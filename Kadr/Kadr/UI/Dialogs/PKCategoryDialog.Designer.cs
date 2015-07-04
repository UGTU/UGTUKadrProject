namespace Kadr.UI.Dialogs
{
    partial class PKCategoryDialog
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.pKCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.btnPKGroup = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPKGroup = new System.Windows.Forms.ComboBox();
            this.pKGroupDecoratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.pKCategoryNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PKSubCategoryNumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pKCategoryBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pKGroupDecoratorBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnPKGroup);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cbPKGroup);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Location = new System.Drawing.Point(12, 2);
            this.helpProvider1.SetShowHelp(this.panel1, true);
            this.panel1.Size = new System.Drawing.Size(625, 293);
            this.panel1.Controls.SetChildIndex(this.dataGridView1, 0);
            this.panel1.Controls.SetChildIndex(this.cbPKGroup, 0);
            this.panel1.Controls.SetChildIndex(this.label1, 0);
            this.panel1.Controls.SetChildIndex(this.btnPKGroup, 0);
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(12, 298);
            this.panel2.Size = new System.Drawing.Size(626, 30);
            // 
            // ApplyBtn
            // 
            this.helpProvider1.SetHelpString(this.ApplyBtn, "Вносит изменения в базу данных, не закрывая окно.");
            this.ApplyBtn.Location = new System.Drawing.Point(534, 2);
            this.helpProvider1.SetShowHelp(this.ApplyBtn, true);
            // 
            // CancelBtn
            // 
            this.helpProvider1.SetHelpString(this.CancelBtn, "Отменяет все изменения с момента последноего сохранения и закрывает окно.");
            this.CancelBtn.Location = new System.Drawing.Point(442, 2);
            this.helpProvider1.SetShowHelp(this.CancelBtn, true);
            // 
            // OKBtn
            // 
            this.helpProvider1.SetHelpString(this.OKBtn, "Вносит изменения в базу данных и закрывает окно.");
            this.OKBtn.Location = new System.Drawing.Point(350, 2);
            this.helpProvider1.SetShowHelp(this.OKBtn, true);
            // 
            // HelpBtn
            // 
            this.helpProvider1.SetHelpString(this.HelpBtn, "Вызов справки по диалоговому окну");
            this.helpProvider1.SetShowHelp(this.HelpBtn, true);
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pKCategoryNumberDataGridViewTextBoxColumn,
            this.PKSubCategoryNumber});
            this.dataGridView1.DataSource = this.pKCategoryBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(0, 43);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(625, 225);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellBeginEdit += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_CellBeginEdit);
            this.dataGridView1.RowValidating += new System.Windows.Forms.DataGridViewCellCancelEventHandler(this.dataGridView1_RowValidating);
            // 
            // pKCategoryBindingSource
            // 
            this.pKCategoryBindingSource.DataSource = typeof(Kadr.Data.PKCategory);
            // 
            // btnPKGroup
            // 
            this.btnPKGroup.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.btnPKGroup.Location = new System.Drawing.Point(324, 14);
            this.btnPKGroup.Name = "btnPKGroup";
            this.btnPKGroup.Size = new System.Drawing.Size(292, 23);
            this.btnPKGroup.TabIndex = 11;
            this.btnPKGroup.Text = "Профессионально-квалификационные группы";
            this.btnPKGroup.UseVisualStyleBackColor = true;
            this.btnPKGroup.Click += new System.EventHandler(this.btnPKGroup_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(271, 13);
            this.label1.TabIndex = 10;
            this.label1.Text = "Профессинально-квалификационная группа";
            // 
            // cbPKGroup
            // 
            this.cbPKGroup.DataSource = this.pKGroupDecoratorBindingSource;
            this.cbPKGroup.DisplayMember = "GroupFullName";
            this.cbPKGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPKGroup.FormattingEnabled = true;
            this.cbPKGroup.Location = new System.Drawing.Point(0, 16);
            this.cbPKGroup.Name = "cbPKGroup";
            this.cbPKGroup.Size = new System.Drawing.Size(313, 21);
            this.cbPKGroup.TabIndex = 9;
            this.cbPKGroup.ValueMember = "id";
            this.cbPKGroup.SelectedValueChanged += new System.EventHandler(this.cbPKGroup_SelectedValueChanged);
            // 
            // pKGroupDecoratorBindingSource
            // 
            this.pKGroupDecoratorBindingSource.DataSource = typeof(Kadr.Data.PKGroupDecorator);
            // 
            // pKCategoryNumberDataGridViewTextBoxColumn
            // 
            this.pKCategoryNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pKCategoryNumberDataGridViewTextBoxColumn.DataPropertyName = "PKCategoryNumber";
            this.pKCategoryNumberDataGridViewTextBoxColumn.HeaderText = "Номер уровня";
            this.pKCategoryNumberDataGridViewTextBoxColumn.Name = "pKCategoryNumberDataGridViewTextBoxColumn";
            // 
            // PKSubCategoryNumber
            // 
            this.PKSubCategoryNumber.DataPropertyName = "PKSubCategoryNumber";
            this.PKSubCategoryNumber.HeaderText = "Номер подуровня 1";
            this.PKSubCategoryNumber.Name = "PKSubCategoryNumber";
            this.PKSubCategoryNumber.Width = 170;
            // 
            // PKCategoryDialog
            // 
            this.ApplyButtonVisible = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 336);
            this.Name = "PKCategoryDialog";
            this.helpProvider1.SetShowHelp(this, true);
            this.Text = "Профессионально-квалификационные уровни";
            this.Load += new System.EventHandler(this.PKCategoryDialog_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pKCategoryBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pKGroupDecoratorBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btnPKGroup;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbPKGroup;
        private System.Windows.Forms.BindingSource pKCategoryBindingSource;
        private System.Windows.Forms.BindingSource pKGroupDecoratorBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pKCategoryNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PKSubCategoryNumber;
    }
}