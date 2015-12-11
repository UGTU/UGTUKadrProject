namespace Kadr.UI.Dialogs
{
    partial class ContractSelectionDialog
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
            this.label1 = new System.Windows.Forms.Label();
            this.tbContractName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDateBegin = new System.Windows.Forms.DateTimePicker();
            this.dtpDateContract = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.dtpDateEnd = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.pSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectListBindingSource)).BeginInit();
            this.pAdding.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(3, 6);
            // 
            // pSelection
            // 
            this.pSelection.Size = new System.Drawing.Size(556, 55);
            // 
            // pAdding
            // 
            this.pAdding.Controls.Add(this.dtpDateEnd);
            this.pAdding.Controls.Add(this.label4);
            this.pAdding.Controls.Add(this.dtpDateContract);
            this.pAdding.Controls.Add(this.label3);
            this.pAdding.Controls.Add(this.dtpDateBegin);
            this.pAdding.Controls.Add(this.label2);
            this.pAdding.Controls.Add(this.tbContractName);
            this.pAdding.Controls.Add(this.label1);
            this.pAdding.Size = new System.Drawing.Size(567, 127);
            // 
            // panel1
            // 
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(556, 65);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 83);
            this.panel2.Size = new System.Drawing.Size(556, 39);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(464, 3);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(372, 3);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(280, 3);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Номер договора:";
            // 
            // tbContractName
            // 
            this.tbContractName.Location = new System.Drawing.Point(30, 46);
            this.tbContractName.Name = "tbContractName";
            this.tbContractName.Size = new System.Drawing.Size(254, 20);
            this.tbContractName.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 80);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Дата начала действия:";
            // 
            // dtpDateBegin
            // 
            this.dtpDateBegin.CustomFormat = "dd.MM.yyyy";
            this.dtpDateBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateBegin.Location = new System.Drawing.Point(30, 99);
            this.dtpDateBegin.Name = "dtpDateBegin";
            this.dtpDateBegin.Size = new System.Drawing.Size(256, 20);
            this.dtpDateBegin.TabIndex = 3;
            // 
            // dtpDateContract
            // 
            this.dtpDateContract.CustomFormat = "dd.MM.yyyy";
            this.dtpDateContract.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateContract.Location = new System.Drawing.Point(304, 47);
            this.dtpDateContract.Name = "dtpDateContract";
            this.dtpDateContract.Size = new System.Drawing.Size(251, 20);
            this.dtpDateContract.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(301, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Дата договора:";
            // 
            // dtpDateEnd
            // 
            this.dtpDateEnd.Checked = false;
            this.dtpDateEnd.CustomFormat = "dd.MM.yyyy";
            this.dtpDateEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpDateEnd.Location = new System.Drawing.Point(304, 99);
            this.dtpDateEnd.Name = "dtpDateEnd";
            this.dtpDateEnd.ShowCheckBox = true;
            this.dtpDateEnd.Size = new System.Drawing.Size(251, 20);
            this.dtpDateEnd.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(301, 80);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(142, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Дата окончания действия:";
            // 
            // ContractSelectionDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(567, 123);
            this.Name = "ContractSelectionDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Выбор договора";
            this.Load += new System.EventHandler(this.ContractSelectionDialog_Load);
            this.pSelection.ResumeLayout(false);
            this.pSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectListBindingSource)).EndInit();
            this.pAdding.ResumeLayout(false);
            this.pAdding.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDateEnd;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DateTimePicker dtpDateContract;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DateTimePicker dtpDateBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbContractName;
    }
}