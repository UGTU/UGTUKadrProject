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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.regionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.businessTripRegionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idRegionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBusinessTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBeginDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RegionCB = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessTripRegionTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(550, 240);
            this.panel1.Controls.SetChildIndex(this.dataGridView1, 0);
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
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRegionTypeDataGridViewTextBoxColumn,
            this.idBusinessTripDataGridViewTextBoxColumn,
            this.dateBeginDataGridViewTextBoxColumn,
            this.dateEndDataGridViewTextBoxColumn,
            this.regionTypeDataGridViewTextBoxColumn,
            this.businessTripDataGridViewTextBoxColumn,
            this.RegionCB});
            this.dataGridView1.DataSource = this.businessTripRegionTypeBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(550, 215);
            this.dataGridView1.TabIndex = 5;
            // 
            // regionTypeBindingSource
            // 
            this.regionTypeBindingSource.DataSource = typeof(Kadr.Data.RegionType);
            // 
            // businessTripRegionTypeBindingSource
            // 
            this.businessTripRegionTypeBindingSource.DataSource = typeof(Kadr.Data.BusinessTripRegionType);
            // 
            // idRegionTypeDataGridViewTextBoxColumn
            // 
            this.idRegionTypeDataGridViewTextBoxColumn.DataPropertyName = "idRegionType";
            this.idRegionTypeDataGridViewTextBoxColumn.HeaderText = "idRegionType";
            this.idRegionTypeDataGridViewTextBoxColumn.Name = "idRegionTypeDataGridViewTextBoxColumn";
            this.idRegionTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // idBusinessTripDataGridViewTextBoxColumn
            // 
            this.idBusinessTripDataGridViewTextBoxColumn.DataPropertyName = "idBusinessTrip";
            this.idBusinessTripDataGridViewTextBoxColumn.HeaderText = "idBusinessTrip";
            this.idBusinessTripDataGridViewTextBoxColumn.Name = "idBusinessTripDataGridViewTextBoxColumn";
            this.idBusinessTripDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateBeginDataGridViewTextBoxColumn
            // 
            this.dateBeginDataGridViewTextBoxColumn.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.HeaderText = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.Name = "dateBeginDataGridViewTextBoxColumn";
            // 
            // dateEndDataGridViewTextBoxColumn
            // 
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
            this.businessTripDataGridViewTextBoxColumn.DataPropertyName = "BusinessTrip";
            this.businessTripDataGridViewTextBoxColumn.HeaderText = "BusinessTrip";
            this.businessTripDataGridViewTextBoxColumn.Name = "businessTripDataGridViewTextBoxColumn";
            this.businessTripDataGridViewTextBoxColumn.Visible = false;
            // 
            // RegionCB
            // 
            this.RegionCB.DataPropertyName = "idRegionType";
            this.RegionCB.DataSource = this.regionTypeBindingSource;
            this.RegionCB.DisplayMember = "RegionTypeName";
            this.RegionCB.HeaderText = "Регион";
            this.RegionCB.Name = "RegionCB";
            this.RegionCB.ValueMember = "id";
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessTripRegionTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource regionTypeBindingSource;
        private System.Windows.Forms.BindingSource businessTripRegionTypeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idRegionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBusinessTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn businessTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn RegionCB;
    }
}
