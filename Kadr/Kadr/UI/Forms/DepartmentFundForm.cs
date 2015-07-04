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
    public partial class DepartmentFundForm : Form
    {
        public Dep Department
        { 
            get; set; 
        }

        public DepartmentFundForm()
        {
            InitializeComponent();
        }

        private void DepartmentFundForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            if (Department != null)
            {
                departmentFundBindingSource.DataSource = Department.DepartmentFunds.OrderByDescending(df => df.DateBegin).ToArray();
                Text = "Бюджетный фонд отдела " + Department.DepartmentSmallName;
            }
        }

        private void tsbClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void tsbEditDepFund_Click(object sender, EventArgs e)
        {
            if (Department != null)
            {
                DepartmentFund CurrentFund = departmentFundBindingSource.Current as DepartmentFund;
                if (CurrentFund == null)
                {
                    MessageBox.Show("Не выбрано редактируемое изменение.", "АИС \"Штатное расписание\"");
                    return;
                }
                LinqActionsController<DepartmentFund>.Instance.EditObject(CurrentFund, true);
            }
        }

        private void tsbAddDepFund_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<DepartmentFund> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<DepartmentFund>())
            {
                dlg.ObjectList = KadrController.Instance.Model.DepartmentFunds;
                //dlg.BindingSource = departmentFundBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.PrikazButtonVisible = false;
                dlg.InitializeNewObject = (x) =>
                {
                    if (Department.LastFund != null)
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "PlanFundSum", Department.LastFund.PlanFundSum, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "FactFundSum", Department.LastFund.FactFundSum, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "ExtraordSum", Department.LastFund.ExtraordSum, null), this);
                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "PlanFundSum", 0, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "FactFundSum", 0, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, decimal>(x, "ExtraordSum", 0, null), this);
                    }
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, DateTime>(x, "DateBegin", DateTime.Today, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<DepartmentFund, Dep>(x, "Dep", Department, null), this);
                };

                dlg.ShowDialog();
                LoadData();
            }
        }

        private void tsbDelDepFund_Click(object sender, EventArgs e)
        {
            DepartmentFund CurrentFund = departmentFundBindingSource.Current as DepartmentFund;
            if (CurrentFund == null)
            {
                MessageBox.Show("Не выбрана удаляемая запись бюджета.", "АИС \"Штатное расписание\"");
                return;
            }
            if (MessageBox.Show("Удалить запись бюджета?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
            {

                LinqActionsController<DepartmentFund>.Instance.DeleteObject(CurrentFund,
                     KadrController.Instance.Model.DepartmentFunds, null);
                LoadData();

            }
        }


    }
}
