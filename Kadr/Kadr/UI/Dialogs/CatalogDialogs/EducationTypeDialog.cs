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
    public partial class EducationTypeDialog : LinqDataGridViewDialog
    {
        public EducationTypeDialog()
        {
            InitializeComponent();
        }

        private void EducationTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = EduTypeBindingSource;
            EduTypeBindingSource.DataSource = KadrController.Instance.Model.EducationTypes.OrderBy(x => x.EduTypeName);
        }

        private void dgvEducationType_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }

}
