using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace SolarPanelTest
{
    [TestFixture]
    public class SolarPanelTest
    {
        [Test]
        [TestCase(5,10)]
        [TestCase(13, 2)]
        [TestCase(16, 1)]
        public void SolarPanelKonstruktorDobriParametri(int id,int maxsnaga)
        {
            SolarPanel.SolarPanel solarPanel = new SolarPanel.SolarPanel(id, maxsnaga);

            Assert.AreEqual(solarPanel.Id,id);
            Assert.AreEqual(solarPanel.Max_snaga,maxsnaga);
        }

        [Test]
        [TestCase("5",1)]
        [TestCase(2,3.5)]
        [TestCase(true,5)]
        public void SolarPanelKonstruktorLosiParametri(int id, int maxsnaga)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                SolarPanel.SolarPanel solarPanel = new SolarPanel.SolarPanel(id, maxsnaga);
            }

            );
        }

        [Test]
        [TestCase(null,3)]
        [TestCase(5,null)]
        public void SolarPanelKonstruktorLosiParametri2(int id, int maxsnaga)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                SolarPanel.SolarPanel solarPanel = new SolarPanel.SolarPanel(id, maxsnaga);
            }

            );
        }

        [Test]

        public void GetId()
        {
            SolarPanel.SolarPanel solarPanel = new SolarPanel.SolarPanel();
            solarPanel.Id = 2;
            Assert.AreEqual(2, solarPanel.Id);
        }

        [Test]

        public void GetMaxSnaga()
        {
            SolarPanel.SolarPanel solarPanel = new SolarPanel.SolarPanel();
            solarPanel.Max_snaga = 6;
            Assert.AreEqual(6, solarPanel.Max_snaga);
        }

        [Test]

        public void PrimiTest()
        {
            SolarPanel.SolarPanel solarPanel = new SolarPanel.SolarPanel();
            int x = 50;
            int ret = solarPanel.primi(x);
            Assert.AreEqual(x * solarPanel.Max_snaga / 100, ret);
        }
    }
}
