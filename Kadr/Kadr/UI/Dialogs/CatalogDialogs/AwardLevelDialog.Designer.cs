namespace Kadr.UI.Dialogs
{
    partial class AwardLevelDialog
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
            this.AwardLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvAwardLevel = new System.Windows.Forms.DataGridView();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.awardLevel1DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.AwardLevelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAwardLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvAwardLevel);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvAwardLevel, 0);
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
            // AwardLevelBindingSource
            // 
            this.AwardLevelBindingSource.DataSource = typeof(Kadr.Data.AwardLevel);
            // 
            // dgvAwardLevel
            // 
            this.dgvAwardLevel.AutoGenerateColumns = false;
            this.dgvAwardLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvAwardLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.awardLevel1DataGridViewTextBoxColumn});
            this.dgvAwardLevel.DataSource = this.AwardLevelBindingSource;
            this.dgvAwardLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvAwardLevel.Location = new System.Drawing.Point(0, 0);
            this.dgvAwardLevel.Name = "dgvAwardLevel";
            this.dgvAwardLevel.Size = new System.Drawing.Size(550, 185);
            this.dgvAwardLevel.TabIndex = 5;
            this.dgvAwardLevel.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvAwardLevel_CellBeginEdit);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Название уровня";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // awardLevel1DataGridViewTextBoxColumn
            // 
            this.awardLevel1DataGridViewTextBoxColumn.DataPropertyName = "AwardLevel1";
            this.awardLevel1DataGridViewTextBoxColumn.HeaderText = "Предыдущий уровень";
            this.awardLevel1DataGridViewTextBoxColumn.Name = "awardLevel1DataGridViewTextBoxColumn";
            this.awardLevel1DataGridViewTextBoxColumn.Visible = false;
            this.awardLevel1DataGridViewTextBoxColumn.Width = 200;
            // 
            // AwardLevelDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "AwardLevelDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Уровень награды";
            this.Load += new System.EventHandler(this.AwardLevelDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.AwardLevelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvAwardLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource AwardLevelBindingSource;
        private System.Windows.Forms.DataGridView dgvAwardLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn awardLevel1DataGridViewTextBoxColumn;
    }
}