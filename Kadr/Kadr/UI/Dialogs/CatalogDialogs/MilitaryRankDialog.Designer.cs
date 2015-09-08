namespace Kadr.UI.Dialogs
{
    partial class MilitaryRankDialog
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
            this.dgvMilitaryRank = new System.Windows.Forms.DataGridView();
            this.MilitaryRankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.militaryRankNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaryRank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilitaryRankBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvMilitaryRank);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvMilitaryRank, 0);
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
            // dgvMilitaryRank
            // 
            this.dgvMilitaryRank.AutoGenerateColumns = false;
            this.dgvMilitaryRank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMilitaryRank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.militaryRankNameDataGridViewTextBoxColumn});
            this.dgvMilitaryRank.DataSource = this.MilitaryRankBindingSource;
            this.dgvMilitaryRank.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMilitaryRank.Location = new System.Drawing.Point(0, 0);
            this.dgvMilitaryRank.Name = "dgvMilitaryRank";
            this.dgvMilitaryRank.Size = new System.Drawing.Size(550, 185);
            this.dgvMilitaryRank.TabIndex = 8;
            this.dgvMilitaryRank.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMilitaryRank_CellBeginEdit);
            // 
            // MilitaryRankBindingSource
            // 
            this.MilitaryRankBindingSource.DataSource = typeof(Kadr.Data.MilitaryRank);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // militaryRankNameDataGridViewTextBoxColumn
            // 
            this.militaryRankNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.militaryRankNameDataGridViewTextBoxColumn.DataPropertyName = "MilitaryRankName";
            this.militaryRankNameDataGridViewTextBoxColumn.HeaderText = "Наименование звания";
            this.militaryRankNameDataGridViewTextBoxColumn.Name = "militaryRankNameDataGridViewTextBoxColumn";
            // 
            // MilitaryRankDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "MilitaryRankDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Воинское звание";
            this.Load += new System.EventHandler(this.MilitaryRankDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaryRank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilitaryRankBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMilitaryRank;
        private System.Windows.Forms.BindingSource MilitaryRankBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn militaryRankNameDataGridViewTextBoxColumn;
    }
}