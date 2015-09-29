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
    public partial class LeaveReasonDialog : LinqDataGridViewDialog
    {
        public LeaveReasonDialog()
        {
            InitializeComponent();
        }

        private void LeaveReasonDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = LeaveReasonBindingSource;
            LeaveReasonBindingSource.DataSource = KadrController.Instance.Model.OK_Reasons.OrderBy(x => x.reasonname);
        }

        private void dgvLeaveReason_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
