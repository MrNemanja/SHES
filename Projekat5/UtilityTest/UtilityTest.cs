using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Utility;

namespace UtilityTest
{
    [TestFixture]
    public class UtilityTest
    {
        [Test]
        [TestCase(5)]
        [TestCase(100)]
        [TestCase(2300)]
        public void UtilityKonstruktorDobriParametri(int cena)
        {
            Utility.Utility utility = new Utility.Utility(cena);

            Assert.AreEqual(utility.Cena, cena);
        }

        [Test]
        [TestCase("5")]
        [TestCase(3.5)]
        [TestCase(true)]
        public void UtilityKonstruktorLosiParametri(int cena)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Utility.Utility utility = new Utility.Utility(cena);
            }

            );
        }

        [Test]
        [TestCase(null)]
        public void UtilityKonstruktorLosiParametri2(int cena)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Utility.Utility utility = new Utility.Utility(cena);
            }

            );
        }

        [Test]

        public void GetCena()
        {
            Utility.Utility utility = new Utility.Utility();
            utility.Cena = 100;
            Assert.AreEqual(100, utility.Cena);
        }

        [Test]

        public void NaplataTest()
        {
            Utility.Utility utility = new Utility.Utility();
            int x = 50;
            double ret = utility.Naplata(x);
            Assert.AreEqual(x * utility.Cena / 3600.0f, ret);
        }
    }
}
