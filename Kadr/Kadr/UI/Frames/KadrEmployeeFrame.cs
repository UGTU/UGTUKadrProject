﻿using System;
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
        private UIX.UI.CommandPropertyGrid cpgEmployee;
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
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private TabPage tpMaterial;
        private ToolStrip tsMaterialResp;
        private ToolStripButton tsbAddMaterial;
        private ToolStripButton toolStripButton2;
        private ToolStripButton toolStripButton3;
        private DataGridView dgvMaterial;
        private BindingSource MaterialResponsibilitybindingSource;
        private DataGridViewTextBoxColumn prikazDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn targetPlaceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn finSourceDataGridViewTextBoxColumn;
        private BindingSource businessTripDecoratorBindingSource;
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
        private DataGridViewTextBoxColumn sumDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn ContractName;
        private DataGridViewTextBoxColumn DateContract;
        private DataGridViewTextBoxColumn DateBegin;
        private DataGridViewTextBoxColumn DateEnd;
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
            MaterialResponsibilitybindingSource.DataSource = KadrController.Instance.Model.MaterialResponsibilities.Where(t => t.FactStaffPrikaz.FactStaff == f).Select(x=>new  MaterialResponsibilityDecorator(x)).ToList();
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
            this.tableLayoutPanel5 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOk = new System.Windows.Forms.Button();
            this.tcEmplData = new System.Windows.Forms.TabControl();
            this.tpPersonData = new System.Windows.Forms.TabPage();
            this.cpgEmployee = new UIX.UI.CommandPropertyGrid();
            this.tpFamily = new System.Windows.Forms.TabPage();
            this.tpContData = new System.Windows.Forms.TabPage();
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
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.oKOtpuskBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip5 = new System.Windows.Forms.ToolStrip();
            this.tsbAddOtp = new System.Windows.Forms.ToolStripButton();
            this.tsbEditOtp = new System.Windows.Forms.ToolStripButton();
            this.tsbDelOtp = new System.Windows.Forms.ToolStripButton();
            this.tpBusTrip = new System.Windows.Forms.TabPage();
            this.dgvTrips = new System.Windows.Forms.DataGridView();
            this.prikazDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBeginDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.targetPlaceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.finSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessTripDecoratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsBusinessTrips = new System.Windows.Forms.ToolStrip();
            this.tsbAddEmplTrip = new System.Windows.Forms.ToolStripButton();
            this.tsbEditEmplTrip = new System.Windows.Forms.ToolStripButton();
            this.tsbDelEmplTrip = new System.Windows.Forms.ToolStripButton();
            this.tpMaterial = new System.Windows.Forms.TabPage();
            this.dgvMaterial = new System.Windows.Forms.DataGridView();
            this.MaterialResponsibilitybindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tsMaterialResp = new System.Windows.Forms.ToolStrip();
            this.tsbAddMaterial = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
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
            this.employeeDegreeBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.bonusReportColumnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bonusTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
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
            this.BusinessTripsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn61 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn62 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn63 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn64 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn65 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn66 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContractName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateContract = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tcEmployee.SuspendLayout();
            this.tpEmployee.SuspendLayout();
            this.tableLayoutPanel5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tcEmplData.SuspendLayout();
            this.tpPersonData.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.businessTripDecoratorBindingSource)).BeginInit();
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
            this.tpBonus.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBonus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllbonusBindingSource)).BeginInit();
            this.toolStrip3.SuspendLayout();
            this.tpEducation.SuspendLayout();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDegreeBindingSource)).BeginInit();
            this.toolStrip4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.tableLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeRankBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tpEmplBonusReport.SuspendLayout();
            this.tableLayoutPanel6.SuspendLayout();
            this.toolStrip6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportColumnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessTripsBindingSource)).BeginInit();
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
            this.tpEmployee.Controls.Add(this.tableLayoutPanel5);
            this.tpEmployee.Location = new System.Drawing.Point(4, 22);
            this.tpEmployee.Name = "tpEmployee";
            this.tpEmployee.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmployee.Size = new System.Drawing.Size(883, 371);
            this.tpEmployee.TabIndex = 0;
            this.tpEmployee.Text = "Личные данные";
            this.tpEmployee.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel5
            // 
            this.tableLayoutPanel5.ColumnCount = 1;
            this.tableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.Controls.Add(this.panel1, 0, 1);
            this.tableLayoutPanel5.Controls.Add(this.tcEmplData, 0, 0);
            this.tableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel5.Name = "tableLayoutPanel5";
            this.tableLayoutPanel5.RowCount = 2;
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tableLayoutPanel5.Size = new System.Drawing.Size(877, 365);
            this.tableLayoutPanel5.TabIndex = 3;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnCancel);
            this.panel1.Controls.Add(this.btnOk);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 328);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(871, 34);
            this.panel1.TabIndex = 1;
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(559, 0);
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
            this.btnOk.Location = new System.Drawing.Point(703, 0);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(165, 32);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "Сохранить изменения";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // tcEmplData
            // 
            this.tcEmplData.Controls.Add(this.tpPersonData);
            this.tcEmplData.Controls.Add(this.tpFamily);
            this.tcEmplData.Controls.Add(this.tpContData);
            this.tcEmplData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEmplData.Location = new System.Drawing.Point(3, 3);
            this.tcEmplData.Name = "tcEmplData";
            this.tcEmplData.SelectedIndex = 0;
            this.tcEmplData.Size = new System.Drawing.Size(871, 319);
            this.tcEmplData.TabIndex = 4;
            // 
            // tpPersonData
            // 
            this.tpPersonData.Controls.Add(this.cpgEmployee);
            this.tpPersonData.Location = new System.Drawing.Point(4, 22);
            this.tpPersonData.Name = "tpPersonData";
            this.tpPersonData.Padding = new System.Windows.Forms.Padding(3);
            this.tpPersonData.Size = new System.Drawing.Size(863, 293);
            this.tpPersonData.TabIndex = 0;
            this.tpPersonData.Text = "Персональные данные";
            this.tpPersonData.UseVisualStyleBackColor = true;
            // 
            // cpgEmployee
            // 
            this.cpgEmployee.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cpgEmployee.CommandRegister = null;
            this.cpgEmployee.Location = new System.Drawing.Point(0, 0);
            this.cpgEmployee.Name = "cpgEmployee";
            this.cpgEmployee.Size = new System.Drawing.Size(1542, 538);
            this.cpgEmployee.TabIndex = 0;
            // 
            // tpFamily
            // 
            this.tpFamily.Location = new System.Drawing.Point(4, 22);
            this.tpFamily.Name = "tpFamily";
            this.tpFamily.Padding = new System.Windows.Forms.Padding(3);
            this.tpFamily.Size = new System.Drawing.Size(863, 293);
            this.tpFamily.TabIndex = 1;
            this.tpFamily.Text = "Состав семьи";
            this.tpFamily.UseVisualStyleBackColor = true;
            // 
            // tpContData
            // 
            this.tpContData.Location = new System.Drawing.Point(4, 22);
            this.tpContData.Name = "tpContData";
            this.tpContData.Size = new System.Drawing.Size(863, 293);
            this.tpContData.TabIndex = 2;
            this.tpContData.Text = "Контактные данные";
            this.tpContData.UseVisualStyleBackColor = true;
            // 
            // tpEmpPost
            // 
            this.tpEmpPost.AutoScroll = true;
            this.tpEmpPost.Controls.Add(this.tcEmplWorkData);
            this.tpEmpPost.Location = new System.Drawing.Point(4, 22);
            this.tpEmpPost.Name = "tpEmpPost";
            this.tpEmpPost.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmpPost.Size = new System.Drawing.Size(883, 371);
            this.tpEmpPost.TabIndex = 1;
            this.tpEmpPost.Text = "Трудовая деятельность";
            this.tpEmpPost.UseVisualStyleBackColor = true;
            // 
            // tcEmplWorkData
            // 
            this.tcEmplWorkData.Controls.Add(this.tpUGTUPosts);
            this.tcEmplWorkData.Controls.Add(this.tpEmplStading);
            this.tcEmplWorkData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEmplWorkData.Location = new System.Drawing.Point(3, 3);
            this.tcEmplWorkData.Name = "tcEmplWorkData";
            this.tcEmplWorkData.SelectedIndex = 0;
            this.tcEmplWorkData.Size = new System.Drawing.Size(877, 365);
            this.tcEmplWorkData.TabIndex = 1;
            this.tcEmplWorkData.SelectedIndexChanged += new System.EventHandler(this.tcEmplWorkData_SelectedIndexChanged);
            // 
            // tpUGTUPosts
            // 
            this.tpUGTUPosts.Controls.Add(this.splitContainer1);
            this.tpUGTUPosts.Location = new System.Drawing.Point(4, 22);
            this.tpUGTUPosts.Name = "tpUGTUPosts";
            this.tpUGTUPosts.Padding = new System.Windows.Forms.Padding(3);
            this.tpUGTUPosts.Size = new System.Drawing.Size(869, 339);
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
            this.splitContainer1.Size = new System.Drawing.Size(863, 333);
            this.splitContainer1.SplitterDistance = 205;
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
            this.dgvEmplPosts.Size = new System.Drawing.Size(863, 205);
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
            this.tcEmplPostInf.Size = new System.Drawing.Size(863, 124);
            this.tcEmplPostInf.TabIndex = 1;
            this.tcEmplPostInf.SelectedIndexChanged += new System.EventHandler(this.tcEmplPostInf_SelectedIndexChanged);
            // 
            // tpEmpOtpusk
            // 
            this.tpEmpOtpusk.Controls.Add(this.tableLayoutPanel7);
            this.tpEmpOtpusk.Location = new System.Drawing.Point(4, 22);
            this.tpEmpOtpusk.Name = "tpEmpOtpusk";
            this.tpEmpOtpusk.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmpOtpusk.Size = new System.Drawing.Size(855, 98);
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
            this.tableLayoutPanel7.Size = new System.Drawing.Size(849, 92);
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
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12});
            this.dataGridView5.DataSource = this.oKOtpuskBindingSource;
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView5.Location = new System.Drawing.Point(3, 27);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.RowHeadersVisible = false;
            this.dataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView5.Size = new System.Drawing.Size(843, 155);
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
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn10.HeaderText = "Приказ";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Width = 140;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn11.HeaderText = "Дата начала";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Width = 70;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn12.HeaderText = "Дата окончания";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            this.dataGridViewTextBoxColumn12.Width = 50;
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
            this.tsbDelOtp});
            this.toolStrip5.Location = new System.Drawing.Point(0, 0);
            this.toolStrip5.Name = "toolStrip5";
            this.toolStrip5.Size = new System.Drawing.Size(849, 24);
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
            // tpBusTrip
            // 
            this.tpBusTrip.Controls.Add(this.dgvTrips);
            this.tpBusTrip.Controls.Add(this.tsBusinessTrips);
            this.tpBusTrip.Location = new System.Drawing.Point(4, 22);
            this.tpBusTrip.Name = "tpBusTrip";
            this.tpBusTrip.Padding = new System.Windows.Forms.Padding(3);
            this.tpBusTrip.Size = new System.Drawing.Size(855, 98);
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
            this.dgvTrips.DataSource = this.businessTripDecoratorBindingSource;
            this.dgvTrips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrips.Location = new System.Drawing.Point(3, 28);
            this.dgvTrips.Name = "dgvTrips";
            this.dgvTrips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrips.Size = new System.Drawing.Size(849, 67);
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
            // businessTripDecoratorBindingSource
            // 
            this.businessTripDecoratorBindingSource.DataSource = typeof(Kadr.Data.BusinessTripDecorator);
            // 
            // tsBusinessTrips
            // 
            this.tsBusinessTrips.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddEmplTrip,
            this.tsbEditEmplTrip,
            this.tsbDelEmplTrip});
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
            // tpMaterial
            // 
            this.tpMaterial.Controls.Add(this.dgvMaterial);
            this.tpMaterial.Controls.Add(this.tsMaterialResp);
            this.tpMaterial.Location = new System.Drawing.Point(4, 22);
            this.tpMaterial.Name = "tpMaterial";
            this.tpMaterial.Padding = new System.Windows.Forms.Padding(3);
            this.tpMaterial.Size = new System.Drawing.Size(855, 98);
            this.tpMaterial.TabIndex = 2;
            this.tpMaterial.Text = "Материальная ответственность";
            this.tpMaterial.UseVisualStyleBackColor = true;
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AutoGenerateColumns = false;
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn66,
            this.sumDataGridViewTextBoxColumn,
            this.ContractName,
            this.DateContract,
            this.DateBegin,
            this.DateEnd});
            this.dgvMaterial.DataSource = this.MaterialResponsibilitybindingSource;
            this.dgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterial.Location = new System.Drawing.Point(3, 28);
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.RowHeadersWidth = 4;
            this.dgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterial.Size = new System.Drawing.Size(849, 67);
            this.dgvMaterial.TabIndex = 14;
            // 
            // MaterialResponsibilitybindingSource
            // 
            this.MaterialResponsibilitybindingSource.DataSource = typeof(Kadr.Data.MaterialResponsibilityDecorator);
            // 
            // tsMaterialResp
            // 
            this.tsMaterialResp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddMaterial,
            this.toolStripButton2,
            this.toolStripButton3});
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
            // toolStripButton2
            // 
            this.toolStripButton2.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(107, 22);
            this.toolStripButton2.Text = "Редактировать";
            this.toolStripButton2.ToolTipText = "Редактировать запись";
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(71, 22);
            this.toolStripButton3.Text = "Удалить";
            this.toolStripButton3.ToolTipText = "Удалить запись";
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
            this.tpEducation.Controls.Add(this.splitContainer2);
            this.tpEducation.Location = new System.Drawing.Point(4, 22);
            this.tpEducation.Name = "tpEducation";
            this.tpEducation.Padding = new System.Windows.Forms.Padding(3);
            this.tpEducation.Size = new System.Drawing.Size(802, 533);
            this.tpEducation.TabIndex = 3;
            this.tpEducation.Text = "Образование";
            this.tpEducation.UseVisualStyleBackColor = true;
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
            this.splitContainer2.Size = new System.Drawing.Size(796, 527);
            this.splitContainer2.SplitterDistance = 254;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(796, 254);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(790, 235);
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
            // employeeDegreeBindingSource
            // 
            this.employeeDegreeBindingSource.DataSource = typeof(Kadr.Data.EmployeeDegree);
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
            this.groupBox5.Size = new System.Drawing.Size(796, 269);
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(790, 250);
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
            this.dataGridView3.Size = new System.Drawing.Size(877, 219);
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
            this.dataGridViewTextBoxColumn24.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn24.HeaderText = "Приказ";
            this.dataGridViewTextBoxColumn24.Name = "dataGridViewTextBoxColumn24";
            // 
            // dataGridViewTextBoxColumn25
            // 
            this.dataGridViewTextBoxColumn25.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn25.HeaderText = "Дата начала";
            this.dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            // 
            // dataGridViewTextBoxColumn26
            // 
            this.dataGridViewTextBoxColumn26.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn26.HeaderText = "Дата окончания";
            this.dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            // 
            // dataGridViewTextBoxColumn27
            // 
            this.dataGridViewTextBoxColumn27.DataPropertyName = "TargetPlace";
            this.dataGridViewTextBoxColumn27.HeaderText = "Место назначения";
            this.dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            // 
            // dataGridViewTextBoxColumn28
            // 
            this.dataGridViewTextBoxColumn28.DataPropertyName = "FinSource";
            this.dataGridViewTextBoxColumn28.HeaderText = "Источник финансирования";
            this.dataGridViewTextBoxColumn28.Name = "dataGridViewTextBoxColumn28";
            // 
            // dataGridViewTextBoxColumn29
            // 
            this.dataGridViewTextBoxColumn29.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn29.HeaderText = "id";
            this.dataGridViewTextBoxColumn29.Name = "dataGridViewTextBoxColumn29";
            // 
            // dataGridViewTextBoxColumn30
            // 
            this.dataGridViewTextBoxColumn30.DataPropertyName = "idFactStaffPrikaz";
            this.dataGridViewTextBoxColumn30.HeaderText = "idFactStaffPrikaz";
            this.dataGridViewTextBoxColumn30.Name = "dataGridViewTextBoxColumn30";
            this.dataGridViewTextBoxColumn30.ReadOnly = true;
            this.dataGridViewTextBoxColumn30.Visible = false;
            // 
            // dataGridViewTextBoxColumn31
            // 
            this.dataGridViewTextBoxColumn31.DataPropertyName = "idContract";
            this.dataGridViewTextBoxColumn31.HeaderText = "idContract";
            this.dataGridViewTextBoxColumn31.Name = "dataGridViewTextBoxColumn31";
            this.dataGridViewTextBoxColumn31.ReadOnly = true;
            this.dataGridViewTextBoxColumn31.Width = 130;
            // 
            // dataGridViewTextBoxColumn32
            // 
            this.dataGridViewTextBoxColumn32.DataPropertyName = "Sum";
            this.dataGridViewTextBoxColumn32.HeaderText = "Sum";
            this.dataGridViewTextBoxColumn32.Name = "dataGridViewTextBoxColumn32";
            this.dataGridViewTextBoxColumn32.ReadOnly = true;
            this.dataGridViewTextBoxColumn32.Width = 130;
            // 
            // dataGridViewTextBoxColumn33
            // 
            this.dataGridViewTextBoxColumn33.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn33.DataPropertyName = "Contract";
            this.dataGridViewTextBoxColumn33.HeaderText = "Contract";
            this.dataGridViewTextBoxColumn33.Name = "dataGridViewTextBoxColumn33";
            this.dataGridViewTextBoxColumn33.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn34
            // 
            this.dataGridViewTextBoxColumn34.DataPropertyName = "FactStaffPrikaz";
            this.dataGridViewTextBoxColumn34.HeaderText = "FactStaffPrikaz";
            this.dataGridViewTextBoxColumn34.Name = "dataGridViewTextBoxColumn34";
            this.dataGridViewTextBoxColumn34.ReadOnly = true;
            this.dataGridViewTextBoxColumn34.Width = 130;
            // 
            // dataGridViewTextBoxColumn35
            // 
            this.dataGridViewTextBoxColumn35.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn35.HeaderText = "id";
            this.dataGridViewTextBoxColumn35.Name = "dataGridViewTextBoxColumn35";
            this.dataGridViewTextBoxColumn35.ReadOnly = true;
            this.dataGridViewTextBoxColumn35.Visible = false;
            this.dataGridViewTextBoxColumn35.Width = 70;
            // 
            // dataGridViewTextBoxColumn36
            // 
            this.dataGridViewTextBoxColumn36.DataPropertyName = "RegionType";
            this.dataGridViewTextBoxColumn36.HeaderText = "Тип региона";
            this.dataGridViewTextBoxColumn36.Name = "dataGridViewTextBoxColumn36";
            this.dataGridViewTextBoxColumn36.ReadOnly = true;
            this.dataGridViewTextBoxColumn36.Width = 130;
            // 
            // dataGridViewTextBoxColumn37
            // 
            this.dataGridViewTextBoxColumn37.DataPropertyName = "StandingType";
            this.dataGridViewTextBoxColumn37.HeaderText = "Тип стажа";
            this.dataGridViewTextBoxColumn37.Name = "dataGridViewTextBoxColumn37";
            this.dataGridViewTextBoxColumn37.ReadOnly = true;
            this.dataGridViewTextBoxColumn37.Visible = false;
            this.dataGridViewTextBoxColumn37.Width = 130;
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
            this.dataGridViewTextBoxColumn40.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn40.HeaderText = "Дата приема";
            this.dataGridViewTextBoxColumn40.Name = "dataGridViewTextBoxColumn40";
            this.dataGridViewTextBoxColumn40.ReadOnly = true;
            this.dataGridViewTextBoxColumn40.Visible = false;
            this.dataGridViewTextBoxColumn40.Width = 70;
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
            this.dataGridViewTextBoxColumn42.DataPropertyName = "idRegionType";
            this.dataGridViewTextBoxColumn42.HeaderText = "idRegionType";
            this.dataGridViewTextBoxColumn42.Name = "dataGridViewTextBoxColumn42";
            this.dataGridViewTextBoxColumn42.ReadOnly = true;
            this.dataGridViewTextBoxColumn42.Visible = false;
            this.dataGridViewTextBoxColumn42.Width = 120;
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
            this.dataGridViewTextBoxColumn45.DataPropertyName = "Employee";
            this.dataGridViewTextBoxColumn45.HeaderText = "Employee";
            this.dataGridViewTextBoxColumn45.Name = "dataGridViewTextBoxColumn45";
            this.dataGridViewTextBoxColumn45.ReadOnly = true;
            this.dataGridViewTextBoxColumn45.Visible = false;
            this.dataGridViewTextBoxColumn45.Width = 80;
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
            this.dataGridViewTextBoxColumn50.DataPropertyName = "BonusCount";
            this.dataGridViewTextBoxColumn50.HeaderText = "Размер надбавки";
            this.dataGridViewTextBoxColumn50.Name = "dataGridViewTextBoxColumn50";
            this.dataGridViewTextBoxColumn50.ReadOnly = true;
            this.dataGridViewTextBoxColumn50.Width = 80;
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
            this.dataGridViewTextBoxColumn52.Name = "dataGridViewTextBoxColumn52";
            this.dataGridViewTextBoxColumn52.ReadOnly = true;
            this.dataGridViewTextBoxColumn52.Width = 110;
            // 
            // dataGridViewTextBoxColumn53
            // 
            this.dataGridViewTextBoxColumn53.DataPropertyName = "IntermediateDateEnd";
            this.dataGridViewTextBoxColumn53.HeaderText = "Пром. дата отмены";
            this.dataGridViewTextBoxColumn53.Name = "dataGridViewTextBoxColumn53";
            this.dataGridViewTextBoxColumn53.ReadOnly = true;
            this.dataGridViewTextBoxColumn53.Width = 70;
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
            this.dataGridViewTextBoxColumn57.Name = "dataGridViewTextBoxColumn57";
            this.dataGridViewTextBoxColumn57.ReadOnly = true;
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
            // BusinessTripsBindingSource
            // 
            this.BusinessTripsBindingSource.DataSource = typeof(Kadr.Data.BusinessTripDecorator);
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
            // dataGridViewTextBoxColumn66
            // 
            this.dataGridViewTextBoxColumn66.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn66.HeaderText = "Приказ";
            this.dataGridViewTextBoxColumn66.Name = "dataGridViewTextBoxColumn66";
            // 
            // sumDataGridViewTextBoxColumn
            // 
            this.sumDataGridViewTextBoxColumn.DataPropertyName = "Sum";
            this.sumDataGridViewTextBoxColumn.HeaderText = "Сумма выплаты";
            this.sumDataGridViewTextBoxColumn.Name = "sumDataGridViewTextBoxColumn";
            // 
            // ContractName
            // 
            this.ContractName.DataPropertyName = "ContractName";
            this.ContractName.HeaderText = "Номер договора";
            this.ContractName.Name = "ContractName";
            // 
            // DateContract
            // 
            this.DateContract.DataPropertyName = "DateContract";
            this.DateContract.HeaderText = "Дата договора";
            this.DateContract.Name = "DateContract";
            // 
            // DateBegin
            // 
            this.DateBegin.DataPropertyName = "DateBegin";
            this.DateBegin.HeaderText = "Дата начала";
            this.DateBegin.Name = "DateBegin";
            // 
            // DateEnd
            // 
            this.DateEnd.DataPropertyName = "DateEnd";
            this.DateEnd.HeaderText = "Дата окончания";
            this.DateEnd.Name = "DateEnd";
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
            this.tableLayoutPanel5.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.tcEmplData.ResumeLayout(false);
            this.tpPersonData.ResumeLayout(false);
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
            ((System.ComponentModel.ISupportInitialize)(this.businessTripDecoratorBindingSource)).EndInit();
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
            this.tpBonus.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAllBonus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.AllbonusBindingSource)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            this.tpEducation.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeDegreeBindingSource)).EndInit();
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
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportColumnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BusinessTripsBindingSource)).EndInit();
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

            /*if (tcEmployee.SelectedTab == tpEmplBonus)
            {
                bonusFrame1.BonusObject = Employee;
                bonusFrame1.LoadBonus();
            }*/

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
                    FactStaffPrikaz factStaffPrikaz = new Data.FactStaffPrikaz();
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffPrikaz, FactStaff>(factStaffPrikaz, "FactStaff", factStaffBindingSource.Current as FactStaff, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffPrikaz, Prikaz>(factStaffPrikaz, "Prikaz", NullPrikaz.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffPrikaz, DateTime?>(factStaffPrikaz, "DateBegin", DateTime.Today, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<FactStaffPrikaz, DateTime?>(factStaffPrikaz, "DateEnd", DateTime.Today, null), this);

                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_Otpusk, FactStaffPrikaz>(x, "FactStaffPrikaz", factStaffPrikaz, null), this);
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

                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, FactStaffPrikaz>(x, "FactStaffPrikaz", new FactStaffPrikaz(DateTime.Now, DateTime.Now.AddDays(7), fs), null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTrip, string>(x, "TripTargetPlace", " ", null), this);
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

        private void tsbAddMaterial_Click(object sender, EventArgs e)
        {
            using (var dlg = new Common.PropertyGridDialogAdding<MaterialResponsibility>())
            {
                dlg.ObjectList = KadrController.Instance.Model.MaterialResponsibilities;
                dlg.UseInternalCommandManager = true;
                dlg.InitializeNewObject = (x) =>
                {
                    var factStaffPrikaz = new Data.FactStaffPrikaz();
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
                            DateTime.Today, null), this);

                    dlg.CommandManager.Execute(
                        new GenericPropertyCommand<MaterialResponsibility, FactStaffPrikaz>(x,
                            "FactStaffPrikaz", factStaffPrikaz, null), this);
                   // var contract = new Data.Contract();
                    dlg.CommandManager.Execute(new GenericPropertyCommand<MaterialResponsibility, Contract>(x, "Contract", new Contract(), null), this);
                    dlg.CommandManager.Execute(new GenericPropertyCommand<Contract, DateTime?>(x.Contract, "DateContract", DateTime.Today, null), this);
                    dlg.CommandManager.Execute(
                        new UIX.Commands.GenericPropertyCommand<Contract, string>(x.Contract, "ContractName", "", null),
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

    }

}
