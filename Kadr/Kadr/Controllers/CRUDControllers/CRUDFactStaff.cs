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
        public static void Create(System.Windows.Forms.BindingSource factStaffBindingSource, PlanStaff planStaffCurrent, object sender, bool applyButtonVisible = true, bool isMainContract = true, Employee employee = null, UIX.Commands.ICommandManager commandManager = null, Dep department = null, WorkType workType = null)
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

                    Contract newContract = new Contract(dlg.CommandManager, fcStHistory, "", DateTime.Today.Date, DateTime.Today.Date);
                };

                dlg.BeforeApplyAction = (x) =>
                {
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        if (x.CurrentChange != null)
                            if (x.CurrentChange.Contract != null)
                            {
                                dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Contract, string>(x.CurrentChange.Contract, "ContractName", x.CurrentChange.Contract.ContractName, null), sender);
                                dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Contract, DateTime?>(x.CurrentChange.Contract, "DateBegin", x.CurrentChange.Contract.DateBegin, null), sender);
                                dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Contract, DateTime?>(x.CurrentChange.Contract, "DateEnd", x.CurrentChange.Contract.DateEnd, null), sender);
                                dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Contract, DateTime?>(x.CurrentChange.Contract, "DateContract", x.CurrentChange.Contract.DateContract, null), sender);
                            }
                    }

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

            FactStaffHistory fcStHistory = new FactStaffHistory();
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, PlanStaff>(x, "PlanStaff", planStaffCurrent, null), sender);
            
			commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, Prikaz>(fcStHistory, "Prikaz", NullPrikaz.Instance, null), sender);
			commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, WorkType>(fcStHistory, "WorkType", workType, null), sender);

            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Employee>(x, "Employee", employee, null), sender);
			commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(x, "IsReplacement", false, null), sender);
			commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, Dep>(x, "Dep", department, null), sender);
			commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, FundingCenter>(x, "FundingCenter", NullFundingCenter.Instance, null), sender);
			//dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, decimal>(fcStHistory, "SalaryKoeff", 1, null), this);
			commandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffHistory, FactStaff>(fcStHistory, "FactStaff", x, null), sender);

			Contract newContract = new Contract(commandManager,fcStHistory, "", DateTime.Today.Date, DateTime.Today.Date);
						commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Contract, string>(x.CurrentChange.Contract, "ContractName", x.CurrentChange.Contract.ContractName, null), sender);
						commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Contract, DateTime?>(x.CurrentChange.Contract, "DateBegin", x.CurrentChange.Contract.DateBegin, null), sender);
						commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Contract, DateTime?>(x.CurrentChange.Contract, "DateEnd", x.CurrentChange.Contract.DateEnd, null), sender);
						commandManager.Execute(new UIX.Commands.GenericPropertyCommand<Contract, DateTime?>(x.CurrentChange.Contract, "DateContract", x.CurrentChange.Contract.DateContract, null), sender);


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
    }
}
