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
    public partial class MilitaryCategoryDialog : LinqDataGridViewDialog
    {
        public MilitaryCategoryDialog()
        {
            InitializeComponent();
        }

        private void MilitaryCategoryDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = MilitaryCategoryBindingSource;
            MilitaryCategoryBindingSource.DataSource = KadrController.Instance.Model.MilitaryCategories.OrderBy(x => x.MilitaryCategoryName);
        }

        private void dgvMilitaryCategory_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
