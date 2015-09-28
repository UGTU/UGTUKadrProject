namespace Kadr.UI.Dialogs
{
    partial class LeaveReasonDialog
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
            this.dgvLeaveReason = new System.Windows.Forms.DataGridView();
            this.LeaveReasonBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idreasonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.reasonnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isUvolnDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.isoldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveReason)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeaveReasonBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvLeaveReason);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvLeaveReason, 0);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(459, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(367, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dgvLeaveReason
            // 
            this.dgvLeaveReason.AutoGenerateColumns = false;
            this.dgvLeaveReason.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLeaveReason.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idreasonDataGridViewTextBoxColumn,
            this.reasonnameDataGridViewTextBoxColumn,
            this.isUvolnDataGridViewCheckBoxColumn,
            this.isoldDataGridViewTextBoxColumn});
            this.dgvLeaveReason.DataSource = this.LeaveReasonBindingSource;
            this.dgvLeaveReason.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLeaveReason.Location = new System.Drawing.Point(0, 0);
            this.dgvLeaveReason.Name = "dgvLeaveReason";
            this.dgvLeaveReason.Size = new System.Drawing.Size(550, 185);
            this.dgvLeaveReason.TabIndex = 5;
            this.dgvLeaveReason.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLeaveReason_CellBeginEdit);
            // 
            // LeaveReasonBindingSource
            // 
            this.LeaveReasonBindingSource.DataSource = typeof(Kadr.Data.OK_Reason);
            // 
            // idreasonDataGridViewTextBoxColumn
            // 
            this.idreasonDataGridViewTextBoxColumn.DataPropertyName = "idreason";
            this.idreasonDataGridViewTextBoxColumn.HeaderText = "idreason";
            this.idreasonDataGridViewTextBoxColumn.Name = "idreasonDataGridViewTextBoxColumn";
            this.idreasonDataGridViewTextBoxColumn.Visible = false;
            // 
            // reasonnameDataGridViewTextBoxColumn
            // 
            this.reasonnameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.reasonnameDataGridViewTextBoxColumn.DataPropertyName = "reasonname";
            this.reasonnameDataGridViewTextBoxColumn.HeaderText = "Наименование причины";
            this.reasonnameDataGridViewTextBoxColumn.Name = "reasonnameDataGridViewTextBoxColumn";
            // 
            // isUvolnDataGridViewCheckBoxColumn
            // 
            this.isUvolnDataGridViewCheckBoxColumn.DataPropertyName = "isUvoln";
            this.isUvolnDataGridViewCheckBoxColumn.HeaderText = "isUvoln";
            this.isUvolnDataGridViewCheckBoxColumn.Name = "isUvolnDataGridViewCheckBoxColumn";
            this.isUvolnDataGridViewCheckBoxColumn.Visible = false;
            // 
            // isoldDataGridViewTextBoxColumn
            // 
            this.isoldDataGridViewTextBoxColumn.DataPropertyName = "is_old";
            this.isoldDataGridViewTextBoxColumn.HeaderText = "Устаревший";
            this.isoldDataGridViewTextBoxColumn.Name = "isoldDataGridViewTextBoxColumn";
            this.isoldDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isoldDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LeaveReasonDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "LeaveReasonDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Причина увольнения";
            this.Load += new System.EventHandler(this.LeaveReasonDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvLeaveReason)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LeaveReasonBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvLeaveReason;
        private System.Windows.Forms.BindingSource LeaveReasonBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idreasonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn reasonnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isUvolnDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isoldDataGridViewTextBoxColumn;
    }
}