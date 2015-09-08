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
    public partial class LanguageDialog : LinqDataGridViewDialog
    {
        public LanguageDialog()
        {
            InitializeComponent();
        }

        private void LanguageDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = LanguageBindingSource;
            LanguageBindingSource.DataSource = KadrController.Instance.Model.OK_Languages.OrderBy(x => x.languagename);
        }

        private void dgvLanguage_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
