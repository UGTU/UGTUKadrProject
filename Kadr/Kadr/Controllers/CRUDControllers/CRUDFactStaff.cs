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
        public static FactStaff Create(System.Windows.Forms.BindingSource factStaffBindingSource, PlanStaff planStaffCurrent, object sender, Dep department = null, bool isReplacement = false, FactStaff prevFactStaff = null)
        {
            if ((planStaffCurrent == null) && (department == null))
            {
                MessageBox.Show("Не выбрана должность в штатном расписании.", "ИС \"Управление кадрами\"");
                return null;
            }

            bool employeeReadOnly = true;
            EventKind eventKind = department == null ? MagicNumberController.FactStaffCreateEventKind : MagicNumberController.FactStaffHourCreateEventKind;
            Employee employee;
            if (prevFactStaff == null)
            {
                employee = NullEmployee.Instance;
                employeeReadOnly = false;
            }
            else
            {
                eventKind = MagicNumberController.FactStaffTransferEventKind;
                employee = prevFactStaff.Employee;
            }

            WorkType workType = NullWorkType.Instance;
            bool withContract = true;
            FinancingSource financingSource = NullFinancingSource.Instance;

            //если создается почасовик, то для него другие параметры задаем
            if ((department != null) && (planStaffCurrent == null))
            {
                workType = WorkType.hourWorkType;
                financingSource = MagicNumberController.budgetFinancingSource;
                withContract = false;
            }

            using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaff> dlg =
                 new Kadr.UI.Common.PropertyGridDialogAdding<FactStaff>())
            {
                dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
                dlg.BindingSource = factStaffBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.PrikazButtonVisible = true;

                dlg.InitializeNewObject = (x) =>
                {
                    //x.WithNewEmployee = false;
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, bool>(x, "EmployeeReadOnly", employeeReadOnly, null), sender);
                    FactStaffHistory fcStHistory = new FactStaffHistory();
                    x.SetProperties(dlg.CommandManager, planStaffCurrent, employee, isReplacement, department, financingSource);

                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                        prevFactStaff = dlg.SelectedObjects[0] as FactStaff;
                    if (prevFactStaff != null)
                    {
                        fcStHistory.SetProperties(dlg.CommandManager, x, prevFactStaff.WorkType,
                            eventKind == MagicNumberController.FactStaffTransferEventKind ? NullPrikaz.Instance : prevFactStaff.PrikazBegin,
                            eventKind == MagicNumberController.FactStaffTransferEventKind ? DateTime.Today : prevFactStaff.DateBegin,
                            eventKind,
                            MagicNumberController.BeginEventType, withContract, prevFactStaff);
                        //fcStHistory = new FactStaffHistory(dlg.CommandManager, x, prev.WorkType, prev.PrikazBegin, prev.DateBegin, MagicNumberController.FactStaffCreateEventKind,
                            //MagicNumberController.BeginEventType,withContract);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaff, decimal>(x, "StaffCount", prevFactStaff.StaffCount, null), sender);
                    }
                    else
                    {
                        fcStHistory.SetProperties(dlg.CommandManager, x, workType, NullPrikaz.Instance, DateTime.Today.Date,
                            eventKind,
                            MagicNumberController.BeginEventType, withContract, prevFactStaff);
                        //fcStHistory = new FactStaffHistory(dlg.CommandManager, x, workType, NullPrikaz.Instance, DateTime.Today, MagicNumberController.FactStaffCreateEventKind,
                            //MagicNumberController.BeginEventType, withContract);
                    }

                    

                };


                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.FactStaffs;
                };
                dlg.ShowDialog();

                if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    return dlg.SelectedObjects[0] as FactStaff;
                return null;
            }
        }

        public static DialogResult CreateWithEmployee(System.Windows.Forms.BindingSource factStaffBindingSource, PlanStaff planStaffCurrent, object sender, bool applyButtonVisible = true, bool isMainContract = true, Employee employee = null, UIX.Commands.ICommandManager commandManager = null, Dep department = null, WorkType workType = null, FinancingSource financingSource = null, bool withContract = false, bool isReplacement = false)
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

            FactStaff x = new FactStaff(commandManager, planStaffCurrent, employee, isReplacement, department, financingSource);
            x.EmployeeReadOnly = true;            
            FactStaffHistory fcStHistory = new FactStaffHistory(commandManager, x, workType, NullPrikaz.Instance, DateTime.Today, MagicNumberController.FactStaffCreateEventKind,
                MagicNumberController.BeginEventType, withContract);


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
