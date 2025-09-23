using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SolarPanel;
using Moq;

namespace SolarPanelTest
{
    [TestFixture]
    public class ISolarPanelTest
    {
        [Test]
        public void ISolarPanelTesting()
        {
            int x = 30;
            var mock = new Mock<ISolarPanel>();
            mock.SetupGet(m => m.Id).Returns(1);
            mock.SetupGet(m => m.Max_snaga).Returns(6);
            mock.Setup(m => m.primi(x)).Returns(x * mock.Object.Max_snaga / 100);
            double rez = mock.Object.primi(x);
            Assert.AreEqual(1, mock.Object.Id);
            Assert.AreEqual(6, mock.Object.Max_snaga);
            Assert.AreEqual(1.8, rez);
            
        }
    }
}
