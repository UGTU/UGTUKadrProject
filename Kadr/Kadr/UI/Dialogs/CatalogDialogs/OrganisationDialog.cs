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
    public partial class OrganisationDialog : LinqDataGridViewDialog
    {
        public OrganisationDialog()
        {
            InitializeComponent();
        }

        private void OrganisationDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = OrganisationBindingSource;
            OrganisationBindingSource.DataSource = KadrController.Instance.Model.Organisations.OrderBy(x => x.Name);
        }

        private void dgvOrganisation_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
