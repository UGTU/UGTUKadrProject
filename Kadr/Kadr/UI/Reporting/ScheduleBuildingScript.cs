using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Kadr.Reporting;

namespace Kadr.UI.Reporting
{
   
    public class ScheduleBuildingScript
    {
        private readonly VacationPlanParams _vacationParams;

        public ScheduleBuildingScript(VacationPlanParams vp)
        {
            if (vp == null) throw new ArgumentNullException(nameof(vp));
            _vacationParams = vp;
        }

        public void Run()
        {
            using (var dlg = new UIX.UI.PropertyGridViewerDialog())
            {
                dlg.SelectedObject = _vacationParams;

                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            }

            var data = Controllers.KadrController.Instance.Model.FetchVacationPlansByDepartmentId(
                _vacationParams.Department, _vacationParams.Year);

            Kadr.Reporting.ScheduleReportBuilder.Create(_vacationParams, data.AsVacationPlanView());

            try
            {
                RunShell();
            }
            catch (Exception exception)
            {
                throw new ApplicationException($"Файл с отчётом успешно построен по адресу {_vacationParams.OutputFileName}, однако не удалось запустить средство просмотра. Информация об ошибке содержится во вложенном сообщении.", exception);
            }

        }

        private void RunShell()
        {
            var psi = new ProcessStartInfo(_vacationParams.OutputFileName);
            var p = new Process { StartInfo = psi };
            p.Start();
        }
    }
}
