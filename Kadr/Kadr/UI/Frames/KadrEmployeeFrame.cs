using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Windows.Forms;
using Kadr.KadrTreeView;
using Kadr.Controllers;
using Kadr.Data;
using UIX.Commands;
using Kadr.Data.Common;
using Reports.Frames;
using Kadr.UI.Editors;
using Kadr.UI.Dialogs;

namespace Kadr.UI.Frames
{
    public partial class KadrEmployeeFrame : Kadr.UI.Frames.KadrBaseFrame
    {
        

        #region Properties

        /// <summary>
        /// Текущая должность (фактическое штатное) сотрудника
        /// </summary>
        /*public FactStaff FactStaff
        {
            get
            {
                if (this.FrameNodeObject != null)
                    return (this.FrameNodeObject as KadrEmployeeObject).FactStaff;
                else
                    return null;
            }
        }*/


        /// <summary>
        /// Отображаемый сотрудник
        /// </summary>
        public Kadr.Data.Employee Employee
        {
            get
            {
                if (this.FrameNodeObject != null)
                    if ((this.FrameNodeObject as KadrEmployeeObject).Employee != null)
                    {
                        // было так:
                        //return (this.FrameNodeObject as KadrEmployeeObject).Employee;
                        return KadrController.Instance.Model.Employees.SingleOrDefault(x=> (this.FrameNodeObject as KadrEmployeeObject).Employee.id == x.id);
                    }
                        
                return NullEmployee.Instance;
            }
        }


        /// <summary>
        /// Отображаемый сотрудник отдела - FactStaff
        /// </summary>
        public Kadr.Data.FactStaff FactStaff
        {
            get
            {
                if (this.FrameNodeObject != null)
                    if ((this.FrameNodeObject as KadrEmployeeObject).Employee != null)
                    {
                        //return (this.FrameNodeObject as KadrEmployeeObject).FactStaff;
                        return KadrController.Instance.Model.FactStaffs.SingleOrDefault(x => (this.FrameNodeObject as KadrEmployeeObject).FactStaff.id == x.id);

                    }
                return NullFactStaff.Instance;
            }
        }

        private UIX.Commands.ICommandManager commandManager;



        #endregion
   
        #region LoadData

        private void LoadPostList()
        {
            factStaffBindingSource.DataSource = KadrController.Instance.Model.FactStaffs.Where(factSt => factSt.Employee == Employee).ToArray().OrderByDescending(factSt => factSt.LastChange.DateBegin).ToArray();//.OfType<UIX.Views.IDecorable>().ToArray();
        }

        private void LoadBonus()
        {
            tsbBonusFilter_DropDownItemClicked(null, null);
        }

        private void LoadBonus(ArrayList BonusFilters)
        {
            //фильтруем элементы
            ArrayList bon = new ArrayList();
            IEnumerable<Bonus> bonus = BonusController.Instance.GetAllEmployeeBonus((this.FrameNodeObject as KadrEmployeeObject).Employee);
            foreach (Bonus bn in bonus)
            {
                if (BonusFilters.Contains((bn as IObjectState).State()))
                {
                    if (bn.BonusPlanStaff != null)
                    {

                        foreach (FactStaff fcSt in (bn.BonusPlanStaff.PlanStaff.FactStaffs.Where(fcSt
                                => fcSt.Employee == (this.FrameNodeObject as KadrEmployeeObject).Employee)))
                            if (BonusFilters.Contains((fcSt as IObjectState).State()))
                            {
                                bon.Add(bn);
                                break;
                            }
                    }
                    else
                    {
                        if (bn.BonusPost != null)
                        {
                            foreach (FactStaff fcSt in bn.BonusPost.Post.PlanStaffs.SelectMany(plSt =>
                                plSt.FactStaffs).Where(fcSt => fcSt.Employee == (this.FrameNodeObject as KadrEmployeeObject).Employee))
                                if (BonusFilters.Contains((fcSt as IObjectState).State()))
                                {
                                    bon.Add(bn);
                                    break;
                                }
                        }
                        else
                            bon.Add(bn);
                    }
                }
 
            }

            AllbonusBindingSource.DataSource = bon;
           
            
            //bonusBindingSource.DataSource = BonusController.Instance.GetBonus((this.FrameNodeObject as KadrEmployeeObject).Employee);
            //AllbonusBindingSource.DataSource = BonusController.Instance.GetAllEmployeeBonus((this.FrameNodeObject as KadrEmployeeObject).Employee);
                //KadrController.Instance.Model.Bonus.Where(bonus => bonus.FactStaff.Employee == Employee);
        }

