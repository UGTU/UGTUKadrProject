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
    public partial class MilitaryTypeDialog : LinqDataGridViewDialog
    {
        public MilitaryTypeDialog()
        {
            InitializeComponent();
        }

        private void MilitaryTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = MilitaryTypeBindingSource;
            MilitaryTypeBindingSource.DataSource = KadrController.Instance.Model.MilitaryTypes.OrderBy(x => x.MilitaryTypeName);
        }

        private void dgvMilitaryType_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
