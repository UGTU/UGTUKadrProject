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
    public partial class ReportBaseFrameForQuarter : ReportBaseFrame
    {
        const int QuarterMonthCount = 3;

        public ReportBaseFrameForQuarter()
        {
            InitializeComponent();
        }

        /// <summary>
        /// год отчета
        /// </summary>
        private int selectedYear;
        public int SelectedYear
        {
            get
            {
                return selectedYear;
            }
            set
            {
                if (selectedYear != value)
                {
                    selectedYear = value;
                    //RefreshReport();
                }
            }
        }

        /// <summary>
        /// номер квартала
        /// </summary>
        public int QuaterNumber
        {
            get;
            set;
        }


        public void UpdateReportParams(int Year, int quaterNumber, int DepID, bool WithSubDeps)
        {
            bool IsChanged = false;
            if (SelectedYear != Year)
            {
                selectedYear = Year;
                IsChanged = true;
            }

            if (ReportParam != DepID)
            {
                ReportParam = DepID;
                IsChanged = true;
            }

            if (WithSubReports != WithSubDeps)
            {
                this.WithSubReports = WithSubDeps;
                IsChanged = true;
            }

            if (QuaterNumber != quaterNumber)
            {
                QuaterNumber = quaterNumber;
                IsChanged = true;
            }

            if (IsChanged)
                RefreshReport();
        }

        protected override void DoInitializeReport()
        {
            bsReportData.DataSource = ReportType;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

            if (ReportType == typeof(Reports.GetAverageNumEmplByCatResult) && (ReportNumber == 3))
            {
                this.Text = "Отчет по среднесписочной численности по категориям для заработной платы";
                reportDataSource1.Name = "dsAverageDepByCategory";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepCatZPAverageReport.rdlc";
            }


            if (ReportType == typeof(Reports.GetAverageNumEmplResult) && (ReportNumber == 0))
            {
                this.Text = "Отчет по среднесписочной численности по должностям";
                reportDataSource1.Name = "AverageStaff";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepPostAverageStaff.rdlc";
            }

            if (ReportType == typeof(Reports.GetAverageNumEmplResult) && (ReportNumber == 3))
            {
                this.Text = "Отчет по среднесписочной численности по ОКВЕД";
                reportDataSource1.Name = "dsAverNumEmpl";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.AverageDepByOKVEDReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetFundingDepAverageNumEmplResult))
            {
                this.Text = "Отчет по среднесписочной численности по ЦЗФ";
                reportDataSource1.Name = "dsFundingDepAverageNumEmpl";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.FundingDepAverageNumEmpl.rdlc";
            }
        }

        protected override void LoadData()
        {
            //int MonthBegin = QuaterNumber * QuarterMonthCount + 1;
            //int MonthEnd = (QuaterNumber + 1) * QuarterMonthCount;
            if (ReportType == typeof(Reports.GetAverageNumEmplByCatResult))
                bsReportData.DataSource = Model.GetAverageNumEmplByCat(SelectedYear, ReportParam, WithSubReports, QuaterNumber * QuarterMonthCount + 1, (QuaterNumber + 1) * QuarterMonthCount).ToArray();
            if (ReportType == typeof(Reports.GetAverageNumEmplResult))
                bsReportData.DataSource = Model.GetAverageNumEmpl(SelectedYear, ReportParam, WithSubReports, QuaterNumber * QuarterMonthCount + 1, (QuaterNumber + 1) * QuarterMonthCount).ToArray();
            if (ReportType == typeof(Reports.GetFundingDepAverageNumEmplResult))
                bsReportData.DataSource = Model.GetFundingDepAverageNumEmpl(SelectedYear, ReportParam, WithSubReports, QuaterNumber * QuarterMonthCount + 1, (QuaterNumber + 1) * QuarterMonthCount).ToArray();
        }
    }
}
