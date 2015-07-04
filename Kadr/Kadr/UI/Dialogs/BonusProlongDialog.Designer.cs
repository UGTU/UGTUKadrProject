namespace Kadr.UI.Dialogs
{
    partial class BonusProlongDialog
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
            this.cbBonusType = new System.Windows.Forms.ComboBox();
            this.bonusTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.cbNewPrikaz = new System.Windows.Forms.ComboBox();
            this.newPrikazBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtNewDate = new System.Windows.Forms.DateTimePicker();
            this.cbFinancingSource = new System.Windows.Forms.ComboBox();
            this.financingSourceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.chbWithFinSource = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPrikazBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.financingSourceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.chbWithFinSource);
            this.panel1.Controls.Add(this.cbNewPrikaz);
            this.panel1.Controls.Add(this.dtNewDate);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.cbFinancingSource);
            this.panel1.Controls.Add(this.cbBonusType);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(473, 152);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 167);
            this.panel2.Size = new System.Drawing.Size(473, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(381, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Click += new System.EventHandler(this.ApplyBtn_Click);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(289, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(197, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // cbBonusType
            // 
            this.cbBonusType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbBonusType.DataSource = this.bonusTypeBindingSource;
            this.cbBonusType.DisplayMember = "BonusTypeName";
            this.cbBonusType.FormattingEnabled = true;
            this.cbBonusType.Location = new System.Drawing.Point(6, 24);
            this.cbBonusType.Name = "cbBonusType";
            this.cbBonusType.Size = new System.Drawing.Size(464, 21);
            this.cbBonusType.TabIndex = 0;
            this.cbBonusType.ValueMember = "id";
            // 
            // bonusTypeBindingSource
            // 
            this.bonusTypeBindingSource.DataSource = typeof(Kadr.Data.BonusType);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Вид надбавки";
            // 
            // cbNewPrikaz
            // 
            this.cbNewPrikaz.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbNewPrikaz.DataSource = this.newPrikazBindingSource;
            this.cbNewPrikaz.FormattingEnabled = true;
            this.cbNewPrikaz.Location = new System.Drawing.Point(161, 70);
            this.cbNewPrikaz.Name = "cbNewPrikaz";
            this.cbNewPrikaz.Size = new System.Drawing.Size(308, 21);
            this.cbNewPrikaz.TabIndex = 9;
            // 
            // newPrikazBindingSource
            // 
            this.newPrikazBindingSource.DataSource = typeof(Kadr.Data.Prikaz);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 54);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(111, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Приказ о продлении";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(4, 54);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(90, 13);
            this.label5.TabIndex = 7;
            this.label5.Text = "Дата продления";
            // 
            // dtNewDate
            // 
            this.dtNewDate.Location = new System.Drawing.Point(6, 70);
            this.dtNewDate.Name = "dtNewDate";
            this.dtNewDate.Size = new System.Drawing.Size(141, 20);
            this.dtNewDate.TabIndex = 6;
            // 
            // cbFinancingSource
            // 
            this.cbFinancingSource.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cbFinancingSource.DataSource = this.financingSourceBindingSource;
            this.cbFinancingSource.FormattingEnabled = true;
            this.cbFinancingSource.Location = new System.Drawing.Point(6, 120);
            this.cbFinancingSource.Name = "cbFinancingSource";
            this.cbFinancingSource.Size = new System.Drawing.Size(463, 21);
            this.cbFinancingSource.TabIndex = 11;
            // 
            // financingSourceBindingSource
            // 
            this.financingSourceBindingSource.DataSource = typeof(Kadr.Data.FinancingSource);
            // 
            // chbWithFinSource
            // 
            this.chbWithFinSource.AutoSize = true;
            this.chbWithFinSource.Location = new System.Drawing.Point(7, 97);
            this.chbWithFinSource.Name = "chbWithFinSource";
            this.chbWithFinSource.Size = new System.Drawing.Size(247, 17);
            this.chbWithFinSource.TabIndex = 10;
            this.chbWithFinSource.Text = "Назначить всем источник финансирования";
            this.chbWithFinSource.UseVisualStyleBackColor = true;
            this.chbWithFinSource.CheckedChanged += new System.EventHandler(this.chbWithFinSource_CheckedChanged);
            // 
            // BonusProlongDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(497, 205);
            this.Name = "BonusProlongDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Продление надбавки";
            this.Load += new System.EventHandler(this.BonusProlongDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bonusTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newPrikazBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.financingSourceBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbBonusType;
        private System.Windows.Forms.ComboBox cbNewPrikaz;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtNewDate;
        private System.Windows.Forms.BindingSource newPrikazBindingSource;
        private System.Windows.Forms.BindingSource bonusTypeBindingSource;
        private System.Windows.Forms.ComboBox cbFinancingSource;
        private System.Windows.Forms.BindingSource financingSourceBindingSource;
        private System.Windows.Forms.CheckBox chbWithFinSource;
    }
}