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
using Kadr.Data;

namespace Kadr.UI.Dialogs
{
    public partial class PrikazDialog : LinqDataGridViewDialog
    {
        public PrikazDialog()
        {
            InitializeComponent();
        }

        private void PrikazDialog_Load(object sender, EventArgs e)
        {
            prikazTypeBindingSource.DataSource = KadrController.Instance.Model.PrikazTypes;
            bindingNavigator1.BindingSource = prikazBindingSource;
        }

        private void btnPrikazType_Click(object sender, EventArgs e)
        {
            using (PrikazTypeDialog dlg = new PrikazTypeDialog())
            {
                dlg.ShowDialog();
                //обновляем данные
                PrikazDialog_Load(sender, e);
            }

        }

        private void cbPrikazType_SelectedValueChanged(object sender, EventArgs e)
        {
            prikazBindingSource.DataSource = KadrController.Instance.Model.Prikazs.Where(prik => prik.PrikazType == cbPrikazType.SelectedItem);

        }

        private void dgvPrikaz_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //проверяем, чтобы были заполнены какие-то поля
            if ((prikazBindingSource.Current != null)
                && ((prikazBindingSource.Current as Prikaz).PrikazName != "")
                && ((prikazBindingSource.Current as Prikaz).PrikazName != null)
                && (cbPrikazType.SelectedItem != null)
                && ((prikazBindingSource.Current as Prikaz).PrikazType == null))
                (prikazBindingSource.Current as Prikaz).PrikazType =
                        cbPrikazType.SelectedItem as PrikazType;

        }

        private void dgvPrikaz_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
            
        }

        private void prikazBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {

        }

        private void dgvPrikaz_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if ((prikazBindingSource.Current != null)
                    && ((prikazBindingSource.Current as Prikaz).DateBegin != null)
                    && ((prikazBindingSource.Current as Prikaz).DatePrikaz == null))
                (prikazBindingSource.Current as Prikaz).DatePrikaz =
                        (prikazBindingSource.Current as Prikaz).DateBegin;            
        }
    }
}
