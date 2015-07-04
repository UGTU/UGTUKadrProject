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
            this.label4 = new System.Windows.Forms.Label();
            this.cbDepartment = new System.Windows.Forms.ComboBox();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chbWithBonus = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.planStaffBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chbWithBonus);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbDepartment);
            this.panel1.Controls.Add(this.cbTransferPrikaz);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtTransferDate);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbNewPlanStaff);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(526, 175);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 190);
            this.panel2.Size = new System.Drawing.Size(526, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(434, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Visible = false;
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(342, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(250, 2);
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
            this.cbNewPlanStaff.Location = new System.Drawing.Point(6, 72);
            this.cbNewPlanStaff.Name = "cbNewPlanStaff";
            this.cbNewPlanStaff.Size = new System.Drawing.Size(517, 21);
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
            this.label1.Location = new System.Drawing.Point(3, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Запись штатного расписания";
            // 
            // dtTransferDate
            // 
            this.dtTransferDate.Location = new System.Drawing.Point(6, 125);
            this.dtTransferDate.Name = "dtTransferDate";
            this.dtTransferDate.Size = new System.Drawing.Size(136, 20);
            this.dtTransferDate.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 106);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата перевода";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(161, 106);
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
            this.cbTransferPrikaz.Location = new System.Drawing.Point(164, 123);
            this.cbTransferPrikaz.Name = "cbTransferPrikaz";
            this.cbTransferPrikaz.Size = new System.Drawing.Size(359, 21);
            this.cbTransferPrikaz.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Отдел";
            // 
            // cbDepartment
            // 
            this.cbDepartment.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.cbDepartment.DataSource = this.departmentBindingSource;
            this.cbDepartment.DisplayMember = "DepartmentName";
            this.cbDepartment.FormattingEnabled = true;
            this.cbDepartment.Location = new System.Drawing.Point(6, 25);
            this.cbDepartment.Name = "cbDepartment";
            this.cbDepartment.Size = new System.Drawing.Size(517, 21);
            this.cbDepartment.TabIndex = 6;
            this.cbDepartment.SelectedValueChanged += new System.EventHandler(this.cbDepartment_SelectedValueChanged);
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(Kadr.Data.Dep);
            // 
            // chbWithBonus
            // 
            this.chbWithBonus.AutoSize = true;
            this.chbWithBonus.Location = new System.Drawing.Point(6, 151);
            this.chbWithBonus.Name = "chbWithBonus";
            this.chbWithBonus.Size = new System.Drawing.Size(143, 17);
            this.chbWithBonus.TabIndex = 8;
            this.chbWithBonus.Text = "С переносом надбавки";
            this.chbWithBonus.UseVisualStyleBackColor = true;
            // 
            // FactStaffTransfer
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(550, 228);
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
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
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
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbDepartment;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        private System.Windows.Forms.CheckBox chbWithBonus;
    }
}