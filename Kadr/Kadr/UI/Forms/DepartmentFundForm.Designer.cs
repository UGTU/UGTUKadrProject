namespace Kadr.UI.Forms
{
    partial class DepartmentFundForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsbAddDepFund = new System.Windows.Forms.ToolStripButton();
            this.tsbEditDepFund = new System.Windows.Forms.ToolStripButton();
            this.tsbDelDepFund = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbClose = new System.Windows.Forms.ToolStripButton();
            this.dgvDepurtmentFund = new System.Windows.Forms.DataGridView();
            this.dateBeginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.planFundSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factFundSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.extraordSumDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentFundBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepurtmentFund)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentFundBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.toolStrip2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.dgvDepurtmentFund, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 22F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(531, 363);
            this.tableLayoutPanel1.TabIndex = 7;
            // 
            // toolStrip2
            // 
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbAddDepFund,
            this.tsbEditDepFund,
            this.tsbDelDepFund,
            this.toolStripSeparator2,
            this.tsbClose});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(531, 22);
            this.toolStrip2.TabIndex = 5;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsbAddDepFund
            // 
            this.tsbAddDepFund.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.tsbAddDepFund.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbAddDepFund.Name = "tsbAddDepFund";
            this.tsbAddDepFund.Size = new System.Drawing.Size(119, 19);
            this.tsbAddDepFund.Text = "Добавить запись";
            this.tsbAddDepFund.ToolTipText = "Добавить запись бюджета";
            this.tsbAddDepFund.Click += new System.EventHandler(this.tsbAddDepFund_Click);
            // 
            // tsbEditDepFund
            // 
            this.tsbEditDepFund.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.tsbEditDepFund.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEditDepFund.Name = "tsbEditDepFund";
            this.tsbEditDepFund.Size = new System.Drawing.Size(107, 19);
            this.tsbEditDepFund.Text = "Редактировать";
            this.tsbEditDepFund.ToolTipText = "Редактировать запись бюджета";
            this.tsbEditDepFund.Click += new System.EventHandler(this.tsbEditDepFund_Click);
            // 
            // tsbDelDepFund
            // 
            this.tsbDelDepFund.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.tsbDelDepFund.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbDelDepFund.Name = "tsbDelDepFund";
            this.tsbDelDepFund.Size = new System.Drawing.Size(71, 19);
            this.tsbDelDepFund.Text = "Удалить";
            this.tsbDelDepFund.ToolTipText = "Удалить запись бюджета";
            this.tsbDelDepFund.Click += new System.EventHandler(this.tsbDelDepFund_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 22);
            // 
            // tsbClose
            // 
            this.tsbClose.Image = global::Kadr.Properties.Resources.DeleteFolderHS;
            this.tsbClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbClose.Name = "tsbClose";
            this.tsbClose.Size = new System.Drawing.Size(61, 19);
            this.tsbClose.Text = "Выход";
            this.tsbClose.ToolTipText = "Закрыть окно";
            this.tsbClose.Click += new System.EventHandler(this.tsbClose_Click);
            // 
            // dgvDepurtmentFund
            // 
            this.dgvDepurtmentFund.AllowUserToAddRows = false;
            this.dgvDepurtmentFund.AllowUserToDeleteRows = false;
            this.dgvDepurtmentFund.AutoGenerateColumns = false;
            this.dgvDepurtmentFund.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDepurtmentFund.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dateBeginDataGridViewTextBoxColumn,
            this.planFundSumDataGridViewTextBoxColumn,
            this.factFundSumDataGridViewTextBoxColumn,
            this.extraordSumDataGridViewTextBoxColumn});
            this.dgvDepurtmentFund.DataSource = this.departmentFundBindingSource;
            this.dgvDepurtmentFund.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDepurtmentFund.Location = new System.Drawing.Point(3, 25);
            this.dgvDepurtmentFund.Name = "dgvDepurtmentFund";
            this.dgvDepurtmentFund.ReadOnly = true;
            this.dgvDepurtmentFund.RowHeadersVisible = false;
            this.dgvDepurtmentFund.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDepurtmentFund.Size = new System.Drawing.Size(525, 335);
            this.dgvDepurtmentFund.TabIndex = 6;
            this.dgvDepurtmentFund.DoubleClick += new System.EventHandler(this.tsbEditDepFund_Click);
            // 
            // dateBeginDataGridViewTextBoxColumn
            // 
            this.dateBeginDataGridViewTextBoxColumn.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.HeaderText = "Дата назначения";
            this.dateBeginDataGridViewTextBoxColumn.Name = "dateBeginDataGridViewTextBoxColumn";
            this.dateBeginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // planFundSumDataGridViewTextBoxColumn
            // 
            this.planFundSumDataGridViewTextBoxColumn.DataPropertyName = "PlanFundSum";
            this.planFundSumDataGridViewTextBoxColumn.HeaderText = "Плановая сумма";
            this.planFundSumDataGridViewTextBoxColumn.Name = "planFundSumDataGridViewTextBoxColumn";
            this.planFundSumDataGridViewTextBoxColumn.ReadOnly = true;
            this.planFundSumDataGridViewTextBoxColumn.Width = 120;
            // 
            // factFundSumDataGridViewTextBoxColumn
            // 
            this.factFundSumDataGridViewTextBoxColumn.DataPropertyName = "FactFundSum";
            this.factFundSumDataGridViewTextBoxColumn.HeaderText = "Фактическая сумма";
            this.factFundSumDataGridViewTextBoxColumn.Name = "factFundSumDataGridViewTextBoxColumn";
            this.factFundSumDataGridViewTextBoxColumn.ReadOnly = true;
            this.factFundSumDataGridViewTextBoxColumn.Width = 120;
            // 
            // extraordSumDataGridViewTextBoxColumn
            // 
            this.extraordSumDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.extraordSumDataGridViewTextBoxColumn.DataPropertyName = "ExtraordSum";
            this.extraordSumDataGridViewTextBoxColumn.HeaderText = "Внеплановые расходы";
            this.extraordSumDataGridViewTextBoxColumn.Name = "extraordSumDataGridViewTextBoxColumn";
            this.extraordSumDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // departmentFundBindingSource
            // 
            this.departmentFundBindingSource.DataSource = typeof(Kadr.Data.DepartmentFund);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn1.HeaderText = "Дата назначения";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "PlanFundSum";
            this.dataGridViewTextBoxColumn2.HeaderText = "Плановая сумма";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 120;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "FactFundSum";
            this.dataGridViewTextBoxColumn3.HeaderText = "Фактическая сумма";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 120;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ExtraordSum";
            this.dataGridViewTextBoxColumn4.HeaderText = "Внеплановые расходы";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // DepartmentFundForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(531, 363);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "DepartmentFundForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Бюджетный фонд отдела";
            this.Load += new System.EventHandler(this.DepartmentFundForm_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDepurtmentFund)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentFundBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripButton tsbEditDepFund;
        private System.Windows.Forms.ToolStripButton tsbDelDepFund;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbClose;
        private System.Windows.Forms.BindingSource departmentFundBindingSource;
        private System.Windows.Forms.DataGridView dgvDepurtmentFund;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn planFundSumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn factFundSumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn extraordSumDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripButton tsbAddDepFund;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;

    }
}