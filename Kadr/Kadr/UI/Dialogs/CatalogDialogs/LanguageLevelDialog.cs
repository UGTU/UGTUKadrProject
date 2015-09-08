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
    public partial class LanguageLevelDialog : LinqDataGridViewDialog
    {
        public LanguageLevelDialog()
        {
            InitializeComponent();
        }

        private void LanguageLevelDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = LanguageLevelBindingSource;
            LanguageLevelBindingSource.DataSource = KadrController.Instance.Model.LanguageLevels.OrderBy(x => x.id);
        }

        private void dgvLanguageLevel_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
