namespace Kadr.UI.Dialogs
{
    partial class LanguageLevelDialog
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
            this.LanguageLevelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvLanguageLevel = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.levelNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GoodBit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LanguageLevelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguageLevel)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvLanguageLevel);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvLanguageLevel, 0);
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
            // LanguageLevelBindingSource
            // 
            this.LanguageLevelBindingSource.DataSource = typeof(Kadr.Data.LanguageLevel);
            // 
            // dgvLanguageLevel
            // 
            this.dgvLanguageLevel.AutoGenerateColumns = false;
            this.dgvLanguageLevel.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvLanguageLevel.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.levelNameDataGridViewTextBoxColumn,
            this.GoodBit});
            this.dgvLanguageLevel.DataSource = this.LanguageLevelBindingSource;
            this.dgvLanguageLevel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLanguageLevel.Location = new System.Drawing.Point(0, 0);
            this.dgvLanguageLevel.Name = "dgvLanguageLevel";
            this.dgvLanguageLevel.Size = new System.Drawing.Size(550, 185);
            this.dgvLanguageLevel.TabIndex = 7;
            this.dgvLanguageLevel.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvLanguageLevel_CellBeginEdit);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // levelNameDataGridViewTextBoxColumn
            // 
            this.levelNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.levelNameDataGridViewTextBoxColumn.DataPropertyName = "LevelName";
            this.levelNameDataGridViewTextBoxColumn.HeaderText = "Наименование степени владения";
            this.levelNameDataGridViewTextBoxColumn.Name = "levelNameDataGridViewTextBoxColumn";
            // 
            // GoodBit
            // 
            this.GoodBit.DataPropertyName = "GoodBit";
            this.GoodBit.HeaderText = "Хороший уровень";
            this.GoodBit.Name = "GoodBit";
            this.GoodBit.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.GoodBit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // LanguageLevelDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "LanguageLevelDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Степень владения иностранным языком";
            this.Load += new System.EventHandler(this.LanguageLevelDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.LanguageLevelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvLanguageLevel)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource LanguageLevelBindingSource;
        private System.Windows.Forms.DataGridView dgvLanguageLevel;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn levelNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn GoodBit;
    }
}