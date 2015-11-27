namespace Kadr.UI.Common
{
    partial class BaseSelectionDialog
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
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.helpProvider1.SetShowHelp(this.panel1, true);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClearSelection);
            this.panel2.Controls.SetChildIndex(this.OKBtn, 0);
            this.panel2.Controls.SetChildIndex(this.CancelBtn, 0);
            this.panel2.Controls.SetChildIndex(this.ApplyBtn, 0);
            this.panel2.Controls.SetChildIndex(this.HelpBtn, 0);
            this.panel2.Controls.SetChildIndex(this.btnClearSelection, 0);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(450, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            this.ApplyBtn.Text = "Применить";
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            this.CancelBtn.Text = "Отмена";
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(266, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            this.OKBtn.Text = "OK";
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(3, 4);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(133, 23);
            this.btnClearSelection.TabIndex = 9;
            this.btnClearSelection.Text = "Очистить значение";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            // 
            // BaseSelectionDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 262);
            this.Name = "BaseSelectionDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "BaseSelectionDialog";
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnClearSelection;
    }
}