namespace Kadr.UI.Dialogs
{
    partial class DocumentTypeDialog
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
            this.dgvDocumentType = new System.Windows.Forms.DataGridView();
            this.DocumentTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.idDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.docTypeNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isOldDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDocumentType);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dgvDocumentType, 0);
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
            // dgvDocumentType
            // 
            this.dgvDocumentType.AutoGenerateColumns = false;
            this.dgvDocumentType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDocumentType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.idDataGridViewTextBoxColumn,
            this.docTypeNameDataGridViewTextBoxColumn,
            this.isOldDataGridViewTextBoxColumn});
            this.dgvDocumentType.DataSource = this.DocumentTypeBindingSource;
            this.dgvDocumentType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDocumentType.Location = new System.Drawing.Point(0, 0);
            this.dgvDocumentType.Name = "dgvDocumentType";
            this.dgvDocumentType.Size = new System.Drawing.Size(550, 185);
            this.dgvDocumentType.TabIndex = 7;
            this.dgvDocumentType.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDocumentType_CellBeginEdit);
            // 
            // DocumentTypeBindingSource
            // 
            this.DocumentTypeBindingSource.DataSource = typeof(Kadr.Data.EducDocumentType);
            // 
            // idDataGridViewTextBoxColumn
            // 
            this.idDataGridViewTextBoxColumn.DataPropertyName = "id";
            this.idDataGridViewTextBoxColumn.HeaderText = "id";
            this.idDataGridViewTextBoxColumn.Name = "idDataGridViewTextBoxColumn";
            this.idDataGridViewTextBoxColumn.Visible = false;
            // 
            // docTypeNameDataGridViewTextBoxColumn
            // 
            this.docTypeNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.docTypeNameDataGridViewTextBoxColumn.DataPropertyName = "DocTypeName";
            this.docTypeNameDataGridViewTextBoxColumn.HeaderText = "Название вида документа";
            this.docTypeNameDataGridViewTextBoxColumn.Name = "docTypeNameDataGridViewTextBoxColumn";
            // 
            // isOldDataGridViewTextBoxColumn
            // 
            this.isOldDataGridViewTextBoxColumn.DataPropertyName = "isOld";
            this.isOldDataGridViewTextBoxColumn.FalseValue = "False";
            this.isOldDataGridViewTextBoxColumn.HeaderText = "isOld";
            this.isOldDataGridViewTextBoxColumn.IndeterminateValue = "False";
            this.isOldDataGridViewTextBoxColumn.Name = "isOldDataGridViewTextBoxColumn";
            this.isOldDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.isOldDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.isOldDataGridViewTextBoxColumn.TrueValue = "True";
            this.isOldDataGridViewTextBoxColumn.Visible = false;
            // 
            // DocumentTypeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "DocumentTypeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Виды документов";
            this.Load += new System.EventHandler(this.OrganisationDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDocumentType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DocumentTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDocumentType;
        private System.Windows.Forms.BindingSource DocumentTypeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn idDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn docTypeNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isOldDataGridViewTextBoxColumn;
    }
}