        private void LoadEmployee()
        {          
            
            cpgEmployee.SelectedObjects = new object[] { Employee.GetDecorator() };
            commandManager = new UIX.Commands.CommandManager();
            cpgEmployee.CommandRegister = commandManager.GetCommandRegister();
            commandManager.BeginBatchCommand();
        }

        private void LoadEducation()
        {
            CRUDEmployeeRank.Read(Employee,employeeRankBindingSource);
            CRUDEmployeeDegree.Read(Employee, employeeDegreeBindingSource);
            CRUDEducation.Read(Employee, EducationBindingSource);
            CRUDLanguage.Read(Employee, employeeLangDecoratorBindingSource);
            CRUDDopEducation.Read(Employee, DopEducationBindingSource);
        }

        private void LoadContactData()
        {
            CRUDPhone.Read(Employee, oKphoneBindingSource);
            CRUDAddress.Read(Employee, oKAdressBindingSource);
        }


        #endregion

        public KadrEmployeeFrame()
        {
            InitializeComponent();
        }

        public KadrEmployeeFrame(object AObject)
        {
            InitializeComponent();
            FrameObject = AObject;
        }

        protected override void DoRefreshFrame()
        {
            tcEmployee_SelectedIndexChanged(null,null);
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (commandManager.IsInBatchMode)
            {
                commandManager.EndBatchCommand();
            }
            KadrController.Instance.SubmitChanges();
            commandManager.BeginBatchCommand();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (commandManager != null)
            {
                if (commandManager.IsInBatchMode)
                {
                    commandManager.TerminateBatchCommand();
                }
            }
            commandManager.BeginBatchCommand();
            cpgEmployee.SelectedObjects = new object[] { Employee.GetDecorator() };
        }

        public void RefreshBonusFilter()
        {
            tsbBonusFilter_DropDownItemClicked(this, null);
        }

        private void tsbBonusFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            LoadBonus(ObjectStateController.Instance.GetObjectStatesForFilter(tsbBonusFilter, e));
        }

        private void KadrEmployeeFrame_Load(object sender, EventArgs e)
        {
            tcEmployee.TabPages.Remove(tpBonus);
            tcEmployee.TabPages.Remove(tpEmplBonusReport);
            
            dtpBonRepPeriodBegin.Value = DateTime.Today.AddDays(-DateTime.Today.Day + 1);
            dtpBonRepPeriodEnd.Value = DateTime.Today;

            employeeBonusReportFrame1.InitializeReport(typeof(Reports.GetEmployeesSumResult), 0);
        }

        private void btnBonusRepLoad_Click(object sender, EventArgs e)
        {
            employeeBonusReportFrame1.UpdateReportParams(dtpBonRepPeriodBegin.Value, dtpBonRepPeriodEnd.Value, Employee.id, false);
        }

 

        private void dgvAllBonus_RowPrePaint(object sender, DataGridViewRowPrePaintEventArgs e)
        {
            if ((dgvAllBonus.Rows[e.RowIndex].DataBoundItem as Bonus).HasHistoryChanges)
            {
                dgvAllBonus.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Bisque;
            }
            else
            {
                dgvAllBonus.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
            }
        }


        private void tcEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (tcEmployee.SelectedTab == tpBonus)
                LoadBonus();*/

            if (tcEmployee.SelectedTab == tpEducation)
            {
                LoadEducation();
            }   

            if (tcEmployee.SelectedTab == tpEmpPost)
                tcEmplWorkData_SelectedIndexChanged(null, null);

            if (tcEmployee.SelectedTab == tpEmployee)
                LoadEmployee();

