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
    public partial class PrikazSuperTypeDialog : LinqDataGridViewDialog
    {
        public PrikazSuperTypeDialog()
        {
            InitializeComponent();
        }

        private void PrikazSuperTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = prikazSuperTypeBindingSource;
            prikazSuperTypeBindingSource.DataSource = KadrController.Instance.Model.PrikazSuperTypes;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
