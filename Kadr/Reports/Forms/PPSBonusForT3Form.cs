using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using Reports.Dialogs;

namespace Reports.Forms
{
    public partial class PPSBonusForT3Form : Form
    {
        public PPSBonusForT3Form()
        {
            InitializeComponent();
        }
        //bool IsShowed;
        
        
        private KadrDataDataContext model;

        public KadrDataDataContext Model
        {
            get
            {
                if (model == null)
                    model = new KadrDataDataContext();
                return model;
            }
        }


        public void RefreshReport()
        {
            DoRefreshReport();
        }

        private void DoRefreshReport()
        {
            if (dtpPeriodEnd.Value < dtpPeriodBegin.Value)
            {
                MessageBox.Show("Установлена дата начала периода позже, чем дата окончания!", "АИС Штатное расписание", MessageBoxButtons.OK);
                return;
            }


            if (cbParamValue.SelectedItem != null)
            {
                if (reportType == typeof(Reports.GetBonusByBonusTypeResult))
                {
                    bsReportData.DataSource = Model.GetBonusByBonusType((cbParamValue.SelectedItem as BonusType).id, dtpPeriodBegin.Value, dtpPeriodEnd.Value).OrderBy(bon => bon.DepartmentName);
                }

                if (reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult))
                {
                    bsReportData.DataSource = Model.GetDepartmentBonusWithSettings(1, dtpPeriodBegin.Value, dtpPeriodEnd.Value, true, 3, (cbParamValue.SelectedItem as WorkType).id);
                }
            }
            else
                if ((reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) )
                {
                    bsReportData.DataSource = Model.GetDepartmentBonusWithSettings(1, dtpPeriodBegin.Value, dtpPeriodEnd.Value, true, 1, -1);
                }
            

            this.reportViewer1.RefreshReport();
            
        }


        private System.Type reportType;




        public void LoadData(System.Type ReportType)
        {
            reportType = ReportType;
            dtpPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
            dtpPeriodEnd.Value = DateTime.Today;
            //model = new KadrDataDataContext();
            bsReportData.DataSource = ReportType;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            if (reportType == typeof(Reports.GetPPSDepartmentBonusForT3Result))
            {
                this.Text = "Отчет Т3 по ППС";
                tslParamName.Visible = false;
                cbParamValue.Visible = false;
                btnSettings.Visible = false;
                reportDataSource1.Name = "dsPPSBonusForT3";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.PPSBonusForT3.rdlc";

                //RefreshReport();
           }

        }


        private void BaseReportForm_Load(object sender, EventArgs e)
        {
            reportViewer1.RefreshReport();
        }


        private void btnLoadData_Click(object sender, EventArgs e)
        {
            RefreshReport();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

       

     }
}

