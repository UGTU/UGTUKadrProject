﻿namespace Kadr.UI.Common
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
        protected void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnClearSelection = new System.Windows.Forms.Button();
            this.pSelection = new System.Windows.Forms.Panel();
            this.bAddingMode = new System.Windows.Forms.Button();
            this.cbObjectList = new System.Windows.Forms.ComboBox();
            this.ObjectListBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.lObjectTypeName = new System.Windows.Forms.Label();
            this.pAdding = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.pSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectListBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.pSelection);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(542, 60);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnClearSelection);
            this.panel2.Location = new System.Drawing.Point(12, 75);
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
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(450, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(358, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            this.OKBtn.Text = "OK";
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            this.HelpBtn.Visible = false;
            // 
            // btnClearSelection
            // 
            this.btnClearSelection.Location = new System.Drawing.Point(3, 4);
            this.btnClearSelection.Name = "btnClearSelection";
            this.btnClearSelection.Size = new System.Drawing.Size(133, 23);
            this.btnClearSelection.TabIndex = 9;
            this.btnClearSelection.Text = "Очистить значение";
            this.btnClearSelection.UseVisualStyleBackColor = true;
            this.btnClearSelection.Click += new System.EventHandler(this.btnClearSelection_Click);
            // 
            // pSelection
            // 
            this.pSelection.Controls.Add(this.bAddingMode);
            this.pSelection.Controls.Add(this.cbObjectList);
            this.pSelection.Controls.Add(this.lObjectTypeName);
            this.pSelection.Dock = System.Windows.Forms.DockStyle.Top;
            this.pSelection.Location = new System.Drawing.Point(0, 0);
            this.pSelection.Name = "pSelection";
            this.pSelection.Size = new System.Drawing.Size(542, 55);
            this.pSelection.TabIndex = 20;
            // 
            // bAddingMode
            // 
            this.bAddingMode.ForeColor = System.Drawing.SystemColors.ControlText;
            this.bAddingMode.Image = global::Kadr.Properties.Resources.add_icon1;
            this.bAddingMode.Location = new System.Drawing.Point(503, 16);
            this.bAddingMode.Name = "bAddingMode";
            this.bAddingMode.Size = new System.Drawing.Size(35, 32);
            this.bAddingMode.TabIndex = 6;
            this.bAddingMode.UseVisualStyleBackColor = true;
            this.bAddingMode.Click += new System.EventHandler(this.bAddingMode_Click);
            // 
            // cbObjectList
            // 
            this.cbObjectList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Append;
            this.cbObjectList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbObjectList.DataSource = this.ObjectListBindingSource;
            this.cbObjectList.FormattingEnabled = true;
            this.cbObjectList.Location = new System.Drawing.Point(3, 23);
            this.cbObjectList.Name = "cbObjectList";
            this.cbObjectList.Size = new System.Drawing.Size(495, 21);
            this.cbObjectList.TabIndex = 4;
            this.cbObjectList.SelectedIndexChanged += new System.EventHandler(this.cbObjectList_SelectedIndexChanged);
            // 
            // ObjectListBindingSource
            // 
            this.ObjectListBindingSource.DataSource = typeof(Kadr.Data.Contract);
            // 
            // lObjectTypeName
            // 
            this.lObjectTypeName.AutoSize = true;
            this.lObjectTypeName.Location = new System.Drawing.Point(12, 3);
            this.lObjectTypeName.Name = "lObjectTypeName";
            this.lObjectTypeName.Size = new System.Drawing.Size(48, 13);
            this.lObjectTypeName.TabIndex = 5;
            this.lObjectTypeName.Text = "Объект:";
            // 
            // pAdding
            // 
            this.pAdding.Dock = System.Windows.Forms.DockStyle.Top;
            this.pAdding.Location = new System.Drawing.Point(0, 0);
            this.pAdding.Name = "pAdding";
            this.pAdding.Size = new System.Drawing.Size(566, 127);
            this.pAdding.TabIndex = 18;
            this.pAdding.Visible = false;
            // 
            // BaseSelectionDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(566, 113);
            this.Controls.Add(this.pAdding);
            this.Name = "BaseSelectionDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "BaseSelectionDialog";
            this.Load += new System.EventHandler(this.BaseSelectionDialog_Load);
            this.Controls.SetChildIndex(this.panel1, 0);
            this.Controls.SetChildIndex(this.panel2, 0);
            this.Controls.SetChildIndex(this.pAdding, 0);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.pSelection.ResumeLayout(false);
            this.pSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ObjectListBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.Button btnClearSelection;
        public System.Windows.Forms.Panel pSelection;
        public System.Windows.Forms.Button bAddingMode;
        public System.Windows.Forms.ComboBox cbObjectList;
        public System.Windows.Forms.Label lObjectTypeName;
        public System.Windows.Forms.BindingSource ObjectListBindingSource;
        public System.Windows.Forms.Panel pAdding;
    }
}