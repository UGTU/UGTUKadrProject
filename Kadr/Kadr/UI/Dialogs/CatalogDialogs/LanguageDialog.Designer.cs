namespace Kadr.UI.Dialogs
{
    partial class LanguageDialog
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
            this.LanguageBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvLanguage = new System.Windows.Forms.DataGridView();
            this.idlanguageDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.languagenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LanguageBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguage)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvLanguage);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvLanguage, 0);
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
            // LanguageBindingSource
            // 
            this.LanguageBindingSource.DataSource = typeof(Kadr.Data.OK_Language);
            // 
            // dgvLanguage
            // 
            this.dgvLanguage.AutoGenerateColumns = false;
            this.dgvLanguage.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLanguage.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idlanguageDataGridViewTextBoxColumn,
            this.languagenameDataGridViewTextBoxColumn});
            this.dgvLanguage.DataSource = this.LanguageBindingSource;
            this.dgvLanguage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLanguage.Location = new System.Drawing.Point(0, 0);
            this.dgvLanguage.Name = "dgvLanguage";
            this.dgvLanguage.Size = new System.Drawing.Size(550, 185);
            this.dgvLanguage.TabIndex = 7;
            this.dgvLanguage.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLanguage_CellBeginEdit);
            // 
            // idlanguageDataGridViewTextBoxColumn
            // 
            this.idlanguageDataGridViewTextBoxColumn.DataPropertyName = "idlanguage";
            this.idlanguageDataGridViewTextBoxColumn.HeaderText = "idlanguage";
            this.idlanguageDataGridViewTextBoxColumn.Name = "idlanguageDataGridViewTextBoxColumn";
            this.idlanguageDataGridViewTextBoxColumn.Visible = false;
            // 
            // languagenameDataGridViewTextBoxColumn
            // 
            this.languagenameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.languagenameDataGridViewTextBoxColumn.DataPropertyName = "languagename";
            this.languagenameDataGridViewTextBoxColumn.HeaderText = "Наименование языка";
            this.languagenameDataGridViewTextBoxColumn.Name = "languagenameDataGridViewTextBoxColumn";
            // 
            // LanguageDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "LanguageDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "LanguageDialog";
            this.Load += new System.EventHandler(this.LanguageDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LanguageBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource LanguageBindingSource;
        private System.Windows.Forms.DataGridView dgvLanguage;
        private System.Windows.Forms.DataGridViewTextBoxColumn idlanguageDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn languagenameDataGridViewTextBoxColumn;
    }
}