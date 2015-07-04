using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class DepartmentTypeDialog : LinqDataGridViewDialog
    {
        public DepartmentTypeDialog()
        {
            InitializeComponent();
        }

        private void DepartmentTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.Visible = false;
            bindingNavigator1.BindingSource = departmentTypeBindingSource;
            departmentTypeBindingSource.DataSource = KadrController.Instance.Model.DepartmentTypes.OrderBy(dt => dt.id);
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
