using Kadr.Data;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using UIX.Commands;

namespace Kadr.Controllers
{
    public static class CRUDEmployee
    {
        public static void Create(object sender, PlanStaff planStaff)
        {
            if (planStaff == null)
            {
                MessageBox.Show("Не выбрана должность в штатном расписании.", "ИС \"Управление кадрами\"");
                return;
            }

            using (PropertyGridDialogAdding<Employee> dlg =
                new PropertyGridDialogAdding<Employee>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.Employees;
                dlg.PrikazButtonVisible = false;
                dlg.oneObjectCreated = true;
                //dlg.BindingSource = employeeBindingSource;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, Guid>(x, "GUID", Guid.NewGuid(), null), sender);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        Employee prev = dlg.SelectedObjects[0] as Employee;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, SemPol>(x, "SemPol", prev.SemPol, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, Grazd>(x, "Grazd", prev.Grazd, null), sender);

                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, SemPol>(x, "SemPol", NullSemPol.Instance, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Employee, Grazd>(x, "Grazd", Grazd.DefaultGrazd, null), sender);

                    }
                };

                dlg.BeforeApplyAction = (x) =>
                {
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        CRUDFactStaff.Create(null, planStaff, sender, false, true, x, dlg.CommandManager,null, WorkType.MainWorkType);
                    }

                };

                dlg.ShowDialog();
                //RefreshFrame();
            }
        }
    }
}
