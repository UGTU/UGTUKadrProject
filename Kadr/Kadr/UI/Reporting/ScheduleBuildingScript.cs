using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.UI.Reporting
{
    public class VacationPlanParams
    {
        public int Year { get; set; }

        [System.ComponentModel.Browsable(false)]
        public Guid Department { get; private set; }
        public string OutputFileName { get; internal set; }

        public VacationPlanParams(Guid departmentId)
        {
            var today = DateTime.Today;
            Year = (today.Month > 8 ? today.Year + 1 : today.Year);
            Department = departmentId;
            OutputFileName = $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\График отпусков {Year}.xlsx";
        }
    }
    public class ScheduleBuildingScript
    {
        public VacationPlanParams VacationParams { get; private set; }
        public ScheduleBuildingScript(VacationPlanParams vp)
        {
            VacationParams = vp;
        }
        public void Run()
        {
            using (var dlg = new UI.Common.PropertyGridDialog())
            {
                dlg.SelectedObjects = new[] { VacationParams };
                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    var data = Kadr.Controllers.KadrController.Instance.Model.FetchVacationPlansByDepartmentId(VacationParams.Department, VacationParams.Year);

                    Kadr.Reporting.ScheduleReportBuilder.Create(@"Reporting\template_график.xlsx", VacationParams.OutputFileName, data.AsVacationPlanView(), VacationParams.Year);
                }
            }
        }
    }
}
