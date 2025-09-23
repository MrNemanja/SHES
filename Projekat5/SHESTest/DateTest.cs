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
    public class DateTest
    {
        [Test]

        public void DateIncreaseTest()
        {
            Date date = new Date(31, 12, 2019);
            date.DateIncrease();
            Assert.AreEqual(new Date(1, 1, 2020), date);
            Date date1 = new Date(28, 2, 2003);
            date1.DateIncrease();
            Assert.AreEqual(new Date(1, 3, 2003), date1);
            Date date2 = new Date(29, 2, 2004);
            date2.DateIncrease();
            Assert.AreEqual(new Date(1, 3, 2004), date2);
            Date date3 = new Date(28, 2, 2004);
            date3.DateIncrease();
            Assert.AreEqual(new Date(29, 2, 2004), date3);
            Date date4 = new Date(30, 4, 2004);
            date4.DateIncrease();
            Assert.AreEqual(new Date(1, 5, 2004), date4);
            Date date5 = new Date(14, 2, 2004);
            date5.DateIncrease();
            Assert.AreEqual(new Date(15, 2, 2004), date5);
        }

        [Test]

        public void DateKontruktorTest()
        {
            Date date = new Date();
            Assert.AreEqual(DateTime.Now.Year, date.Year);
            Assert.AreEqual(DateTime.Now.Month, date.Month);
            Assert.AreEqual(DateTime.Now.Day, date.Day);
        }

        [Test]
        [TestCase(5, 12, 2013)]
        [TestCase(2, 11, 1502)]
        [TestCase(3, 10, 2000)]
        public void DateKonstruktorDobriParametri(int day, int month, int year)
        {
            Date date = new Date(day, month, year);

            Assert.AreEqual(date.Day,day);
            Assert.AreEqual(date.Month,month);
            Assert.AreEqual(date.Year,year);
        }

        [Test]
        [TestCase("5", 1200, 1000)]
        [TestCase(3, "120", 600)]
        [TestCase(5, 2, true)]
        [TestCase(12.5, 2, 1203)]
        public void DateKonstruktorLosiParametri(int day, int month, int year)
        {
            Assert.Throws<ArgumentException>(() =>
            {
                Date date = new Date(day, month, year);
            }

            );
        }

        [Test]
        [TestCase(null, 20, 2018)]
        [TestCase(10, null, 1000)]
        [TestCase(12, 2, null)]

        public void DateKonstruktorLosiParametri2(int day, int month, int year)
        {
            Assert.Throws<ArgumentNullException>(() =>
            {
                Date date = new Date(day, month, year);
            }

            );
        }

        [Test]

        public void GetDay()
        {
            Date date = new Date();
            date.Day = 9;
            Assert.AreEqual(9, date.Day);
        }

        [Test]

        public void GetMonth()
        {
            Date date = new Date();
            date.Month = 4;
            Assert.AreEqual(4, date.Month);
        }

        [Test]

        public void GetYear()
        {
            Date date = new Date();
            date.Year = 9;
            Assert.AreEqual(9, date.Year);
        }

    }
}
