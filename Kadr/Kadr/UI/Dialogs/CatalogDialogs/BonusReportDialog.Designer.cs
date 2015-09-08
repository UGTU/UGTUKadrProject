namespace Kadr.UI.Dialogs
{
    partial class BonusReportDialog
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.reporNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DefaultBonusOrder = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.SalaryFirst = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.WithReplacements = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.withManagersDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bonusReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(699, 283);
            this.panel1.Controls.SetChildIndex(this.dataGridView1, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 298);
            this.panel2.Size = new System.Drawing.Size(700, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(608, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(516, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(424, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.reporNameDataGridViewTextBoxColumn,
            this.DefaultBonusOrder,
            this.SalaryFirst,
            this.WithReplacements,
            this.withManagersDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bonusReportBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(699, 258);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            // 
            // reporNameDataGridViewTextBoxColumn
            // 
            this.reporNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reporNameDataGridViewTextBoxColumn.DataPropertyName = "ReporName";
            this.reporNameDataGridViewTextBoxColumn.HeaderText = "Название отчета";
            this.reporNameDataGridViewTextBoxColumn.Name = "reporNameDataGridViewTextBoxColumn";
            this.reporNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // DefaultBonusOrder
            // 
            this.DefaultBonusOrder.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DefaultBonusOrder.DataPropertyName = "DefaultBonusOrder";
            this.DefaultBonusOrder.HeaderText = "Последовательность по умолчанию";
            this.DefaultBonusOrder.Name = "DefaultBonusOrder";
            this.DefaultBonusOrder.ReadOnly = true;
            this.DefaultBonusOrder.Width = 125;
            // 
            // SalaryFirst
            // 
            this.SalaryFirst.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.SalaryFirst.DataPropertyName = "SalaryFirst";
            this.SalaryFirst.HeaderText = "Оклад вначале";
            this.SalaryFirst.Name = "SalaryFirst";
            this.SalaryFirst.ReadOnly = true;
            this.SalaryFirst.Width = 80;
            // 
            // WithReplacements
            // 
            this.WithReplacements.DataPropertyName = "WithReplacements";
            this.WithReplacements.HeaderText = "С совместителями";
            this.WithReplacements.Name = "WithReplacements";
            this.WithReplacements.ReadOnly = true;
            this.WithReplacements.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.WithReplacements.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // withManagersDataGridViewTextBoxColumn
            // 
            this.withManagersDataGridViewTextBoxColumn.DataPropertyName = "WithManagers";
            this.withManagersDataGridViewTextBoxColumn.HeaderText = "С проректорами";
            this.withManagersDataGridViewTextBoxColumn.Name = "withManagersDataGridViewTextBoxColumn";
            this.withManagersDataGridViewTextBoxColumn.ReadOnly = true;
            this.withManagersDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.withManagersDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.withManagersDataGridViewTextBoxColumn.Width = 90;
            // 
            // bonusReportBindingSource
            // 
            this.bonusReportBindingSource.DataSource = typeof(Kadr.Data.BonusReport);
            // 
            // BonusReportDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 336);
            this.Name = "BonusReportDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Отчеты по надбавкам";
            this.Load += new System.EventHandler(this.BonusReportDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bonusReportBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn reporNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn DefaultBonusOrder;
        private System.Windows.Forms.DataGridViewCheckBoxColumn SalaryFirst;
        private System.Windows.Forms.DataGridViewCheckBoxColumn WithReplacements;
        private System.Windows.Forms.DataGridViewCheckBoxColumn withManagersDataGridViewTextBoxColumn;
    }
}