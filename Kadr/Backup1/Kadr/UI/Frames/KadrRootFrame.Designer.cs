namespace Kadr.UI.Frames
{
    partial class KadrRootFrame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tpStaff = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPlanStaff = new System.Windows.Forms.DataGridView();
            this.planStaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddPlanStaffBtn = new System.Windows.Forms.ToolStripButton();
            this.EditPlanStaffBtn = new System.Windows.Forms.ToolStripButton();
            this.DelPlanStaffBtn = new System.Windows.Forms.ToolStripButton();
            this.btnSalaryAdd = new System.Windows.Forms.ToolStripButton();
            this.btnEditSalary = new System.Windows.Forms.ToolStripButton();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvFactStaff = new System.Windows.Forms.DataGridView();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffCountDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBeginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikazDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikaz1DataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factStaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.AddFactStaffBtn = new System.Windows.Forms.ToolStripButton();
            this.EditFactStaffBtn = new System.Windows.Forms.ToolStripButton();
            this.DelFactStaffBtn = new System.Windows.Forms.ToolStripButton();
            this.TransferFactStaffBtn = new System.Windows.Forms.ToolStripButton();
            this.ptDepartments = new System.Windows.Forms.TabPage();
            this.dgvDepartments = new System.Windows.Forms.DataGridView();
            this.departmentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tcDepartment = new System.Windows.Forms.TabControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.дабавитьЗаписьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.categoryDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FinancingSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.postDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.staffCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikazDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikaz1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SalarySize = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HaveIndivSal = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tpStaff.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planStaffBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffBindingSource)).BeginInit();
            this.toolStrip2.SuspendLayout();
            this.ptDepartments.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.tcDepartment.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcDepartment);
            this.groupBox1.Size = new System.Drawing.Size(841, 524);
            // 
            // tpStaff
            // 
            this.tpStaff.Controls.Add(this.splitContainer1);
            this.tpStaff.Location = new System.Drawing.Point(4, 22);
            this.tpStaff.Name = "tpStaff";
            this.tpStaff.Padding = new System.Windows.Forms.Padding(3);
            this.tpStaff.Size = new System.Drawing.Size(827, 479);
            this.tpStaff.TabIndex = 1;
            this.tpStaff.Text = "Штаты";
            this.tpStaff.UseVisualStyleBackColor = true;
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
            this.splitContainer1.Panel1.Controls.Add(this.tableLayoutPanel1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.tableLayoutPanel2);
            this.splitContainer1.Size = new System.Drawing.Size(821, 473);
            this.splitContainer1.SplitterDistance = 225;
            this.splitContainer1.TabIndex = 0;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.dgvPlanStaff, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(821, 225);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvPlanStaff
            // 
            this.dgvPlanStaff.AllowUserToAddRows = false;
            this.dgvPlanStaff.AllowUserToDeleteRows = false;
            this.dgvPlanStaff.AutoGenerateColumns = false;
            this.dgvPlanStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryDataGridViewTextBoxColumn,
            this.FinancingSource,
            this.postDataGridViewTextBoxColumn,
            this.staffCountDataGridViewTextBoxColumn,
            this.prikazDataGridViewTextBoxColumn,
            this.prikaz1DataGridViewTextBoxColumn,
            this.SalarySize,
            this.HaveIndivSal});
            this.dgvPlanStaff.DataSource = this.planStaffBindingSource;
            this.dgvPlanStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanStaff.Location = new System.Drawing.Point(3, 29);
            this.dgvPlanStaff.Name = "dgvPlanStaff";
            this.dgvPlanStaff.ReadOnly = true;
            this.dgvPlanStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanStaff.Size = new System.Drawing.Size(815, 226);
            this.dgvPlanStaff.TabIndex = 1;
            this.dgvPlanStaff.DoubleClick += new System.EventHandler(this.dgvPlanStaff_DoubleClick);
            // 
            // planStaffBindingSource
            // 
            this.planStaffBindingSource.DataSource = typeof(Kadr.Data.PlanStaff);
            this.planStaffBindingSource.PositionChanged += new System.EventHandler(this.planStaffBindingSource_PositionChanged);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPlanStaffBtn,
            this.EditPlanStaffBtn,
            this.DelPlanStaffBtn,
            this.btnSalaryAdd,
            this.btnEditSalary});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddPlanStaffBtn
            // 
            this.AddPlanStaffBtn.Image = global::Kadr.Properties.Resources.NewDocumentHS;
            this.AddPlanStaffBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddPlanStaffBtn.Name = "AddPlanStaffBtn";
            this.AddPlanStaffBtn.Size = new System.Drawing.Size(114, 22);
            this.AddPlanStaffBtn.Text = "Добавить запись";
            this.AddPlanStaffBtn.Click += new System.EventHandler(this.btnAddPlanStaff_Click);
            // 
            // EditPlanStaffBtn
            // 
            this.EditPlanStaffBtn.Image = global::Kadr.Properties.Resources.Open;
            this.EditPlanStaffBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditPlanStaffBtn.Name = "EditPlanStaffBtn";
            this.EditPlanStaffBtn.Size = new System.Drawing.Size(143, 22);
            this.EditPlanStaffBtn.Text = "Редактировать запись";
            this.EditPlanStaffBtn.Click += new System.EventHandler(this.EditPlanStaffBtn_Click);
            // 
            // DelPlanStaffBtn
            // 
            this.DelPlanStaffBtn.Image = global::Kadr.Properties.Resources.DeleteHS;
            this.DelPlanStaffBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.DelPlanStaffBtn.Name = "DelPlanStaffBtn";
            this.DelPlanStaffBtn.Size = new System.Drawing.Size(108, 22);
            this.DelPlanStaffBtn.Text = "Удалить запись";
            this.DelPlanStaffBtn.Click += new System.EventHandler(this.DelPlanStaffBtn_Click);
            // 
            // btnSalaryAdd
            // 
            this.btnSalaryAdd.Image = global::Kadr.Properties.Resources.AddToFavoritesHS;
            this.btnSalaryAdd.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnSalaryAdd.Name = "btnSalaryAdd";
            this.btnSalaryAdd.Size = new System.Drawing.Size(115, 22);
            this.btnSalaryAdd.Text = "Назначить оклад";
            this.btnSalaryAdd.Click += new System.EventHandler(this.btnSalaryAdd_Click);
            // 
            // btnEditSalary
            // 
            this.btnEditSalary.Image = global::Kadr.Properties.Resources.EditInformationHS;
            this.btnEditSalary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnEditSalary.Name = "btnEditSalary";
            this.btnEditSalary.Size = new System.Drawing.Size(109, 22);
            this.btnEditSalary.Text = "Изменить оклад";
            this.btnEditSalary.Click += new System.EventHandler(this.btnEditSalary_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.Controls.Add(this.dgvFactStaff, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(821, 244);
            this.tableLayoutPanel2.TabIndex = 2;
            // 
            // dgvFactStaff
            // 
            this.dgvFactStaff.AllowUserToAddRows = false;
            this.dgvFactStaff.AllowUserToDeleteRows = false;
            this.dgvFactStaff.AutoGenerateColumns = false;
            this.dgvFactStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFactStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.employeeDataGridViewTextBoxColumn,
            this.staffCountDataGridViewTextBoxColumn1,
            this.workTypeDataGridViewTextBoxColumn,
            this.dateBeginDataGridViewTextBoxColumn,
            this.prikazDataGridViewTextBoxColumn1,
            this.dateEndDataGridViewTextBoxColumn,
            this.prikaz1DataGridViewTextBoxColumn1});
            this.dgvFactStaff.DataSource = this.factStaffBindingSource;
            this.dgvFactStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvFactStaff.Location = new System.Drawing.Point(3, 29);
            this.dgvFactStaff.Name = "dgvFactStaff";
            this.dgvFactStaff.ReadOnly = true;
            this.dgvFactStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvFactStaff.Size = new System.Drawing.Size(815, 405);
            this.dgvFactStaff.TabIndex = 6;
            this.dgvFactStaff.DoubleClick += new System.EventHandler(this.dgvFactStaff_DoubleClick);
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.employeeDataGridViewTextBoxColumn.MinimumWidth = 300;
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // staffCountDataGridViewTextBoxColumn1
            // 
            this.staffCountDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.staffCountDataGridViewTextBoxColumn1.DataPropertyName = "StaffCount";
            this.staffCountDataGridViewTextBoxColumn1.HeaderText = "Кол-во ставок";
            this.staffCountDataGridViewTextBoxColumn1.Name = "staffCountDataGridViewTextBoxColumn1";
            this.staffCountDataGridViewTextBoxColumn1.ReadOnly = true;
            this.staffCountDataGridViewTextBoxColumn1.Width = 96;
            // 
            // workTypeDataGridViewTextBoxColumn
            // 
            this.workTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.workTypeDataGridViewTextBoxColumn.DataPropertyName = "WorkType";
            this.workTypeDataGridViewTextBoxColumn.HeaderText = "Вид работы";
            this.workTypeDataGridViewTextBoxColumn.Name = "workTypeDataGridViewTextBoxColumn";
            this.workTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.workTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.workTypeDataGridViewTextBoxColumn.Width = 84;
            // 
            // dateBeginDataGridViewTextBoxColumn
            // 
            this.dateBeginDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dateBeginDataGridViewTextBoxColumn.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.HeaderText = "Дата назначения";
            this.dateBeginDataGridViewTextBoxColumn.Name = "dateBeginDataGridViewTextBoxColumn";
            this.dateBeginDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateBeginDataGridViewTextBoxColumn.Width = 110;
            // 
            // prikazDataGridViewTextBoxColumn1
            // 
            this.prikazDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.prikazDataGridViewTextBoxColumn1.DataPropertyName = "Prikaz";
            this.prikazDataGridViewTextBoxColumn1.HeaderText = "Приказ назначения";
            this.prikazDataGridViewTextBoxColumn1.Name = "prikazDataGridViewTextBoxColumn1";
            this.prikazDataGridViewTextBoxColumn1.ReadOnly = true;
            this.prikazDataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.prikazDataGridViewTextBoxColumn1.Width = 121;
            // 
            // dateEndDataGridViewTextBoxColumn
            // 
            this.dateEndDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dateEndDataGridViewTextBoxColumn.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn.HeaderText = "Дата увольнения";
            this.dateEndDataGridViewTextBoxColumn.Name = "dateEndDataGridViewTextBoxColumn";
            this.dateEndDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateEndDataGridViewTextBoxColumn.Width = 110;
            // 
            // prikaz1DataGridViewTextBoxColumn1
            // 
            this.prikaz1DataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.prikaz1DataGridViewTextBoxColumn1.DataPropertyName = "Prikaz1";
            this.prikaz1DataGridViewTextBoxColumn1.HeaderText = "Приказ увольнения";
            this.prikaz1DataGridViewTextBoxColumn1.Name = "prikaz1DataGridViewTextBoxColumn1";
            this.prikaz1DataGridViewTextBoxColumn1.ReadOnly = true;
            this.prikaz1DataGridViewTextBoxColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.prikaz1DataGridViewTextBoxColumn1.Width = 121;
            // 
            // factStaffBindingSource
            // 
            this.factStaffBindingSource.DataSource = typeof(Kadr.Data.FactStaff);
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddFactStaffBtn,
            this.EditFactStaffBtn,
            this.DelFactStaffBtn,
            this.TransferFactStaffBtn});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(821, 25);
            this.toolStrip2.TabIndex = 7;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // AddFactStaffBtn
            // 
            this.AddFactStaffBtn.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.AddFactStaffBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddFactStaffBtn.Name = "AddFactStaffBtn";
            this.AddFactStaffBtn.Size = new System.Drawing.Size(140, 22);
            this.AddFactStaffBtn.Text = "Добавить сотрудника";
            this.AddFactStaffBtn.Click += new System.EventHandler(this.AddFactStaffBtn_Click);
            // 
            // EditFactStaffBtn
            // 
            this.EditFactStaffBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditFactStaffBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditFactStaffBtn.Name = "EditFactStaffBtn";
            this.EditFactStaffBtn.Size = new System.Drawing.Size(106, 22);
            this.EditFactStaffBtn.Text = "Редактировать";
            this.EditFactStaffBtn.Click += new System.EventHandler(this.EditFactStaffBtn_Click);
            // 
            // DelFactStaffBtn
            // 
            this.DelFactStaffBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DelFactStaffBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelFactStaffBtn.Name = "DelFactStaffBtn";
            this.DelFactStaffBtn.Size = new System.Drawing.Size(71, 22);
            this.DelFactStaffBtn.Text = "Удалить";
            this.DelFactStaffBtn.Click += new System.EventHandler(this.DelFactStaffBtn_Click);
            // 
            // TransferFactStaffBtn
            // 
            this.TransferFactStaffBtn.Image = global::Kadr.Properties.Resources.NextPageHS;
            this.TransferFactStaffBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.TransferFactStaffBtn.Name = "TransferFactStaffBtn";
            this.TransferFactStaffBtn.Size = new System.Drawing.Size(81, 22);
            this.TransferFactStaffBtn.Text = "Перевести";
            this.TransferFactStaffBtn.Click += new System.EventHandler(this.TransferFactStaffBtn_Click);
            // 
            // ptDepartments
            // 
            this.ptDepartments.Controls.Add(this.dgvDepartments);
            this.ptDepartments.Location = new System.Drawing.Point(4, 22);
            this.ptDepartments.Name = "ptDepartments";
            this.ptDepartments.Padding = new System.Windows.Forms.Padding(3);
            this.ptDepartments.Size = new System.Drawing.Size(827, 479);
            this.ptDepartments.TabIndex = 0;
            this.ptDepartments.Text = "Отделы";
            this.ptDepartments.UseVisualStyleBackColor = true;
            // 
            // dgvDepartments
            // 
            this.dgvDepartments.AutoGenerateColumns = false;
            this.dgvDepartments.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepartments.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.departmentNameDataGridViewTextBoxColumn});
            this.dgvDepartments.DataSource = this.departmentBindingSource;
            this.dgvDepartments.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepartments.Location = new System.Drawing.Point(3, 3);
            this.dgvDepartments.Name = "dgvDepartments";
            this.dgvDepartments.ReadOnly = true;
            this.dgvDepartments.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepartments.Size = new System.Drawing.Size(821, 473);
            this.dgvDepartments.TabIndex = 0;
            // 
            // departmentNameDataGridViewTextBoxColumn
            // 
            this.departmentNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.departmentNameDataGridViewTextBoxColumn.DataPropertyName = "DepartmentName";
            this.departmentNameDataGridViewTextBoxColumn.HeaderText = "Название отдела";
            this.departmentNameDataGridViewTextBoxColumn.Name = "departmentNameDataGridViewTextBoxColumn";
            this.departmentNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(Kadr.Data.DepartmentDecorator);
            // 
            // tcDepartment
            // 
            this.tcDepartment.Controls.Add(this.ptDepartments);
            this.tcDepartment.Controls.Add(this.tpStaff);
            this.tcDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDepartment.Location = new System.Drawing.Point(3, 16);
            this.tcDepartment.Name = "tcDepartment";
            this.tcDepartment.SelectedIndex = 0;
            this.tcDepartment.Size = new System.Drawing.Size(835, 505);
            this.tcDepartment.TabIndex = 2;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.дабавитьЗаписьToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(173, 26);
            // 
            // дабавитьЗаписьToolStripMenuItem
            // 
            this.дабавитьЗаписьToolStripMenuItem.Name = "дабавитьЗаписьToolStripMenuItem";
            this.дабавитьЗаписьToolStripMenuItem.Size = new System.Drawing.Size(172, 22);
            this.дабавитьЗаписьToolStripMenuItem.Text = "Добавить запись";
            // 
            // categoryDataGridViewTextBoxColumn
            // 
            this.categoryDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.categoryDataGridViewTextBoxColumn.DataPropertyName = "Category";
            this.categoryDataGridViewTextBoxColumn.HeaderText = "Категория";
            this.categoryDataGridViewTextBoxColumn.Name = "categoryDataGridViewTextBoxColumn";
            this.categoryDataGridViewTextBoxColumn.ReadOnly = true;
            this.categoryDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.categoryDataGridViewTextBoxColumn.Width = 85;
            // 
            // FinancingSource
            // 
            this.FinancingSource.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.FinancingSource.DataPropertyName = "FinancingSource";
            this.FinancingSource.HeaderText = "Источник финан.";
            this.FinancingSource.Name = "FinancingSource";
            this.FinancingSource.ReadOnly = true;
            this.FinancingSource.Width = 108;
            // 
            // postDataGridViewTextBoxColumn
            // 
            this.postDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.postDataGridViewTextBoxColumn.DataPropertyName = "Post";
            this.postDataGridViewTextBoxColumn.HeaderText = "Должность";
            this.postDataGridViewTextBoxColumn.MinimumWidth = 300;
            this.postDataGridViewTextBoxColumn.Name = "postDataGridViewTextBoxColumn";
            this.postDataGridViewTextBoxColumn.ReadOnly = true;
            this.postDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // staffCountDataGridViewTextBoxColumn
            // 
            this.staffCountDataGridViewTextBoxColumn.DataPropertyName = "StaffCount";
            this.staffCountDataGridViewTextBoxColumn.HeaderText = "Кол-во ставок";
            this.staffCountDataGridViewTextBoxColumn.Name = "staffCountDataGridViewTextBoxColumn";
            this.staffCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.staffCountDataGridViewTextBoxColumn.Width = 80;
            // 
            // prikazDataGridViewTextBoxColumn
            // 
            this.prikazDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.prikazDataGridViewTextBoxColumn.DataPropertyName = "Prikaz";
            this.prikazDataGridViewTextBoxColumn.HeaderText = "Приказ утверждения";
            this.prikazDataGridViewTextBoxColumn.Name = "prikazDataGridViewTextBoxColumn";
            this.prikazDataGridViewTextBoxColumn.ReadOnly = true;
            this.prikazDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.prikazDataGridViewTextBoxColumn.Width = 127;
            // 
            // prikaz1DataGridViewTextBoxColumn
            // 
            this.prikaz1DataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.DisplayedCells;
            this.prikaz1DataGridViewTextBoxColumn.DataPropertyName = "Prikaz1";
            this.prikaz1DataGridViewTextBoxColumn.HeaderText = "Приказ отмены";
            this.prikaz1DataGridViewTextBoxColumn.Name = "prikaz1DataGridViewTextBoxColumn";
            this.prikaz1DataGridViewTextBoxColumn.ReadOnly = true;
            this.prikaz1DataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.prikaz1DataGridViewTextBoxColumn.Width = 103;
            // 
            // SalarySize
            // 
            this.SalarySize.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SalarySize.DataPropertyName = "SalarySize";
            this.SalarySize.HeaderText = "Размер оклада";
            this.SalarySize.Name = "SalarySize";
            this.SalarySize.ReadOnly = true;
            this.SalarySize.Width = 101;
            // 
            // HaveIndivSal
            // 
            this.HaveIndivSal.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.HaveIndivSal.DataPropertyName = "HaveIndivSal";
            this.HaveIndivSal.HeaderText = "Индивид оклад";
            this.HaveIndivSal.Name = "HaveIndivSal";
            this.HaveIndivSal.ReadOnly = true;
            this.HaveIndivSal.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.HaveIndivSal.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // KadrRootFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.FrameName = "Отдел";
            this.Name = "KadrRootFrame";
            this.Size = new System.Drawing.Size(841, 524);
            this.Controls.SetChildIndex(this.groupBox1, 0);
            this.groupBox1.ResumeLayout(false);
            this.tpStaff.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planStaffBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFactStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffBindingSource)).EndInit();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.ptDepartments.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepartments)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.tcDepartment.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource departmentBindingSource;
        private System.Windows.Forms.BindingSource planStaffBindingSource;
        private System.Windows.Forms.BindingSource factStaffBindingSource;
        private System.Windows.Forms.TabControl tcDepartment;
        private System.Windows.Forms.TabPage ptDepartments;
        private System.Windows.Forms.DataGridView dgvDepartments;
        private System.Windows.Forms.TabPage tpStaff;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvPlanStaff;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvFactStaff;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddPlanStaffBtn;
        private System.Windows.Forms.ToolStripButton EditPlanStaffBtn;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton AddFactStaffBtn;
        private System.Windows.Forms.ToolStripButton EditFactStaffBtn;
        private System.Windows.Forms.ToolStripButton DelFactStaffBtn;
        private System.Windows.Forms.ToolStripButton DelPlanStaffBtn;
        private System.Windows.Forms.ToolStripButton TransferFactStaffBtn;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem дабавитьЗаписьToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnSalaryAdd;
        private System.Windows.Forms.ToolStripButton btnEditSalary;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffCountDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn workTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikazDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikaz1DataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FinancingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn postDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn staffCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikazDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikaz1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn SalarySize;
        private System.Windows.Forms.DataGridViewCheckBoxColumn HaveIndivSal;
    }
}
