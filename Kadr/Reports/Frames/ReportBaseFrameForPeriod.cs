using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reports.Frames
{
    public partial class ReportBaseFrameForPeriod : ReportBaseFrame
    {
        public ReportBaseFrameForPeriod()
        {
            InitializeComponent();
        }

        /// <summary>
        /// дата начала периода
        /// </summary>
        private DateTime periodBegin;
        public DateTime PeriodBegin
        {
            get
            {
                return periodBegin;
            }
            set
            {
                periodBegin = value;
            }
        }

        /// <summary>
        /// дата окончания периода
        /// </summary>
        private DateTime periodEnd;
        public DateTime PeriodEnd
        {
            get
            {
                return periodEnd;
            }
            set
            {
                periodEnd = value;
            }
        }

        public void UpdateReportParams(DateTime periodBegin, DateTime periodEnd, int DepID, bool WithSubDeps)
        {
            if (periodEnd < periodBegin)
            {
                MessageBox.Show("Установлена дата начала периода позже, чем дата окончания!", "АИС Штатное расписание", MessageBoxButtons.OK);
                return;
            }

            bool IsChanged = false;
            if (periodBegin != PeriodBegin)
            {
                PeriodBegin = periodBegin;
                IsChanged = true;
            }

            if (periodEnd != PeriodEnd)
            {
                PeriodEnd = periodEnd;
                IsChanged = true;
            }

            if (WithSubReports != WithSubDeps)
            {
                this.WithSubReports = WithSubDeps;
                IsChanged = true;
            }

            if (ReportParam != DepID)
            {
                this.ReportParam = DepID;
                IsChanged = true;
            }

            if (IsChanged)
                RefreshReport();
        }

        protected override void DoInitializeReport()
        {
            bsReportData.DataSource = ReportType;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

            if (ReportType == typeof(Reports.GetDepartmentBonusWithEmployeesResult) )
            {
                this.Text = "Отчет по надбавкам по сотрудникам";
                reportDataSource1.Name = "dsDepartmentBonus";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepartmentBonusReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetDepartmentBonusForT3Result) && (ReportNumber == 1))
            {
                this.Text = "Отчет Т3 по должностям";
                reportDataSource1.Name = "dsDepBonusForT3";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepByPostBonusT3Report.rdlc";
            }

            if (ReportType == typeof(Reports.GetDepartmentBonusForT3Result) && (ReportNumber == 2))
            {
                this.Text = "Отчет Т3 по категориям";
                reportDataSource1.Name = "dsDepBonusFoT3";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepByCategoryBonusT3Report.rdlc";
            }

            if (ReportType == typeof(Reports.GetEmployeesSumResult))
            {
                this.Text = "Отчет по надбавкам для сотрудника";
                reportDataSource1.Name = "dsEmplBonus";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.EmployeeBonusReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetFactStaffChangesByPeriodResult))
            {
                this.Text = "Отчет изменения в штатах по сотрудникам";
                reportDataSource1.Name = "dsfactStaffChanges";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.FactStaffChangesReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetPostStaffChangesByPeriodResult))
            {
                this.Text = "Отчет изменения в штатах по должностям";
                reportDataSource1.Name = "dsPostStChanges";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.PostStChangesReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetDepartmentBonusWithSettingsResult) && (ReportNumber == 1))
            {
                this.Text = "Отчет основная форма (министерство)";
                reportDataSource1.Name = "dsDepBonus";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.MinFormMainReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetDepartmentBonusWithSettingsResult) && (ReportNumber == 2))
            {
                this.Text = "Отчет форма №7 по должностям(министерство)";
                reportDataSource1.Name = "dsDepartmentBonus";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.MinFormsReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetDepartmentBonusWithSettingsResult) && (ReportNumber == 3))
            {
                this.Text = "Отчет по надбавкам (для раскладов)";
                reportDataSource1.Name = "dsDepBonus";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepartmentBonusSmallReport.rdlc";
            }

            if ((ReportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && (ReportNumber == 4))
            {
                this.Text = "Фонд по источникам с должностями";
                reportDataSource1.Name = "dsDepartmentBonus";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepByPostBonusReport.rdlc";
            }


            if (ReportType == typeof(Reports.GetPPSDepartmentBonusResult))
            {
                this.Text = "Отчет форма №3 по ППС (министерство)";
                reportDataSource1.Name = "dsPPSBonusReport";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.MinForm3PPSReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetDepartmentStaffResult) && (ReportNumber == 1))
            {
                this.Text = "Отчет штат сотрудников с делением по источникам финансирования";
                reportDataSource1.Name = "dsDepStaffReport";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepStaffReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetDepartmentStaffResult) && (ReportNumber == 2))
            {
                this.Text = "Отчет штат сотрудников без деления по источникам финансирования";
                reportDataSource1.Name = "dsDepStaffReport";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepStaffWithoutFinSourceReport.rdlc";
            }

        }

        protected override void LoadData()
        {
            if (ReportType == typeof(Reports.GetDepartmentBonusWithEmployeesResult))
                bsReportData.DataSource = Model.GetDepartmentBonusWithEmployees(ReportParam, PeriodBegin, PeriodEnd, WithSubReports, 1).ToArray();

            if (ReportType == typeof(Reports.GetDepartmentBonusForT3Result))
                bsReportData.DataSource = Model.GetDepartmentBonusForT3(ReportParam, PeriodBegin, PeriodEnd, WithSubReports,7).ToArray();

            if (ReportType == typeof(Reports.GetEmployeesSumResult))
                bsReportData.DataSource = Model.GetEmployeesSum(ReportParam, PeriodBegin, PeriodEnd).ToArray();

            if (ReportType == typeof(Reports.GetFactStaffChangesByPeriodResult))
                bsReportData.DataSource = Model.GetFactStaffChangesByPeriod(ReportParam, PeriodBegin, PeriodEnd, WithSubReports).ToArray();

            if (ReportType == typeof(Reports.GetPostStaffChangesByPeriodResult))
                bsReportData.DataSource = Model.GetPostStaffChangesByPeriod(ReportParam, PeriodBegin, PeriodEnd, WithSubReports).ToArray();

            if (ReportType == typeof(Reports.GetDepartmentBonusWithSettingsResult) && (ReportNumber < 3))
                bsReportData.DataSource = Model.GetDepartmentBonusWithSettings(ReportParam, PeriodBegin, PeriodEnd, WithSubReports, 5, -1).Where(bon => bon.idReplacementReason == null).ToArray();
            
            if (ReportType == typeof(Reports.GetDepartmentBonusWithSettingsResult) && (ReportNumber == 3))
                bsReportData.DataSource = Model.GetDepartmentBonusWithSettings(ReportParam, PeriodBegin, PeriodEnd, WithSubReports, 1, -1).ToArray();

            if ((ReportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && (ReportNumber == 4))
            {
                bsReportData.DataSource = Model.GetDepartmentBonusWithSettings(ReportParam, PeriodBegin, PeriodEnd, true, 12, -1);
            }

            if (ReportType == typeof(Reports.GetPPSDepartmentBonusResult))
                bsReportData.DataSource = Model.GetPPSDepartmentBonus(ReportParam, PeriodBegin, PeriodEnd, WithSubReports).Where(bon => bon.idReplacementReason == null).ToArray();

            if (ReportType == typeof(Reports.GetDepartmentStaffResult))
                bsReportData.DataSource = Model.GetDepartmentStaff(ReportParam, PeriodBegin, PeriodEnd, WithSubReports).ToArray();


        }

    }



}
