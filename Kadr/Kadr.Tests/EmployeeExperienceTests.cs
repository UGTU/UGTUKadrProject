using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using Kadr.Data;
using Kadr.Data.Common;
using Kadr.Data.Common.Fakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Kadr.Tests
{
    [TestClass]
    public class EmployeeExperienceTests
    {
        [TestMethod]
        public void FormatAsExperienceTest()
        {
            var ts = TimeSpan.FromDays(2*360 + 180 + 15);
            var str = ts.FormatAsExperience();
            Console.WriteLine(str);
            Assert.AreEqual("2 года, 6 месяцев, 15 дней", str);
        }
        
        [TestMethod]
        public void EmployeeDecoratorExperienceTest()
        {
            var employee = new Employee()
            {
                EmployeeStandings = new EntitySet<EmployeeStanding>()
                {
                    new EmployeeStanding() {DateBegin = DateTime.Parse("01.01.2014"),
                        DateEnd = DateTime.Parse("01.01.2014").AddDays(359+180+15) }
                }
            };

            var decorator = new EmployeeDecorator(employee);
            Assert.AreEqual("1 год, 6 месяцев, 15 дней", decorator.TotalExperience);
        }

        [TestMethod]
        public void EmployeeExperienceProviderIsNotNullTest()
        {
            var employee = new Employee() {EmployeeStandings = new EntitySet<EmployeeStanding>()};
            Assert.IsNotNull(employee.EmployeeExperiences);
        }

        [TestMethod]
        public void GetExperienceTimeSpanExtensionsTest()
        {
            var ts = TimeSpan.FromDays(360);
            Assert.AreEqual(1, ts.GetExperienceYears());
            Assert.AreEqual(0, ts.GetExperienceMonthes());
            Assert.AreEqual(0, ts.GetExperienceDays());

            ts = TimeSpan.FromDays(359);
            Assert.AreEqual(0, ts.GetExperienceYears());
            Assert.AreEqual(11, ts.GetExperienceMonthes());
            Assert.AreEqual(29, ts.GetExperienceDays());

            ts = TimeSpan.FromDays(361);
            Assert.AreEqual(1, ts.GetExperienceYears());
            Assert.AreEqual(0, ts.GetExperienceMonthes());
            Assert.AreEqual(1, ts.GetExperienceDays());

            ts = TimeSpan.FromDays(361*2);
            Assert.AreEqual(2, ts.GetExperienceYears());
            Assert.AreEqual(0, ts.GetExperienceMonthes());
            Assert.AreEqual(2, ts.GetExperienceDays());

            ts = TimeSpan.FromDays(0);
            Assert.AreEqual(0, ts.GetExperienceYears());
            Assert.AreEqual(0, ts.GetExperienceMonthes());
            Assert.AreEqual(0, ts.GetExperienceDays());

            ts = TimeSpan.FromDays(360+180+15);
            Assert.AreEqual(1, ts.GetExperienceYears());
            Assert.AreEqual(6, ts.GetExperienceMonthes());
            Assert.AreEqual(15, ts.GetExperienceDays());
        }

        [TestMethod]
        public void GetExperienceWhenHiredAndFiredTodayTest()
        {
            IExperienceProvider provider = new StubIExperienceProvider()
            {
                EmployeeExperiencesGet =
                    () =>
                        new List<IEmployeeExperienceRecord>()
                        {
                            new StubIEmployeeExperienceRecord()
                            {
                                StartOfWorkGet = () => DateTime.Today,
                                EndOfWorkGet = () => DateTime.Today
                            }
                        }
            };
            Assert.AreEqual(TimeSpan.FromDays(1), provider.EmployeeExperiences.GetExperience());
        }
        [TestMethod]
        public void GetExperienceWhenHiredTodayTest()
        {
            IExperienceProvider provider = new StubIExperienceProvider()
            {
                EmployeeExperiencesGet =
                    () =>
                        new List<IEmployeeExperienceRecord>()
                        {
                            new StubIEmployeeExperienceRecord()
                            {
                                StartOfWorkGet = () => DateTime.Today
                            }
                        }
            };
            Assert.AreEqual(TimeSpan.FromDays(1), provider.EmployeeExperiences.GetExperience());
        }

        [TestMethod]
        public void GetExperienceEmptySetTest()
        {
            IExperienceProvider provider = new StubIExperienceProvider()
            {
                EmployeeExperiencesGet = () => Enumerable.Empty<IEmployeeExperienceRecord>()
            };
            Assert.AreEqual(TimeSpan.FromDays(0), provider.EmployeeExperiences.GetExperience());
        }

        [TestMethod]
        public void GetExperienceTest()
        {
            var dtStart = DateTime.Parse("01.01.2014");
            var dtOrgStart = DateTime.Parse("01.01.2015");

            IExperienceProvider provider = new StubIExperienceProvider
            {
                // Сотрудник имел педагогический опыт в другой организации, в районах не приравненных к районам крайнего севера,
                // после чего поступил на работу в нашу организацию, после двух месяцев был уволен и на следующий день снова поступил на 
                // на педагогическую должность, где и работает до сих пор.            
                EmployeeExperiencesGet = () =>
                    new List<IEmployeeExperienceRecord>()
                    {
                        // Работа в другой организации, не приравненой к РКС или МКС
                        new StubIEmployeeExperienceRecord()
                        {
                            StartOfWorkGet = () => dtStart,
                            EndOfWorkGet = () => DateTime.Parse("31.12.2014"),
                            AffilationGet = () => Affilations.External,
                            TerritoryGet = () => TerritoryConditions.Default,
                            ExperienceGet = () => KindOfExperience.Pedagogical
                        },

                        // Переход в организацию на научно-педагогическую должность (НПД)
                        // работал в течение двух месяцев
                        new StubIEmployeeExperienceRecord()
                        {
                            StartOfWorkGet = () => dtOrgStart,  
                            EndOfWorkGet = () => dtOrgStart.AddDays(60),
                            AffilationGet = () => Affilations.Organization,
                            TerritoryGet = () => TerritoryConditions.North,
                            ExperienceGet = () => KindOfExperience.Other
                        },
                        
                        // На следующий день после увольнения с НПД поступил снова на НПД и
                        // работает до сих пор 
                        new StubIEmployeeExperienceRecord()
                        {
                            StartOfWorkGet = () => dtOrgStart.AddDays(61),                            
                            AffilationGet = () => Affilations.Organization,
                            TerritoryGet = () => TerritoryConditions.North,
                            ExperienceGet = () => KindOfExperience.Other
                        }
                    }
            };
            var experience = provider.EmployeeExperiences.GetExperience();
            Assert.IsNotNull(experience);
            
            // Текущий день входит в стаж работы
            Assert.AreEqual((DateTime.Today.AddDays(1) - dtStart), experience);

            // Педагогический стаж
            var pedExperienceSet = 
                provider.EmployeeExperiences.Where(x => x.Experience == KindOfExperience.Pedagogical);
            experience = pedExperienceSet.GetExperience();
            Assert.AreEqual(1, experience.GetExperienceYears());
            Assert.AreEqual(0, experience.GetExperienceMonthes());
            Assert.AreEqual(5, experience.GetExperienceDays());
            
            // Непрерывный стаж в организации
            var orgExperienceSet = provider.EmployeeExperiences.Where
                (x => x.Affilation == Affilations.Organization);
            experience = orgExperienceSet.Continious().GetExperience();
            Assert.AreEqual((DateTime.Today.AddDays(1) - dtOrgStart), experience);
        }
    }
}
