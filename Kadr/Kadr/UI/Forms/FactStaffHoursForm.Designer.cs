namespace Kadr.UI.Forms
{
    partial class FactStaffHoursForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle11 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle12 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPlanStaffHistory = new System.Windows.Forms.DataGridView();
            this.factStaffMonthHourBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddSalaryBtn = new System.Windows.Forms.ToolStripButton();
            this.EditPStChangeBtn = new System.Windows.Forms.ToolStripButton();
            this.DelPStChangeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.RestHourStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.YearNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MonthName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.hourCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonusSum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanStaffHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffMonthHourBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPlanStaffHistory
            // 
            this.dgvPlanStaffHistory.AllowUserToAddRows = false;
            this.dgvPlanStaffHistory.AllowUserToDeleteRows = false;
            this.dgvPlanStaffHistory.AutoGenerateColumns = false;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle9.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanStaffHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvPlanStaffHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanStaffHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.YearNumber,
            this.MonthName,
            this.hourCountDataGridViewTextBoxColumn,
            this.BonusSum});
            this.dgvPlanStaffHistory.DataSource = this.factStaffMonthHourBindingSource;
            dataGridViewCellStyle11.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle11.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle11.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle11.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle11.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle11.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlanStaffHistory.DefaultCellStyle = dataGridViewCellStyle11;
            this.dgvPlanStaffHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanStaffHistory.Location = new System.Drawing.Point(0, 25);
            this.dgvPlanStaffHistory.Name = "dgvPlanStaffHistory";
            this.dgvPlanStaffHistory.ReadOnly = true;
            dataGridViewCellStyle12.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle12.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle12.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle12.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle12.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle12.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanStaffHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle12;
            this.dgvPlanStaffHistory.RowHeadersVisible = false;
            this.dgvPlanStaffHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanStaffHistory.Size = new System.Drawing.Size(536, 240);
            this.dgvPlanStaffHistory.TabIndex = 7;
            this.dgvPlanStaffHistory.DoubleClick += new System.EventHandler(this.EditPStChangeBtn_Click);
            // 
            // factStaffMonthHourBindingSource
            // 
            this.factStaffMonthHourBindingSource.DataSource = typeof(Kadr.Data.FactStaffMonthHour);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddSalaryBtn,
            this.EditPStChangeBtn,
            this.DelPStChangeBtn,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(536, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddSalaryBtn
            // 
            this.AddSalaryBtn.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.AddSalaryBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddSalaryBtn.Name = "AddSalaryBtn";
            this.AddSalaryBtn.Size = new System.Drawing.Size(110, 22);
            this.AddSalaryBtn.Text = "Добавить часы";
            this.AddSalaryBtn.Click += new System.EventHandler(this.AddSalaryBtn_Click);
            // 
            // EditPStChangeBtn
            // 
            this.EditPStChangeBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditPStChangeBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditPStChangeBtn.Name = "EditPStChangeBtn";
            this.EditPStChangeBtn.Size = new System.Drawing.Size(107, 22);
            this.EditPStChangeBtn.Text = "Редактировать";
            this.EditPStChangeBtn.ToolTipText = "Редактировать часы";
            this.EditPStChangeBtn.Click += new System.EventHandler(this.EditPStChangeBtn_Click);
            // 
            // DelPStChangeBtn
            // 
            this.DelPStChangeBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DelPStChangeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelPStChangeBtn.Name = "DelPStChangeBtn";
            this.DelPStChangeBtn.Size = new System.Drawing.Size(71, 22);
            this.DelPStChangeBtn.Text = "Удалить";
            this.DelPStChangeBtn.ToolTipText = "Удалить часы";
            this.DelPStChangeBtn.Click += new System.EventHandler(this.DelPStChangeBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Kadr.Properties.Resources.DeleteFolderHS;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 22);
            this.btnClose.Text = "Выход";
            this.btnClose.ToolTipText = "Закрыть окно";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RestHourStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 243);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(536, 22);
            this.statusStrip1.TabIndex = 8;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // RestHourStatus
            // 
            this.RestHourStatus.Name = "RestHourStatus";
            this.RestHourStatus.Size = new System.Drawing.Size(118, 17);
            this.RestHourStatus.Text = "toolStripStatusLabel1";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BonusCount";
            this.dataGridViewTextBoxColumn1.HeaderText = "Новый размер надбавки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn2.HeaderText = "Дата назначения";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 130;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn3.HeaderText = "Приказ назначения";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 152;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FinancingSource";
            this.dataGridViewTextBoxColumn4.HeaderText = "Источник финанс.";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // YearNumber
            // 
            this.YearNumber.DataPropertyName = "YearNumber";
            this.YearNumber.HeaderText = "Год";
            this.YearNumber.Name = "YearNumber";
            this.YearNumber.ReadOnly = true;
            // 
            // MonthName
            // 
            this.MonthName.DataPropertyName = "MonthName";
            this.MonthName.HeaderText = "Месяц";
            this.MonthName.Name = "MonthName";
            this.MonthName.ReadOnly = true;
            this.MonthName.Width = 130;
            // 
            // hourCountDataGridViewTextBoxColumn
            // 
            this.hourCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.hourCountDataGridViewTextBoxColumn.DataPropertyName = "HourCount";
            this.hourCountDataGridViewTextBoxColumn.HeaderText = "Количество часов";
            this.hourCountDataGridViewTextBoxColumn.Name = "hourCountDataGridViewTextBoxColumn";
            this.hourCountDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // BonusSum
            // 
            this.BonusSum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BonusSum.DataPropertyName = "BonusSum";
            dataGridViewCellStyle10.Format = "N2";
            dataGridViewCellStyle10.NullValue = null;
            this.BonusSum.DefaultCellStyle = dataGridViewCellStyle10;
            this.BonusSum.HeaderText = "Размер премии";
            this.BonusSum.Name = "BonusSum";
            this.BonusSum.ReadOnly = true;
            // 
            // FactStaffHoursForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(536, 265);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.dgvPlanStaffHistory);
            this.Controls.Add(this.toolStrip1);
            this.Name = "FactStaffHoursForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FactStaffHoursForm";
            this.Load += new System.EventHandler(this.FactStaffHoursForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanStaffHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.factStaffMonthHourBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanStaffHistory;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton EditPStChangeBtn;
        private System.Windows.Forms.ToolStripButton DelPStChangeBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.BindingSource factStaffMonthHourBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn ьonthNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton AddSalaryBtn;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel RestHourStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn YearNumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthName;
        private System.Windows.Forms.DataGridViewTextBoxColumn hourCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BonusSum;
    }
}