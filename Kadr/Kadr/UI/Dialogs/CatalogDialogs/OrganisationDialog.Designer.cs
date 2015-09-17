namespace Kadr.UI.Dialogs
{
    partial class OrganisationDialog
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
            this.dgvOrganisation = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.OrganisationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganisation)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrganisationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvOrganisation);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(747, 210);
            this.panel1.Controls.SetChildIndex(this.dgvOrganisation, 0);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(748, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(656, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(564, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(472, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dgvOrganisation
            // 
            this.dgvOrganisation.AutoGenerateColumns = false;
            this.dgvOrganisation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvOrganisation.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn});
            this.dgvOrganisation.DataSource = this.OrganisationBindingSource;
            this.dgvOrganisation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvOrganisation.Location = new System.Drawing.Point(0, 0);
            this.dgvOrganisation.Name = "dgvOrganisation";
            this.dgvOrganisation.Size = new System.Drawing.Size(747, 185);
            this.dgvOrganisation.TabIndex = 6;
            this.dgvOrganisation.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvOrganisation_CellBeginEdit);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Название";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // OrganisationBindingSource
            // 
            this.OrganisationBindingSource.DataSource = typeof(Kadr.Data.Organisation);
            // 
            // OrganisationDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(772, 263);
            this.Name = "OrganisationDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Организация";
            this.Load += new System.EventHandler(this.OrganisationDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvOrganisation)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.OrganisationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvOrganisation;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource OrganisationBindingSource;

    }
}