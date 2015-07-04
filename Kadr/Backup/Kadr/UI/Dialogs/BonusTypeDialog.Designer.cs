namespace Kadr.UI.Dialogs
{
    partial class BonusTypeDialog
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
            this.dgvBonusType = new System.Windows.Forms.DataGridView();
            this.BonusTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonusTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.idBonusSuperTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonusSuperTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonusTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cbBonusSuperType = new System.Windows.Forms.ComboBox();
            this.bonusSuperTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.btnBonusSuperType = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusSuperTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnBonusSuperType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbBonusSuperType);
            this.panel1.Controls.Add(this.dgvBonusType);
            this.panel1.Location = new System.Drawing.Point(12, 3);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(547, 217);
            this.panel1.Controls.SetChildIndex(this.dgvBonusType, 0);
            this.panel1.Controls.SetChildIndex(this.cbBonusSuperType, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnBonusSuperType, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 223);
            this.panel2.Size = new System.Drawing.Size(548, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(456, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(364, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(272, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dgvBonusType
            // 
            this.dgvBonusType.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvBonusType.AutoGenerateColumns = false;
            this.dgvBonusType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonusType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BonusTypeName,
            this.idDataGridViewTextBoxColumn,
            this.bonusTypeNameDataGridViewTextBoxColumn,
            this.idBonusSuperTypeDataGridViewTextBoxColumn,
            this.bonusSuperTypeDataGridViewTextBoxColumn});
            this.dgvBonusType.DataSource = this.bonusTypeBindingSource;
            this.dgvBonusType.Location = new System.Drawing.Point(0, 43);
            this.dgvBonusType.Name = "dgvBonusType";
            this.dgvBonusType.Size = new System.Drawing.Size(547, 149);
            this.dgvBonusType.TabIndex = 5;
            this.dgvBonusType.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBonusType_CellBeginEdit);
            this.dgvBonusType.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBonusType_RowValidating);
            // 
            // BonusTypeName
            // 
            this.BonusTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.BonusTypeName.DataPropertyName = "BonusTypeName";
            this.BonusTypeName.HeaderText = "Вид надбавки";
            this.BonusTypeName.Name = "BonusTypeName";
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // bonusTypeNameDataGridViewTextBoxColumn
            // 
            this.bonusTypeNameDataGridViewTextBoxColumn.DataPropertyName = "BonusTypeName";
            this.bonusTypeNameDataGridViewTextBoxColumn.HeaderText = "BonusTypeName";
            this.bonusTypeNameDataGridViewTextBoxColumn.Name = "bonusTypeNameDataGridViewTextBoxColumn";
            this.bonusTypeNameDataGridViewTextBoxColumn.Visible = false;
            // 
            // idBonusSuperTypeDataGridViewTextBoxColumn
            // 
            this.idBonusSuperTypeDataGridViewTextBoxColumn.DataPropertyName = "idBonusSuperType";
            this.idBonusSuperTypeDataGridViewTextBoxColumn.HeaderText = "idBonusSuperType";
            this.idBonusSuperTypeDataGridViewTextBoxColumn.Name = "idBonusSuperTypeDataGridViewTextBoxColumn";
            this.idBonusSuperTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // bonusSuperTypeDataGridViewTextBoxColumn
            // 
            this.bonusSuperTypeDataGridViewTextBoxColumn.DataPropertyName = "BonusSuperType";
            this.bonusSuperTypeDataGridViewTextBoxColumn.HeaderText = "BonusSuperType";
            this.bonusSuperTypeDataGridViewTextBoxColumn.Name = "bonusSuperTypeDataGridViewTextBoxColumn";
            this.bonusSuperTypeDataGridViewTextBoxColumn.Visible = false;
            // 
            // bonusTypeBindingSource
            // 
            this.bonusTypeBindingSource.DataSource = typeof(Kadr.Data.BonusType);
            // 
            // cbBonusSuperType
            // 
            this.cbBonusSuperType.DataSource = this.bonusSuperTypeBindingSource;
            this.cbBonusSuperType.DisplayMember = "BonusSuperTypeName";
            this.cbBonusSuperType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBonusSuperType.Location = new System.Drawing.Point(0, 16);
            this.cbBonusSuperType.Name = "cbBonusSuperType";
            this.cbBonusSuperType.Size = new System.Drawing.Size(239, 21);
            this.cbBonusSuperType.TabIndex = 6;
            this.cbBonusSuperType.ValueMember = "id";
            this.cbBonusSuperType.SelectedValueChanged += new System.EventHandler(this.cbBonusSuperType_SelectedValueChanged);
            // 
            // bonusSuperTypeBindingSource
            // 
            this.bonusSuperTypeBindingSource.DataSource = typeof(Kadr.Data.BonusSuperType);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(89, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Тип надбавки";
            // 
            // btnBonusSuperType
            // 
            this.btnBonusSuperType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnBonusSuperType.Location = new System.Drawing.Point(275, 14);
            this.btnBonusSuperType.Name = "btnBonusSuperType";
            this.btnBonusSuperType.Size = new System.Drawing.Size(181, 23);
            this.btnBonusSuperType.TabIndex = 8;
            this.btnBonusSuperType.Text = "Типы надбавок";
            this.btnBonusSuperType.UseVisualStyleBackColor = true;
            this.btnBonusSuperType.Click += new System.EventHandler(this.btnBonusSuperType_Click);
            // 
            // BonusTypeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 261);
            this.Name = "BonusTypeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Виды надбавок";
            this.Load += new System.EventHandler(this.BonusTypeDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusSuperTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBonusType;
        private System.Windows.Forms.BindingSource bonusTypeBindingSource;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource bonusSuperTypeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn BonusTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonusTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn idBonusSuperTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonusSuperTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnBonusSuperType;
        private System.Windows.Forms.ComboBox cbBonusSuperType;
    }
}