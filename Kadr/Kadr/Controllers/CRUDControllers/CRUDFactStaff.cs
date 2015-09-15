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
    public static class CRUDFactStaff
    {
        public static void Create(System.Windows.Forms.BindingSource factStaffBindingSource, PlanStaff planStaffCurrent, object sender, Employee employee = null,  Dep department = null, WorkType workType = null)
        {
            if (planStaffCurrent == null)
            {
                MessageBox.Show("Не выбрана должность в штатном расписании.", "ИС \"Управление кадрами\"");
            }

            if (workType == null)
                workType = NullWorkType.Instance;
            if (employee == null)
                employee = NullEmployee.Instance;

            using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaff> dlg =
                 new Kadr.UI.Common.PropertyGridDialogAdding<FactStaff>())
            {
                dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
                dlg.BindingSource = factStaffBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.PrikazButtonVisible = true;

                dlg.InitializeNewObject = (x) =>
                {

                    FactStaffHistory fcStHistory;
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        FactStaff prev = dlg.SelectedObjects[0] as FactStaff;
                        fcStHistory = new FactStaffHistory(dlg.CommandManager, x, prev.WorkType, prev.PrikazBegin, prev.DateBegin, KadrController.Instance.Model.EventKinds.Where(k => k.id == 1).FirstOrDefault());
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, decimal>(x, "StaffCount", prev.StaffCount, null), sender);
                    }
                    else
                    {
                        fcStHistory = new FactStaffHistory(dlg.CommandManager, x, NullWorkType.Instance, NullPrikaz.Instance, DateTime.Today, KadrController.Instance.Model.EventKinds.Where(k => k.id == 1).FirstOrDefault());
                    }

                    SetProperties(dlg.CommandManager, x, planStaffCurrent, employee);

                };


                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
                };
                dlg.ShowDialog();
            }
        }

        public static DialogResult CreateWithEmployee(System.Windows.Forms.BindingSource factStaffBindingSource, PlanStaff planStaffCurrent, object sender, bool applyButtonVisible = true, bool isMainContract = true, Employee employee = null,UIX.Commands.ICommandManager commandManager = null, Dep department = null, WorkType workType = null)
        {
            if (planStaffCurrent == null)
            {
                MessageBox.Show("Не выбрана должность в штатном расписании.", "ИС \"Управление кадрами\"");
                return DialogResult.None;
            }

            if (workType == null)
                workType = NullWorkType.Instance;
            if (employee == null)
                employee = NullEmployee.Instance;

            FactStaff x = new FactStaff();
            SetProperties(commandManager, x, planStaffCurrent, employee);
            FactStaffHistory fcStHistory = new FactStaffHistory(commandManager, x, workType, NullPrikaz.Instance, DateTime.Today, KadrController.Instance.Model.EventKinds.Where(k => k.id == 1).FirstOrDefault());


            using (Kadr.UI.Dialogs.FactStaffLinqPropertyGridDialogAdding dlg =
                 new Kadr.UI.Dialogs.FactStaffLinqPropertyGridDialogAdding())
            {
                dlg.SelectedObjects = new object[] { x };
                dlg.ApplyButtonVisible = false;
                if (commandManager != null)
                {
                    dlg.CommandManager = commandManager;
                    dlg.UseInternalCommandManager = false;
                }
                else
                    dlg.UseInternalCommandManager = true;
                dlg.PrikazButtonVisible = true;


                return dlg.ShowDialog();
            }
        }

        public static void SetProperties(UIX.Commands.ICommandManager commandManager, FactStaff x, PlanStaff planStaff, Employee employee, bool isReplacement = false, Dep department = null)
        {
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, PlanStaff>(x, "PlanStaff", planStaff, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(x, "Employee", employee, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(x, "IsReplacement", isReplacement, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x, "Dep", department, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FundingCenter>(x, "FundingCenter", NullFundingCenter.Instance, null), null);
        }
    }
}
