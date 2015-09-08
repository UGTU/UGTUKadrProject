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
    public partial class CategoryZPDialog : LinqDataGridViewDialog
    {
        public CategoryZPDialog()
        {
            InitializeComponent();
        }

        private void CategoryZPDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = categoryZPBindingSource;
            categoryZPBindingSource.DataSource = KadrController.Instance.Model.CategoryZPs;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
