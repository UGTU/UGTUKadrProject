﻿using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using APG.Base;
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
            var ts = TimeSpan.FromDays(2 * 360 + 180 + 15);
            var str = ts.FormatAsExperience();
            Console.WriteLine(str);
            Assert.AreEqual("2 года, 6 месяцев, 15 дней", str);
        }
     
        [TestMethod]
        public void CurrentExperienceTest()
        {
            var today = DateTime.Today;
            var set = new[]
            {
                new StubIEmployeeExperienceRecord() {StartGet = () => today.AddDays(-1)},
                new StubIEmployeeExperienceRecord() {StartGet = () => today.AddDays(1)},
            };
            var actual = set.CurrentExperience().ToList();
            Assert.AreEqual(1, actual.Count);
            Assert.AreEqual(today.AddDays(-1), actual[0].Start);
        }

        [TestMethod]
        public void EmployeeDecoratorExperienceTest()
        {
            var startDate = DateTime.Parse("01.01.2014");
            var endDate = DateTime.Parse("01.01.2014").AddYears(1).AddMonths(6).AddDays(15);
            var employee = new Employee()
            {
                EmployeeStandings = new EntitySet<EmployeeStanding>()
                {
                    new EmployeeStanding() {DateBegin = startDate,
                        DateEnd = endDate }
                }
            };

            var decorator = new EmployeeDecorator(employee);
            Assert.AreEqual("1 год, 6 месяцев, 16 дней", decorator.TotalExperience);
            Assert.AreEqual("0 лет, 0 месяцев, 0 дней", decorator.NorthExperience);
            Assert.AreEqual("0 лет, 0 месяцев, 0 дней", decorator.TotalOrganizationContiniousExperience);
            Assert.AreEqual("0 лет, 0 месяцев, 0 дней", decorator.TotalPedagogicalExperience);
            Assert.AreEqual("0 лет, 0 месяцев, 0 дней", decorator.TotalOrganizationExperience);

        }

        [TestMethod]
        public void EmployeeExperienceProviderIsNotNullTest()
        {
            var employee = new Employee() { EmployeeStandings = new EntitySet<EmployeeStanding>() };
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

            ts = TimeSpan.FromDays(361 * 2);
            Assert.AreEqual(2, ts.GetExperienceYears());
            Assert.AreEqual(0, ts.GetExperienceMonthes());
            Assert.AreEqual(2, ts.GetExperienceDays());

            ts = TimeSpan.FromDays(0);
            Assert.AreEqual(0, ts.GetExperienceYears());
            Assert.AreEqual(0, ts.GetExperienceMonthes());
            Assert.AreEqual(0, ts.GetExperienceDays());

            ts = TimeSpan.FromDays(360 + 180 + 15);
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
                        new System.Collections.Generic.List<IEmployeeExperienceRecord>()
                        {
                            new StubIEmployeeExperienceRecord()
                            {
                                StartGet = () => DateTime.Today,
                                StopGet = () => DateTime.Today,
                                IsEndedGet = ()=>true
                            }
                        }
            };
            Assert.AreEqual(TimeSpan.FromDays(1), provider.EmployeeExperiences.GetExperience());
            Assert.AreEqual(new DateSpan(1,0,0), provider.EmployeeExperiences.GetExperienceDates());

        }
        [TestMethod]
        public void GetExperienceWhenHiredTodayTest()
        {
            IExperienceProvider provider = new StubIExperienceProvider()
            {
                EmployeeExperiencesGet =
                    () =>
                        new System.Collections.Generic.List<IEmployeeExperienceRecord>()
                        {
                            new StubIEmployeeExperienceRecord()
                            {
                                StartGet = () => DateTime.Today,
                                IsEndedGet = ()=>false,
                            }
                        }
            };
            Assert.AreEqual(TimeSpan.FromDays(1), provider.EmployeeExperiences.GetExperience());
        }

        /// <summary>
        /// Проверка не выполнения(!!!) инварианта, 
        /// что сумма северного стажа всегда равна сумме стажа в РКС и МКС
        /// и зависит от последовательности вызова метода SequenceInterval(), 
        /// даты получения стажа перекрываться во времени
        /// </summary>
        [TestMethod]
        public void NorthExperienceWhenOverlappedDependsOnSequenceOrderTest()
        {
            var dtStart = DateTime.Parse("01.01.2015");
            IExperienceProvider provider = new StubIExperienceProvider()
            {
                EmployeeExperiencesGet =
                    () =>
                        new System.Collections.Generic.List<IEmployeeExperienceRecord>()
                        {
                            new StubIEmployeeExperienceRecord()
                            {
                                StartGet = () => dtStart,
                                StopGet = () => dtStart.AddDays(30),
                                IsEndedGet = ()=>true,
                                TerritoryGet = () => TerritoryConditions.North,
                                AffilationGet = () => Affilations.External
                            },
                            new StubIEmployeeExperienceRecord()
                            {
                                StartGet = () => dtStart.AddDays(10),
                                StopGet = () => dtStart.AddDays(20),
                                IsEndedGet = ()=>true,
                                TerritoryGet = () => TerritoryConditions.StrictNorth,
                                AffilationGet = () => Affilations.External
                            },
                             new StubIEmployeeExperienceRecord()
                            {
                                StartGet = () => dtStart.AddDays(21),
                                StopGet = () => dtStart.AddDays(22),
                                IsEndedGet = ()=>true,
                                TerritoryGet = () => TerritoryConditions.StrictNorth,
                                AffilationGet = () => Affilations.External
                            }
                        }
            };
            var expSet = provider.EmployeeExperiences.ToList();
            var totalNorth = expSet.FilterNorthExperience().ToList();
            var north = totalNorth.Where(x => x.Territory == TerritoryConditions.North).ToList();
            var strictNorth = totalNorth.Where(x => x.Territory == TerritoryConditions.StrictNorth).ToList();
            Assert.AreEqual(totalNorth.GetExperience(), north.GetExperience()+strictNorth.GetExperience());
            Assert.AreEqual(totalNorth.GetExperienceDates(), north.GetExperienceDates() + strictNorth.GetExperienceDates());

            var totalIntervaledPre = totalNorth.SequenceInterval();
            var totalIntervaledPost = expSet.SequenceInterval().FilterNorthExperience();
            Assert.IsTrue(totalIntervaledPost.GetExperience() == totalIntervaledPre.GetExperience());

            Assert.AreNotEqual(totalNorth.SequenceInterval().GetExperience(), 
                expSet.FilterNorthExperience().SequenceInterval()
                .Where(x=>x.Territory == TerritoryConditions.North).GetExperience()
                + expSet.FilterNorthExperience()
                .Where(x => x.Territory == TerritoryConditions.StrictNorth)
                .SequenceInterval().GetExperience());

            Assert.AreEqual(totalNorth.SequenceInterval().GetExperience(), 
                expSet.FilterNorthExperience().SequenceInterval()
                .Where(x => x.Territory == TerritoryConditions.North).GetExperience()
                + expSet.FilterNorthExperience().SequenceInterval()
                .Where(x => x.Territory == TerritoryConditions.StrictNorth).GetExperience());

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

        /// <summary>
        /// Если дата окончания стажа задана в будущем, т
        /// о нужно, что бы стаж расчитывался на текущий момент
        /// </summary>
        [TestMethod]
        public void GetExperienceWhenFireDateInTheFutureTest()
        {
            var today = DateTime.Today;
            var future = today.AddYears(1);
            var start = today.AddDays(-1);
            IExperienceProvider provider = new StubIExperienceProvider()
            {
                EmployeeExperiencesGet = () => new System.Collections.Generic.List<IEmployeeExperienceRecord>()
                {
                    new StubIEmployeeExperienceRecord()
                    {
                        StartGet = ()=>start,
                        IsEndedGet = ()=>true,
                        StopGet = ()=>future
                    }
                }
            };
            var actual = provider.EmployeeExperiences.GetExperienceDates();
            Assert.AreEqual(new DateSpan(1,0,0), actual);
        }
        /// <summary>
        /// Если дата окончания предыдущего стажа совпадает с датой начала следующего стажа, 
        /// то эта дата должна считаться стажем однократно (1 день)
        /// </summary>
        [TestMethod]
        public void GetExperienceWhenContainsEqualStopAndNextStartDatesTest()
        {
            var dtStart = DateTime.Parse("01.01.2015");
            IExperienceProvider provider = new StubIExperienceProvider()
            {
                
                EmployeeExperiencesGet = () => new System.Collections.Generic.List<IEmployeeExperienceRecord>()
                {
                    new StubIEmployeeExperienceRecord()
                    {
                        StartGet = ()=>dtStart,
                        StopGet = ()=>dtStart.AddDays(1),
                        IsEndedGet = ()=>true
                    },
                    new StubIEmployeeExperienceRecord()
                    {
                        StartGet = ()=>dtStart.AddDays(1),
                        StopGet = ()=>dtStart.AddDays(2),
                        IsEndedGet = ()=>true
                    },
                    new StubIEmployeeExperienceRecord()
                    {
                        StartGet = ()=>dtStart.AddDays(2),
                        StopGet = ()=>dtStart.AddDays(3),
                        IsEndedGet = ()=>true
                    }
                }
            };
            Assert.AreEqual(TimeSpan.FromDays(4), provider.EmployeeExperiences.GetExperience());
            Assert.AreEqual(new DateSpan(4, 0, 0), provider.EmployeeExperiences.GetExperienceDates());

        }
        [TestMethod]
        public void NorthExperienceTest()
        {
            var start = DateTime.Today;
            var provider = new StubIExperienceProvider()
            {
                EmployeeExperiencesGet = () => new System.Collections.Generic.List<IEmployeeExperienceRecord>()
                {
                    //ТК - Северный
                    new StubIEmployeeExperienceRecord()
                    {
                        StartGet = () => start,
                        StopGet = () => start.AddDays(1),
                        IsEndedGet = ()=>true,
                        AffilationGet = () => Affilations.External,
                        TerritoryGet = () => TerritoryConditions.North
                    },
                    // ТК - Не северный
                    new StubIEmployeeExperienceRecord()
                    {
                        StartGet = () => start.AddDays(2),
                        StopGet = () => start.AddDays(4),
                        IsEndedGet = ()=>true,
                        AffilationGet = () => Affilations.External,
                        TerritoryGet = () => TerritoryConditions.Default
                    },

                    // Организация (основаня) - Северный
                    new StubIEmployeeExperienceRecord()
                    {
                        StartGet = () => start.AddDays(5),
                        StopGet = () => start.AddDays(10),
                        IsEndedGet = ()=>true,
                        AffilationGet = () => Affilations.Organization,
                        TerritoryGet = () => TerritoryConditions.North,
                        WorkWorkTypeGet = () => WorkOrganizationWorkType.Internal
                    },

                    // Организация (совмещение) - Северный
                    new StubIEmployeeExperienceRecord()
                    {
                        StartGet = () => start.AddDays(6),
                        StopGet = () => start.AddDays(10),
                        IsEndedGet = ()=>true,
                        AffilationGet = () => Affilations.Organization,
                        TerritoryGet = () => TerritoryConditions.StrictNorth,
                        WorkWorkTypeGet = () => WorkOrganizationWorkType.Combined
                    },

                    // Организация (совмещение) - Северный
                    new StubIEmployeeExperienceRecord()
                    {
                        StartGet = () => start.AddDays(6),
                        StopGet = () => start.AddDays(10),
                        IsEndedGet = ()=>true,
                        AffilationGet = () => Affilations.Organization,
                        TerritoryGet = () => TerritoryConditions.North,
                        WorkWorkTypeGet = () => WorkOrganizationWorkType.Combined
                    }
                }
            };
            var experienceSet = provider.EmployeeExperiencesGet.Invoke();

            // Северный стаж считается по трудовой книжке и по основной должности сотрудника
            // в организации
            var northExperience = experienceSet.FilterNorthExperience().ToList();
            Assert.AreEqual(2, northExperience.Count());
            Assert.AreEqual(8, northExperience.GetExperience().Days);

            Assert.AreEqual(new DateSpan(8, 0, 0), northExperience.GetExperienceDates());
        }
        [TestMethod]
        public void GetIntersectedExperienceTest()
        {
            var dtStart = DateTime.Parse("01.01.2014");

            IExperienceProvider provider = new StubIExperienceProvider
            {
                EmployeeExperiencesGet = () =>
                    new System.Collections.Generic.List<IEmployeeExperienceRecord>()
                    {
                        // Работа в организации на основной должности
                        new StubIEmployeeExperienceRecord()
                        {
                            StartGet = () => dtStart,
                            StopGet = () => DateTime.Parse("31.12.2014"),
                            IsEndedGet = ()=>true,
                            AffilationGet = () => Affilations.Organization,
                            TerritoryGet = () => TerritoryConditions.Default,
                            ExperienceGet = () => KindOfExperience.Pedagogical,
                            WorkWorkTypeGet = ()=>WorkOrganizationWorkType.Internal
                        },
                        // Работа в организации на совместительстве
                        new StubIEmployeeExperienceRecord()
                        {
                            StartGet = () => dtStart,
                            StopGet = () => DateTime.Parse("31.12.2014"),
                            IsEndedGet = ()=>true,
                            AffilationGet = () => Affilations.Organization,
                            TerritoryGet = () => TerritoryConditions.Default,
                            ExperienceGet = () => KindOfExperience.Pedagogical,
                            WorkWorkTypeGet = ()=>WorkOrganizationWorkType.Combined
                        }

                    }
            };
            var experience = provider.EmployeeExperiences.Sequence<IEmployeeExperienceRecord, DateTime>
                ((x, s, e) => new ExperienceInterval(x, s, e)).ToList();
            var actual = experience.GetExperience();
            Assert.AreEqual(365, actual.Days);
            Assert.AreEqual(new DateSpan(0, 0, 1), experience.GetExperienceDates());

        }

        [TestMethod]
        public void ContiniousExperienceTest()
        {
            var dtStart = DateTime.Parse("01.01.2014");
            var r1 = new StubIEmployeeExperienceRecord()
            {
                StartGet = () => dtStart,
                IsEndedGet = () => false
            };

            var r3 = new StubIEmployeeExperienceRecord()
            {
                StopGet = () => dtStart.AddDays(-1),
                StartGet = () => dtStart.AddDays(-100),
                IsEndedGet = () => true
            };

            var r4 = new StubIEmployeeExperienceRecord()
            {
                StopGet = () => dtStart.AddDays(-100),
                StartGet = () => dtStart.AddDays(-102),
                IsEndedGet = () => true
            };

            var r2 = new StubIEmployeeExperienceRecord()
            {
                StopGet = () => dtStart.AddDays(-104),
                StartGet = () => dtStart.AddDays(-200),
                IsEndedGet = () => true
            };



            IExperienceProvider provider = new StubIExperienceProvider
            {

                EmployeeExperiencesGet = () =>
                    new System.Collections.Generic.List<IEmployeeExperienceRecord>()
                    {r3, r1, r2, r4}
            };

            var actual = provider.EmployeeExperiences.Continious().ToList();
            Assert.AreEqual(3, actual.Count);
            Assert.AreSame(r1, actual.First());
            Assert.AreSame(r3, actual.Skip(1).First());
            Assert.AreSame(r4, actual.Skip(2).First());

            //Только одна запись
            actual = provider.EmployeeExperiences.Take(1).Continious().ToList();
            Assert.AreEqual(1, actual.Count);
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
                    new System.Collections.Generic.List<IEmployeeExperienceRecord>()
                    {
                        // Работа в другой организации, не приравненой к РКС или МКС
                        new StubIEmployeeExperienceRecord()
                        {
                            StartGet = () => dtStart,
                            StopGet = () => DateTime.Parse("31.12.2014"),
                            IsEndedGet = () => true,
                            AffilationGet = () => Affilations.External,
                            TerritoryGet = () => TerritoryConditions.Default,
                            ExperienceGet = () => KindOfExperience.Pedagogical
                        },

                        // Переход в организацию на научно-педагогическую должность (НПД)
                        // работал в течение двух месяцев
                        new StubIEmployeeExperienceRecord()
                        {
                            StartGet = () => dtOrgStart,
                            StopGet = () => dtOrgStart.AddDays(60),
                            IsEndedGet = ()=>true,
                            AffilationGet = () => Affilations.Organization,
                            TerritoryGet = () => TerritoryConditions.North,
                            ExperienceGet = () => KindOfExperience.Other
                        },
                        
                        // На следующий день после увольнения с НПД поступил снова на НПД и
                        // работает до сих пор 
                        new StubIEmployeeExperienceRecord()
                        {
                            StartGet = () => dtOrgStart.AddDays(61),
                            IsEndedGet = ()=>false,
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
                provider.EmployeeExperiences.Where(x => x.Experience == KindOfExperience.Pedagogical).ToList();
            experience = pedExperienceSet.GetExperience();
            Assert.AreEqual(1, experience.GetExperienceYears());
            Assert.AreEqual(0, experience.GetExperienceMonthes());
            Assert.AreEqual(5, experience.GetExperienceDays());
            Assert.AreEqual(new DateSpan(0, 0, 1), pedExperienceSet.GetExperienceDates());


            // Непрерывный стаж в организации
            var orgExperienceSet = provider.EmployeeExperiences.Where
                (x => x.Affilation == Affilations.Organization);
            experience = orgExperienceSet.Continious().GetExperience();
            Assert.AreEqual((DateTime.Today.AddDays(1) - dtOrgStart), experience);
        }
    }
}
