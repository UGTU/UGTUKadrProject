namespace Kadr.UI.Dialogs
{
    partial class SalaryKoeffDialog
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.salaryKoeffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pKSubSubCategoryNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.salaryKoeffcDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryKoeffBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(491, 208);
            this.panel1.Controls.SetChildIndex(this.dataGridView1, 0);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(491, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(388, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Size = new System.Drawing.Size(100, 26);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(296, 3);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(204, 3);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pKSubSubCategoryNumberDataGridViewTextBoxColumn,
            this.salaryKoeffcDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.salaryKoeffBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(491, 183);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            // 
            // salaryKoeffBindingSource
            // 
            this.salaryKoeffBindingSource.DataSource = typeof(Kadr.Data.SalaryKoeff);
            // 
            // pKSubSubCategoryNumberDataGridViewTextBoxColumn
            // 
            this.pKSubSubCategoryNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.pKSubSubCategoryNumberDataGridViewTextBoxColumn.DataPropertyName = "PKSubSubCategoryNumber";
            this.pKSubSubCategoryNumberDataGridViewTextBoxColumn.HeaderText = "Номер подподкатегории";
            this.pKSubSubCategoryNumberDataGridViewTextBoxColumn.Name = "pKSubSubCategoryNumberDataGridViewTextBoxColumn";
            this.pKSubSubCategoryNumberDataGridViewTextBoxColumn.Width = 143;
            // 
            // salaryKoeffcDataGridViewTextBoxColumn
            // 
            this.salaryKoeffcDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.salaryKoeffcDataGridViewTextBoxColumn.DataPropertyName = "SalaryKoeffc";
            this.salaryKoeffcDataGridViewTextBoxColumn.HeaderText = "Коэффициент к окладу";
            this.salaryKoeffcDataGridViewTextBoxColumn.Name = "salaryKoeffcDataGridViewTextBoxColumn";
            // 
            // SalaryKoeffDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 267);
            this.Name = "SalaryKoeffDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Коэффициенты к окладу";
            this.Load += new System.EventHandler(this.SalaryKoeffDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.salaryKoeffBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn pKSubSubCategoryNuvberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryKoeff1DataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource salaryKoeffBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pKSubSubCategoryNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn salaryKoeffcDataGridViewTextBoxColumn;
    }
}