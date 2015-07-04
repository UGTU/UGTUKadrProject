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
    public partial class BonusReportColumnsDialog : LinqDataGridViewDialog
    {
        public BonusReportColumnsDialog()
        {
            InitializeComponent();
        }

        private void BonusReportColumnsDialog_Load(object sender, EventArgs e)
        {
            bonusReportBindingSource.DataSource = KadrController.Instance.Model.BonusReports.Where(bonRep => 
                !bonRep.DefaultBonusOrder).OrderBy(bonRep => bonRep.ReporName);
            bonusTypeBindingSource.DataSource = KadrController.Instance.Model.BonusTypes.OrderBy(bonRep =>
                bonRep.BonusTypeName);
            bindingNavigator1.BindingSource = bonusReportColumnBindingSource;
            bindingNavigator1.AddNewItem = null;
            bindingNavigator1.DeleteItem = null;
            bindingNavigatorDeleteItem.Enabled = false;
            bindingNavigatorAddNewItem.Enabled = false;
            
        }

        private void btnBonusReport_Click(object sender, EventArgs e)
        {
            using (BonusReportDialog dlg = new BonusReportDialog())
            {
                dlg.ShowDialog();
            }
            //обновляем данные
            BonusReportColumnsDialog_Load(null, null);
        }

        private void cbBonusReport_SelectedValueChanged(object sender, EventArgs e)
        {
            bonusReportColumnBindingSource.DataSource = KadrController.Instance.Model.BonusReportColumns.Where(brCol =>
                brCol.BonusReport ==cbBonusReport.SelectedItem ).OrderBy(brCol => brCol.BonusOrderNumber);
        }

        private void dgvBonusReportColumns_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            //проверяем, чтобы было заполнено название вида надбавки
            if ((bonusReportColumnBindingSource.Current != null)
                && ((bonusReportColumnBindingSource.Current as BonusReportColumn).BonusOrderNumber > 0)
                && ((bonusReportColumnBindingSource.Current as BonusReportColumn).BonusType != null)
                && (cbBonusReport.SelectedValue != null)
                && ((bonusReportColumnBindingSource.Current as BonusReportColumn).BonusReport !=
                        cbBonusReport.SelectedItem as BonusReport))
            {
                (bonusReportColumnBindingSource.Current as BonusReportColumn).BonusReport =
                        cbBonusReport.SelectedItem as BonusReport;
                cbBonusReport_SelectedValueChanged(null, null);
                /*if ((bonusReportColumnBindingSource.Current as BonusReportColumn).BonusOrderNumber < 1)
                    (bonusReportColumnBindingSource.Current as BonusReportColumn).BonusOrderNumber =
                        (cbBonusReport.SelectedItem as BonusReport).BonusReportColumns.Select(repCol =>
                            repCol.BonusOrderNumber).Max()+1;*/
             }
        }
        
        private void dgvBonusReportColumns_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                (bonusReportColumnBindingSource.Current as BonusReportColumn).BonusType =
                        bonusTypeBindingSource.Current as BonusType;
                if ((bonusReportColumnBindingSource.Current as BonusReportColumn).BonusOrderNumber < 1)
                {
                    BonusReport bonReport = cbBonusReport.SelectedItem as BonusReport;
                    if (bonReport.BonusReportColumns.Count == 0)
                        (bonusReportColumnBindingSource.Current as BonusReportColumn).BonusOrderNumber = 1;
                    else
                        (bonusReportColumnBindingSource.Current as BonusReportColumn).BonusOrderNumber =
                            (cbBonusReport.SelectedItem as BonusReport).BonusReportColumns.Select(repCol =>
                                repCol.BonusOrderNumber).Max() + 1;
                }
                (bonusReportColumnBindingSource.Current as BonusReportColumn).BonusReport =
                        cbBonusReport.SelectedItem as BonusReport;
            }
        }

        private void dgvBonusReportColumns_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            IsModified = true;
        }
    }
}
