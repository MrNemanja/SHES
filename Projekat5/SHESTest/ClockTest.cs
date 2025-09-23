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
    public class ClockTest
    {
        [Test]

        public void TestTick()
        {
            SHES.SHES sHES = new SHES.SHES();
            sHES.clock.Hours = 23;
            sHES.clock.Minutes = 59;
            sHES.clock.Seconds = 59;

            sHES.clock.Date = new Date(11, 9, 2001);

            bool temp = sHES.clock.Tick();
            Assert.AreEqual(true, temp);
        }

        [Test]

        public void GetHours()
        {
            Clock c = new Clock();
            c.Hours = 9;
            Assert.AreEqual(9, c.Hours);
        }

        [Test]

        public void GetMinutes()
        {
            Clock c = new Clock();
            c.Minutes = 9;
            Assert.AreEqual(9, c.Minutes);
        }

        [Test]

        public void GetSeconds()
        {
            Clock c = new Clock();
            c.Seconds = 9;
            Assert.AreEqual(9, c.Seconds);
        }

        [Test]

        public void GetDate()
        {
            Clock c = new Clock();
            c.Date = new Date(1,11,1997);
            Assert.AreEqual(new Date(1,11,1997), c.Date);
        }

        [Test]

        public void ClockKontruktorTest()
        {
            Clock c = new Clock();
            Assert.AreEqual(DateTime.Now.Hour, c.Hours);
            Assert.AreEqual(DateTime.Now.Minute, c.Minutes);
            Assert.AreEqual(DateTime.Now.Second, c.Seconds);
        }
    }
}
