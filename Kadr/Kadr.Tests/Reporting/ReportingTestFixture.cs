using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using Kadr.Data;
using System.Diagnostics;
using Kadr.UI.Reporting;

namespace Kadr.Tests.Reporting
{
    [TestClass]
    public class ReportingTestFixture
    {
        [TestMethod]
        public void CreateScheduleReportTest()
        {
            var dataSource = new List<ViewVacationPlan>();
            for (int i = 0; i < 1500; ++i)
            {
                dataSource.Add(new ViewVacationPlan()
                {
                    CountDay = 1,
                    DateBegin = Convert.ToDateTime("2015-08-17 00:00:00.000"),
                    DateEnd = Convert.ToDateTime("2015-09-29 00:00:00.000"),
                    LastName = "Курлени",
                    FirstName = "Алёна",
                    Otch = "Александровна",
                    DepartmentName = "Административно-хозяйственное управление",
                    PostName = "владыка ситхов Дарт Вейдер"
                });
            }

            Kadr.Reporting.ScheduleReportBuilder.Create(@"Reporting\template_график.xlsx", @"Reporting\test_schedule_output.xlsx", dataSource, 2016);

            ProcessStartInfo psi = new ProcessStartInfo(@"Reporting\test_schedule_output.xlsx");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }


       
    }
}
