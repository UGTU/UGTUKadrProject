using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reports.Forms
{
    public partial class BaseReportFormWithYear : Form
    {
        public BaseReportFormWithYear()
        {
            InitializeComponent();
        }

        private void BaseReportFormWithYear_Load(object sender, EventArgs e)
        {
            cbYear.DataSource = Model.TimeSheets.Select(ts => ts.TimeSheetYear).Distinct().OrderByDescending(ts => ts as int?).ToArray();
            cbYear.SelectedItem = DateTime.Today.Year;
            if ((cbYear.SelectedItem == null) && (cbYear.Items.Count > 0))
               cbYear.SelectedItem = cbYear.Items[0];
            Text = "Численность по ЦЗФ";
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

            //GetFundingDepAverageNumEmplResultBindingSource.DataSource = Model.GetFundingDepAverageNumEmpl(Convert.ToInt32(cbYear.SelectedValue), 0).ToArray();
            reportViewer1.RefreshReport();

        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnLoadData_Click(object sender, EventArgs e)
        {
            RefreshReport();
        }

    }
}
