using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.UI.Common;

namespace Kadr.UI.Dialogs
{
    public partial class DopEducTypeDialog : LinqDataGridViewDialog
    {
        public DopEducTypeDialog()
        {
            InitializeComponent();
        }

        private void DopEducTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = DopEducTypeBindingSource;
            DopEducTypeBindingSource.DataSource = KadrController.Instance.Model.DopEducTypes.OrderBy(x => x.id);
            TypeDocumentBindingSource.DataSource = KadrController.Instance.Model.EducDocumentTypes.Where(x=>x.isOld == false).OrderBy(y => y.DocTypeName).ToArray();
            foreach (DataGridViewRow row in dgvDopEducType.Rows.Cast<DataGridViewRow>().Where(row => row.Cells["EducDocumentType"].Value != null))
            {
                row.Cells["DocTypeName"].Value = (row.Cells["EducDocumentType"].Value as EducDocumentType).DocTypeName;
            }
        }

        private void dgvDopEducType_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvDopEducType.Rows)
            {
                row.Cells["EducDocumentType"].Value = KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(x => x.DocTypeName == row.Cells["DocTypeName"].Value );
            }

            KadrController.Instance.SubmitChanges();
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            ApplyBtn_Click(null, null);
            Close();
        }
    }
}
