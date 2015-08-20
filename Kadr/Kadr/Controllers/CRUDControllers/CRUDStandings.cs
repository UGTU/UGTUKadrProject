using Kadr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;

namespace Kadr.Controllers
{


    public static class CRUDStanding
    {
        public static void Create(Employee e, BindingSource employeeStandingBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<EmployeeStanding> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<EmployeeStanding>())
            {
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, DateTime>(x, "DateBegin", DateTime.Today, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, DateTime>(x, "DateEnd", DateTime.Today, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, Employee>(x, "Employee", e, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, RegionType>(x, "RegionType", NullRegionType.Instance, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, StandingType>(x, "StandingType", NullStandingType.Instance, null), sender);
                };


                dlg.ShowDialog();
            }
            Read(e, employeeStandingBindingSource);
        }

        public static void Read(Employee e, BindingSource employeeStandingBindingSource)
        {
            employeeStandingBindingSource.DataSource =
            KadrController.Instance.Model.EmployeeStandings.Where(empSt => empSt.Employee == e)
                .OrderBy(empSt => empSt.DateBegin)
                .ToArray(); 
        }

        public static void Update(Employee e, BindingSource employeeStandingBindingSource)
        {
            if (employeeStandingBindingSource.Current != null)
                LinqActionsController<EmployeeStanding>.Instance.EditObject(
                        employeeStandingBindingSource.Current as EmployeeStanding, false);
            Read(e, employeeStandingBindingSource);
        }

        public static void Delete(Employee e, BindingSource employeeStandingBindingSource)
        {
            if (MessageBox.Show("Удалить запись трудовой книжки сотрудника?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                LinqActionsController<EmployeeStanding>.Instance.DeleteObject((employeeStandingBindingSource.Current as EmployeeStanding),
                     KadrController.Instance.Model.EmployeeStandings, null);
                Read(e, employeeStandingBindingSource);
            }
            
        }


    }
}
