using System;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class BonusMeasureDialog : LinqDataGridViewDialog
    {
        public BonusMeasureDialog()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }

        private void BonusMeasureDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = bonusMeasureBindingSource;
            bonusMeasureBindingSource.DataSource = KadrController.Instance.Model.BonusMeasures;

        }
    }
}
