namespace Kadr.UI.Dialogs
{
    partial class PrikazSelectionDialog
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
            this.cbSuperType = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cbType = new System.Windows.Forms.ComboBox();
            this.cbPrikaz = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.bAddingMode = new System.Windows.Forms.Button();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtBegin = new System.Windows.Forms.DateTimePicker();
            this.dtEnd = new System.Windows.Forms.DateTimePicker();
            this.dtDate = new System.Windows.Forms.DateTimePicker();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.pAdding = new System.Windows.Forms.Panel();
            this.pSelection = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.cbFilter = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pAdding.SuspendLayout();
            this.pSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pAdding);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.cbType);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbSuperType);
            this.panel1.Location = new System.Drawing.Point(12, 31);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(481, 125);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button1);
            this.panel2.Location = new System.Drawing.Point(12, 140);
            this.panel2.Size = new System.Drawing.Size(481, 30);
            this.panel2.Controls.SetChildIndex(this.OKBtn, 0);
            this.panel2.Controls.SetChildIndex(this.CancelBtn, 0);
            this.panel2.Controls.SetChildIndex(this.ApplyBtn, 0);
            this.panel2.Controls.SetChildIndex(this.HelpBtn, 0);
            this.panel2.Controls.SetChildIndex(this.button1, 0);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Âíîñèò èçìåíåíèÿ â áàçó äàííûõ, íå çàêðûâàÿ îêíî.");
            this.ApplyBtn.Location = new System.Drawing.Point(389, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Text = "Применить";
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Îòìåíÿåò âñå èçìåíåíèÿ ñ ìîìåíòà ïîñëåäíîåãî ñîõðàíåíèÿ è çàêðûâàåò îêíî.");
            this.CancelBtn.Location = new System.Drawing.Point(297, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            this.CancelBtn.Text = "Отмена";
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Âíîñèò èçìåíåíèÿ â áàçó äàííûõ è çàêðûâàåò îêíî.");
            this.OKBtn.Location = new System.Drawing.Point(205, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            this.OKBtn.Text = "OK";
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Âûçîâ ñïðàâêè ïî äèàëîãîâîìó îêíó");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            this.HelpBtn.Visible = false;
            // 
            // cbSuperType
            // 
            this.cbSuperType.FormattingEnabled = true;
            this.cbSuperType.Location = new System.Drawing.Point(15, 23);
            this.cbSuperType.Name = "cbSuperType";
            this.cbSuperType.Size = new System.Drawing.Size(255, 21);
            this.cbSuperType.TabIndex = 0;
            this.cbSuperType.SelectedIndexChanged += new System.EventHandler(this.cbSuperType_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тип приказа:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(273, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Вид приказа:";
            // 
            // cbType
            // 
            this.cbType.FormattingEnabled = true;
            this.cbType.Location = new System.Drawing.Point(276, 23);
            this.cbType.Name = "cbType";
            this.cbType.Size = new System.Drawing.Size(198, 21);
            this.cbType.TabIndex = 2;
            this.cbType.SelectedIndexChanged += new System.EventHandler(this.cbType_SelectedIndexChanged);
            // 
            // cbPrikaz
            // 
            this.cbPrikaz.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbPrikaz.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPrikaz.FormattingEnabled = true;
            this.cbPrikaz.Location = new System.Drawing.Point(0, 26);
            this.cbPrikaz.Name = "cbPrikaz";
            this.cbPrikaz.Size = new System.Drawing.Size(418, 21);
            this.cbPrikaz.TabIndex = 4;
            this.cbPrikaz.SelectedIndexChanged += new System.EventHandler(this.cbPrikaz_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(48, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Приказ:";
            // 
            // bAddingMode
            // 
            this.bAddingMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bAddingMode.Image = global::Kadr.Properties.Resources.add_icon1;
            this.bAddingMode.Location = new System.Drawing.Point(424, 19);
            this.bAddingMode.Name = "bAddingMode";
            this.bAddingMode.Size = new System.Drawing.Size(35, 32);
            this.bAddingMode.TabIndex = 6;
            this.bAddingMode.UseVisualStyleBackColor = true;
            this.bAddingMode.Click += new System.EventHandler(this.bAddingMode_Click);
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(0, 33);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(219, 20);
            this.tbName.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Номер приказа:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(237, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(121, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Дата выхода приказа:";
            // 
            // dtBegin
            // 
            this.dtBegin.Checked = false;
            this.dtBegin.CustomFormat = "dd.MM.yyyy";
            this.dtBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtBegin.Location = new System.Drawing.Point(0, 83);
            this.dtBegin.Name = "dtBegin";
            this.dtBegin.ShowCheckBox = true;
            this.dtBegin.Size = new System.Drawing.Size(219, 20);
            this.dtBegin.TabIndex = 11;
            // 
            // dtEnd
            // 
            this.dtEnd.Checked = false;
            this.dtEnd.CustomFormat = "dd.MM.yyyy";
            this.dtEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtEnd.Location = new System.Drawing.Point(240, 84);
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.ShowCheckBox = true;
            this.dtEnd.Size = new System.Drawing.Size(210, 20);
            this.dtEnd.TabIndex = 12;
            // 
            // dtDate
            // 
            this.dtDate.CustomFormat = "dd.MM.yyyy";
            this.dtDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtDate.Location = new System.Drawing.Point(240, 33);
            this.dtDate.Name = "dtDate";
            this.dtDate.Size = new System.Drawing.Size(210, 20);
            this.dtDate.TabIndex = 13;
            this.dtDate.ValueChanged += new System.EventHandler(this.dtDate_ValueChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(-3, 67);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(132, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Дата вступления в силу:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(237, 68);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(142, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Дата окончания действия:";
            // 
            // pAdding
            // 
            this.pAdding.Controls.Add(this.pSelection);
            this.pAdding.Controls.Add(this.label6);
            this.pAdding.Controls.Add(this.tbName);
            this.pAdding.Controls.Add(this.label7);
            this.pAdding.Controls.Add(this.label4);
            this.pAdding.Controls.Add(this.label5);
            this.pAdding.Controls.Add(this.dtDate);
            this.pAdding.Controls.Add(this.dtBegin);
            this.pAdding.Controls.Add(this.dtEnd);
            this.pAdding.Location = new System.Drawing.Point(15, 49);
            this.pAdding.Name = "pAdding";
            this.pAdding.Size = new System.Drawing.Size(459, 127);
            this.pAdding.TabIndex = 17;
            this.pAdding.Visible = false;
            // 
            // pSelection
            // 
            this.pSelection.Controls.Add(this.bAddingMode);
            this.pSelection.Controls.Add(this.cbPrikaz);
            this.pSelection.Controls.Add(this.label3);
            this.pSelection.Location = new System.Drawing.Point(0, 1);
            this.pSelection.Name = "pSelection";
            this.pSelection.Size = new System.Drawing.Size(459, 55);
            this.pSelection.TabIndex = 18;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(0, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(133, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "Очистить значение";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // cbFilter
            // 
            this.cbFilter.AutoSize = true;
            this.cbFilter.Checked = true;
            this.cbFilter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFilter.Location = new System.Drawing.Point(27, 8);
            this.cbFilter.Name = "cbFilter";
            this.cbFilter.Size = new System.Drawing.Size(196, 17);
            this.cbFilter.TabIndex = 7;
            this.cbFilter.Text = "Фильтровать по видам приказов";
            this.cbFilter.UseVisualStyleBackColor = true;
            this.cbFilter.CheckedChanged += new System.EventHandler(this.cbFilter_Click);
            // 
            // PrikazSelectionDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 184);
            this.Controls.Add(this.cbFilter);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "PrikazSelectionDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Выбор приказа";
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.cbFilter, 0);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.pAdding.ResumeLayout(false);
            this.pAdding.PerformLayout();
            this.pSelection.ResumeLayout(false);
            this.pSelection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbPrikaz;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbType;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbSuperType;
        private System.Windows.Forms.Button bAddingMode;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtDate;
        private System.Windows.Forms.DateTimePicker dtEnd;
        private System.Windows.Forms.DateTimePicker dtBegin;
        private System.Windows.Forms.Panel pSelection;
        private System.Windows.Forms.Panel pAdding;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.CheckBox cbFilter;
    }
}