using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Command
{
    class CreatePlanStaffCommand: UIX.Commands.ICommand
    {
        public CreatePlanStaffCommand(Kadr.Data.Dep department) 
        {
            this.department = department;
        }
        #region ICommand Members

        private Kadr.Data.PlanStaff planStaff;

        public Kadr.Data.PlanStaff PlanStaff
        {
            get { return planStaff; }            
        }

        private Kadr.Data.Dep department;

        public Kadr.Data.Dep Department
        {
            get { return department; }
            set { department = value; }
        }

        public void Execute(object sender)
        {
            planStaff = new Kadr.Data.PlanStaff();
            planStaff.Dep = department;
            Kadr.Controllers.KadrController.Instance.Model.SubmitChanges();
        }

        public void Unexecute(object sender)
        {
            if (planStaff != null)
            {
                Kadr.Controllers.KadrController.Instance.Model.PlanStaffs.DeleteOnSubmit(planStaff);
                Kadr.Controllers.KadrController.Instance.Model.SubmitChanges();
            }
        }

        public bool IsOneWayCommand(object sender)
        {
            return false;
        }

        #endregion
    }
}
