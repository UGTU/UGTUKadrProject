namespace Kadr.UI.Dialogs
{
    partial class MilitaryCategoryDialog
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
            this.dgvMilitaryCategory = new System.Windows.Forms.DataGridView();
            this.MilitaryCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.militaryCategoryNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaryCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilitaryCategoryBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvMilitaryCategory);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvMilitaryCategory, 0);
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
            // dgvMilitaryCategory
            // 
            this.dgvMilitaryCategory.AutoGenerateColumns = false;
            this.dgvMilitaryCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMilitaryCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.militaryCategoryNameDataGridViewTextBoxColumn});
            this.dgvMilitaryCategory.DataSource = this.MilitaryCategoryBindingSource;
            this.dgvMilitaryCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvMilitaryCategory.Location = new System.Drawing.Point(0, 0);
            this.dgvMilitaryCategory.Name = "dgvMilitaryCategory";
            this.dgvMilitaryCategory.Size = new System.Drawing.Size(550, 185);
            this.dgvMilitaryCategory.TabIndex = 7;
            this.dgvMilitaryCategory.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvMilitaryCategory_CellBeginEdit);
            // 
            // MilitaryCategoryBindingSource
            // 
            this.MilitaryCategoryBindingSource.DataSource = typeof(Kadr.Data.MilitaryCategory);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // militaryCategoryNameDataGridViewTextBoxColumn
            // 
            this.militaryCategoryNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.militaryCategoryNameDataGridViewTextBoxColumn.DataPropertyName = "MilitaryCategoryName";
            this.militaryCategoryNameDataGridViewTextBoxColumn.HeaderText = "Название категории";
            this.militaryCategoryNameDataGridViewTextBoxColumn.Name = "militaryCategoryNameDataGridViewTextBoxColumn";
            // 
            // MilitaryCategoryDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "MilitaryCategoryDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Категории запаса";
            this.Load += new System.EventHandler(this.MilitaryCategoryDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMilitaryCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MilitaryCategoryBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMilitaryCategory;
        private System.Windows.Forms.BindingSource MilitaryCategoryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn militaryCategoryNameDataGridViewTextBoxColumn;
    }
}