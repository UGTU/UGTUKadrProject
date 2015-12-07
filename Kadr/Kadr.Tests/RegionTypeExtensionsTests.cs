using System;
using Kadr.Data;
using Kadr.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kadr.Tests
{
    [TestClass]
    public class RegionTypeExtensionsTests
    {
        [TestMethod]
        public void GetTerriotoryConditionByRegionTypeTest()
        {
            var regType = new RegionType() {id=1};
            Assert.AreEqual(TerritoryConditions.Default, regType.GetTerritoryCondition());
            regType.id = 3;
            Assert.AreEqual(TerritoryConditions.StrictNorth, regType.GetTerritoryCondition());
            regType.id = 5;
            Assert.AreEqual(TerritoryConditions.Default, regType.GetTerritoryCondition());
        }
    }
}
