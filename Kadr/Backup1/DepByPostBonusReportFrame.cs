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
    public partial class DepByPostBonusReportFrame : DepAverageStaffBaseFrame
    {
        public DepByPostBonusReportFrame()
        {
            InitializeComponent();
        }

        protected override void LoadData()
        {
            GetDepartmentBonusForT3ResultBindingSource.DataSource = Model.GetDepartmentBonusForT3(ReportParam, PeriodBegin, PeriodEnd, WithSubReports,4).ToArray();

        }

    }
}
