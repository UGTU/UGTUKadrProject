using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class PlanStaffSelectDialog : CustomBaseDialog
    {
        public Dep Department
        {
            get;
            set;
        }

        public PlanStaffSelectDialog()
        {
            InitializeComponent();
        }

        public PlanStaff PlanStaff
        {
            get
            {
                return cbPlanStaff.SelectedItem as PlanStaff;
            }
        }

        private void PlanStaffSelectDialog_Load(object sender, EventArgs e)
        {
            if (Department  != null)
                planStaffBindingSource.DataSource = KadrController.Instance.Model.PlanStaffs.Where(plSt => plSt.Dep == Department).OrderBy(plSt => plSt.Post.PostName).ToArray();
        }


    }
}
