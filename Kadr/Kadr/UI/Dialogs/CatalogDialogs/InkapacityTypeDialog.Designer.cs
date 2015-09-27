namespace Kadr.UI.Dialogs
{
    partial class InkapacityTypeDialog
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
            this.InkapacityTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvInkapacityType = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameInkapacityTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InkapacityTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInkapacityType)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvInkapacityType);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvInkapacityType, 0);
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
            // InkapacityTypeBindingSource
            // 
            this.InkapacityTypeBindingSource.DataSource = typeof(Kadr.Data.InkapacityType);
            // 
            // dgvInkapacityType
            // 
            this.dgvInkapacityType.AutoGenerateColumns = false;
            this.dgvInkapacityType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvInkapacityType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.nameInkapacityTypeDataGridViewTextBoxColumn});
            this.dgvInkapacityType.DataSource = this.InkapacityTypeBindingSource;
            this.dgvInkapacityType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvInkapacityType.Location = new System.Drawing.Point(0, 0);
            this.dgvInkapacityType.Name = "dgvInkapacityType";
            this.dgvInkapacityType.Size = new System.Drawing.Size(550, 185);
            this.dgvInkapacityType.TabIndex = 5;
            this.dgvInkapacityType.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvInkapacityType_CellBeginEdit);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // nameInkapacityTypeDataGridViewTextBoxColumn
            // 
            this.nameInkapacityTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameInkapacityTypeDataGridViewTextBoxColumn.DataPropertyName = "NameInkapacityType";
            this.nameInkapacityTypeDataGridViewTextBoxColumn.HeaderText = "Тип больничного";
            this.nameInkapacityTypeDataGridViewTextBoxColumn.Name = "nameInkapacityTypeDataGridViewTextBoxColumn";
            // 
            // InkapacityTypeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "InkapacityTypeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Тип больничного";
            this.Load += new System.EventHandler(this.InkapacityTypeDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InkapacityTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvInkapacityType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource InkapacityTypeBindingSource;
        private System.Windows.Forms.DataGridView dgvInkapacityType;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameInkapacityTypeDataGridViewTextBoxColumn;
    }
}