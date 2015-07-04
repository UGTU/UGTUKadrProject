namespace Kadr.UI.Dialogs
{
    partial class FactStaffTransfer
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
            this.cbNewPlanStaff = new System.Windows.Forms.ComboBox();
            this.planStaffBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.prikazBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.dtTransferDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cbTransferPrikaz = new System.Windows.Forms.ComboBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planStaffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cbTransferPrikaz);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtTransferDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbNewPlanStaff);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(465, 113);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 128);
            this.panel2.Size = new System.Drawing.Size(465, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(189, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(281, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(373, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // cbNewPlanStaff
            // 
            this.cbNewPlanStaff.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNewPlanStaff.DataSource = this.planStaffBindingSource;
            this.cbNewPlanStaff.FormattingEnabled = true;
            this.cbNewPlanStaff.Location = new System.Drawing.Point(6, 25);
            this.cbNewPlanStaff.Name = "cbNewPlanStaff";
            this.cbNewPlanStaff.Size = new System.Drawing.Size(456, 21);
            this.cbNewPlanStaff.TabIndex = 0;
            // 
            // planStaffBindingSource
            // 
            this.planStaffBindingSource.DataSource = typeof(Kadr.Data.PlanStaff);
            // 
            // prikazBindingSource
            // 
            this.prikazBindingSource.DataSource = typeof(Kadr.Data.Prikaz);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Запись штатного расписания";
            // 
            // dtTransferDate
            // 
            this.dtTransferDate.Location = new System.Drawing.Point(6, 78);
            this.dtTransferDate.Name = "dtTransferDate";
            this.dtTransferDate.Size = new System.Drawing.Size(136, 20);
            this.dtTransferDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата перевода";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 59);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Приказ о переводе";
            // 
            // cbTransferPrikaz
            // 
            this.cbTransferPrikaz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbTransferPrikaz.DataSource = this.prikazBindingSource;
            this.cbTransferPrikaz.FormattingEnabled = true;
            this.cbTransferPrikaz.Location = new System.Drawing.Point(164, 76);
            this.cbTransferPrikaz.Name = "cbTransferPrikaz";
            this.cbTransferPrikaz.Size = new System.Drawing.Size(298, 21);
            this.cbTransferPrikaz.TabIndex = 5;
            // 
            // FactStaffTransfer
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 166);
            this.Name = "FactStaffTransfer";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Перевод сотрудников";
            this.Load += new System.EventHandler(this.FactStaffTransfer_Load);
            this.Shown += new System.EventHandler(this.FactStaffTransfer_Shown);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.planStaffBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox cbNewPlanStaff;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbTransferPrikaz;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtTransferDate;
        private System.Windows.Forms.BindingSource prikazBindingSource;
        private System.Windows.Forms.BindingSource planStaffBindingSource;
    }
}