            if (tcEmployee.SelectedTab == tpDopInf)
                CRUDDopInfo.Read(Employee, oKDopInfBindingSource);

        }

        private void tsbBonusHistory_Click(object sender, EventArgs e)
        {
            var currentBonus = AllbonusBindingSource.Current as Bonus;
            if (currentBonus == null)
            {
                MessageBox.Show("Не выбрана надбавка для просмотра истории.", "АИС \"Штатное расписание\"");
                return;
            }

            using (Forms.BonusHistoryForm histForm =
                           new Forms.BonusHistoryForm())
            {
                histForm.Bonus = currentBonus;
                histForm.ShowDialog();
            }
        }

        private void dgvAllBonus_DoubleClick(object sender, EventArgs e)
        {
            tsbBonusHistory_Click(null, null);
        }

        private void tcEmplWorkData_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcEmplWorkData.SelectedTab == tpEmplStading)
                CRUDStanding.Read(Employee, employeeStandingBindingSource);
            if (tcEmplWorkData.SelectedTab == tpUGTUPosts)
                LoadPostList();
            if (tcEmplWorkData.SelectedTab == tpIncapacities)
                CRUDIncapacity.Read(Employee, inkapacityDecoratorBindingSource);
        }

        private void tsbSocialFareTransit_Click(object sender, EventArgs e)
        {
            using (Forms.SocialFareTransitForm dlg = new Forms.SocialFareTransitForm())
            {
                dlg.Employee = Employee;
                dlg.ShowDialog();
            }
        }

        private void tcEmplPostInf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcEmplPostInf.SelectedTab == tpEmpOtpusk)
                CRUDVacation.Read(FactStaff.CurrentChange, Employee, oKOtpuskBindingSource);

            if (tcEmplPostInf.SelectedTab == tpBusTrip)
                CRUDBusinessTrips.Read((FactStaff)factStaffBindingSource.Current, BusinessTripsBindingSource);

            if (tcEmplPostInf.SelectedTab == tpMaterial)
                CRUDMaterial.Read((FactStaff)factStaffBindingSource.Current, MaterialResponsibilityBindingSource);

            if (tcEmplPostInf.SelectedTab == tpValidations)
                CRUDValidation.Read((FactStaff)factStaffBindingSource.Current, validationDecoratorBindingSource);
        }


        private void tcEmplData_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (tcEmplData.SelectedTab == tpPersonData)
                LoadStandings();*/

            if (tcEmplData.SelectedTab == tpContData)
                LoadContactData();

            if (tcEmplData.SelectedTab == tpFamily)
                CRUDMembFam.Read(Employee, oKFamBindingSource);

            if (tcEmplData.SelectedTab == tpAwards)
                CRUDAward.Read(Employee, awardDecoratorBindingSource);

            if (tcEmplData.SelectedTab == tpSocial)
                CRUDSocial.Read(Employee, socialDecoratorBindingSource);
        }

        private void EditDegreeBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeDegree.Update(employeeDegreeBindingSource);

        }

        private void AddDegreeBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeDegree.Create(Employee, this, employeeDegreeBindingSource);

        }

        private void DelDegreeBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeDegree.Delete(employeeDegreeBindingSource);
        }

        private void AddRankBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeRank.Create(Employee, this, employeeRankBindingSource);
        }

        private void EditRankBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeRank.Update(employeeRankBindingSource);
        }

        private void DelRankBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeRank.Delete(Employee, employeeRankBindingSource);
        }

        private void tsbAddEmplStanding_Click(object sender, EventArgs e)
        {
            CRUDStanding.Create(Employee,employeeStandingBindingSource,this);
        }

        private void tsbEditEmplStanding_Click(object sender, EventArgs e)
        {
           CRUDStanding.Update(Employee,employeeStandingBindingSource);
        }

        private void tsbDelEmplStanding_Click(object sender, EventArgs e)
        {
            CRUDStanding.Delete(Employee, employeeStandingBindingSource);
        }

        private void factStaffBindingSource_PositionChanged(object sender, EventArgs e)
        {
            tcEmplPostInf_SelectedIndexChanged(null, null);
        }

        private void tsbAddOtp_Click(object sender, EventArgs e)
        {
            CRUDVacation.Create((FactStaff)factStaffBindingSource.Current, Employee, oKOtpuskBindingSource, this);
        }


        private void tsbEditOtp_Click(object sender, EventArgs e)
        {
            CRUDVacation.Update((FactStaff)factStaffBindingSource.Current, Employee, oKOtpuskBindingSource);
        }

                private void tsbDelOtp_Click(object sender, EventArgs e)
        {
            CRUDVacation.Delete((FactStaff)factStaffBindingSource.Current, Employee, oKOtpuskBindingSource);
        }


        private void tsbAddEmplTrip_Click(object sender, EventArgs e)
        {
            CRUDBusinessTrips.Create((FactStaff)factStaffBindingSource.Current, BusinessTripsBindingSource, this);
        }

        private void tsbDelEmplTrip_Click(object sender, EventArgs e)
        {
            CRUDBusinessTrips.Delete((FactStaff)factStaffBindingSource.Current, BusinessTripsBindingSource);
        }

        private void tsbEditEmplTrip_Click(object sender, EventArgs e)
        {
            CRUDBusinessTrips.Update((FactStaff)factStaffBindingSource.Current, BusinessTripsBindingSource);
        }

        private void dgvTrips_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbEditEmplTrip_Click(sender, null);
        }


        private void tsbChangeRegionDates_Click(object sender, EventArgs e)
        {
            if (BusinessTripsBindingSource.Current != null)
            {
                CRUDBusinessRegionType.Update((BusinessTripsBindingSource.Current as BusinessTripDecorator).GetTrip());
                CRUDBusinessTrips.Read((FactStaff)factStaffBindingSource.Current, BusinessTripsBindingSource);
            }
        }

        private void tsbAddMaterial_Click(object sender, EventArgs e)
        {
            CRUDMaterial.Create((FactStaff)factStaffBindingSource.Current, MaterialResponsibilityBindingSource, this);
        }

        private void tsbDelMaterial_Click(object sender, EventArgs e)
        {
            CRUDMaterial.Delete((FactStaff)factStaffBindingSource.Current, MaterialResponsibilityBindingSource);
        }

        private void tsbEditMaterial_Click(object sender, EventArgs e)
        {
            CRUDMaterial.Update((FactStaff)factStaffBindingSource.Current, MaterialResponsibilityBindingSource, sender);
        }


        private void tsbAddPhone_Click(object sender, EventArgs e)
        {
            CRUDPhone.Create(Employee, oKphoneBindingSource, this);
        }

        private void tsbEditPhone_Click(object sender, EventArgs e)
        {
            CRUDPhone.Update(Employee, oKphoneBindingSource);
        }

        private void tsbDelPhone_Click(object sender, EventArgs e)
        {
            CRUDPhone.Delete(Employee, oKphoneBindingSource);
        }

        private void tsbAddAddress_Click(object sender, EventArgs e)
        {
            CRUDAddress.Create(Employee, oKAdressBindingSource, this);
        }

        private void tsbUpdAddress_Click(object sender, EventArgs e)
        {
            CRUDAddress.Update(Employee, oKAdressBindingSource);
        }

        private void tsbDelAddress_Click(object sender, EventArgs e)
        {
            CRUDAddress.Delete(Employee, oKAdressBindingSource);
        }

        private void tsbAddFamMember_Click(object sender, EventArgs e)
        {
            CRUDMembFam.Create(Employee, oKFamBindingSource, this);
        }

        private void tsbEditFamMember_Click(object sender, EventArgs e)
        {
            CRUDMembFam.Update(Employee, oKFamBindingSource);
        }

        private void tsbDelFamMember_Click(object sender, EventArgs e)
        {
            CRUDMembFam.Delete(Employee, oKFamBindingSource);
        }

        private void tsbAddDopInf_Click(object sender, EventArgs e)
        {
            CRUDDopInfo.Create(Employee, oKDopInfBindingSource, this);
        }

        private void tsbEditDopInf_Click(object sender, EventArgs e)
        {
            CRUDDopInfo.Update(Employee, oKDopInfBindingSource);
        }

        private void tsbDelDopInf_Click(object sender, EventArgs e)
        {
            CRUDDopInfo.Delete(Employee, oKDopInfBindingSource);
        }

        private void tsbAddIncapacity_Click(object sender, EventArgs e)
        {
            CRUDIncapacity.Create(Employee, inkapacityDecoratorBindingSource, this);
        }


        private void tsbEditIncapacity_Click(object sender, EventArgs e)
        {
            CRUDIncapacity.Update(Employee, inkapacityDecoratorBindingSource);
        }

        private void tsbDeleteIncapacity_Click(object sender, EventArgs e)
        {
            CRUDIncapacity.Delete(Employee, inkapacityDecoratorBindingSource);
        }


        private void dgvIncapacities_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbEditIncapacity_Click(sender, null);
        }

        private void tsbAddAward_Click(object sender, EventArgs e)
        {
            CRUDAward.Create(Employee, awardDecoratorBindingSource, this);
        }

        private void tsbEditAward_Click(object sender, EventArgs e)
        {
            CRUDAward.Update(Employee, awardDecoratorBindingSource);
        }

        private void tsbDelAward_Click(object sender, EventArgs e)
        {
            CRUDAward.Delete(Employee, awardDecoratorBindingSource);
        }

        private void dgvAwards_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbEditAward_Click(this, null);
        }


        private void tsbAddSocial_Click(object sender, EventArgs e)
        {
            CRUDSocial.Create(Employee, socialDecoratorBindingSource, this);
        }

        private void tsbEditSocial_Click(object sender, EventArgs e)
        {
            CRUDSocial.Update(Employee, socialDecoratorBindingSource);
        }


        private void tsbDelSocial_Click(object sender, EventArgs e)
        {
            CRUDSocial.Delete(Employee, socialDecoratorBindingSource);
        }

        private void dgvSocials_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbEditSocial_Click(this,null);
        }

        private void tsbAddValidation_Click(object sender, EventArgs e)
        {
            CRUDValidation.Create((FactStaff)factStaffBindingSource.Current,validationDecoratorBindingSource,this); 
        }

        private void tsbEditValidation_Click(object sender, EventArgs e)
        {
            CRUDValidation.Update((FactStaff)factStaffBindingSource.Current, validationDecoratorBindingSource);
        }

        private void tsbDelValidation_Click(object sender, EventArgs e)
        {
            CRUDValidation.Delete((FactStaff)factStaffBindingSource.Current, validationDecoratorBindingSource);
        }

        private void dgvValidations_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbEditValidation_Click(this, null);
        }

        private void tsbAddLanguage_Click(object sender, EventArgs e)
        {
            CRUDLanguage.Create(Employee, employeeLangDecoratorBindingSource, this);
        }

        private void tsbEditLanguage_Click(object sender, EventArgs e)
        {
            CRUDLanguage.Update(Employee, employeeLangDecoratorBindingSource);
        }

        private void tsbDeleteLanguage_Click(object sender, EventArgs e)
        {
            CRUDLanguage.Delete(Employee, employeeLangDecoratorBindingSource);
        }

        private void AddEducationBtn_Click(object sender, EventArgs e)
        {
            CRUDEducation.Create(Employee, EducationBindingSource,this);
        }

        private void EditEducationBtn_Click(object sender, EventArgs e)
        {
            CRUDEducation.Update(Employee, EducationBindingSource);
        }

        private void DeleteEducationBtn_Click(object sender, EventArgs e)
        {
            CRUDEducation.Delete(Employee, EducationBindingSource);
        }

        private void AddDopEducBtn_Click(object sender, EventArgs e)
        {
            CRUDDopEducation.Create(Employee, FactStaff, DopEducationBindingSource, this);
        }

        private void EditDopEducBtn_Click(object sender, EventArgs e)
        {
            CRUDDopEducation.Update(Employee, FactStaff, DopEducationBindingSource, this);
        }

        private void DeleteDopEducBtn_Click(object sender, EventArgs e)
        {
            CRUDDopEducation.Delete(Employee, DopEducationBindingSource);
        }

        private void dgvTrips_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
           for (int i = e.RowIndex; i < e.RowIndex+e.RowCount; i++)
                dgvTrips.Rows[i].Cells["RegionDatesChanged"].Value = (BusinessTripsBindingSource[i] as BusinessTripDecorator).IsRegionDatesChanged; 


        }

        private void tsbCancelTrip_Click(object sender, EventArgs e)
        {
            CRUDBusinessTrips.CancelTrip((FactStaff)factStaffBindingSource.Current, BusinessTripsBindingSource); 
        }

        private void tsbChangeTripDates_Click(object sender, EventArgs e)
        {
            CRUDBusinessTrips.TripChangeDates((FactStaff)factStaffBindingSource.Current, BusinessTripsBindingSource);
        }
    }

}
