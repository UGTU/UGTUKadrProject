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
                    DepartmentName = "Административно-хозяйственное управление",
                    PostName = "владыка ситхов Дарт Вейдер",
                    TypeWorkName = "Внегалактическая"
                });
            }
            var vp = new VacationPlanParams(Guid.Parse("{BAEE3FD5-664D-E111-96A2-0018FE865BEC}"),
              @"Reporting\template_график.xlsx", @"Reporting\test_schedule_output.xlsx")
            { Year = 2016 };

            Kadr.Reporting.ScheduleReportBuilder.Create(vp, dataSource);

            ProcessStartInfo psi = new ProcessStartInfo(vp.OutputFileName);
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }


       
    }
}
