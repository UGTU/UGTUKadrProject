namespace Kadr.UI.Dialogs
{
    partial class PrikazTypeDialog
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
            this.prikazTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikazTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnBonusSuperType = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrikazSuperType = new System.Windows.Forms.ComboBox();
            this.prikazSuperTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazSuperTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBonusSuperType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbPrikazSuperType);
            this.panel1.Controls.Add(this.dataGridView1);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(611, 255);
            this.panel1.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.Controls.SetChildIndex(this.cbPrikazSuperType, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnBonusSuperType, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 270);
            this.panel2.Size = new System.Drawing.Size(612, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(520, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(428, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(336, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prikazTypeNameDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.prikazTypeBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 46);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(608, 181);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_RowValidating);
            // 
            // prikazTypeNameDataGridViewTextBoxColumn
            // 
            this.prikazTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prikazTypeNameDataGridViewTextBoxColumn.DataPropertyName = "PrikazTypeName";
            this.prikazTypeNameDataGridViewTextBoxColumn.HeaderText = "Вид приказа";
            this.prikazTypeNameDataGridViewTextBoxColumn.Name = "prikazTypeNameDataGridViewTextBoxColumn";
            // 
            // prikazTypeBindingSource
            // 
            this.prikazTypeBindingSource.DataSource = typeof(Kadr.Data.PrikazType);
            // 
            // btnBonusSuperType
            // 
            this.btnBonusSuperType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBonusSuperType.Location = new System.Drawing.Point(275, 17);
            this.btnBonusSuperType.Name = "btnBonusSuperType";
            this.btnBonusSuperType.Size = new System.Drawing.Size(181, 23);
            this.btnBonusSuperType.TabIndex = 11;
            this.btnBonusSuperType.Text = "Типы приказов";
            this.btnBonusSuperType.UseVisualStyleBackColor = true;
            this.btnBonusSuperType.Click += new System.EventHandler(this.btnBonusSuperType_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Тип приказа";
            // 
            // cbPrikazSuperType
            // 
            this.cbPrikazSuperType.DataSource = this.prikazSuperTypeBindingSource;
            this.cbPrikazSuperType.DisplayMember = "PrikazSuperTypeName";
            this.cbPrikazSuperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrikazSuperType.FormattingEnabled = true;
            this.cbPrikazSuperType.Location = new System.Drawing.Point(0, 19);
            this.cbPrikazSuperType.Name = "cbPrikazSuperType";
            this.cbPrikazSuperType.Size = new System.Drawing.Size(239, 21);
            this.cbPrikazSuperType.TabIndex = 9;
            this.cbPrikazSuperType.ValueMember = "id";
            this.cbPrikazSuperType.SelectedValueChanged += new System.EventHandler(this.cbPrikazSuperType_SelectedValueChanged);
            // 
            // prikazSuperTypeBindingSource
            // 
            this.prikazSuperTypeBindingSource.DataSource = typeof(Kadr.Data.PrikazSuperType);
            // 
            // PrikazTypeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 308);
            this.Name = "PrikazTypeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Виды приказов";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.PrikazTypeDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazSuperTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource prikazTypeBindingSource;
        private System.Windows.Forms.Button btnBonusSuperType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPrikazSuperType;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikazTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource prikazSuperTypeBindingSource;
    }
}