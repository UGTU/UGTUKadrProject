namespace Kadr.UI.Forms
{
    partial class PlanStaffHistoryForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPlanStaffHistory = new System.Windows.Forms.DataGridView();
            this.planStaffHistoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.EditPStChangeBtn = new System.Windows.Forms.ToolStripButton();
            this.DelPStChangeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikazDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.financingSourceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanStaffHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.planStaffHistoryBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPlanStaffHistory
            // 
            this.dgvPlanStaffHistory.AllowUserToAddRows = false;
            this.dgvPlanStaffHistory.AllowUserToDeleteRows = false;
            this.dgvPlanStaffHistory.AutoGenerateColumns = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanStaffHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvPlanStaffHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanStaffHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DateBegin,
            this.prikazDataGridViewTextBoxColumn,
            this.StaffCount,
            this.financingSourceDataGridViewTextBoxColumn});
            this.dgvPlanStaffHistory.DataSource = this.planStaffHistoryBindingSource;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlanStaffHistory.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvPlanStaffHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanStaffHistory.Location = new System.Drawing.Point(0, 25);
            this.dgvPlanStaffHistory.Name = "dgvPlanStaffHistory";
            this.dgvPlanStaffHistory.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanStaffHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgvPlanStaffHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanStaffHistory.Size = new System.Drawing.Size(632, 257);
            this.dgvPlanStaffHistory.TabIndex = 3;
            this.dgvPlanStaffHistory.DoubleClick += new System.EventHandler(this.EditPStChangeBtn_Click);
            // 
            // planStaffHistoryBindingSource
            // 
            this.planStaffHistoryBindingSource.DataSource = typeof(Kadr.Data.PlanStaffHistory);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Kadr.Properties.Resources.DeleteFolderHS;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 22);
            this.btnClose.Text = "Выход";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditPStChangeBtn,
            this.DelPStChangeBtn,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(632, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // EditPStChangeBtn
            // 
            this.EditPStChangeBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditPStChangeBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditPStChangeBtn.Name = "EditPStChangeBtn";
            this.EditPStChangeBtn.Size = new System.Drawing.Size(107, 22);
            this.EditPStChangeBtn.Text = "Редактировать";
            this.EditPStChangeBtn.ToolTipText = "Редактировать изменение";
            this.EditPStChangeBtn.Click += new System.EventHandler(this.EditPStChangeBtn_Click);
            // 
            // DelPStChangeBtn
            // 
            this.DelPStChangeBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DelPStChangeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelPStChangeBtn.Name = "DelPStChangeBtn";
            this.DelPStChangeBtn.Size = new System.Drawing.Size(134, 22);
            this.DelPStChangeBtn.Text = "Удалить изменение";
            this.DelPStChangeBtn.Click += new System.EventHandler(this.DelPStChangeBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "MonthName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Месяц";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn2.HeaderText = "Приказ об изменении";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "PrevStaffCount";
            this.dataGridViewTextBoxColumn3.HeaderText = "Пред. кол-во ставок";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 70;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "NewStaffCount";
            this.dataGridViewTextBoxColumn4.HeaderText = "Новое кол-во ставок";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 104;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "FinancingSource";
            this.dataGridViewTextBoxColumn5.HeaderText = "Пред. источник фин.";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "FinancingSource1";
            this.dataGridViewTextBoxColumn6.HeaderText = "Новый источник фин.";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Prikaz1";
            this.dataGridViewTextBoxColumn7.HeaderText = "Пред. приказ";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // DateBegin
            // 
            this.DateBegin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DateBegin.DataPropertyName = "DateBegin";
            this.DateBegin.HeaderText = "Дата изменения";
            this.DateBegin.Name = "DateBegin";
            this.DateBegin.ReadOnly = true;
            this.DateBegin.Width = 107;
            // 
            // prikazDataGridViewTextBoxColumn
            // 
            this.prikazDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prikazDataGridViewTextBoxColumn.DataPropertyName = "Prikaz";
            this.prikazDataGridViewTextBoxColumn.HeaderText = "Приказ об изменении";
            this.prikazDataGridViewTextBoxColumn.Name = "prikazDataGridViewTextBoxColumn";
            this.prikazDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StaffCount
            // 
            this.StaffCount.DataPropertyName = "StaffCount";
            this.StaffCount.HeaderText = "Кол-во ставок";
            this.StaffCount.Name = "StaffCount";
            this.StaffCount.ReadOnly = true;
            this.StaffCount.Width = 60;
            // 
            // financingSourceDataGridViewTextBoxColumn
            // 
            this.financingSourceDataGridViewTextBoxColumn.DataPropertyName = "FinancingSource";
            this.financingSourceDataGridViewTextBoxColumn.HeaderText = "Источник фин.";
            this.financingSourceDataGridViewTextBoxColumn.Name = "financingSourceDataGridViewTextBoxColumn";
            this.financingSourceDataGridViewTextBoxColumn.ReadOnly = true;
            this.financingSourceDataGridViewTextBoxColumn.Width = 70;
            // 
            // PlanStaffHistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(632, 282);
            this.Controls.Add(this.dgvPlanStaffHistory);
            this.Controls.Add(this.toolStrip1);
            this.Name = "PlanStaffHistoryForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "История записи штатов";
            this.Load += new System.EventHandler(this.PlanStaffHistoryForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanStaffHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.planStaffHistoryBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanStaffHistory;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.BindingSource planStaffHistoryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn financingSource1DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prevStaffCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton EditPStChangeBtn;
        private System.Windows.Forms.ToolStripButton DelPStChangeBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateChangeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn newStaffCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikazDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn financingSourceDataGridViewTextBoxColumn;
    }
}