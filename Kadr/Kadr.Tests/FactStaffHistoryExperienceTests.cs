using System;
using Kadr.Data;
using Kadr.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kadr.Tests
{
    [TestClass]
    public class FactStaffHistoryExperienceTests
    {
        [TestMethod]
        public void FactStaffHistTerrirityConditionTest()
        {
            var fsh = new FactStaffHistory {
                FactStaff = new FactStaff(){Department = new Dep() }
            };

            Assert.AreEqual(fsh.Territory, RegionType.Default);

            fsh.FactStaff.Department.DepartmentHistories.Add(
                new DepartmentHistory() { RegionType = new RegionType() { id = 2 }});

            Assert.AreEqual(TerritoryConditions.North, fsh.Territory);

            fsh.RegionType = new RegionType() {id = 4};

            Assert.AreEqual(TerritoryConditions.StrictNorth, fsh.Territory);

        }
    }
}
