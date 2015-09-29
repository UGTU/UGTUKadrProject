namespace Kadr.UI.Dialogs
{
    partial class DatesRangeDialog
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
            this.dBegin = new System.Windows.Forms.DateTimePicker();
            this.dEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dEnd);
            this.panel1.Controls.Add(this.dBegin);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(335, 110);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 125);
            this.panel2.Size = new System.Drawing.Size(335, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Âíîñèò èçìåíåíèÿ â áàçó äàííûõ, íå çàêðûâàÿ îêíî.");
            this.ApplyBtn.Location = new System.Drawing.Point(243, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Text = "Применить";
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Îòìåíÿåò âñå èçìåíåíèÿ ñ ìîìåíòà ïîñëåäíîåãî ñîõðàíåíèÿ è çàêðûâàåò îêíî.");
            this.CancelBtn.Location = new System.Drawing.Point(151, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            this.CancelBtn.Text = "Отмена";
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Âíîñèò èçìåíåíèÿ â áàçó äàííûõ è çàêðûâàåò îêíî.");
            this.OKBtn.Location = new System.Drawing.Point(59, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            this.OKBtn.Text = "ОК";
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Âûçîâ ñïðàâêè ïî äèàëîãîâîìó îêíó");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            this.HelpBtn.Text = "Помощь";
            // 
            // dBegin
            // 
            this.dBegin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dBegin.Location = new System.Drawing.Point(14, 26);
            this.dBegin.Name = "dBegin";
            this.dBegin.Size = new System.Drawing.Size(305, 20);
            this.dBegin.TabIndex = 0;
            // 
            // dEnd
            // 
            this.dEnd.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dEnd.Location = new System.Drawing.Point(14, 74);
            this.dEnd.Name = "dEnd";
            this.dEnd.Size = new System.Drawing.Size(305, 20);
            this.dEnd.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Дата начала ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Дата окончания";
            // 
            // DatesRangeDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(359, 163);
            this.Name = "DatesRangeDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "DatesRangeDialog";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DateTimePicker dBegin;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.DateTimePicker dEnd;
    }
}