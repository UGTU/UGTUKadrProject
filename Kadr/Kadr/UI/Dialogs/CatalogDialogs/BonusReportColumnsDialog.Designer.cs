namespace Kadr.UI.Dialogs
{
    partial class BonusReportColumnsDialog
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
            this.dgvBonusReportColumns = new System.Windows.Forms.DataGridView();
            this.bonusTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.bonusTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bonusOrderNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonusReportColumnBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBonusReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbBonusReport = new System.Windows.Forms.ComboBox();
            this.bonusReportBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusReportColumns)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportColumnBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBonusReport);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbBonusReport);
            this.panel1.Controls.Add(this.dgvBonusReportColumns);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(601, 338);
            this.panel1.Controls.SetChildIndex(this.dgvBonusReportColumns, 0);
            this.panel1.Controls.SetChildIndex(this.cbBonusReport, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnBonusReport, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 353);
            this.panel2.Size = new System.Drawing.Size(602, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(510, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(418, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(326, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dgvBonusReportColumns
            // 
            this.dgvBonusReportColumns.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBonusReportColumns.AutoGenerateColumns = false;
            this.dgvBonusReportColumns.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonusReportColumns.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bonusTypeDataGridViewTextBoxColumn,
            this.bonusOrderNumberDataGridViewTextBoxColumn});
            this.dgvBonusReportColumns.DataSource = this.bonusReportColumnBindingSource;
            this.dgvBonusReportColumns.Location = new System.Drawing.Point(0, 50);
            this.dgvBonusReportColumns.Name = "dgvBonusReportColumns";
            this.dgvBonusReportColumns.ReadOnly = true;
            this.dgvBonusReportColumns.Size = new System.Drawing.Size(597, 256);
            this.dgvBonusReportColumns.TabIndex = 5;
            this.dgvBonusReportColumns.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBonusReportColumns_CellBeginEdit);
            this.dgvBonusReportColumns.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvBonusReportColumns_DataError);
            this.dgvBonusReportColumns.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBonusReportColumns_RowValidating);
            // 
            // bonusTypeDataGridViewTextBoxColumn
            // 
            this.bonusTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bonusTypeDataGridViewTextBoxColumn.DataPropertyName = "BonusType";
            this.bonusTypeDataGridViewTextBoxColumn.DataSource = this.bonusTypeBindingSource;
            this.bonusTypeDataGridViewTextBoxColumn.HeaderText = "Вид надбавки";
            this.bonusTypeDataGridViewTextBoxColumn.Name = "bonusTypeDataGridViewTextBoxColumn";
            this.bonusTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bonusTypeDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.bonusTypeDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // bonusTypeBindingSource
            // 
            this.bonusTypeBindingSource.DataSource = typeof(Kadr.Data.BonusType);
            // 
            // bonusOrderNumberDataGridViewTextBoxColumn
            // 
            this.bonusOrderNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.bonusOrderNumberDataGridViewTextBoxColumn.DataPropertyName = "BonusOrderNumber";
            this.bonusOrderNumberDataGridViewTextBoxColumn.HeaderText = "Порядок следования";
            this.bonusOrderNumberDataGridViewTextBoxColumn.Name = "bonusOrderNumberDataGridViewTextBoxColumn";
            this.bonusOrderNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.bonusOrderNumberDataGridViewTextBoxColumn.Width = 127;
            // 
            // bonusReportColumnBindingSource
            // 
            this.bonusReportColumnBindingSource.AllowNew = false;
            this.bonusReportColumnBindingSource.DataSource = typeof(Kadr.Data.BonusReportColumn);
            // 
            // btnBonusReport
            // 
            this.btnBonusReport.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBonusReport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBonusReport.Location = new System.Drawing.Point(366, 23);
            this.btnBonusReport.Name = "btnBonusReport";
            this.btnBonusReport.Size = new System.Drawing.Size(232, 21);
            this.btnBonusReport.TabIndex = 11;
            this.btnBonusReport.Text = "Виды отчетов";
            this.btnBonusReport.UseVisualStyleBackColor = true;
            this.btnBonusReport.Click += new System.EventHandler(this.btnBonusReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Вид отчета";
            // 
            // cbBonusReport
            // 
            this.cbBonusReport.DataSource = this.bonusReportBindingSource;
            this.cbBonusReport.DisplayMember = "ReporName";
            this.cbBonusReport.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBonusReport.Location = new System.Drawing.Point(0, 23);
            this.cbBonusReport.Name = "cbBonusReport";
            this.cbBonusReport.Size = new System.Drawing.Size(360, 21);
            this.cbBonusReport.TabIndex = 9;
            this.cbBonusReport.ValueMember = "id";
            this.cbBonusReport.SelectedValueChanged += new System.EventHandler(this.cbBonusReport_SelectedValueChanged);
            // 
            // bonusReportBindingSource
            // 
            this.bonusReportBindingSource.DataSource = typeof(Kadr.Data.BonusReport);
            // 
            // BonusReportColumnsDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(626, 391);
            this.Name = "BonusReportColumnsDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Последовательность надбавок в отчете";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BonusReportColumnsDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusReportColumns)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportColumnBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusReportBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBonusReportColumns;
        private System.Windows.Forms.BindingSource bonusReportColumnBindingSource;
        private System.Windows.Forms.BindingSource bonusTypeBindingSource;
        private System.Windows.Forms.Button btnBonusReport;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBonusReport;
        private System.Windows.Forms.BindingSource bonusReportBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn bonusTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonusOrderNumberDataGridViewTextBoxColumn;
    }
}