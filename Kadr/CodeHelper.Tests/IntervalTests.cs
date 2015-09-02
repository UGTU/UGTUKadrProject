using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using APG.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeHelper.Tests
{
    class TimeInterval : IRange<DateTime>
    {
        public DateTime Start { get; set; }
        public DateTime Stop { get; set; }
    }

    [TestClass]
    public class IntervalTests
    {
        [TestMethod]
        public void IsOrderedEmptyEnumShouldReturnTrueTest()
        {
            var empty = Enumerable.Empty<TimeInterval>();
            Assert.IsTrue(empty.IsOrdered(x=>x.Start));
        }

        [TestMethod]
        public void IsOrderedOneElementEnumShouldReturnTrueTest()
        {
            var empty = new List<TimeInterval>()
            {
                new TimeInterval() {Start = DateTime.Today}
            };

            Assert.IsTrue(empty.IsOrdered(x => x.Start));
        }

        [TestMethod]
        public void IsOrderedShouldReturnTrueTest()
        {
            var start = DateTime.Today;
            var empty = new List<TimeInterval>()
            {
                new TimeInterval() {Start = start},
                new TimeInterval() {Start = start.AddDays(1)},
                new TimeInterval() {Start = start.AddDays(10)}
            };

            Assert.IsTrue(empty.IsOrdered(x => x.Start));
        }
        [TestMethod]
        public void IsOrderedShouldReturnFalseTest()
        {
            var start = DateTime.Today;
            var empty = new List<TimeInterval>()
            {
                new TimeInterval() {Start = start.AddDays(100)},
                new TimeInterval() {Start = start.AddDays(1)},
                new TimeInterval() {Start = start.AddDays(10)}
            };

            Assert.IsFalse(empty.IsOrdered(x => x.Start));
        }

        [TestMethod]
        public void SequnceTest()
        {
            var start = DateTime.Today;
            
            var testIntervals = new List<TimeInterval>()
            {
                new TimeInterval() {Start = start, Stop = start.AddDays(10)},
                new TimeInterval() {Start = start.AddDays(5), Stop = start.AddDays(15)},
                new TimeInterval() {Start = start.AddDays(-10), Stop = start.AddDays(100)}
            };

            var actual = testIntervals.Sequence<TimeInterval, DateTime>().ToList();
            Assert.AreEqual(testIntervals.Count(), actual.Count());
            Assert.IsTrue(actual.IsOrdered(x=>x.Start));            
        }
    }
}
