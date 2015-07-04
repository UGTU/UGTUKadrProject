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
    public partial class BaseReportForm : Form
    {

        public BaseReportForm()
        {
            InitializeComponent();
        }
        
        //bool IsShowed;
        
        /// <summary>
        /// Диалог выбора отделов
        /// </summary>
        private DepartmentSelectDialog selDialog;
        public DepartmentSelectDialog SelDialog
        {
            get
            {
                if (selDialog == null)
                    selDialog = new DepartmentSelectDialog();
                return selDialog;
            }
        }
        
        /// <summary>
        /// контекст
        /// </summary>
        private KadrDataDataContext model;
        public KadrDataDataContext Model
        {
            get
            {
                if (model == null)
                {
                    model = new KadrDataDataContext();
                    model.CommandTimeout = 100000;
                }
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

                if (reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult) && (reportSubType == 0))
                {
                    bsReportData.DataSource = Model.GetDepartmentBonusWithSettings(1, dtpPeriodBegin.Value, dtpPeriodEnd.Value, true, 3, (cbParamValue.SelectedItem as WorkType).id);
                }

                if ((reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && (reportSubType == 5))
                {
                    bsReportData.DataSource = Model.GetDepartmentBonusWithSettings(1, dtpPeriodBegin.Value, dtpPeriodEnd.Value, true, 8, (cbParamValue.SelectedItem as Prikaz).id).Where(res => res.TypeWorkName != null).Where(res => res.idBonusType != null);
                }
            }
            else
            {
                
                if ((reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && ((reportSubType == 2) || (reportSubType == 6)))
                {
                    bsReportData.DataSource = Model.GetDepartmentBonusWithSettings(1, dtpPeriodBegin.Value, dtpPeriodEnd.Value, true, 1, -1).Where(bon => bon.idFactStaff != null).Where(bon => bon.MatOtpusk == null).Where(bon => bon.idWorkType !=15).ToArray();
                }
            }

            if ((reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && (reportSubType == 3))
            {
                //reportParams = SelDialog.DepList;
                if ((SelDialog.DepList != null))
                {
                    IEnumerable<GetDepartmentBonusWithSettingsResult> result = null;
                    foreach (int param in SelDialog.DepList)
                    {
                        if (result != null)
                            result = Model.GetDepartmentBonusWithSettings(Convert.ToInt32(param), dtpPeriodBegin.Value, dtpPeriodEnd.Value, false, 2, -1).Union(result);
                        else
                            result = Model.GetDepartmentBonusWithSettings(Convert.ToInt32(param), dtpPeriodBegin.Value, dtpPeriodEnd.Value, false, 2, -1);
                    }
                    bsReportData.DataSource = result;
                }
                else
                    bsReportData.DataSource = null;
            }

            //новый отчет
            if (reportType == typeof(Reports.GetPPSDepartmentBonusForT3Result) && (reportSubType == 1))
            {
                if ((cbParamValue.SelectedItem as FinancingSource).id==0)//без ограничений по ист фин-я
                    bsReportData.DataSource = Model.GetPPSDepartmentBonusForT3(1, dtpPeriodBegin.Value, dtpPeriodEnd.Value,true,7).ToArray();
                else //с ограничениями
                    bsReportData.DataSource = Model.GetPPSDepartmentBonusForT3(1, dtpPeriodBegin.Value, dtpPeriodEnd.Value, true, 7).Where(res => 
                        res.idFinancingSource == (cbParamValue.SelectedItem as FinancingSource).id).ToArray();
            }

            //прежний отчет
            if (reportType == typeof(Reports.GetPPSDepartmentBonusForT3Result) && (reportSubType == 0))
            {
                bsReportData.DataSource = Model.GetPPSDepartmentBonusForT3(1, dtpPeriodBegin.Value, dtpPeriodEnd.Value, true, 4).ToArray();
            }

            if (reportType == typeof(Reports.GetAllPostsResult))
            {
                bsReportData.DataSource = Model.GetAllPosts(1, dtpPeriodBegin.Value, dtpPeriodEnd.Value, true).ToArray();
            }

            this.reportViewer1.RefreshReport();
            
        }


        private System.Type reportType;


        private int reportSubType;


        public void LoadData(System.Type ReportType, int ReportSubType = 0)
        {
            reportType = ReportType;
            reportSubType = ReportSubType;
            dtpPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
            dtpPeriodEnd.Value = DateTime.Today;
            //model = new KadrDataDataContext();
            bsReportData.DataSource = ReportType;
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            if (reportType == typeof(Reports.GetBonusByBonusTypeResult))
            {
                this.Text = "Отчет по виду надбавки";
                tslParamName.Visible = true;
                cbParamValue.Visible = true;
                btnSettings.Visible = false;
                tslParamName.Text = "Вид надбавки";
                reportDataSource1.Name = "dsBonusByBonusType";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.BonusByBonusTypeReport.rdlc";

                bsParameterDataSource.DataSource = typeof(BonusType);
                bsParameterDataSource.DataSource = Model.BonusTypes.OrderBy(bonT => bonT.BonusTypeName);

                //RefreshReport();
           }

            if ((reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && (reportSubType == 5))
            {
                this.Text = "Поиск надбавок по приказу";
                tslParamName.Visible = true;
                cbParamValue.Visible = true;
                btnSettings.Visible = false;
                tslParamName.Text = "Приказ";
                reportDataSource1.Name = "dsBonusByPrikaz";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.BonusByPrikazReport.rdlc";

                bsParameterDataSource.DataSource = typeof(BonusType);
                bsParameterDataSource.DataSource = Model.Prikazs.OrderByDescending(prik => prik.DatePrikaz).ThenBy(prik => prik.PrikazName);

                 //RefreshReport();
            }


            if ((reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && (reportSubType == 3))
           {
               this.Text = "Отчет по надбавкам";
                tslParamName.Visible = false;
                cbParamValue.Visible = false;
                btnSettings.Visible = true;
                reportDataSource1.Name = "dsDepartmentBonus";
                reportDataSource1.Value = this.bsReportData;
                this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
                this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.DepartmentBonusReport.rdlc";
                //btnLoadData_Click(null, null);

                SelDialog.DepsList = Model.Departments.OrderBy(dep
                     => dep.dateExit).ThenBy(dep => dep.DepartmentName);
                if (SetSettings())
                    ShowDialog();
            }

           if ((reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && (reportSubType == 0))
           {
               this.Text = "Фонд по виду работы";
               tslParamName.Visible = true;
               cbParamValue.Visible = true;
               btnSettings.Visible = false;
               tslParamName.Text = "Вид работы";
               reportDataSource1.Name = "dsDepartmentBonusBySettings";
               reportDataSource1.Value = this.bsReportData;
               this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
               this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.BonusByWorkTypeReport.rdlc";

               bsParameterDataSource.DataSource = typeof(WorkType);
               WorkType Vacancy = new WorkType();
               bsParameterDataSource.DataSource = Model.WorkTypes.ToArray().Union(WorkType.Vacancy).OrderBy(wt => wt.TypeWorkName);
               //RefreshReport();
           }

           
           if ((reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && (reportSubType == 2))
           {
               this.Text = "Фонд оплаты труда по категориям с источниками";
               tslParamName.Visible = false;
               cbParamValue.Visible = false;
               btnSettings.Visible = false;
               reportDataSource1.Name = "dsDepBonus";
               reportDataSource1.Value = this.bsReportData;
               this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
               this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.AllBonusReport.rdlc";
               //btnLoadData_Click(null, null);
           }

           if ((reportType == typeof(Reports.GetDepartmentBonusWithSettingsResult)) && (reportSubType == 6))
           {
               this.Text = "Фонд оплаты труда по категориям без источников";
               tslParamName.Visible = false;
               cbParamValue.Visible = false;
               btnSettings.Visible = false;
               reportDataSource1.Name = "dsDepBonus";
               reportDataSource1.Value = this.bsReportData;
               this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
               this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.BonusByCategoryReport.rdlc";
               //btnLoadData_Click(null, null);
           }

           if ((reportType == typeof(Reports.GetPPSDepartmentBonusForT3Result))&& (reportSubType == 0))
           {
               this.Text = "Отчет Т3 по ППС";
               tslParamName.Visible = false;
               cbParamValue.Visible = false;
               btnSettings.Visible = false;
               reportDataSource1.Name = "dsPPSBonusForT3";
               reportDataSource1.Value = this.bsReportData;
               this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
               this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.PPSBonusForT3.rdlc";

               //RefreshReport();
           }

           if ((reportType == typeof(Reports.GetPPSDepartmentBonusForT3Result)) && (reportSubType == 1))
           {
               this.Text = "Отчет Т3 по ППС";
               tslParamName.Visible = true;
               cbParamValue.Visible = true;
               btnSettings.Visible = false;
               tslParamName.Text = "Источник финан-я";
               reportDataSource1.Name = "dsPPSBonusForT3";
               reportDataSource1.Value = this.bsReportData;
               this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
               this.reportViewer1.LocalReport.ReportEmbeddedResource = "ReportsReports..PPSBonusForT3Report.rdlc";

               bsParameterDataSource.DataSource = typeof(FinancingSource);
               bsParameterDataSource.DataSource = Model.FinancingSources.OrderBy(finS => finS.FinancingSourceName);

               //RefreshReport();
           }

           if (reportType == typeof(Reports.GetAllPostsResult)) 
           {
               this.Text = "Отчет сетка окладов";
               tslParamName.Visible = false;
               cbParamValue.Visible = false;
               btnSettings.Visible = false;
               reportDataSource1.Name = "dsAllPosts";
               reportDataSource1.Value = this.bsReportData;
               this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
               this.reportViewer1.LocalReport.ReportEmbeddedResource = "Reports.Reports.AllPostsReport.rdlc";

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

        private bool SetSettings()
        {
            if (SelDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                RefreshReport();
                return true;
            }
            else
                return false;
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            SetSettings();
                
        }

     }
}
