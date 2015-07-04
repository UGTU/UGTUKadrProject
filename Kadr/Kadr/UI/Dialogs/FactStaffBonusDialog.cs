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
    public partial class FactStaffBonusDialog : CustomBaseDialog
    {
        public FactStaffBonusDialog()
        {
            InitializeComponent();
        }

        private void FactStaffBonusDialog0_Load(object sender, EventArgs e) 
        {
            factStaffBindingSource.DataSource = KadrController.Instance.Model.FactStaffs.Where(fcSt => fcSt.PlanStaff != null).Where(fs => (fs.DateEnd == null) || (fs.DateEnd > DateTime.Today)).ToArray().OrderBy(fs =>
                fs.Department.DepartmentName).ThenBy(fs => fs.Post.PostName).ThenBy(fs => fs.UniversalEmployee.EmployeeName);
            bonusTypeBindingSource.DataSource = Kadr.Controllers.KadrController.Instance.GetCurrentBonusTypes().OrderBy(bnt => bnt.BonusTypeName).ToArray();
            prikazBeginBindingSource.DataSource = KadrController.Instance.Model.Prikazs.Where(pr => pr.DatePrikaz >= DateTime.Today.AddYears(-2)).OrderByDescending(pr => pr.DatePrikaz);
            prikazEndBindingSource.DataSource = KadrController.Instance.Model.Prikazs.Where(pr => pr.DatePrikaz >= DateTime.Today.AddYears(-2)).OrderByDescending(pr => pr.DatePrikaz);
            prikazEntermEndBindingSource.DataSource = KadrController.Instance.Model.Prikazs.Where(pr => pr.DatePrikaz >= DateTime.Today.AddYears(-2)).OrderByDescending(pr => pr.DatePrikaz);
            financingSourceBindingSource.DataSource = KadrController.Instance.Model.FinancingSources.OrderBy(fs => fs.OrderBy).ToArray();
            BonusFinSourceBindingSource.DataSource = KadrController.Instance.Model.FinancingSources.OrderBy(fs => fs.OrderBy).ToArray();
            dtDateBegin.Value = DateTime.Today;
            cbPrikazEnd.Text = "";
            cbPrikazIntermEnd.Text = "";
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            foreach (FactStaff fcSt in KadrController.Instance.Model.FactStaffs)
            {
                if (fcSt.BonusCount > 0)
                {
                    Bonus bonus = new Bonus();
                    
                    try
                    {
                        bonus.DateEnd = Convert.ToDateTime(mtbDateEnd.Text);
                    }
                        catch
                    {
                        bonus.DateEnd = null;
                    }

                    if (cbPrikazIntermEnd.Text != "")
                        bonus.IntermediateEndPrikaz = cbPrikazIntermEnd.SelectedItem as Prikaz;
                    if (cbPrikazEnd.Text != "")
                        bonus.EndPrikaz = cbPrikazEnd.SelectedItem as Prikaz;
                    bonus.BonusType = cbBonusType.SelectedItem as BonusType;
                    bonus.Comment = tbComment.Text;

                    BonusHistory bonusHistory = new BonusHistory();
                    bonusHistory.BonusCount = fcSt.BonusCount.Value;
                    if (fcSt.BonusFinancingSourceName != null)
                        bonusHistory.FinancingSource = FinancingSource.GetFinancingSourceByName(fcSt.BonusFinancingSourceName);
                    else
                    {
                        if (cbFinancingSource.Text == "")
                            bonusHistory.FinancingSource = fcSt.FinancingSource;
                        else
                            bonusHistory.FinancingSource = cbFinancingSource.SelectedItem as FinancingSource;
                    }
                    if (fcSt.BonusDateBegin != null)
                        bonusHistory.DateBegin = fcSt.BonusDateBegin.Value;
                    else
                        bonusHistory.DateBegin = dtDateBegin.Value;
                    bonusHistory.Prikaz = cbPrikazBegin.SelectedItem as Prikaz;
                    
                    bonusHistory.Bonus = bonus;

                    BonusFactStaff bonusFcSt = new BonusFactStaff();
                    bonusFcSt.FactStaff = fcSt;
                    bonusFcSt.Bonus = bonus;
                    fcSt.BonusCount = null;

                    KadrController.Instance.SubmitChanges();
                 }
            }
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            ApplyBtn_Click(null, null);
            Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            foreach (FactStaff fcSt in KadrController.Instance.Model.FactStaffs)
            {
                if (fcSt.BonusCount != null)
                {
                    fcSt.BonusCount = null;
                }
            }
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
