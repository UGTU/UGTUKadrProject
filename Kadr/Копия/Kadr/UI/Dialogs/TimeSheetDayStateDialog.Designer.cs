namespace Kadr.UI.Dialogs
{
    partial class TimeSheetDayStateDialog
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
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.timeSheetDayStateBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.DayStateName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DayStateShortName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IsRequired = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSheetDayStateBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dataGridView2);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Controls.SetChildIndex(this.dataGridView2, 0);
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
            // dataGridView2
            // 
            this.dataGridView2.AutoGenerateColumns = false;
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.DayStateName,
            this.DayStateShortName,
            this.IsRequired});
            this.dataGridView2.DataSource = this.timeSheetDayStateBindingSource;
            this.dataGridView2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView2.Location = new System.Drawing.Point(0, 0);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.Size = new System.Drawing.Size(550, 185);
            this.dataGridView2.TabIndex = 6;
            this.dataGridView2.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView2_CellBeginEdit);
            // 
            // timeSheetDayStateBindingSource
            // 
            this.timeSheetDayStateBindingSource.DataSource = typeof(Kadr.Data.TimeSheetDayState);
            // 
            // DayStateName
            // 
            this.DayStateName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.DayStateName.DataPropertyName = "DayStateName";
            this.DayStateName.HeaderText = "Название статуса дня";
            this.DayStateName.Name = "DayStateName";
            // 
            // DayStateShortName
            // 
            this.DayStateShortName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.DayStateShortName.DataPropertyName = "DayStateShortName";
            this.DayStateShortName.HeaderText = "Краткое обозначение";
            this.DayStateShortName.Name = "DayStateShortName";
            this.DayStateShortName.Width = 130;
            // 
            // IsRequired
            // 
            this.IsRequired.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.IsRequired.DataPropertyName = "IsRequired";
            this.IsRequired.HeaderText = "Обязателен";
            this.IsRequired.Name = "IsRequired";
            this.IsRequired.Width = 74;
            // 
            // TimeSheetDayStateDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 263);
            this.Name = "TimeSheetDayStateDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Статус дня";
            this.Load += new System.EventHandler(this.TimeSheetDayStateDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.timeSheetDayStateBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.BindingSource timeSheetDayStateBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayStateName;
        private System.Windows.Forms.DataGridViewTextBoxColumn DayStateShortName;
        private System.Windows.Forms.DataGridViewCheckBoxColumn IsRequired;
    }
}