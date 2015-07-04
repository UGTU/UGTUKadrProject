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
    public partial class DepartmentHistoryForm : Form
    {
        public Dep Department { get; set; }
        
        public DepartmentHistoryForm()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void DepartmentHistoryForm_Load(object sender, EventArgs e)
        {
            if (Department != null)
            {
                Text = "История " + Department.ToString();
                departmentHistoryBindingSource.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.DepartmentHistories.Where(hist =>
                        hist.Dep == Department).OrderBy(hist => hist.DateBegin);
            }
        }

        private void EditFStChangeBtn_Click(object sender, EventArgs e)
        {
            if (Department != null)
            {
                DepartmentHistory CurrentChange = departmentHistoryBindingSource.Current as DepartmentHistory;
                if (CurrentChange == null)
                {
                    MessageBox.Show("Не выбрано редактируемое изменение.", "АИС \"Штатное расписание\"");
                    return;
                }
                LinqActionsController<DepartmentHistory>.Instance.EditObject(departmentHistoryBindingSource.Current as DepartmentHistory, true);
            }
        }

        private void DelFStChangeBtn_Click(object sender, EventArgs e)
        {
            DepartmentHistory CurrentChange = departmentHistoryBindingSource.Current as DepartmentHistory;
            if (CurrentChange == null)
            {
                MessageBox.Show("Не выбрано удаляемое изменение.", "АИС \"Штатное расписание\"");
                return;
            }

            if (MessageBox.Show("Удалить изменение?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
            {

                LinqActionsController<DepartmentHistory>.Instance.DeleteObject(departmentHistoryBindingSource.Current as DepartmentHistory,
                     KadrController.Instance.Model.DepartmentHistories, departmentHistoryBindingSource);

            }
        }

    }
}
