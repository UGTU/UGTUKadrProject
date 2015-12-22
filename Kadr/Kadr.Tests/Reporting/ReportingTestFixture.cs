using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Kadr.Data;
using System.Diagnostics;
using Kadr.Reporting;
using Kadr.UI.Reporting;

namespace Kadr.Tests.Reporting
{
    [TestClass]
    public class ReportingTestFixture
    {
        [TestMethod]
        public void CreateScheduleReportTest()
        {
            var dataSource = CreateVacationPlanTestFixtureDataSet();
            var vp = CreateDefaultReportParams();
            RunReportBuilder(vp, dataSource);
        }
        [TestMethod]
        public void CreateScheduleGroupedReportTest()
        {
            var dataSource = CreateVacationPlanTestFixtureDataSet();
            var vp = CreateDefaultReportParams();
            vp.GroupByDepartment = true;
            RunReportBuilder(vp, dataSource);
        }

        private static VacationPlanParams CreateDefaultReportParams()
        {
            var vp = new VacationPlanParams(Guid.Parse("{BAEE3FD5-664D-E111-96A2-0018FE865BEC}"),
                @"Reporting\template_график.xlsx", @"Reporting\test_schedule_output.xlsx")
            {Year = 2016};
            return vp;
        }

        private static void RunReportBuilder(VacationPlanParams vp, List<FetchVacationPlansByDepartmentIdResult> dataSource)
        {
            Kadr.Reporting.ScheduleReportBuilder.Create(vp, dataSource);

            ProcessStartInfo psi = new ProcessStartInfo(vp.OutputFileName);
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }

        private static List<FetchVacationPlansByDepartmentIdResult> CreateVacationPlanTestFixtureDataSet()
        {
            var departments = new[]
            {
                "Административно-хозяйственное управление", "Управление далами сенатора Палпатина",
                "Ремонтно-техническая мастерская дроидов", "Центр безопасности внутригаллактических перелётов"
            };
            var rnd = new Random();
            var dataSource = new List<FetchVacationPlansByDepartmentIdResult>();
            for (int i = 0; i < 1500; ++i)
            {
                dataSource.Add(new FetchVacationPlansByDepartmentIdResult()
                {
                    CountDay = 1,
                    DateBegin = Convert.ToDateTime("2015-08-17 00:00:00.000"),
                    DateEnd = Convert.ToDateTime("2015-09-29 00:00:00.000"),
                    LastName = "Курлени",
                    FirstName = "Алёна",
                    Otch = "Александровна",
                    DepartmentName = departments[rnd.Next(departments.Length - 1)],
                    PostName = "владыка ситхов Дарт Вейдер",
                    TypeWorkName = "Внегалактическая"
                });
            }
            return dataSource;
        }
    }
}
