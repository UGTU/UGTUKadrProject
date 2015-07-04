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
using Kadr.Data.Common;
using System.Collections;

namespace Kadr.UI.Dialogs
{
    public partial class BonusProlongDialog : CustomBaseDialog
    {
        public BonusProlongDialog()
        {
            InitializeComponent();
        }

        private void BonusProlongDialog_Load(object sender, EventArgs e)
        {
            bonusTypeBindingSource.DataSource = Kadr.Controllers.KadrController.Instance.GetCurrentBonusTypes().OrderBy(bnt => bnt.BonusTypeName).ToArray();
            cbBonusType.SelectedItem = KadrController.Instance.Model.BonusTypes.Where(bnt => bnt.id == 3).FirstOrDefault();
            //bonusTypeBindingSource.Current = KadrController.Instance.Model.BonusTypes.OrderBy(bnt => bnt.BonusTypeName).Where(bnt => bnt.id == 3).FirstOrDefault();
            newPrikazBindingSource.DataSource = KadrController.Instance.Model.Prikazs.Where(pr => pr.DatePrikaz >= DateTime.Today.AddYears(-2)).OrderByDescending(pr => pr.DatePrikaz);
            financingSourceBindingSource.DataSource = KadrController.Instance.Model.FinancingSources.OrderBy(fs => fs.OrderBy).ToArray();
            dtNewDate.Value = DateTime.Today;
            cbFinancingSource.Enabled = false;
            chbWithFinSource.Checked = false;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            ApplyBtn_Click(null, null);
            Close();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
             if ((dtNewDate.Value == null) 
                ||(cbBonusType.SelectedItem == null) 
                || (cbNewPrikaz.SelectedItem == null))
            {
               MessageBox.Show("Внесите все данные!");
               return;                
            }

             var deps = KadrController.Instance.Model.GetSubDepartmentsWithPeriod(1, dtNewDate.Value, dtNewDate.Value).ToArray();

            //выбираем все надбавки указанного типа, которые еще действующие
             var bonus = KadrController.Instance.Model.Bonus.Where(bn => bn.BonusType == cbBonusType.SelectedItem).Where(bn =>
                         (bn.DateEnd > dtNewDate.Value) || (bn.DateEnd == null)).ToArray().Where(bn => deps.Select(dep => dep.idDepartment).Contains(bn.Department.id)).ToArray();

            //для каждой подходящей по условиям надбавки создаем запись истории
            foreach (Bonus bon in bonus)
            {
                //проверяем, если сотрудник уволен к началу месяца продления надбавки, то ему не продлеваем
                if (bon.BonusFactStaff != null)
                    if (bon.BonusFactStaff.FactStaff.DateEnd <= dtNewDate.Value.AddDays(-dtNewDate.Value.Day+1))
                        continue;
                BonusHistory bonHist = new BonusHistory();
                bonHist.BonusCount = bon.LastBonusCount;
                bonHist.DateBegin = dtNewDate.Value;
                bonHist.Prikaz = cbNewPrikaz.SelectedItem as Prikaz;
                if ((chbWithFinSource.Checked) && (cbFinancingSource.SelectedItem != null))
                {
                    //если источник финансирования <не указано> 
                    if ((cbFinancingSource.SelectedItem as FinancingSource).id == 0) 
                    {
                        bonHist.FinancingSource = bon.ObjectFinancingSource;
                    }
                    else
                        bonHist.FinancingSource = cbFinancingSource.SelectedItem as FinancingSource;
                }
                else //если источник просто не указан, то берем источник надбавки
                {
                    bonHist.FinancingSource = bon.LastFinancingSource;
                }
                bonHist.Bonus = bon;
            }
            KadrController.Instance.SubmitChanges();
        }

        private void chbWithFinSource_CheckedChanged(object sender, EventArgs e)
        {
            cbFinancingSource.Enabled = chbWithFinSource.Checked;

        }
    }
}
