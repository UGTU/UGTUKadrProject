namespace Kadr.UI.Forms
{
    partial class TimeSheetsForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvTimeSheets = new System.Windows.Forms.DataGridView();
            this.MonthName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSheetAllDayCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSheetWorkingDayCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TimeSheetWorkingHourCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsFilled = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsClosed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.timeSheetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbTimeSheetYear = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.AddTimeSheetBtn = new System.Windows.Forms.ToolStripButton();
            this.EditTimeSheetBtn = new System.Windows.Forms.ToolStripButton();
            this.DelTimeSheetBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnFillingReport = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSheets)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSheetBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvTimeSheets
            // 
            this.dgvTimeSheets.AllowUserToAddRows = false;
            this.dgvTimeSheets.AllowUserToDeleteRows = false;
            this.dgvTimeSheets.AutoGenerateColumns = false;
            this.dgvTimeSheets.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTimeSheets.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MonthName,
            this.timeSheetAllDayCountDataGridViewTextBoxColumn,
            this.timeSheetWorkingDayCountDataGridViewTextBoxColumn,
            this.TimeSheetWorkingHourCount,
            this.IsFilled,
            this.IsClosed});
            this.dgvTimeSheets.DataSource = this.timeSheetBindingSource;
            this.dgvTimeSheets.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTimeSheets.Location = new System.Drawing.Point(0, 25);
            this.dgvTimeSheets.Name = "dgvTimeSheets";
            this.dgvTimeSheets.ReadOnly = true;
            this.dgvTimeSheets.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTimeSheets.Size = new System.Drawing.Size(664, 317);
            this.dgvTimeSheets.TabIndex = 1;
            this.dgvTimeSheets.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTimeSheets_CellClick);
            this.dgvTimeSheets.DoubleClick += new System.EventHandler(this.dgvTimeSheets_DoubleClick);
            // 
            // MonthName
            // 
            this.MonthName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.MonthName.DataPropertyName = "MonthName";
            this.MonthName.HeaderText = "Месяц";
            this.MonthName.Name = "MonthName";
            this.MonthName.ReadOnly = true;
            // 
            // timeSheetAllDayCountDataGridViewTextBoxColumn
            // 
            this.timeSheetAllDayCountDataGridViewTextBoxColumn.DataPropertyName = "TimeSheetWorkingDayCount";
            this.timeSheetAllDayCountDataGridViewTextBoxColumn.HeaderText = "Всего дней в месяце";
            this.timeSheetAllDayCountDataGridViewTextBoxColumn.Name = "timeSheetAllDayCountDataGridViewTextBoxColumn";
            this.timeSheetAllDayCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeSheetAllDayCountDataGridViewTextBoxColumn.Width = 190;
            // 
            // timeSheetWorkingDayCountDataGridViewTextBoxColumn
            // 
            this.timeSheetWorkingDayCountDataGridViewTextBoxColumn.DataPropertyName = "TimeSheetWorkingDayCount";
            this.timeSheetWorkingDayCountDataGridViewTextBoxColumn.HeaderText = "Кол-во рабочих дней";
            this.timeSheetWorkingDayCountDataGridViewTextBoxColumn.Name = "timeSheetWorkingDayCountDataGridViewTextBoxColumn";
            this.timeSheetWorkingDayCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.timeSheetWorkingDayCountDataGridViewTextBoxColumn.Visible = false;
            this.timeSheetWorkingDayCountDataGridViewTextBoxColumn.Width = 153;
            // 
            // TimeSheetWorkingHourCount
            // 
            this.TimeSheetWorkingHourCount.DataPropertyName = "TimeSheetWorkingHourCount";
            dataGridViewCellStyle1.Format = "N2";
            dataGridViewCellStyle1.NullValue = null;
            this.TimeSheetWorkingHourCount.DefaultCellStyle = dataGridViewCellStyle1;
            this.TimeSheetWorkingHourCount.HeaderText = "Среднемес. кол-во часов";
            this.TimeSheetWorkingHourCount.Name = "TimeSheetWorkingHourCount";
            this.TimeSheetWorkingHourCount.ReadOnly = true;
            // 
            // IsFilled
            // 
            this.IsFilled.DataPropertyName = "IsFilled";
            this.IsFilled.HeaderText = "Заполнен";
            this.IsFilled.Name = "IsFilled";
            this.IsFilled.ReadOnly = true;
            // 
            // IsClosed
            // 
            this.IsClosed.DataPropertyName = "IsClosed";
            this.IsClosed.HeaderText = "Закрыт";
            this.IsClosed.Name = "IsClosed";
            this.IsClosed.ReadOnly = true;
            // 
            // timeSheetBindingSource
            // 
            this.timeSheetBindingSource.DataSource = typeof(Kadr.Data.TimeSheet);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbTimeSheetYear,
            this.toolStripSeparator1,
            this.AddTimeSheetBtn,
            this.EditTimeSheetBtn,
            this.DelTimeSheetBtn,
            this.toolStripSeparator2,
            this.btnFillingReport,
            this.toolStripSeparator3,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(664, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbTimeSheetYear
            // 
            this.cbTimeSheetYear.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeSheetYear.Name = "cbTimeSheetYear";
            this.cbTimeSheetYear.Size = new System.Drawing.Size(121, 25);
            this.cbTimeSheetYear.ToolTipText = "Год табеля";
            this.cbTimeSheetYear.SelectedIndexChanged += new System.EventHandler(this.cbTimeSheetYear_SelectedValueChanged);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // AddTimeSheetBtn
            // 
            this.AddTimeSheetBtn.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.AddTimeSheetBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddTimeSheetBtn.Name = "AddTimeSheetBtn";
            this.AddTimeSheetBtn.Size = new System.Drawing.Size(119, 22);
            this.AddTimeSheetBtn.Text = "Добавить табель";
            this.AddTimeSheetBtn.Click += new System.EventHandler(this.AddTimeSheetBtn_Click);
            // 
            // EditTimeSheetBtn
            // 
            this.EditTimeSheetBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditTimeSheetBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditTimeSheetBtn.Name = "EditTimeSheetBtn";
            this.EditTimeSheetBtn.Size = new System.Drawing.Size(107, 22);
            this.EditTimeSheetBtn.Text = "Редактировать";
            this.EditTimeSheetBtn.Click += new System.EventHandler(this.dgvTimeSheets_DoubleClick);
            // 
            // DelTimeSheetBtn
            // 
            this.DelTimeSheetBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DelTimeSheetBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelTimeSheetBtn.Name = "DelTimeSheetBtn";
            this.DelTimeSheetBtn.Size = new System.Drawing.Size(71, 22);
            this.DelTimeSheetBtn.Text = "Удалить";
            this.DelTimeSheetBtn.Click += new System.EventHandler(this.DelTimeSheetBtn_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnFillingReport
            // 
            this.btnFillingReport.Image = global::Kadr.Properties.Resources.TaskHS;
            this.btnFillingReport.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnFillingReport.Name = "btnFillingReport";
            this.btnFillingReport.Size = new System.Drawing.Size(59, 22);
            this.btnFillingReport.Text = "Отчет";
            this.btnFillingReport.ToolTipText = "Отчет по заполнению";
            this.btnFillingReport.Click += new System.EventHandler(this.btnFillingReport_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Kadr.Properties.Resources.DeleteFolderHS;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 22);
            this.btnClose.Text = "Выход";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn1.HeaderText = "id";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "TimeSheetMonth";
            this.dataGridViewTextBoxColumn2.HeaderText = "TimeSheetMonth";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 150;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TimeSheetYear";
            this.dataGridViewTextBoxColumn3.HeaderText = "TimeSheetYear";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Visible = false;
            this.dataGridViewTextBoxColumn3.Width = 153;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "TimeSheetAllDayCount";
            this.dataGridViewTextBoxColumn4.HeaderText = "TimeSheetAllDayCount";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TimeSheetWorkingDayCount";
            this.dataGridViewTextBoxColumn5.HeaderText = "TimeSheetWorkingDayCount";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // TimeSheetsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(664, 342);
            this.Controls.Add(this.dgvTimeSheets);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TimeSheetsForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Табели рабочего времени";
            this.Load += new System.EventHandler(this.TimeSheetsForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTimeSheets)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSheetBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource timeSheetBindingSource;
        private System.Windows.Forms.DataGridView dgvTimeSheets;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton AddTimeSheetBtn;
        private System.Windows.Forms.ToolStripButton EditTimeSheetBtn;
        private System.Windows.Forms.ToolStripButton DelTimeSheetBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripComboBox cbTimeSheetYear;
        private System.Windows.Forms.ToolStripButton btnFillingReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn MonthName;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeSheetAllDayCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn timeSheetWorkingDayCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TimeSheetWorkingHourCount;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsFilled;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsClosed;
    }
}