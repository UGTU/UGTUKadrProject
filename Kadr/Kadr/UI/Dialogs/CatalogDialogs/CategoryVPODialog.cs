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
    public partial class CategoryVPODialog :  LinqDataGridViewDialog
    {
        public CategoryVPODialog()
        {
            InitializeComponent();
        }

        private void CategoryVPODialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = categoryVPOBindingSource;
            categoryVPOBindingSource.DataSource = KadrController.Instance.Model.CategoryVPOs;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
