namespace Kadr.UI.Dialogs
{
    partial class MilitaryTypeDialog
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
            this.dgvMilitaryType = new System.Windows.Forms.DataGridView();
            this.MilitaryTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.militaryTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaryType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilitaryTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvMilitaryType);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvMilitaryType, 0);
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
            // dgvMilitaryType
            // 
            this.dgvMilitaryType.AutoGenerateColumns = false;
            this.dgvMilitaryType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMilitaryType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.militaryTypeNameDataGridViewTextBoxColumn});
            this.dgvMilitaryType.DataSource = this.MilitaryTypeBindingSource;
            this.dgvMilitaryType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMilitaryType.Location = new System.Drawing.Point(0, 0);
            this.dgvMilitaryType.Name = "dgvMilitaryType";
            this.dgvMilitaryType.Size = new System.Drawing.Size(550, 185);
            this.dgvMilitaryType.TabIndex = 8;
            this.dgvMilitaryType.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMilitaryType_CellBeginEdit);
            // 
            // MilitaryTypeBindingSource
            // 
            this.MilitaryTypeBindingSource.DataSource = typeof(Kadr.Data.MilitaryType);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // militaryTypeNameDataGridViewTextBoxColumn
            // 
            this.militaryTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.militaryTypeNameDataGridViewTextBoxColumn.DataPropertyName = "MilitaryTypeName";
            this.militaryTypeNameDataGridViewTextBoxColumn.HeaderText = "Название типа";
            this.militaryTypeNameDataGridViewTextBoxColumn.Name = "militaryTypeNameDataGridViewTextBoxColumn";
            // 
            // MilitaryTypeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "MilitaryTypeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "MilitaryTypeDialog";
            this.Load += new System.EventHandler(this.MilitaryTypeDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaryType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilitaryTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMilitaryType;
        private System.Windows.Forms.BindingSource MilitaryTypeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn militaryTypeNameDataGridViewTextBoxColumn;
    }
}