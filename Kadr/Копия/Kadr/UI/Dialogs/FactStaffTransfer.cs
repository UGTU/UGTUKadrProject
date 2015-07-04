using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.Data.Common;
using System.Collections;

namespace Kadr.UI.Dialogs
{
    public partial class FactStaffTransfer : CustomBaseDialog
    {
        //текущий отдел
        private Department currentDepartment;

        public Department Department
        {
            get
            {
                return currentDepartment;
            }
            set
            {
                currentDepartment = value;
                
            }
        }

        //текущая запись штатного расписания
        private PlanStaff currentPlanStaff;

        public PlanStaff CurentPlanStaff
        {
            get
            {
                return currentPlanStaff;
            }
            set
            {
                currentPlanStaff = value;
            }
        }

        //выбранная запись штатного расписания
        public PlanStaff NewPlanStaff
        {
            get
            {
                return cbNewPlanStaff.SelectedValue as PlanStaff;

            }
            //set
            //{

            //}
        
        }

        public bool TransferWithBonus
        {
            get
            {
                return chbWithBonus.Checked;
            }
        }

        //приказ о переводе
        public Prikaz TransferPrikaz
        {
            get
            {
                return cbTransferPrikaz.SelectedValue as Prikaz;
            }
        }

        //дата перевода
        public DateTime TransferData
        {
            get
            {
                return dtTransferDate.Value;
            }
        }

        public FactStaffTransfer()
        {
            InitializeComponent();
        }

        private void planStaffLoad()
        {
            if (currentDepartment == null)
                return;

            IEnumerable<PlanStaff> planStaffs = KadrController.Instance.Model.PlanStaffs.Where(plStaff => (plStaff.Dep.id == currentDepartment.id)
                                            && (plStaff != currentPlanStaff) && (plStaff.Prikaz == null)).OrderByDescending(plStaff => plStaff.Prikaz.DatePrikaz).ToArray();

            ArrayList freePlanStaffs = new ArrayList();

            foreach (PlanStaff planStaff in planStaffs)
            {
                if (planStaff.FreeStaffCount > 0)
                    freePlanStaffs.Add(planStaff);
            }
            planStaffBindingSource.DataSource = freePlanStaffs;
        }

        public void LoadDepartments()
        {
            departmentBindingSource.DataSource = KadrController.Instance.Model.Departments.Where(dep => ((dep.dateExit == null) || (dep.dateExit > DateTime.Today))).OrderBy(dep => dep.DepartmentName).ToArray();
        }

        private void FactStaffTransfer_Load(object sender, EventArgs e)
        {

            chbWithBonus.Checked = true;
            prikazBindingSource.DataSource = KadrController.Instance.Model.Prikazs.OrderByDescending(prik => prik.DatePrikaz).ThenByDescending(prik => prik.PrikazName).ToArray();
            if ((! currentPlanStaff.IsNull()) && (currentDepartment != null))
            {
                
                cbDepartment.SelectedItem = currentDepartment;
               // planStaffLoad();
                //    //устанавливаем значения по умолчанию - c той же должностью
                //cbNewPlanStaff.DataSource = planStaffBindingSource;
                //if ((planStaffBindingSource.DataSource as System.Data.Linq.Table<PlanStaff>).Count()>0)
                //    cbNewPlanStaff.SelectedValue = (planStaffBindingSource.DataSource as System.Data.Linq.Table<PlanStaff>).Where(plStaff => (plStaff.Department == currentDepatment)
                //              && (plStaff != currentPlanStaff) && (plStaff.Prikaz1 == null) && (plStaff.Post == currentPlanStaff.Post)).First();

            }
            //dtTransferDate.Value = 

        }

        private void FactStaffTransfer_Shown(object sender, EventArgs e)
        {
            ApplyButtonVisible = false;

        }

        private void cbDepartment_SelectedValueChanged(object sender, EventArgs e)
        {
            currentDepartment = cbDepartment.SelectedValue as Department;
            planStaffLoad();
        }

    }
}
