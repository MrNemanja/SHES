using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Utility;
using Moq;

namespace UtilityTest
{
    [TestFixture]
    public class IUtilityTest
    {
        [Test]
        public void IUtilityTesting()
        {
            int x = 55;
            var mock = new Mock<IUtility>();
            mock.SetupGet(m => m.Cena).Returns(10);
            mock.Setup(m => m.Naplata(x)).Returns(x * mock.Object.Cena / 3600.0f);
            double rez = mock.Object.Naplata(x);
            Assert.AreEqual(10, mock.Object.Cena);
            Assert.AreEqual(0.1527777777777778, rez);

        }
    }
}
