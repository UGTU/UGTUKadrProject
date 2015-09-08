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
    public partial class MilitaryRankDialog : LinqDataGridViewDialog
    {
        public MilitaryRankDialog()
        {
            InitializeComponent();
        }

        private void MilitaryRankDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = MilitaryRankBindingSource;
            MilitaryRankBindingSource.DataSource = KadrController.Instance.Model.MilitaryRanks.OrderBy(x => x.MilitaryRankName);
        }

        private void dgvMilitaryRank_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
