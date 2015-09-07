using System;
using System.Linq;
using APG.Base;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CodeHelper.Tests
{
    class StubRange<T, TU> : IRange<TU> where TU : IComparable
    {
        public StubRange(TU start, TU stop, T tag = default(T))
        {
            Start = start;
            Stop = stop;
            Tag = tag;
        }

        public T Tag { get; set; }
        public TU Start { get; set; }
        public TU Stop { get; set; }

        public override string ToString()
        {
            return string.Format("{0}-{1}[{2}]", Start, Stop, Tag);
        }
    }
    [TestClass]
    public class RangeTests
    {
        [TestMethod]
        public void PointRangeRelationTest()
        {
            var p23 = new StubRange<int, int>(2, 4);
            Assert.AreEqual(PointRangeRelation.Before, p23.GetRelationTo(1));
            Assert.AreEqual(PointRangeRelation.After, p23.GetRelationTo(5));
            Assert.AreEqual(PointRangeRelation.In, p23.GetRelationTo(2));
            Assert.AreEqual(PointRangeRelation.In, p23.GetRelationTo(3));
        }
        
        [TestMethod]
        public void RangeStrictRelationTest()
        {
            var ranges = new[]
            {
                new StubRange<int, int>(0, 1),
                new StubRange<int, int>(2, 3),
                new StubRange<int, int>(4, 5),
            };

            CheckRangesIntersects(ranges, RangeRelation.NotIn, true);
        }
        [TestMethod]
        public void RangeEqualsRelationTest()
        {
            var ranges = new[]
            {
                new StubRange<int, int>(0, 1),
                new StubRange<int, int>(0, 1)
                
            };

            CheckRangesIntersects(ranges, RangeRelation.Equals, true);
        }
        private static void CheckRangesIntersects(StubRange<int, int>[] ranges, RangeRelation expectedValue, bool invert)
        {
            foreach (var itemI in ranges)
            {
                foreach (var itemJ in ranges.Where(itemJ => itemJ != itemI))
                {
                    Action<RangeRelation, RangeRelation> conditionFunc;
                    if (invert)
                        conditionFunc = Assert.AreEqual;
                    else
                        conditionFunc = Assert.AreNotEqual;

                    conditionFunc(expectedValue, itemI.GetRelationTo(itemJ));
                }
            }
        }

        [TestMethod]
        public void RangeRelationTest()
        {
            var p15 = new StubRange<int, int>(1, 5);
            var p23 = new StubRange<int, int>(2, 3);            
            var p03 = new StubRange<int, int>(0, 3);
            var p36 = new StubRange<int, int>(3, 6);
            var p67 = new StubRange<int, int>(6, 7);
            var pm10 = new StubRange<int, int>(-1, 0);
            Assert.AreEqual(RangeRelation.Includes, p15.GetRelationTo(p23));
            Assert.AreEqual(RangeRelation.Within, p23.GetRelationTo(p15));
            Assert.AreEqual(RangeRelation.EndsIn, p15.GetRelationTo(p03));
            Assert.AreEqual(RangeRelation.StartsIn, p15.GetRelationTo(p36));
            Assert.AreEqual(RangeRelation.NotIn, p67.GetRelationTo(p15));
            Assert.AreEqual(RangeRelation.NotIn, p15.GetRelationTo(p67));
            Assert.AreEqual(RangeRelation.NotIn, pm10.GetRelationTo(p15));
            Assert.AreEqual(RangeRelation.NotIn, p15.GetRelationTo(pm10));
        }
    }
}
