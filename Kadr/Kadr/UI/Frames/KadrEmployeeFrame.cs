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
        private GroupBox groupBox2;
        private TableLayoutPanel tableLayoutPanel12;
        private DataGridView dgvLanguages;
        private ToolStrip toolStrip11;
        private ToolStripButton tsbAddLanguage;
        private ToolStripButton tsbEditLanguage;
        private ToolStripButton tsbDeleteLanguage;
        private DataGridView dgvEducation;
        private TabPage tpIncapacities;
        private DataGridView dgvIncapacities;
        private BindingSource inkapacityDecoratorBindingSource;
        private ToolStrip toolStrip12;
        private ToolStripButton tsbAddIncapacity;
        private ToolStripButton tsbEditIncapacity;
        private ToolStripButton tsbDeleteIncapacity;
        private TabPage tpAwards;
        private DataGridView dgvAwards;
        private ToolStrip toolStrip13;
        private ToolStripButton tsbAddAward;
        private ToolStripButton tsbEditAward;
        private ToolStripButton tsbDelAward;
        private BindingSource awardDecoratorBindingSource;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn organizationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn prikazDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn targetPlaceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn finSourceDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private DataGridViewTextBoxColumn DateEnd;
        private DataGridViewCheckBoxColumn SocialFareTransit;
        private TabPage tpSocial;
        private DataGridView dgvSocials;
        private ToolStrip toolStrip14;
        private ToolStripButton tsbAddSocial;
        private ToolStripButton tsbEditSocial;
        private ToolStripButton tsbDelSocial;
        private BindingSource socialDecoratorBindingSource;
        private DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn organizationDataGridViewTextBoxColumn1;
        private BindingSource EducationBindingSource;
        private DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn;
        private TabPage tpValidations;
        private DataGridView dgvValidations;
        private ToolStrip toolStrip15;
        private ToolStripButton tsbAddValidation;
        private ToolStripButton tsbEditValidation;
        private ToolStripButton tsbDelValidation;
        private DataGridViewTextBoxColumn organizationDataGridViewTextBoxColumn2;
        private BindingSource validationDecoratorBindingSource;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn prikazDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn decisionDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn docDateDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn commentaryDataGridViewTextBoxColumn;
        private BindingSource timeSheetDayStateBindingSource;
        private BindingSource oKLanguageBindingSource;
        private BindingSource languageLevelBindingSource;
        private BindingSource employeeLangDecoratorBindingSource;
        private DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn educWhenDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn whereDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn educDocumentTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn seriaDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn organizationDataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn qualificationDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn specDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn languageDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn languageLevelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn levelDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn serieDataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn organizationDataGridViewTextBoxColumn3;
        private TabPage tpDopEducation;
        private SplitContainer splitContainer4;
        private GroupBox groupBox3;
        private TableLayoutPanel tableLayoutPanel13;
        private ToolStrip toolStrip16;
        private ToolStripButton AddEducationBtn;
        private ToolStripButton EditEducationBtn;
        private ToolStripButton DeleteEducationBtn;
        private DataGridView dataGridView9;
        private BindingSource DopEducationBindingSource;
        private ToolStrip toolStrip17;
        private ToolStripButton AddDopEducBtn;
        private ToolStripButton EditDopEducBtn;
        private ToolStripButton DeleteDopEducBtn;
        private DataGridViewTextBoxColumn idEducDocumentDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEmployeeDataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn educWhereDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn educWhenDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn specDataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn kvalifDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn idEducationTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn educationTypeDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn educDocumentDataGridViewTextBoxColumn2;

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

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle8 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle13 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle14 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle15 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle16 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle17 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle18 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle19 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle20 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle21 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle22 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle23 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle24 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle25 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle26 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle27 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle28 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle29 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle30 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle31 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle32 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle33 = new System.Windows.Forms.DataGridViewCellStyle();
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
            this.tpAwards = new System.Windows.Forms.TabPage();
            this.dgvAwards = new System.Windows.Forms.DataGridView();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serieDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organizationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awardDecoratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip13 = new System.Windows.Forms.ToolStrip();
            this.tsbAddAward = new System.Windows.Forms.ToolStripButton();
            this.tsbEditAward = new System.Windows.Forms.ToolStripButton();
            this.tsbDelAward = new System.Windows.Forms.ToolStripButton();
            this.tpSocial = new System.Windows.Forms.TabPage();
            this.dgvSocials = new System.Windows.Forms.DataGridView();
            this.statusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serieDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organizationDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.socialDecoratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip14 = new System.Windows.Forms.ToolStrip();
            this.tsbAddSocial = new System.Windows.Forms.ToolStripButton();
            this.tsbEditSocial = new System.Windows.Forms.ToolStripButton();
            this.tsbDelSocial = new System.Windows.Forms.ToolStripButton();
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
            this.SocialFareTransit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
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
            this.tpValidations = new System.Windows.Forms.TabPage();
            this.dgvValidations = new System.Windows.Forms.DataGridView();
            this.dateDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikazDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.decisionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serieDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docDateDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentaryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.validationDecoratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip15 = new System.Windows.Forms.ToolStrip();
            this.tsbAddValidation = new System.Windows.Forms.ToolStripButton();
            this.tsbEditValidation = new System.Windows.Forms.ToolStripButton();
            this.tsbDelValidation = new System.Windows.Forms.ToolStripButton();
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
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel13 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvEducation = new System.Windows.Forms.DataGridView();
            this.typeDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educWhenDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.whereDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educDocumentTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriaDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organizationDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.qualificationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.EducationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip16 = new System.Windows.Forms.ToolStrip();
            this.AddEducationBtn = new System.Windows.Forms.ToolStripButton();
            this.EditEducationBtn = new System.Windows.Forms.ToolStripButton();
            this.DeleteEducationBtn = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tableLayoutPanel12 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvLanguages = new System.Windows.Forms.DataGridView();
            this.languageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.languageLevelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serieDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.organizationDataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeLangDecoratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip11 = new System.Windows.Forms.ToolStrip();
            this.tsbAddLanguage = new System.Windows.Forms.ToolStripButton();
            this.tsbEditLanguage = new System.Windows.Forms.ToolStripButton();
            this.tsbDeleteLanguage = new System.Windows.Forms.ToolStripButton();
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
            this.tpDopEducation = new System.Windows.Forms.TabPage();
            this.dataGridView9 = new System.Windows.Forms.DataGridView();
            this.idEducDocumentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployeeDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educWhereDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educWhenDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.specDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.kvalifDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEducationTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educationTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.educDocumentDataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DopEducationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip17 = new System.Windows.Forms.ToolStrip();
            this.AddDopEducBtn = new System.Windows.Forms.ToolStripButton();
            this.EditDopEducBtn = new System.Windows.Forms.ToolStripButton();
            this.DeleteDopEducBtn = new System.Windows.Forms.ToolStripButton();
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
            this.bonusReportColumnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bonusTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.timeSheetDayStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.languageLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.oKLanguageBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.tpAwards.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAwards)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.awardDecoratorBindingSource)).BeginInit();
            this.toolStrip13.SuspendLayout();
            this.tpSocial.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocials)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.socialDecoratorBindingSource)).BeginInit();
            this.toolStrip14.SuspendLayout();
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
            this.tpValidations.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidations)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.validationDecoratorBindingSource)).BeginInit();
            this.toolStrip15.SuspendLayout();
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
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tableLayoutPanel13.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEducation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.EducationBindingSource)).BeginInit();
            this.toolStrip16.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tableLayoutPanel12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeLangDecoratorBindingSource)).BeginInit();
            this.toolStrip11.SuspendLayout();
            this.tpPostGradEduc.SuspendLayout();
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
            this.tpDopEducation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DopEducationBindingSource)).BeginInit();
            this.toolStrip17.SuspendLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.timeSheetDayStateBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageLevelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKLanguageBindingSource)).BeginInit();
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
            this.tcEmplData.Controls.Add(this.tpSocial);
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
            this.splitContainer3.SplitterDistance = 167;
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
            this.tableLayoutPanel8.Size = new System.Drawing.Size(869, 167);
            this.tableLayoutPanel8.TabIndex = 0;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idphoneDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn1,
            this.phoneDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn1});
            this.dataGridView1.DataSource = this.oKphoneBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
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
            this.tableLayoutPanel9.Size = new System.Drawing.Size(869, 168);
            this.tableLayoutPanel9.TabIndex = 1;
            // 
            // dataGridView6
            // 
            this.dataGridView6.AllowUserToAddRows = false;
            this.dataGridView6.AllowUserToDeleteRows = false;
            this.dataGridView6.AutoGenerateColumns = false;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView6.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView6.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView6.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idAdressDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn2,
            this.adressDataGridViewTextBoxColumn,
            this.dateRegDataGridViewTextBoxColumn,
            this.regBitDataGridViewCheckBoxColumn,
            this.employeeDataGridViewTextBoxColumn2});
            this.dataGridView6.DataSource = this.oKAdressBindingSource;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView6.DefaultCellStyle = dataGridViewCellStyle4;
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
            this.tpFamily.Size = new System.Drawing.Size(788, 501);
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
            this.tableLayoutPanel10.Size = new System.Drawing.Size(782, 495);
            this.tableLayoutPanel10.TabIndex = 0;
            // 
            // dataGridView7
            // 
            this.dataGridView7.AllowUserToAddRows = false;
            this.dataGridView7.AllowUserToDeleteRows = false;
            this.dataGridView7.AutoGenerateColumns = false;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView7.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
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
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView7.DefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView7.Location = new System.Drawing.Point(3, 27);
            this.dataGridView7.Name = "dataGridView7";
            this.dataGridView7.ReadOnly = true;
            this.dataGridView7.RowHeadersVisible = false;
            this.dataGridView7.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView7.Size = new System.Drawing.Size(776, 465);
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
            this.toolStrip9.Size = new System.Drawing.Size(782, 24);
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
            this.dgvAwards.AutoGenerateColumns = false;
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAwards.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle7;
            this.dgvAwards.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAwards.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.serieDataGridViewTextBoxColumn1,
            this.numberDataGridViewTextBoxColumn1,
            this.organizationDataGridViewTextBoxColumn});
            this.dgvAwards.DataSource = this.awardDecoratorBindingSource;
            dataGridViewCellStyle8.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle8.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle8.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle8.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle8.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle8.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAwards.DefaultCellStyle = dataGridViewCellStyle8;
            this.dgvAwards.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAwards.Location = new System.Drawing.Point(3, 28);
            this.dgvAwards.Name = "dgvAwards";
            this.dgvAwards.ReadOnly = true;
            this.dgvAwards.RowHeadersVisible = false;
            this.dgvAwards.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAwards.Size = new System.Drawing.Size(863, 308);
            this.dgvAwards.TabIndex = 6;
            this.dgvAwards.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvAwards_CellDoubleClick);
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Наименование награды";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Дата вручения";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serieDataGridViewTextBoxColumn1
            // 
            this.serieDataGridViewTextBoxColumn1.DataPropertyName = "Serie";
            this.serieDataGridViewTextBoxColumn1.HeaderText = "Серия";
            this.serieDataGridViewTextBoxColumn1.Name = "serieDataGridViewTextBoxColumn1";
            this.serieDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // numberDataGridViewTextBoxColumn1
            // 
            this.numberDataGridViewTextBoxColumn1.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn1.HeaderText = "Номер";
            this.numberDataGridViewTextBoxColumn1.Name = "numberDataGridViewTextBoxColumn1";
            this.numberDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // organizationDataGridViewTextBoxColumn
            // 
            this.organizationDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.organizationDataGridViewTextBoxColumn.DataPropertyName = "Organization";
            this.organizationDataGridViewTextBoxColumn.HeaderText = "Организация";
            this.organizationDataGridViewTextBoxColumn.Name = "organizationDataGridViewTextBoxColumn";
            this.organizationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // awardDecoratorBindingSource
            // 
            this.awardDecoratorBindingSource.DataSource = typeof(Kadr.Data.AwardDecorator);
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
            this.tsbAddAward.Click += new System.EventHandler(this.tsbAddAward_Click);
            // 
            // tsbEditAward
            // 
            this.tsbEditAward.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditAward.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditAward.Name = "tsbEditAward";
            this.tsbEditAward.Size = new System.Drawing.Size(107, 22);
            this.tsbEditAward.Text = "Редактировать";
            this.tsbEditAward.ToolTipText = "Редактировать награду";
            this.tsbEditAward.Click += new System.EventHandler(this.tsbEditAward_Click);
            // 
            // tsbDelAward
            // 
            this.tsbDelAward.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelAward.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelAward.Name = "tsbDelAward";
            this.tsbDelAward.Size = new System.Drawing.Size(71, 22);
            this.tsbDelAward.Text = "Удалить";
            this.tsbDelAward.ToolTipText = "Удалить награду";
            this.tsbDelAward.Click += new System.EventHandler(this.tsbDelAward_Click);
            // 
            // tpSocial
            // 
            this.tpSocial.Controls.Add(this.dgvSocials);
            this.tpSocial.Controls.Add(this.toolStrip14);
            this.tpSocial.Location = new System.Drawing.Point(4, 22);
            this.tpSocial.Name = "tpSocial";
            this.tpSocial.Padding = new System.Windows.Forms.Padding(3);
            this.tpSocial.Size = new System.Drawing.Size(869, 339);
            this.tpSocial.TabIndex = 4;
            this.tpSocial.Text = "Социальные льготы";
            this.tpSocial.UseVisualStyleBackColor = true;
            // 
            // dgvSocials
            // 
            this.dgvSocials.AllowUserToAddRows = false;
            this.dgvSocials.AllowUserToDeleteRows = false;
            this.dgvSocials.AutoGenerateColumns = false;
            this.dgvSocials.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocials.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.statusDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn1,
            this.serieDataGridViewTextBoxColumn2,
            this.numberDataGridViewTextBoxColumn2,
            this.organizationDataGridViewTextBoxColumn1});
            this.dgvSocials.DataSource = this.socialDecoratorBindingSource;
            this.dgvSocials.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSocials.Location = new System.Drawing.Point(3, 28);
            this.dgvSocials.Name = "dgvSocials";
            this.dgvSocials.ReadOnly = true;
            this.dgvSocials.RowHeadersVisible = false;
            this.dgvSocials.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvSocials.Size = new System.Drawing.Size(863, 308);
            this.dgvSocials.TabIndex = 8;
            this.dgvSocials.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvSocials_CellDoubleClick);
            // 
            // statusDataGridViewTextBoxColumn
            // 
            this.statusDataGridViewTextBoxColumn.DataPropertyName = "Status";
            this.statusDataGridViewTextBoxColumn.HeaderText = "Социальный статус";
            this.statusDataGridViewTextBoxColumn.Name = "statusDataGridViewTextBoxColumn";
            this.statusDataGridViewTextBoxColumn.ReadOnly = true;
            this.statusDataGridViewTextBoxColumn.Width = 200;
            // 
            // dateDataGridViewTextBoxColumn1
            // 
            this.dateDataGridViewTextBoxColumn1.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn1.HeaderText = "Дата утверждения";
            this.dateDataGridViewTextBoxColumn1.Name = "dateDataGridViewTextBoxColumn1";
            this.dateDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // serieDataGridViewTextBoxColumn2
            // 
            this.serieDataGridViewTextBoxColumn2.DataPropertyName = "Serie";
            this.serieDataGridViewTextBoxColumn2.HeaderText = "\t\tСерия";
            this.serieDataGridViewTextBoxColumn2.Name = "serieDataGridViewTextBoxColumn2";
            this.serieDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // numberDataGridViewTextBoxColumn2
            // 
            this.numberDataGridViewTextBoxColumn2.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn2.HeaderText = "\tНомер";
            this.numberDataGridViewTextBoxColumn2.Name = "numberDataGridViewTextBoxColumn2";
            this.numberDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // organizationDataGridViewTextBoxColumn1
            // 
            this.organizationDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.organizationDataGridViewTextBoxColumn1.DataPropertyName = "Organization";
            this.organizationDataGridViewTextBoxColumn1.HeaderText = "Организация";
            this.organizationDataGridViewTextBoxColumn1.Name = "organizationDataGridViewTextBoxColumn1";
            this.organizationDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // socialDecoratorBindingSource
            // 
            this.socialDecoratorBindingSource.DataSource = typeof(Kadr.Data.SocialDecorator);
            // 
            // toolStrip14
            // 
            this.toolStrip14.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddSocial,
            this.tsbEditSocial,
            this.tsbDelSocial});
            this.toolStrip14.Location = new System.Drawing.Point(3, 3);
            this.toolStrip14.Name = "toolStrip14";
            this.toolStrip14.Size = new System.Drawing.Size(863, 25);
            this.toolStrip14.TabIndex = 7;
            this.toolStrip14.Text = "toolStrip14";
            // 
            // tsbAddSocial
            // 
            this.tsbAddSocial.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddSocial.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddSocial.Name = "tsbAddSocial";
            this.tsbAddSocial.Size = new System.Drawing.Size(188, 22);
            this.tsbAddSocial.Text = "Добавить социальный статус";
            this.tsbAddSocial.Click += new System.EventHandler(this.tsbAddSocial_Click);
            // 
            // tsbEditSocial
            // 
            this.tsbEditSocial.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditSocial.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditSocial.Name = "tsbEditSocial";
            this.tsbEditSocial.Size = new System.Drawing.Size(107, 22);
            this.tsbEditSocial.Text = "Редактировать";
            this.tsbEditSocial.ToolTipText = "Редактировать социальный статус";
            this.tsbEditSocial.Click += new System.EventHandler(this.tsbEditSocial_Click);
            // 
            // tsbDelSocial
            // 
            this.tsbDelSocial.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelSocial.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelSocial.Name = "tsbDelSocial";
            this.tsbDelSocial.Size = new System.Drawing.Size(71, 22);
            this.tsbDelSocial.Text = "Удалить";
            this.tsbDelSocial.ToolTipText = "Удалить социальный статус";
            this.tsbDelSocial.Click += new System.EventHandler(this.tsbDelSocial_Click);
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
            this.tcEmplWorkData.Controls.Add(this.tpIncapacities);
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
            this.splitContainer1.SplitterDistance = 189;
            this.splitContainer1.TabIndex = 2;
            // 
            // dgvEmplPosts
            // 
            this.dgvEmplPosts.AllowUserToAddRows = false;
            this.dgvEmplPosts.AllowUserToDeleteRows = false;
            this.dgvEmplPosts.AutoGenerateColumns = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEmplPosts.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
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
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle10.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEmplPosts.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvEmplPosts.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEmplPosts.Location = new System.Drawing.Point(0, 0);
            this.dgvEmplPosts.Name = "dgvEmplPosts";
            this.dgvEmplPosts.ReadOnly = true;
            this.dgvEmplPosts.RowHeadersVisible = false;
            this.dgvEmplPosts.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEmplPosts.Size = new System.Drawing.Size(863, 189);
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
            this.tcEmplPostInf.Controls.Add(this.tpValidations);
            this.tcEmplPostInf.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEmplPostInf.Location = new System.Drawing.Point(0, 0);
            this.tcEmplPostInf.Name = "tcEmplPostInf";
            this.tcEmplPostInf.SelectedIndex = 0;
            this.tcEmplPostInf.Size = new System.Drawing.Size(863, 140);
            this.tcEmplPostInf.TabIndex = 1;
            this.tcEmplPostInf.SelectedIndexChanged += new System.EventHandler(this.tcEmplPostInf_SelectedIndexChanged);
            // 
            // tpEmpOtpusk
            // 
            this.tpEmpOtpusk.Controls.Add(this.tableLayoutPanel7);
            this.tpEmpOtpusk.Location = new System.Drawing.Point(4, 22);
            this.tpEmpOtpusk.Name = "tpEmpOtpusk";
            this.tpEmpOtpusk.Padding = new System.Windows.Forms.Padding(3);
            this.tpEmpOtpusk.Size = new System.Drawing.Size(855, 114);
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
            this.tableLayoutPanel7.Size = new System.Drawing.Size(849, 108);
            this.tableLayoutPanel7.TabIndex = 1;
            // 
            // dataGridView5
            // 
            this.dataGridView5.AllowUserToAddRows = false;
            this.dataGridView5.AllowUserToDeleteRows = false;
            this.dataGridView5.AutoGenerateColumns = false;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView5.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle11;
            this.dataGridView5.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView5.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn11,
            this.DateEnd,
            this.SocialFareTransit});
            this.dataGridView5.DataSource = this.oKOtpuskBindingSource;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView5.DefaultCellStyle = dataGridViewCellStyle12;
            this.dataGridView5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView5.Location = new System.Drawing.Point(3, 27);
            this.dataGridView5.Name = "dataGridView5";
            this.dataGridView5.ReadOnly = true;
            this.dataGridView5.RowHeadersVisible = false;
            this.dataGridView5.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView5.Size = new System.Drawing.Size(843, 182);
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
            this.dataGridViewTextBoxColumn11.Width = 120;
            // 
            // DateEnd
            // 
            this.DateEnd.DataPropertyName = "RealDateEnd";
            this.DateEnd.HeaderText = "Дата окончания";
            this.DateEnd.Name = "DateEnd";
            this.DateEnd.ReadOnly = true;
            this.DateEnd.Width = 120;
            // 
            // SocialFareTransit
            // 
            this.SocialFareTransit.DataPropertyName = "WithSocialFareTransit";
            this.SocialFareTransit.HeaderText = "С соц проездом";
            this.SocialFareTransit.Name = "SocialFareTransit";
            this.SocialFareTransit.ReadOnly = true;
            this.SocialFareTransit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.SocialFareTransit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.SocialFareTransit.Width = 120;
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
            this.tpBusTrip.Size = new System.Drawing.Size(855, 114);
            this.tpBusTrip.TabIndex = 1;
            this.tpBusTrip.Text = "Командировки";
            this.tpBusTrip.UseVisualStyleBackColor = true;
            // 
            // dgvTrips
            // 
            this.dgvTrips.AutoGenerateColumns = false;
            dataGridViewCellStyle13.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle13.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle13.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle13.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle13.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle13.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTrips.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle13;
            this.dgvTrips.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTrips.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prikazDataGridViewTextBoxColumn,
            this.dateBeginDataGridViewTextBoxColumn1,
            this.dateEndDataGridViewTextBoxColumn2,
            this.targetPlaceDataGridViewTextBoxColumn,
            this.finSourceDataGridViewTextBoxColumn});
            this.dgvTrips.DataSource = this.BusinessTripsBindingSource;
            dataGridViewCellStyle14.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle14.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle14.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle14.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle14.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle14.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvTrips.DefaultCellStyle = dataGridViewCellStyle14;
            this.dgvTrips.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTrips.Location = new System.Drawing.Point(3, 28);
            this.dgvTrips.Name = "dgvTrips";
            this.dgvTrips.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTrips.Size = new System.Drawing.Size(849, 83);
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
            this.finSourceDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            this.tsbAddEmplTrip.Size = new System.Drawing.Size(162, 22);
            this.tsbAddEmplTrip.Text = "Добавить командировку";
            this.tsbAddEmplTrip.Click += new System.EventHandler(this.tsbAddEmplTrip_Click);
            // 
            // tsbEditEmplTrip
            // 
            this.tsbEditEmplTrip.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditEmplTrip.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditEmplTrip.Name = "tsbEditEmplTrip";
            this.tsbEditEmplTrip.Size = new System.Drawing.Size(107, 22);
            this.tsbEditEmplTrip.Text = "Редактировать";
            this.tsbEditEmplTrip.ToolTipText = "Редактировать командировку";
            this.tsbEditEmplTrip.Click += new System.EventHandler(this.tsbEditEmplTrip_Click);
            // 
            // tsbDelEmplTrip
            // 
            this.tsbDelEmplTrip.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelEmplTrip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelEmplTrip.Name = "tsbDelEmplTrip";
            this.tsbDelEmplTrip.Size = new System.Drawing.Size(71, 22);
            this.tsbDelEmplTrip.Text = "Удалить";
            this.tsbDelEmplTrip.ToolTipText = "Удалить командировку";
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
            this.tpMaterial.Size = new System.Drawing.Size(855, 114);
            this.tpMaterial.TabIndex = 2;
            this.tpMaterial.Text = "Материальная ответственность";
            this.tpMaterial.UseVisualStyleBackColor = true;
            // 
            // dgvMaterial
            // 
            this.dgvMaterial.AllowUserToAddRows = false;
            this.dgvMaterial.AllowUserToDeleteRows = false;
            this.dgvMaterial.AutoGenerateColumns = false;
            dataGridViewCellStyle15.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle15.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle15.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle15.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle15.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle15.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvMaterial.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle15;
            this.dgvMaterial.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMaterial.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colPrikazMaterial,
            this.colNumContractMaterial,
            this.colDateContractMaterial,
            this.colSumMaterial,
            this.colDataBeginMaterial,
            this.colDateEndMaterial});
            this.dgvMaterial.DataSource = this.MaterialResponsibilitybindingSource;
            dataGridViewCellStyle16.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle16.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle16.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle16.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle16.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle16.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvMaterial.DefaultCellStyle = dataGridViewCellStyle16;
            this.dgvMaterial.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMaterial.Location = new System.Drawing.Point(3, 28);
            this.dgvMaterial.MultiSelect = false;
            this.dgvMaterial.Name = "dgvMaterial";
            this.dgvMaterial.ReadOnly = true;
            this.dgvMaterial.RowHeadersWidth = 4;
            this.dgvMaterial.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvMaterial.Size = new System.Drawing.Size(849, 83);
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
            // tpValidations
            // 
            this.tpValidations.Controls.Add(this.dgvValidations);
            this.tpValidations.Controls.Add(this.toolStrip15);
            this.tpValidations.Location = new System.Drawing.Point(4, 22);
            this.tpValidations.Name = "tpValidations";
            this.tpValidations.Padding = new System.Windows.Forms.Padding(3);
            this.tpValidations.Size = new System.Drawing.Size(855, 114);
            this.tpValidations.TabIndex = 3;
            this.tpValidations.Text = "Аттестации";
            this.tpValidations.UseVisualStyleBackColor = true;
            // 
            // dgvValidations
            // 
            this.dgvValidations.AllowUserToAddRows = false;
            this.dgvValidations.AllowUserToDeleteRows = false;
            this.dgvValidations.AutoGenerateColumns = false;
            dataGridViewCellStyle17.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle17.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle17.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle17.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle17.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle17.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvValidations.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle17;
            this.dgvValidations.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvValidations.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateDataGridViewTextBoxColumn2,
            this.prikazDataGridViewTextBoxColumn1,
            this.decisionDataGridViewTextBoxColumn,
            this.serieDataGridViewTextBoxColumn3,
            this.numberDataGridViewTextBoxColumn3,
            this.docDateDataGridViewTextBoxColumn1,
            this.commentaryDataGridViewTextBoxColumn});
            this.dgvValidations.DataSource = this.validationDecoratorBindingSource;
            dataGridViewCellStyle18.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle18.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle18.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle18.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle18.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle18.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle18.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvValidations.DefaultCellStyle = dataGridViewCellStyle18;
            this.dgvValidations.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvValidations.Location = new System.Drawing.Point(3, 28);
            this.dgvValidations.MultiSelect = false;
            this.dgvValidations.Name = "dgvValidations";
            this.dgvValidations.ReadOnly = true;
            this.dgvValidations.RowHeadersWidth = 4;
            this.dgvValidations.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvValidations.Size = new System.Drawing.Size(849, 83);
            this.dgvValidations.TabIndex = 16;
            this.dgvValidations.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvValidations_CellDoubleClick);
            // 
            // dateDataGridViewTextBoxColumn2
            // 
            this.dateDataGridViewTextBoxColumn2.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn2.HeaderText = "Дата аттестации";
            this.dateDataGridViewTextBoxColumn2.Name = "dateDataGridViewTextBoxColumn2";
            this.dateDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // prikazDataGridViewTextBoxColumn1
            // 
            this.prikazDataGridViewTextBoxColumn1.DataPropertyName = "Prikaz";
            this.prikazDataGridViewTextBoxColumn1.HeaderText = "Приказ";
            this.prikazDataGridViewTextBoxColumn1.Name = "prikazDataGridViewTextBoxColumn1";
            this.prikazDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // decisionDataGridViewTextBoxColumn
            // 
            this.decisionDataGridViewTextBoxColumn.DataPropertyName = "Decision";
            this.decisionDataGridViewTextBoxColumn.HeaderText = "Решение комиссии";
            this.decisionDataGridViewTextBoxColumn.Name = "decisionDataGridViewTextBoxColumn";
            this.decisionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serieDataGridViewTextBoxColumn3
            // 
            this.serieDataGridViewTextBoxColumn3.DataPropertyName = "Serie";
            this.serieDataGridViewTextBoxColumn3.HeaderText = "\t\tСерия подтверждающего документа";
            this.serieDataGridViewTextBoxColumn3.Name = "serieDataGridViewTextBoxColumn3";
            this.serieDataGridViewTextBoxColumn3.ReadOnly = true;
            this.serieDataGridViewTextBoxColumn3.Width = 150;
            // 
            // numberDataGridViewTextBoxColumn3
            // 
            this.numberDataGridViewTextBoxColumn3.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn3.HeaderText = "\tНомер подтверждающего документа";
            this.numberDataGridViewTextBoxColumn3.Name = "numberDataGridViewTextBoxColumn3";
            this.numberDataGridViewTextBoxColumn3.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn3.Width = 150;
            // 
            // docDateDataGridViewTextBoxColumn1
            // 
            this.docDateDataGridViewTextBoxColumn1.DataPropertyName = "DocDate";
            this.docDateDataGridViewTextBoxColumn1.HeaderText = "Дата выдачи подтверждающего документа";
            this.docDateDataGridViewTextBoxColumn1.Name = "docDateDataGridViewTextBoxColumn1";
            this.docDateDataGridViewTextBoxColumn1.ReadOnly = true;
            this.docDateDataGridViewTextBoxColumn1.Width = 150;
            // 
            // commentaryDataGridViewTextBoxColumn
            // 
            this.commentaryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.commentaryDataGridViewTextBoxColumn.DataPropertyName = "Commentary";
            this.commentaryDataGridViewTextBoxColumn.HeaderText = "Дополнительная информация";
            this.commentaryDataGridViewTextBoxColumn.Name = "commentaryDataGridViewTextBoxColumn";
            this.commentaryDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // validationDecoratorBindingSource
            // 
            this.validationDecoratorBindingSource.DataSource = typeof(Kadr.Data.ValidationDecorator);
            // 
            // toolStrip15
            // 
            this.toolStrip15.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddValidation,
            this.tsbEditValidation,
            this.tsbDelValidation});
            this.toolStrip15.Location = new System.Drawing.Point(3, 3);
            this.toolStrip15.Name = "toolStrip15";
            this.toolStrip15.Size = new System.Drawing.Size(849, 25);
            this.toolStrip15.TabIndex = 15;
            this.toolStrip15.Text = "toolStrip7";
            // 
            // tsbAddValidation
            // 
            this.tsbAddValidation.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddValidation.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddValidation.Name = "tsbAddValidation";
            this.tsbAddValidation.Size = new System.Drawing.Size(145, 22);
            this.tsbAddValidation.Text = "Добавить аттестацию";
            this.tsbAddValidation.Click += new System.EventHandler(this.tsbAddValidation_Click);
            // 
            // tsbEditValidation
            // 
            this.tsbEditValidation.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditValidation.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditValidation.Name = "tsbEditValidation";
            this.tsbEditValidation.Size = new System.Drawing.Size(107, 22);
            this.tsbEditValidation.Text = "Редактировать";
            this.tsbEditValidation.ToolTipText = "Редактировать аттестацию";
            this.tsbEditValidation.Click += new System.EventHandler(this.tsbEditValidation_Click);
            // 
            // tsbDelValidation
            // 
            this.tsbDelValidation.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelValidation.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelValidation.Name = "tsbDelValidation";
            this.tsbDelValidation.Size = new System.Drawing.Size(71, 22);
            this.tsbDelValidation.Text = "Удалить";
            this.tsbDelValidation.ToolTipText = "Удалить аттестацию";
            this.tsbDelValidation.Click += new System.EventHandler(this.tsbDelValidation_Click);
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
            dataGridViewCellStyle19.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle19.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle19.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle19.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle19.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle19.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView4.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle19;
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
            dataGridViewCellStyle20.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle20.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle20.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle20.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle20.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle20.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle20.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView4.DefaultCellStyle = dataGridViewCellStyle20;
            this.dataGridView4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView4.Location = new System.Drawing.Point(3, 28);
            this.dataGridView4.MultiSelect = false;
            this.dataGridView4.Name = "dataGridView4";
            this.dataGridView4.ReadOnly = true;
            this.dataGridView4.RowHeadersVisible = false;
            this.dataGridView4.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView4.Size = new System.Drawing.Size(857, 302);
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
            this.toolStrip2.Size = new System.Drawing.Size(863, 25);
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
            dataGridViewCellStyle21.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle21.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle21.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle21.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle21.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle21.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvIncapacities.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle21;
            this.dgvIncapacities.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvIncapacities.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateBeginDataGridViewTextBoxColumn2,
            this.dateEndDataGridViewTextBoxColumn3,
            this.serieDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.docDateDataGridViewTextBoxColumn});
            this.dgvIncapacities.DataSource = this.inkapacityDecoratorBindingSource;
            dataGridViewCellStyle22.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle22.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle22.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle22.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle22.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle22.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvIncapacities.DefaultCellStyle = dataGridViewCellStyle22;
            this.dgvIncapacities.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvIncapacities.Location = new System.Drawing.Point(3, 28);
            this.dgvIncapacities.MultiSelect = false;
            this.dgvIncapacities.Name = "dgvIncapacities";
            this.dgvIncapacities.ReadOnly = true;
            this.dgvIncapacities.RowHeadersVisible = false;
            this.dgvIncapacities.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvIncapacities.Size = new System.Drawing.Size(863, 308);
            this.dgvIncapacities.TabIndex = 11;
            this.dgvIncapacities.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvIncapacities_CellDoubleClick);
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
            this.docDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
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
            this.tsbAddIncapacity.Size = new System.Drawing.Size(241, 22);
            this.tsbAddIncapacity.Text = "Добавить период нетрудоспособности";
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
            this.tpBonus.Size = new System.Drawing.Size(883, 371);
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
            this.tableLayoutPanel1.Size = new System.Drawing.Size(877, 365);
            this.tableLayoutPanel1.TabIndex = 3;
            // 
            // dgvAllBonus
            // 
            this.dgvAllBonus.AllowUserToAddRows = false;
            this.dgvAllBonus.AllowUserToDeleteRows = false;
            this.dgvAllBonus.AutoGenerateColumns = false;
            dataGridViewCellStyle23.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle23.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle23.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle23.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle23.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle23.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAllBonus.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle23;
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
            dataGridViewCellStyle24.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle24.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle24.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle24.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle24.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle24.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAllBonus.DefaultCellStyle = dataGridViewCellStyle24;
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
            this.tpEducation.Size = new System.Drawing.Size(883, 371);
            this.tpEducation.TabIndex = 3;
            this.tpEducation.Text = "Образование";
            this.tpEducation.UseVisualStyleBackColor = true;
            // 
            // tcEducation
            // 
            this.tcEducation.Controls.Add(this.tpGrandEducation);
            this.tcEducation.Controls.Add(this.tpPostGradEduc);
            this.tcEducation.Controls.Add(this.tpDopEducation);
            this.tcEducation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcEducation.Location = new System.Drawing.Point(3, 3);
            this.tcEducation.Name = "tcEducation";
            this.tcEducation.SelectedIndex = 0;
            this.tcEducation.Size = new System.Drawing.Size(877, 365);
            this.tcEducation.TabIndex = 4;
            // 
            // tpGrandEducation
            // 
            this.tpGrandEducation.Controls.Add(this.splitContainer4);
            this.tpGrandEducation.Location = new System.Drawing.Point(4, 22);
            this.tpGrandEducation.Name = "tpGrandEducation";
            this.tpGrandEducation.Padding = new System.Windows.Forms.Padding(3);
            this.tpGrandEducation.Size = new System.Drawing.Size(869, 339);
            this.tpGrandEducation.TabIndex = 1;
            this.tpGrandEducation.Text = "Основное образование";
            this.tpGrandEducation.UseVisualStyleBackColor = true;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(3, 3);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.groupBox3);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer4.Size = new System.Drawing.Size(863, 333);
            this.splitContainer4.SplitterDistance = 180;
            this.splitContainer4.TabIndex = 11;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tableLayoutPanel13);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(863, 180);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // tableLayoutPanel13
            // 
            this.tableLayoutPanel13.ColumnCount = 1;
            this.tableLayoutPanel13.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel13.Controls.Add(this.dgvEducation, 0, 1);
            this.tableLayoutPanel13.Controls.Add(this.toolStrip16, 0, 0);
            this.tableLayoutPanel13.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel13.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel13.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel13.Name = "tableLayoutPanel13";
            this.tableLayoutPanel13.RowCount = 2;
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel13.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel13.Size = new System.Drawing.Size(857, 161);
            this.tableLayoutPanel13.TabIndex = 0;
            // 
            // dgvEducation
            // 
            this.dgvEducation.AllowUserToAddRows = false;
            this.dgvEducation.AllowUserToDeleteRows = false;
            this.dgvEducation.AutoGenerateColumns = false;
            dataGridViewCellStyle25.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle25.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle25.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle25.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle25.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle25.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEducation.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle25;
            this.dgvEducation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.typeDataGridViewTextBoxColumn1,
            this.educWhenDataGridViewTextBoxColumn,
            this.whereDataGridViewTextBoxColumn,
            this.educDocumentTypeDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn4,
            this.seriaDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn5,
            this.organizationDataGridViewTextBoxColumn4,
            this.qualificationDataGridViewTextBoxColumn,
            this.specDataGridViewTextBoxColumn});
            this.dgvEducation.DataSource = this.EducationBindingSource;
            dataGridViewCellStyle26.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle26.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle26.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle26.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle26.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle26.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvEducation.DefaultCellStyle = dataGridViewCellStyle26;
            this.dgvEducation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEducation.Location = new System.Drawing.Point(3, 28);
            this.dgvEducation.MultiSelect = false;
            this.dgvEducation.Name = "dgvEducation";
            this.dgvEducation.ReadOnly = true;
            dataGridViewCellStyle27.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle27.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle27.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle27.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle27.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle27.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle27.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvEducation.RowHeadersDefaultCellStyle = dataGridViewCellStyle27;
            this.dgvEducation.RowHeadersVisible = false;
            this.dgvEducation.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvEducation.Size = new System.Drawing.Size(851, 333);
            this.dgvEducation.TabIndex = 9;
            this.dgvEducation.DoubleClick += new System.EventHandler(this.EditEducationBtn_Click);
            // 
            // typeDataGridViewTextBoxColumn1
            // 
            this.typeDataGridViewTextBoxColumn1.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn1.HeaderText = "Тип образования";
            this.typeDataGridViewTextBoxColumn1.Name = "typeDataGridViewTextBoxColumn1";
            this.typeDataGridViewTextBoxColumn1.ReadOnly = true;
            this.typeDataGridViewTextBoxColumn1.Width = 200;
            // 
            // educWhenDataGridViewTextBoxColumn
            // 
            this.educWhenDataGridViewTextBoxColumn.DataPropertyName = "EducWhen";
            this.educWhenDataGridViewTextBoxColumn.HeaderText = "Год окончания";
            this.educWhenDataGridViewTextBoxColumn.Name = "educWhenDataGridViewTextBoxColumn";
            this.educWhenDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // whereDataGridViewTextBoxColumn
            // 
            this.whereDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.whereDataGridViewTextBoxColumn.DataPropertyName = "Where";
            this.whereDataGridViewTextBoxColumn.HeaderText = "Образовательное учреждение";
            this.whereDataGridViewTextBoxColumn.Name = "whereDataGridViewTextBoxColumn";
            this.whereDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // educDocumentTypeDataGridViewTextBoxColumn
            // 
            this.educDocumentTypeDataGridViewTextBoxColumn.DataPropertyName = "EducDocumentType";
            this.educDocumentTypeDataGridViewTextBoxColumn.HeaderText = "Вид документа";
            this.educDocumentTypeDataGridViewTextBoxColumn.Name = "educDocumentTypeDataGridViewTextBoxColumn";
            this.educDocumentTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.educDocumentTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateDataGridViewTextBoxColumn4
            // 
            this.dateDataGridViewTextBoxColumn4.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn4.HeaderText = "Дата вручения";
            this.dateDataGridViewTextBoxColumn4.Name = "dateDataGridViewTextBoxColumn4";
            this.dateDataGridViewTextBoxColumn4.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn4.Visible = false;
            // 
            // seriaDataGridViewTextBoxColumn
            // 
            this.seriaDataGridViewTextBoxColumn.DataPropertyName = "Seria";
            this.seriaDataGridViewTextBoxColumn.HeaderText = "\t\tСерия";
            this.seriaDataGridViewTextBoxColumn.Name = "seriaDataGridViewTextBoxColumn";
            this.seriaDataGridViewTextBoxColumn.ReadOnly = true;
            this.seriaDataGridViewTextBoxColumn.Visible = false;
            // 
            // numberDataGridViewTextBoxColumn5
            // 
            this.numberDataGridViewTextBoxColumn5.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn5.HeaderText = "\tНомер";
            this.numberDataGridViewTextBoxColumn5.Name = "numberDataGridViewTextBoxColumn5";
            this.numberDataGridViewTextBoxColumn5.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn5.Visible = false;
            // 
            // organizationDataGridViewTextBoxColumn4
            // 
            this.organizationDataGridViewTextBoxColumn4.DataPropertyName = "Organization";
            this.organizationDataGridViewTextBoxColumn4.HeaderText = "Организация";
            this.organizationDataGridViewTextBoxColumn4.Name = "organizationDataGridViewTextBoxColumn4";
            this.organizationDataGridViewTextBoxColumn4.ReadOnly = true;
            this.organizationDataGridViewTextBoxColumn4.Visible = false;
            // 
            // qualificationDataGridViewTextBoxColumn
            // 
            this.qualificationDataGridViewTextBoxColumn.DataPropertyName = "Qualification";
            this.qualificationDataGridViewTextBoxColumn.HeaderText = "Квалификация";
            this.qualificationDataGridViewTextBoxColumn.Name = "qualificationDataGridViewTextBoxColumn";
            this.qualificationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // specDataGridViewTextBoxColumn
            // 
            this.specDataGridViewTextBoxColumn.DataPropertyName = "Spec";
            this.specDataGridViewTextBoxColumn.HeaderText = "Направление/Специальность";
            this.specDataGridViewTextBoxColumn.Name = "specDataGridViewTextBoxColumn";
            this.specDataGridViewTextBoxColumn.ReadOnly = true;
            this.specDataGridViewTextBoxColumn.Width = 250;
            // 
            // EducationBindingSource
            // 
            this.EducationBindingSource.DataSource = typeof(Kadr.Data.EducationDecorator);
            // 
            // toolStrip16
            // 
            this.toolStrip16.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddEducationBtn,
            this.EditEducationBtn,
            this.DeleteEducationBtn});
            this.toolStrip16.Location = new System.Drawing.Point(0, 0);
            this.toolStrip16.Name = "toolStrip16";
            this.toolStrip16.Size = new System.Drawing.Size(857, 25);
            this.toolStrip16.TabIndex = 8;
            this.toolStrip16.Text = "toolStrip16";
            // 
            // AddEducationBtn
            // 
            this.AddEducationBtn.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.AddEducationBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddEducationBtn.Name = "AddEducationBtn";
            this.AddEducationBtn.Size = new System.Drawing.Size(153, 22);
            this.AddEducationBtn.Text = "Добавить образование";
            this.AddEducationBtn.Click += new System.EventHandler(this.AddEducationBtn_Click);
            // 
            // EditEducationBtn
            // 
            this.EditEducationBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditEducationBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditEducationBtn.Name = "EditEducationBtn";
            this.EditEducationBtn.Size = new System.Drawing.Size(107, 22);
            this.EditEducationBtn.Text = "Редактировать";
            this.EditEducationBtn.ToolTipText = "Редактировать образование";
            this.EditEducationBtn.Click += new System.EventHandler(this.EditEducationBtn_Click);
            // 
            // DeleteEducationBtn
            // 
            this.DeleteEducationBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DeleteEducationBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteEducationBtn.Name = "DeleteEducationBtn";
            this.DeleteEducationBtn.Size = new System.Drawing.Size(71, 22);
            this.DeleteEducationBtn.Text = "Удалить";
            this.DeleteEducationBtn.ToolTipText = "Удалить образование";
            this.DeleteEducationBtn.Click += new System.EventHandler(this.DeleteEducationBtn_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tableLayoutPanel12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(863, 149);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Языки";
            // 
            // tableLayoutPanel12
            // 
            this.tableLayoutPanel12.AutoScroll = true;
            this.tableLayoutPanel12.ColumnCount = 1;
            this.tableLayoutPanel12.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel12.Controls.Add(this.dgvLanguages, 0, 1);
            this.tableLayoutPanel12.Controls.Add(this.toolStrip11, 0, 0);
            this.tableLayoutPanel12.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel12.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel12.Name = "tableLayoutPanel12";
            this.tableLayoutPanel12.RowCount = 2;
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tableLayoutPanel12.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel12.Size = new System.Drawing.Size(857, 130);
            this.tableLayoutPanel12.TabIndex = 3;
            // 
            // dgvLanguages
            // 
            this.dgvLanguages.AllowUserToAddRows = false;
            this.dgvLanguages.AllowUserToDeleteRows = false;
            this.dgvLanguages.AutoGenerateColumns = false;
            dataGridViewCellStyle28.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle28.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle28.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle28.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle28.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle28.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle28.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvLanguages.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle28;
            this.dgvLanguages.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.languageDataGridViewTextBoxColumn,
            this.languageLevelDataGridViewTextBoxColumn,
            this.levelDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn3,
            this.serieDataGridViewTextBoxColumn4,
            this.numberDataGridViewTextBoxColumn4,
            this.organizationDataGridViewTextBoxColumn3});
            this.dgvLanguages.DataSource = this.employeeLangDecoratorBindingSource;
            dataGridViewCellStyle29.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle29.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle29.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle29.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle29.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle29.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvLanguages.DefaultCellStyle = dataGridViewCellStyle29;
            this.dgvLanguages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLanguages.Location = new System.Drawing.Point(3, 28);
            this.dgvLanguages.MultiSelect = false;
            this.dgvLanguages.Name = "dgvLanguages";
            this.dgvLanguages.ReadOnly = true;
            this.dgvLanguages.RowHeadersVisible = false;
            this.dgvLanguages.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvLanguages.Size = new System.Drawing.Size(877, 227);
            this.dgvLanguages.TabIndex = 8;
            // 
            // languageDataGridViewTextBoxColumn
            // 
            this.languageDataGridViewTextBoxColumn.DataPropertyName = "Language";
            this.languageDataGridViewTextBoxColumn.HeaderText = "Название языка";
            this.languageDataGridViewTextBoxColumn.Name = "languageDataGridViewTextBoxColumn";
            this.languageDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // languageLevelDataGridViewTextBoxColumn
            // 
            this.languageLevelDataGridViewTextBoxColumn.DataPropertyName = "LanguageLevel";
            this.languageLevelDataGridViewTextBoxColumn.HeaderText = "Степень владения";
            this.languageLevelDataGridViewTextBoxColumn.Name = "languageLevelDataGridViewTextBoxColumn";
            this.languageLevelDataGridViewTextBoxColumn.ReadOnly = true;
            this.languageLevelDataGridViewTextBoxColumn.Width = 150;
            // 
            // levelDataGridViewTextBoxColumn
            // 
            this.levelDataGridViewTextBoxColumn.DataPropertyName = "Level";
            this.levelDataGridViewTextBoxColumn.HeaderText = "Хороший уровень";
            this.levelDataGridViewTextBoxColumn.Name = "levelDataGridViewTextBoxColumn";
            this.levelDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateDataGridViewTextBoxColumn3
            // 
            this.dateDataGridViewTextBoxColumn3.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn3.HeaderText = "Дата подтверждения";
            this.dateDataGridViewTextBoxColumn3.Name = "dateDataGridViewTextBoxColumn3";
            this.dateDataGridViewTextBoxColumn3.ReadOnly = true;
            this.dateDataGridViewTextBoxColumn3.Width = 150;
            // 
            // serieDataGridViewTextBoxColumn4
            // 
            this.serieDataGridViewTextBoxColumn4.DataPropertyName = "Serie";
            this.serieDataGridViewTextBoxColumn4.HeaderText = "\t\tСерия";
            this.serieDataGridViewTextBoxColumn4.Name = "serieDataGridViewTextBoxColumn4";
            this.serieDataGridViewTextBoxColumn4.ReadOnly = true;
            this.serieDataGridViewTextBoxColumn4.Visible = false;
            // 
            // numberDataGridViewTextBoxColumn4
            // 
            this.numberDataGridViewTextBoxColumn4.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn4.HeaderText = "\tНомер";
            this.numberDataGridViewTextBoxColumn4.Name = "numberDataGridViewTextBoxColumn4";
            this.numberDataGridViewTextBoxColumn4.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn4.Visible = false;
            // 
            // organizationDataGridViewTextBoxColumn3
            // 
            this.organizationDataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.organizationDataGridViewTextBoxColumn3.DataPropertyName = "Organization";
            this.organizationDataGridViewTextBoxColumn3.HeaderText = "Организация, выдавшая сертификат/диплом";
            this.organizationDataGridViewTextBoxColumn3.Name = "organizationDataGridViewTextBoxColumn3";
            this.organizationDataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // employeeLangDecoratorBindingSource
            // 
            this.employeeLangDecoratorBindingSource.DataSource = typeof(Kadr.Data.EmployeeLangDecorator);
            // 
            // toolStrip11
            // 
            this.toolStrip11.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddLanguage,
            this.tsbEditLanguage,
            this.tsbDeleteLanguage});
            this.toolStrip11.Location = new System.Drawing.Point(0, 0);
            this.toolStrip11.Name = "toolStrip11";
            this.toolStrip11.Size = new System.Drawing.Size(883, 25);
            this.toolStrip11.TabIndex = 7;
            this.toolStrip11.Text = "toolStrip11";
            // 
            // tsbAddLanguage
            // 
            this.tsbAddLanguage.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddLanguage.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddLanguage.Name = "tsbAddLanguage";
            this.tsbAddLanguage.Size = new System.Drawing.Size(108, 22);
            this.tsbAddLanguage.Text = "Добавить язык";
            this.tsbAddLanguage.Click += new System.EventHandler(this.tsbAddLanguage_Click);
            // 
            // tsbEditLanguage
            // 
            this.tsbEditLanguage.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditLanguage.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditLanguage.Name = "tsbEditLanguage";
            this.tsbEditLanguage.Size = new System.Drawing.Size(107, 22);
            this.tsbEditLanguage.Text = "Редактировать";
            this.tsbEditLanguage.ToolTipText = "Редактировать степень";
            this.tsbEditLanguage.Click += new System.EventHandler(this.tsbEditLanguage_Click);
            // 
            // tsbDeleteLanguage
            // 
            this.tsbDeleteLanguage.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDeleteLanguage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDeleteLanguage.Name = "tsbDeleteLanguage";
            this.tsbDeleteLanguage.Size = new System.Drawing.Size(71, 22);
            this.tsbDeleteLanguage.Text = "Удалить";
            this.tsbDeleteLanguage.ToolTipText = "Удалить степень";
            this.tsbDeleteLanguage.Click += new System.EventHandler(this.tsbDeleteLanguage_Click);
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
            this.splitContainer2.SplitterDistance = 166;
            this.splitContainer2.TabIndex = 2;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tableLayoutPanel3);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(863, 166);
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
            this.tableLayoutPanel3.Size = new System.Drawing.Size(857, 147);
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
            this.groupBox5.Size = new System.Drawing.Size(863, 163);
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
            this.tableLayoutPanel4.Size = new System.Drawing.Size(857, 144);
            this.tableLayoutPanel4.TabIndex = 2;
            // 
            // dataGridView3
            // 
            this.dataGridView3.AllowUserToAddRows = false;
            this.dataGridView3.AllowUserToDeleteRows = false;
            this.dataGridView3.AutoGenerateColumns = false;
            dataGridViewCellStyle30.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle30.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle30.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle30.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle30.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle30.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle30.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView3.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle30;
            this.dataGridView3.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView3.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.rankDataGridViewTextBoxColumn,
            this.educDocumentDataGridViewTextBoxColumn1,
            this.rankWhereDataGridViewTextBoxColumn});
            this.dataGridView3.DataSource = this.employeeRankBindingSource;
            dataGridViewCellStyle31.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle31.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle31.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle31.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle31.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle31.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView3.DefaultCellStyle = dataGridViewCellStyle31;
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
            // tpDopEducation
            // 
            this.tpDopEducation.Controls.Add(this.dataGridView9);
            this.tpDopEducation.Controls.Add(this.toolStrip17);
            this.tpDopEducation.Location = new System.Drawing.Point(4, 22);
            this.tpDopEducation.Name = "tpDopEducation";
            this.tpDopEducation.Padding = new System.Windows.Forms.Padding(3);
            this.tpDopEducation.Size = new System.Drawing.Size(869, 339);
            this.tpDopEducation.TabIndex = 2;
            this.tpDopEducation.Text = "Повышение квалификации и проф. переподготовка";
            this.tpDopEducation.UseVisualStyleBackColor = true;
            // 
            // dataGridView9
            // 
            this.dataGridView9.AllowUserToAddRows = false;
            this.dataGridView9.AllowUserToDeleteRows = false;
            this.dataGridView9.AutoGenerateColumns = false;
            this.dataGridView9.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idEducDocumentDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn5,
            this.educWhereDataGridViewTextBoxColumn,
            this.educWhenDataGridViewTextBoxColumn1,
            this.specDataGridViewTextBoxColumn1,
            this.kvalifDataGridViewTextBoxColumn,
            this.idEducationTypeDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn5,
            this.educationTypeDataGridViewTextBoxColumn,
            this.educDocumentDataGridViewTextBoxColumn2});
            this.dataGridView9.DataSource = this.DopEducationBindingSource;
            this.dataGridView9.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView9.Location = new System.Drawing.Point(3, 28);
            this.dataGridView9.MultiSelect = false;
            this.dataGridView9.Name = "dataGridView9";
            this.dataGridView9.ReadOnly = true;
            this.dataGridView9.RowHeadersVisible = false;
            this.dataGridView9.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView9.Size = new System.Drawing.Size(863, 308);
            this.dataGridView9.TabIndex = 10;
            // 
            // idEducDocumentDataGridViewTextBoxColumn
            // 
            this.idEducDocumentDataGridViewTextBoxColumn.DataPropertyName = "idEducDocument";
            this.idEducDocumentDataGridViewTextBoxColumn.HeaderText = "idEducDocument";
            this.idEducDocumentDataGridViewTextBoxColumn.Name = "idEducDocumentDataGridViewTextBoxColumn";
            this.idEducDocumentDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEmployeeDataGridViewTextBoxColumn5
            // 
            this.idEmployeeDataGridViewTextBoxColumn5.DataPropertyName = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn5.HeaderText = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn5.Name = "idEmployeeDataGridViewTextBoxColumn5";
            this.idEmployeeDataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // educWhereDataGridViewTextBoxColumn
            // 
            this.educWhereDataGridViewTextBoxColumn.DataPropertyName = "EducWhere";
            this.educWhereDataGridViewTextBoxColumn.HeaderText = "EducWhere";
            this.educWhereDataGridViewTextBoxColumn.Name = "educWhereDataGridViewTextBoxColumn";
            this.educWhereDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // educWhenDataGridViewTextBoxColumn1
            // 
            this.educWhenDataGridViewTextBoxColumn1.DataPropertyName = "EducWhen";
            this.educWhenDataGridViewTextBoxColumn1.HeaderText = "EducWhen";
            this.educWhenDataGridViewTextBoxColumn1.Name = "educWhenDataGridViewTextBoxColumn1";
            this.educWhenDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // specDataGridViewTextBoxColumn1
            // 
            this.specDataGridViewTextBoxColumn1.DataPropertyName = "Spec";
            this.specDataGridViewTextBoxColumn1.HeaderText = "Spec";
            this.specDataGridViewTextBoxColumn1.Name = "specDataGridViewTextBoxColumn1";
            this.specDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // kvalifDataGridViewTextBoxColumn
            // 
            this.kvalifDataGridViewTextBoxColumn.DataPropertyName = "Kvalif";
            this.kvalifDataGridViewTextBoxColumn.HeaderText = "Kvalif";
            this.kvalifDataGridViewTextBoxColumn.Name = "kvalifDataGridViewTextBoxColumn";
            this.kvalifDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // idEducationTypeDataGridViewTextBoxColumn
            // 
            this.idEducationTypeDataGridViewTextBoxColumn.DataPropertyName = "idEducationType";
            this.idEducationTypeDataGridViewTextBoxColumn.HeaderText = "idEducationType";
            this.idEducationTypeDataGridViewTextBoxColumn.Name = "idEducationTypeDataGridViewTextBoxColumn";
            this.idEducationTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // employeeDataGridViewTextBoxColumn5
            // 
            this.employeeDataGridViewTextBoxColumn5.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn5.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn5.Name = "employeeDataGridViewTextBoxColumn5";
            this.employeeDataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // educationTypeDataGridViewTextBoxColumn
            // 
            this.educationTypeDataGridViewTextBoxColumn.DataPropertyName = "EducationType";
            this.educationTypeDataGridViewTextBoxColumn.HeaderText = "EducationType";
            this.educationTypeDataGridViewTextBoxColumn.Name = "educationTypeDataGridViewTextBoxColumn";
            this.educationTypeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // educDocumentDataGridViewTextBoxColumn2
            // 
            this.educDocumentDataGridViewTextBoxColumn2.DataPropertyName = "EducDocument";
            this.educDocumentDataGridViewTextBoxColumn2.HeaderText = "EducDocument";
            this.educDocumentDataGridViewTextBoxColumn2.Name = "educDocumentDataGridViewTextBoxColumn2";
            this.educDocumentDataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // DopEducationBindingSource
            // 
            this.DopEducationBindingSource.DataSource = typeof(Kadr.Data.OK_Educ);
            // 
            // toolStrip17
            // 
            this.toolStrip17.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddDopEducBtn,
            this.EditDopEducBtn,
            this.DeleteDopEducBtn});
            this.toolStrip17.Location = new System.Drawing.Point(3, 3);
            this.toolStrip17.Name = "toolStrip17";
            this.toolStrip17.Size = new System.Drawing.Size(863, 25);
            this.toolStrip17.TabIndex = 9;
            this.toolStrip17.Text = "toolStrip17";
            // 
            // AddDopEducBtn
            // 
            this.AddDopEducBtn.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.AddDopEducBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddDopEducBtn.Name = "AddDopEducBtn";
            this.AddDopEducBtn.Size = new System.Drawing.Size(135, 22);
            this.AddDopEducBtn.Text = "Добавить обучение";
            this.AddDopEducBtn.Click += new System.EventHandler(this.AddDopEducBtn_Click);
            // 
            // EditDopEducBtn
            // 
            this.EditDopEducBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditDopEducBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditDopEducBtn.Name = "EditDopEducBtn";
            this.EditDopEducBtn.Size = new System.Drawing.Size(107, 22);
            this.EditDopEducBtn.Text = "Редактировать";
            this.EditDopEducBtn.ToolTipText = "Редактировать обучение";
            this.EditDopEducBtn.Click += new System.EventHandler(this.EditDopEducBtn_Click);
            // 
            // DeleteDopEducBtn
            // 
            this.DeleteDopEducBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DeleteDopEducBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeleteDopEducBtn.Name = "DeleteDopEducBtn";
            this.DeleteDopEducBtn.Size = new System.Drawing.Size(71, 22);
            this.DeleteDopEducBtn.Text = "Удалить";
            this.DeleteDopEducBtn.ToolTipText = "Удалить обучение";
            this.DeleteDopEducBtn.Click += new System.EventHandler(this.DeleteDopEducBtn_Click);
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
            dataGridViewCellStyle32.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle32.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle32.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle32.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle32.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle32.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle32.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView8.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle32;
            this.dataGridView8.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView8.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDopInfDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn4,
            this.dopInfDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn4});
            this.dataGridView8.DataSource = this.oKDopInfBindingSource;
            dataGridViewCellStyle33.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle33.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle33.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle33.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle33.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle33.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView8.DefaultCellStyle = dataGridViewCellStyle33;
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
            // bonusReportColumnBindingSource
            // 
            this.bonusReportColumnBindingSource.DataSource = typeof(Kadr.Data.BonusReportColumn);
            // 
            // bonusTypeBindingSource
            // 
            this.bonusTypeBindingSource.DataSource = typeof(Kadr.Data.BonusType);
            // 
            // timeSheetDayStateBindingSource
            // 
            this.timeSheetDayStateBindingSource.DataSource = typeof(Kadr.Data.TimeSheetDayState);
            // 
            // languageLevelBindingSource
            // 
            this.languageLevelBindingSource.DataSource = typeof(Kadr.Data.LanguageLevel);
            // 
            // oKLanguageBindingSource
            // 
            this.oKLanguageBindingSource.DataSource = typeof(Kadr.Data.OK_Language);
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
            this.tpAwards.ResumeLayout(false);
            this.tpAwards.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAwards)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.awardDecoratorBindingSource)).EndInit();
            this.toolStrip13.ResumeLayout(false);
            this.toolStrip13.PerformLayout();
            this.tpSocial.ResumeLayout(false);
            this.tpSocial.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocials)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.socialDecoratorBindingSource)).EndInit();
            this.toolStrip14.ResumeLayout(false);
            this.toolStrip14.PerformLayout();
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
            this.tpValidations.ResumeLayout(false);
            this.tpValidations.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvValidations)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.validationDecoratorBindingSource)).EndInit();
            this.toolStrip15.ResumeLayout(false);
            this.toolStrip15.PerformLayout();
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
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            this.splitContainer4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tableLayoutPanel13.ResumeLayout(false);
            this.tableLayoutPanel13.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEducation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.EducationBindingSource)).EndInit();
            this.toolStrip16.ResumeLayout(false);
            this.toolStrip16.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.tableLayoutPanel12.ResumeLayout(false);
            this.tableLayoutPanel12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguages)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.employeeLangDecoratorBindingSource)).EndInit();
            this.toolStrip11.ResumeLayout(false);
            this.toolStrip11.PerformLayout();
            this.tpPostGradEduc.ResumeLayout(false);
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
            this.tpDopEducation.ResumeLayout(false);
            this.tpDopEducation.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DopEducationBindingSource)).EndInit();
            this.toolStrip17.ResumeLayout(false);
            this.toolStrip17.PerformLayout();
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
            ((System.ComponentModel.ISupportInitialize)(this.timeSheetDayStateBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.languageLevelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.oKLanguageBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

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
                CRUDVacation.Read((FactStaff)factStaffBindingSource.Current, Employee, oKOtpuskBindingSource);

            if (tcEmplPostInf.SelectedTab == tpBusTrip)
                CRUDBusinessTrips.Read((FactStaff)factStaffBindingSource.Current, BusinessTripsBindingSource);

            if (tcEmplPostInf.SelectedTab == tpMaterial)
                CRUDMaterial.Read((FactStaff)factStaffBindingSource.Current, MaterialResponsibilitybindingSource);

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
            CRUDEmployeeDegree.Create(Employee, this);

        }

        private void DelDegreeBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeDegree.Delete(employeeDegreeBindingSource);
        }

        private void AddRankBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeRank.Create(Employee, this);
        }

        private void EditRankBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeRank.Update(employeeDegreeBindingSource);
        }

        private void DelRankBtn_Click(object sender, EventArgs e)
        {
            CRUDEmployeeRank.Delete(employeeDegreeBindingSource);
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
            CRUDBusinessRegionType.Update(BusinessTripsBindingSource);
        }

        private void tsbAddMaterial_Click(object sender, EventArgs e)
        {
            CRUDMaterial.Create((FactStaff)factStaffBindingSource.Current, MaterialResponsibilitybindingSource, this);
        }

        private void tsbDelMaterial_Click(object sender, EventArgs e)
        {
            CRUDMaterial.Delete((FactStaff)factStaffBindingSource.Current, MaterialResponsibilitybindingSource);
        }

        private void tsbEditMaterial_Click(object sender, EventArgs e)
        {
            CRUDMaterial.Update((FactStaff)factStaffBindingSource.Current, MaterialResponsibilitybindingSource);
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
            //
        }

        private void EditDopEducBtn_Click(object sender, EventArgs e)
        {
            //
        }

        private void DeleteDopEducBtn_Click(object sender, EventArgs e)
        {
            //
        }

    }

}
