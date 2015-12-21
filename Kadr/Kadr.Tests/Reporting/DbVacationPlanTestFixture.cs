using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kadr.Data;
using Kadr.Data.Common;
using System.Linq;
using System.Collections.Generic;
using Kadr.Controllers;
using System.Diagnostics;
using System.Windows.Forms;
using Kadr.Reporting;
using Kadr.UI.Reporting;

namespace Kadr.Tests.Reporting
{
    [TestClass]
    public class DbVacationPlanTestFixture
    {
        [TestMethod]
        public void FetchVacationPlanTest()
        {
            var vp = new VacationPlanParams(Guid.Parse("{BAEE3FD5-664D-E111-96A2-0018FE865BEC}"),
                @"Reporting\template_график.xlsx", @"Reporting\test_schedule_output.xlsx") {Year = 2016};

            var actual = KadrController.Instance.Model.FetchVacationPlansByDepartmentId(vp.Department, vp.Year);
            ScheduleReportBuilder.Create(vp, actual.AsEnumerable());

            ProcessStartInfo psi = new ProcessStartInfo(vp.OutputFileName);
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
        [TestMethod]
        [TestCategory("UI")]
        public void VacationScriptTest()
        {
            var vp = new VacationPlanParams(Guid.Parse("{BAEE3FD5-664D-E111-96A2-0018FE865BEC}"),
             @"Reporting\template_график.xlsx", @"Reporting\test_schedule_output.xlsx")
            { Year = 2016 };
            var script = new ScheduleBuildingScript(vp);
            script.Run();
        }
    }
}
