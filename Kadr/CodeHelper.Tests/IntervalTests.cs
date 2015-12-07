using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
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
            Assert.IsTrue(empty.IsOrdered(x => x.Start));
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
        private static void WriteOutSequence<TU, TV>(IEnumerable<StubRange<TU, TV>> range) where TV : IComparable
        {
            var str = range.Aggregate(new StringBuilder(), (x, s) => x.AppendFormat("{0}; ", s), s => s.ToString());
            Console.WriteLine(str);
        }

        private static bool CompareSequences<TU, TV>(IEnumerable<StubRange<TU, TV>> range, IReadOnlyList<TV> rangeValues,
            params TU[] rangeTags) where TU : IComparable where TV : IComparable
        {

            //var startRange = rangeValues.First();
            //var endRange = rangeValues.Skip(1).First();
            //var tag = rangeTags.First();

            var valueIndex = 0;
            var tagIndex = 0;
            foreach (var rangeItem in range)
            {
                var startRange = rangeValues[valueIndex++];
                var endRange = rangeValues[valueIndex++];
                var tag = rangeTags[tagIndex++];

                if (rangeItem.Start.CompareTo(startRange) != 0 || rangeItem.Stop.CompareTo(endRange) != 0)
                    return false;

                if (rangeItem.Tag.CompareTo(tag) != 0) return false;

            }
            return true;
        }

        [TestMethod]
        public void SimpleTwoNotIntersectedRangeSequenceTest()
        {
            // 0-1, 2-3
            //  0-1
            CheckSequenceResult(new[] { 0, 1, 2, 3 },
                new[] { 0, 1 }, new[] { 0, 1, 2, 3 },
                0, 1);
        }

        [TestMethod]
        public void SimpleTwoIncludedRangeSequenceTest()
        {
            // 0-1-2-3
            //  0-1-0
            CheckSequenceResult(new[] { 0, 3, 1, 2 },
                new[] { 0, 1 }, new[] { 0, 1, 1, 2, 2, 3 },
                0, 1, 0);
        }

        [TestMethod]
        public void SimpleEqualRangesSequenceTest()
        {
            CheckSequenceResult(new[] { 0, 1, 0, 1 },
                new[] { 0, 0 }, new[] { 0, 1, 0, 1},
                0, 0);
        }

        private static void CheckSequenceResult<TU, TV>(IReadOnlyList<TV> initialValues,
            IReadOnlyList<TU> initialTags, IReadOnlyList<TV> expectedValues,
            params TU[] expectedTags) where TU : IComparable where TV : IComparable
        {
            var initRange = new List<StubRange<TU, TV>>();
            var t = 0;
            for (var i = 0; i < initialValues.Count; i += 2)
            {
                initRange.Add(new StubRange<TU, TV>(initialValues[i], initialValues[i + 1], initialTags[t++]));
            }

            var actual = initRange.Sequence<StubRange<TU, TV>, TV>
              ((x, s, e) => new StubRange<TU, TV>(s, e, x.Tag)).ToList();

            WriteOutSequence(actual);

            Assert.IsTrue(CompareSequences(actual, expectedValues, expectedTags));
        }

        [TestMethod]
        public void SimpleTwoIntersectedStartRangeSequenceTest()
        {
            // 0-1-2-3
            //  0-1-1
            CheckSequenceResult(new[] { 0, 2, 1, 3 },
                new[] { 0, 1 }, new[] { 0, 1, 1, 2, 2, 3 }, 0, 1, 1);

        }
        [TestMethod]
        public void SimpleDoubleNestedRangeSequenceTest()
        {
            // 0-1-2-3-4-5
            //  0-1-2-1-0
            CheckSequenceResult(new[] { 0, 5, 1, 4, 2, 3 },
                new[] { 0, 1, 2 }, new[] { 0, 1, 1, 2, 2, 3, 3, 4, 4, 5 }, 0, 1, 2, 1, 0);

        }

        [TestMethod]
        public void TreeNestedRangeSequenceTest()
        {
            // 0-1-2-3-4-5
            //  0-1-2-1-0
            CheckSequenceResult(new[] { 0, 8, 1, 3, 2, 6, 5, 7 },
                new[] { 0, 1, 2, 3 }, new[] { 0, 1, 1, 2, 2, 3, 3, 5, 5, 6, 6, 7, 7, 8 }, 0, 1, 2, 2, 3, 3, 0);

        }

        [TestMethod]
        public void ComplexSequnceTest()
        {
      
            CheckSequenceResult(new[] { 0, 10, 11, 12, -1, 1, 2, 8, 7, 9 },
               new[] { 0, 1, 2, 3, 4 },
               new[] { -1, 0, 0, 1, 1, 2, 2, 7, 7, 8, 8, 9, 9, 10, 11, 12 },
                2, 0, 0, 3, 4, 4, 0, 1);

        }

        [TestMethod]
        public void FutureDatesSequnceTest()
        {

            CheckSequenceResult(new[]
            {
                DateTime.Parse("27.06.2015"), DateTime.Parse("31.08.2015"),
                DateTime.Parse("01.09.2015"), DateTime.Parse("01.12.2015"),
                DateTime.Parse("01.10.2015"), DateTime.Parse("01.12.2015"),
                DateTime.Parse("23.12.2015"), DateTime.Parse("01.12.2015")
            },
                new[] {0, 0, 0, 0},
                new[]
                {
                    DateTime.Parse("27.06.2015"), DateTime.Parse("31.08.2015"),
                    DateTime.Parse("01.09.2015"), DateTime.Parse("01.12.2015"),
                    DateTime.Parse("01.10.2015"), DateTime.Parse("01.12.2015"),
                    DateTime.Parse("23.12.2015"), DateTime.Parse("01.12.2015")
                }, 0, 0, 0, 0);
        }
    }
}
