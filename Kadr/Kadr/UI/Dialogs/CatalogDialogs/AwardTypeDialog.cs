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
    public partial class AwardTypeDialog : LinqDataGridViewDialog
    {
        public AwardTypeDialog()
        {
            InitializeComponent();
        }

        private void AwardTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = AwardTypeBindingSource;
            AwardTypeBindingSource.DataSource = KadrController.Instance.Model.AwardTypes.OrderBy(x => x.Name);
        }

        private void dgvAwardType_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
