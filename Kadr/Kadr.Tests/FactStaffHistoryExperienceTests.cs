using System;
using APG.Base;
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
        
        [TestMethod]
        public void BusinessTripExperienceTests()
        {
            var start = DateTime.Parse("01.01.2015");
            var north = new RegionType() {id = (int) TerritoryConditions.North};
            var strictNorth = new RegionType() { id = (int)TerritoryConditions.StrictNorth };
            var trip = new BusinessTrip();

            trip.BusinessTripRegionTypes.Add(new BusinessTripRegionType()
            { DateBegin = start, DateEnd=start.AddDays(6), RegionType = strictNorth});

            trip.BusinessTripRegionTypes.Add(new BusinessTripRegionType()
            { DateBegin = start, DateEnd = start.AddDays(1), RegionType = north});

            trip.BusinessTripRegionTypes.Add(new BusinessTripRegionType()
            { DateBegin = start.AddDays(5), DateEnd = start.AddDays(6), RegionType = north });

            var experience = trip.BusinessTripRegionTypes.SequenceInterval().GetExperienceDates();
            Assert.AreEqual(new DateSpan(6,0,0), experience);
        }
    }
}
