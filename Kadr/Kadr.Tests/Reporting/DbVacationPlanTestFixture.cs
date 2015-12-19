using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Kadr.Data;
using Kadr.Data.Common;
using System.Linq;
using System.Collections.Generic;
using Kadr.Controllers;
using System.Diagnostics;
using Kadr.UI.Reporting;

namespace Kadr.Tests.Reporting
{
    [TestClass]
    public class DbVacationPlanTestFixture
    {
        [TestMethod]
        public void FetchVacationPlanTest()
        {
            
           var actual = KadrController.Instance.Model.FetchVacationPlansByDepartmentId(Guid.Parse("{BAEE3FD5-664D-E111-96A2-0018FE865BEC}"),2016);
            Kadr.Reporting.ScheduleReportBuilder.Create(@"Reporting\template_график.xlsx", @"Reporting\test_schedule_output.xlsx", actual.AsEnumerable().AsVacationPlanView(), 2016);

            ProcessStartInfo psi = new ProcessStartInfo(@"Reporting\test_schedule_output.xlsx");
            Process p = new Process();
            p.StartInfo = psi;
            p.Start();
        }
        [TestMethod]
        public void VacationScriptTest()
        {
            var par = new VacationPlanParams(Guid.Parse("{BAEE3FD5-664D-E111-96A2-0018FE865BEC}"));
            var script = new ScheduleBuildingScript(par);
            script.Run();
        }
    }
}
