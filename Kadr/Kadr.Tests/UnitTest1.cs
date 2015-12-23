using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kadr.Data;
using System.Linq;
using Kadr.Controllers;
using UIX.Views;

namespace Kadr.Tests
{
    [TestClass]
    public class AwardTest
    {
        class A
        {
            public string Value => "OK";
        }

        private string GetValue(object obj)
        {
            return (obj as A)?.Value;
        }
        [TestMethod]
        public void TestNullPropogatorIssue()
        {
            var obj = new A();
            Assert.AreEqual("OK", GetValue(obj));            
        }
    }
}
