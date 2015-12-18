using System;
using APG.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeHelper.Tests
{
    [TestClass]
    public class DateDifferenceFixture
    {

        private static void CheckDate(DateSpan actual, int expectedDays, int expectedMonths, int expectedYears)
        {
            Assert.AreEqual(expectedDays, actual.Days);
            Assert.AreEqual(expectedMonths, actual.Months);
            Assert.AreEqual(expectedYears, actual.Years);
        }

        [TestMethod]
        public void SimpleDateTests()
        {
            var d1 = new DateSpan(0, 0, 0);
            var d2 = new DateSpan(0, 0, 0);
            var d3 = d1 + d2;
            CheckDate(d3, 0, 0, 0);
            CheckDate(d3.Add(new DateSpan(1, 0, 0)), 1, 0, 0);
            CheckDate(d3.Add(new DateSpan(0, 1, 0)), 0, 1, 0);
            CheckDate(d3.Add(new DateSpan(0, 0, 1)), 0, 0, 1);
        }
        [TestMethod]
        public void SimpleDateDaysSubstractTests()
        {
            var d1 = new DateSpan(1, 0, 0);            
            var d2 = d1 - 1;
            CheckDate(d2, 0, 0, 0);            
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void DateDaysSubstractFromZeroMustThrowExceptionTests()
        {
            var d1 = new DateSpan(0, 0, 0);
            var d2 = d1 - 1;            
        }

        [TestMethod]        
        public void DateDaysSubstractMonthTests()
        {
            var d1 = new DateSpan(0, 1, 0);
            var d2 = d1 - 30;
            CheckDate(d2, 0, 0, 0);
        }

        [TestMethod]
        public void DateDaysSubstractYearTests()
        {
            var d1 = new DateSpan(0, 0, 1);
            var d2 = d1 - 360;
            CheckDate(d2, 0, 0, 0);
        }

        [TestMethod]
        public void ComplexDateDaysSubstractTest()
        {
            var d1 = new DateSpan(10, 10, 1);
            var d2 = d1 - (360+300+10);
            CheckDate(d2, 0, 0, 0);
        }

        [TestMethod]
        public void SimpleDaysDateTests()
        {
            var d1 = new DateSpan(30, 0, 0);
            var d2 = new DateSpan(0, 0, 0);
            var d3 = d1.Add(d2);
            CheckDate(d3, 0, 1, 0);
        }

        [TestMethod]
        public void SimpleMonthDateTests()
        {
            var d1 = new DateSpan(0, 11, 0);
            var d2 = new DateSpan(0, 2, 0);
            var d3 = d1.Add(d2);
            CheckDate(d3, 0, 1, 1);
        }

        [TestMethod]
        public void ComplexDaysMonthDateTests()
        {
            var d1 = new DateSpan(30, 11, 1);
            var d2 = new DateSpan(5, 2, 1);
            var d3 = d1.Add(d2);
            CheckDate(d3, 5, 2, 3);
        }

        [TestMethod]
        public void GetAgeShouldReturnExactlyOneYearTest()
        {
            var bd = DateTime.Parse("01.01.2014");
            var today = DateTime.Parse("01.01.2015");
            var age = new DateSpanDifference(bd, today);
            Assert.AreEqual(1, age.Years);
            Assert.AreEqual(0, age.Months);
            Assert.AreEqual(0, age.Days);
        }
        [TestMethod]
        public void GetAgeShouldBeCorrectInDayMonthSubstructionTest()
        {
            var bd = DateTime.Parse("15.06.2014");
            var today = DateTime.Parse("01.01.2015");
            var age = new DateSpanDifference(bd, today);
            Assert.AreEqual(0, age.Years);
            Assert.AreEqual(6, age.Months);
            Assert.AreEqual(16, age.Days);
        }
        [TestMethod]
        public void GetAgeShouldBeZeroTest()
        {
            var bd = DateTime.Parse("15.06.2014");
            var today = DateTime.Parse("15.06.2014");
            var age = new DateSpanDifference(bd, today);
            Assert.AreEqual(0, age.Years);
            Assert.AreEqual(0, age.Months);
            Assert.AreEqual(0, age.Days);
        }
        [TestMethod]
        public void GetAgeShouldBeZeroWhenAllMaxTest()
        {
            var bd = DateTime.Parse("31.12.2014");
            var today = DateTime.Parse("31.12.2014");
            var age = new DateSpanDifference(bd, today);
            Assert.AreEqual(0, age.Years);
            Assert.AreEqual(0, age.Months);
            Assert.AreEqual(0, age.Days);
        }
        [TestMethod]
        public void GetAgeShouldCorrectWhenLeapYearsSubsTest()
        {
            var bd = DateTime.Parse("29.02.2012");
            var today = DateTime.Parse("01.03.2015");
            var age = new DateSpanDifference(bd, today);
            Assert.AreEqual(3, age.Years);
            Assert.AreEqual(0, age.Months);
            Assert.AreEqual(1, age.Days);
        }
        [TestMethod]
        public void DateSubstractShouldBe30Days()
        {
            var bd = DateTime.Parse("01.12.2015");
            var today = DateTime.Parse("31.12.2015");
            var age = new DateSpanDifference(bd, today);
            CheckDate(age, 30, 0, 0);
        }
        [TestMethod]
        public void DateSubstractShouldBe1and1DayMonth()
        {
            var bd = DateTime.Parse("30.11.2015");
            var today = DateTime.Parse("31.12.2015");
            var age = new DateSpanDifference(bd, today);
            CheckDate(age, 1, 1, 0);
        }

    }
}
