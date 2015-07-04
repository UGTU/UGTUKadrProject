using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.UI.Forms
{
    public partial class PlanStaffHistoryForm : Form
    {
        private PlanStaff planStaff;
        public PlanStaff PlanStaff
        {
            get
            {
                return planStaff;
            }
            set
            {
                planStaff = value;
            }
        }
        
        public PlanStaffHistoryForm()
        {
            InitializeComponent();
        }

        private void PlanStaffHistoryForm_Load(object sender, EventArgs e)
        {
            if (PlanStaff != null)
            {
                Text = "История " + PlanStaff.ToString();
                planStaffHistoryBindingSource.DataSource = 
                    Kadr.Controllers.KadrController.Instance.Model.PlanStaffHistories.Where(hist => 
                        hist.PlanStaff == PlanStaff).OrderByDescending(hist => hist.DateBegin);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void EditPStChangeBtn_Click(object sender, EventArgs e)
        {
            if (PlanStaff != null)
            {
                PlanStaffHistory CurrentChange = planStaffHistoryBindingSource.Current as PlanStaffHistory;
                if (CurrentChange == null)
                {
                    MessageBox.Show("Не выбрано редактируемое изменение.", "АИС \"Штатное расписание\"");
                    return;
                }
                LinqActionsController<PlanStaffHistory>.Instance.EditObject(CurrentChange, true);
            }
        }

        private void DelPStChangeBtn_Click(object sender, EventArgs e)
        {
            PlanStaffHistory CurrentChange = planStaffHistoryBindingSource.Current as PlanStaffHistory;
            if (CurrentChange == null)
            {
                MessageBox.Show("Не выбрано удаляемое изменение.", "АИС \"Штатное расписание\"");
                return;
            }
            if (MessageBox.Show("Удалить изменение?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
            {
                LinqActionsController<PlanStaffHistory>.Instance.DeleteObject(planStaffHistoryBindingSource.Current as PlanStaffHistory,
                     KadrController.Instance.Model.PlanStaffHistories, planStaffHistoryBindingSource);

            }
        }

        

        


     }
}
