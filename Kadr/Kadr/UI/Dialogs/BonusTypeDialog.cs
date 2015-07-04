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
    public partial class BonusTypeDialog : LinqDataGridViewDialog
    {
        public BonusTypeDialog()
        {
            InitializeComponent();
        }

        private void BonusTypeDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = bonusTypeBindingSource;
            bonusSuperTypeBindingSource.DataSource = KadrController.Instance.Model.BonusSuperTypes;
            bonusMeasureBindingSource.DataSource = KadrController.Instance.Model.BonusMeasures;
        }

        private void cbBonusSuperType_SelectedValueChanged(object sender, EventArgs e)
        {
            bonusTypeBindingSource.DataSource = KadrController.Instance.Model.BonusTypes.Where(bt => 
                bt.BonusSuperType == cbBonusSuperType.SelectedItem).Where(bt => bt.BonusMeasure == cbBonusMeasure.SelectedItem);
        }

        private void dgvBonusType_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //проверяем, чтобы было заполнено название вида надбавки
            if ((bonusTypeBindingSource.Current != null)
                && ((bonusTypeBindingSource.Current as BonusType).BonusTypeName != "")
                && ((bonusTypeBindingSource.Current as BonusType).BonusTypeName != null)
                && (cbBonusSuperType.SelectedItem != null)
                && (cbBonusMeasure.SelectedItem != null))
            {
                (bonusTypeBindingSource.Current as BonusType).BonusSuperType =
                        cbBonusSuperType.SelectedItem as BonusSuperType;
                (bonusTypeBindingSource.Current as BonusType).BonusMeasure =
                        cbBonusMeasure.SelectedItem as BonusMeasure;
            }

            if ((bonusTypeBindingSource.Current as BonusType).DateEnd.ToString() == "")
                (bonusTypeBindingSource.Current as BonusType).DateEnd = null;
        }

        private void btnBonusSuperType_Click(object sender, EventArgs e)
        {
            using (BonusSuperTypeDialog dlg = new BonusSuperTypeDialog())
            {
                dlg.ShowDialog();
                //обновляем данные
                BonusTypeDialog_Load(sender,e);
            }

        }

        private void dgvBonusType_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }

        private void btnBonusMeasure_Click(object sender, EventArgs e)
        {
            using (BonusMeasureDialog dlg = new BonusMeasureDialog())
            {
                dlg.ShowDialog();
                //обновляем данные
                BonusTypeDialog_Load(sender, e);
            }

        }

 

    }
}
