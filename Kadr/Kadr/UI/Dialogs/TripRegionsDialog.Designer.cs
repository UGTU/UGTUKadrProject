namespace Kadr.UI.Dialogs
{
    partial class TripRegionsDialog
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
            this.dgvRegionType = new System.Windows.Forms.DataGridView();
            this.idBusinessTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idRegionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.regionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dateBeginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessTripRegionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessTripRegionTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRegionType);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(550, 240);
            this.panel1.Controls.SetChildIndex(this.dgvRegionType, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 255);
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
            // dgvRegionType
            // 
            this.dgvRegionType.AutoGenerateColumns = false;
            this.dgvRegionType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegionType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idBusinessTripDataGridViewTextBoxColumn,
            this.idRegionType,
            this.dateBeginDataGridViewTextBoxColumn,
            this.dateEndDataGridViewTextBoxColumn,
            this.regionTypeDataGridViewTextBoxColumn,
            this.businessTripDataGridViewTextBoxColumn});
            this.dgvRegionType.DataSource = this.businessTripRegionTypeBindingSource;
            this.dgvRegionType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRegionType.Location = new System.Drawing.Point(0, 0);
            this.dgvRegionType.Name = "dgvRegionType";
            this.dgvRegionType.Size = new System.Drawing.Size(550, 215);
            this.dgvRegionType.TabIndex = 5;
            // 
            // idBusinessTripDataGridViewTextBoxColumn
            // 
            this.idBusinessTripDataGridViewTextBoxColumn.DataPropertyName = "idBusinessTrip";
            this.idBusinessTripDataGridViewTextBoxColumn.HeaderText = "idBusinessTrip";
            this.idBusinessTripDataGridViewTextBoxColumn.Name = "idBusinessTripDataGridViewTextBoxColumn";
            this.idBusinessTripDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.idBusinessTripDataGridViewTextBoxColumn.Visible = false;
            // 
            // idRegionType
            // 
            this.idRegionType.DataPropertyName = "idRegionType";
            this.idRegionType.DataSource = this.regionTypeBindingSource;
            this.idRegionType.DisplayMember = "RegionTypeName";
            this.idRegionType.HeaderText = "idRegionType";
            this.idRegionType.Name = "idRegionType";
            this.idRegionType.ValueMember = "id";
            // 
            // regionTypeBindingSource
            // 
            this.regionTypeBindingSource.DataSource = typeof(Kadr.Data.RegionType);
            // 
            // dateBeginDataGridViewTextBoxColumn
            // 
            this.dateBeginDataGridViewTextBoxColumn.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.HeaderText = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.Name = "dateBeginDataGridViewTextBoxColumn";
            // 
            // dateEndDataGridViewTextBoxColumn
            // 
            this.dateEndDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dateEndDataGridViewTextBoxColumn.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn.HeaderText = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn.Name = "dateEndDataGridViewTextBoxColumn";
            // 
            // regionTypeDataGridViewTextBoxColumn
            // 
            this.regionTypeDataGridViewTextBoxColumn.DataPropertyName = "RegionType";
            this.regionTypeDataGridViewTextBoxColumn.HeaderText = "RegionType";
            this.regionTypeDataGridViewTextBoxColumn.Name = "regionTypeDataGridViewTextBoxColumn";
            this.regionTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // businessTripDataGridViewTextBoxColumn
            // 
            this.businessTripDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.businessTripDataGridViewTextBoxColumn.DataPropertyName = "BusinessTrip";
            this.businessTripDataGridViewTextBoxColumn.HeaderText = "BusinessTrip";
            this.businessTripDataGridViewTextBoxColumn.Name = "businessTripDataGridViewTextBoxColumn";
            this.businessTripDataGridViewTextBoxColumn.Visible = false;
            // 
            // businessTripRegionTypeBindingSource
            // 
            this.businessTripRegionTypeBindingSource.DataSource = typeof(Kadr.Data.BusinessTripRegionType);
            // 
            // TripRegionsDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(575, 293);
            this.Name = "TripRegionsDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Места пребывания";
            this.Load += new System.EventHandler(this.TripRegionsDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessTripRegionTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegionType;
        private System.Windows.Forms.BindingSource regionTypeBindingSource;
        private System.Windows.Forms.BindingSource businessTripRegionTypeBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn idRegionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBusinessTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn idRegionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn businessTripDataGridViewTextBoxColumn;
    }
}
