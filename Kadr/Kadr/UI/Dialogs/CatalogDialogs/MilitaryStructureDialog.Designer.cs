namespace Kadr.UI.Dialogs
{
    partial class MilitaryStructureDialog
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
            this.dgvMilitaryStructure = new System.Windows.Forms.DataGridView();
            this.MilitaryStructureBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.militaryStructureNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaryStructure)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilitaryStructureBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvMilitaryStructure);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvMilitaryStructure, 0);
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
            // dgvMilitaryStructure
            // 
            this.dgvMilitaryStructure.AutoGenerateColumns = false;
            this.dgvMilitaryStructure.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMilitaryStructure.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.militaryStructureNameDataGridViewTextBoxColumn});
            this.dgvMilitaryStructure.DataSource = this.MilitaryStructureBindingSource;
            this.dgvMilitaryStructure.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMilitaryStructure.Location = new System.Drawing.Point(0, 0);
            this.dgvMilitaryStructure.Name = "dgvMilitaryStructure";
            this.dgvMilitaryStructure.Size = new System.Drawing.Size(550, 185);
            this.dgvMilitaryStructure.TabIndex = 8;
            this.dgvMilitaryStructure.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMilitaryStructure_CellBeginEdit);
            // 
            // MilitaryStructureBindingSource
            // 
            this.MilitaryStructureBindingSource.DataSource = typeof(Kadr.Data.MilitaryStructure);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // militaryStructureNameDataGridViewTextBoxColumn
            // 
            this.militaryStructureNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.militaryStructureNameDataGridViewTextBoxColumn.DataPropertyName = "MilitaryStructureName";
            this.militaryStructureNameDataGridViewTextBoxColumn.HeaderText = "Название состава";
            this.militaryStructureNameDataGridViewTextBoxColumn.Name = "militaryStructureNameDataGridViewTextBoxColumn";
            // 
            // MilitaryStructureDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "MilitaryStructureDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Воинский состав (профиль)";
            this.Load += new System.EventHandler(this.MilitaryStructureDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaryStructure)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilitaryStructureBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMilitaryStructure;
        private System.Windows.Forms.BindingSource MilitaryStructureBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn militaryStructureNameDataGridViewTextBoxColumn;
    }
}