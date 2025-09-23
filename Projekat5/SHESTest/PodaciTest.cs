using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SHES;

namespace SHESTest
{
    [TestFixture]
    public class PodaciTest
    {
        [Test]
        [TestCase(-5, 100, 20, 50)]
        [TestCase(2, -2400, 30, 20)]
        [TestCase(11, 33, 66, 99)]
        [TestCase(978, 312, 78, 11)]
        public void PodaciKonstruktorDobriParametri(int energija_baterije, double energija_distribucije, int energija_panela, 
            int potrosnja_potrosaca)
        {
            Podaci podaci = new Podaci(energija_baterije, energija_distribucije, energija_panela, potrosnja_potrosaca);

            Assert.AreEqual(podaci.Energija_baterije,energija_baterije);
            Assert.AreEqual(podaci.Energija_distribucije, energija_distribucije);
            Assert.AreEqual(podaci.Energija_panela, energija_panela);
            Assert.AreEqual(podaci.Potrosnja_potrosaca, potrosnja_potrosaca);
        }

        [Test]
        [TestCase("123", 100, 20, 50)]
        [TestCase(2, false, 30, 20)]
        [TestCase(11, 33, 0.5, 99)]

        public void PodaciKonstruktorLosiParametri(int energija_baterije, double energija_distribucije, int energija_panela,
            int potrosnja_potrosaca)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Podaci podaci = new Podaci(energija_baterije, energija_distribucije, energija_panela, potrosnja_potrosaca);
            }

            );
        }

        [Test]
        [TestCase(null, 2000, 20, 25)]
        [TestCase(10, 34, null, false)]
        [TestCase(3, 2400, 50, null)]
        [TestCase(3, null, 50, 60)]

        public void PodaciKonstruktorLosiParametri2(int energija_baterije, double energija_distribucije, int energija_panela,
            int potrosnja_potrosaca)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Podaci podaci = new Podaci(energija_baterije, energija_distribucije, energija_panela, potrosnja_potrosaca);
            }

            );
        }

        [Test]

        public void GetEnergijaBaterije()
        {
            Podaci podaci = new Podaci();
            podaci.Energija_baterije = 100;
            Assert.AreEqual(100, podaci.Energija_baterije);
        }

        [Test]

        public void GetEnergijaDistribucije()
        {
            Podaci podaci = new Podaci();
            podaci.Energija_distribucije = 50;
            Assert.AreEqual(50, podaci.Energija_distribucije);
        }

        [Test]

        public void GetEnergijaPanela()
        {
            Podaci podaci = new Podaci();
            podaci.Energija_panela = 10;
            Assert.AreEqual(10, podaci.Energija_panela);
        }

        public void GetPotrosnjaPotrosaca()
        {
            Podaci podaci = new Podaci();
            podaci.Potrosnja_potrosaca = 666;
            Assert.AreEqual(666, podaci.Potrosnja_potrosaca);
        }
    }
}
