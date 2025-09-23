using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Moq;
using Potrosaci;

namespace PotrosaciTest
{
    [TestFixture]
   public class IPotrosaciTest
    {
        [Test]

        public void IPotrosaciTesting()
        {
            var mock = new Mock<IPotrosaci>();
            mock.SetupGet(m => m.Ime).Returns("2");
            mock.SetupGet(m => m.Potrosnja).Returns(3);
            mock.SetupGet(m => m.Stanje).Returns(true);
            Assert.AreEqual("2", mock.Object.Ime);
            Assert.AreEqual(3, mock.Object.Potrosnja);
            Assert.AreEqual(true, mock.Object.Stanje);
        }
    }
}
