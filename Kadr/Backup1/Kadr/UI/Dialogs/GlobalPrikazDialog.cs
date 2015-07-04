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
    public partial class GlobalPrikazDialog : LinqDataGridViewDialog
    {
        public GlobalPrikazDialog()
        {
            InitializeComponent();
        }

        private void GlobalPrikazDialog_Load(object sender, EventArgs e)
        {
            globalPrikazBindingSource.DataSource = KadrController.Instance.Model.GlobalPrikazs;
            bindingNavigator1.BindingSource = globalPrikazBindingSource;

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
