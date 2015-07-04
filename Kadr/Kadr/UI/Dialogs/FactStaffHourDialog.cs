using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.UI.Common;

namespace Kadr.UI.Dialogs
{
    public partial class FactStaffHourDialog : CustomBaseDialog
    {
        public FactStaffHourDialog()
        {
            InitializeComponent();
        }

        private void FactStaffHourDialog_Load(object sender, EventArgs e)
        {
            factStaffBindingSource.DataSource =
                KadrController.Instance.GetHourFactStaff(null).Where(fcSt => (fcSt.DateEnd == null) || (fcSt.DateEnd > DateTime.Today));
            financingSourceBindingSource.DataSource = KadrController.Instance.Model.FinancingSources.OrderBy(fnS => fnS.FinancingSourceName);
            cbFinancingSource.SelectedItem = FinancingSource.extrabudgetFinancingSource;
            prikazBindingSource.DataSource = KadrController.Instance.Model.Prikazs.Where(pr => (pr.idPrikazType < 26) || (pr.idPrikazType > 28)).OrderByDescending(prik => prik.DatePrikaz).ThenBy(prik => prik.PrikazName);

            cbYear.Items.Clear();
            int thisYear = DateTime.Today.Year;
            cbYear.Items.Add(thisYear - 1);
            cbYear.Items.Add(thisYear);
            cbYear.Items.Add(thisYear + 1);
            cbYear.SelectedIndex = 1;
            cbMonth.SelectedIndex = DateTime.Today.Month-1;
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            foreach (FactStaff fcSt in KadrController.Instance.Model.FactStaffs)
            {
                if (fcSt.MonthHourCount != null)
                {
                    fcSt.MonthHourCount = null;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            foreach (FactStaff fcSt in KadrController.Instance.Model.FactStaffs)
            {
                if (fcSt.MonthHourCount > 0)
                {
                    FactStaffMonthHour hour = new FactStaffMonthHour();

                    hour.MonthNumber = cbMonth.SelectedIndex + 1;
                    hour.YearNumber = Convert.ToInt32(cbYear.SelectedItem);
                    hour.HourCount = Convert.ToDecimal(fcSt.MonthHourCount);
                    hour.FactStaff = fcSt;
                    fcSt.MonthHourCount = null;
                    KadrController.Instance.Model.FactStaffMonthHours.InsertOnSubmit(hour);

                    KadrController.Instance.SubmitChanges();

                    //назначаем надбавку, если почасовик работает по договору
                    if (fcSt.IsContractHourStaff)
                    {
                        Bonus bonus = new Bonus();
                        BonusHistory bonusHistory = new BonusHistory();

                        try
                        {
                            bonus.DateEnd = Convert.ToDateTime("01." + (cbMonth.SelectedIndex + 2).ToString() + '.' + cbYear.SelectedItem.ToString()).AddDays(-1);
                            bonusHistory.DateBegin = Convert.ToDateTime("01." + (cbMonth.SelectedIndex + 1).ToString() + '.' + cbYear.SelectedItem.ToString());
                        }
                        catch
                        {
                            bonus.DateEnd = null;
                        }

                        bonus.BonusType = BonusType.HourBonus;
                        bonus.Comment = tbComment.Text;

                        bonusHistory.BonusCount = hour.BonusSum.Value;                        
                        bonusHistory.Prikaz = cbPrikazBegin.SelectedItem as Prikaz;
                        if (cbFinancingSource.Text == "")
                            bonusHistory.FinancingSource = fcSt.FinancingSource;
                        else
                            bonusHistory.FinancingSource = cbFinancingSource.SelectedItem as FinancingSource;
                        bonusHistory.Bonus = bonus;

                        BonusFactStaff bonusFcSt = new BonusFactStaff();
                        bonusFcSt.FactStaff = fcSt.MainFactStaff;
                        bonusFcSt.Bonus = bonus;

                        KadrController.Instance.Model.Bonus.InsertOnSubmit(bonus);
                        KadrController.Instance.Model.BonusHistories.InsertOnSubmit(bonusHistory);
                        KadrController.Instance.Model.BonusFactStaffs.InsertOnSubmit(bonusFcSt);

                        KadrController.Instance.SubmitChanges();

                    }

                }


            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            ApplyBtn_Click(sender,e);
            Close();
        }
    }
}
