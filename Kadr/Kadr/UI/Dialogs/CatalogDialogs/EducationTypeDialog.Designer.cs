namespace Kadr.UI.Dialogs
{
    partial class EducationTypeDialog
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
            this.EduTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dgvEducationType = new System.Windows.Forms.DataGridView();
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.eduTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EduTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEducationType)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvEducationType);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvEducationType, 0);
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
            // EduTypeBindingSource
            // 
            this.EduTypeBindingSource.DataSource = typeof(Kadr.Data.EducationType);
            // 
            // dgvEducationType
            // 
            this.dgvEducationType.AutoGenerateColumns = false;
            this.dgvEducationType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvEducationType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.eduTypeNameDataGridViewTextBoxColumn});
            this.dgvEducationType.DataSource = this.EduTypeBindingSource;
            this.dgvEducationType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvEducationType.Location = new System.Drawing.Point(0, 0);
            this.dgvEducationType.Name = "dgvEducationType";
            this.dgvEducationType.Size = new System.Drawing.Size(550, 185);
            this.dgvEducationType.TabIndex = 7;
            this.dgvEducationType.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvEducationType_CellBeginEdit);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // eduTypeNameDataGridViewTextBoxColumn
            // 
            this.eduTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.eduTypeNameDataGridViewTextBoxColumn.DataPropertyName = "EduTypeName";
            this.eduTypeNameDataGridViewTextBoxColumn.HeaderText = "Наименование типа";
            this.eduTypeNameDataGridViewTextBoxColumn.Name = "eduTypeNameDataGridViewTextBoxColumn";
            // 
            // EducationTypeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "EducationTypeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Тип образования";
            this.Load += new System.EventHandler(this.EducationTypeDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EduTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvEducationType)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource EduTypeBindingSource;
        private System.Windows.Forms.DataGridView dgvEducationType;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn eduTypeNameDataGridViewTextBoxColumn;
    }
}