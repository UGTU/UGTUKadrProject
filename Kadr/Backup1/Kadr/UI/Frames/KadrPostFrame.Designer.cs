namespace Kadr.UI.Frames
{
    partial class KadrPostFrame
    {
        /// <summary> 
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Обязательный метод для поддержки конструктора - не изменяйте 
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tcDepartment = new System.Windows.Forms.TabControl();
            this.tpPost = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPost = new System.Windows.Forms.DataGridView();
            this.postBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddPostBtn = new System.Windows.Forms.ToolStripButton();
            this.EditPostBtn = new System.Windows.Forms.ToolStripButton();
            this.DelPostBtn = new System.Windows.Forms.ToolStripButton();
            this.tpPKCategory = new System.Windows.Forms.TabPage();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvPKCategory = new System.Windows.Forms.DataGridView();
            this.pKGroupDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pKCategoryNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PKCategorySalary = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pKCategoryBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ToolStrip2 = new System.Windows.Forms.ToolStrip();
            this.AddPKCatBtn = new System.Windows.Forms.ToolStripButton();
            this.EditPKCatBtn = new System.Windows.Forms.ToolStripButton();
            this.DelPKCatBtn = new System.Windows.Forms.ToolStripButton();
            this.AddSalaryBtn = new System.Windows.Forms.ToolStripButton();
            this.EditSalaryBtn = new System.Windows.Forms.ToolStripButton();
            this.postNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GlobalPrikaz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PKCategory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ManagerBit = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.groupBox1.SuspendLayout();
            this.tcDepartment.SuspendLayout();
            this.tpPost.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPost)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.tpPKCategory.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPKCategory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pKCategoryBindingSource)).BeginInit();
            this.ToolStrip2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tcDepartment);
            // 
            // tcDepartment
            // 
            this.tcDepartment.Controls.Add(this.tpPost);
            this.tcDepartment.Controls.Add(this.tpPKCategory);
            this.tcDepartment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tcDepartment.Location = new System.Drawing.Point(3, 16);
            this.tcDepartment.Name = "tcDepartment";
            this.tcDepartment.SelectedIndex = 0;
            this.tcDepartment.Size = new System.Drawing.Size(810, 559);
            this.tcDepartment.TabIndex = 3;
            // 
            // tpPost
            // 
            this.tpPost.Controls.Add(this.tableLayoutPanel1);
            this.tpPost.Location = new System.Drawing.Point(4, 22);
            this.tpPost.Name = "tpPost";
            this.tpPost.Padding = new System.Windows.Forms.Padding(3);
            this.tpPost.Size = new System.Drawing.Size(802, 533);
            this.tpPost.TabIndex = 1;
            this.tpPost.Text = "Должности";
            this.tpPost.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPost, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(796, 527);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dgvPost
            // 
            this.dgvPost.AllowUserToAddRows = false;
            this.dgvPost.AllowUserToDeleteRows = false;
            this.dgvPost.AutoGenerateColumns = false;
            this.dgvPost.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPost.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.postNameDataGridViewTextBoxColumn,
            this.GlobalPrikaz,
            this.PKCategory,
            this.ManagerBit});
            this.dgvPost.DataSource = this.postBindingSource;
            this.dgvPost.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPost.Location = new System.Drawing.Point(3, 29);
            this.dgvPost.Name = "dgvPost";
            this.dgvPost.ReadOnly = true;
            this.dgvPost.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPost.Size = new System.Drawing.Size(815, 495);
            this.dgvPost.TabIndex = 1;
            this.dgvPost.DoubleClick += new System.EventHandler(this.dgvPost_DoubleClick);
            // 
            // postBindingSource
            // 
            this.postBindingSource.DataSource = typeof(Kadr.Data.Post);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPostBtn,
            this.EditPostBtn,
            this.DelPostBtn});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(821, 25);
            this.toolStrip1.TabIndex = 2;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddPostBtn
            // 
            this.AddPostBtn.Image = global::Kadr.Properties.Resources.NewDocumentHS;
            this.AddPostBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddPostBtn.Name = "AddPostBtn";
            this.AddPostBtn.Size = new System.Drawing.Size(136, 22);
            this.AddPostBtn.Text = "Добавить должность";
            this.AddPostBtn.Click += new System.EventHandler(this.AddPostBtn_Click);
            // 
            // EditPostBtn
            // 
            this.EditPostBtn.Image = global::Kadr.Properties.Resources.Open;
            this.EditPostBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditPostBtn.Name = "EditPostBtn";
            this.EditPostBtn.Size = new System.Drawing.Size(106, 22);
            this.EditPostBtn.Text = "Редактировать";
            this.EditPostBtn.Click += new System.EventHandler(this.EditPostBtn_Click);
            // 
            // DelPostBtn
            // 
            this.DelPostBtn.Image = global::Kadr.Properties.Resources.DeleteHS;
            this.DelPostBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.DelPostBtn.Name = "DelPostBtn";
            this.DelPostBtn.Size = new System.Drawing.Size(71, 22);
            this.DelPostBtn.Text = "Удалить";
            this.DelPostBtn.Click += new System.EventHandler(this.DelPostBtn_Click);
            // 
            // tpPKCategory
            // 
            this.tpPKCategory.Controls.Add(this.tableLayoutPanel2);
            this.tpPKCategory.Location = new System.Drawing.Point(4, 22);
            this.tpPKCategory.Name = "tpPKCategory";
            this.tpPKCategory.Padding = new System.Windows.Forms.Padding(3);
            this.tpPKCategory.Size = new System.Drawing.Size(802, 533);
            this.tpPKCategory.TabIndex = 2;
            this.tpPKCategory.Text = "Профессиональные категории ";
            this.tpPKCategory.UseVisualStyleBackColor = true;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.dgvPKCategory, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.ToolStrip2, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(796, 527);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // dgvPKCategory
            // 
            this.dgvPKCategory.AllowUserToAddRows = false;
            this.dgvPKCategory.AllowUserToDeleteRows = false;
            this.dgvPKCategory.AutoGenerateColumns = false;
            this.dgvPKCategory.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPKCategory.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pKGroupDataGridViewTextBoxColumn,
            this.pKCategoryNumberDataGridViewTextBoxColumn,
            this.PKCategorySalary});
            this.dgvPKCategory.DataSource = this.pKCategoryBindingSource;
            this.dgvPKCategory.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPKCategory.Location = new System.Drawing.Point(3, 29);
            this.dgvPKCategory.Name = "dgvPKCategory";
            this.dgvPKCategory.ReadOnly = true;
            this.dgvPKCategory.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPKCategory.Size = new System.Drawing.Size(815, 495);
            this.dgvPKCategory.TabIndex = 1;
            this.dgvPKCategory.DoubleClick += new System.EventHandler(this.dgvPKCategory_DoubleClick);
            // 
            // pKGroupDataGridViewTextBoxColumn
            // 
            this.pKGroupDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.pKGroupDataGridViewTextBoxColumn.DataPropertyName = "PKGroup";
            this.pKGroupDataGridViewTextBoxColumn.FillWeight = 200F;
            this.pKGroupDataGridViewTextBoxColumn.HeaderText = "Профессиональная группа";
            this.pKGroupDataGridViewTextBoxColumn.Name = "pKGroupDataGridViewTextBoxColumn";
            this.pKGroupDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pKCategoryNumberDataGridViewTextBoxColumn
            // 
            this.pKCategoryNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.pKCategoryNumberDataGridViewTextBoxColumn.DataPropertyName = "PKCategoryNumber";
            this.pKCategoryNumberDataGridViewTextBoxColumn.FillWeight = 200F;
            this.pKCategoryNumberDataGridViewTextBoxColumn.HeaderText = "Номер категории";
            this.pKCategoryNumberDataGridViewTextBoxColumn.Name = "pKCategoryNumberDataGridViewTextBoxColumn";
            this.pKCategoryNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.pKCategoryNumberDataGridViewTextBoxColumn.Width = 200;
            // 
            // PKCategorySalary
            // 
            this.PKCategorySalary.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.PKCategorySalary.DataPropertyName = "PKCategorySalary";
            this.PKCategorySalary.HeaderText = "Размер оклада";
            this.PKCategorySalary.Name = "PKCategorySalary";
            this.PKCategorySalary.ReadOnly = true;
            this.PKCategorySalary.Width = 200;
            // 
            // pKCategoryBindingSource
            // 
            this.pKCategoryBindingSource.DataSource = typeof(Kadr.Data.PKCategory);
            // 
            // ToolStrip2
            // 
            this.ToolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPKCatBtn,
            this.EditPKCatBtn,
            this.DelPKCatBtn,
            this.AddSalaryBtn,
            this.EditSalaryBtn});
            this.ToolStrip2.Location = new System.Drawing.Point(0, 0);
            this.ToolStrip2.Name = "ToolStrip2";
            this.ToolStrip2.Size = new System.Drawing.Size(821, 25);
            this.ToolStrip2.TabIndex = 2;
            this.ToolStrip2.Text = "toolStrip2";
            // 
            // AddPKCatBtn
            // 
            this.AddPKCatBtn.Image = global::Kadr.Properties.Resources.NewDocumentHS;
            this.AddPKCatBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddPKCatBtn.Name = "AddPKCatBtn";
            this.AddPKCatBtn.Size = new System.Drawing.Size(136, 22);
            this.AddPKCatBtn.Text = "Добавить категорию";
            this.AddPKCatBtn.Click += new System.EventHandler(this.AddPKCatBtn_Click);
            // 
            // EditPKCatBtn
            // 
            this.EditPKCatBtn.Image = global::Kadr.Properties.Resources.Open;
            this.EditPKCatBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.EditPKCatBtn.Name = "EditPKCatBtn";
            this.EditPKCatBtn.Size = new System.Drawing.Size(165, 22);
            this.EditPKCatBtn.Text = "Редактировать категорию";
            this.EditPKCatBtn.Click += new System.EventHandler(this.EditPKCatBtn_Click);
            // 
            // DelPKCatBtn
            // 
            this.DelPKCatBtn.Image = global::Kadr.Properties.Resources.DeleteHS;
            this.DelPKCatBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.DelPKCatBtn.Name = "DelPKCatBtn";
            this.DelPKCatBtn.Size = new System.Drawing.Size(130, 22);
            this.DelPKCatBtn.Text = "Удалить категорию";
            this.DelPKCatBtn.Click += new System.EventHandler(this.DelPKCatBtn_Click);
            // 
            // AddSalaryBtn
            // 
            this.AddSalaryBtn.Image = global::Kadr.Properties.Resources.AddToFavoritesHS;
            this.AddSalaryBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddSalaryBtn.Name = "AddSalaryBtn";
            this.AddSalaryBtn.Size = new System.Drawing.Size(115, 22);
            this.AddSalaryBtn.Text = "Назначить оклад";
            this.AddSalaryBtn.Click += new System.EventHandler(this.AddSalaryBtn_Click);
            // 
            // EditSalaryBtn
            // 
            this.EditSalaryBtn.Image = global::Kadr.Properties.Resources.EditInformationHS;
            this.EditSalaryBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditSalaryBtn.Name = "EditSalaryBtn";
            this.EditSalaryBtn.Size = new System.Drawing.Size(140, 22);
            this.EditSalaryBtn.Text = "Редактировать оклад";
            this.EditSalaryBtn.Click += new System.EventHandler(this.EditSalaryBtn_Click);
            // 
            // postNameDataGridViewTextBoxColumn
            // 
            this.postNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.postNameDataGridViewTextBoxColumn.DataPropertyName = "PostName";
            this.postNameDataGridViewTextBoxColumn.HeaderText = "Должность";
            this.postNameDataGridViewTextBoxColumn.MinimumWidth = 350;
            this.postNameDataGridViewTextBoxColumn.Name = "postNameDataGridViewTextBoxColumn";
            this.postNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // GlobalPrikaz
            // 
            this.GlobalPrikaz.DataPropertyName = "GlobalPrikaz";
            this.GlobalPrikaz.HeaderText = "Приказ министерства";
            this.GlobalPrikaz.Name = "GlobalPrikaz";
            this.GlobalPrikaz.ReadOnly = true;
            // 
            // PKCategory
            // 
            this.PKCategory.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.PKCategory.DataPropertyName = "PKCategory";
            this.PKCategory.HeaderText = "Профессиональная категория";
            this.PKCategory.Name = "PKCategory";
            this.PKCategory.ReadOnly = true;
            this.PKCategory.Width = 170;
            // 
            // ManagerBit
            // 
            this.ManagerBit.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.ManagerBit.DataPropertyName = "ManagerBit";
            this.ManagerBit.HeaderText = "Руководитель";
            this.ManagerBit.Name = "ManagerBit";
            this.ManagerBit.ReadOnly = true;
            this.ManagerBit.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.ManagerBit.Width = 103;
            // 
            // KadrPostFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "KadrPostFrame";
            this.groupBox1.ResumeLayout(false);
            this.tcDepartment.ResumeLayout(false);
            this.tpPost.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPost)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.postBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.tpPKCategory.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPKCategory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pKCategoryBindingSource)).EndInit();
            this.ToolStrip2.ResumeLayout(false);
            this.ToolStrip2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tcDepartment;
        private System.Windows.Forms.TabPage tpPost;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.DataGridView dgvPost;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddPostBtn;
        private System.Windows.Forms.ToolStripButton EditPostBtn;
        private System.Windows.Forms.ToolStripButton DelPostBtn;
        private System.Windows.Forms.TabPage tpPKCategory;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvPKCategory;
        private System.Windows.Forms.ToolStrip ToolStrip2;
        private System.Windows.Forms.ToolStripButton AddPKCatBtn;
        private System.Windows.Forms.ToolStripButton EditPKCatBtn;
        private System.Windows.Forms.ToolStripButton DelPKCatBtn;
        private System.Windows.Forms.ToolStripButton AddSalaryBtn;
        private System.Windows.Forms.ToolStripButton EditSalaryBtn;
        private System.Windows.Forms.BindingSource pKCategoryBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn pKGroupDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pKCategoryNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn PKCategorySalary;
        private System.Windows.Forms.BindingSource postBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn postNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn GlobalPrikaz;
        private System.Windows.Forms.DataGridViewTextBoxColumn PKCategory;
        private System.Windows.Forms.DataGridViewCheckBoxColumn ManagerBit;
    }
}
