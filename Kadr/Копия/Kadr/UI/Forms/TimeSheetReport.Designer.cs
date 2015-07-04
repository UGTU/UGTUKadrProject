namespace Kadr.UI.Forms
{
    partial class TimeSheetReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TimeSheetReport));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.cbTimeSheet = new System.Windows.Forms.ToolStripComboBox();
            this.tsUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.создатьЗановоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.добавитьНедостающиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnTSheetReportToExcel = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.dgvTSRecord = new System.Windows.Forms.DataGridView();
            this.isClosedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsCreated = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.Department = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.factStaffDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StaffCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.workingDaysCountDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.timeSheetFSWorkingDaysBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTSRecord)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSheetFSWorkingDaysBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.cbTimeSheet,
            this.tsUpdate,
            this.toolStripDropDownButton1,
            this.toolStripSeparator1,
            this.btnTSheetReportToExcel,
            this.toolStripSeparator2,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(855, 25);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // cbTimeSheet
            // 
            this.cbTimeSheet.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTimeSheet.Name = "cbTimeSheet";
            this.cbTimeSheet.Size = new System.Drawing.Size(201, 25);
            this.cbTimeSheet.ToolTipText = "Месяц табеля";
            this.cbTimeSheet.SelectedIndexChanged += new System.EventHandler(this.cbTimeSheet_SelectedIndexChanged);
            // 
            // tsUpdate
            // 
            this.tsUpdate.Image = global::Kadr.Properties.Resources.RefreshDocViewHS;
            this.tsUpdate.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsUpdate.Name = "tsUpdate";
            this.tsUpdate.Size = new System.Drawing.Size(81, 22);
            this.tsUpdate.Text = "Обновить";
            this.tsUpdate.ToolTipText = "Обновить все табели";
            this.tsUpdate.Visible = false;
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.создатьЗановоToolStripMenuItem,
            this.добавитьНедостающиеToolStripMenuItem});
            this.toolStripDropDownButton1.Image = global::Kadr.Properties.Resources.AddToFavoritesHS;
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(79, 22);
            this.toolStripDropDownButton1.Text = "Создать";
            // 
            // создатьЗановоToolStripMenuItem
            // 
            this.создатьЗановоToolStripMenuItem.Name = "создатьЗановоToolStripMenuItem";
            this.создатьЗановоToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.создатьЗановоToolStripMenuItem.Text = "Создать заново";
            this.создатьЗановоToolStripMenuItem.Click += new System.EventHandler(this.создатьЗановоToolStripMenuItem_Click);
            // 
            // добавитьНедостающиеToolStripMenuItem
            // 
            this.добавитьНедостающиеToolStripMenuItem.Name = "добавитьНедостающиеToolStripMenuItem";
            this.добавитьНедостающиеToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.добавитьНедостающиеToolStripMenuItem.Text = "Добавить недостающих";
            this.добавитьНедостающиеToolStripMenuItem.Click += new System.EventHandler(this.добавитьНедостающиеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnTSheetReportToExcel
            // 
            this.btnTSheetReportToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnTSheetReportToExcel.Image")));
            this.btnTSheetReportToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnTSheetReportToExcel.Name = "btnTSheetReportToExcel";
            this.btnTSheetReportToExcel.Size = new System.Drawing.Size(142, 22);
            this.btnTSheetReportToExcel.Text = "Выгрузить в MS Excel";
            this.btnTSheetReportToExcel.Click += new System.EventHandler(this.btnTSheetReportToExcel_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
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
            // dgvTSRecord
            // 
            this.dgvTSRecord.AllowUserToAddRows = false;
            this.dgvTSRecord.AllowUserToDeleteRows = false;
            this.dgvTSRecord.AutoGenerateColumns = false;
            this.dgvTSRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTSRecord.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.isClosedDataGridViewCheckBoxColumn,
            this.IsCreated,
            this.Department,
            this.factStaffDataGridViewTextBoxColumn,
            this.StaffCount,
            this.workingDaysCountDataGridViewTextBoxColumn});
            this.dgvTSRecord.DataSource = this.timeSheetFSWorkingDaysBindingSource;
            this.dgvTSRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTSRecord.Location = new System.Drawing.Point(0, 25);
            this.dgvTSRecord.Name = "dgvTSRecord";
            this.dgvTSRecord.ReadOnly = true;
            this.dgvTSRecord.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTSRecord.Size = new System.Drawing.Size(855, 422);
            this.dgvTSRecord.TabIndex = 1;
            this.dgvTSRecord.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvTSRecord_CellClick);
            this.dgvTSRecord.DoubleClick += new System.EventHandler(this.dgvTSRecord_DoubleClick);
            // 
            // isClosedDataGridViewCheckBoxColumn
            // 
            this.isClosedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.isClosedDataGridViewCheckBoxColumn.DataPropertyName = "IsClosed";
            this.isClosedDataGridViewCheckBoxColumn.HeaderText = "Зафикс.";
            this.isClosedDataGridViewCheckBoxColumn.Name = "isClosedDataGridViewCheckBoxColumn";
            this.isClosedDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isClosedDataGridViewCheckBoxColumn.Width = 55;
            // 
            // IsCreated
            // 
            this.IsCreated.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsCreated.DataPropertyName = "IsCreated";
            this.IsCreated.HeaderText = "Создан";
            this.IsCreated.Name = "IsCreated";
            this.IsCreated.ReadOnly = true;
            this.IsCreated.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsCreated.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsCreated.Width = 69;
            // 
            // Department
            // 
            this.Department.DataPropertyName = "Department";
            this.Department.HeaderText = "Отдел";
            this.Department.Name = "Department";
            this.Department.ReadOnly = true;
            this.Department.Width = 130;
            // 
            // factStaffDataGridViewTextBoxColumn
            // 
            this.factStaffDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.factStaffDataGridViewTextBoxColumn.DataPropertyName = "FactStaff";
            this.factStaffDataGridViewTextBoxColumn.HeaderText = "Сотрудник";
            this.factStaffDataGridViewTextBoxColumn.Name = "factStaffDataGridViewTextBoxColumn";
            this.factStaffDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // StaffCount
            // 
            this.StaffCount.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.StaffCount.DataPropertyName = "StaffCount";
            this.StaffCount.HeaderText = "Кол-во ставок";
            this.StaffCount.Name = "StaffCount";
            this.StaffCount.ReadOnly = true;
            this.StaffCount.Width = 96;
            // 
            // workingDaysCountDataGridViewTextBoxColumn
            // 
            this.workingDaysCountDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.workingDaysCountDataGridViewTextBoxColumn.DataPropertyName = "WorkingDaysCount";
            this.workingDaysCountDataGridViewTextBoxColumn.HeaderText = "Кол-во рабочих дней";
            this.workingDaysCountDataGridViewTextBoxColumn.Name = "workingDaysCountDataGridViewTextBoxColumn";
            this.workingDaysCountDataGridViewTextBoxColumn.ReadOnly = true;
            this.workingDaysCountDataGridViewTextBoxColumn.Width = 103;
            // 
            // timeSheetFSWorkingDaysBindingSource
            // 
            this.timeSheetFSWorkingDaysBindingSource.DataSource = typeof(Kadr.Data.TimeSheetFSWorkingDay);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "idTimeSheet";
            this.dataGridViewTextBoxColumn1.HeaderText = "idTimeSheet";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "idFactStaff";
            this.dataGridViewTextBoxColumn2.HeaderText = "idFactStaff";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "WorkingDaysCount";
            this.dataGridViewTextBoxColumn3.HeaderText = "WorkingDaysCount";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "FactStaff";
            this.dataGridViewTextBoxColumn4.HeaderText = "FactStaff";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "TimeSheet";
            this.dataGridViewTextBoxColumn5.HeaderText = "TimeSheet";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // TimeSheetReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(855, 447);
            this.Controls.Add(this.dgvTSRecord);
            this.Controls.Add(this.toolStrip1);
            this.Name = "TimeSheetReport";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Информация по табелю";
            this.Load += new System.EventHandler(this.TimeSheetReport_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTSRecord)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSheetFSWorkingDaysBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvTSRecord;
        private System.Windows.Forms.BindingSource timeSheetFSWorkingDaysBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripButton tsUpdate;
        private System.Windows.Forms.ToolStripComboBox cbTimeSheet;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem создатьЗановоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem добавитьНедостающиеToolStripMenuItem;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsCreated;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isClosedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Department;
        private System.Windows.Forms.DataGridViewTextBoxColumn factStaffDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn StaffCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn workingDaysCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnTSheetReportToExcel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}