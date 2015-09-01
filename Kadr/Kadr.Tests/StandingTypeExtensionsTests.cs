using System;
using Kadr.Data;
using Kadr.Data.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kadr.Tests
{
    [TestClass]
    public class StandingTypeExtensionsTests
    {
        [TestMethod]
        public void GetKindOfExperienceByStandingTypeTest()
        {
            var standType = new StandingType() { id = 1 };
            Assert.AreEqual(KindOfExperience.Other, standType.GetKindOfExperience());
            standType.id = 2;
            Assert.AreEqual(KindOfExperience.Pedagogical, standType.GetKindOfExperience());
            standType.id = 5;
            Assert.AreEqual(KindOfExperience.Other, standType.GetKindOfExperience());
        }
    }
}
