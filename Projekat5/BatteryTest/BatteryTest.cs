using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Baterry;
using Moq;

namespace BatteryTest
{
    [TestFixture]
    public class BatteryTest
    {
        [Test]
        [TestCase(5, 1200, 130)]
        [TestCase(2, 2400, 150)]
        [TestCase(3, 1000, 20)]
        public void BaterijaKonstruktorDobriParametri(int id, int max, int kap)
        {
            Battery battery = new Battery(id, max, kap);

            Assert.AreEqual(battery.Id, id);
            Assert.AreEqual(battery.MaxSnaga, max);
            Assert.AreEqual(battery.Kapacitet, kap);
        }

        [Test]
        [TestCase("5", 1200, 1000)]
        [TestCase(3, "120", 600)]
        [TestCase(5, 2400, 125.6)]

        public void BaterijaKonstruktorLosiParametri(int id, int max, int kap)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Battery battery = new Battery(id, max, kap);
            }

            );
        }

        [Test]
        [TestCase(null, 2000, 50)]
        [TestCase(10, null, 100000)]
        [TestCase(12, 2400, null)]

        public void BaterijaKonstruktorLosiParametri2(int id, int max, int kap)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Battery battery = new Battery(id, max, kap);
            }

            );
        }

        [Test]

        public void GetID()
        {
            Battery battery = new Battery();
            battery.Id = 1;
            Assert.AreEqual(1, battery.Id);
        }

        [Test]

        public void GetMaxSnaga()
        {
            Battery battery = new Battery();
            battery.MaxSnaga = 3;
            Assert.AreEqual(3, battery.MaxSnaga);
        }

        [Test]

        public void GetKapacitet()
        {
            Battery battery = new Battery();
            battery.Kapacitet = 1;
            Assert.AreEqual(1, battery.Kapacitet);
        }

    }
}
