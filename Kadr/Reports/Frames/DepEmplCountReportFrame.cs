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
    public partial class DepEmplCountReportFrame : ReportBaseFrame
    {
        
        public DepEmplCountReportFrame()
        {
            InitializeComponent();
        }


        protected override void LoadData()
        {
            
            if ((ReportParam != null) )
                GetDepartmentStaffCountsResultBindingSource.DataSource = Model.GetDepartmentStaffCounts(ReportParam, dtpReportDate.Value, dtpReportDate.Value).ToArray();
            else
                GetDepartmentStaffCountsResultBindingSource.DataSource = null;
        }

        private void btnLoadReport_Click(object sender, EventArgs e)
        {
            //DoRefreshReport();
            RefreshReport();
        }


    }
}
