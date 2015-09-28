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
    public partial class InkapacityTypeDialog : LinqDataGridViewDialog
    {
        public InkapacityTypeDialog()
        {
            InitializeComponent();
        }

        private void InkapacityTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = InkapacityTypeBindingSource;
            InkapacityTypeBindingSource.DataSource = KadrController.Instance.Model.InkapacityTypes.OrderBy(x => x.NameInkapacityType);
        }

        private void dgvInkapacityType_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
