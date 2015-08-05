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

namespace Kadr.UI.Frames
{
    public partial class KadrEmployeeFrame : Kadr.UI.Frames.KadrBaseFrame
    {
        private TabControl tcEmployee;
        private TabPage tpEmployee;
        private TabPage tpEmpPost;
        private TabPage tpBonus;
        private BindingSource factStaffBindingSource;
        private IContainer components;
        private BindingSource AllbonusBindingSource;
        private TabPage tpEducation;
        private SplitContainer splitContainer2;
        private GroupBox groupBox4;
        private GroupBox groupBox5;
        private TableLayoutPanel tableLayoutPanel4;
        private DataGridView dataGridView3;
        private ToolStrip toolStrip1;
        private ToolStripButton AddRankBtn;
        private ToolStripButton EditRankBtn;
        private ToolStripButton DelRankBtn;
        private TableLayoutPanel tableLayoutPanel1;
        private ToolStrip toolStrip3;
        private TableLayoutPanel tableLayoutPanel3;
        private DataGridView dataGridView2;
        private ToolStrip toolStrip4;
        private ToolStripButton AddDegreeBtn;
        private ToolStripButton EditDegreeBtn;
        private ToolStripButton DelDegreeBtn;
        private DataGridView dgvAllBonus;
        private Button btnCancel;
        private Button btnOk;
        private BindingSource employeeDegreeBindingSource;
        private DataGridViewTextBoxColumn rankDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn educDocumentDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn rankWhereDataGridViewTextBoxColumn;
        private BindingSource employeeRankBindingSource;
        public ToolStripSplitButton tsbBonusFilter;
        private ToolStripMenuItem текущиеToolStripMenuItem;
        private ToolStripMenuItem отмененныеToolStripMenuItem;
        private DataGridViewTextBoxColumn staffCountDataGridViewTextBoxColumn;
        private TabPage tpEmplBonusReport;
        private Button btnBonusRepLoad;
        private DateTimePicker dtpBonRepPeriodEnd;
        private Label label1;
        private DateTimePicker dtpBonRepPeriodBegin;
        private ToolStrip toolStrip6;
        private ToolStripLabel toolStripLabel2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private ToolStripSeparator toolStripSeparator3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private BindingSource oKOtpuskBindingSource;
        private TableLayoutPanel tableLayoutPanel5;
        private Panel panel1;
        private TableLayoutPanel tableLayoutPanel6;
        private DataGridViewTextBoxColumn degreeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn scienceTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn educDocumentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dissertCouncilDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn degreeDateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn diplWhereDataGridViewTextBoxColumn;
        private ToolStripButton tsbBonusHistory;
        private ReportBaseFrameForPeriod employeeBonusReportFrame1;
        private DataGridViewTextBoxColumn BonusLevel;
        private DataGridViewTextBoxColumn BonusPost;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn BnLastFinancingSource;
        private DataGridViewTextBoxColumn AllBonusCount;
        private DataGridViewTextBoxColumn AllDateBegin;
        private DataGridViewTextBoxColumn PrikazBegin;
        private DataGridViewTextBoxColumn IntermediateDateEnd0;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private TabControl tcEmplData;
        private TabPage tpPersonData;
        private TabPage tpFamily;
        private BindingSource employeeStandingBindingSource;
        private TabPage tpContData;
        private BindingSource bonusReportColumnBindingSource;
        private BindingSource bonusTypeBindingSource;
        private BindingSource BusinessTripsBindingSource;
        private DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn1;
        private TabControl tcEmplWorkData;
        private TabPage tpUGTUPosts;
        private SplitContainer splitContainer1;
        private DataGridView dgvEmplPosts;
        private DataGridViewTextBoxColumn Department;
        private DataGridViewTextBoxColumn Post;
        private DataGridViewTextBoxColumn WorkType;
        private DataGridViewTextBoxColumn HourCount;
        private DataGridViewTextBoxColumn FinancingSource;
        private DataGridViewTextBoxColumn PKCategory;
        private DataGridViewTextBoxColumn Category;
        private DataGridViewTextBoxColumn SalarySize;
        private DataGridViewTextBoxColumn StaffCount;
        private DataGridViewTextBoxColumn FStDateBegin;
        private DataGridViewTextBoxColumn FStPrikazBegin;
        private DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn Prikaz;
        private TabControl tcEmplPostInf;
        private TabPage tpEmpOtpusk;
        private TableLayoutPanel tableLayoutPanel7;
        private DataGridView dataGridView5;
        private ToolStrip toolStrip5;
        private ToolStripButton tsbAddOtp;
        private ToolStripButton tsbEditOtp;
        private ToolStripButton tsbDelOtp;
        private TabPage tpBusTrip;
        private DataGridView dgvTrips;
        private ToolStrip tsBusinessTrips;
        private ToolStripButton tsbAddEmplTrip;
        private ToolStripButton tsbEditEmplTrip;
        private ToolStripButton tsbDelEmplTrip;
        private TabPage tpEmplStading;
        private TableLayoutPanel tableLayoutPanel2;
        private DataGridView dataGridView4;
        private DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn regionTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn standingTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn workPlaceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn postDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn idRegionTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idStandingTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEmployeeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private ToolStrip toolStrip2;
        private ToolStripButton tsbAddEmplStanding;
        private ToolStripButton tsbEditEmplStanding;
        private ToolStripButton tsbDelEmplStanding;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private TabPage tpMaterial;
        private ToolStrip tsMaterialResp;
        private ToolStripButton tsbAddMaterial;
        private ToolStripButton tsbEditMaterial;
        private ToolStripButton tsbDelMaterial;
        private DataGridView dgvMaterial;
        private BindingSource MaterialResponsibilitybindingSource;
        private DataGridViewTextBoxColumn prikazDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn targetPlaceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn finSourceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn21;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn22;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn23;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn24;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn28;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn29;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn30;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn31;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn32;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn33;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn34;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn35;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn36;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn37;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn38;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn39;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn40;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn41;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn42;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn43;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn44;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn45;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn46;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn47;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn48;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn49;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn50;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn51;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn52;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn53;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn54;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn55;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn56;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn57;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn58;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn59;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn60;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn61;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn62;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn63;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn64;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn65;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn66;
        private DataGridViewTextBoxColumn ContractName;
        private DataGridViewTextBoxColumn DateContract;
        private DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn DateBegin;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripButton tsbSocialFareTransit;
        private SplitContainer splitContainer3;
        private TableLayoutPanel tableLayoutPanel8;
        private DataGridView dataGridView1;
        private ToolStrip toolStrip7;
        private ToolStripButton tsbAddPhone;
        private ToolStripButton tsbEditPhone;
        private ToolStripButton tsbDelPhone;
        private TableLayoutPanel tableLayoutPanel9;
        private DataGridView dataGridView6;
        private ToolStrip toolStrip8;
        private ToolStripButton tsbAddAddress;
        private ToolStripButton tsbUpdAddress;
        private ToolStripButton tsbDelAddress;
        private DataGridViewTextBoxColumn idphoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEmployeeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn1;
        private BindingSource oKphoneBindingSource;
        private BindingSource oKAdressBindingSource;
        private UIX.UI.CommandPropertyGrid cpgEmployee;
        private BindingSource materialResponsibilityDecoratorBindingSource;
        private DataGridViewTextBoxColumn colPrikazMaterial;
        private DataGridViewTextBoxColumn colNumContractMaterial;
        private DataGridViewTextBoxColumn colDateContractMaterial;
        private DataGridViewTextBoxColumn colSumMaterial;
        private DataGridViewTextBoxColumn colDataBeginMaterial;
        private DataGridViewTextBoxColumn colDateEndMaterial;
        private ToolStripButton tsbChangeRegionDates;
        private TabControl tcEducation;
        private TabPage tpPostGradEduc;
        private TabPage tpGrandEducation;
        private TableLayoutPanel tableLayoutPanel10;
        private DataGridView dataGridView7;
        private ToolStrip toolStrip9;
        private ToolStripButton tsbAddFamMember;
        private ToolStripButton tsbEditFamMember;
        private ToolStripButton tsbDelFamMember;
        private BindingSource oKFamBindingSource;
        private DataGridViewTextBoxColumn idfamDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idmembfamDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idemployeeDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn oKMembFamDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn fiomembfamDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn godbirthDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn3;
        private TabPage tpDopInf;
        private TableLayoutPanel tableLayoutPanel11;
        private DataGridView dataGridView8;
        private ToolStrip toolStrip10;
        private ToolStripButton tsbAddDopInf;
        private ToolStripButton tsbEditDopInf;
        private ToolStripButton tsbDelDopInf;
        private BindingSource oKDopInfBindingSource;
        private DataGridViewTextBoxColumn idDopInfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEmployeeDataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dopInfDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn idAdressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEmployeeDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn adressDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateRegDataGridViewTextBoxColumn;
        private DataGridViewCheckBoxColumn regBitDataGridViewCheckBoxColumn;
        private DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn DateEnd;
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel12;
        private DataGridView dataGridView9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn73;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn74;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn75;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn76;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn77;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn78;
        private ToolStrip toolStrip11;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private DataGridView dgvEducation;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn67;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn68;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn69;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn70;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn71;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn72;
        private TabPage tpIncapacities;
        private DataGridView dgvIncapacities;
        private BindingSource inkapacityDecoratorBindingSource;
        private ToolStrip toolStrip12;
        private ToolStripButton tsbAddIncapacity;
        private ToolStripButton tsbEditIncapacity;
        private ToolStripButton tsbDeleteIncapacity;
        private DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private TabPage tpAwards;
        private DataGridView dgvAwards;
        private ToolStrip toolStrip13;
        private ToolStripButton tsbAddAward;
        private ToolStripButton tsbEditAward;
        private ToolStripButton tsbDelAward;
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
                        return (this.FrameNodeObject as KadrEmployeeObject).Employee;
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
                        return (this.FrameNodeObject as KadrEmployeeObject).FactStaff;
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
            employeeDegreeBindingSource.DataSource = KadrController.Instance.Model.EmployeeDegrees.Where(empDegr => empDegr.Employee == Employee);
            employeeRankBindingSource.DataSource = KadrController.Instance.Model.EmployeeRanks.Where(empRank => empRank.Employee == Employee);
        }

        private void LoadOtpusk()
        {
            //IEnumerable<OK_Otpusk>
            if (factStaffBindingSource.Current != null )
                oKOtpuskBindingSource.DataSource =
               KadrController.Instance.Model.OK_Otpusks.Where(otp => otp.FactStaffPrikaz.FactStaff == (factStaffBindingSource.Current as FactStaff)).Where(
                    otp => otp.FactStaffPrikaz.DateBegin >= DateTime.Today.AddYears(-2)).OrderByDescending(otp => otp.FactStaffPrikaz.DateBegin);
            else
                oKOtpuskBindingSource.DataSource =
                    KadrController.Instance.Model.OK_Otpusks.Where(otp => otp.FactStaffPrikaz.FactStaff.Employee == Employee).Where(
                    otp => otp.FactStaffPrikaz.DateBegin >= DateTime.Today.AddYears(-2)).OrderByDescending(otp => otp.FactStaffPrikaz.DateBegin);

            //foreach ()
            /* KadrController.Instance.Model.OK_Otpusks.Where(otp => otp.FactStaff.Employee == Employee).Where(
                    otp => otp.DateBegin >= DateTime.Today.AddYears(-2)).OrderByDescending(otp => otp.DateBegin);*/
        }

        private void LoadTrips()
        {
            FactStaff f = (FactStaff)factStaffBindingSource.Current;
            BusinessTripsBindingSource.DataSource = KadrController.Instance.Model.BusinessTrips.Where(t => t.FactStaffPrikaz.FactStaff == f).Select(x=>new BusinessTripDecorator(x)).ToList();
            dgvTrips.Refresh();

        }

