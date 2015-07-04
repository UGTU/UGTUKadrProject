using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class PrikazTypeDialog : LinqDataGridViewDialog
    {
        public PrikazTypeDialog()
        {
            InitializeComponent();
        }

        private void PrikazTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = prikazTypeBindingSource;
            prikazSuperTypeBindingSource.DataSource = KadrController.Instance.Model.PrikazSuperTypes;
        }

        private void cbPrikazSuperType_SelectedValueChanged(object sender, EventArgs e)
        {
            prikazTypeBindingSource.DataSource = KadrController.Instance.Model.PrikazTypes.Where(prt => prt.PrikazSuperType == cbPrikazSuperType.SelectedItem);
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //проверяем, чтобы были заполнены какие-то поля
            if ((prikazTypeBindingSource.Current != null)
                && ((prikazTypeBindingSource.Current as PrikazType).PrikazTypeName != "")
                && ((prikazTypeBindingSource.Current as PrikazType).PrikazTypeName != null)
                && (cbPrikazSuperType.SelectedItem != null))
                (prikazTypeBindingSource.Current as PrikazType).PrikazSuperType =
                        cbPrikazSuperType.SelectedItem as PrikazSuperType;

        }

        private void btnBonusSuperType_Click(object sender, EventArgs e)
        {
            using (PrikazSuperTypeDialog dlg = new PrikazSuperTypeDialog())
            {
                dlg.ShowDialog();
                //обновляем данные
                PrikazTypeDialog_Load(sender, e);
            }

        }

        private void dataGridView1_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
