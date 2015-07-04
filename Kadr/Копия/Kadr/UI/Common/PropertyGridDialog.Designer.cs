namespace Kadr.UI.Common
{
    partial class PropertyGridDialog
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
            this.commandProperyGrid1 = new UIX.UI.CommandPropertyGrid();
            this.btnPrikaz = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.commandProperyGrid1);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(576, 453);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnPrikaz);
            this.panel2.Location = new System.Drawing.Point(12, 468);
            this.panel2.Size = new System.Drawing.Size(576, 30);
            this.panel2.Controls.SetChildIndex(this.CancelBtn, 0);
            this.panel2.Controls.SetChildIndex(this.OKBtn, 0);
            this.panel2.Controls.SetChildIndex(this.ApplyBtn, 0);
            this.panel2.Controls.SetChildIndex(this.HelpBtn, 0);
            this.panel2.Controls.SetChildIndex(this.btnPrikaz, 0);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(387, 0);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Size = new System.Drawing.Size(92, 30);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(481, 0);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            this.CancelBtn.Size = new System.Drawing.Size(92, 30);
            // 
            // OKBtn
            // 
            this.OKBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)));
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(297, 0);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            this.OKBtn.Size = new System.Drawing.Size(89, 30);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.HelpBtn.Location = new System.Drawing.Point(3, 0);
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            this.HelpBtn.Size = new System.Drawing.Size(89, 29);
            // 
            // commandProperyGrid1
            // 
            this.commandProperyGrid1.CommandRegister = null;
            this.commandProperyGrid1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.commandProperyGrid1.Location = new System.Drawing.Point(0, 0);
            this.commandProperyGrid1.Name = "commandProperyGrid1";
            this.commandProperyGrid1.Size = new System.Drawing.Size(576, 453);
            this.commandProperyGrid1.TabIndex = 0;
            this.commandProperyGrid1.PropertyValueChanged += new System.Windows.Forms.PropertyValueChangedEventHandler(this.commandProperyGrid1_PropertyValueChanged);
            // 
            // btnPrikaz
            // 
            this.btnPrikaz.Location = new System.Drawing.Point(95, 0);
            this.btnPrikaz.Name = "btnPrikaz";
            this.btnPrikaz.Size = new System.Drawing.Size(74, 29);
            this.btnPrikaz.TabIndex = 9;
            this.btnPrikaz.Text = "Приказы";
            this.btnPrikaz.UseVisualStyleBackColor = true;
            this.btnPrikaz.Visible = false;
            // 
            // PropertyGridDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(600, 506);
            this.Name = "PropertyGridDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Редактор свойств объекта";
            this.Load += new System.EventHandler(this.PropertyGridDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        protected UIX.UI.CommandPropertyGrid commandProperyGrid1;
        protected System.Windows.Forms.Button btnPrikaz;

    }
}
