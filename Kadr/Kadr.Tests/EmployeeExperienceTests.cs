using System;
using System.Collections.Generic;
using Kadr.Data.Common;
using Kadr.Data.Common.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kadr.Tests
{
    [TestClass]
    public class EmployeeExperienceTests
    {
        [TestMethod]
        public void GetExperienceTest()
        {
            var dtStart = DateTime.Parse("01.01.2014");

            var provider = new StubIExperienceProvider
            {
                // Сотрудник имел педагогический опыт в другом вузе, в районах не приравненных к районам крайнего севера,
                // после чего поступил на работу в нашу организацию и работает до сих пор            
                EmployeeExperiencesGet = () =>
                    new List<IEmployeeExperienceRecord>()
                    {
                        new StubIEmployeeExperienceRecord()
                        {
                            StartOfWorkGet = () => dtStart,
                            EndOfWorkGet = () => DateTime.Parse("31.12.2014"),
                            AffilationGet = () => Affilations.External,
                            TerritoryGet = () => TerritoryConditions.Default,
                            ExperienceGet = () => KindOfExperience.Pedagogical
                        },
                        new StubIEmployeeExperienceRecord()
                        {
                            StartOfWorkGet = () => DateTime.Parse("01.01.2015"),                            
                            AffilationGet = () => Affilations.Organization,
                            TerritoryGet = () => TerritoryConditions.North,
                            ExperienceGet = () => KindOfExperience.Pedagogical
                        }
                    }
            };
            var experience = provider.GetExperience();
            Assert.IsNotNull(experience);
            Assert.AreEqual(DateTime.Today - dtStart - TimeSpan.FromDays(1), experience.Total);
        }
    }
}
