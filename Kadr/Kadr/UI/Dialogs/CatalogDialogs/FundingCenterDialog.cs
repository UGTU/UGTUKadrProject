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
    public partial class FundingCenterDialog : LinqDataGridViewDialog
    {
        public FundingCenterDialog()
        {
            InitializeComponent();
        }

        private void FundingCenterDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = fundingCenterBindingSource;
            fundingCenterBindingSource.DataSource = KadrController.Instance.Model.FundingCenters;
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
