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
    public partial class BonusReportDialog : LinqDataGridViewDialog
    {
        public BonusReportDialog()
        {
            InitializeComponent();
        }

        private void BonusReportDialog_Load(object sender, EventArgs e)
        {
            bonusReportBindingSource.DataSource = KadrController.Instance.Model.BonusReports;
            bindingNavigator1.BindingSource = bonusReportBindingSource;
            bindingNavigator1.AddNewItem = null;
            bindingNavigator1.DeleteItem = null;
            bindingNavigatorDeleteItem.Enabled = false;
            bindingNavigatorAddNewItem.Enabled = false;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
