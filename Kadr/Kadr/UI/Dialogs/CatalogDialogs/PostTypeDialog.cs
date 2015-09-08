using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class PostTypeDialog : LinqDataGridViewDialog
    {
        public PostTypeDialog()
        {
            InitializeComponent();
        }

        private void PostTypeDialog_Load(object sender, EventArgs e)
        {
            postTypeBindingSource.DataSource = KadrController.Instance.Model.PostTypes;
            bindingNavigator1.BindingSource = postTypeBindingSource;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
