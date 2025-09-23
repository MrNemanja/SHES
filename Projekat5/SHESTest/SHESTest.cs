using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SHES;
using NUnit.Framework;

namespace SHESTest
{
    [TestFixture]
    public class SHESTest
    {
        [Test]
        public void CiklusTest()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.listaPotrosaca.Add(new Potrosaci.Potrosaci("1",5,true));
            sHES.listaBaterija.Add(new Baterry.Battery(2, 6, 1));
            sHES.listaPanela.Add(new SolarPanel.SolarPanel(2, 4));
            sHES.procenatSunca = 20;
            sHES.clock.Hours = 2;
            sHES.clock.Minutes = 30;
            sHES.clock.Seconds = 15;
            Utility.Utility utility = new Utility.Utility(5);

            Podaci p = new Podaci(1,utility.Naplata(sHES.listaPotrosaca[0].Potrosnja - (sHES.listaPanela[0].Max_snaga * sHES.procenatSunca)),sHES.listaPanela[0].Max_snaga * sHES.procenatSunca,sHES.listaPotrosaca[0].Potrosnja);
            sHES.Ciklus();
            Assert.AreEqual(p, sHES.p);

        }

        [Test]
        public void CiklusTestBaterijaPotrosac()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.listaPotrosaca.Add(new Potrosaci.Potrosaci("1", 5, true));
            sHES.listaBaterija.Add(new Baterry.Battery(2, 6, 1));
            sHES.listaPanela.Add(new SolarPanel.SolarPanel(2, 4));
            sHES.procenatSunca = 20;
            sHES.clock.Hours = 3;
            sHES.clock.Minutes = 30;
            sHES.clock.Seconds = 15;
            Utility.Utility utility = new Utility.Utility(5);

            Podaci p = new Podaci(sHES.listaBaterija[0].Kapacitet, utility.Naplata((sHES.listaPotrosaca[0].Potrosnja + sHES.listaBaterija[0].MaxSnaga) - (sHES.listaPanela[0].Max_snaga * sHES.procenatSunca)), sHES.listaPanela[0].Max_snaga * sHES.procenatSunca, sHES.listaPotrosaca[0].Potrosnja + sHES.listaBaterija[0].MaxSnaga);
            sHES.Ciklus();
            Assert.AreEqual(p, sHES.p);

        }

        [Test]
        public void CiklusTestBaterijaGenerator()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.listaPotrosaca.Add(new Potrosaci.Potrosaci("1", 5, true));
            sHES.listaBaterija.Add(new Baterry.Battery(2, 6, 1));
            sHES.listaPanela.Add(new SolarPanel.SolarPanel(2, 4));
            sHES.procenatSunca = 20;
            sHES.clock.Hours = 14;
            sHES.clock.Minutes = 30;
            sHES.clock.Seconds = 15;
            Utility.Utility utility = new Utility.Utility(5);

            Podaci p = new Podaci(sHES.listaBaterija[0].Kapacitet, utility.Naplata((sHES.listaPotrosaca[0].Potrosnja - sHES.listaBaterija[0].MaxSnaga) - (sHES.listaPanela[0].Max_snaga * sHES.procenatSunca)), sHES.listaPanela[0].Max_snaga * sHES.procenatSunca, sHES.listaPotrosaca[0].Potrosnja);
            sHES.Ciklus();
            Assert.AreEqual(p, sHES.p);

        }

        [Test]

        public void TestDodajUListuPotrosaca()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.DodajUListuPotrosaca(new Potrosaci.Potrosaci("1", 5, true));

            Assert.AreEqual(1, sHES.listaPotrosaca.Count);
        }

        [Test]

        public void TestDodajUListuBaterija()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.DodajUListuBaterija(new Baterry.Battery(2,4,1));

            Assert.AreEqual(1, sHES.listaBaterija.Count);
        }

        [Test]

        public void TestDodajUListuPanela()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.DodajUListuPanela(new SolarPanel.SolarPanel(2,5));

            Assert.AreEqual(1, sHES.listaPanela.Count);
        }

        [Test]

        public void TestDodajUListuDatuma()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.DodajUListuDatuma(new Date(8,11,2006));

            Assert.AreEqual(1, sHES.datumi.Count);
        }

        [Test]

        public void TestIzmeniPotrosace()
        {
            SHES.SHES sHES = new SHES.SHES();
            string dobra_izmena = "1";
            string losa_izmena = "ba";
            
            sHES.listaPotrosaca.Add(new Potrosaci.Potrosaci("1", 5, true));
            sHES.IzmeniPotrosace(dobra_izmena);
            Assert.AreEqual(false, sHES.listaPotrosaca[0].Stanje);

            sHES.listaPotrosaca.Add(new Potrosaci.Potrosaci("3", 4, false));
            List<Potrosaci.Potrosaci> temp = sHES.listaPotrosaca; 
            sHES.IzmeniPotrosace(losa_izmena);
            Assert.AreEqual(temp, sHES.listaPotrosaca);

        }

        [Test]

        public void TestObrisiIzListeBaterija()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.listaBaterija.Add(new Baterry.Battery(2, 4, 1));
            sHES.ObrisiIzListeBaterija(sHES.listaBaterija[0]);

            Assert.AreEqual(0, sHES.listaBaterija.Count);
        }

        [Test]
        public void TestObrisiIzListePanela()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.listaPanela.Add(new SolarPanel.SolarPanel(1,5));
            sHES.ObrisiIzListePanela(sHES.listaPanela[0]);

            Assert.AreEqual(0, sHES.listaPanela.Count);
        }

        [Test]

        public void XMLReaderTest()
        {
            SHES.SHES sHES = new SHES.SHES();

            Assert.Throws<SystemException>(() =>
                {
                    var v = sHES.ReadFromXmlFile<Object>(@"C:\\temp\\test.xml");
                }
                );
        }

        [Test]

        public void XMLWriterTest()
        {
            SHES.SHES sHES = new SHES.SHES();

            Assert.Throws<SystemException>(() =>
            {
                sHES.WriteToXmlFile<Object>(@"C:\\temp\\test.xml", new Object());
            }
            );
        }
    }
}
