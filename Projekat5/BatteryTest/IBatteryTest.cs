using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Baterry;

namespace BatteryTest
{
    [TestFixture]
    public class IBatteryTest
    {
        [Test]

        public void IBatteryTesting()
        {
            var mock = new Mock<IBattery>();
            mock.SetupGet(m => m.Id).Returns(2);
            mock.SetupGet(m => m.MaxSnaga).Returns(3);
            mock.SetupGet(m => m.Kapacitet).Returns(1);
            Assert.AreEqual(2, mock.Object.Id);
            Assert.AreEqual(3, mock.Object.MaxSnaga);
            Assert.AreEqual(1, mock.Object.Kapacitet);
        }
    }
}
