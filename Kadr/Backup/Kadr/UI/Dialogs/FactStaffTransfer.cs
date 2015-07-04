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

namespace Kadr.UI.Dialogs
{
    public partial class FactStaffTransfer : CustomBaseDialog
    {
        //текущий отдел
        private Department currentDepatment;

        public Department Department
        {
            get
            {
                return currentDepatment;
            }
            set
            {
                currentDepatment = value;
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

        private void FactStaffTransfer_Load(object sender, EventArgs e)
        {
            prikazBindingSource.DataSource = KadrController.Instance.Model.Prikazs.OrderByDescending(prik => prik.DatePrikaz);
            if ((! currentPlanStaff.IsNull()) && (! currentDepatment.IsNull()))
            {
                planStaffBindingSource.DataSource = KadrController.Instance.Model.PlanStaffs.Where(plStaff => (plStaff.Department == currentDepatment) 
                                            && (plStaff != currentPlanStaff) && (plStaff.Prikaz1 == null)).OrderByDescending(plStaff => plStaff.Prikaz1.DatePrikaz);

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

        }

    }
}
