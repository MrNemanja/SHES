using Oracle.ManagedDataAccess.Client;
using Potrosaci;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Utility;
using Baterry;
using SolarPanel;
using System.Diagnostics;

namespace SHES
{
    public class SHES
    {
        public  List<Potrosaci.Potrosaci> listaPotrosaca = new List<Potrosaci.Potrosaci>();
        public  List<SolarPanel.SolarPanel> listaPanela = new List<SolarPanel.SolarPanel>();
        public  List<Baterry.Battery> listaBaterija = new List<Baterry.Battery>();
        public  List<Podaci> podaci = new List<Podaci>();
        public  IUtility utility = new Utility.Utility();
        public  List<Date> datumi = new List<Date>();
        public  Podaci p = new Podaci(0,0,0,0);
        public int procenatSunca;

        public void Add(Podaci podaci)
        {
            string conString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)" +
                "(PORT=1521)))(CONNECT_DATA=(SID=XE)));User ID=MrClown;Password=axethower79";

            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select count(*) from PODACI";

            OracleDataReader reader = cmd.ExecuteReader();

            if (reader.GetInt32(0) == 0)
            {
                string k2 = string.Format("insert into PODACI values({0},{1},{2},{3},{4})",
                podaci.Energija_baterije, podaci.Energija_distribucije, podaci.Energija_panela, podaci.Potrosnja_potrosaca, 1);
                cmd.CommandText = k2;
                cmd.ExecuteNonQuery();
            }

            cmd.CommandText = "select MAX(redni_broj) from PODACI";

            reader = cmd.ExecuteReader();
           
            string k = string.Format("insert into PODACI values({0},{1},{2},{3},{4})",
                podaci.Energija_baterije,podaci.Energija_distribucije,podaci.Energija_panela,podaci.Potrosnja_potrosaca,
                reader.GetInt32(0) + 1);
            cmd.CommandText = k;
            cmd.ExecuteNonQuery();

        }

        public  Podaci Open(int id)
        {
            Podaci p = new Podaci();

            string conString = "Data Source=(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=localhost)" +
                "(PORT=1521)))(CONNECT_DATA=(SID=XE)));User ID=MrClown;Password=axethower79";

            OracleConnection con = new OracleConnection();
            con.ConnectionString = conString;
            con.Open();

            OracleCommand cmd = con.CreateCommand();
            cmd.CommandText = "select MAX(redni_broj) from PODACI";

            OracleDataReader reader = cmd.ExecuteReader();

            if(id > reader.GetInt32(0) || id < 1)
            {
                p.Energija_baterije = -1;
                p.Energija_distribucije = -1;
                p.Energija_panela = -1;
                p.Potrosnja_potrosaca = -1;

                return p;
            }

            cmd.CommandText = string.Format("select * from PODACI where redni_broj = {0}",id);

                reader = cmd.ExecuteReader();

                p.Energija_baterije = reader.GetInt32(0);
                p.Energija_distribucije = reader.GetInt32(1);
                p.Energija_panela = reader.GetInt32(2);
                p.Potrosnja_potrosaca = reader.GetInt32(3);

            return p;
        }
        public  Clock clock = new Clock();
        public  void radi()
        {
           
            string path = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            int x = ReadFromXmlFile<int>(path + "\\Config.xml");
            //int x = 50;
            Console.WriteLine(x);
            Time(x);
        }

        public async void Time(int x)
        {
            int wait = 1000 / x;
            bool temp = false;
            while (true)
            {
                temp = clock.Tick();
                if (temp) DodajUListuDatuma(clock.Date);
                Ciklus();
                await Task.Delay(wait);
            }
        }

        public void WriteToXmlFile<T>(string filePath, T objectToWrite, bool append = false) where T : new()

        {
            TextWriter writer = null;

            try
            {
                var serializer = new XmlSerializer(typeof(T));

                writer = new StreamWriter(filePath, append);

                serializer.Serialize(writer, objectToWrite);
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        public T ReadFromXmlFile<T>(string filePath) where T : new()
        {
            TextReader reader = null;
            try
            {
                var serializer = new XmlSerializer(typeof(T));

                reader = new StreamReader(filePath);

                return (T)serializer.Deserialize(reader);
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

         public void Ciklus()
        {
            int potrosnja = 0;
            foreach (var v in listaPotrosaca)
            {
                if (v.Stanje)
                {
                    potrosnja += v.Potrosnja;
                    p.Potrosnja_potrosaca += v.Potrosnja;
                }
            }

            foreach (var v in listaPanela)
            {
                potrosnja -= v.primi(procenatSunca);
                p.Energija_panela += v.primi(procenatSunca);
            }
            
            if (clock.Hours >= 3 && clock.Hours < 6)
            {
                foreach (var v in listaBaterija)
                {
                    if (v.Kapacitet < 3 * 3600)
                    {
                        potrosnja += v.MaxSnaga;
                        v.Kapacitet++;
                        p.Energija_baterije -= v.Kapacitet;
                    }
                }
            }                   
            else if (clock.Hours >= 14 && clock.Hours < 17)
            {
                foreach (var v in listaBaterija)
                {
                    if (v.Kapacitet > 0)
                    {
                        potrosnja -= v.MaxSnaga;
                        v.Kapacitet--;
                        p.Energija_baterije += v.Kapacitet;
                    }
                }
            }
            
            double naplata = utility.Naplata(potrosnja);
            p.Energija_distribucije = naplata;
        }
        public  void NacrtajGrafik(int dani)
        {
            podaci.Clear();
            int x = (dani - 1) * 86400;
            for (int i = 0; i < 86400; i+=100)
            {
                podaci.Add(Open(x + i));
            }
            string filename = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;

            WriteToXmlFile<List<Podaci>>(filename + "\\Grafik.xml",podaci);

            Process p = new Process();
            p.StartInfo.FileName = "Grafik.exe";
            p.StartInfo.Arguments = filename + "\\Grafik.xml";
            p.Start();
            p.WaitForExit();
        }

        public  void DodajUListuPotrosaca(Potrosaci.Potrosaci potrosaci)
        {
            listaPotrosaca.Add(potrosaci);
        }

        public  void DodajUListuBaterija(Battery battery)
        {
            listaBaterija.Add(battery);
        }

        public  void DodajUListuPanela(SolarPanel.SolarPanel solarPanel)
        {
            listaPanela.Add(solarPanel);
        }

        public  void DodajUListuDatuma(Date date)
        {
            datumi.Add(date);
        }

        public  void IzmeniPotrosace(string unos)
        {
            foreach (var v in listaPotrosaca)
            {
                if (unos.Equals(v.Ime))
                {
                    v.Stanje = !v.Stanje;
                    return;
                }
            }
        }

        public  void ObrisiIzListeBaterija(Battery battery)
        {
            listaBaterija.Remove(battery);
        }

        public  void ObrisiIzListePanela(SolarPanel.SolarPanel solarPanel)
        {
            listaPanela.Remove(solarPanel);
        }
    }

}
