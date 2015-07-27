namespace Kadr.UI.Forms
{
    partial class SocialFareTransitForm
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvPlanStaffHistory = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.EditPStChangeBtn = new System.Windows.Forms.ToolStripButton();
            this.DelPStChangeBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            this.socialFareTransitBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBeginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FactStaffPrikaz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idEmployeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idFactStaffPrikazDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.employeeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanStaffHistory)).BeginInit();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.socialFareTransitBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvPlanStaffHistory
            // 
            this.dgvPlanStaffHistory.AllowUserToAddRows = false;
            this.dgvPlanStaffHistory.AllowUserToDeleteRows = false;
            this.dgvPlanStaffHistory.AutoGenerateColumns = false;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanStaffHistory.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvPlanStaffHistory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPlanStaffHistory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.dateBeginDataGridViewTextBoxColumn,
            this.dateEndDataGridViewTextBoxColumn,
            this.FactStaffPrikaz,
            this.idEmployeeDataGridViewTextBoxColumn,
            this.idFactStaffPrikazDataGridViewTextBoxColumn,
            this.employeeDataGridViewTextBoxColumn});
            this.dgvPlanStaffHistory.DataSource = this.socialFareTransitBindingSource;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvPlanStaffHistory.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgvPlanStaffHistory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPlanStaffHistory.Location = new System.Drawing.Point(0, 25);
            this.dgvPlanStaffHistory.Name = "dgvPlanStaffHistory";
            this.dgvPlanStaffHistory.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvPlanStaffHistory.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvPlanStaffHistory.RowHeadersVisible = false;
            this.dgvPlanStaffHistory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPlanStaffHistory.Size = new System.Drawing.Size(539, 322);
            this.dgvPlanStaffHistory.TabIndex = 7;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EditPStChangeBtn,
            this.DelPStChangeBtn,
            this.toolStripSeparator1,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(539, 25);
            this.toolStrip1.TabIndex = 6;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // EditPStChangeBtn
            // 
            this.EditPStChangeBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditPStChangeBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditPStChangeBtn.Name = "EditPStChangeBtn";
            this.EditPStChangeBtn.Size = new System.Drawing.Size(107, 22);
            this.EditPStChangeBtn.Text = "Редактировать";
            this.EditPStChangeBtn.ToolTipText = "Редактировать изменение";
            // 
            // DelPStChangeBtn
            // 
            this.DelPStChangeBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DelPStChangeBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelPStChangeBtn.Name = "DelPStChangeBtn";
            this.DelPStChangeBtn.Size = new System.Drawing.Size(134, 22);
            this.DelPStChangeBtn.Text = "Удалить изменение";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Kadr.Properties.Resources.DeleteFolderHS;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 22);
            this.btnClose.Text = "Выход";
            this.btnClose.ToolTipText = "Закрыть окно";
            // 
            // socialFareTransitBindingSource
            // 
            this.socialFareTransitBindingSource.DataSource = typeof(Kadr.Data.SocialFareTransit);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.ReadOnly = true;
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateBeginDataGridViewTextBoxColumn
            // 
            this.dateBeginDataGridViewTextBoxColumn.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.HeaderText = "Дата начала периода";
            this.dateBeginDataGridViewTextBoxColumn.Name = "dateBeginDataGridViewTextBoxColumn";
            this.dateBeginDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // dateEndDataGridViewTextBoxColumn
            // 
            this.dateEndDataGridViewTextBoxColumn.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn.HeaderText = "Дата окончания периода";
            this.dateEndDataGridViewTextBoxColumn.Name = "dateEndDataGridViewTextBoxColumn";
            this.dateEndDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // FactStaffPrikaz
            // 
            this.FactStaffPrikaz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.FactStaffPrikaz.DataPropertyName = "FactStaffPrikaz";
            this.FactStaffPrikaz.HeaderText = "Приказ об использовании";
            this.FactStaffPrikaz.Name = "FactStaffPrikaz";
            this.FactStaffPrikaz.ReadOnly = true;
            // 
            // idEmployeeDataGridViewTextBoxColumn
            // 
            this.idEmployeeDataGridViewTextBoxColumn.DataPropertyName = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn.HeaderText = "idEmployee";
            this.idEmployeeDataGridViewTextBoxColumn.Name = "idEmployeeDataGridViewTextBoxColumn";
            this.idEmployeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.idEmployeeDataGridViewTextBoxColumn.Visible = false;
            // 
            // idFactStaffPrikazDataGridViewTextBoxColumn
            // 
            this.idFactStaffPrikazDataGridViewTextBoxColumn.DataPropertyName = "idFactStaffPrikaz";
            this.idFactStaffPrikazDataGridViewTextBoxColumn.HeaderText = "idFactStaffPrikaz";
            this.idFactStaffPrikazDataGridViewTextBoxColumn.Name = "idFactStaffPrikazDataGridViewTextBoxColumn";
            this.idFactStaffPrikazDataGridViewTextBoxColumn.ReadOnly = true;
            this.idFactStaffPrikazDataGridViewTextBoxColumn.Visible = false;
            // 
            // employeeDataGridViewTextBoxColumn
            // 
            this.employeeDataGridViewTextBoxColumn.DataPropertyName = "Employee";
            this.employeeDataGridViewTextBoxColumn.HeaderText = "Employee";
            this.employeeDataGridViewTextBoxColumn.Name = "employeeDataGridViewTextBoxColumn";
            this.employeeDataGridViewTextBoxColumn.ReadOnly = true;
            this.employeeDataGridViewTextBoxColumn.Visible = false;
            // 
            // SocialFareTransitForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(539, 347);
            this.Controls.Add(this.dgvPlanStaffHistory);
            this.Controls.Add(this.toolStrip1);
            this.Name = "SocialFareTransitForm";
            this.Text = "SocialFareTransitForm";
            this.Load += new System.EventHandler(this.SocialFareTransitForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPlanStaffHistory)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.socialFareTransitBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPlanStaffHistory;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton EditPStChangeBtn;
        private System.Windows.Forms.ToolStripButton DelPStChangeBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.BindingSource socialFareTransitBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn FactStaffPrikaz;
        private System.Windows.Forms.DataGridViewTextBoxColumn idEmployeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idFactStaffPrikazDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
    }
}