using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SHES
{
    public class Program
    {
        public SHES sHES = new SHES();

        static void Main(string[] args)
        {
            Program p = new Program();
            int broj_panela = 0;
            int broj_baterija = 0;
            int broj_potrosaca = 0;

            Console.WriteLine("DOBRODOSLI U SMART HOME ENERGY SYSTEM");
            Console.WriteLine("Obavezan unos:");
            Console.WriteLine(" 1.Broj solarnih panela.");
            Console.WriteLine(" 2.Broj Baterija.");
            Console.WriteLine(" 3.Broj Potrosaca.");
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Broj solarnih panela:");
            try
            {
                broj_panela = Int32.Parse(Console.ReadLine());

            }catch(Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("Broj baterija:");
            try
            {
                broj_baterija = Int32.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            Console.WriteLine("Broj potrosaca:");
            try
            {
                broj_potrosaca = Int32.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            Random r = new Random();
            int id = 0;
            

            while(broj_panela > 0)
            {
                foreach (var v in p.sHES.listaPanela)
                {
                    if (v.Id > id)
                        id = v.Id;
                }

                id++;
                broj_panela--;
                p.sHES.DodajUListuPanela(new SolarPanel.SolarPanel(id, r.Next(1,10)));
            }

            id = 0;

            while (broj_baterija > 0)
            {
                foreach (var v in p.sHES.listaBaterija)
                {
                    if (v.Id > id)
                        id = v.Id;
                }

                id++;
                broj_baterija--;
                p.sHES.DodajUListuBaterija(new Baterry.Battery(id, r.Next(1, 3), 0));
            }

            string ime = "0";

            while (broj_potrosaca > 0)
            {
                foreach (Potrosaci.Potrosaci v in p.sHES.listaPotrosaca)
                {
                    if (Int32.Parse(ime) < Int32.Parse(v.Ime))
                    {
                        ime = v.Ime;
                    }
                }

                int i = Int32.Parse(ime) + 1;
                ime = i.ToString();
                broj_potrosaca--;
                p.sHES.DodajUListuPotrosaca(new Potrosaci.Potrosaci(ime, r.Next(1,3), true));
            }

            Console.Clear();

            p.sHES.radi();

            while (true)
            {
                Console.WriteLine("Odaberite opciju:");
                Console.WriteLine(" 1.Izmena stanja potrosaca.");
                Console.WriteLine(" 2.Dodavanje novog potrosaca.");
                Console.WriteLine(" 3.Dodavanje novog solarnog panela.");
                Console.WriteLine(" 4.Dodavanje nove baterije.");
                Console.WriteLine(" 5.Uklanjanje solarnog panela.");
                Console.WriteLine(" 6.Uklanjanje baterije.");
                Console.WriteLine(" 7.Izmena snage sunceve svetlosti.");
                Console.WriteLine(" 8.Ispis vremena.");
                Console.WriteLine(" 9.Nacrtaj grafik za dan.");
                Console.WriteLine(Environment.NewLine);
                int unos = 0;
                try
                {
                    unos = Int32.Parse(Console.ReadLine());

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }

                switch (unos)
                {
                    case 1:
                        p.IzmeniStanjePotrosaca();
                        break;
                    case 2:
                        p.DodajPotrosaca();
                        break;
                    case 3:
                        p.DodajPanel();
                        break;
                    case 4:
                        p.DodajBateriju();
                        break;
                    case 5:
                        p.ObrisiPanel();
                        break;
                    case 6:
                        p.ObrisiBateriju();
                        break;
                    case 7:
                        p.PromeniSnaguSunca();
                        break;
                    case 8:
                        p.IspisiVreme();
                        break;
                    case 9:
                        p.NacrtajGrafik();
                        break;
                    default:
                        break;
                }
            }


        }

        void NacrtajGrafik()
        {
            Console.WriteLine("Unesite datum: ");
            string unos = Console.ReadLine();
            string[] datum = unos.Split('/');
            int dan = Int32.Parse(datum[0]);
            int mesec = Int32.Parse(datum[1]);
            int godina = Int32.Parse(datum[2]);

            if (!sHES.datumi.Contains(new Date(dan, mesec, godina)))
            {
                Console.WriteLine("Greska pri unosu datuma.");
                return;
            }

            DateTime first = new DateTime(sHES.datumi[0].Year, sHES.datumi[0].Month, sHES.datumi[0].Day);
            DateTime curr = new DateTime(godina, mesec, dan);

            TimeSpan pass = curr - first;

            sHES.NacrtajGrafik((int)pass.TotalDays);
        }

         void IzmeniStanjePotrosaca()
        {
            Console.WriteLine("Stanje kog potrosaca bi zeleli da izmenite?");
            foreach (var v in sHES.listaPotrosaca)
            {
                Console.WriteLine(v.Ime + " " + v.Potrosnja + "kW " + v.Stanje);
            }

            string unos = Console.ReadLine();
            sHES.IzmeniPotrosace(unos);
            Console.WriteLine("Stanje '" + unos + "' potrosaca je promenjeno.");
        }

        void DodajPanel()
        {
            Random r = new Random();
            int id = 0;

            foreach (var v in sHES.listaPanela)
            {
                if (v.Id > id)
                    id = v.Id;
            }

            id++;
            sHES.DodajUListuPanela(new SolarPanel.SolarPanel(id, r.Next(1, 10)));

            Console.WriteLine("Solarni panel uspesno dodat!");
        }

         void IspisiVreme()
        {
            Console.WriteLine(sHES.clock.Hours + ":" + sHES.clock.Minutes + ":" + sHES.clock.Seconds);
        }

         void DodajPotrosaca()
        {
            Random r = new Random();
            string ime = "0";

            foreach (var v in sHES.listaPotrosaca)
            {
                if (Int32.Parse(ime) < Int32.Parse(v.Ime))
                {
                    ime = v.Ime;
                }
            }

            int i = Int32.Parse(ime) + 1;
            ime = i.ToString();

            sHES.DodajUListuPotrosaca(new Potrosaci.Potrosaci(ime, r.Next(2), true));

            Console.WriteLine("Potrosac uspesno dodat!");
        }

         void DodajBateriju()
        {
            Random r = new Random();
            int id = 0;

            foreach (var v in sHES.listaBaterija)
            {
                if (v.Id > id)
                    id = v.Id;
            }

            id++;
            sHES.DodajUListuBaterija(new Baterry.Battery(id, r.Next(1, 3), 0));

            Console.WriteLine("Baterija uspesno dodata!");

        }

         void PromeniSnaguSunca()
        {
            int snagaSunca = 50;
            do
            {
                Console.WriteLine("Unesite snagu Sunca - ");

                try
                {
                    snagaSunca = Int32.Parse(Console.ReadLine());

                }
                catch (Exception e)
                {
                    Console.WriteLine(e.StackTrace);
                }
            } while (snagaSunca < 0 || snagaSunca > 100);

            sHES.procenatSunca = snagaSunca;
        }

         void ObrisiPanel()
        {
            int id = 0;
            Console.WriteLine("Koji od panela zelite da uklonite?");
            foreach (var v in sHES.listaPanela)
            {
                Console.WriteLine(v.Id + " " + v.Max_snaga + "kW");
            }

            try
            {
                id = Int32.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            foreach (var v in sHES.listaPanela)
            {
                if (id == v.Id)
                {
                    sHES.ObrisiIzListePanela(v);
                    Console.WriteLine("Panel uspesno uklonjen.");
                    return;
                }
            }
        }
         void ObrisiBateriju()
        {
            int id = 0;
            Console.WriteLine("Koju bateriju zelite da uklonite?");
            foreach (var v in sHES.listaBaterija)
            {
                Console.WriteLine(v.Id + " " + v.MaxSnaga + "kW " + v.Kapacitet * 60 + "min");
            }

            try
            {
                id = Int32.Parse(Console.ReadLine());

            }
            catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }

            foreach (var v in sHES.listaBaterija)
            {
                if (id == v.Id)
                {
                    sHES.ObrisiIzListeBaterija(v);
                    Console.WriteLine("Baterija uspesno uklonjena.");
                    return;
                }
            }
        }
    }
}
