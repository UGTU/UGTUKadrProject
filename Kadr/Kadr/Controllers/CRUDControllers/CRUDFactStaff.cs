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
        public static void Create(System.Windows.Forms.BindingSource factStaffBindingSource, PlanStaff planStaffCurrent, object sender, bool applyButtonVisible = true, Employee employee = null,UIX.Commands.ICommandManager commandManager = null, Dep department = null, WorkType workType = null)
        {
            if (workType == null)
                workType = NullWorkType.Instance;
            if (employee == null)
                employee = NullEmployee.Instance;

            using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaff> dlg =
                 new Kadr.UI.Common.PropertyGridDialogAdding<FactStaff>())
            {
                dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
                dlg.BindingSource = factStaffBindingSource;
                if (commandManager != null)
                {
                    dlg.CommandManager = commandManager;
                    dlg.UseInternalCommandManager = false;
                }
                else
                    dlg.UseInternalCommandManager = true;
                dlg.PrikazButtonVisible = true;
                dlg.oneObjectCreated = !applyButtonVisible;
                dlg.InitializeNewObject = (x) =>
                {
                    FactStaffHistory fcStHistory = new FactStaffHistory();
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, PlanStaff>(x, "PlanStaff", planStaffCurrent, null), sender);
                    //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x, "Dep", (planStaffBindingSource.Current as PlanStaff).Dep, null), this);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        FactStaff prev = dlg.SelectedObjects[0] as FactStaff;
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, DateTime?>(fcStHistory, "DateBegin", prev.LastChange.DateBegin, null), this);
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", prev.PrikazBegin, null), this);
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", prev.WorkType, null), this);
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "StaffCount", prev.StaffCount, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, DateTime?>(x, "DateBegin", prev.DateBegin, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "PrikazBegin", prev.PrikazBegin, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, WorkType>(x, "WorkType", prev.WorkType, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, decimal>(x, "StaffCount", prev.StaffCount, null), sender);
                        

                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", NullPrikaz.Instance, null), sender);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", workType, null), sender);
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Prikaz>(x, "PrikazBegin", NullPrikaz.Instance, null), this);
                        //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, WorkType>(x, "WorkType", NullWorkType.Instance, null), this);
                    }
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(x, "Employee", employee, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(x, "IsReplacement", false, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x, "Dep", department, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FundingCenter>(x, "FundingCenter", NullFundingCenter.Instance, null), sender);
                    //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "SalaryKoeff", 1, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(fcStHistory, "FactStaff", x, null), sender);
                };

                

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
                };
                dlg.ShowDialog();
            }
        }
    }
}
