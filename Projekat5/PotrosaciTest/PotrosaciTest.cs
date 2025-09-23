using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Potrosaci;

namespace PotrosaciTest
{
    [TestFixture]
    public class PotrosaciTest
    {
        [Test]
        [TestCase("3",1200,true)]
        [TestCase("2",2400,false)]
        [TestCase("5",1000,true)]
        public void PotrosaciKonstruktorDobriParametri(string ime, int potrosnja, bool stanje)
        {
            Potrosaci.Potrosaci potrosaci = new Potrosaci.Potrosaci(ime, potrosnja, stanje);

            Assert.AreEqual(potrosaci.Ime, ime);
            Assert.AreEqual(potrosaci.Potrosnja, potrosnja);
            Assert.AreEqual(potrosaci.Stanje, stanje);
        }

        [Test]
        [TestCase("",1200,true)]
        [TestCase("1","k",false)]
        [TestCase("3",2400,10)]
        [TestCase(100, 2400,true)]

        public void PotrosaciKonstruktorLosiParametri(string ime, int potrosnja, bool stanje)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Potrosaci.Potrosaci potrosaci = new Potrosaci.Potrosaci(ime, potrosnja, stanje);
            }

            ); 
        }

        [Test]
        [TestCase(null, 2000, true)]
        [TestCase("2", null, false)]
        [TestCase("3", 2400, null)]

        public void PotrosaciKonstruktorLosiParametri2(string ime, int potrosnja, bool stanje)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Potrosaci.Potrosaci potrosaci = new Potrosaci.Potrosaci(ime, potrosnja, stanje);
            }

            );
        }

        [Test]

        public void GetIme()
        {
            Potrosaci.Potrosaci potrosaci = new Potrosaci.Potrosaci();
            potrosaci.Ime = "1";
            Assert.AreEqual("1", potrosaci.Ime);
        }

        [Test]

        public void GetPotrosnja()
        {
            Potrosaci.Potrosaci potrosaci = new Potrosaci.Potrosaci();
            potrosaci.Potrosnja = 5;
            Assert.AreEqual(5, potrosaci.Potrosnja);
        }

        [Test]

        public void GetStanje()
        {
            Potrosaci.Potrosaci potrosaci = new Potrosaci.Potrosaci();
            potrosaci.Stanje = true;
            Assert.AreEqual(true, potrosaci.Stanje);
        }

    }
}
