namespace Kadr.UI.Dialogs
{
    partial class DopEducTypeDialog
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
            this.dgvDopEducType = new System.Windows.Forms.DataGridView();
            this.TypeDocumentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DopEducTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dopEducNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DocTypeName = new System.Windows.Forms.DataGridViewComboBoxColumn();
            this.EducDocumentType = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDopEducType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeDocumentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DopEducTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dgvDopEducType);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(746, 210);
            this.panel1.Controls.SetChildIndex(this.dgvDopEducType, 0);
            // 
            // panel2
            // 
            this.panel2.Size = new System.Drawing.Size(747, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(655, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(563, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(471, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dgvDopEducType
            // 
            this.dgvDopEducType.AutoGenerateColumns = false;
            this.dgvDopEducType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDopEducType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dopEducNameDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.DocTypeName,
            this.EducDocumentType});
            this.dgvDopEducType.DataSource = this.DopEducTypeBindingSource;
            this.dgvDopEducType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDopEducType.Location = new System.Drawing.Point(0, 0);
            this.dgvDopEducType.Name = "dgvDopEducType";
            this.dgvDopEducType.Size = new System.Drawing.Size(746, 185);
            this.dgvDopEducType.TabIndex = 7;
            this.dgvDopEducType.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dgvDopEducType_CellBeginEdit);
            // 
            // TypeDocumentBindingSource
            // 
            this.TypeDocumentBindingSource.DataSource = typeof(Kadr.Data.EducDocumentType);
            // 
            // DopEducTypeBindingSource
            // 
            this.DopEducTypeBindingSource.DataSource = typeof(Kadr.Data.DopEducTypeDecorator);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "DopEducName";
            this.dataGridViewTextBoxColumn1.HeaderText = "Тип повышения квалификации";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Duration";
            this.dataGridViewTextBoxColumn2.HeaderText = "Продолжительность, час";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 200;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "EducDocumentType";
            this.dataGridViewTextBoxColumn3.HeaderText = "EducDocumentType";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Visible = false;
            // 
            // dopEducNameDataGridViewTextBoxColumn
            // 
            this.dopEducNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dopEducNameDataGridViewTextBoxColumn.DataPropertyName = "DopEducName";
            this.dopEducNameDataGridViewTextBoxColumn.HeaderText = "Тип повышения квалификации";
            this.dopEducNameDataGridViewTextBoxColumn.Name = "dopEducNameDataGridViewTextBoxColumn";
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "Duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "Продолжительность, час";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.Width = 200;
            // 
            // DocTypeName
            // 
            this.DocTypeName.DataPropertyName = "DocTypeName";
            this.DocTypeName.DataSource = this.TypeDocumentBindingSource;
            this.DocTypeName.DisplayMember = "DocTypeName";
            this.DocTypeName.HeaderText = "Вид документа";
            this.DocTypeName.Name = "DocTypeName";
            this.DocTypeName.Width = 200;
            // 
            // EducDocumentType
            // 
            this.EducDocumentType.DataPropertyName = "EducDocumentType";
            this.EducDocumentType.HeaderText = "EducDocumentType";
            this.EducDocumentType.Name = "EducDocumentType";
            this.EducDocumentType.Visible = false;
            // 
            // DopEducTypeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(771, 263);
            this.Name = "DopEducTypeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Виды повышения квалификации";
            this.Load += new System.EventHandler(this.DopEducTypeDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDopEducType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TypeDocumentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DopEducTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource DopEducTypeBindingSource;
        private System.Windows.Forms.DataGridView dgvDopEducType;
        private System.Windows.Forms.BindingSource TypeDocumentBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dopEducNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewComboBoxColumn DocTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn EducDocumentType;
    }
}