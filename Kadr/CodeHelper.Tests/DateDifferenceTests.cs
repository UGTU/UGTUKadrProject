using System;
using APG.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeHelper.Tests
{
    [TestClass]
    public class DateDifferenceTests
    {
        [TestMethod]
        public void GetAgeShouldReturnExactlyOneYearTest()
        {
            var bd = DateTime.Parse("01.01.2014");
            var today = DateTime.Parse("01.01.2015");
            var age = new DateDifference(bd, today);
            Assert.AreEqual(1, age.Years);
            Assert.AreEqual(0, age.Months);
            Assert.AreEqual(0, age.Days);
        }
        [TestMethod]
        public void GetAgeShouldBeCorrectInDayMonthSubstructionTest()
        {
            var bd = DateTime.Parse("15.06.2014");
            var today = DateTime.Parse("01.01.2015");
            var age = new DateDifference(bd, today);
            Assert.AreEqual(0, age.Years);
            Assert.AreEqual(6, age.Months);
            Assert.AreEqual(16, age.Days);
        }
        [TestMethod]
        public void GetAgeShouldBeZeroTest()
        {
            var bd = DateTime.Parse("15.06.2014");
            var today = DateTime.Parse("15.06.2014");
            var age = new DateDifference(bd, today);
            Assert.AreEqual(0, age.Years);
            Assert.AreEqual(0, age.Months);
            Assert.AreEqual(0, age.Days);
        }
        [TestMethod]
        public void GetAgeShouldBeZeroWhenAllMaxTest()
        {
            var bd = DateTime.Parse("31.12.2014");
            var today = DateTime.Parse("31.12.2014");
            var age = new DateDifference(bd, today);
            Assert.AreEqual(0, age.Years);
            Assert.AreEqual(0, age.Months);
            Assert.AreEqual(0, age.Days);
        }
        [TestMethod]
        public void GetAgeShouldCorrectWhenLeapYearsSubsTest()
        {
            var bd = DateTime.Parse("29.02.2012");
            var today = DateTime.Parse("01.03.2015");
            var age = new DateDifference(bd, today);
            Assert.AreEqual(3, age.Years);
            Assert.AreEqual(0, age.Months);
            Assert.AreEqual(1, age.Days);
        }
    }
}
