namespace Kadr.UI.Dialogs
{
    partial class WorkTypeDialog
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
            this.workTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.typeWorkNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TypeWorkShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsMain = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.IsReplacement = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.workTypeBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView1);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dataGridView1, 0);
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
            this.typeWorkNameDataGridViewTextBoxColumn,
            this.TypeWorkShortName,
            this.IsMain,
            this.IsReplacement});
            this.dataGridView1.DataSource = this.workTypeBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(550, 185);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            // 
            // workTypeBindingSource
            // 
            this.workTypeBindingSource.DataSource = typeof(Kadr.Data.WorkType);
            // 
            // typeWorkNameDataGridViewTextBoxColumn
            // 
            this.typeWorkNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.typeWorkNameDataGridViewTextBoxColumn.DataPropertyName = "TypeWorkName";
            this.typeWorkNameDataGridViewTextBoxColumn.HeaderText = "Вид работы";
            this.typeWorkNameDataGridViewTextBoxColumn.Name = "typeWorkNameDataGridViewTextBoxColumn";
            // 
            // TypeWorkShortName
            // 
            this.TypeWorkShortName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.TypeWorkShortName.DataPropertyName = "TypeWorkShortName";
            this.TypeWorkShortName.HeaderText = "Краткое название";
            this.TypeWorkShortName.Name = "TypeWorkShortName";
            this.TypeWorkShortName.Width = 115;
            // 
            // IsMain
            // 
            this.IsMain.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsMain.DataPropertyName = "IsMain";
            this.IsMain.HeaderText = "Основная";
            this.IsMain.Name = "IsMain";
            this.IsMain.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.IsMain.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.IsMain.Width = 82;
            // 
            // IsReplacement
            // 
            this.IsReplacement.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsReplacement.DataPropertyName = "IsReplacement";
            this.IsReplacement.HeaderText = "Совмещение";
            this.IsReplacement.Name = "IsReplacement";
            this.IsReplacement.Width = 79;
            // 
            // WorkTypeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "WorkTypeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Виды работ";
            this.Load += new System.EventHandler(this.WorkTypeDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.workTypeBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource workTypeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeWorkNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn TypeWorkShortName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsMain;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsReplacement;
    }
}