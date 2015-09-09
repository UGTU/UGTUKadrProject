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
            this.idRegionType = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.regionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBusinessTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.regionTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBeginDataGridViewTextBoxColumn = new Kadr.UI.Common.DataGridViewDateTimeColumn();
            this.dateEndDataGridViewTextBoxColumn = new Kadr.UI.Common.DataGridViewDateTimeColumn();
            this.businessTripDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.businessTripRegionTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel3 = new System.Windows.Forms.Panel();
            this.bDelete = new System.Windows.Forms.Button();
            this.bEdit = new System.Windows.Forms.Button();
            this.bAdd = new System.Windows.Forms.Button();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbRegion = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegionType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessTripRegionTypeBindingSource)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvRegionType);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(569, 188);
            this.panel1.Controls.SetChildIndex(this.dgvRegionType, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 207);
            this.panel2.Size = new System.Drawing.Size(569, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(477, 14);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Visible = false;
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(385, 4);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.OKBtn.DialogResult = System.Windows.Forms.DialogResult.None;
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(293, 4);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dgvRegionType
            // 
            this.dgvRegionType.AllowUserToAddRows = false;
            this.dgvRegionType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvRegionType.AutoGenerateColumns = false;
            this.dgvRegionType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRegionType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idRegionType,
            this.iDDataGridViewTextBoxColumn,
            this.idBusinessTripDataGridViewTextBoxColumn,
            this.regionTypeDataGridViewTextBoxColumn,
            this.dateBeginDataGridViewTextBoxColumn,
            this.dateEndDataGridViewTextBoxColumn,
            this.businessTripDataGridViewTextBoxColumn});
            this.dgvRegionType.DataSource = this.businessTripRegionTypeBindingSource;
            this.dgvRegionType.Location = new System.Drawing.Point(0, 0);
            this.dgvRegionType.MultiSelect = false;
            this.dgvRegionType.Name = "dgvRegionType";
            this.dgvRegionType.RowHeadersVisible = false;
            this.dgvRegionType.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRegionType.ShowCellErrors = false;
            this.dgvRegionType.ShowCellToolTips = false;
            this.dgvRegionType.ShowEditingIcon = false;
            this.dgvRegionType.ShowRowErrors = false;
            this.dgvRegionType.Size = new System.Drawing.Size(569, 157);
            this.dgvRegionType.TabIndex = 5;
            this.dgvRegionType.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.dgvRegionType_DataError);
            this.dgvRegionType.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgvRegionType_RowsAdded);
            // 
            // idRegionType
            // 
            this.idRegionType.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.idRegionType.DataPropertyName = "idRegionType";
            this.idRegionType.DataSource = this.regionTypeBindingSource;
            this.idRegionType.DisplayMember = "RegionTypeSmallName";
            this.idRegionType.HeaderText = "Территориальные условия";
            this.idRegionType.Name = "idRegionType";
            this.idRegionType.ValueMember = "id";
            // 
            // regionTypeBindingSource
            // 
            this.regionTypeBindingSource.DataSource = typeof(Kadr.Data.RegionType);
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            this.iDDataGridViewTextBoxColumn.Width = 43;
            // 
            // idBusinessTripDataGridViewTextBoxColumn
            // 
            this.idBusinessTripDataGridViewTextBoxColumn.DataPropertyName = "idBusinessTrip";
            this.idBusinessTripDataGridViewTextBoxColumn.HeaderText = "idBusinessTrip";
            this.idBusinessTripDataGridViewTextBoxColumn.Name = "idBusinessTripDataGridViewTextBoxColumn";
            this.idBusinessTripDataGridViewTextBoxColumn.Visible = false;
            // 
            // regionTypeDataGridViewTextBoxColumn
            // 
            this.regionTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.regionTypeDataGridViewTextBoxColumn.DataPropertyName = "RegionType";
            this.regionTypeDataGridViewTextBoxColumn.HeaderText = "Регион";
            this.regionTypeDataGridViewTextBoxColumn.Name = "regionTypeDataGridViewTextBoxColumn";
            this.regionTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // dateBeginDataGridViewTextBoxColumn
            // 
            this.dateBeginDataGridViewTextBoxColumn.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.HeaderText = "Дата начала пребывания";
            this.dateBeginDataGridViewTextBoxColumn.Name = "dateBeginDataGridViewTextBoxColumn";
            this.dateBeginDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateBeginDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dateBeginDataGridViewTextBoxColumn.Width = 170;
            // 
            // dateEndDataGridViewTextBoxColumn
            // 
            this.dateEndDataGridViewTextBoxColumn.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn.FillWeight = 150F;
            this.dateEndDataGridViewTextBoxColumn.HeaderText = "Дата окончания пребывания";
            this.dateEndDataGridViewTextBoxColumn.Name = "dateEndDataGridViewTextBoxColumn";
            this.dateEndDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateEndDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.dateEndDataGridViewTextBoxColumn.Width = 180;
            // 
            // businessTripDataGridViewTextBoxColumn
            // 
            this.businessTripDataGridViewTextBoxColumn.DataPropertyName = "BusinessTrip";
            this.businessTripDataGridViewTextBoxColumn.HeaderText = "BusinessTrip";
            this.businessTripDataGridViewTextBoxColumn.Name = "businessTripDataGridViewTextBoxColumn";
            this.businessTripDataGridViewTextBoxColumn.Visible = false;
            this.businessTripDataGridViewTextBoxColumn.Width = 92;
            // 
            // businessTripRegionTypeBindingSource
            // 
            this.businessTripRegionTypeBindingSource.DataSource = typeof(Kadr.Data.BusinessTripRegionType);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.bDelete);
            this.panel3.Controls.Add(this.bEdit);
            this.panel3.Controls.Add(this.bAdd);
            this.panel3.Controls.Add(this.dtEnd);
            this.panel3.Controls.Add(this.label3);
            this.panel3.Controls.Add(this.dtBegin);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Controls.Add(this.cbRegion);
            this.panel3.Location = new System.Drawing.Point(566, 142);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(551, 191);
            this.panel3.TabIndex = 5;
            this.panel3.Visible = false;
            // 
            // bDelete
            // 
            this.bDelete.Location = new System.Drawing.Point(378, 60);
            this.bDelete.Name = "bDelete";
            this.bDelete.Size = new System.Drawing.Size(170, 29);
            this.bDelete.TabIndex = 8;
            this.bDelete.Text = "Удалить выбранное";
            this.bDelete.UseVisualStyleBackColor = true;
            // 
            // bEdit
            // 
            this.bEdit.Location = new System.Drawing.Point(209, 60);
            this.bEdit.Name = "bEdit";
            this.bEdit.Size = new System.Drawing.Size(163, 29);
            this.bEdit.TabIndex = 7;
            this.bEdit.Text = "Изменить выбранное";
            this.bEdit.UseVisualStyleBackColor = true;
            // 
            // bAdd
            // 
            this.bAdd.Location = new System.Drawing.Point(0, 60);
            this.bAdd.Name = "bAdd";
            this.bAdd.Size = new System.Drawing.Size(203, 29);
            this.bAdd.TabIndex = 6;
            this.bAdd.Text = "Добавить новое";
            this.bAdd.UseVisualStyleBackColor = true;
            // 
            // dtEnd
            // 
            this.dtEnd.Location = new System.Drawing.Point(378, 33);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.Size = new System.Drawing.Size(170, 20);
            this.dtEnd.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(375, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(154, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата окончания пребывания";
            // 
            // dtBegin
            // 
            this.dtBegin.Location = new System.Drawing.Point(209, 34);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.Size = new System.Drawing.Size(163, 20);
            this.dtBegin.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(206, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата начала пребывания";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Регион";
            // 
            // cbRegion
            // 
            this.cbRegion.FormattingEnabled = true;
            this.cbRegion.Location = new System.Drawing.Point(0, 33);
            this.cbRegion.Name = "cbRegion";
            this.cbRegion.Size = new System.Drawing.Size(203, 21);
            this.cbRegion.TabIndex = 0;
            // 
            // TripRegionsDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(593, 245);
            this.Controls.Add(this.panel3);
            this.Name = "TripRegionsDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Места пребывания";
            this.Load += new System.EventHandler(this.TripRegionsDialog_Load);
            this.Controls.SetChildIndex(this.panel3, 0);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRegionType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.regionTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.businessTripRegionTypeBindingSource)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvRegionType;
        private System.Windows.Forms.BindingSource regionTypeBindingSource;
        private System.Windows.Forms.DataGridViewComboBoxColumn idRegionTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource businessTripRegionTypeBindingSource;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbRegion;
        private System.Windows.Forms.Button bDelete;
        private System.Windows.Forms.Button bEdit;
        private System.Windows.Forms.Button bAdd;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.DataGridViewComboBoxColumn idRegionType;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBusinessTripDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn regionTypeDataGridViewTextBoxColumn;
        private Common.DataGridViewDateTimeColumn dateBeginDataGridViewTextBoxColumn;
        private Common.DataGridViewDateTimeColumn dateEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn businessTripDataGridViewTextBoxColumn;
    }
}
