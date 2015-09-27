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
    public partial class GovDepartmentDialog : LinqDataGridViewDialog
    {
        public GovDepartmentDialog()
        {
            InitializeComponent();
        }

        private void GovDepartmentDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = GovDepartmentBindingSource;
            GovDepartmentBindingSource.DataSource = KadrController.Instance.Model.GovDepartments.OrderBy(x => x.Name);
        }

        private void dgvGovDepartment_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
