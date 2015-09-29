using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.UI.Common;

namespace Kadr.UI.Dialogs
{
    public partial class AwardLevelDialog : LinqDataGridViewDialog
    {
        public AwardLevelDialog()
        {
            InitializeComponent();
        }

        private void AwardLevelDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = AwardLevelBindingSource;
            AwardLevelBindingSource.DataSource = KadrController.Instance.Model.AwardLevels.OrderBy(x => x.Name);
        }

        private void dgvAwardLevel_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
