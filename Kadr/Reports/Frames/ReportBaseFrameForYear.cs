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
    public partial class ReportBaseFrameForYear : ReportBaseFrame
    {
         
       
        public ReportBaseFrameForYear()
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
                }
            }
        }


        public void UpdateReportParams(int Year, int DepID, bool WithSubDeps)
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

            if (this.WithSubReports != WithSubDeps)
            {
                this.WithSubReports = WithSubDeps;
                IsChanged = true;
            }

            if (IsChanged)
                RefreshReport();
        }



        protected override void DoInitializeReport()
        {
            bsReportData.DataSource = ReportType;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();

            if (ReportType == typeof(Reports.GetAverageNumEmplByCatResult) && (ReportNumber == 1))
            {
                this.Text = "Отчет по среднесписочной численности по категориям";
                reportDataSource1.Name = "AverageStaff";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepCategoryAverageStaff.rdlc";
            }

            if (ReportType == typeof(Reports.GetAverageNumEmplByCatResult) && (ReportNumber == 2))
            {
                this.Text = "Отчет по среднесписочной численности по категориям ВПО";
                reportDataSource1.Name = "dsAverageDepByCategory";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepCatVPOAverageReport.rdlc";
            }

            if (ReportType == typeof(Reports.GetAverageNumEmplResult))
            {
                this.Text = "Отчет по среднесписочной численности по видам работы";
                reportDataSource1.Name = "AverageStaff";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.AverageStaff.rdlc";
            }
        }

        protected override void LoadData()
        {
            if (ReportType == typeof(Reports.GetAverageNumEmplByCatResult))
                bsReportData.DataSource = Model.GetAverageNumEmplByCat(SelectedYear, ReportParam, WithSubReports,1,12).ToArray();

            if (ReportType == typeof(Reports.GetAverageNumEmplResult))
                bsReportData.DataSource = Model.GetAverageNumEmpl(SelectedYear, ReportParam, WithSubReports,1,12).ToArray();
        }
    }
}
