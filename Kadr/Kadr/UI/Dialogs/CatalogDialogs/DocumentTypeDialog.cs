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
    public partial class DocumentTypeDialog : LinqDataGridViewDialog
    {
        public DocumentTypeDialog()
        {
            InitializeComponent();
        }

        private void OrganisationDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = DocumentTypeBindingSource;
            DocumentTypeBindingSource.DataSource = KadrController.Instance.Model.EducDocumentTypes.Where(x => x.isOld == false).OrderBy(x => x.DocTypeName);
        }

        private void dgvDocumentType_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
