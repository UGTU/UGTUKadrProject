namespace Kadr.UI.Dialogs
{
    partial class BonusProlongFullDialog
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
            this.tableLayoutPanel8 = new System.Windows.Forms.TableLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.chbWithFinSource = new System.Windows.Forms.CheckBox();
            this.cbNewPrikaz = new System.Windows.Forms.ComboBox();
            this.prikazBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dtNewDate = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbFinancingSource = new System.Windows.Forms.ComboBox();
            this.financingSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Post = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Employee = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.WorkType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactStaffFinancingSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonusDateBegin = new Kadr.UI.Common.DataGridViewDateTimeColumn();
            this.BonusCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonusFinancingSourceName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.Prolong = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.getBonusByBonusTypeForProlongResultBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip3 = new System.Windows.Forms.ToolStrip();
            this.cbBonusType = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.factStaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbProlongForAll = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel8.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prikazBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financingSourceBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBonusByBonusTypeForProlongResultBindingSource)).BeginInit();
            this.toolStrip3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbProlongForAll);
            this.panel1.Controls.Add(this.tableLayoutPanel8);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(1046, 507);
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 524);
            this.panel2.Size = new System.Drawing.Size(1060, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(968, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(876, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(784, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // tableLayoutPanel8
            // 
            this.tableLayoutPanel8.ColumnCount = 1;
            this.tableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.Controls.Add(this.panel3, 0, 2);
            this.tableLayoutPanel8.Controls.Add(this.dataGridView1, 0, 1);
            this.tableLayoutPanel8.Controls.Add(this.toolStrip3, 0, 0);
            this.tableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel8.Name = "tableLayoutPanel8";
            this.tableLayoutPanel8.RowCount = 3;
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 24F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 52F));
            this.tableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel8.Size = new System.Drawing.Size(1046, 507);
            this.tableLayoutPanel8.TabIndex = 3;
            // 
            // panel3
            // 
            this.panel3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel3.Controls.Add(this.chbWithFinSource);
            this.panel3.Controls.Add(this.cbNewPrikaz);
            this.panel3.Controls.Add(this.dtNewDate);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.cbFinancingSource);
            this.panel3.Location = new System.Drawing.Point(3, 458);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1040, 46);
            this.panel3.TabIndex = 5;
            // 
            // chbWithFinSource
            // 
            this.chbWithFinSource.AutoSize = true;
            this.chbWithFinSource.Location = new System.Drawing.Point(4, 10);
            this.chbWithFinSource.Name = "chbWithFinSource";
            this.chbWithFinSource.Size = new System.Drawing.Size(247, 17);
            this.chbWithFinSource.TabIndex = 16;
            this.chbWithFinSource.Text = "Назначить всем источник финансирования";
            this.chbWithFinSource.UseVisualStyleBackColor = true;
            this.chbWithFinSource.Visible = false;
            this.chbWithFinSource.CheckedChanged += new System.EventHandler(this.chbWithFinSource_CheckedChanged);
            // 
            // cbNewPrikaz
            // 
            this.cbNewPrikaz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNewPrikaz.DataSource = this.prikazBindingSource;
            this.cbNewPrikaz.FormattingEnabled = true;
            this.cbNewPrikaz.Location = new System.Drawing.Point(335, 19);
            this.cbNewPrikaz.Name = "cbNewPrikaz";
            this.cbNewPrikaz.Size = new System.Drawing.Size(698, 21);
            this.cbNewPrikaz.TabIndex = 15;
            // 
            // prikazBindingSource
            // 
            this.prikazBindingSource.DataSource = typeof(Kadr.Data.Prikaz);
            // 
            // dtNewDate
            // 
            this.dtNewDate.Location = new System.Drawing.Point(4, 20);
            this.dtNewDate.Name = "dtNewDate";
            this.dtNewDate.Size = new System.Drawing.Size(314, 20);
            this.dtNewDate.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(2, 4);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 13;
            this.label5.Text = "Дата продления";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(332, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 14;
            this.label4.Text = "Приказ о продлении";
            // 
            // cbFinancingSource
            // 
            this.cbFinancingSource.DataSource = this.financingSourceBindingSource;
            this.cbFinancingSource.FormattingEnabled = true;
            this.cbFinancingSource.Location = new System.Drawing.Point(3, 19);
            this.cbFinancingSource.Name = "cbFinancingSource";
            this.cbFinancingSource.Size = new System.Drawing.Size(540, 21);
            this.cbFinancingSource.TabIndex = 17;
            this.cbFinancingSource.Visible = false;
            // 
            // financingSourceBindingSource
            // 
            this.financingSourceBindingSource.DataSource = typeof(Kadr.Data.FinancingSource);
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
            this.BonusDateBegin,
            this.BonusCount,
            this.BonusFinancingSourceName,
            this.Prolong});
            this.dataGridView1.DataSource = this.getBonusByBonusTypeForProlongResultBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(3, 27);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1040, 425);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            // 
            // Department
            // 
            this.Department.DataPropertyName = "DepartmentName";
            this.Department.HeaderText = "Отдел";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.Width = 120;
            // 
            // Post
            // 
            this.Post.DataPropertyName = "PostName";
            this.Post.HeaderText = "Должность";
            this.Post.Name = "Post";
            this.Post.ReadOnly = true;
            this.Post.Width = 130;
            // 
            // Employee
            // 
            this.Employee.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Employee.DataPropertyName = "EmployeeName";
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
            this.WorkType.DataPropertyName = "TypeWorkName";
            this.WorkType.HeaderText = "Вид работы";
            this.WorkType.Name = "WorkType";
            this.WorkType.ReadOnly = true;
            this.WorkType.Width = 60;
            // 
            // FactStaffFinancingSource
            // 
            this.FactStaffFinancingSource.DataPropertyName = "FinancingSourceName";
            this.FactStaffFinancingSource.HeaderText = "Источник финанс";
            this.FactStaffFinancingSource.Name = "FactStaffFinancingSource";
            this.FactStaffFinancingSource.ReadOnly = true;
            this.FactStaffFinancingSource.Width = 70;
            // 
            // DateBegin
            // 
            this.DateBegin.DataPropertyName = "DateBegin";
            this.DateBegin.HeaderText = "Дата приема";
            this.DateBegin.Name = "DateBegin";
            this.DateBegin.ReadOnly = true;
            this.DateBegin.Visible = false;
            this.DateBegin.Width = 75;
            // 
            // dateEndDataGridViewTextBoxColumn
            // 
            this.dateEndDataGridViewTextBoxColumn.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn.HeaderText = "Дата увольн";
            this.dateEndDataGridViewTextBoxColumn.Name = "dateEndDataGridViewTextBoxColumn";
            this.dateEndDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateEndDataGridViewTextBoxColumn.Visible = false;
            this.dateEndDataGridViewTextBoxColumn.Width = 75;
            // 
            // BonusDateBegin
            // 
            this.BonusDateBegin.DataPropertyName = "DateBegin";
            this.BonusDateBegin.HeaderText = "Дата назн";
            this.BonusDateBegin.Name = "BonusDateBegin";
            this.BonusDateBegin.ReadOnly = true;
            this.BonusDateBegin.Width = 80;
            // 
            // BonusCount
            // 
            this.BonusCount.DataPropertyName = "BonusCount";
            this.BonusCount.HeaderText = "Размер надбавки";
            this.BonusCount.Name = "BonusCount";
            // 
            // BonusFinancingSourceName
            // 
            this.BonusFinancingSourceName.DataPropertyName = "BonusFinancingSourceName";
            this.BonusFinancingSourceName.DataSource = this.financingSourceBindingSource;
            this.BonusFinancingSourceName.DisplayMember = "FinancingSourceName";
            this.BonusFinancingSourceName.HeaderText = "Источник финанс надбавки";
            this.BonusFinancingSourceName.Name = "BonusFinancingSourceName";
            this.BonusFinancingSourceName.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.BonusFinancingSourceName.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.BonusFinancingSourceName.Width = 75;
            // 
            // Prolong
            // 
            this.Prolong.DataPropertyName = "Prolong";
            this.Prolong.HeaderText = "Продлевать";
            this.Prolong.Name = "Prolong";
            this.Prolong.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Prolong.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Prolong.Width = 60;
            // 
            // getBonusByBonusTypeForProlongResultBindingSource
            // 
            this.getBonusByBonusTypeForProlongResultBindingSource.DataSource = typeof(Kadr.Data.GetBonusByBonusTypeForProlongResult);
            // 
            // toolStrip3
            // 
            this.toolStrip3.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbBonusType,
            this.toolStripSeparator5});
            this.toolStrip3.Location = new System.Drawing.Point(0, 0);
            this.toolStrip3.Name = "toolStrip3";
            this.toolStrip3.Size = new System.Drawing.Size(1046, 24);
            this.toolStrip3.TabIndex = 0;
            this.toolStrip3.Text = "toolStrip3";
            // 
            // cbBonusType
            // 
            this.cbBonusType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBonusType.Name = "cbBonusType";
            this.cbBonusType.Size = new System.Drawing.Size(450, 24);
            this.cbBonusType.ToolTipText = "Вид надбавки";
            this.cbBonusType.SelectedIndexChanged += new System.EventHandler(this.cbBonusType_SelectedIndexChanged);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 24);
            // 
            // factStaffBindingSource
            // 
            this.factStaffBindingSource.DataSource = typeof(Kadr.Data.FactStaff);
            // 
            // cbProlongForAll
            // 
            this.cbProlongForAll.AutoSize = true;
            this.cbProlongForAll.BackColor = System.Drawing.SystemColors.Control;
            this.cbProlongForAll.Checked = true;
            this.cbProlongForAll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbProlongForAll.Location = new System.Drawing.Point(470, 2);
            this.cbProlongForAll.Name = "cbProlongForAll";
            this.cbProlongForAll.Size = new System.Drawing.Size(116, 17);
            this.cbProlongForAll.TabIndex = 17;
            this.cbProlongForAll.Text = "Продлевать всем";
            this.cbProlongForAll.UseVisualStyleBackColor = false;
            this.cbProlongForAll.CheckedChanged += new System.EventHandler(this.cbBonRepWithSubDeps_CheckedChanged);
            // 
            // BonusProlongFullDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1060, 554);
            this.Name = "BonusProlongFullDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Продление надбавки (расширенное)";
            this.Load += new System.EventHandler(this.BonusProlongFullDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel8.ResumeLayout(false);
            this.tableLayoutPanel8.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.prikazBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financingSourceBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getBonusByBonusTypeForProlongResultBindingSource)).EndInit();
            this.toolStrip3.ResumeLayout(false);
            this.toolStrip3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel8;
        private System.Windows.Forms.ToolStrip toolStrip3;
        private System.Windows.Forms.ToolStripComboBox cbBonusType;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.BindingSource factStaffBindingSource;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource getBonusByBonusTypeForProlongResultBindingSource;
        private System.Windows.Forms.BindingSource financingSourceBindingSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.CheckBox chbWithFinSource;
        private System.Windows.Forms.ComboBox cbNewPrikaz;
        private System.Windows.Forms.DateTimePicker dtNewDate;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbFinancingSource;
        private System.Windows.Forms.CheckBox cbProlongForAll;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn Post;
        private System.Windows.Forms.DataGridViewTextBoxColumn Employee;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn WorkType;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactStaffFinancingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn;
        private Common.DataGridViewDateTimeColumn BonusDateBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn BonusCount;
        private System.Windows.Forms.DataGridViewComboBoxColumn BonusFinancingSourceName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Prolong;
        private System.Windows.Forms.BindingSource prikazBindingSource;

    }
}