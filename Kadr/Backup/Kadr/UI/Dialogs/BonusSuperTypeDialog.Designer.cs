namespace Kadr.UI.Dialogs
{
    partial class BonusSuperTypeDialog
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
            this.dgvBonusSuperType = new System.Windows.Forms.DataGridView();
            this.bonusSuperTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonusSuperTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusSuperType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusSuperTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvBonusSuperType);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvBonusSuperType, 0);
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
            // dgvBonusSuperType
            // 
            this.dgvBonusSuperType.AutoGenerateColumns = false;
            this.dgvBonusSuperType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonusSuperType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bonusSuperTypeNameDataGridViewTextBoxColumn});
            this.dgvBonusSuperType.DataSource = this.bonusSuperTypeBindingSource;
            this.dgvBonusSuperType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBonusSuperType.Location = new System.Drawing.Point(0, 0);
            this.dgvBonusSuperType.Name = "dgvBonusSuperType";
            this.dgvBonusSuperType.Size = new System.Drawing.Size(550, 185);
            this.dgvBonusSuperType.TabIndex = 5;
            this.dgvBonusSuperType.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvBonusSuperType_CellBeginEdit);
            // 
            // bonusSuperTypeNameDataGridViewTextBoxColumn
            // 
            this.bonusSuperTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.bonusSuperTypeNameDataGridViewTextBoxColumn.DataPropertyName = "BonusSuperTypeName";
            this.bonusSuperTypeNameDataGridViewTextBoxColumn.HeaderText = "Тип надбавки";
            this.bonusSuperTypeNameDataGridViewTextBoxColumn.Name = "bonusSuperTypeNameDataGridViewTextBoxColumn";
            // 
            // bonusSuperTypeBindingSource
            // 
            this.bonusSuperTypeBindingSource.DataSource = typeof(Kadr.Data.BonusSuperType);
            // 
            // BonusSuperTypeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "BonusSuperTypeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Типы надбавок";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.BonusSuperTypeDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusSuperType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusSuperTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBonusSuperType;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonusSuperTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bonusSuperTypeBindingSource;
    }
}