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
    public partial class BonusSuperTypeDialog : LinqDataGridViewDialog
    {

 
        public BonusSuperTypeDialog()
        {
            InitializeComponent();
        }

        private void BonusSuperTypeDialog_Load(object sender, EventArgs e)
        {
            bonusSuperTypeBindingSource.DataSource = KadrController.Instance.Model.BonusSuperTypes;
            bindingNavigator1.BindingSource = bonusSuperTypeBindingSource;
        }

        private void dgvBonusSuperType_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }



    }
}
