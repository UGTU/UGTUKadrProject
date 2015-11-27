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
            this.components = new System.ComponentModel.Container();
            this.pSelection = new System.Windows.Forms.Panel();
            this.bAddingMode = new System.Windows.Forms.Button();
            this.cbPrikaz = new System.Windows.Forms.ComboBox();
            this.contractBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label3 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pSelection);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(493, 58);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 72);
            this.panel2.Size = new System.Drawing.Size(508, 52);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(399, 4);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(307, 4);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(215, 4);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // pSelection
            // 
            this.pSelection.Controls.Add(this.bAddingMode);
            this.pSelection.Controls.Add(this.cbPrikaz);
            this.pSelection.Controls.Add(this.label3);
            this.pSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSelection.Location = new System.Drawing.Point(0, 0);
            this.pSelection.Name = "pSelection";
            this.pSelection.Size = new System.Drawing.Size(493, 55);
            this.pSelection.TabIndex = 19;
            // 
            // bAddingMode
            // 
            this.bAddingMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bAddingMode.Image = global::Kadr.Properties.Resources.add_icon1;
            this.bAddingMode.Location = new System.Drawing.Point(439, 12);
            this.bAddingMode.Name = "bAddingMode";
            this.bAddingMode.Size = new System.Drawing.Size(35, 32);
            this.bAddingMode.TabIndex = 6;
            this.bAddingMode.UseVisualStyleBackColor = true;
            // 
            // cbPrikaz
            // 
            this.cbPrikaz.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbPrikaz.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbPrikaz.DataSource = this.contractBindingSource;
            this.cbPrikaz.FormattingEnabled = true;
            this.cbPrikaz.Location = new System.Drawing.Point(15, 19);
            this.cbPrikaz.Name = "cbPrikaz";
            this.cbPrikaz.Size = new System.Drawing.Size(418, 21);
            this.cbPrikaz.TabIndex = 4;
            // 
            // contractBindingSource
            // 
            this.contractBindingSource.DataSource = typeof(Kadr.Data.Contract);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Договор:";
            // 
            // ContractSelectionDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 103);
            this.Name = "ContractSelectionDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "ContractSelectionDialog";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pSelection.ResumeLayout(false);
            this.pSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.contractBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pSelection;
        private System.Windows.Forms.Button bAddingMode;
        private System.Windows.Forms.ComboBox cbPrikaz;
        private System.Windows.Forms.BindingSource contractBindingSource;
        private System.Windows.Forms.Label label3;
    }
}