using Kadr.Data.Common;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Kadr.Reporting;

namespace Kadr.UI.Reporting
{
    public class ScheduleBuildingScript : ReportScript<VacationPlanParams>
    {
        public ScheduleBuildingScript(VacationPlanParams vp) : base(vp){}

        protected override void CreateReport()
        {
            var data = Controllers.KadrController.Instance.Model
                .FetchVacationPlansByDepartmentId(
                    ReportParams.Department, ReportParams.Year).OrderBy(x=>x.LastName);

            ScheduleReportBuilder.Create(ReportParams, data);           
        }        
    }
}
