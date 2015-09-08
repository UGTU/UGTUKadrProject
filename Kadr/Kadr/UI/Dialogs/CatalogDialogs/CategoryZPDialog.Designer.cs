namespace Kadr.UI.Dialogs
{
    partial class CategoryZPDialog
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
            this.categoryZPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.categoryZPNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.categoryZPSmallNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.orderByDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryZPBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dataGridView1, 0);
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
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.categoryZPNameDataGridViewTextBoxColumn,
            this.categoryZPSmallNameDataGridViewTextBoxColumn,
            this.orderByDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.categoryZPBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(550, 185);
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            // 
            // categoryZPBindingSource
            // 
            this.categoryZPBindingSource.DataSource = typeof(Kadr.Data.CategoryZP);
            // 
            // categoryZPNameDataGridViewTextBoxColumn
            // 
            this.categoryZPNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.categoryZPNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryZPName";
            this.categoryZPNameDataGridViewTextBoxColumn.HeaderText = "Название категории";
            this.categoryZPNameDataGridViewTextBoxColumn.Name = "categoryZPNameDataGridViewTextBoxColumn";
            // 
            // categoryZPSmallNameDataGridViewTextBoxColumn
            // 
            this.categoryZPSmallNameDataGridViewTextBoxColumn.DataPropertyName = "CategoryZPSmallName";
            this.categoryZPSmallNameDataGridViewTextBoxColumn.HeaderText = "Краткое название";
            this.categoryZPSmallNameDataGridViewTextBoxColumn.Name = "categoryZPSmallNameDataGridViewTextBoxColumn";
            this.categoryZPSmallNameDataGridViewTextBoxColumn.Width = 150;
            // 
            // orderByDataGridViewTextBoxColumn
            // 
            this.orderByDataGridViewTextBoxColumn.DataPropertyName = "OrderBy";
            this.orderByDataGridViewTextBoxColumn.HeaderText = "Порядок сортировки";
            this.orderByDataGridViewTextBoxColumn.Name = "orderByDataGridViewTextBoxColumn";
            // 
            // CategoryZPDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "CategoryZPDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Категории для зп-образования";
            this.Load += new System.EventHandler(this.CategoryZPDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.categoryZPBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryZPNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn categoryZPSmallNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn orderByDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource categoryZPBindingSource;
    }
}