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
    public partial class BonusProlongFullDialog : CustomBaseDialog
    {

        protected IEnumerable<GetBonusByBonusTypeForProlongResult> bonus;
        
        public BonusProlongFullDialog()
        {
            InitializeComponent();
        }

        private void BonusProlongFullDialog_Load(object sender, EventArgs e)
        {
            financingSourceBindingSource.DataSource = KadrController.Instance.Model.FinancingSources.OrderBy(fnS => fnS.FinancingSourceName).ToArray();
            IEnumerable<BonusType> bonusTypes = KadrController.Instance.Model.BonusTypes.OrderBy(bnT => bnT.BonusTypeName).ToArray();
            prikazBindingSource.DataSource = KadrController.Instance.Model.Prikazs.OrderByDescending(prik => prik.DatePrikaz);
            foreach (BonusType bonType in bonusTypes)
            {
                cbBonusType.Items.Add(bonType);
            }

            cbFinancingSource.Enabled = false;
            chbWithFinSource.Checked = false;
        }

        private void cbBonusType_SelectedIndexChanged(object sender, EventArgs e)
        {
            //загружаем список надбавок указанного типа
            
            bonus = KadrController.Instance.Model.GetBonusByBonusTypeForProlong((cbBonusType.SelectedItem as BonusType).id, DateTime.Today, DateTime.Today.AddMonths(1).AddDays(1 - DateTime.Today.Day)).ToArray();
            getBonusByBonusTypeForProlongResultBindingSource.DataSource = bonus;
            cbProlongForAll.Checked = true;
        }

        protected override void DoApply()
        {
            if ((dtNewDate == null)
                || (cbBonusType.SelectedItem == null)
                || (cbNewPrikaz.SelectedItem == null))
            {
                MessageBox.Show("Внесите все данные!");
                OKClicked = false;
                return;
            }

            //выбираем все надбавки указанного типа, которые еще действующие

            //для каждой подходящей по условиям надбавки создаем запись истории
            IEnumerable<GetBonusByBonusTypeForProlongResult> CheckedBonus = bonus.Where(bon => bon.Prolong.Value).ToArray();
            foreach (GetBonusByBonusTypeForProlongResult curBonus in CheckedBonus)
            {
                Bonus bon = KadrController.Instance.Model.Bonus.Where(bn => bn.id == curBonus.idBonus).FirstOrDefault();
                if (bon == null)
                    continue;
                BonusHistory bonHist = new BonusHistory();
                bonHist.BonusCount = curBonus.BonusCount.Value;
                bonHist.FinancingSource = FinancingSource.GetFinancingSourceByName(curBonus.BonusFinancingSourceName);
                bonHist.DateBegin = dtNewDate.Value;
                bonHist.Prikaz = cbNewPrikaz.SelectedItem as Prikaz;
                bonHist.Bonus = bon;
            }
            KadrController.Instance.SubmitChanges();
        }

        private void chbWithFinSource_CheckedChanged(object sender, EventArgs e)
        {
            cbFinancingSource.Enabled = chbWithFinSource.Checked;
        }

        private void cbBonRepWithSubDeps_CheckedChanged(object sender, EventArgs e)
        {
            foreach (GetBonusByBonusTypeForProlongResult bon in bonus)
            {
                bon.Prolong = cbProlongForAll.Checked;
            }
            getBonusByBonusTypeForProlongResultBindingSource.DataSource = null;
            getBonusByBonusTypeForProlongResultBindingSource.DataSource = bonus;
        }

        

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            (getBonusByBonusTypeForProlongResultBindingSource.Current as GetBonusByBonusTypeForProlongResult).Prolong = true;
        }

        

        
    }
}
