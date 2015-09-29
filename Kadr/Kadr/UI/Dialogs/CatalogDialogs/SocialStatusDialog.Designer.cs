namespace Kadr.UI.Dialogs
{
    partial class SocialStatusDialog
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
            this.SocialStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvSocialStatus = new System.Windows.Forms.DataGridView();
            this.idSocialStatusDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.socialStatusNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.is_old = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.SocialStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocialStatus)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvSocialStatus);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvSocialStatus, 0);
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
            // SocialStatusBindingSource
            // 
            this.SocialStatusBindingSource.DataSource = typeof(Kadr.Data.OK_SocialStatus);
            // 
            // dgvSocialStatus
            // 
            this.dgvSocialStatus.AutoGenerateColumns = false;
            this.dgvSocialStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSocialStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idSocialStatusDataGridViewTextBoxColumn,
            this.socialStatusNameDataGridViewTextBoxColumn,
            this.is_old});
            this.dgvSocialStatus.DataSource = this.SocialStatusBindingSource;
            this.dgvSocialStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSocialStatus.Location = new System.Drawing.Point(0, 0);
            this.dgvSocialStatus.Name = "dgvSocialStatus";
            this.dgvSocialStatus.Size = new System.Drawing.Size(550, 185);
            this.dgvSocialStatus.TabIndex = 5;
            this.dgvSocialStatus.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvSocialStatus_CellBeginEdit);
            // 
            // idSocialStatusDataGridViewTextBoxColumn
            // 
            this.idSocialStatusDataGridViewTextBoxColumn.DataPropertyName = "idSocialStatus";
            this.idSocialStatusDataGridViewTextBoxColumn.HeaderText = "idSocialStatus";
            this.idSocialStatusDataGridViewTextBoxColumn.Name = "idSocialStatusDataGridViewTextBoxColumn";
            this.idSocialStatusDataGridViewTextBoxColumn.Visible = false;
            // 
            // socialStatusNameDataGridViewTextBoxColumn
            // 
            this.socialStatusNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.socialStatusNameDataGridViewTextBoxColumn.DataPropertyName = "SocialStatusName";
            this.socialStatusNameDataGridViewTextBoxColumn.HeaderText = "Название социального статуса";
            this.socialStatusNameDataGridViewTextBoxColumn.Name = "socialStatusNameDataGridViewTextBoxColumn";
            // 
            // is_old
            // 
            this.is_old.DataPropertyName = "is_old";
            this.is_old.HeaderText = "Устаревший";
            this.is_old.Name = "is_old";
            this.is_old.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.is_old.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // SocialStatusDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "SocialStatusDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Социальный статус";
            this.Load += new System.EventHandler(this.SocialStatusDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.SocialStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSocialStatus)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource SocialStatusBindingSource;
        private System.Windows.Forms.DataGridView dgvSocialStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn idSocialStatusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn socialStatusNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn is_old;
    }
}