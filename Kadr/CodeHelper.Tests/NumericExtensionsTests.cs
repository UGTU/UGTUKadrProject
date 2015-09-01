using System;
using APG.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeHelper.Tests
{
    [TestClass]
    public class NumericExtensionsTests
    {
        [TestMethod]        
        public void GetYearStrTest()
        {
            var years = 0;
            Assert.AreEqual("лет", years.GetYearStr());
            years = 1;
            Assert.AreEqual("год", years.GetYearStr());
            years = 2;
            Assert.AreEqual("года", years.GetYearStr());
            years = 5;
            Assert.AreEqual("лет", years.GetYearStr());
            years = 9;
            Assert.AreEqual("лет", years.GetYearStr());
            years = 10;
            Assert.AreEqual("лет", years.GetYearStr());
            years = 11;
            Assert.AreEqual("лет", years.GetYearStr());
            years = 12;
            Assert.AreEqual("лет", years.GetYearStr());
            years = 19;
            Assert.AreEqual("лет", years.GetYearStr());
            years = 121;
            Assert.AreEqual("год", years.GetYearStr());
            years = 1915;
            Assert.AreEqual("лет", years.GetYearStr());
            years = 2014;
            Assert.AreEqual("лет", years.GetYearStr());

        }
    }
}
