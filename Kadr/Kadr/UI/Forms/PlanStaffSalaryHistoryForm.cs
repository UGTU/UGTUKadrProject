using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.UI.Forms
{
    public partial class PlanStaffSalaryHistoryForm : Form
    {
        
        
        private Object salaryObject;
        public Object SalaryObject
        {
            get
            {
                return salaryObject;
            }
            set
            {
                salaryObject = value;
                if (salaryObject != null)
                {
                    if (salaryObject is PlanStaff)
                    {
                        PlanStaffSalaryBindingSource.DataSource = KadrController.Instance.Model.PlanStaffSalaries.Where(Sal => Sal.PlanStaff == salaryObject as PlanStaff).OrderByDescending(plSt => plSt.DateBegin);
                        Text = salaryObject.ToString();
                    }
                    if (salaryObject is PKCategory)
                    {
                        PlanStaffSalaryBindingSource.DataSource = KadrController.Instance.Model.PKCategorySalaries.Where(Sal => Sal.PKCategory == salaryObject as PKCategory).OrderByDescending(plSt => plSt.DateBegin);
                        Text = "Уровень " + salaryObject.ToString();
                    }
                }

            }
        }

        public PlanStaffSalaryHistoryForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DelSalaryBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить оклад?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
              == DialogResult.OK)
            {
                if (SalaryObject is PlanStaff)
                {
                    LinqActionsController<PlanStaffSalary>.Instance.DeleteObject(PlanStaffSalaryBindingSource.Current as Kadr.Data.PlanStaffSalary,
                         KadrController.Instance.Model.PlanStaffSalaries, PlanStaffSalaryBindingSource);
                }
                if (SalaryObject is PKCategory)
                {
                    LinqActionsController<PKCategorySalary>.Instance.DeleteObject(PlanStaffSalaryBindingSource.Current as Kadr.Data.PKCategorySalary,
                         KadrController.Instance.Model.PKCategorySalaries, PlanStaffSalaryBindingSource);
                }

            }
        }

        private void EditSalaryBtn_Click(object sender, EventArgs e)
        {
            if (SalaryObject is PlanStaff)
            {
                LinqActionsController<PlanStaffSalary>.Instance.EditObject(PlanStaffSalaryBindingSource.Current as Kadr.Data.PlanStaffSalary, false);
            }
            if (SalaryObject is PKCategory)
            {
                LinqActionsController<PKCategorySalary>.Instance.EditObject(PlanStaffSalaryBindingSource.Current as Kadr.Data.PKCategorySalary, false);
            }
        }

        private void AddSalaryBtn_Click(object sender, EventArgs e)
        {

            if (SalaryObject is PlanStaff)
            {
                using (Kadr.UI.Common.PropertyGridDialogAdding<PlanStaffSalary> dlg =
                                new Kadr.UI.Common.PropertyGridDialogAdding<PlanStaffSalary>())
                {
                    dlg.UseInternalCommandManager = true;
                    dlg.ObjectList = KadrController.Instance.Model.PlanStaffSalaries;
                    dlg.BindingSource = PlanStaffSalaryBindingSource;
                    dlg.ApplyButtonVisible = false;
                    dlg.InitializeNewObject = (x) =>
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PlanStaffSalary, PlanStaff>(x, "PlanStaff", salaryObject as PlanStaff, null), this);
                    };
                    dlg.oneObjectCreated = true;

                    dlg.ShowDialog();
                }
            }
            if (SalaryObject is PKCategory)
            {
                using (Kadr.UI.Common.PropertyGridDialogAdding<PKCategorySalary> dlg =
                                new Kadr.UI.Common.PropertyGridDialogAdding<PKCategorySalary>())
                {
                    dlg.UseInternalCommandManager = true;
                    dlg.ObjectList = KadrController.Instance.Model.PKCategorySalaries;
                    dlg.BindingSource = PlanStaffSalaryBindingSource;
                    dlg.ApplyButtonVisible = false;
                    dlg.InitializeNewObject = (x) =>
                    {

                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<PKCategorySalary, PKCategory>(x, "PKCategory", salaryObject as PKCategory, null), this);
                    };
                    dlg.oneObjectCreated = true;

                    dlg.ShowDialog();
                }
            }
            
        }

    }
}
