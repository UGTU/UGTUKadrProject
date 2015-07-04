namespace Kadr.UI.Dialogs
{
    partial class FactStaffBonusDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactStaffFinancingSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonusCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonusDateBegin = new Kadr.UI.Common.DataGridViewDateTimeColumn();
            this.BonusFinancingSourceName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.financingSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idPlanStaffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEndPrikazDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isReplacementDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.phoneNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDSheduleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idlaborcontraktDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idreasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFundingDepartmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idTimeSheetSheduleTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFundingCenterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDepartmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFinancingSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.commentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.depDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fundingCenterDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planStaffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikazDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factStaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.mtbDateEnd = new System.Windows.Forms.MaskedTextBox();
            this.tbComment = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPrikazIntermEnd = new System.Windows.Forms.ComboBox();
            this.prikazEntermEndBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label7 = new System.Windows.Forms.Label();
            this.cbPrikazEnd = new System.Windows.Forms.ComboBox();
            this.prikazEndBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrikazBegin = new System.Windows.Forms.ComboBox();
            this.prikazBeginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtDateBegin = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFinancingSource = new System.Windows.Forms.ComboBox();
            this.cbBonusType = new System.Windows.Forms.ComboBox();
            this.bonusTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.Exit = new System.Windows.Forms.Button();
            this.BonusFinSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financingSourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prikazEntermEndBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazEndBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazBeginBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonusFinSourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(1115, 450);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.Exit);
            this.panel2.Location = new System.Drawing.Point(12, 465);
            this.panel2.Size = new System.Drawing.Size(1115, 30);
            this.panel2.Controls.SetChildIndex(this.OKBtn, 0);
            this.panel2.Controls.SetChildIndex(this.CancelBtn, 0);
            this.panel2.Controls.SetChildIndex(this.ApplyBtn, 0);
            this.panel2.Controls.SetChildIndex(this.HelpBtn, 0);
            this.panel2.Controls.SetChildIndex(this.Exit, 0);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(1023, 0);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(931, 0);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            this.CancelBtn.Click += new System.EventHandler(this.CancelBtn_Click);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(839, 0);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dataGridView1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel3, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 146F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1115, 450);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Department,
            this.Post,
            this.Employee,
            this.StaffCount,
            this.WorkType,
            this.FactStaffFinancingSource,
            this.DateBegin,
            this.dateEndDataGridViewTextBoxColumn,
            this.BonusCount,
            this.BonusDateBegin,
            this.BonusFinancingSourceName,
            this.idDataGridViewTextBoxColumn,
            this.idPlanStaffDataGridViewTextBoxColumn,
            this.idEmployeeDataGridViewTextBoxColumn,
            this.idEndPrikazDataGridViewTextBoxColumn,
            this.isReplacementDataGridViewCheckBoxColumn,
            this.phoneNumberDataGridViewTextBoxColumn,
            this.iDSheduleDataGridViewTextBoxColumn,
            this.idlaborcontraktDataGridViewTextBoxColumn,
            this.idreasonDataGridViewTextBoxColumn,
            this.idFundingDepartmentDataGridViewTextBoxColumn,
            this.idTimeSheetSheduleTypeDataGridViewTextBoxColumn,
            this.idFundingCenterDataGridViewTextBoxColumn,
            this.idDepartmentDataGridViewTextBoxColumn,
            this.idFinancingSourceDataGridViewTextBoxColumn,
            this.commentDataGridViewTextBoxColumn,
            this.depDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn,
            this.fundingCenterDataGridViewTextBoxColumn,
            this.planStaffDataGridViewTextBoxColumn,
            this.prikazDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.factStaffBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 3);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1109, 298);
            this.dataGridView1.TabIndex = 1;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Отдел";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.Width = 120;
            // 
            // Post
            // 
            this.Post.DataPropertyName = "Post";
            this.Post.HeaderText = "Должность";
            this.Post.Name = "Post";
            this.Post.ReadOnly = true;
            this.Post.Width = 130;
            // 
            // Employee
            // 
            this.Employee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Employee.DataPropertyName = "Employee";
            this.Employee.HeaderText = "ФИО сотрудника";
            this.Employee.Name = "Employee";
            this.Employee.ReadOnly = true;
            // 
            // StaffCount
            // 
            this.StaffCount.DataPropertyName = "StaffCount";
            this.StaffCount.HeaderText = "Кол-во ставок";
            this.StaffCount.Name = "StaffCount";
            this.StaffCount.ReadOnly = true;
            this.StaffCount.Width = 50;
            // 
            // WorkType
            // 
            this.WorkType.DataPropertyName = "WorkType";
            this.WorkType.HeaderText = "Вид работы";
            this.WorkType.Name = "WorkType";
            this.WorkType.ReadOnly = true;
            this.WorkType.Width = 60;
            // 
            // FactStaffFinancingSource
            // 
            this.FactStaffFinancingSource.DataPropertyName = "FinSource";
            this.FactStaffFinancingSource.HeaderText = "Источник финанс";
            this.FactStaffFinancingSource.Name = "FactStaffFinancingSource";
            this.FactStaffFinancingSource.Width = 70;
            // 
            // DateBegin
            // 
            this.DateBegin.DataPropertyName = "DateBegin";
            this.DateBegin.HeaderText = "Дата приема";
            this.DateBegin.Name = "DateBegin";
            this.DateBegin.ReadOnly = true;
            this.DateBegin.Width = 75;
            // 
            // dateEndDataGridViewTextBoxColumn
            // 
            this.dateEndDataGridViewTextBoxColumn.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn.HeaderText = "Дата увольн";
            this.dateEndDataGridViewTextBoxColumn.Name = "dateEndDataGridViewTextBoxColumn";
            this.dateEndDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateEndDataGridViewTextBoxColumn.Width = 75;
            // 
            // BonusCount
            // 
            this.BonusCount.DataPropertyName = "BonusCount";
            this.BonusCount.HeaderText = "Размер надбавки";
            this.BonusCount.Name = "BonusCount";
            // 
            // BonusDateBegin
            // 
            this.BonusDateBegin.DataPropertyName = "BonusDateBegin";
            this.BonusDateBegin.HeaderText = "Дата назн";
            this.BonusDateBegin.Name = "BonusDateBegin";
            this.BonusDateBegin.Width = 80;
            // 
            // BonusFinancingSourceName
            // 
            this.BonusFinancingSourceName.DataPropertyName = "BonusFinancingSourceName";
            this.BonusFinancingSourceName.DataSource = this.financingSourceBindingSource;
            this.BonusFinancingSourceName.DisplayMember = "FinancingSourceName";
            this.BonusFinancingSourceName.HeaderText = "Источник финанс";
            this.BonusFinancingSourceName.Name = "BonusFinancingSourceName";
            this.BonusFinancingSourceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BonusFinancingSourceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BonusFinancingSourceName.Width = 75;
            // 
            // financingSourceBindingSource
            // 
            this.financingSourceBindingSource.DataSource = typeof(Kadr.Data.FinancingSource);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // idPlanStaffDataGridViewTextBoxColumn
            // 
            this.idPlanStaffDataGridViewTextBoxColumn.DataPropertyName = "idPlanStaff";
            this.idPlanStaffDataGridViewTextBoxColumn.HeaderText = "idPlanStaff";
            this.idPlanStaffDataGridViewTextBoxColumn.Name = "idPlanStaffDataGridViewTextBoxColumn";
            this.idPlanStaffDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEmployeeDataGridViewTextBoxColumn
            // 
            this.idEmployeeDataGridViewTextBoxColumn.DataPropertyName = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn.HeaderText = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn.Name = "idEmployeeDataGridViewTextBoxColumn";
            this.idEmployeeDataGridViewTextBoxColumn.Visible = false;
            // 
            // idEndPrikazDataGridViewTextBoxColumn
            // 
            this.idEndPrikazDataGridViewTextBoxColumn.DataPropertyName = "idEndPrikaz";
            this.idEndPrikazDataGridViewTextBoxColumn.HeaderText = "idEndPrikaz";
            this.idEndPrikazDataGridViewTextBoxColumn.Name = "idEndPrikazDataGridViewTextBoxColumn";
            this.idEndPrikazDataGridViewTextBoxColumn.Visible = false;
            // 
            // isReplacementDataGridViewCheckBoxColumn
            // 
            this.isReplacementDataGridViewCheckBoxColumn.DataPropertyName = "IsReplacement";
            this.isReplacementDataGridViewCheckBoxColumn.HeaderText = "IsReplacement";
            this.isReplacementDataGridViewCheckBoxColumn.Name = "isReplacementDataGridViewCheckBoxColumn";
            this.isReplacementDataGridViewCheckBoxColumn.Visible = false;
            // 
            // phoneNumberDataGridViewTextBoxColumn
            // 
            this.phoneNumberDataGridViewTextBoxColumn.DataPropertyName = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.HeaderText = "PhoneNumber";
            this.phoneNumberDataGridViewTextBoxColumn.Name = "phoneNumberDataGridViewTextBoxColumn";
            this.phoneNumberDataGridViewTextBoxColumn.Visible = false;
            // 
            // iDSheduleDataGridViewTextBoxColumn
            // 
            this.iDSheduleDataGridViewTextBoxColumn.DataPropertyName = "IDShedule";
            this.iDSheduleDataGridViewTextBoxColumn.HeaderText = "IDShedule";
            this.iDSheduleDataGridViewTextBoxColumn.Name = "iDSheduleDataGridViewTextBoxColumn";
            this.iDSheduleDataGridViewTextBoxColumn.Visible = false;
            // 
            // idlaborcontraktDataGridViewTextBoxColumn
            // 
            this.idlaborcontraktDataGridViewTextBoxColumn.DataPropertyName = "idlaborcontrakt";
            this.idlaborcontraktDataGridViewTextBoxColumn.HeaderText = "idlaborcontrakt";
            this.idlaborcontraktDataGridViewTextBoxColumn.Name = "idlaborcontraktDataGridViewTextBoxColumn";
            this.idlaborcontraktDataGridViewTextBoxColumn.Visible = false;
            // 
            // idreasonDataGridViewTextBoxColumn
            // 
            this.idreasonDataGridViewTextBoxColumn.DataPropertyName = "idreason";
            this.idreasonDataGridViewTextBoxColumn.HeaderText = "idreason";
            this.idreasonDataGridViewTextBoxColumn.Name = "idreasonDataGridViewTextBoxColumn";
            this.idreasonDataGridViewTextBoxColumn.Visible = false;
            // 
            // idFundingDepartmentDataGridViewTextBoxColumn
            // 
            this.idFundingDepartmentDataGridViewTextBoxColumn.DataPropertyName = "idFundingDepartment";
            this.idFundingDepartmentDataGridViewTextBoxColumn.HeaderText = "idFundingDepartment";
            this.idFundingDepartmentDataGridViewTextBoxColumn.Name = "idFundingDepartmentDataGridViewTextBoxColumn";
            this.idFundingDepartmentDataGridViewTextBoxColumn.Visible = false;
            // 
            // idTimeSheetSheduleTypeDataGridViewTextBoxColumn
            // 
            this.idTimeSheetSheduleTypeDataGridViewTextBoxColumn.DataPropertyName = "idTimeSheetSheduleType";
            this.idTimeSheetSheduleTypeDataGridViewTextBoxColumn.HeaderText = "idTimeSheetSheduleType";
            this.idTimeSheetSheduleTypeDataGridViewTextBoxColumn.Name = "idTimeSheetSheduleTypeDataGridViewTextBoxColumn";
            this.idTimeSheetSheduleTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // idFundingCenterDataGridViewTextBoxColumn
            // 
            this.idFundingCenterDataGridViewTextBoxColumn.DataPropertyName = "idFundingCenter";
            this.idFundingCenterDataGridViewTextBoxColumn.HeaderText = "idFundingCenter";
            this.idFundingCenterDataGridViewTextBoxColumn.Name = "idFundingCenterDataGridViewTextBoxColumn";
            this.idFundingCenterDataGridViewTextBoxColumn.Visible = false;
            // 
            // idDepartmentDataGridViewTextBoxColumn
            // 
            this.idDepartmentDataGridViewTextBoxColumn.DataPropertyName = "idDepartment";
            this.idDepartmentDataGridViewTextBoxColumn.HeaderText = "idDepartment";
            this.idDepartmentDataGridViewTextBoxColumn.Name = "idDepartmentDataGridViewTextBoxColumn";
            this.idDepartmentDataGridViewTextBoxColumn.Visible = false;
            // 
            // idFinancingSourceDataGridViewTextBoxColumn
            // 
            this.idFinancingSourceDataGridViewTextBoxColumn.DataPropertyName = "idFinancingSource";
            this.idFinancingSourceDataGridViewTextBoxColumn.HeaderText = "idFinancingSource";
            this.idFinancingSourceDataGridViewTextBoxColumn.Name = "idFinancingSourceDataGridViewTextBoxColumn";
            this.idFinancingSourceDataGridViewTextBoxColumn.Visible = false;
            // 
            // commentDataGridViewTextBoxColumn
            // 
            this.commentDataGridViewTextBoxColumn.DataPropertyName = "Comment";
            this.commentDataGridViewTextBoxColumn.HeaderText = "Comment";
            this.commentDataGridViewTextBoxColumn.Name = "commentDataGridViewTextBoxColumn";
            this.commentDataGridViewTextBoxColumn.Visible = false;
            // 
            // depDataGridViewTextBoxColumn
            // 
            this.depDataGridViewTextBoxColumn.DataPropertyName = "Dep";
            this.depDataGridViewTextBoxColumn.HeaderText = "Dep";
            this.depDataGridViewTextBoxColumn.Name = "depDataGridViewTextBoxColumn";
            this.depDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.Visible = false;
            // 
            // fundingCenterDataGridViewTextBoxColumn
            // 
            this.fundingCenterDataGridViewTextBoxColumn.DataPropertyName = "FundingCenter";
            this.fundingCenterDataGridViewTextBoxColumn.HeaderText = "FundingCenter";
            this.fundingCenterDataGridViewTextBoxColumn.Name = "fundingCenterDataGridViewTextBoxColumn";
            this.fundingCenterDataGridViewTextBoxColumn.Visible = false;
            // 
            // planStaffDataGridViewTextBoxColumn
            // 
            this.planStaffDataGridViewTextBoxColumn.DataPropertyName = "PlanStaff";
            this.planStaffDataGridViewTextBoxColumn.HeaderText = "PlanStaff";
            this.planStaffDataGridViewTextBoxColumn.Name = "planStaffDataGridViewTextBoxColumn";
            this.planStaffDataGridViewTextBoxColumn.Visible = false;
            // 
            // prikazDataGridViewTextBoxColumn
            // 
            this.prikazDataGridViewTextBoxColumn.DataPropertyName = "Prikaz";
            this.prikazDataGridViewTextBoxColumn.HeaderText = "Prikaz";
            this.prikazDataGridViewTextBoxColumn.Name = "prikazDataGridViewTextBoxColumn";
            this.prikazDataGridViewTextBoxColumn.Visible = false;
            // 
            // factStaffBindingSource
            // 
            this.factStaffBindingSource.DataSource = typeof(Kadr.Data.FactStaff);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.mtbDateEnd);
            this.panel3.Controls.Add(this.tbComment);
            this.panel3.Controls.Add(this.label8);
            this.panel3.Controls.Add(this.cbPrikazIntermEnd);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.cbPrikazEnd);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbPrikazBegin);
            this.panel3.Controls.Add(this.dtDateBegin);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbFinancingSource);
            this.panel3.Controls.Add(this.cbBonusType);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(3, 307);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1109, 140);
            this.panel3.TabIndex = 2;
            // 
            // mtbDateEnd
            // 
            this.mtbDateEnd.Location = new System.Drawing.Point(487, 69);
            this.mtbDateEnd.Mask = "00/00/0000";
            this.mtbDateEnd.Name = "mtbDateEnd";
            this.mtbDateEnd.Size = new System.Drawing.Size(159, 20);
            this.mtbDateEnd.TabIndex = 38;
            this.mtbDateEnd.ValidatingType = typeof(System.DateTime);
            // 
            // tbComment
            // 
            this.tbComment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tbComment.Location = new System.Drawing.Point(314, 109);
            this.tbComment.Name = "tbComment";
            this.tbComment.Size = new System.Drawing.Size(792, 20);
            this.tbComment.TabIndex = 37;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(311, 93);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 13);
            this.label8.TabIndex = 36;
            this.label8.Text = "Комментарий";
            // 
            // cbPrikazIntermEnd
            // 
            this.cbPrikazIntermEnd.DataSource = this.prikazEntermEndBindingSource;
            this.cbPrikazIntermEnd.FormattingEnabled = true;
            this.cbPrikazIntermEnd.Location = new System.Drawing.Point(9, 109);
            this.cbPrikazIntermEnd.Name = "cbPrikazIntermEnd";
            this.cbPrikazIntermEnd.Size = new System.Drawing.Size(285, 21);
            this.cbPrikazIntermEnd.TabIndex = 35;
            // 
            // prikazEntermEndBindingSource
            // 
            this.prikazEntermEndBindingSource.DataSource = typeof(Kadr.Data.Prikaz);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 93);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(184, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Промежуточный приказ об отмене";
            // 
            // cbPrikazEnd
            // 
            this.cbPrikazEnd.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbPrikazEnd.DataSource = this.prikazEndBindingSource;
            this.cbPrikazEnd.FormattingEnabled = true;
            this.cbPrikazEnd.Location = new System.Drawing.Point(652, 68);
            this.cbPrikazEnd.Name = "cbPrikazEnd";
            this.cbPrikazEnd.Size = new System.Drawing.Size(454, 21);
            this.cbPrikazEnd.TabIndex = 32;
            // 
            // prikazEndBindingSource
            // 
            this.prikazEndBindingSource.DataSource = typeof(Kadr.Data.Prikaz);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(484, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 30;
            this.label3.Text = "Дата отмены";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(649, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(100, 13);
            this.label6.TabIndex = 31;
            this.label6.Text = "Приказ об отмене";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(484, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(144, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Источник финансирования";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 22;
            this.label1.Text = "Вид надбавки";
            // 
            // cbPrikazBegin
            // 
            this.cbPrikazBegin.DataSource = this.prikazBeginBindingSource;
            this.cbPrikazBegin.FormattingEnabled = true;
            this.cbPrikazBegin.Location = new System.Drawing.Point(181, 68);
            this.cbPrikazBegin.Name = "cbPrikazBegin";
            this.cbPrikazBegin.Size = new System.Drawing.Size(288, 21);
            this.cbPrikazBegin.TabIndex = 26;
            // 
            // prikazBeginBindingSource
            // 
            this.prikazBeginBindingSource.DataSource = typeof(Kadr.Data.Prikaz);
            // 
            // dtDateBegin
            // 
            this.dtDateBegin.Location = new System.Drawing.Point(9, 69);
            this.dtDateBegin.Name = "dtDateBegin";
            this.dtDateBegin.Size = new System.Drawing.Size(166, 20);
            this.dtDateBegin.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(95, 13);
            this.label5.TabIndex = 24;
            this.label5.Text = "Дата назначения";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(178, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(116, 13);
            this.label4.TabIndex = 25;
            this.label4.Text = "Приказ о назначении";
            // 
            // cbFinancingSource
            // 
            this.cbFinancingSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFinancingSource.DataSource = this.financingSourceBindingSource;
            this.cbFinancingSource.FormattingEnabled = true;
            this.cbFinancingSource.Location = new System.Drawing.Point(487, 26);
            this.cbFinancingSource.Name = "cbFinancingSource";
            this.cbFinancingSource.Size = new System.Drawing.Size(619, 21);
            this.cbFinancingSource.TabIndex = 27;
            // 
            // cbBonusType
            // 
            this.cbBonusType.DataSource = this.bonusTypeBindingSource;
            this.cbBonusType.DisplayMember = "BonusTypeName";
            this.cbBonusType.FormattingEnabled = true;
            this.cbBonusType.Location = new System.Drawing.Point(9, 26);
            this.cbBonusType.Name = "cbBonusType";
            this.cbBonusType.Size = new System.Drawing.Size(460, 21);
            this.cbBonusType.TabIndex = 21;
            this.cbBonusType.ValueMember = "id";
            // 
            // bonusTypeBindingSource
            // 
            this.bonusTypeBindingSource.DataSource = typeof(Kadr.Data.BonusType);
            // 
            // Exit
            // 
            this.Exit.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Exit.Location = new System.Drawing.Point(712, 0);
            this.Exit.Name = "Exit";
            this.Exit.Size = new System.Drawing.Size(121, 26);
            this.Exit.TabIndex = 7;
            this.Exit.Text = "Выход без очистки";
            this.Exit.UseVisualStyleBackColor = true;
            this.Exit.Click += new System.EventHandler(this.Exit_Click);
            // 
            // BonusFinSourceBindingSource
            // 
            this.BonusFinSourceBindingSource.DataSource = typeof(Kadr.Data.FinancingSource);
            // 
            // FactStaffBonusDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1139, 503);
            this.Name = "FactStaffBonusDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Назначить надбавки";
            this.Load += new System.EventHandler(this.FactStaffBonusDialog0_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financingSourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prikazEntermEndBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazEndBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazBeginBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.BonusFinSourceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox tbComment;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cbPrikazIntermEnd;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cbPrikazEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPrikazBegin;
        private System.Windows.Forms.DateTimePicker dtDateBegin;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFinancingSource;
        private System.Windows.Forms.ComboBox cbBonusType;
        private System.Windows.Forms.BindingSource factStaffBindingSource;
        private System.Windows.Forms.BindingSource bonusTypeBindingSource;
        private System.Windows.Forms.BindingSource prikazEntermEndBindingSource;
        private System.Windows.Forms.BindingSource prikazEndBindingSource;
        private System.Windows.Forms.BindingSource prikazBeginBindingSource;
        private System.Windows.Forms.BindingSource financingSourceBindingSource;
        private System.Windows.Forms.MaskedTextBox mtbDateEnd;
        private System.Windows.Forms.Button Exit;
        private System.Windows.Forms.DataGridViewTextBoxColumn financingSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factStaffReplacementDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource BonusFinSourceBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactStaffFinancingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BonusCount;
        private Common.DataGridViewDateTimeColumn BonusDateBegin;
        private System.Windows.Forms.DataGridViewComboBoxColumn BonusFinancingSourceName;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idPlanStaffDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmployeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEndPrikazDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isReplacementDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDSheduleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlaborcontraktDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idreasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFundingDepartmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idTimeSheetSheduleTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFundingCenterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDepartmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFinancingSourceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn commentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn depDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fundingCenterDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planStaffDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikazDataGridViewTextBoxColumn;
    }
}