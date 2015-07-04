namespace Kadr.UI.Dialogs
{
    partial class PrikazDialog
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
            this.dgvPrikaz = new System.Windows.Forms.DataGridView();
            this.prikazNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateBeginDataGridViewTextBoxColumn = new Kadr.UI.Common.DataGridViewDateTimeColumn();
            this.datePrikazDataGridViewTextBoxColumn = new Kadr.UI.Common.DataGridViewDateTimeColumn();
            this.prikazBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPrikazType = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrikazType = new System.Windows.Forms.ComboBox();
            this.prikazTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrikaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPrikazType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbPrikazType);
            this.panel1.Controls.Add(this.dgvPrikaz);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(618, 289);
            this.panel1.Controls.SetChildIndex(this.dgvPrikaz, 0);
            this.panel1.Controls.SetChildIndex(this.cbPrikazType, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnPrikazType, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 304);
            this.panel2.Size = new System.Drawing.Size(619, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(527, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(435, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(343, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dgvPrikaz
            // 
            this.dgvPrikaz.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvPrikaz.AutoGenerateColumns = false;
            this.dgvPrikaz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrikaz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prikazNameDataGridViewTextBoxColumn,
            this.dateBeginDataGridViewTextBoxColumn,
            this.datePrikazDataGridViewTextBoxColumn});
            this.dgvPrikaz.DataSource = this.prikazBindingSource;
            this.dgvPrikaz.Location = new System.Drawing.Point(0, 44);
            this.dgvPrikaz.Name = "dgvPrikaz";
            this.dgvPrikaz.Size = new System.Drawing.Size(618, 220);
            this.dgvPrikaz.TabIndex = 5;
            this.dgvPrikaz.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPrikaz_CellBeginEdit);
            this.dgvPrikaz.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvPrikaz_RowValidating);
            // 
            // prikazNameDataGridViewTextBoxColumn
            // 
            this.prikazNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prikazNameDataGridViewTextBoxColumn.DataPropertyName = "PrikazName";
            this.prikazNameDataGridViewTextBoxColumn.HeaderText = "Номер приказа";
            this.prikazNameDataGridViewTextBoxColumn.Name = "prikazNameDataGridViewTextBoxColumn";
            this.prikazNameDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // dateBeginDataGridViewTextBoxColumn
            // 
            this.dateBeginDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dateBeginDataGridViewTextBoxColumn.DataPropertyName = "DateBegin";
            this.dateBeginDataGridViewTextBoxColumn.HeaderText = "Дата создания";
            this.dateBeginDataGridViewTextBoxColumn.Name = "dateBeginDataGridViewTextBoxColumn";
            this.dateBeginDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dateBeginDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // datePrikazDataGridViewTextBoxColumn
            // 
            this.datePrikazDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.datePrikazDataGridViewTextBoxColumn.DataPropertyName = "DatePrikaz";
            this.datePrikazDataGridViewTextBoxColumn.HeaderText = "Дата вступления в силу";
            this.datePrikazDataGridViewTextBoxColumn.Name = "datePrikazDataGridViewTextBoxColumn";
            this.datePrikazDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.datePrikazDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.datePrikazDataGridViewTextBoxColumn.Width = 120;
            // 
            // prikazBindingSource
            // 
            this.prikazBindingSource.DataSource = typeof(Kadr.Data.Prikaz);
            // 
            // btnPrikazType
            // 
            this.btnPrikazType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPrikazType.Location = new System.Drawing.Point(278, 15);
            this.btnPrikazType.Name = "btnPrikazType";
            this.btnPrikazType.Size = new System.Drawing.Size(181, 23);
            this.btnPrikazType.TabIndex = 14;
            this.btnPrikazType.Text = "Виды приказов";
            this.btnPrikazType.UseVisualStyleBackColor = true;
            this.btnPrikazType.Click += new System.EventHandler(this.btnPrikazType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(6, 1);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Вид приказа";
            // 
            // cbPrikazType
            // 
            this.cbPrikazType.DataSource = this.prikazTypeBindingSource;
            this.cbPrikazType.DisplayMember = "PrikazTypeName";
            this.cbPrikazType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrikazType.FormattingEnabled = true;
            this.cbPrikazType.Location = new System.Drawing.Point(3, 17);
            this.cbPrikazType.Name = "cbPrikazType";
            this.cbPrikazType.Size = new System.Drawing.Size(239, 21);
            this.cbPrikazType.TabIndex = 12;
            this.cbPrikazType.ValueMember = "id";
            this.cbPrikazType.SelectedValueChanged += new System.EventHandler(this.cbPrikazType_SelectedValueChanged);
            // 
            // prikazTypeBindingSource
            // 
            this.prikazTypeBindingSource.DataSource = typeof(Kadr.Data.PrikazType);
            // 
            // PrikazDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(643, 342);
            this.Name = "PrikazDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Приказы";
            this.Load += new System.EventHandler(this.PrikazDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrikaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvPrikaz;
        private System.Windows.Forms.BindingSource prikazBindingSource;
        private System.Windows.Forms.Button btnPrikazType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPrikazType;
        private System.Windows.Forms.BindingSource prikazTypeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikazNameDataGridViewTextBoxColumn;
        private Kadr.UI.Common.DataGridViewDateTimeColumn dateBeginDataGridViewTextBoxColumn;
        private Kadr.UI.Common.DataGridViewDateTimeColumn datePrikazDataGridViewTextBoxColumn;
    }
}