        private void LoadMaterials()
        {
            var f = (FactStaff)factStaffBindingSource.Current;
            MaterialResponsibilitybindingSource.DataSource = KadrController.Instance.Model.MaterialResponsibilities.Where(t => t.FactStaffPrikaz.FactStaff == f);
            dgvMaterial.Refresh();

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


        private void EditDegreeBtn_Click(object sender, EventArgs e)
        {
            if (employeeDegreeBindingSource.Current != null)
                LinqActionsController<EmployeeDegree>.Instance.EditObject(
                        employeeDegreeBindingSource.Current as EmployeeDegree, false);

        }

        private void AddDegreeBtn_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<EmployeeDegree> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<EmployeeDegree>())
            {
                dlg.ObjectList = KadrController.Instance.Model.EmployeeDegrees;
                dlg.BindingSource = employeeDegreeBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.InitializeNewObject = (x) =>
                {
                    EducDocument educDocument = new EducDocument();
                    EducDocumentType docType = KadrController.Instance.Model.EducDocumentTypes.Where(educDocType
                        => educDocType.id == 1).First();
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EducDocument, EducDocumentType>(educDocument, "EducDocumentType", docType, null), this);

                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeDegree, ScienceType>(x, "ScienceType", NullScienceType.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeDegree, Degree>(x, "Degree", NullDegree.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeDegree, Employee>(x, "Employee", Employee, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeDegree, EducDocument>(x, "EducDocument", educDocument, null), this);
                };



                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.EmployeeDegrees;
                };

                dlg.ShowDialog();
            }

        }

        private void DelDegreeBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить научную степень сотрудника?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                LinqActionsController<EducDocument>.Instance.DeleteObject((employeeDegreeBindingSource.Current as EmployeeDegree).EducDocument,
                     KadrController.Instance.Model.EducDocuments, null);

                LinqActionsController<EmployeeDegree>.Instance.DeleteObject(employeeDegreeBindingSource.Current as EmployeeDegree,
                     KadrController.Instance.Model.EmployeeDegrees, employeeDegreeBindingSource);
            }
        }

        private void AddRankBtn_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<EmployeeRank> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<EmployeeRank>())
            {
                dlg.ObjectList = KadrController.Instance.Model.EmployeeRanks;
                dlg.BindingSource = employeeRankBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.InitializeNewObject = (x) =>
                {
                    EducDocument educDocument = new EducDocument();
                    EducDocumentType docType = Kadr.Controllers.KadrController.Instance.Model.EducDocumentTypes.Where(educDocType
                        => educDocType.id == 2).First();
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EducDocument, EducDocumentType>(educDocument, "EducDocumentType", docType, null), this);

                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeRank, Rank>(x, "Rank", NullRank.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeRank, Employee>(x, "Employee", Employee, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeRank, EducDocument>(x, "EducDocument", educDocument, null), this);

                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.EmployeeRanks;
                };

                dlg.ShowDialog();
            }
        }

        private void EditRankBtn_Click(object sender, EventArgs e)
        {
            if (employeeRankBindingSource.Current != null)
                LinqActionsController<EmployeeRank>.Instance.EditObject(
                        employeeRankBindingSource.Current as EmployeeRank, false);
        }

        private void DelRankBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить ученое звание сотрудника?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                 == DialogResult.OK)
            {
                LinqActionsController<EducDocument>.Instance.DeleteObject((employeeRankBindingSource.Current as EmployeeRank).EducDocument,
                     KadrController.Instance.Model.EducDocuments, null);

                LinqActionsController<EmployeeRank>.Instance.DeleteObject(employeeRankBindingSource.Current as EmployeeRank,
                     KadrController.Instance.Model.EmployeeRanks, employeeRankBindingSource);
            }
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tcEmployee = new System.Windows.Forms.TabControl();
            this.tpEmployee = new System.Windows.Forms.TabPage();
            this.tcEmplData = new System.Windows.Forms.TabControl();
            this.tpPersonData = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.cpgEmployee = new UIX.UI.CommandPropertyGrid();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tpContData = new System.Windows.Forms.TabPage();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.idphoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployeeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oKphoneBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip7 = new System.Windows.Forms.ToolStrip();
            this.tsbAddPhone = new System.Windows.Forms.ToolStripButton();
            this.tsbEditPhone = new System.Windows.Forms.ToolStripButton();
            this.tsbDelPhone = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel9 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView6 = new System.Windows.Forms.DataGridView();
            this.idAdressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployeeDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.adressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateRegDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regBitDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.employeeDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oKAdressBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip8 = new System.Windows.Forms.ToolStrip();
            this.tsbAddAddress = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdAddress = new System.Windows.Forms.ToolStripButton();
            this.tsbDelAddress = new System.Windows.Forms.ToolStripButton();
            this.tpFamily = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel10 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView7 = new System.Windows.Forms.DataGridView();
            this.idfamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idmembfamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idemployeeDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oKMembFamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fiomembfamDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.godbirthDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oKFamBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip9 = new System.Windows.Forms.ToolStrip();
            this.tsbAddFamMember = new System.Windows.Forms.ToolStripButton();
            this.tsbEditFamMember = new System.Windows.Forms.ToolStripButton();
            this.tsbDelFamMember = new System.Windows.Forms.ToolStripButton();
            this.tpEmpPost = new System.Windows.Forms.TabPage();
            this.tcEmplWorkData = new System.Windows.Forms.TabControl();
            this.tpUGTUPosts = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dgvEmplPosts = new System.Windows.Forms.DataGridView();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HourCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinancingSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PKCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalarySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FStDateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FStPrikazBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prikaz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factStaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tcEmplPostInf = new System.Windows.Forms.TabControl();
            this.tpEmpOtpusk = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel7 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView5 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oKOtpuskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.tsbAddOtp = new System.Windows.Forms.ToolStripButton();
            this.tsbEditOtp = new System.Windows.Forms.ToolStripButton();
            this.tsbDelOtp = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbSocialFareTransit = new System.Windows.Forms.ToolStripButton();
            this.tpBusTrip = new System.Windows.Forms.TabPage();
            this.dgvTrips = new System.Windows.Forms.DataGridView();
            this.prikazDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBeginDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetPlaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BusinessTripsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsBusinessTrips = new System.Windows.Forms.ToolStrip();
            this.tsbAddEmplTrip = new System.Windows.Forms.ToolStripButton();
            this.tsbEditEmplTrip = new System.Windows.Forms.ToolStripButton();
            this.tsbDelEmplTrip = new System.Windows.Forms.ToolStripButton();
            this.tsbChangeRegionDates = new System.Windows.Forms.ToolStripButton();
            this.tpMaterial = new System.Windows.Forms.TabPage();
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.colPrikazMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colNumContractMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateContractMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colSumMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDataBeginMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDateEndMaterial = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaterialResponsibilitybindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsMaterialResp = new System.Windows.Forms.ToolStrip();
            this.tsbAddMaterial = new System.Windows.Forms.ToolStripButton();
            this.tsbEditMaterial = new System.Windows.Forms.ToolStripButton();
            this.tsbDelMaterial = new System.Windows.Forms.ToolStripButton();
            this.tpEmplStading = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView4 = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.standingTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workPlaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBeginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRegionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idStandingTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeStandingBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbAddEmplStanding = new System.Windows.Forms.ToolStripButton();
            this.tsbEditEmplStanding = new System.Windows.Forms.ToolStripButton();
            this.tsbDelEmplStanding = new System.Windows.Forms.ToolStripButton();
            this.tpIncapacities = new System.Windows.Forms.TabPage();
            this.dgvIncapacities = new System.Windows.Forms.DataGridView();
            this.dateBeginDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serieDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.inkapacityDecoratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip12 = new System.Windows.Forms.ToolStrip();
            this.tsbAddIncapacity = new System.Windows.Forms.ToolStripButton();
            this.tsbEditIncapacity = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteIncapacity = new System.Windows.Forms.ToolStripButton();
            this.tpBonus = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvAllBonus = new System.Windows.Forms.DataGridView();
            this.BonusLevel = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonusPost = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BnLastFinancingSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllBonusCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllDateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PrikazBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntermediateDateEnd0 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AllbonusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.tsbBonusHistory = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBonusFilter = new System.Windows.Forms.ToolStripSplitButton();
            this.текущиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отмененныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tpEducation = new System.Windows.Forms.TabPage();
            this.tcEducation = new System.Windows.Forms.TabControl();
            this.tpGrandEducation = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView9 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn73 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn74 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn75 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn76 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn77 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn78 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDegreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip11 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.dgvEducation = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn67 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn68 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn69 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn70 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn71 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn72 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpPostGradEduc = new System.Windows.Forms.TabPage();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.degreeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scienceTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educDocumentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dissertCouncilDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.degreeDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.diplWhereDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip4 = new System.Windows.Forms.ToolStrip();
            this.AddDegreeBtn = new System.Windows.Forms.ToolStripButton();
            this.EditDegreeBtn = new System.Windows.Forms.ToolStripButton();
            this.DelDegreeBtn = new System.Windows.Forms.ToolStripButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel4 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView3 = new System.Windows.Forms.DataGridView();
            this.rankDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educDocumentDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.rankWhereDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeRankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddRankBtn = new System.Windows.Forms.ToolStripButton();
            this.EditRankBtn = new System.Windows.Forms.ToolStripButton();
            this.DelRankBtn = new System.Windows.Forms.ToolStripButton();
            this.tpEmplBonusReport = new System.Windows.Forms.TabPage();
            this.btnBonusRepLoad = new System.Windows.Forms.Button();
            this.dtpBonRepPeriodEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpBonRepPeriodBegin = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel6 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip6 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.employeeBonusReportFrame1 = new Reports.Frames.ReportBaseFrameForPeriod();
            this.tpDopInf = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel11 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView8 = new System.Windows.Forms.DataGridView();
            this.idDopInfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployeeDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dopInfDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oKDopInfBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip10 = new System.Windows.Forms.ToolStrip();
            this.tsbAddDopInf = new System.Windows.Forms.ToolStripButton();
            this.tsbEditDopInf = new System.Windows.Forms.ToolStripButton();
            this.tsbDelDopInf = new System.Windows.Forms.ToolStripButton();
            this.materialResponsibilityDecoratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bonusReportColumnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bonusTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn21 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn22 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn23 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn24 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn25 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn26 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn27 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn28 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn29 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn30 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn31 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn32 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn33 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn34 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn35 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn36 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn37 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn38 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn39 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn40 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn41 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn42 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn43 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn44 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn45 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn46 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn47 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn48 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn49 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn50 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn51 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn52 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn53 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn54 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn55 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn56 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn57 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn58 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn59 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn60 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn66 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tpAwards = new System.Windows.Forms.TabPage();
            this.dgvAwards = new System.Windows.Forms.DataGridView();
            this.toolStrip13 = new System.Windows.Forms.ToolStrip();
            this.tsbAddAward = new System.Windows.Forms.ToolStripButton();
            this.tsbEditAward = new System.Windows.Forms.ToolStripButton();
            this.tsbDelAward = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.tcEmployee.SuspendLayout();
            this.tpEmployee.SuspendLayout();
            this.tcEmplData.SuspendLayout();
            this.tpPersonData.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tpContData.SuspendLayout();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKphoneBindingSource)).BeginInit();
            this.toolStrip7.SuspendLayout();
            this.tableLayoutPanel9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKAdressBindingSource)).BeginInit();
            this.toolStrip8.SuspendLayout();
            this.tpFamily.SuspendLayout();
            this.tableLayoutPanel10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKFamBindingSource)).BeginInit();
            this.toolStrip9.SuspendLayout();
            this.tpEmpPost.SuspendLayout();
            this.tcEmplWorkData.SuspendLayout();
            this.tpUGTUPosts.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmplPosts)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffBindingSource)).BeginInit();
            this.tcEmplPostInf.SuspendLayout();
            this.tpEmpOtpusk.SuspendLayout();
            this.tableLayoutPanel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKOtpuskBindingSource)).BeginInit();
            this.toolStrip5.SuspendLayout();
            this.tpBusTrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrips)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessTripsBindingSource)).BeginInit();
            this.tsBusinessTrips.SuspendLayout();
            this.tpMaterial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialResponsibilitybindingSource)).BeginInit();
            this.tsMaterialResp.SuspendLayout();
            this.tpEmplStading.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeStandingBindingSource)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.tpIncapacities.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncapacities)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.inkapacityDecoratorBindingSource)).BeginInit();
            this.toolStrip12.SuspendLayout();
            this.tpBonus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllbonusBindingSource)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tpEducation.SuspendLayout();
            this.tcEducation.SuspendLayout();
            this.tpGrandEducation.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDegreeBindingSource)).BeginInit();
            this.toolStrip11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEducation)).BeginInit();
            this.tpPostGradEduc.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRankBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tpEmplBonusReport.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            this.tpDopInf.SuspendLayout();
            this.tableLayoutPanel11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKDopInfBindingSource)).BeginInit();
            this.toolStrip10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialResponsibilityDecoratorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportColumnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).BeginInit();
            this.tpAwards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAwards)).BeginInit();
            this.toolStrip13.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcEmployee);
            this.groupBox1.Size = new System.Drawing.Size(897, 416);
            // 
            // tcEmployee
            // 
            this.tcEmployee.Controls.Add(this.tpEmployee);
            this.tcEmployee.Controls.Add(this.tpEmpPost);
            this.tcEmployee.Controls.Add(this.tpBonus);
            this.tcEmployee.Controls.Add(this.tpEducation);
            this.tcEmployee.Controls.Add(this.tpEmplBonusReport);
            this.tcEmployee.Controls.Add(this.tpDopInf);
            this.tcEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEmployee.Location = new System.Drawing.Point(3, 16);
            this.tcEmployee.Name = "tcEmployee";
            this.tcEmployee.SelectedIndex = 0;
            this.tcEmployee.Size = new System.Drawing.Size(891, 397);
            this.tcEmployee.TabIndex = 0;
            this.tcEmployee.SelectedIndexChanged += new System.EventHandler(this.tcEmployee_SelectedIndexChanged);
            // 
            // tpEmployee
            // 
            this.tpEmployee.AutoScroll = true;
            this.tpEmployee.Controls.Add(this.tcEmplData);
            this.tpEmployee.Location = new System.Drawing.Point(4, 22);
            this.tpEmployee.Name = "tpEmployee";
            this.tpEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmployee.Size = new System.Drawing.Size(883, 371);
            this.tpEmployee.TabIndex = 0;
            this.tpEmployee.Text = "Личные данные";
            this.tpEmployee.UseVisualStyleBackColor = true;
            // 
            // tcEmplData
            // 
            this.tcEmplData.Controls.Add(this.tpPersonData);
            this.tcEmplData.Controls.Add(this.tpContData);
            this.tcEmplData.Controls.Add(this.tpFamily);
            this.tcEmplData.Controls.Add(this.tpAwards);
            this.tcEmplData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEmplData.Location = new System.Drawing.Point(3, 3);
            this.tcEmplData.Name = "tcEmplData";
            this.tcEmplData.SelectedIndex = 0;
            this.tcEmplData.Size = new System.Drawing.Size(877, 365);
            this.tcEmplData.TabIndex = 4;
            this.tcEmplData.SelectedIndexChanged += new System.EventHandler(this.tcEmplData_SelectedIndexChanged);
            // 
            // tpPersonData
            // 
            this.tpPersonData.Controls.Add(this.tableLayoutPanel5);
            this.tpPersonData.Location = new System.Drawing.Point(4, 22);
            this.tpPersonData.Name = "tpPersonData";
            this.tpPersonData.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonData.Size = new System.Drawing.Size(869, 339);
            this.tpPersonData.TabIndex = 0;
            this.tpPersonData.Text = "Персональные данные";
            this.tpPersonData.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.cpgEmployee, 0, 0);
            this.tableLayoutPanel5.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(863, 333);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // cpgEmployee
            // 
            this.cpgEmployee.CommandRegister = null;
            this.cpgEmployee.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cpgEmployee.Location = new System.Drawing.Point(3, 3);
            this.cpgEmployee.Name = "cpgEmployee";
            this.cpgEmployee.Size = new System.Drawing.Size(857, 287);
            this.cpgEmployee.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(3, 296);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(857, 34);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(545, 0);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(138, 32);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Отменить изменения";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOk.Location = new System.Drawing.Point(689, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(165, 32);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Сохранить изменения";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tpContData
            // 
            this.tpContData.Controls.Add(this.splitContainer3);
            this.tpContData.Location = new System.Drawing.Point(4, 22);
            this.tpContData.Name = "tpContData";
            this.tpContData.Size = new System.Drawing.Size(869, 339);
            this.tpContData.TabIndex = 2;
            this.tpContData.Text = "Контактные данные";
            this.tpContData.UseVisualStyleBackColor = true;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            this.splitContainer3.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.tableLayoutPanel8);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.tableLayoutPanel9);
            this.splitContainer3.Size = new System.Drawing.Size(869, 339);
            this.splitContainer3.SplitterDistance = 174;
            this.splitContainer3.TabIndex = 0;
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.toolStrip7, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 2;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel8.Size = new System.Drawing.Size(869, 174);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idphoneDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn1,
            this.phoneDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn1});
            this.dataGridView1.DataSource = this.oKphoneBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 27);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(863, 233);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.DoubleClick += new System.EventHandler(this.tsbEditPhone_Click);
            // 
            // idphoneDataGridViewTextBoxColumn
            // 
            this.idphoneDataGridViewTextBoxColumn.DataPropertyName = "idphone";
            this.idphoneDataGridViewTextBoxColumn.HeaderText = "idphone";
            this.idphoneDataGridViewTextBoxColumn.Name = "idphoneDataGridViewTextBoxColumn";
            this.idphoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.idphoneDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEmployeeDataGridViewTextBoxColumn1
            // 
            this.idEmployeeDataGridViewTextBoxColumn1.DataPropertyName = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn1.HeaderText = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn1.Name = "idEmployeeDataGridViewTextBoxColumn1";
            this.idEmployeeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.idEmployeeDataGridViewTextBoxColumn1.Visible = false;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Номер телефона";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeDataGridViewTextBoxColumn1
            // 
            this.employeeDataGridViewTextBoxColumn1.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn1.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn1.Name = "employeeDataGridViewTextBoxColumn1";
            this.employeeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn1.Visible = false;
            // 
            // oKphoneBindingSource
            // 
            this.oKphoneBindingSource.DataSource = typeof(Kadr.Data.OK_phone);
            // 
            // toolStrip7
            // 
            this.toolStrip7.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddPhone,
            this.tsbEditPhone,
            this.tsbDelPhone});
            this.toolStrip7.Location = new System.Drawing.Point(0, 0);
            this.toolStrip7.Name = "toolStrip7";
            this.toolStrip7.Size = new System.Drawing.Size(869, 24);
            this.toolStrip7.TabIndex = 2;
            this.toolStrip7.Text = "toolStrip7";
            // 
            // tsbAddPhone
            // 
            this.tsbAddPhone.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddPhone.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddPhone.Name = "tsbAddPhone";
            this.tsbAddPhone.Size = new System.Drawing.Size(174, 21);
            this.tsbAddPhone.Text = "Добавить номер телефона";
            this.tsbAddPhone.Click += new System.EventHandler(this.tsbAddPhone_Click);
            // 
            // tsbEditPhone
            // 
            this.tsbEditPhone.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditPhone.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditPhone.Name = "tsbEditPhone";
            this.tsbEditPhone.Size = new System.Drawing.Size(107, 21);
            this.tsbEditPhone.Text = "Редактировать";
            this.tsbEditPhone.ToolTipText = "Редактировать номер телефона";
            this.tsbEditPhone.Click += new System.EventHandler(this.tsbEditPhone_Click);
            // 
            // tsbDelPhone
            // 
            this.tsbDelPhone.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelPhone.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelPhone.Name = "tsbDelPhone";
            this.tsbDelPhone.Size = new System.Drawing.Size(71, 21);
            this.tsbDelPhone.Text = "Удалить";
            this.tsbDelPhone.ToolTipText = "Удалить номер телефона";
            this.tsbDelPhone.Click += new System.EventHandler(this.tsbDelPhone_Click);
            // 
            // tableLayoutPanel9
            // 
            this.tableLayoutPanel9.ColumnCount = 1;
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel9.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel9.Controls.Add(this.dataGridView6, 0, 1);
            this.tableLayoutPanel9.Controls.Add(this.toolStrip8, 0, 0);
            this.tableLayoutPanel9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel9.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel9.Name = "tableLayoutPanel9";
            this.tableLayoutPanel9.RowCount = 2;
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel9.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel9.Size = new System.Drawing.Size(869, 161);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // dataGridView6
            // 
            this.dataGridView6.AllowUserToAddRows = false;
            this.dataGridView6.AllowUserToDeleteRows = false;
            this.dataGridView6.AutoGenerateColumns = false;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAdressDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn2,
            this.adressDataGridViewTextBoxColumn,
            this.dateRegDataGridViewTextBoxColumn,
            this.regBitDataGridViewCheckBoxColumn,
            this.employeeDataGridViewTextBoxColumn2});
            this.dataGridView6.DataSource = this.oKAdressBindingSource;
            this.dataGridView6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView6.Location = new System.Drawing.Point(3, 27);
            this.dataGridView6.Name = "dataGridView6";
            this.dataGridView6.ReadOnly = true;
            this.dataGridView6.RowHeadersVisible = false;
            this.dataGridView6.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView6.Size = new System.Drawing.Size(863, 228);
            this.dataGridView6.TabIndex = 3;
            this.dataGridView6.DoubleClick += new System.EventHandler(this.tsbUpdAddress_Click);
            // 
            // idAdressDataGridViewTextBoxColumn
            // 
            this.idAdressDataGridViewTextBoxColumn.DataPropertyName = "idAdress";
            this.idAdressDataGridViewTextBoxColumn.HeaderText = "idAdress";
            this.idAdressDataGridViewTextBoxColumn.Name = "idAdressDataGridViewTextBoxColumn";
            this.idAdressDataGridViewTextBoxColumn.ReadOnly = true;
            this.idAdressDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEmployeeDataGridViewTextBoxColumn2
            // 
            this.idEmployeeDataGridViewTextBoxColumn2.DataPropertyName = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn2.HeaderText = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn2.Name = "idEmployeeDataGridViewTextBoxColumn2";
            this.idEmployeeDataGridViewTextBoxColumn2.ReadOnly = true;
            this.idEmployeeDataGridViewTextBoxColumn2.Visible = false;
            // 
            // adressDataGridViewTextBoxColumn
            // 
            this.adressDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.adressDataGridViewTextBoxColumn.DataPropertyName = "Adress";
            this.adressDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.adressDataGridViewTextBoxColumn.Name = "adressDataGridViewTextBoxColumn";
            this.adressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateRegDataGridViewTextBoxColumn
            // 
            this.dateRegDataGridViewTextBoxColumn.DataPropertyName = "DateReg";
            this.dateRegDataGridViewTextBoxColumn.HeaderText = "Дата регистрации";
            this.dateRegDataGridViewTextBoxColumn.Name = "dateRegDataGridViewTextBoxColumn";
            this.dateRegDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // regBitDataGridViewCheckBoxColumn
            // 
            this.regBitDataGridViewCheckBoxColumn.DataPropertyName = "RegBit";
            this.regBitDataGridViewCheckBoxColumn.HeaderText = "Прописка";
            this.regBitDataGridViewCheckBoxColumn.Name = "regBitDataGridViewCheckBoxColumn";
            this.regBitDataGridViewCheckBoxColumn.ReadOnly = true;
            // 
            // employeeDataGridViewTextBoxColumn2
            // 
            this.employeeDataGridViewTextBoxColumn2.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn2.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn2.Name = "employeeDataGridViewTextBoxColumn2";
            this.employeeDataGridViewTextBoxColumn2.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn2.Visible = false;
            // 
            // oKAdressBindingSource
            // 
            this.oKAdressBindingSource.DataSource = typeof(Kadr.Data.OK_Adress);
            // 
            // toolStrip8
            // 
            this.toolStrip8.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddAddress,
            this.tsbUpdAddress,
            this.tsbDelAddress});
            this.toolStrip8.Location = new System.Drawing.Point(0, 0);
            this.toolStrip8.Name = "toolStrip8";
            this.toolStrip8.Size = new System.Drawing.Size(869, 24);
            this.toolStrip8.TabIndex = 2;
            this.toolStrip8.Text = "toolStrip8";
            // 
            // tsbAddAddress
            // 
            this.tsbAddAddress.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddAddress.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddAddress.Name = "tsbAddAddress";
            this.tsbAddAddress.Size = new System.Drawing.Size(113, 21);
            this.tsbAddAddress.Text = "Добавить адрес";
            this.tsbAddAddress.Click += new System.EventHandler(this.tsbAddAddress_Click);
            // 
            // tsbUpdAddress
            // 
            this.tsbUpdAddress.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbUpdAddress.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbUpdAddress.Name = "tsbUpdAddress";
            this.tsbUpdAddress.Size = new System.Drawing.Size(107, 21);
            this.tsbUpdAddress.Text = "Редактировать";
            this.tsbUpdAddress.ToolTipText = "Редактировать  адрес";
            this.tsbUpdAddress.Click += new System.EventHandler(this.tsbUpdAddress_Click);
            // 
            // tsbDelAddress
            // 
            this.tsbDelAddress.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelAddress.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelAddress.Name = "tsbDelAddress";
            this.tsbDelAddress.Size = new System.Drawing.Size(71, 21);
            this.tsbDelAddress.Text = "Удалить";
            this.tsbDelAddress.ToolTipText = "Удалить  адрес";
            this.tsbDelAddress.Click += new System.EventHandler(this.tsbDelAddress_Click);
            // 
            // tpFamily
            // 
            this.tpFamily.Controls.Add(this.tableLayoutPanel10);
            this.tpFamily.Location = new System.Drawing.Point(4, 22);
            this.tpFamily.Name = "tpFamily";
            this.tpFamily.Padding = new System.Windows.Forms.Padding(3);
            this.tpFamily.Size = new System.Drawing.Size(869, 339);
            this.tpFamily.TabIndex = 1;
            this.tpFamily.Text = "Состав семьи";
            this.tpFamily.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel10
            // 
            this.tableLayoutPanel10.ColumnCount = 1;
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel10.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel10.Controls.Add(this.dataGridView7, 0, 1);
            this.tableLayoutPanel10.Controls.Add(this.toolStrip9, 0, 0);
            this.tableLayoutPanel10.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel10.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel10.Name = "tableLayoutPanel10";
            this.tableLayoutPanel10.RowCount = 2;
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel10.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel10.Size = new System.Drawing.Size(863, 333);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // dataGridView7
            // 
            this.dataGridView7.AllowUserToAddRows = false;
            this.dataGridView7.AllowUserToDeleteRows = false;
            this.dataGridView7.AutoGenerateColumns = false;
            this.dataGridView7.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView7.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idfamDataGridViewTextBoxColumn,
            this.idmembfamDataGridViewTextBoxColumn,
            this.idemployeeDataGridViewTextBoxColumn3,
            this.oKMembFamDataGridViewTextBoxColumn,
            this.fiomembfamDataGridViewTextBoxColumn,
            this.godbirthDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn3});
            this.dataGridView7.DataSource = this.oKFamBindingSource;
            this.dataGridView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView7.Location = new System.Drawing.Point(3, 27);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.ReadOnly = true;
            this.dataGridView7.RowHeadersVisible = false;
            this.dataGridView7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView7.Size = new System.Drawing.Size(857, 465);
            this.dataGridView7.TabIndex = 4;
            this.dataGridView7.DoubleClick += new System.EventHandler(this.tsbEditFamMember_Click);
            // 
            // idfamDataGridViewTextBoxColumn
            // 
            this.idfamDataGridViewTextBoxColumn.DataPropertyName = "idfam";
            this.idfamDataGridViewTextBoxColumn.HeaderText = "idfam";
            this.idfamDataGridViewTextBoxColumn.Name = "idfamDataGridViewTextBoxColumn";
            this.idfamDataGridViewTextBoxColumn.ReadOnly = true;
            this.idfamDataGridViewTextBoxColumn.Visible = false;
            // 
            // idmembfamDataGridViewTextBoxColumn
            // 
            this.idmembfamDataGridViewTextBoxColumn.DataPropertyName = "idmembfam";
            this.idmembfamDataGridViewTextBoxColumn.HeaderText = "idmembfam";
            this.idmembfamDataGridViewTextBoxColumn.Name = "idmembfamDataGridViewTextBoxColumn";
            this.idmembfamDataGridViewTextBoxColumn.ReadOnly = true;
            this.idmembfamDataGridViewTextBoxColumn.Visible = false;
            // 
            // idemployeeDataGridViewTextBoxColumn3
            // 
            this.idemployeeDataGridViewTextBoxColumn3.DataPropertyName = "idemployee";
            this.idemployeeDataGridViewTextBoxColumn3.HeaderText = "idemployee";
            this.idemployeeDataGridViewTextBoxColumn3.Name = "idemployeeDataGridViewTextBoxColumn3";
            this.idemployeeDataGridViewTextBoxColumn3.ReadOnly = true;
            this.idemployeeDataGridViewTextBoxColumn3.Visible = false;
            // 
            // oKMembFamDataGridViewTextBoxColumn
            // 
            this.oKMembFamDataGridViewTextBoxColumn.DataPropertyName = "OK_MembFam";
            this.oKMembFamDataGridViewTextBoxColumn.HeaderText = "Степень родства";
            this.oKMembFamDataGridViewTextBoxColumn.Name = "oKMembFamDataGridViewTextBoxColumn";
            this.oKMembFamDataGridViewTextBoxColumn.ReadOnly = true;
            this.oKMembFamDataGridViewTextBoxColumn.Width = 170;
            // 
            // fiomembfamDataGridViewTextBoxColumn
            // 
            this.fiomembfamDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.fiomembfamDataGridViewTextBoxColumn.DataPropertyName = "fiomembfam";
            this.fiomembfamDataGridViewTextBoxColumn.HeaderText = "ФИО родственника";
            this.fiomembfamDataGridViewTextBoxColumn.Name = "fiomembfamDataGridViewTextBoxColumn";
            this.fiomembfamDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // godbirthDataGridViewTextBoxColumn
            // 
            this.godbirthDataGridViewTextBoxColumn.DataPropertyName = "godbirth";
            this.godbirthDataGridViewTextBoxColumn.HeaderText = "Дата рождения";
            this.godbirthDataGridViewTextBoxColumn.Name = "godbirthDataGridViewTextBoxColumn";
            this.godbirthDataGridViewTextBoxColumn.ReadOnly = true;
            this.godbirthDataGridViewTextBoxColumn.Width = 150;
            // 
            // employeeDataGridViewTextBoxColumn3
            // 
            this.employeeDataGridViewTextBoxColumn3.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn3.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn3.Name = "employeeDataGridViewTextBoxColumn3";
            this.employeeDataGridViewTextBoxColumn3.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn3.Visible = false;
            // 
            // oKFamBindingSource
            // 
            this.oKFamBindingSource.DataSource = typeof(Kadr.Data.OK_Fam);
            // 
            // toolStrip9
            // 
            this.toolStrip9.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddFamMember,
            this.tsbEditFamMember,
            this.tsbDelFamMember});
            this.toolStrip9.Location = new System.Drawing.Point(0, 0);
            this.toolStrip9.Name = "toolStrip9";
            this.toolStrip9.Size = new System.Drawing.Size(863, 24);
            this.toolStrip9.TabIndex = 3;
            this.toolStrip9.Text = "toolStrip9";
            // 
            // tsbAddFamMember
            // 
            this.tsbAddFamMember.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddFamMember.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddFamMember.Name = "tsbAddFamMember";
            this.tsbAddFamMember.Size = new System.Drawing.Size(152, 21);
            this.tsbAddFamMember.Text = "Добавить члена семьи";
            this.tsbAddFamMember.Click += new System.EventHandler(this.tsbAddFamMember_Click);
            // 
            // tsbEditFamMember
            // 
            this.tsbEditFamMember.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditFamMember.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditFamMember.Name = "tsbEditFamMember";
            this.tsbEditFamMember.Size = new System.Drawing.Size(107, 21);
            this.tsbEditFamMember.Text = "Редактировать";
            this.tsbEditFamMember.ToolTipText = "Редактировать члена семьи";
            this.tsbEditFamMember.Click += new System.EventHandler(this.tsbEditFamMember_Click);
            // 
            // tsbDelFamMember
            // 
            this.tsbDelFamMember.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelFamMember.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelFamMember.Name = "tsbDelFamMember";
            this.tsbDelFamMember.Size = new System.Drawing.Size(71, 21);
            this.tsbDelFamMember.Text = "Удалить";
            this.tsbDelFamMember.ToolTipText = "Удалить члена семьи";
            this.tsbDelFamMember.Click += new System.EventHandler(this.tsbDelFamMember_Click);
            // 
            // tpEmpPost
            // 
            this.tpEmpPost.AutoScroll = true;
            this.tpEmpPost.Controls.Add(this.tcEmplWorkData);
            this.tpEmpPost.Location = new System.Drawing.Point(4, 22);
            this.tpEmpPost.Name = "tpEmpPost";
            this.tpEmpPost.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmpPost.Size = new System.Drawing.Size(802, 533);
            this.tpEmpPost.TabIndex = 1;
            this.tpEmpPost.Text = "Трудовая деятельность";
            this.tpEmpPost.UseVisualStyleBackColor = true;
            // 
            // tcEmplWorkData
            // 
            this.tcEmplWorkData.Controls.Add(this.tpUGTUPosts);
            this.tcEmplWorkData.Controls.Add(this.tpEmplStading);
            this.tcEmplWorkData.Controls.Add(this.tpIncapacities);
            this.tcEmplWorkData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEmplWorkData.Location = new System.Drawing.Point(3, 3);
            this.tcEmplWorkData.Name = "tcEmplWorkData";
            this.tcEmplWorkData.SelectedIndex = 0;
            this.tcEmplWorkData.Size = new System.Drawing.Size(796, 527);
            this.tcEmplWorkData.TabIndex = 1;
            this.tcEmplWorkData.SelectedIndexChanged += new System.EventHandler(this.tcEmplWorkData_SelectedIndexChanged);
            // 
            // tpUGTUPosts
            // 
            this.tpUGTUPosts.Controls.Add(this.splitContainer1);
            this.tpUGTUPosts.Location = new System.Drawing.Point(4, 22);
            this.tpUGTUPosts.Name = "tpUGTUPosts";
            this.tpUGTUPosts.Padding = new System.Windows.Forms.Padding(3);
            this.tpUGTUPosts.Size = new System.Drawing.Size(788, 501);
            this.tpUGTUPosts.TabIndex = 0;
            this.tpUGTUPosts.Text = "Должности";
            this.tpUGTUPosts.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.dgvEmplPosts);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tcEmplPostInf);
            this.splitContainer1.Size = new System.Drawing.Size(782, 495);
            this.splitContainer1.SplitterDistance = 291;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvEmplPosts
            // 
            this.dgvEmplPosts.AllowUserToAddRows = false;
            this.dgvEmplPosts.AllowUserToDeleteRows = false;
            this.dgvEmplPosts.AutoGenerateColumns = false;
            this.dgvEmplPosts.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEmplPosts.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Department,
            this.Post,
            this.WorkType,
            this.HourCount,
            this.FinancingSource,
            this.PKCategory,
            this.Category,
            this.SalarySize,
            this.StaffCount,
            this.FStDateBegin,
            this.FStPrikazBegin,
            this.dateEndDataGridViewTextBoxColumn,
            this.Prikaz});
            this.dgvEmplPosts.DataSource = this.factStaffBindingSource;
            this.dgvEmplPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmplPosts.Location = new System.Drawing.Point(0, 0);
            this.dgvEmplPosts.Name = "dgvEmplPosts";
            this.dgvEmplPosts.ReadOnly = true;
            this.dgvEmplPosts.RowHeadersVisible = false;
            this.dgvEmplPosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmplPosts.Size = new System.Drawing.Size(782, 291);
            this.dgvEmplPosts.TabIndex = 0;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Отдел";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.Width = 110;
            // 
            // Post
            // 
            this.Post.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Post.DataPropertyName = "Post";
            this.Post.HeaderText = "Должность";
            this.Post.Name = "Post";
            this.Post.ReadOnly = true;
            // 
            // WorkType
            // 
            this.WorkType.DataPropertyName = "WorkType";
            this.WorkType.HeaderText = "Вид работы";
            this.WorkType.Name = "WorkType";
            this.WorkType.ReadOnly = true;
            this.WorkType.Width = 55;
            // 
            // HourCount
            // 
            this.HourCount.DataPropertyName = "HourCount";
            this.HourCount.HeaderText = "Кол-во часов";
            this.HourCount.Name = "HourCount";
            this.HourCount.ReadOnly = true;
            this.HourCount.Width = 45;
            // 
            // FinancingSource
            // 
            this.FinancingSource.DataPropertyName = "FinSource";
            this.FinancingSource.HeaderText = "Ист фин";
            this.FinancingSource.Name = "FinancingSource";
            this.FinancingSource.ReadOnly = true;
            this.FinancingSource.Width = 45;
            // 
            // PKCategory
            // 
            this.PKCategory.DataPropertyName = "PKCategory";
            this.PKCategory.HeaderText = "ПКГ/ КУ/ ПУ (/ППУ)";
            this.PKCategory.Name = "PKCategory";
            this.PKCategory.ReadOnly = true;
            this.PKCategory.Width = 50;
            // 
            // Category
            // 
            this.Category.DataPropertyName = "Category";
            this.Category.HeaderText = "Катег.";
            this.Category.Name = "Category";
            this.Category.ReadOnly = true;
            this.Category.Width = 50;
            // 
            // SalarySize
            // 
            this.SalarySize.DataPropertyName = "SalarySize";
            this.SalarySize.HeaderText = "Размер оклада/ стоим. часа";
            this.SalarySize.Name = "SalarySize";
            this.SalarySize.ReadOnly = true;
            this.SalarySize.Width = 70;
            // 
            // StaffCount
            // 
            this.StaffCount.DataPropertyName = "StaffCount";
            this.StaffCount.HeaderText = "Кол-во ставок";
            this.StaffCount.Name = "StaffCount";
            this.StaffCount.ReadOnly = true;
            this.StaffCount.Width = 50;
            // 
            // FStDateBegin
            // 
            this.FStDateBegin.DataPropertyName = "DateBegin";
            this.FStDateBegin.HeaderText = "Дата назн.";
            this.FStDateBegin.Name = "FStDateBegin";
            this.FStDateBegin.ReadOnly = true;
            this.FStDateBegin.Width = 70;
            // 
            // FStPrikazBegin
            // 
            this.FStPrikazBegin.DataPropertyName = "PrikazBegin";
            this.FStPrikazBegin.HeaderText = "Приказ назн.";
            this.FStPrikazBegin.Name = "FStPrikazBegin";
            this.FStPrikazBegin.ReadOnly = true;
            this.FStPrikazBegin.Width = 55;
            // 
            // dateEndDataGridViewTextBoxColumn
            // 
            this.dateEndDataGridViewTextBoxColumn.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn.HeaderText = "Дата увольн";
            this.dateEndDataGridViewTextBoxColumn.Name = "dateEndDataGridViewTextBoxColumn";
            this.dateEndDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateEndDataGridViewTextBoxColumn.Width = 70;
            // 
            // Prikaz
            // 
            this.Prikaz.DataPropertyName = "Prikaz";
            this.Prikaz.HeaderText = "Приказ увольн";
            this.Prikaz.Name = "Prikaz";
            this.Prikaz.ReadOnly = true;
            this.Prikaz.Width = 55;
            // 
            // factStaffBindingSource
            // 
            this.factStaffBindingSource.DataSource = typeof(Kadr.Data.FactStaff);
            this.factStaffBindingSource.PositionChanged += new System.EventHandler(this.factStaffBindingSource_PositionChanged);
            // 
            // tcEmplPostInf
            // 
            this.tcEmplPostInf.Controls.Add(this.tpEmpOtpusk);
            this.tcEmplPostInf.Controls.Add(this.tpBusTrip);
            this.tcEmplPostInf.Controls.Add(this.tpMaterial);
            this.tcEmplPostInf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEmplPostInf.Location = new System.Drawing.Point(0, 0);
            this.tcEmplPostInf.Name = "tcEmplPostInf";
            this.tcEmplPostInf.SelectedIndex = 0;
            this.tcEmplPostInf.Size = new System.Drawing.Size(782, 200);
            this.tcEmplPostInf.TabIndex = 1;
            this.tcEmplPostInf.SelectedIndexChanged += new System.EventHandler(this.tcEmplPostInf_SelectedIndexChanged);
            // 
            // tpEmpOtpusk
            // 
            this.tpEmpOtpusk.Controls.Add(this.tableLayoutPanel7);
            this.tpEmpOtpusk.Location = new System.Drawing.Point(4, 22);
            this.tpEmpOtpusk.Name = "tpEmpOtpusk";
            this.tpEmpOtpusk.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmpOtpusk.Size = new System.Drawing.Size(774, 174);
            this.tpEmpOtpusk.TabIndex = 0;
            this.tpEmpOtpusk.Text = "Отпуска";
            this.tpEmpOtpusk.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel7
            // 
            this.tableLayoutPanel7.ColumnCount = 1;
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel7.Controls.Add(this.dataGridView5, 0, 1);
            this.tableLayoutPanel7.Controls.Add(this.toolStrip5, 0, 0);
            this.tableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel7.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel7.Name = "tableLayoutPanel7";
            this.tableLayoutPanel7.RowCount = 2;
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel7.Size = new System.Drawing.Size(768, 168);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.AutoGenerateColumns = false;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.DateEnd});
            this.dataGridView5.DataSource = this.oKOtpuskBindingSource;
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView5.Location = new System.Drawing.Point(3, 27);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.RowHeadersVisible = false;
            this.dataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView5.Size = new System.Drawing.Size(762, 155);
            this.dataGridView5.TabIndex = 2;
            this.dataGridView5.DoubleClick += new System.EventHandler(this.tsbEditOtp_Click);
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "OK_Otpuskvid";
            this.dataGridViewTextBoxColumn9.HeaderText = "Вид отпуска";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "RealDateBegin";
            this.dataGridViewTextBoxColumn11.HeaderText = "Дата начала";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 70;
            // 
            // DateEnd
            // 
            this.DateEnd.DataPropertyName = "RealDateEnd";
            this.DateEnd.HeaderText = "Дата окончания";
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.ReadOnly = true;
            // 
            // oKOtpuskBindingSource
            // 
            this.oKOtpuskBindingSource.DataSource = typeof(Kadr.Data.OK_Otpusk);
            // 
            // toolStrip5
            // 
            this.toolStrip5.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddOtp,
            this.tsbEditOtp,
            this.tsbDelOtp,
            this.toolStripSeparator1,
            this.tsbSocialFareTransit});
            this.toolStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(768, 24);
            this.toolStrip5.TabIndex = 1;
            this.toolStrip5.Text = "toolStrip5";
            // 
            // tsbAddOtp
            // 
            this.tsbAddOtp.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddOtp.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddOtp.Name = "tsbAddOtp";
            this.tsbAddOtp.Size = new System.Drawing.Size(119, 21);
            this.tsbAddOtp.Text = "Добавить отпуск";
            this.tsbAddOtp.Click += new System.EventHandler(this.tsbAddOtp_Click);
            // 
            // tsbEditOtp
            // 
            this.tsbEditOtp.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditOtp.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditOtp.Name = "tsbEditOtp";
            this.tsbEditOtp.Size = new System.Drawing.Size(107, 21);
            this.tsbEditOtp.Text = "Редактировать";
            this.tsbEditOtp.ToolTipText = "Редактировать отпуск";
            this.tsbEditOtp.Click += new System.EventHandler(this.tsbEditOtp_Click);
            // 
            // tsbDelOtp
            // 
            this.tsbDelOtp.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelOtp.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelOtp.Name = "tsbDelOtp";
            this.tsbDelOtp.Size = new System.Drawing.Size(71, 21);
            this.tsbDelOtp.Text = "Удалить";
            this.tsbDelOtp.ToolTipText = "Удалить отпуск";
            this.tsbDelOtp.Click += new System.EventHandler(this.tsbDelOtp_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 24);
            // 
            // tsbSocialFareTransit
            // 
            this.tsbSocialFareTransit.Image = global::Kadr.Properties.Resources.Calendar_scheduleHS;
            this.tsbSocialFareTransit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbSocialFareTransit.Name = "tsbSocialFareTransit";
            this.tsbSocialFareTransit.Size = new System.Drawing.Size(122, 21);
            this.tsbSocialFareTransit.Text = "Льготный проезд";
            this.tsbSocialFareTransit.ToolTipText = "Льготный проезд";
            this.tsbSocialFareTransit.Click += new System.EventHandler(this.tsbSocialFareTransit_Click);
            // 
            // tpBusTrip
            // 
            this.tpBusTrip.Controls.Add(this.dgvTrips);
            this.tpBusTrip.Controls.Add(this.tsBusinessTrips);
            this.tpBusTrip.Location = new System.Drawing.Point(4, 22);
            this.tpBusTrip.Name = "tpBusTrip";
            this.tpBusTrip.Padding = new System.Windows.Forms.Padding(3);
            this.tpBusTrip.Size = new System.Drawing.Size(855, 107);
            this.tpBusTrip.TabIndex = 1;
            this.tpBusTrip.Text = "Командировки";
            this.tpBusTrip.UseVisualStyleBackColor = true;
            // 
            // dgvTrips
            // 
            this.dgvTrips.AutoGenerateColumns = false;
            this.dgvTrips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrips.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prikazDataGridViewTextBoxColumn,
            this.dateBeginDataGridViewTextBoxColumn1,
            this.dateEndDataGridViewTextBoxColumn2,
            this.targetPlaceDataGridViewTextBoxColumn,
            this.finSourceDataGridViewTextBoxColumn});
            this.dgvTrips.DataSource = this.BusinessTripsBindingSource;
            this.dgvTrips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrips.Location = new System.Drawing.Point(3, 28);
            this.dgvTrips.Name = "dgvTrips";
            this.dgvTrips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrips.Size = new System.Drawing.Size(849, 76);
            this.dgvTrips.TabIndex = 13;
            this.dgvTrips.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTrips_CellDoubleClick);
            // 
            // prikazDataGridViewTextBoxColumn
            // 
            this.prikazDataGridViewTextBoxColumn.DataPropertyName = "Prikaz";
            this.prikazDataGridViewTextBoxColumn.HeaderText = "Приказ";
            this.prikazDataGridViewTextBoxColumn.Name = "prikazDataGridViewTextBoxColumn";
            this.prikazDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateBeginDataGridViewTextBoxColumn1
            // 
            this.dateBeginDataGridViewTextBoxColumn1.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn1.HeaderText = "Дата начала";
            this.dateBeginDataGridViewTextBoxColumn1.Name = "dateBeginDataGridViewTextBoxColumn1";
            // 
            // dateEndDataGridViewTextBoxColumn2
            // 
            this.dateEndDataGridViewTextBoxColumn2.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn2.HeaderText = "Дата окончания";
            this.dateEndDataGridViewTextBoxColumn2.Name = "dateEndDataGridViewTextBoxColumn2";
            // 
            // targetPlaceDataGridViewTextBoxColumn
            // 
            this.targetPlaceDataGridViewTextBoxColumn.DataPropertyName = "TargetPlace";
            this.targetPlaceDataGridViewTextBoxColumn.HeaderText = "Место назначения";
            this.targetPlaceDataGridViewTextBoxColumn.Name = "targetPlaceDataGridViewTextBoxColumn";
            this.targetPlaceDataGridViewTextBoxColumn.Width = 200;
            // 
            // finSourceDataGridViewTextBoxColumn
            // 
            this.finSourceDataGridViewTextBoxColumn.DataPropertyName = "FinSource";
            this.finSourceDataGridViewTextBoxColumn.HeaderText = "Источник финансирования";
            this.finSourceDataGridViewTextBoxColumn.Name = "finSourceDataGridViewTextBoxColumn";
            // 
            // BusinessTripsBindingSource
            // 
            this.BusinessTripsBindingSource.DataSource = typeof(Kadr.Data.BusinessTripDecorator);
            // 
            // tsBusinessTrips
            // 
            this.tsBusinessTrips.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddEmplTrip,
            this.tsbEditEmplTrip,
            this.tsbDelEmplTrip,
            this.tsbChangeRegionDates});
            this.tsBusinessTrips.Location = new System.Drawing.Point(3, 3);
            this.tsBusinessTrips.Name = "tsBusinessTrips";
            this.tsBusinessTrips.Size = new System.Drawing.Size(849, 25);
            this.tsBusinessTrips.TabIndex = 12;
            this.tsBusinessTrips.Text = "toolStrip7";
            // 
            // tsbAddEmplTrip
            // 
            this.tsbAddEmplTrip.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddEmplTrip.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddEmplTrip.Name = "tsbAddEmplTrip";
            this.tsbAddEmplTrip.Size = new System.Drawing.Size(119, 22);
            this.tsbAddEmplTrip.Text = "Добавить запись";
            this.tsbAddEmplTrip.Click += new System.EventHandler(this.tsbAddEmplTrip_Click);
            // 
            // tsbEditEmplTrip
            // 
            this.tsbEditEmplTrip.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditEmplTrip.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditEmplTrip.Name = "tsbEditEmplTrip";
            this.tsbEditEmplTrip.Size = new System.Drawing.Size(107, 22);
            this.tsbEditEmplTrip.Text = "Редактировать";
            this.tsbEditEmplTrip.ToolTipText = "Редактировать запись";
            this.tsbEditEmplTrip.Click += new System.EventHandler(this.tsbEditEmplTrip_Click);
            // 
            // tsbDelEmplTrip
            // 
            this.tsbDelEmplTrip.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelEmplTrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelEmplTrip.Name = "tsbDelEmplTrip";
            this.tsbDelEmplTrip.Size = new System.Drawing.Size(71, 22);
            this.tsbDelEmplTrip.Text = "Удалить";
            this.tsbDelEmplTrip.ToolTipText = "Удалить запись";
            this.tsbDelEmplTrip.Click += new System.EventHandler(this.tsbDelEmplTrip_Click);
            // 
            // tsbChangeRegionDates
            // 
            this.tsbChangeRegionDates.Image = global::Kadr.Properties.Resources.TableHS;
            this.tsbChangeRegionDates.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbChangeRegionDates.Name = "tsbChangeRegionDates";
            this.tsbChangeRegionDates.Size = new System.Drawing.Size(245, 22);
            this.tsbChangeRegionDates.Text = "Изменить сроки пребывания в регионе";
            this.tsbChangeRegionDates.Click += new System.EventHandler(this.tsbChangeRegionDates_Click);
            // 
            // tpMaterial
            // 
            this.tpMaterial.Controls.Add(this.dgvMaterial);
            this.tpMaterial.Controls.Add(this.tsMaterialResp);
            this.tpMaterial.Location = new System.Drawing.Point(4, 22);
            this.tpMaterial.Name = "tpMaterial";
            this.tpMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tpMaterial.Size = new System.Drawing.Size(855, 107);
            this.tpMaterial.TabIndex = 2;
            this.tpMaterial.Text = "Материальная ответственность";
            this.tpMaterial.UseVisualStyleBackColor = true;
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AllowUserToAddRows = false;
            this.dgvMaterial.AllowUserToDeleteRows = false;
            this.dgvMaterial.AutoGenerateColumns = false;
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPrikazMaterial,
            this.colNumContractMaterial,
            this.colDateContractMaterial,
            this.colSumMaterial,
            this.colDataBeginMaterial,
            this.colDateEndMaterial});
            this.dgvMaterial.DataSource = this.MaterialResponsibilitybindingSource;
            this.dgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterial.Location = new System.Drawing.Point(3, 28);
            this.dgvMaterial.MultiSelect = false;
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.ReadOnly = true;
            this.dgvMaterial.RowHeadersWidth = 4;
            this.dgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterial.Size = new System.Drawing.Size(849, 76);
            this.dgvMaterial.TabIndex = 14;
            this.dgvMaterial.DoubleClick += new System.EventHandler(this.tsbEditMaterial_Click);
            // 
            // colPrikazMaterial
            // 
            this.colPrikazMaterial.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.colPrikazMaterial.DataPropertyName = "Prikaz";
            this.colPrikazMaterial.HeaderText = "Приказ";
            this.colPrikazMaterial.Name = "colPrikazMaterial";
            this.colPrikazMaterial.ReadOnly = true;
            // 
            // colNumContractMaterial
            // 
            this.colNumContractMaterial.DataPropertyName = "ContractName";
            this.colNumContractMaterial.HeaderText = "Номер договора";
            this.colNumContractMaterial.Name = "colNumContractMaterial";
            this.colNumContractMaterial.ReadOnly = true;
            // 
            // colDateContractMaterial
            // 
            this.colDateContractMaterial.DataPropertyName = "DateContract";
            this.colDateContractMaterial.HeaderText = "Дата договора";
            this.colDateContractMaterial.Name = "colDateContractMaterial";
            this.colDateContractMaterial.ReadOnly = true;
            // 
            // colSumMaterial
            // 
            this.colSumMaterial.DataPropertyName = "Sum";
            this.colSumMaterial.HeaderText = "Сумма выплаты";
            this.colSumMaterial.Name = "colSumMaterial";
            this.colSumMaterial.ReadOnly = true;
            // 
            // colDataBeginMaterial
            // 
            this.colDataBeginMaterial.DataPropertyName = "DateBegin";
            this.colDataBeginMaterial.HeaderText = "Дата начала";
            this.colDataBeginMaterial.Name = "colDataBeginMaterial";
            this.colDataBeginMaterial.ReadOnly = true;
            // 
            // colDateEndMaterial
            // 
            this.colDateEndMaterial.DataPropertyName = "DateEnd";
            this.colDateEndMaterial.HeaderText = "Дата окончания";
            this.colDateEndMaterial.Name = "colDateEndMaterial";
            this.colDateEndMaterial.ReadOnly = true;
            // 
            // MaterialResponsibilitybindingSource
            // 
            this.MaterialResponsibilitybindingSource.AllowNew = false;
            this.MaterialResponsibilitybindingSource.DataSource = typeof(Kadr.Data.MaterialResponsibility);
            // 
            // tsMaterialResp
            // 
            this.tsMaterialResp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddMaterial,
            this.tsbEditMaterial,
            this.tsbDelMaterial});
            this.tsMaterialResp.Location = new System.Drawing.Point(3, 3);
            this.tsMaterialResp.Name = "tsMaterialResp";
            this.tsMaterialResp.Size = new System.Drawing.Size(849, 25);
            this.tsMaterialResp.TabIndex = 13;
            this.tsMaterialResp.Text = "toolStrip7";
            // 
            // tsbAddMaterial
            // 
            this.tsbAddMaterial.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddMaterial.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddMaterial.Name = "tsbAddMaterial";
            this.tsbAddMaterial.Size = new System.Drawing.Size(119, 22);
            this.tsbAddMaterial.Text = "Добавить запись";
            this.tsbAddMaterial.Click += new System.EventHandler(this.tsbAddMaterial_Click);
            // 
            // tsbEditMaterial
            // 
            this.tsbEditMaterial.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditMaterial.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditMaterial.Name = "tsbEditMaterial";
            this.tsbEditMaterial.Size = new System.Drawing.Size(107, 22);
            this.tsbEditMaterial.Text = "Редактировать";
            this.tsbEditMaterial.ToolTipText = "Редактировать запись";
            this.tsbEditMaterial.Click += new System.EventHandler(this.tsbEditMaterial_Click);
            // 
            // tsbDelMaterial
            // 
            this.tsbDelMaterial.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelMaterial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelMaterial.Name = "tsbDelMaterial";
            this.tsbDelMaterial.Size = new System.Drawing.Size(71, 22);
            this.tsbDelMaterial.Text = "Удалить";
            this.tsbDelMaterial.ToolTipText = "Удалить запись";
            this.tsbDelMaterial.Click += new System.EventHandler(this.tsbDelMaterial_Click);
            // 
            // tpEmplStading
            // 
            this.tpEmplStading.Controls.Add(this.tableLayoutPanel2);
            this.tpEmplStading.Location = new System.Drawing.Point(4, 22);
            this.tpEmplStading.Name = "tpEmplStading";
            this.tpEmplStading.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmplStading.Size = new System.Drawing.Size(869, 339);
            this.tpEmplStading.TabIndex = 1;
            this.tpEmplStading.Text = "Трудовая книжка";
            this.tpEmplStading.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dataGridView4, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(863, 333);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // dataGridView4
            // 
            this.dataGridView4.AllowUserToAddRows = false;
            this.dataGridView4.AllowUserToDeleteRows = false;
            this.dataGridView4.AutoGenerateColumns = false;
            this.dataGridView4.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView4.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.regionTypeDataGridViewTextBoxColumn,
            this.standingTypeDataGridViewTextBoxColumn,
            this.workPlaceDataGridViewTextBoxColumn,
            this.postDataGridViewTextBoxColumn,
            this.dateBeginDataGridViewTextBoxColumn,
            this.dateEndDataGridViewTextBoxColumn1,
            this.idRegionTypeDataGridViewTextBoxColumn,
            this.idStandingTypeDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn});
            this.dataGridView4.DataSource = this.employeeStandingBindingSource;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(3, 28);
            this.dataGridView4.MultiSelect = false;
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(877, 302);
            this.dataGridView4.TabIndex = 9;
            this.dataGridView4.DoubleClick += new System.EventHandler(this.tsbEditEmplStanding_Click);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // regionTypeDataGridViewTextBoxColumn
            // 
            this.regionTypeDataGridViewTextBoxColumn.DataPropertyName = "RegionType";
            this.regionTypeDataGridViewTextBoxColumn.HeaderText = "Тип региона";
            this.regionTypeDataGridViewTextBoxColumn.Name = "regionTypeDataGridViewTextBoxColumn";
            this.regionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.regionTypeDataGridViewTextBoxColumn.Width = 130;
            // 
            // standingTypeDataGridViewTextBoxColumn
            // 
            this.standingTypeDataGridViewTextBoxColumn.DataPropertyName = "StandingType";
            this.standingTypeDataGridViewTextBoxColumn.HeaderText = "Тип стажа";
            this.standingTypeDataGridViewTextBoxColumn.Name = "standingTypeDataGridViewTextBoxColumn";
            this.standingTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.standingTypeDataGridViewTextBoxColumn.Width = 130;
            // 
            // workPlaceDataGridViewTextBoxColumn
            // 
            this.workPlaceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.workPlaceDataGridViewTextBoxColumn.DataPropertyName = "WorkPlace";
            this.workPlaceDataGridViewTextBoxColumn.HeaderText = "Место работы";
            this.workPlaceDataGridViewTextBoxColumn.Name = "workPlaceDataGridViewTextBoxColumn";
            this.workPlaceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // postDataGridViewTextBoxColumn
            // 
            this.postDataGridViewTextBoxColumn.DataPropertyName = "Post";
            this.postDataGridViewTextBoxColumn.HeaderText = "Должность";
            this.postDataGridViewTextBoxColumn.Name = "postDataGridViewTextBoxColumn";
            this.postDataGridViewTextBoxColumn.ReadOnly = true;
            this.postDataGridViewTextBoxColumn.Width = 130;
            // 
            // dateBeginDataGridViewTextBoxColumn
            // 
            this.dateBeginDataGridViewTextBoxColumn.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.HeaderText = "Дата приема";
            this.dateBeginDataGridViewTextBoxColumn.Name = "dateBeginDataGridViewTextBoxColumn";
            this.dateBeginDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateBeginDataGridViewTextBoxColumn.Width = 70;
            // 
            // dateEndDataGridViewTextBoxColumn1
            // 
            this.dateEndDataGridViewTextBoxColumn1.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn1.HeaderText = "Дата увольнения";
            this.dateEndDataGridViewTextBoxColumn1.Name = "dateEndDataGridViewTextBoxColumn1";
            this.dateEndDataGridViewTextBoxColumn1.ReadOnly = true;
            this.dateEndDataGridViewTextBoxColumn1.Width = 90;
            // 
            // idRegionTypeDataGridViewTextBoxColumn
            // 
            this.idRegionTypeDataGridViewTextBoxColumn.DataPropertyName = "idRegionType";
            this.idRegionTypeDataGridViewTextBoxColumn.HeaderText = "idRegionType";
            this.idRegionTypeDataGridViewTextBoxColumn.Name = "idRegionTypeDataGridViewTextBoxColumn";
            this.idRegionTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.idRegionTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // idStandingTypeDataGridViewTextBoxColumn
            // 
            this.idStandingTypeDataGridViewTextBoxColumn.DataPropertyName = "idStandingType";
            this.idStandingTypeDataGridViewTextBoxColumn.HeaderText = "idStandingType";
            this.idStandingTypeDataGridViewTextBoxColumn.Name = "idStandingTypeDataGridViewTextBoxColumn";
            this.idStandingTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.idStandingTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEmployeeDataGridViewTextBoxColumn
            // 
            this.idEmployeeDataGridViewTextBoxColumn.DataPropertyName = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn.HeaderText = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn.Name = "idEmployeeDataGridViewTextBoxColumn";
            this.idEmployeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmployeeDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeStandingBindingSource
            // 
            this.employeeStandingBindingSource.DataSource = typeof(Kadr.Data.EmployeeStanding);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddEmplStanding,
            this.tsbEditEmplStanding,
            this.tsbDelEmplStanding});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(883, 25);
            this.toolStrip2.TabIndex = 0;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbAddEmplStanding
            // 
            this.tsbAddEmplStanding.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddEmplStanding.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddEmplStanding.Name = "tsbAddEmplStanding";
            this.tsbAddEmplStanding.Size = new System.Drawing.Size(119, 22);
            this.tsbAddEmplStanding.Text = "Добавить запись";
            this.tsbAddEmplStanding.Click += new System.EventHandler(this.tsbAddEmplStanding_Click);
            // 
            // tsbEditEmplStanding
            // 
            this.tsbEditEmplStanding.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditEmplStanding.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditEmplStanding.Name = "tsbEditEmplStanding";
            this.tsbEditEmplStanding.Size = new System.Drawing.Size(107, 22);
            this.tsbEditEmplStanding.Text = "Редактировать";
            this.tsbEditEmplStanding.ToolTipText = "Редактировать запись";
            this.tsbEditEmplStanding.Click += new System.EventHandler(this.tsbEditEmplStanding_Click);
            // 
            // tsbDelEmplStanding
            // 
            this.tsbDelEmplStanding.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelEmplStanding.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelEmplStanding.Name = "tsbDelEmplStanding";
            this.tsbDelEmplStanding.Size = new System.Drawing.Size(71, 22);
            this.tsbDelEmplStanding.Text = "Удалить";
            this.tsbDelEmplStanding.ToolTipText = "Удалить запись";
            this.tsbDelEmplStanding.Click += new System.EventHandler(this.tsbDelEmplStanding_Click);
            // 
            // tpIncapacities
            // 
            this.tpIncapacities.Controls.Add(this.dgvIncapacities);
            this.tpIncapacities.Controls.Add(this.toolStrip12);
            this.tpIncapacities.Location = new System.Drawing.Point(4, 22);
            this.tpIncapacities.Name = "tpIncapacities";
            this.tpIncapacities.Padding = new System.Windows.Forms.Padding(3);
            this.tpIncapacities.Size = new System.Drawing.Size(869, 339);
            this.tpIncapacities.TabIndex = 2;
            this.tpIncapacities.Text = "Периоды нетрудоспособности";
            this.tpIncapacities.UseVisualStyleBackColor = true;
            // 
            // dgvIncapacities
            // 
            this.dgvIncapacities.AllowUserToAddRows = false;
            this.dgvIncapacities.AllowUserToDeleteRows = false;
            this.dgvIncapacities.AutoGenerateColumns = false;
            this.dgvIncapacities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncapacities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateBeginDataGridViewTextBoxColumn2,
            this.dateEndDataGridViewTextBoxColumn3,
            this.serieDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn});
            this.dgvIncapacities.DataSource = this.inkapacityDecoratorBindingSource;
            this.dgvIncapacities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIncapacities.Location = new System.Drawing.Point(3, 28);
            this.dgvIncapacities.MultiSelect = false;
            this.dgvIncapacities.Name = "dgvIncapacities";
            this.dgvIncapacities.ReadOnly = true;
            this.dgvIncapacities.RowHeadersVisible = false;
            this.dgvIncapacities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncapacities.Size = new System.Drawing.Size(863, 308);
            this.dgvIncapacities.TabIndex = 11;
            // 
            // dateBeginDataGridViewTextBoxColumn2
            // 
            this.dateBeginDataGridViewTextBoxColumn2.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn2.HeaderText = "Дата начала";
            this.dateBeginDataGridViewTextBoxColumn2.Name = "dateBeginDataGridViewTextBoxColumn2";
            this.dateBeginDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dateEndDataGridViewTextBoxColumn3
            // 
            this.dateEndDataGridViewTextBoxColumn3.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn3.HeaderText = "Дата окончания";
            this.dateEndDataGridViewTextBoxColumn3.Name = "dateEndDataGridViewTextBoxColumn3";
            this.dateEndDataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // serieDataGridViewTextBoxColumn
            // 
            this.serieDataGridViewTextBoxColumn.DataPropertyName = "Serie";
            this.serieDataGridViewTextBoxColumn.HeaderText = "Серия";
            this.serieDataGridViewTextBoxColumn.Name = "serieDataGridViewTextBoxColumn";
            this.serieDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // docDateDataGridViewTextBoxColumn
            // 
            this.docDateDataGridViewTextBoxColumn.DataPropertyName = "DocDate";
            this.docDateDataGridViewTextBoxColumn.HeaderText = "Дата выдачи документа";
            this.docDateDataGridViewTextBoxColumn.Name = "docDateDataGridViewTextBoxColumn";
            this.docDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // inkapacityDecoratorBindingSource
            // 
            this.inkapacityDecoratorBindingSource.DataSource = typeof(Kadr.Data.InkapacityDecorator);
            // 
            // toolStrip12
            // 
            this.toolStrip12.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddIncapacity,
            this.tsbEditIncapacity,
            this.tsbDeleteIncapacity});
            this.toolStrip12.Location = new System.Drawing.Point(3, 3);
            this.toolStrip12.Name = "toolStrip12";
            this.toolStrip12.Size = new System.Drawing.Size(863, 25);
            this.toolStrip12.TabIndex = 10;
            this.toolStrip12.Text = "toolStrip12";
            // 
            // tsbAddIncapacity
            // 
            this.tsbAddIncapacity.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddIncapacity.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddIncapacity.Name = "tsbAddIncapacity";
            this.tsbAddIncapacity.Size = new System.Drawing.Size(119, 22);
            this.tsbAddIncapacity.Text = "Добавить запись";
            this.tsbAddIncapacity.Click += new System.EventHandler(this.tsbAddIncapacity_Click);
            // 
            // tsbEditIncapacity
            // 
            this.tsbEditIncapacity.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditIncapacity.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditIncapacity.Name = "tsbEditIncapacity";
            this.tsbEditIncapacity.Size = new System.Drawing.Size(107, 22);
            this.tsbEditIncapacity.Text = "Редактировать";
            this.tsbEditIncapacity.ToolTipText = "Редактировать запись";
            this.tsbEditIncapacity.Click += new System.EventHandler(this.tsbEditIncapacity_Click);
            // 
            // tsbDeleteIncapacity
            // 
            this.tsbDeleteIncapacity.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDeleteIncapacity.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteIncapacity.Name = "tsbDeleteIncapacity";
            this.tsbDeleteIncapacity.Size = new System.Drawing.Size(71, 22);
            this.tsbDeleteIncapacity.Text = "Удалить";
            this.tsbDeleteIncapacity.ToolTipText = "Удалить запись";
            this.tsbDeleteIncapacity.Click += new System.EventHandler(this.tsbDeleteIncapacity_Click);
            // 
            // tpBonus
            // 
            this.tpBonus.AutoScroll = true;
            this.tpBonus.Controls.Add(this.tableLayoutPanel1);
            this.tpBonus.Location = new System.Drawing.Point(4, 22);
            this.tpBonus.Name = "tpBonus";
            this.tpBonus.Padding = new System.Windows.Forms.Padding(3);
            this.tpBonus.Size = new System.Drawing.Size(802, 533);
            this.tpBonus.TabIndex = 2;
            this.tpBonus.Text = "Надбавки";
            this.tpBonus.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.AutoScroll = true;
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvAllBonus, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip3, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(796, 527);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvAllBonus
            // 
            this.dgvAllBonus.AllowUserToAddRows = false;
            this.dgvAllBonus.AllowUserToDeleteRows = false;
            this.dgvAllBonus.AutoGenerateColumns = false;
            this.dgvAllBonus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAllBonus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BonusLevel,
            this.BonusPost,
            this.dataGridViewTextBoxColumn1,
            this.BnLastFinancingSource,
            this.AllBonusCount,
            this.AllDateBegin,
            this.PrikazBegin,
            this.IntermediateDateEnd0,
            this.dataGridViewTextBoxColumn5,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn7});
            this.dgvAllBonus.DataSource = this.AllbonusBindingSource;
            this.dgvAllBonus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAllBonus.Location = new System.Drawing.Point(3, 28);
            this.dgvAllBonus.MultiSelect = false;
            this.dgvAllBonus.Name = "dgvAllBonus";
            this.dgvAllBonus.ReadOnly = true;
            this.dgvAllBonus.RowHeadersVisible = false;
            this.dgvAllBonus.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAllBonus.Size = new System.Drawing.Size(883, 496);
            this.dgvAllBonus.TabIndex = 9;
            this.dgvAllBonus.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvAllBonus_RowPrePaint);
            this.dgvAllBonus.DoubleClick += new System.EventHandler(this.dgvAllBonus_DoubleClick);
            // 
            // BonusLevel
            // 
            this.BonusLevel.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.BonusLevel.DataPropertyName = "BonusLevel";
            this.BonusLevel.HeaderText = "Уровень надбавки";
            this.BonusLevel.Name = "BonusLevel";
            this.BonusLevel.ReadOnly = true;
            this.BonusLevel.Width = 116;
            // 
            // BonusPost
            // 
            this.BonusPost.DataPropertyName = "Post";
            this.BonusPost.HeaderText = "Должность";
            this.BonusPost.Name = "BonusPost";
            this.BonusPost.ReadOnly = true;
            this.BonusPost.Width = 120;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BonusType";
            this.dataGridViewTextBoxColumn1.HeaderText = "Вид надбавки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 94;
            // 
            // BnLastFinancingSource
            // 
            this.BnLastFinancingSource.DataPropertyName = "LastFinancingSource";
            this.BnLastFinancingSource.HeaderText = "Ист фин-я";
            this.BnLastFinancingSource.Name = "BnLastFinancingSource";
            this.BnLastFinancingSource.ReadOnly = true;
            this.BnLastFinancingSource.Width = 65;
            // 
            // AllBonusCount
            // 
            this.AllBonusCount.DataPropertyName = "BonusCount";
            this.AllBonusCount.HeaderText = "Размер надбавки";
            this.AllBonusCount.Name = "AllBonusCount";
            this.AllBonusCount.ReadOnly = true;
            this.AllBonusCount.Width = 80;
            // 
            // AllDateBegin
            // 
            this.AllDateBegin.DataPropertyName = "DateBegin";
            this.AllDateBegin.HeaderText = "Дата назначения";
            this.AllDateBegin.Name = "AllDateBegin";
            this.AllDateBegin.ReadOnly = true;
            this.AllDateBegin.Width = 70;
            // 
            // PrikazBegin
            // 
            this.PrikazBegin.DataPropertyName = "PrikazBegin";
            this.PrikazBegin.HeaderText = "Приказ назначения";
            this.PrikazBegin.Name = "PrikazBegin";
            this.PrikazBegin.ReadOnly = true;
            this.PrikazBegin.Width = 110;
            // 
            // IntermediateDateEnd0
            // 
            this.IntermediateDateEnd0.DataPropertyName = "IntermediateDateEnd";
            this.IntermediateDateEnd0.HeaderText = "Пром. дата отмены";
            this.IntermediateDateEnd0.Name = "IntermediateDateEnd0";
            this.IntermediateDateEnd0.ReadOnly = true;
            this.IntermediateDateEnd0.Width = 70;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата отмены";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn6.HeaderText = "Приказ отмены";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 90;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn7.HeaderText = "Примечание";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // AllbonusBindingSource
            // 
            this.AllbonusBindingSource.DataSource = typeof(Kadr.Data.Bonus);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbBonusHistory,
            this.toolStripSeparator3,
            this.tsbBonusFilter});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(889, 25);
            this.toolStrip3.TabIndex = 7;
            this.toolStrip3.Text = "toolStrip3";
            this.toolStrip3.Visible = false;
            // 
            // tsbBonusHistory
            // 
            this.tsbBonusHistory.Image = global::Kadr.Properties.Resources.FillDownHS;
            this.tsbBonusHistory.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbBonusHistory.Name = "tsbBonusHistory";
            this.tsbBonusHistory.Size = new System.Drawing.Size(117, 22);
            this.tsbBonusHistory.Text = "Общая история ";
            this.tsbBonusHistory.Click += new System.EventHandler(this.tsbBonusHistory_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBonusFilter
            // 
            this.tsbBonusFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.текущиеToolStripMenuItem,
            this.отмененныеToolStripMenuItem});
            this.tsbBonusFilter.Image = global::Kadr.Properties.Resources.Filter2HS;
            this.tsbBonusFilter.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbBonusFilter.Name = "tsbBonusFilter";
            this.tsbBonusFilter.Size = new System.Drawing.Size(80, 22);
            this.tsbBonusFilter.Text = "Фильтр";
            this.tsbBonusFilter.ToolTipText = "Задать фильтр по надбавкам";
            this.tsbBonusFilter.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbBonusFilter_DropDownItemClicked);
            // 
            // текущиеToolStripMenuItem
            // 
            this.текущиеToolStripMenuItem.Checked = true;
            this.текущиеToolStripMenuItem.CheckOnClick = true;
            this.текущиеToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.текущиеToolStripMenuItem.Name = "текущиеToolStripMenuItem";
            this.текущиеToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.текущиеToolStripMenuItem.Text = "Текущие";
            // 
            // отмененныеToolStripMenuItem
            // 
            this.отмененныеToolStripMenuItem.CheckOnClick = true;
            this.отмененныеToolStripMenuItem.Name = "отмененныеToolStripMenuItem";
            this.отмененныеToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.отмененныеToolStripMenuItem.Text = "Отмененные";
            // 
            // tpEducation
            // 
            this.tpEducation.AutoScroll = true;
            this.tpEducation.Controls.Add(this.tcEducation);
            this.tpEducation.Location = new System.Drawing.Point(4, 22);
            this.tpEducation.Name = "tpEducation";
            this.tpEducation.Padding = new System.Windows.Forms.Padding(3);
            this.tpEducation.Size = new System.Drawing.Size(802, 533);
            this.tpEducation.TabIndex = 3;
            this.tpEducation.Text = "Образование";
            this.tpEducation.UseVisualStyleBackColor = true;
            // 
            // tcEducation
            // 
            this.tcEducation.Controls.Add(this.tpGrandEducation);
            this.tcEducation.Controls.Add(this.tpPostGradEduc);
            this.tcEducation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEducation.Location = new System.Drawing.Point(3, 3);
            this.tcEducation.Name = "tcEducation";
            this.tcEducation.SelectedIndex = 0;
            this.tcEducation.Size = new System.Drawing.Size(796, 527);
            this.tcEducation.TabIndex = 4;
            // 
            // tpGrandEducation
            // 
            this.tpGrandEducation.Controls.Add(this.groupBox2);
            this.tpGrandEducation.Controls.Add(this.dgvEducation);
            this.tpGrandEducation.Location = new System.Drawing.Point(4, 22);
            this.tpGrandEducation.Name = "tpGrandEducation";
            this.tpGrandEducation.Padding = new System.Windows.Forms.Padding(3);
            this.tpGrandEducation.Size = new System.Drawing.Size(788, 501);
            this.tpGrandEducation.TabIndex = 1;
            this.tpGrandEducation.Text = "Основное образование";
            this.tpGrandEducation.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(3, 311);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(782, 187);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Языки";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.AutoScroll = true;
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.Controls.Add(this.dataGridView9, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.toolStrip11, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.Size = new System.Drawing.Size(776, 168);
            this.tableLayoutPanel12.TabIndex = 3;
            // 
            // dataGridView9
            // 
            this.dataGridView9.AllowUserToAddRows = false;
            this.dataGridView9.AllowUserToDeleteRows = false;
            this.dataGridView9.AutoGenerateColumns = false;
            this.dataGridView9.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn73,
            this.dataGridViewTextBoxColumn74,
            this.dataGridViewTextBoxColumn75,
            this.dataGridViewTextBoxColumn76,
            this.dataGridViewTextBoxColumn77,
            this.dataGridViewTextBoxColumn78});
            this.dataGridView9.DataSource = this.employeeDegreeBindingSource;
            this.dataGridView9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView9.Location = new System.Drawing.Point(3, 28);
            this.dataGridView9.MultiSelect = false;
            this.dataGridView9.Name = "dataGridView9";
            this.dataGridView9.ReadOnly = true;
            this.dataGridView9.RowHeadersVisible = false;
            this.dataGridView9.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView9.Size = new System.Drawing.Size(877, 227);
            this.dataGridView9.TabIndex = 8;
            // 
            // dataGridViewTextBoxColumn73
            // 
            this.dataGridViewTextBoxColumn73.DataPropertyName = "Degree";
            this.dataGridViewTextBoxColumn73.HeaderText = "Ученая степень";
            this.dataGridViewTextBoxColumn73.Name = "dataGridViewTextBoxColumn73";
            this.dataGridViewTextBoxColumn73.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn74
            // 
            this.dataGridViewTextBoxColumn74.DataPropertyName = "ScienceType";
            this.dataGridViewTextBoxColumn74.HeaderText = "Науч. напр.";
            this.dataGridViewTextBoxColumn74.Name = "dataGridViewTextBoxColumn74";
            this.dataGridViewTextBoxColumn74.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn75
            // 
            this.dataGridViewTextBoxColumn75.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn75.DataPropertyName = "EducDocument";
            this.dataGridViewTextBoxColumn75.HeaderText = "Данные диплома";
            this.dataGridViewTextBoxColumn75.Name = "dataGridViewTextBoxColumn75";
            this.dataGridViewTextBoxColumn75.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn76
            // 
            this.dataGridViewTextBoxColumn76.DataPropertyName = "DissertCouncil";
            this.dataGridViewTextBoxColumn76.HeaderText = "Диссерт совет";
            this.dataGridViewTextBoxColumn76.Name = "dataGridViewTextBoxColumn76";
            this.dataGridViewTextBoxColumn76.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn77
            // 
            this.dataGridViewTextBoxColumn77.DataPropertyName = "degreeDate";
            this.dataGridViewTextBoxColumn77.HeaderText = "Дата присвоения степени";
            this.dataGridViewTextBoxColumn77.Name = "dataGridViewTextBoxColumn77";
            this.dataGridViewTextBoxColumn77.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn78
            // 
            this.dataGridViewTextBoxColumn78.DataPropertyName = "diplWhere";
            this.dataGridViewTextBoxColumn78.HeaderText = "Диплом выдан";
            this.dataGridViewTextBoxColumn78.Name = "dataGridViewTextBoxColumn78";
            this.dataGridViewTextBoxColumn78.ReadOnly = true;
            // 
            // employeeDegreeBindingSource
            // 
            this.employeeDegreeBindingSource.DataSource = typeof(Kadr.Data.EmployeeDegree);
            // 
            // toolStrip11
            // 
            this.toolStrip11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton3});
            this.toolStrip11.Location = new System.Drawing.Point(0, 0);
            this.toolStrip11.Name = "toolStrip11";
            this.toolStrip11.Size = new System.Drawing.Size(883, 25);
            this.toolStrip11.TabIndex = 7;
            this.toolStrip11.Text = "toolStrip11";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(108, 22);
            this.toolStripButton1.Text = "Добавить язык";
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(107, 22);
            this.toolStripButton2.Text = "Редактировать";
            this.toolStripButton2.ToolTipText = "Редактировать степень";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(71, 22);
            this.toolStripButton3.Text = "Удалить";
            this.toolStripButton3.ToolTipText = "Удалить степень";
            // 
            // dgvEducation
            // 
            this.dgvEducation.AllowUserToAddRows = false;
            this.dgvEducation.AllowUserToDeleteRows = false;
            this.dgvEducation.AutoGenerateColumns = false;
            this.dgvEducation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn67,
            this.dataGridViewTextBoxColumn68,
            this.dataGridViewTextBoxColumn69,
            this.dataGridViewTextBoxColumn70,
            this.dataGridViewTextBoxColumn71,
            this.dataGridViewTextBoxColumn72});
            this.dgvEducation.DataSource = this.employeeDegreeBindingSource;
            this.dgvEducation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEducation.Location = new System.Drawing.Point(3, 3);
            this.dgvEducation.MultiSelect = false;
            this.dgvEducation.Name = "dgvEducation";
            this.dgvEducation.ReadOnly = true;
            this.dgvEducation.RowHeadersVisible = false;
            this.dgvEducation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEducation.Size = new System.Drawing.Size(782, 495);
            this.dgvEducation.TabIndex = 9;
            // 
            // dataGridViewTextBoxColumn67
            // 
            this.dataGridViewTextBoxColumn67.DataPropertyName = "Degree";
            this.dataGridViewTextBoxColumn67.HeaderText = "Ученая степень";
            this.dataGridViewTextBoxColumn67.Name = "dataGridViewTextBoxColumn67";
            this.dataGridViewTextBoxColumn67.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn68
            // 
            this.dataGridViewTextBoxColumn68.DataPropertyName = "ScienceType";
            this.dataGridViewTextBoxColumn68.HeaderText = "Науч. напр.";
            this.dataGridViewTextBoxColumn68.Name = "dataGridViewTextBoxColumn68";
            this.dataGridViewTextBoxColumn68.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn69
            // 
            this.dataGridViewTextBoxColumn69.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn69.DataPropertyName = "EducDocument";
            this.dataGridViewTextBoxColumn69.HeaderText = "Данные диплома";
            this.dataGridViewTextBoxColumn69.Name = "dataGridViewTextBoxColumn69";
            this.dataGridViewTextBoxColumn69.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn70
            // 
            this.dataGridViewTextBoxColumn70.DataPropertyName = "DissertCouncil";
            this.dataGridViewTextBoxColumn70.HeaderText = "Диссерт совет";
            this.dataGridViewTextBoxColumn70.Name = "dataGridViewTextBoxColumn70";
            this.dataGridViewTextBoxColumn70.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn71
            // 
            this.dataGridViewTextBoxColumn71.DataPropertyName = "degreeDate";
            this.dataGridViewTextBoxColumn71.HeaderText = "Дата присвоения степени";
            this.dataGridViewTextBoxColumn71.Name = "dataGridViewTextBoxColumn71";
            this.dataGridViewTextBoxColumn71.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn72
            // 
            this.dataGridViewTextBoxColumn72.DataPropertyName = "diplWhere";
            this.dataGridViewTextBoxColumn72.HeaderText = "Диплом выдан";
            this.dataGridViewTextBoxColumn72.Name = "dataGridViewTextBoxColumn72";
            this.dataGridViewTextBoxColumn72.ReadOnly = true;
            // 
            // tpPostGradEduc
            // 
            this.tpPostGradEduc.Controls.Add(this.splitContainer2);
            this.tpPostGradEduc.Location = new System.Drawing.Point(4, 22);
            this.tpPostGradEduc.Name = "tpPostGradEduc";
            this.tpPostGradEduc.Padding = new System.Windows.Forms.Padding(3);
            this.tpPostGradEduc.Size = new System.Drawing.Size(869, 339);
            this.tpPostGradEduc.TabIndex = 0;
            this.tpPostGradEduc.Text = "Послевузовское";
            this.tpPostGradEduc.UseVisualStyleBackColor = true;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(3, 3);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.groupBox4);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.groupBox5);
            this.splitContainer2.Size = new System.Drawing.Size(863, 333);
            this.splitContainer2.SplitterDistance = 155;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(863, 155);
            this.groupBox4.TabIndex = 2;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Ученые степени";
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.AutoScroll = true;
            this.tableLayoutPanel3.ColumnCount = 1;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel3.Controls.Add(this.dataGridView2, 0, 1);
            this.tableLayoutPanel3.Controls.Add(this.toolStrip4, 0, 0);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel3.Size = new System.Drawing.Size(857, 136);
            this.tableLayoutPanel3.TabIndex = 3;
            // 
            // dataGridView2
            // 
            this.dataGridView2.AllowUserToAddRows = false;
            this.dataGridView2.AllowUserToDeleteRows = false;
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.degreeDataGridViewTextBoxColumn,
            this.scienceTypeDataGridViewTextBoxColumn,
            this.educDocumentDataGridViewTextBoxColumn,
            this.dissertCouncilDataGridViewTextBoxColumn,
            this.degreeDateDataGridViewTextBoxColumn,
            this.diplWhereDataGridViewTextBoxColumn});
            this.dataGridView2.DataSource = this.employeeDegreeBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(3, 28);
            this.dataGridView2.MultiSelect = false;
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.ReadOnly = true;
            this.dataGridView2.RowHeadersVisible = false;
            this.dataGridView2.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView2.Size = new System.Drawing.Size(877, 227);
            this.dataGridView2.TabIndex = 8;
            this.dataGridView2.DoubleClick += new System.EventHandler(this.EditDegreeBtn_Click);
            // 
            // degreeDataGridViewTextBoxColumn
            // 
            this.degreeDataGridViewTextBoxColumn.DataPropertyName = "Degree";
            this.degreeDataGridViewTextBoxColumn.HeaderText = "Ученая степень";
            this.degreeDataGridViewTextBoxColumn.Name = "degreeDataGridViewTextBoxColumn";
            this.degreeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // scienceTypeDataGridViewTextBoxColumn
            // 
            this.scienceTypeDataGridViewTextBoxColumn.DataPropertyName = "ScienceType";
            this.scienceTypeDataGridViewTextBoxColumn.HeaderText = "Науч. напр.";
            this.scienceTypeDataGridViewTextBoxColumn.Name = "scienceTypeDataGridViewTextBoxColumn";
            this.scienceTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // educDocumentDataGridViewTextBoxColumn
            // 
            this.educDocumentDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.educDocumentDataGridViewTextBoxColumn.DataPropertyName = "EducDocument";
            this.educDocumentDataGridViewTextBoxColumn.HeaderText = "Данные диплома";
            this.educDocumentDataGridViewTextBoxColumn.Name = "educDocumentDataGridViewTextBoxColumn";
            this.educDocumentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dissertCouncilDataGridViewTextBoxColumn
            // 
            this.dissertCouncilDataGridViewTextBoxColumn.DataPropertyName = "DissertCouncil";
            this.dissertCouncilDataGridViewTextBoxColumn.HeaderText = "Диссерт совет";
            this.dissertCouncilDataGridViewTextBoxColumn.Name = "dissertCouncilDataGridViewTextBoxColumn";
            this.dissertCouncilDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // degreeDateDataGridViewTextBoxColumn
            // 
            this.degreeDateDataGridViewTextBoxColumn.DataPropertyName = "degreeDate";
            this.degreeDateDataGridViewTextBoxColumn.HeaderText = "Дата присвоения степени";
            this.degreeDateDataGridViewTextBoxColumn.Name = "degreeDateDataGridViewTextBoxColumn";
            this.degreeDateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // diplWhereDataGridViewTextBoxColumn
            // 
            this.diplWhereDataGridViewTextBoxColumn.DataPropertyName = "diplWhere";
            this.diplWhereDataGridViewTextBoxColumn.HeaderText = "Диплом выдан";
            this.diplWhereDataGridViewTextBoxColumn.Name = "diplWhereDataGridViewTextBoxColumn";
            this.diplWhereDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // toolStrip4
            // 
            this.toolStrip4.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDegreeBtn,
            this.EditDegreeBtn,
            this.DelDegreeBtn});
            this.toolStrip4.Location = new System.Drawing.Point(0, 0);
            this.toolStrip4.Name = "toolStrip4";
            this.toolStrip4.Size = new System.Drawing.Size(883, 25);
            this.toolStrip4.TabIndex = 7;
            this.toolStrip4.Text = "toolStrip4";
            // 
            // AddDegreeBtn
            // 
            this.AddDegreeBtn.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.AddDegreeBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddDegreeBtn.Name = "AddDegreeBtn";
            this.AddDegreeBtn.Size = new System.Drawing.Size(125, 22);
            this.AddDegreeBtn.Text = "Добавить степень";
            this.AddDegreeBtn.Click += new System.EventHandler(this.AddDegreeBtn_Click);
            // 
            // EditDegreeBtn
            // 
            this.EditDegreeBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditDegreeBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditDegreeBtn.Name = "EditDegreeBtn";
            this.EditDegreeBtn.Size = new System.Drawing.Size(107, 22);
            this.EditDegreeBtn.Text = "Редактировать";
            this.EditDegreeBtn.ToolTipText = "Редактировать степень";
            this.EditDegreeBtn.Click += new System.EventHandler(this.EditDegreeBtn_Click);
            // 
            // DelDegreeBtn
            // 
            this.DelDegreeBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DelDegreeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelDegreeBtn.Name = "DelDegreeBtn";
            this.DelDegreeBtn.Size = new System.Drawing.Size(71, 22);
            this.DelDegreeBtn.Text = "Удалить";
            this.DelDegreeBtn.ToolTipText = "Удалить степень";
            this.DelDegreeBtn.Click += new System.EventHandler(this.DelDegreeBtn_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.tableLayoutPanel4);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox5.Location = new System.Drawing.Point(0, 0);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(863, 174);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Научные звания";
            // 
            // tableLayoutPanel4
            // 
            this.tableLayoutPanel4.AutoScroll = true;
            this.tableLayoutPanel4.ColumnCount = 1;
            this.tableLayoutPanel4.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel4.Controls.Add(this.dataGridView3, 0, 1);
            this.tableLayoutPanel4.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel4.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel4.Name = "tableLayoutPanel4";
            this.tableLayoutPanel4.RowCount = 2;
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel4.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel4.Size = new System.Drawing.Size(857, 155);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoGenerateColumns = false;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rankDataGridViewTextBoxColumn,
            this.educDocumentDataGridViewTextBoxColumn1,
            this.rankWhereDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.employeeRankBindingSource;
            this.dataGridView3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView3.Location = new System.Drawing.Point(3, 28);
            this.dataGridView3.MultiSelect = false;
            this.dataGridView3.Name = "dataGridView3";
            this.dataGridView3.ReadOnly = true;
            this.dataGridView3.RowHeadersVisible = false;
            this.dataGridView3.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView3.Size = new System.Drawing.Size(877, 222);
            this.dataGridView3.TabIndex = 8;
            this.dataGridView3.DoubleClick += new System.EventHandler(this.EditRankBtn_Click);
            // 
            // rankDataGridViewTextBoxColumn
            // 
            this.rankDataGridViewTextBoxColumn.DataPropertyName = "Rank";
            this.rankDataGridViewTextBoxColumn.HeaderText = "Ученое звание";
            this.rankDataGridViewTextBoxColumn.MinimumWidth = 200;
            this.rankDataGridViewTextBoxColumn.Name = "rankDataGridViewTextBoxColumn";
            this.rankDataGridViewTextBoxColumn.ReadOnly = true;
            this.rankDataGridViewTextBoxColumn.Width = 200;
            // 
            // educDocumentDataGridViewTextBoxColumn1
            // 
            this.educDocumentDataGridViewTextBoxColumn1.DataPropertyName = "EducDocument";
            this.educDocumentDataGridViewTextBoxColumn1.HeaderText = "Данные диплома";
            this.educDocumentDataGridViewTextBoxColumn1.MinimumWidth = 200;
            this.educDocumentDataGridViewTextBoxColumn1.Name = "educDocumentDataGridViewTextBoxColumn1";
            this.educDocumentDataGridViewTextBoxColumn1.ReadOnly = true;
            this.educDocumentDataGridViewTextBoxColumn1.Width = 200;
            // 
            // rankWhereDataGridViewTextBoxColumn
            // 
            this.rankWhereDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.rankWhereDataGridViewTextBoxColumn.DataPropertyName = "rankWhere";
            this.rankWhereDataGridViewTextBoxColumn.HeaderText = "Звание утверждено";
            this.rankWhereDataGridViewTextBoxColumn.Name = "rankWhereDataGridViewTextBoxColumn";
            this.rankWhereDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeRankBindingSource
            // 
            this.employeeRankBindingSource.DataSource = typeof(Kadr.Data.EmployeeRank);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddRankBtn,
            this.EditRankBtn,
            this.DelRankBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(883, 25);
            this.toolStrip1.TabIndex = 7;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddRankBtn
            // 
            this.AddRankBtn.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.AddRankBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddRankBtn.Name = "AddRankBtn";
            this.AddRankBtn.Size = new System.Drawing.Size(119, 22);
            this.AddRankBtn.Text = "Добавить звание";
            this.AddRankBtn.Click += new System.EventHandler(this.AddRankBtn_Click);
            // 
            // EditRankBtn
            // 
            this.EditRankBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditRankBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditRankBtn.Name = "EditRankBtn";
            this.EditRankBtn.Size = new System.Drawing.Size(107, 22);
            this.EditRankBtn.Text = "Редактировать";
            this.EditRankBtn.ToolTipText = "Редактировать звание";
            this.EditRankBtn.Click += new System.EventHandler(this.EditRankBtn_Click);
            // 
            // DelRankBtn
            // 
            this.DelRankBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DelRankBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelRankBtn.Name = "DelRankBtn";
            this.DelRankBtn.Size = new System.Drawing.Size(71, 22);
            this.DelRankBtn.Text = "Удалить";
            this.DelRankBtn.ToolTipText = "Удалить звание";
            this.DelRankBtn.Click += new System.EventHandler(this.DelRankBtn_Click);
            // 
            // tpEmplBonusReport
            // 
            this.tpEmplBonusReport.Controls.Add(this.btnBonusRepLoad);
            this.tpEmplBonusReport.Controls.Add(this.dtpBonRepPeriodEnd);
            this.tpEmplBonusReport.Controls.Add(this.label1);
            this.tpEmplBonusReport.Controls.Add(this.dtpBonRepPeriodBegin);
            this.tpEmplBonusReport.Controls.Add(this.tableLayoutPanel6);
            this.tpEmplBonusReport.Location = new System.Drawing.Point(4, 22);
            this.tpEmplBonusReport.Name = "tpEmplBonusReport";
            this.tpEmplBonusReport.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmplBonusReport.Size = new System.Drawing.Size(802, 533);
            this.tpEmplBonusReport.TabIndex = 4;
            this.tpEmplBonusReport.Text = "Отчет по надбавкам";
            this.tpEmplBonusReport.UseVisualStyleBackColor = true;
            // 
            // btnBonusRepLoad
            // 
            this.btnBonusRepLoad.Enabled = false;
            this.btnBonusRepLoad.Location = new System.Drawing.Point(460, 3);
            this.btnBonusRepLoad.Name = "btnBonusRepLoad";
            this.btnBonusRepLoad.Size = new System.Drawing.Size(132, 23);
            this.btnBonusRepLoad.TabIndex = 21;
            this.btnBonusRepLoad.Text = "Загрузить отчет";
            this.btnBonusRepLoad.UseVisualStyleBackColor = true;
            this.btnBonusRepLoad.Click += new System.EventHandler(this.btnBonusRepLoad_Click);
            // 
            // dtpBonRepPeriodEnd
            // 
            this.dtpBonRepPeriodEnd.Location = new System.Drawing.Point(317, 7);
            this.dtpBonRepPeriodEnd.Name = "dtpBonRepPeriodEnd";
            this.dtpBonRepPeriodEnd.Size = new System.Drawing.Size(137, 20);
            this.dtpBonRepPeriodEnd.TabIndex = 20;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(292, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(19, 13);
            this.label1.TabIndex = 19;
            this.label1.Text = "до";
            // 
            // dtpBonRepPeriodBegin
            // 
            this.dtpBonRepPeriodBegin.Location = new System.Drawing.Point(150, 6);
            this.dtpBonRepPeriodBegin.Name = "dtpBonRepPeriodBegin";
            this.dtpBonRepPeriodBegin.Size = new System.Drawing.Size(137, 20);
            this.dtpBonRepPeriodBegin.TabIndex = 18;
            // 
            // tableLayoutPanel6
            // 
            this.tableLayoutPanel6.AutoScroll = true;
            this.tableLayoutPanel6.ColumnCount = 1;
            this.tableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel6.Controls.Add(this.toolStrip6, 0, 0);
            this.tableLayoutPanel6.Controls.Add(this.employeeBonusReportFrame1, 0, 1);
            this.tableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel6.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel6.Name = "tableLayoutPanel6";
            this.tableLayoutPanel6.RowCount = 2;
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel6.Size = new System.Drawing.Size(796, 527);
            this.tableLayoutPanel6.TabIndex = 22;
            // 
            // toolStrip6
            // 
            this.toolStrip6.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel2});
            this.toolStrip6.Location = new System.Drawing.Point(0, 0);
            this.toolStrip6.Name = "toolStrip6";
            this.toolStrip6.Size = new System.Drawing.Size(877, 24);
            this.toolStrip6.TabIndex = 17;
            this.toolStrip6.Text = "toolStrip6";
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(133, 21);
            this.toolStripLabel2.Text = "Период начисления от";
            // 
            // employeeBonusReportFrame1
            // 
            this.employeeBonusReportFrame1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.employeeBonusReportFrame1.Location = new System.Drawing.Point(3, 27);
            this.employeeBonusReportFrame1.Name = "employeeBonusReportFrame1";
            this.employeeBonusReportFrame1.PeriodBegin = new System.DateTime(((long)(0)));
            this.employeeBonusReportFrame1.PeriodEnd = new System.DateTime(((long)(0)));
            this.employeeBonusReportFrame1.ReportNumber = 0;
            this.employeeBonusReportFrame1.ReportParam = -1;
            this.employeeBonusReportFrame1.ReportType = null;
            this.employeeBonusReportFrame1.Size = new System.Drawing.Size(871, 497);
            this.employeeBonusReportFrame1.TabIndex = 18;
            this.employeeBonusReportFrame1.WithSubReports = true;
            // 
            // tpDopInf
            // 
            this.tpDopInf.Controls.Add(this.tableLayoutPanel11);
            this.tpDopInf.Location = new System.Drawing.Point(4, 22);
            this.tpDopInf.Name = "tpDopInf";
            this.tpDopInf.Size = new System.Drawing.Size(883, 371);
            this.tpDopInf.TabIndex = 5;
            this.tpDopInf.Text = "Дополнительные сведения";
            this.tpDopInf.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel11
            // 
            this.tableLayoutPanel11.ColumnCount = 1;
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel11.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel11.Controls.Add(this.dataGridView8, 0, 1);
            this.tableLayoutPanel11.Controls.Add(this.toolStrip10, 0, 0);
            this.tableLayoutPanel11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel11.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel11.Name = "tableLayoutPanel11";
            this.tableLayoutPanel11.RowCount = 2;
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel11.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel11.Size = new System.Drawing.Size(883, 371);
            this.tableLayoutPanel11.TabIndex = 3;
            // 
            // dataGridView8
            // 
            this.dataGridView8.AllowUserToAddRows = false;
            this.dataGridView8.AllowUserToDeleteRows = false;
            this.dataGridView8.AutoGenerateColumns = false;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDopInfDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn4,
            this.dopInfDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn4});
            this.dataGridView8.DataSource = this.oKDopInfBindingSource;
            this.dataGridView8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView8.Location = new System.Drawing.Point(3, 28);
            this.dataGridView8.MultiSelect = false;
            this.dataGridView8.Name = "dataGridView8";
            this.dataGridView8.ReadOnly = true;
            this.dataGridView8.RowHeadersVisible = false;
            this.dataGridView8.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView8.Size = new System.Drawing.Size(877, 502);
            this.dataGridView8.TabIndex = 9;
            this.dataGridView8.DoubleClick += new System.EventHandler(this.tsbEditDopInf_Click);
            // 
            // idDopInfDataGridViewTextBoxColumn
            // 
            this.idDopInfDataGridViewTextBoxColumn.DataPropertyName = "idDopInf";
            this.idDopInfDataGridViewTextBoxColumn.HeaderText = "idDopInf";
            this.idDopInfDataGridViewTextBoxColumn.Name = "idDopInfDataGridViewTextBoxColumn";
            this.idDopInfDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDopInfDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEmployeeDataGridViewTextBoxColumn4
            // 
            this.idEmployeeDataGridViewTextBoxColumn4.DataPropertyName = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn4.HeaderText = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn4.Name = "idEmployeeDataGridViewTextBoxColumn4";
            this.idEmployeeDataGridViewTextBoxColumn4.ReadOnly = true;
            this.idEmployeeDataGridViewTextBoxColumn4.Visible = false;
            // 
            // dopInfDataGridViewTextBoxColumn
            // 
            this.dopInfDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dopInfDataGridViewTextBoxColumn.DataPropertyName = "DopInf";
            this.dopInfDataGridViewTextBoxColumn.HeaderText = "Дополнительная информация";
            this.dopInfDataGridViewTextBoxColumn.Name = "dopInfDataGridViewTextBoxColumn";
            this.dopInfDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeDataGridViewTextBoxColumn4
            // 
            this.employeeDataGridViewTextBoxColumn4.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn4.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn4.Name = "employeeDataGridViewTextBoxColumn4";
            this.employeeDataGridViewTextBoxColumn4.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn4.Visible = false;
            // 
            // oKDopInfBindingSource
            // 
            this.oKDopInfBindingSource.DataSource = typeof(Kadr.Data.OK_DopInf);
            // 
            // toolStrip10
            // 
            this.toolStrip10.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddDopInf,
            this.tsbEditDopInf,
            this.tsbDelDopInf});
            this.toolStrip10.Location = new System.Drawing.Point(0, 0);
            this.toolStrip10.Name = "toolStrip10";
            this.toolStrip10.Size = new System.Drawing.Size(883, 25);
            this.toolStrip10.TabIndex = 0;
            this.toolStrip10.Text = "toolStrip10";
            // 
            // tsbAddDopInf
            // 
            this.tsbAddDopInf.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddDopInf.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddDopInf.Name = "tsbAddDopInf";
            this.tsbAddDopInf.Size = new System.Drawing.Size(119, 22);
            this.tsbAddDopInf.Text = "Добавить запись";
            this.tsbAddDopInf.Click += new System.EventHandler(this.tsbAddDopInf_Click);
            // 
            // tsbEditDopInf
            // 
            this.tsbEditDopInf.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditDopInf.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditDopInf.Name = "tsbEditDopInf";
            this.tsbEditDopInf.Size = new System.Drawing.Size(107, 22);
            this.tsbEditDopInf.Text = "Редактировать";
            this.tsbEditDopInf.ToolTipText = "Редактировать запись";
            this.tsbEditDopInf.Click += new System.EventHandler(this.tsbEditDopInf_Click);
            // 
            // tsbDelDopInf
            // 
            this.tsbDelDopInf.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelDopInf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelDopInf.Name = "tsbDelDopInf";
            this.tsbDelDopInf.Size = new System.Drawing.Size(71, 22);
            this.tsbDelDopInf.Text = "Удалить";
            this.tsbDelDopInf.ToolTipText = "Удалить запись";
            this.tsbDelDopInf.Click += new System.EventHandler(this.tsbDelDopInf_Click);
            // 
            // materialResponsibilityDecoratorBindingSource
            // 
            this.materialResponsibilityDecoratorBindingSource.DataSource = typeof(Kadr.Data.MaterialResponsibilityDecorator);
            // 
            // bonusReportColumnBindingSource
            // 
            this.bonusReportColumnBindingSource.DataSource = typeof(Kadr.Data.BonusReportColumn);
            // 
            // bonusTypeBindingSource
            // 
            this.bonusTypeBindingSource.DataSource = typeof(Kadr.Data.BonusType);
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "FinSource";
            this.dataGridViewTextBoxColumn8.HeaderText = "Ист фин";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 45;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn10.HeaderText = "Приказ";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 140;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn12.HeaderText = "Дата окончания";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 50;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn13.HeaderText = "Дата назн.";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            this.dataGridViewTextBoxColumn13.Width = 70;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "PrikazBegin";
            this.dataGridViewTextBoxColumn14.HeaderText = "Приказ назн.";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            this.dataGridViewTextBoxColumn14.Width = 55;
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn15.HeaderText = "Дата увольн";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            this.dataGridViewTextBoxColumn15.ReadOnly = true;
            this.dataGridViewTextBoxColumn15.Width = 70;
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn16.HeaderText = "Приказ увольн";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            this.dataGridViewTextBoxColumn16.ReadOnly = true;
            this.dataGridViewTextBoxColumn16.Width = 55;
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn20.DataPropertyName = "OK_Otpuskvid";
            this.dataGridViewTextBoxColumn20.HeaderText = "Вид отпуска";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            this.dataGridViewTextBoxColumn20.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn21
            // 
            this.dataGridViewTextBoxColumn21.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn21.HeaderText = "Приказ";
            this.dataGridViewTextBoxColumn21.Name = "dataGridViewTextBoxColumn21";
            this.dataGridViewTextBoxColumn21.ReadOnly = true;
            this.dataGridViewTextBoxColumn21.Width = 140;
            // 
            // dataGridViewTextBoxColumn22
            // 
            this.dataGridViewTextBoxColumn22.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn22.HeaderText = "Дата начала";
            this.dataGridViewTextBoxColumn22.Name = "dataGridViewTextBoxColumn22";
            this.dataGridViewTextBoxColumn22.ReadOnly = true;
            this.dataGridViewTextBoxColumn22.Width = 70;
            // 
            // dataGridViewTextBoxColumn23
            // 
            this.dataGridViewTextBoxColumn23.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn23.HeaderText = "Дата окончания";
            this.dataGridViewTextBoxColumn23.Name = "dataGridViewTextBoxColumn23";
            this.dataGridViewTextBoxColumn23.ReadOnly = true;
            this.dataGridViewTextBoxColumn23.Width = 50;
            // 
            // dataGridViewTextBoxColumn24
            // 
            this.dataGridViewTextBoxColumn24.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn24.HeaderText = "Приказ";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            this.dataGridViewTextBoxColumn24.ReadOnly = true;
            this.dataGridViewTextBoxColumn24.Visible = false;
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn25.HeaderText = "Дата начала";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            this.dataGridViewTextBoxColumn25.ReadOnly = true;
            this.dataGridViewTextBoxColumn25.Width = 130;
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn26.HeaderText = "Дата окончания";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            this.dataGridViewTextBoxColumn26.ReadOnly = true;
            this.dataGridViewTextBoxColumn26.Width = 130;
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn27.DataPropertyName = "TargetPlace";
            this.dataGridViewTextBoxColumn27.HeaderText = "Место назначения";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            this.dataGridViewTextBoxColumn27.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "FinSource";
            this.dataGridViewTextBoxColumn28.HeaderText = "Источник финансирования";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            this.dataGridViewTextBoxColumn28.ReadOnly = true;
            this.dataGridViewTextBoxColumn28.Width = 130;
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn29.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn29.HeaderText = "id";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            this.dataGridViewTextBoxColumn29.ReadOnly = true;
            this.dataGridViewTextBoxColumn29.Visible = false;
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "idFactStaffPrikaz";
            this.dataGridViewTextBoxColumn30.HeaderText = "idFactStaffPrikaz";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Visible = false;
            this.dataGridViewTextBoxColumn30.Width = 130;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "idContract";
            this.dataGridViewTextBoxColumn31.HeaderText = "idContract";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Visible = false;
            this.dataGridViewTextBoxColumn31.Width = 130;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn32.DataPropertyName = "Sum";
            this.dataGridViewTextBoxColumn32.HeaderText = "Sum";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Visible = false;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Contract";
            this.dataGridViewTextBoxColumn33.HeaderText = "Contract";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            this.dataGridViewTextBoxColumn33.Visible = false;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "FactStaffPrikaz";
            this.dataGridViewTextBoxColumn34.HeaderText = "FactStaffPrikaz";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Visible = false;
            this.dataGridViewTextBoxColumn34.Width = 130;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn35.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn35.HeaderText = "id";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            this.dataGridViewTextBoxColumn35.Visible = false;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "RegionType";
            this.dataGridViewTextBoxColumn36.HeaderText = "Тип региона";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Visible = false;
            this.dataGridViewTextBoxColumn36.Width = 130;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn37.DataPropertyName = "StandingType";
            this.dataGridViewTextBoxColumn37.HeaderText = "Тип стажа";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            this.dataGridViewTextBoxColumn37.Visible = false;
            // 
            // dataGridViewTextBoxColumn38
            // 
            this.dataGridViewTextBoxColumn38.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn38.DataPropertyName = "WorkPlace";
            this.dataGridViewTextBoxColumn38.HeaderText = "Место работы";
            this.dataGridViewTextBoxColumn38.Name = "dataGridViewTextBoxColumn38";
            this.dataGridViewTextBoxColumn38.ReadOnly = true;
            this.dataGridViewTextBoxColumn38.Visible = false;
            // 
            // dataGridViewTextBoxColumn39
            // 
            this.dataGridViewTextBoxColumn39.DataPropertyName = "Post";
            this.dataGridViewTextBoxColumn39.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn39.Name = "dataGridViewTextBoxColumn39";
            this.dataGridViewTextBoxColumn39.ReadOnly = true;
            this.dataGridViewTextBoxColumn39.Visible = false;
            this.dataGridViewTextBoxColumn39.Width = 130;
            // 
            // dataGridViewTextBoxColumn40
            // 
            this.dataGridViewTextBoxColumn40.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn40.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn40.HeaderText = "Дата приема";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Visible = false;
            // 
            // dataGridViewTextBoxColumn41
            // 
            this.dataGridViewTextBoxColumn41.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn41.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn41.HeaderText = "Дата увольнения";
            this.dataGridViewTextBoxColumn41.Name = "dataGridViewTextBoxColumn41";
            this.dataGridViewTextBoxColumn41.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn42
            // 
            this.dataGridViewTextBoxColumn42.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn42.DataPropertyName = "idRegionType";
            this.dataGridViewTextBoxColumn42.HeaderText = "idRegionType";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Visible = false;
            // 
            // dataGridViewTextBoxColumn43
            // 
            this.dataGridViewTextBoxColumn43.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn43.DataPropertyName = "idStandingType";
            this.dataGridViewTextBoxColumn43.HeaderText = "idStandingType";
            this.dataGridViewTextBoxColumn43.Name = "dataGridViewTextBoxColumn43";
            this.dataGridViewTextBoxColumn43.ReadOnly = true;
            this.dataGridViewTextBoxColumn43.Visible = false;
            // 
            // dataGridViewTextBoxColumn44
            // 
            this.dataGridViewTextBoxColumn44.DataPropertyName = "idEmployee";
            this.dataGridViewTextBoxColumn44.HeaderText = "idEmployee";
            this.dataGridViewTextBoxColumn44.Name = "dataGridViewTextBoxColumn44";
            this.dataGridViewTextBoxColumn44.ReadOnly = true;
            this.dataGridViewTextBoxColumn44.Visible = false;
            this.dataGridViewTextBoxColumn44.Width = 65;
            // 
            // dataGridViewTextBoxColumn45
            // 
            this.dataGridViewTextBoxColumn45.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn45.DataPropertyName = "Employee";
            this.dataGridViewTextBoxColumn45.HeaderText = "Employee";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            this.dataGridViewTextBoxColumn45.Visible = false;
            // 
            // dataGridViewTextBoxColumn46
            // 
            this.dataGridViewTextBoxColumn46.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn46.DataPropertyName = "BonusLevel";
            this.dataGridViewTextBoxColumn46.HeaderText = "Уровень надбавки";
            this.dataGridViewTextBoxColumn46.Name = "dataGridViewTextBoxColumn46";
            this.dataGridViewTextBoxColumn46.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn47
            // 
            this.dataGridViewTextBoxColumn47.DataPropertyName = "Post";
            this.dataGridViewTextBoxColumn47.HeaderText = "Должность";
            this.dataGridViewTextBoxColumn47.Name = "dataGridViewTextBoxColumn47";
            this.dataGridViewTextBoxColumn47.ReadOnly = true;
            this.dataGridViewTextBoxColumn47.Width = 120;
            // 
            // dataGridViewTextBoxColumn48
            // 
            this.dataGridViewTextBoxColumn48.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn48.DataPropertyName = "BonusType";
            this.dataGridViewTextBoxColumn48.HeaderText = "Вид надбавки";
            this.dataGridViewTextBoxColumn48.Name = "dataGridViewTextBoxColumn48";
            this.dataGridViewTextBoxColumn48.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn49
            // 
            this.dataGridViewTextBoxColumn49.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn49.DataPropertyName = "LastFinancingSource";
            this.dataGridViewTextBoxColumn49.HeaderText = "Ист фин-я";
            this.dataGridViewTextBoxColumn49.Name = "dataGridViewTextBoxColumn49";
            this.dataGridViewTextBoxColumn49.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn50
            // 
            this.dataGridViewTextBoxColumn50.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn50.DataPropertyName = "BonusCount";
            this.dataGridViewTextBoxColumn50.HeaderText = "Размер надбавки";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn51
            // 
            this.dataGridViewTextBoxColumn51.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn51.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn51.HeaderText = "Дата назначения";
            this.dataGridViewTextBoxColumn51.Name = "dataGridViewTextBoxColumn51";
            this.dataGridViewTextBoxColumn51.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn52
            // 
            this.dataGridViewTextBoxColumn52.DataPropertyName = "PrikazBegin";
            this.dataGridViewTextBoxColumn52.HeaderText = "Приказ назначения";
            this.dataGridViewTextBoxColumn52.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.ReadOnly = true;
            this.dataGridViewTextBoxColumn52.Width = 200;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn53.DataPropertyName = "IntermediateDateEnd";
            this.dataGridViewTextBoxColumn53.HeaderText = "Пром. дата отмены";
            this.dataGridViewTextBoxColumn53.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn54
            // 
            this.dataGridViewTextBoxColumn54.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn54.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn54.HeaderText = "Дата отмены";
            this.dataGridViewTextBoxColumn54.Name = "dataGridViewTextBoxColumn54";
            this.dataGridViewTextBoxColumn54.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn55
            // 
            this.dataGridViewTextBoxColumn55.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn55.HeaderText = "Приказ отмены";
            this.dataGridViewTextBoxColumn55.Name = "dataGridViewTextBoxColumn55";
            this.dataGridViewTextBoxColumn55.ReadOnly = true;
            this.dataGridViewTextBoxColumn55.Width = 90;
            // 
            // dataGridViewTextBoxColumn56
            // 
            this.dataGridViewTextBoxColumn56.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn56.DataPropertyName = "Comment";
            this.dataGridViewTextBoxColumn56.HeaderText = "Примечание";
            this.dataGridViewTextBoxColumn56.Name = "dataGridViewTextBoxColumn56";
            this.dataGridViewTextBoxColumn56.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn57
            // 
            this.dataGridViewTextBoxColumn57.DataPropertyName = "Degree";
            this.dataGridViewTextBoxColumn57.HeaderText = "Ученая степень";
            this.dataGridViewTextBoxColumn57.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            this.dataGridViewTextBoxColumn57.ReadOnly = true;
            this.dataGridViewTextBoxColumn57.Width = 200;
            // 
            // dataGridViewTextBoxColumn58
            // 
            this.dataGridViewTextBoxColumn58.DataPropertyName = "ScienceType";
            this.dataGridViewTextBoxColumn58.HeaderText = "Науч. напр.";
            this.dataGridViewTextBoxColumn58.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn58.Name = "dataGridViewTextBoxColumn58";
            this.dataGridViewTextBoxColumn58.ReadOnly = true;
            this.dataGridViewTextBoxColumn58.Width = 200;
            // 
            // dataGridViewTextBoxColumn59
            // 
            this.dataGridViewTextBoxColumn59.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn59.DataPropertyName = "EducDocument";
            this.dataGridViewTextBoxColumn59.HeaderText = "Данные диплома";
            this.dataGridViewTextBoxColumn59.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn59.Name = "dataGridViewTextBoxColumn59";
            this.dataGridViewTextBoxColumn59.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn60
            // 
            this.dataGridViewTextBoxColumn60.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn60.DataPropertyName = "DissertCouncil";
            this.dataGridViewTextBoxColumn60.HeaderText = "Диссерт совет";
            this.dataGridViewTextBoxColumn60.Name = "dataGridViewTextBoxColumn60";
            this.dataGridViewTextBoxColumn60.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn66
            // 
            this.dataGridViewTextBoxColumn66.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn66.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn66.HeaderText = "Приказ";
            this.dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
            this.dataGridViewTextBoxColumn66.ReadOnly = true;
            // 
            // ContractName
            // 
            this.ContractName.DataPropertyName = "ContractName";
            this.ContractName.HeaderText = "Номер договора";
            this.ContractName.Name = "ContractName";
            this.ContractName.ReadOnly = true;
            // 
            // DateContract
            // 
            this.DateContract.DataPropertyName = "DateContract";
            this.DateContract.HeaderText = "Дата договора";
            this.DateContract.Name = "DateContract";
            this.DateContract.ReadOnly = true;
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            this.sumDataGridViewTextBoxColumn.HeaderText = "Сумма выплаты";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            this.sumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DateBegin
            // 
            this.DateBegin.DataPropertyName = "DateBegin";
            this.DateBegin.HeaderText = "Дата начала";
            this.DateBegin.Name = "DateBegin";
            this.DateBegin.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn61
            // 
            this.dataGridViewTextBoxColumn61.DataPropertyName = "degreeDate";
            this.dataGridViewTextBoxColumn61.HeaderText = "Дата присвоения степени";
            this.dataGridViewTextBoxColumn61.Name = "dataGridViewTextBoxColumn61";
            // 
            // dataGridViewTextBoxColumn62
            // 
            this.dataGridViewTextBoxColumn62.DataPropertyName = "diplWhere";
            this.dataGridViewTextBoxColumn62.HeaderText = "Диплом выдан";
            this.dataGridViewTextBoxColumn62.Name = "dataGridViewTextBoxColumn62";
            // 
            // dataGridViewTextBoxColumn63
            // 
            this.dataGridViewTextBoxColumn63.DataPropertyName = "Rank";
            this.dataGridViewTextBoxColumn63.HeaderText = "Ученое звание";
            this.dataGridViewTextBoxColumn63.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn63.Name = "dataGridViewTextBoxColumn63";
            this.dataGridViewTextBoxColumn63.Width = 200;
            // 
            // dataGridViewTextBoxColumn64
            // 
            this.dataGridViewTextBoxColumn64.DataPropertyName = "EducDocument";
            this.dataGridViewTextBoxColumn64.HeaderText = "Данные диплома";
            this.dataGridViewTextBoxColumn64.MinimumWidth = 200;
            this.dataGridViewTextBoxColumn64.Name = "dataGridViewTextBoxColumn64";
            this.dataGridViewTextBoxColumn64.Width = 200;
            // 
            // dataGridViewTextBoxColumn65
            // 
            this.dataGridViewTextBoxColumn65.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn65.DataPropertyName = "rankWhere";
            this.dataGridViewTextBoxColumn65.HeaderText = "Звание утверждено";
            this.dataGridViewTextBoxColumn65.Name = "dataGridViewTextBoxColumn65";
            // 
            // tpAwards
            // 
            this.tpAwards.Controls.Add(this.dgvAwards);
            this.tpAwards.Controls.Add(this.toolStrip13);
            this.tpAwards.Location = new System.Drawing.Point(4, 22);
            this.tpAwards.Name = "tpAwards";
            this.tpAwards.Padding = new System.Windows.Forms.Padding(3);
            this.tpAwards.Size = new System.Drawing.Size(869, 339);
            this.tpAwards.TabIndex = 3;
            this.tpAwards.Text = "Награды";
            this.tpAwards.UseVisualStyleBackColor = true;
            // 
            // dgvAwards
            // 
            this.dgvAwards.AllowUserToAddRows = false;
            this.dgvAwards.AllowUserToDeleteRows = false;
            this.dgvAwards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAwards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAwards.Location = new System.Drawing.Point(3, 28);
            this.dgvAwards.Name = "dgvAwards";
            this.dgvAwards.ReadOnly = true;
            this.dgvAwards.RowHeadersVisible = false;
            this.dgvAwards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAwards.Size = new System.Drawing.Size(863, 308);
            this.dgvAwards.TabIndex = 6;
            // 
            // toolStrip13
            // 
            this.toolStrip13.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddAward,
            this.tsbEditAward,
            this.tsbDelAward});
            this.toolStrip13.Location = new System.Drawing.Point(3, 3);
            this.toolStrip13.Name = "toolStrip13";
            this.toolStrip13.Size = new System.Drawing.Size(863, 25);
            this.toolStrip13.TabIndex = 5;
            this.toolStrip13.Text = "toolStrip13";
            // 
            // tsbAddAward
            // 
            this.tsbAddAward.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddAward.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddAward.Name = "tsbAddAward";
            this.tsbAddAward.Size = new System.Drawing.Size(125, 22);
            this.tsbAddAward.Text = "Добавить награду";
            // 
            // tsbEditAward
            // 
            this.tsbEditAward.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditAward.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditAward.Name = "tsbEditAward";
            this.tsbEditAward.Size = new System.Drawing.Size(107, 22);
            this.tsbEditAward.Text = "Редактировать";
            this.tsbEditAward.ToolTipText = "Редактировать члена семьи";
            // 
            // tsbDelAward
            // 
            this.tsbDelAward.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelAward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelAward.Name = "tsbDelAward";
            this.tsbDelAward.Size = new System.Drawing.Size(71, 22);
            this.tsbDelAward.Text = "Удалить";
            this.tsbDelAward.ToolTipText = "Удалить члена семьи";
            // 
            // KadrEmployeeFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.Name = "KadrEmployeeFrame";
            this.Size = new System.Drawing.Size(897, 416);
            this.Load += new System.EventHandler(this.KadrEmployeeFrame_Load);
            this.groupBox1.ResumeLayout(false);
            this.tcEmployee.ResumeLayout(false);
            this.tpEmployee.ResumeLayout(false);
            this.tcEmplData.ResumeLayout(false);
            this.tpPersonData.ResumeLayout(false);
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tpContData.ResumeLayout(false);
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            this.splitContainer3.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKphoneBindingSource)).EndInit();
            this.toolStrip7.ResumeLayout(false);
            this.toolStrip7.PerformLayout();
            this.tableLayoutPanel9.ResumeLayout(false);
            this.tableLayoutPanel9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKAdressBindingSource)).EndInit();
            this.toolStrip8.ResumeLayout(false);
            this.toolStrip8.PerformLayout();
            this.tpFamily.ResumeLayout(false);
            this.tableLayoutPanel10.ResumeLayout(false);
            this.tableLayoutPanel10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView7)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKFamBindingSource)).EndInit();
            this.toolStrip9.ResumeLayout(false);
            this.toolStrip9.PerformLayout();
            this.tpEmpPost.ResumeLayout(false);
            this.tcEmplWorkData.ResumeLayout(false);
            this.tpUGTUPosts.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvEmplPosts)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffBindingSource)).EndInit();
            this.tcEmplPostInf.ResumeLayout(false);
            this.tpEmpOtpusk.ResumeLayout(false);
            this.tableLayoutPanel7.ResumeLayout(false);
            this.tableLayoutPanel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKOtpuskBindingSource)).EndInit();
            this.toolStrip5.ResumeLayout(false);
            this.toolStrip5.PerformLayout();
            this.tpBusTrip.ResumeLayout(false);
            this.tpBusTrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTrips)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessTripsBindingSource)).EndInit();
            this.tsBusinessTrips.ResumeLayout(false);
            this.tsBusinessTrips.PerformLayout();
            this.tpMaterial.ResumeLayout(false);
            this.tpMaterial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMaterial)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MaterialResponsibilitybindingSource)).EndInit();
            this.tsMaterialResp.ResumeLayout(false);
            this.tsMaterialResp.PerformLayout();
            this.tpEmplStading.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeStandingBindingSource)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.tpIncapacities.ResumeLayout(false);
            this.tpIncapacities.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvIncapacities)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.inkapacityDecoratorBindingSource)).EndInit();
            this.toolStrip12.ResumeLayout(false);
            this.toolStrip12.PerformLayout();
            this.tpBonus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllbonusBindingSource)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tpEducation.ResumeLayout(false);
            this.tcEducation.ResumeLayout(false);
            this.tpGrandEducation.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDegreeBindingSource)).EndInit();
            this.toolStrip11.ResumeLayout(false);
            this.toolStrip11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEducation)).EndInit();
            this.tpPostGradEduc.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.toolStrip4.ResumeLayout(false);
            this.toolStrip4.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.tableLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRankBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tpEmplBonusReport.ResumeLayout(false);
            this.tpEmplBonusReport.PerformLayout();
            this.tableLayoutPanel6.ResumeLayout(false);
            this.tableLayoutPanel6.PerformLayout();
            this.toolStrip6.ResumeLayout(false);
            this.toolStrip6.PerformLayout();
            this.tpDopInf.ResumeLayout(false);
            this.tableLayoutPanel11.ResumeLayout(false);
            this.tableLayoutPanel11.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKDopInfBindingSource)).EndInit();
            this.toolStrip10.ResumeLayout(false);
            this.toolStrip10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.materialResponsibilityDecoratorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportColumnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).EndInit();
            this.tpAwards.ResumeLayout(false);
            this.tpAwards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAwards)).EndInit();
            this.toolStrip13.ResumeLayout(false);
            this.toolStrip13.PerformLayout();
            this.ResumeLayout(false);

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

        private void LoadDopInf()
        {
            oKDopInfBindingSource.DataSource = KadrController.Instance.Model.OK_DopInfs.Where(dInf => dInf.Employee == Employee).ToArray();
        }

        private void tcEmployee_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (tcEmployee.SelectedTab == tpBonus)
                LoadBonus();*/

            if (tcEmployee.SelectedTab == tpEducation)
                LoadEducation();

            if (tcEmployee.SelectedTab == tpEmpPost)
                tcEmplWorkData_SelectedIndexChanged(null, null);

            if (tcEmployee.SelectedTab == tpEmployee)
                LoadEmployee();

            if (tcEmployee.SelectedTab == tpDopInf)
            {
                LoadDopInf();
            }

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
                LoadStandings();
            if (tcEmplWorkData.SelectedTab == tpUGTUPosts)
                LoadPostList();
            if (tcEmplWorkData.SelectedTab == tpIncapacities)
                LoadIncapacities();

            
        }

        private void LoadStandings()
        {
            employeeStandingBindingSource.DataSource =
                KadrController.Instance.Model.EmployeeStandings.Where(empSt => empSt.Employee == Employee)
                    .OrderBy(empSt => empSt.DateBegin)
                    .ToArray(); 
        }

        private void tsbAddEmplStanding_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<EmployeeStanding> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<EmployeeStanding>())
            {
                dlg.ObjectList = KadrController.Instance.Model.EmployeeStandings;
                //dlg.BindingSource = employeeStandingBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, DateTime>(x, "DateBegin", DateTime.Today, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, DateTime>(x, "DateEnd", DateTime.Today, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, Employee>(x, "Employee", Employee, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, RegionType>(x, "RegionType", NullRegionType.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<EmployeeStanding, StandingType>(x, "StandingType", NullStandingType.Instance, null), this);
                };



                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.EmployeeStandings;
                };

                dlg.ShowDialog();
            }
            LoadStandings();
            
        }

        private void tsbEditEmplStanding_Click(object sender, EventArgs e)
        {
            if (employeeStandingBindingSource.Current != null)
                LinqActionsController<EmployeeStanding>.Instance.EditObject(
                        employeeStandingBindingSource.Current as EmployeeStanding, false);
            LoadStandings();
        }

        private void tsbDelEmplStanding_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить запись трудовой книжки сотрудника?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                == DialogResult.OK)
            {
                LinqActionsController<EmployeeStanding>.Instance.DeleteObject((employeeStandingBindingSource.Current as EmployeeStanding),
                     KadrController.Instance.Model.EmployeeStandings, null);

                LoadStandings();
            }
        }

        private void factStaffBindingSource_PositionChanged(object sender, EventArgs e)
        {
            tcEmplPostInf_SelectedIndexChanged(null, null);
        }

        private void tsbAddOtp_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<OK_Otpusk> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<OK_Otpusk>())
            {
                dlg.ObjectList = KadrController.Instance.Model.OK_Otpusks;
                //dlg.BindingSource = employeeStandingBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.InitializeNewObject = (x) =>
                {

                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Otpusk, FactStaffPrikaz>(x, "FactStaffPrikaz", 
                        FactStaffPrikaz.CreateFactStaffPrikaz(dlg.CommandManager, factStaffBindingSource.Current as FactStaff), null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Otpusk, OK_Otpuskvid>(x, "OK_Otpuskvid", NullOK_Otpuskvid.Instance, null), this);
                };



                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.OK_Otpusks;
                };

                dlg.ShowDialog();
            }
            LoadOtpusk();
        }

        


        private void tsbEditOtp_Click(object sender, EventArgs e)
        {
            if (oKOtpuskBindingSource.Current != null)
                LinqActionsController<OK_Otpusk>.Instance.EditObject(
                        oKOtpuskBindingSource.Current as OK_Otpusk, true);
            LoadStandings();
        }

        private void tcEmplPostInf_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tcEmplPostInf.SelectedTab == tpEmpOtpusk)
                LoadOtpusk();
            if (tcEmplPostInf.SelectedTab == tpBusTrip)
                LoadTrips();
            if (tcEmplPostInf.SelectedTab == tpMaterial)
                LoadMaterials();
        }

        private void tsbAddEmplTrip_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<BusinessTrip> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<BusinessTrip>())
            {
                dlg.ObjectList = KadrController.Instance.Model.BusinessTrips;
                //dlg.BindingSource = employeeStandingBindingSo;
                dlg.UseInternalCommandManager = true;

                FactStaff fs = (FactStaff)factStaffBindingSource.Current;
                BusinessTripRegionType btrt = new BusinessTripRegionType(DateTime.Now.Date, DateTime.Now.AddDays(7).Date, KadrController.Instance.Model.RegionTypes.First());
                    
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTripRegionType, BusinessTrip>(btrt, "BusinessTrip", x, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, FactStaffPrikaz>(x, "FactStaffPrikaz", new FactStaffPrikaz(DateTime.Now.Date, DateTime.Now.AddDays(7).Date, fs), null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, string>(x, "TripTargetPlace", "", null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, FinancingSource>(x, "FinancingSource", KadrController.Instance.Model.FinancingSources.FirstOrDefault(), null), this);
                    //dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, string>(x, "FinancingSource", KadrController.Instance.Model.FinancingSources.First(), null), this);
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.BusinessTrips;
                };

                dlg.ShowDialog();
            }
            LoadTrips();
        }

        private void tsbDelEmplTrip_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (BusinessTripsBindingSource.Current as BusinessTripDecorator).ToString()),"Подтверждение", MessageBoxButtons.OKCancel)==DialogResult.OK)
            {
              BusinessTrip bt = (BusinessTripsBindingSource.Current as BusinessTripDecorator).GetTrip();

              foreach (BusinessTripRegionType rt in bt.BusinessTripRegionTypes)
              KadrController.Instance.Model.BusinessTripRegionTypes.DeleteOnSubmit(rt);

              KadrController.Instance.Model.BusinessTrips.DeleteOnSubmit(bt);
              KadrController.Instance.Model.FactStaffPrikazs.DeleteOnSubmit(bt.FactStaffPrikaz);
              KadrController.Instance.Model.SubmitChanges();
            }
            LoadTrips();

        }

        private void tsbEditEmplTrip_Click(object sender, EventArgs e)
        {
            if (BusinessTripsBindingSource.Current != null)
                LinqActionsController<BusinessTrip>.Instance.EditObject(
                        (BusinessTripsBindingSource.Current as BusinessTripDecorator).GetTrip(), true);
            LoadTrips();
        }

        private void dgvTrips_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            tsbEditEmplTrip_Click(sender, null);
        }

        private void tsbDelOtp_Click(object sender, EventArgs e)
        {
            OK_Otpusk CurrentOtp = oKOtpuskBindingSource.Current as OK_Otpusk;
            FactStaffPrikaz CurrentPrikaz = CurrentOtp.FactStaffPrikaz;

            if (CurrentOtp == null)
            {
                MessageBox.Show("Не выбран удаляемый отпуск.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить отпуск?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            KadrController.Instance.Model.OK_Otpusks.DeleteOnSubmit(CurrentOtp);

            LinqActionsController<FactStaffPrikaz>.Instance.DeleteObject(CurrentPrikaz, KadrController.Instance.Model.FactStaffPrikazs, null);

            LoadOtpusk();
        }

        private void tsbChangeRegionDates_Click(object sender, EventArgs e)
        {
            if (BusinessTripsBindingSource.Current != null)
                LinqActionsController<BusinessTripRegionType>.Instance.EditObject(
                        (BusinessTripsBindingSource.Current as BusinessTripDecorator).GetRegionType(), true);
            //LoadTrips();
        }

        private void tsbAddMaterial_Click(object sender, EventArgs e)
        {
            using (var dlg = new Common.PropertyGridDialogAdding<MaterialResponsibility>())
            {
                dlg.ObjectList = KadrController.Instance.Model.MaterialResponsibilities;
                dlg.UseInternalCommandManager = true;
                dlg.InitializeNewObject = (x) =>
                {
                    var factStaffPrikaz = new FactStaffPrikaz();
                    dlg.CommandManager.Execute(
                        new GenericPropertyCommand<FactStaffPrikaz, FactStaff>(factStaffPrikaz, "FactStaff",
                            factStaffBindingSource.Current as FactStaff, null), this);
                    dlg.CommandManager.Execute(
                        new GenericPropertyCommand<FactStaffPrikaz, Prikaz>(factStaffPrikaz, "Prikaz",
                            NullPrikaz.Instance, null), this);
                    dlg.CommandManager.Execute(
                        new GenericPropertyCommand<FactStaffPrikaz, DateTime?>(factStaffPrikaz, "DateBegin",
                            DateTime.Today, null), this);
                    dlg.CommandManager.Execute(
                        new GenericPropertyCommand<FactStaffPrikaz, DateTime?>(factStaffPrikaz, "DateEnd",
                            null, null), this);

                    dlg.CommandManager.Execute(
                        new GenericPropertyCommand<MaterialResponsibility, FactStaffPrikaz>(x,
                            "FactStaffPrikaz", factStaffPrikaz, null), this);
                   // var contract = new Data.Contract();
                    dlg.CommandManager.Execute(new GenericPropertyCommand<MaterialResponsibility, Contract>(x, "Contract", new Contract(), null), this);
                    dlg.CommandManager.Execute(new GenericPropertyCommand<Contract, DateTime?>(x.Contract, "DateContract", DateTime.Today, null), this);
                    dlg.CommandManager.Execute(
                        new GenericPropertyCommand<Contract, string>(x.Contract, "ContractName", "", null),
                        this);

                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.MaterialResponsibilities;
                };

                dlg.ShowDialog();
            }
            LoadMaterials();
        }

        private void tsbDelMaterial_Click(object sender, EventArgs e)
        {
            if (MaterialResponsibilitybindingSource.Current == null)
            {
                MessageBox.Show(@"Не выбрана удаляемая материальная ответственность.", @"ИС ""Управление кадрами""");
                return;
            }

            var currMaterial = MaterialResponsibilitybindingSource.Current as MaterialResponsibility;

            if (MessageBox.Show("Удалить материальную ответственность?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }
            var currentPrikaz = currMaterial.FactStaffPrikaz;
            var currContract = currMaterial.Contract;

            KadrController.Instance.Model.MaterialResponsibilities.DeleteOnSubmit(currMaterial);
            LinqActionsController<FactStaffPrikaz>.Instance.DeleteObject(currentPrikaz, KadrController.Instance.Model.FactStaffPrikazs, null);
            LinqActionsController<Contract>.Instance.DeleteObject(currContract, KadrController.Instance.Model.Contracts, null);

            LoadMaterials();
        }

        private void tsbEditMaterial_Click(object sender, EventArgs e)
        {
            if (MaterialResponsibilitybindingSource.Current != null)
            {
                var currMaterial = MaterialResponsibilitybindingSource.Current as MaterialResponsibility;
                LinqActionsController<MaterialResponsibility>.Instance.EditObject(
                    currMaterial, true);
            }
            LoadMaterials();
        }

        private void tsbSocialFareTransit_Click(object sender, EventArgs e)
        {
            using (Forms.SocialFareTransitForm dlg = new Forms.SocialFareTransitForm())
            {
                dlg.Employee = Employee;
                dlg.ShowDialog();
            }
        }

        private void LoadContactData()
        {
            LoadPhones();
            LoadAddress();
        }

        private void LoadPhones()
        {
            oKphoneBindingSource.DataSource = KadrController.Instance.Model.OK_phones.Where(pH => pH.Employee == Employee).ToArray();
        }

        private void LoadAddress()
        {
            oKAdressBindingSource.DataSource = KadrController.Instance.Model.OK_Adresses.Where(Addr => Addr.Employee == Employee).ToArray();
        }

        private void tcEmplData_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*if (tcEmplData.SelectedTab == tpPersonData)
                LoadStandings();*/
            if (tcEmplData.SelectedTab == tpContData)
                LoadContactData();

            if (tcEmplData.SelectedTab == tpFamily)
                LoadFamMembers();
        }

        private void LoadFamMembers()
        {
            oKFamBindingSource.DataSource = KadrController.Instance.Model.OK_Fams.Where(fM => fM.Employee == Employee).ToArray();
        }

        private void tsbAddPhone_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<OK_phone> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<OK_phone>())
            {
                dlg.ObjectList = KadrController.Instance.Model.OK_phones;
                dlg.PrikazButtonVisible = false;
                //dlg.BindingSource = employeeStandingBindingSource;
                dlg.UseInternalCommandManager = true;

                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_phone, Employee>(x, "Employee", Employee, null), this);
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.OK_phones;
                };

                dlg.ShowDialog();
            }
            LoadPhones();
        }

        private void tsbEditPhone_Click(object sender, EventArgs e)
        {
            if (oKphoneBindingSource.Current != null)
                LinqActionsController<OK_phone>.Instance.EditObject(
                        oKphoneBindingSource.Current as OK_phone, true);
            LoadPhones();
        }

        private void tsbDelPhone_Click(object sender, EventArgs e)
        {
            OK_phone CurrentPhone = oKphoneBindingSource.Current as OK_phone;

            if (CurrentPhone == null)
            {
                MessageBox.Show("Не выбран удаляемый номер.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить номер?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            LinqActionsController<OK_phone>.Instance.DeleteObject(CurrentPhone, KadrController.Instance.Model.OK_phones, null);

            LoadPhones();
        }

        private void tsbAddAddress_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<OK_Adress> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<OK_Adress>())
            {
                dlg.ObjectList = KadrController.Instance.Model.OK_Adresses;
                dlg.PrikazButtonVisible = false;
                //dlg.BindingSource = employeeStandingBindingSource;
                dlg.UseInternalCommandManager = true;

                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Adress, Employee>(x, "Employee", Employee, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Adress, DateTime?>(x, "DateReg", DateTime.Today, null), this);
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.OK_Adresses;
                };

                dlg.ShowDialog();
            }
            LoadAddress();
        }

        private void tsbUpdAddress_Click(object sender, EventArgs e)
        {
            if (oKAdressBindingSource.Current != null)
                LinqActionsController<OK_Adress>.Instance.EditObject(
                        oKAdressBindingSource.Current as OK_Adress, true);
            LoadAddress();
        }

        private void tsbDelAddress_Click(object sender, EventArgs e)
        {
            OK_Adress CurrentAddress = oKAdressBindingSource.Current as OK_Adress;

            if (CurrentAddress == null)
            {
                MessageBox.Show("Не выбран удаляемый адрес.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить адрес?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            LinqActionsController<OK_Adress>.Instance.DeleteObject(CurrentAddress, KadrController.Instance.Model.OK_Adresses, null);

            LoadAddress();
        }

        private void tsbAddFamMember_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<OK_Fam> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<OK_Fam>())
            {
                dlg.ObjectList = KadrController.Instance.Model.OK_Fams;
                //dlg.BindingSource = employeeStandingBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.PrikazButtonVisible = false;

                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Fam, Employee>(x, "Employee", Employee, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Fam, OK_MembFam>(x, "OK_MembFam", NullOK_MembFam.Instance, null), this);
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.OK_Fams;
                };

                dlg.ShowDialog();
            }

            LoadFamMembers();
        }

        private void tsbEditFamMember_Click(object sender, EventArgs e)
        {
            if (oKFamBindingSource.Current != null)
                LinqActionsController<OK_Fam>.Instance.EditObject(
                        oKFamBindingSource.Current as OK_Fam, true);
            LoadFamMembers();
            
        }

        private void tsbDelFamMember_Click(object sender, EventArgs e)
        {
            OK_Fam CurrentFamMemb = oKFamBindingSource.Current as OK_Fam;

            if (CurrentFamMemb == null)
            {
                MessageBox.Show("Не выбран удаляемый родственник.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить родственника?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            LinqActionsController<OK_Fam>.Instance.DeleteObject(CurrentFamMemb, KadrController.Instance.Model.OK_Fams, null);

            LoadFamMembers();
        }

        private void tsbAddDopInf_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<OK_DopInf> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<OK_DopInf>())
            {
                dlg.ObjectList = KadrController.Instance.Model.OK_DopInfs;
                //dlg.BindingSource = employeeStandingBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.PrikazButtonVisible = false;

                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_DopInf, Employee>(x, "Employee", Employee, null), this);
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.OK_DopInfs;
                };

                dlg.ShowDialog();
            }
            
            LoadDopInf();
        }

        private void tsbEditDopInf_Click(object sender, EventArgs e)
        {
            if (oKDopInfBindingSource.Current != null)
                LinqActionsController<OK_DopInf>.Instance.EditObject(
                        oKDopInfBindingSource.Current as OK_DopInf, true);
            LoadDopInf();
        }

        private void tsbDelDopInf_Click(object sender, EventArgs e)
        {
            OK_DopInf CurrentDopInf = oKDopInfBindingSource.Current as OK_DopInf;

            if (CurrentDopInf == null)
            {
                MessageBox.Show("Не выбрана удаляемая строка.", "ИС \"Управление кадрами\"");
                return;
            }

            if (MessageBox.Show("Удалить выбранную строку из дополнительных сведений?", "ИС \"Управление кадрами\"", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            LinqActionsController<OK_DopInf>.Instance.DeleteObject(CurrentDopInf, KadrController.Instance.Model.OK_DopInfs, null);

            LoadDopInf();
        }

        private void tsbAddIncapacity_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<OK_Inkapacity> dlg =
               new Kadr.UI.Common.PropertyGridDialogAdding<OK_Inkapacity>())
            {
                dlg.ObjectList = KadrController.Instance.Model.OK_Inkapacities;
                //dlg.BindingSource = employeeStandingBindingSource;
                dlg.UseInternalCommandManager = true;

                EducDocument ed = new EducDocument();

                dlg.InitializeNewObject = (x =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Inkapacity, Employee>(x, "Employee", Employee, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Inkapacity, EducDocument>(x, "EducDocument",
                        new EducDocument(commandManager, KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(q => q.DocTypeName == Properties.Settings.Default.InkapacityDocTypeName))), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Inkapacity, DateTime>(x, "DateBegin", DateTime.Today.Date, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Inkapacity, DateTime?>(x, "DateEnd", DateTime.Today.AddDays(7).Date, null), this);
                });
                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.OK_Inkapacities;
                };

                dlg.ShowDialog();
            }
            LoadIncapacities();
        }

        private void LoadIncapacities()
        {
            inkapacityDecoratorBindingSource.DataSource = KadrController.Instance.Model.OK_Inkapacities.Where(x => x.Employee == Employee)
                    .OrderBy(x => x.DateBegin)
                    .Select(x => new InkapacityDecorator(x)); 

        }

        private void tsbEditIncapacity_Click(object sender, EventArgs e)
        {
            if (inkapacityDecoratorBindingSource.Current != null)
                LinqActionsController<OK_Inkapacity>.Instance.EditObject(
                        (inkapacityDecoratorBindingSource.Current as InkapacityDecorator).GetInkapacity(), true);
            LoadIncapacities();

        }

        private void tsbDeleteIncapacity_Click(object sender, EventArgs e)
        {
            if (inkapacityDecoratorBindingSource.Current == null)
                MessageBox.Show("Не выбрана командировка!");
            else
                if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (inkapacityDecoratorBindingSource.Current as InkapacityDecorator).ToString()), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    OK_Inkapacity i = (inkapacityDecoratorBindingSource.Current as InkapacityDecorator).GetInkapacity();

                    KadrController.Instance.Model.EducDocuments.DeleteOnSubmit(i.EducDocument);
                    LinqActionsController<OK_Inkapacity>.Instance.DeleteObject(i, KadrController.Instance.Model.OK_Inkapacities, null);

                }
            LoadIncapacities();

        }


    }

}
