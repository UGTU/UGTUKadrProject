namespace Kadr.UI.Frames
{
    partial class BonusFrame
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.bonusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvBonusFactStaff = new System.Windows.Forms.DataGridView();
            this.bonusTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastFinancingSource = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonusCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPrikazBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntermediateDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prikaz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddBonusBtn = new System.Windows.Forms.ToolStripButton();
            this.EditBonusBtn = new System.Windows.Forms.ToolStripButton();
            this.DelBonusBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnChangeBonus = new System.Windows.Forms.ToolStripButton();
            this.btnHistoryBonus = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbBonusFilter = new System.Windows.Forms.ToolStripSplitButton();
            this.текущиеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отмененныеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.btnClose = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.bonusBindingSource)).BeginInit();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusFactStaff)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // bonusBindingSource
            // 
            this.bonusBindingSource.DataSource = typeof(Kadr.Data.Bonus);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.dgvBonusFactStaff, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1006, 540);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // dgvBonusFactStaff
            // 
            this.dgvBonusFactStaff.AllowUserToAddRows = false;
            this.dgvBonusFactStaff.AllowUserToDeleteRows = false;
            this.dgvBonusFactStaff.AllowUserToOrderColumns = true;
            this.dgvBonusFactStaff.AutoGenerateColumns = false;
            this.dgvBonusFactStaff.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBonusFactStaff.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.bonusTypeDataGridViewTextBoxColumn,
            this.LastFinancingSource,
            this.BonusCount,
            this.DateBegin,
            this.LastPrikazBegin,
            this.IntermediateDateEnd,
            this.dateEndDataGridViewTextBoxColumn,
            this.Prikaz,
            this.Comment});
            this.dgvBonusFactStaff.DataSource = this.bonusBindingSource;
            this.dgvBonusFactStaff.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvBonusFactStaff.Location = new System.Drawing.Point(3, 29);
            this.dgvBonusFactStaff.Name = "dgvBonusFactStaff";
            this.dgvBonusFactStaff.ReadOnly = true;
            this.dgvBonusFactStaff.RowHeadersVisible = false;
            this.dgvBonusFactStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBonusFactStaff.Size = new System.Drawing.Size(1000, 508);
            this.dgvBonusFactStaff.TabIndex = 0;
            this.dgvBonusFactStaff.DoubleClick += new System.EventHandler(this.EditBonusBtn_Click);
            // 
            // bonusTypeDataGridViewTextBoxColumn
            // 
            this.bonusTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.bonusTypeDataGridViewTextBoxColumn.DataPropertyName = "BonusType";
            this.bonusTypeDataGridViewTextBoxColumn.HeaderText = "Вид надбавки";
            this.bonusTypeDataGridViewTextBoxColumn.Name = "bonusTypeDataGridViewTextBoxColumn";
            this.bonusTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.bonusTypeDataGridViewTextBoxColumn.Width = 94;
            // 
            // LastFinancingSource
            // 
            this.LastFinancingSource.DataPropertyName = "LastFinancingSource";
            this.LastFinancingSource.HeaderText = "Источ. финан.";
            this.LastFinancingSource.Name = "LastFinancingSource";
            this.LastFinancingSource.ReadOnly = true;
            this.LastFinancingSource.Width = 60;
            // 
            // BonusCount
            // 
            this.BonusCount.DataPropertyName = "BonusCount";
            this.BonusCount.HeaderText = "Размер надбавки";
            this.BonusCount.Name = "BonusCount";
            this.BonusCount.ReadOnly = true;
            this.BonusCount.Width = 70;
            // 
            // DateBegin
            // 
            this.DateBegin.DataPropertyName = "DateBegin";
            this.DateBegin.HeaderText = "Дата назначения";
            this.DateBegin.Name = "DateBegin";
            this.DateBegin.ReadOnly = true;
            this.DateBegin.Width = 80;
            // 
            // LastPrikazBegin
            // 
            this.LastPrikazBegin.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.LastPrikazBegin.DataPropertyName = "LastPrikazBegin";
            this.LastPrikazBegin.HeaderText = "Приказ назначения";
            this.LastPrikazBegin.Name = "LastPrikazBegin";
            this.LastPrikazBegin.ReadOnly = true;
            this.LastPrikazBegin.Width = 121;
            // 
            // IntermediateDateEnd
            // 
            this.IntermediateDateEnd.DataPropertyName = "IntermediateDateEnd";
            this.IntermediateDateEnd.HeaderText = "Промеж. дата отмены";
            this.IntermediateDateEnd.Name = "IntermediateDateEnd";
            this.IntermediateDateEnd.ReadOnly = true;
            this.IntermediateDateEnd.Width = 80;
            // 
            // dateEndDataGridViewTextBoxColumn
            // 
            this.dateEndDataGridViewTextBoxColumn.DataPropertyName = "DateEnd";
            this.dateEndDataGridViewTextBoxColumn.HeaderText = "Дата отмены";
            this.dateEndDataGridViewTextBoxColumn.Name = "dateEndDataGridViewTextBoxColumn";
            this.dateEndDataGridViewTextBoxColumn.ReadOnly = true;
            this.dateEndDataGridViewTextBoxColumn.Width = 80;
            // 
            // Prikaz
            // 
            this.Prikaz.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.Prikaz.DataPropertyName = "Prikaz";
            this.Prikaz.HeaderText = "Приказ отмены";
            this.Prikaz.Name = "Prikaz";
            this.Prikaz.ReadOnly = true;
            this.Prikaz.Width = 103;
            // 
            // Comment
            // 
            this.Comment.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Comment.DataPropertyName = "Comment";
            this.Comment.HeaderText = "Примечание";
            this.Comment.Name = "Comment";
            this.Comment.ReadOnly = true;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddBonusBtn,
            this.EditBonusBtn,
            this.DelBonusBtn,
            this.toolStripSeparator1,
            this.btnChangeBonus,
            this.btnHistoryBonus,
            this.toolStripSeparator3,
            this.tsbBonusFilter,
            this.toolStripSeparator2,
            this.btnClose});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1006, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddBonusBtn
            // 
            this.AddBonusBtn.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.AddBonusBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddBonusBtn.Name = "AddBonusBtn";
            this.AddBonusBtn.Size = new System.Drawing.Size(132, 22);
            this.AddBonusBtn.Text = "Добавить надбавку";
            this.AddBonusBtn.Click += new System.EventHandler(this.AddBonusBtn_Click);
            // 
            // EditBonusBtn
            // 
            this.EditBonusBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditBonusBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditBonusBtn.Name = "EditBonusBtn";
            this.EditBonusBtn.Size = new System.Drawing.Size(107, 22);
            this.EditBonusBtn.Text = "Редактировать";
            this.EditBonusBtn.ToolTipText = "Редактировать надбавку";
            this.EditBonusBtn.Click += new System.EventHandler(this.EditBonusBtn_Click);
            // 
            // DelBonusBtn
            // 
            this.DelBonusBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DelBonusBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelBonusBtn.Name = "DelBonusBtn";
            this.DelBonusBtn.Size = new System.Drawing.Size(71, 22);
            this.DelBonusBtn.Text = "Удалить";
            this.DelBonusBtn.ToolTipText = "Удалить надбавку";
            this.DelBonusBtn.Click += new System.EventHandler(this.DelBonusBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // btnChangeBonus
            // 
            this.btnChangeBonus.Image = global::Kadr.Properties.Resources.SychronizeListHS;
            this.btnChangeBonus.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnChangeBonus.Name = "btnChangeBonus";
            this.btnChangeBonus.Size = new System.Drawing.Size(81, 22);
            this.btnChangeBonus.Text = "Изменить";
            this.btnChangeBonus.ToolTipText = "Добавить изменение надбавки по приказу";
            this.btnChangeBonus.Click += new System.EventHandler(this.btnChangeBonus_Click);
            // 
            // btnHistoryBonus
            // 
            this.btnHistoryBonus.Image = global::Kadr.Properties.Resources.FillUpHS;
            this.btnHistoryBonus.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnHistoryBonus.Name = "btnHistoryBonus";
            this.btnHistoryBonus.Size = new System.Drawing.Size(74, 22);
            this.btnHistoryBonus.Text = "История";
            this.btnHistoryBonus.ToolTipText = "Открыть историю изменений";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbBonusFilter
            // 
            this.tsbBonusFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.текущиеToolStripMenuItem,
            this.отмененныеToolStripMenuItem});
            this.tsbBonusFilter.Image = global::Kadr.Properties.Resources.Filter2HS;
            this.tsbBonusFilter.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbBonusFilter.Name = "tsbBonusFilter";
            this.tsbBonusFilter.Size = new System.Drawing.Size(83, 22);
            this.tsbBonusFilter.Text = "Фильтр ";
            this.tsbBonusFilter.ToolTipText = "Задать фильтр по надбавкам";
            // 
            // текущиеToolStripMenuItem
            // 
            this.текущиеToolStripMenuItem.Checked = true;
            this.текущиеToolStripMenuItem.CheckOnClick = true;
            this.текущиеToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.текущиеToolStripMenuItem.Name = "текущиеToolStripMenuItem";
            this.текущиеToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.текущиеToolStripMenuItem.Text = "Текущие";
            // 
            // отмененныеToolStripMenuItem
            // 
            this.отмененныеToolStripMenuItem.Checked = true;
            this.отмененныеToolStripMenuItem.CheckOnClick = true;
            this.отмененныеToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.отмененныеToolStripMenuItem.Name = "отмененныеToolStripMenuItem";
            this.отмененныеToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.отмененныеToolStripMenuItem.Text = "Отмененные";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // btnClose
            // 
            this.btnClose.Image = global::Kadr.Properties.Resources.DeleteFolderHS;
            this.btnClose.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(61, 22);
            this.btnClose.Text = "Выход";
            this.btnClose.ToolTipText = "Закрыть окно";
            // 
            // BonusFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "BonusFrame";
            this.Size = new System.Drawing.Size(1006, 540);
            ((System.ComponentModel.ISupportInitialize)(this.bonusBindingSource)).EndInit();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusFactStaff)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bonusBindingSource;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvBonusFactStaff;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonusTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastFinancingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn BonusCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPrikazBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntermediateDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prikaz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddBonusBtn;
        private System.Windows.Forms.ToolStripButton EditBonusBtn;
        private System.Windows.Forms.ToolStripButton DelBonusBtn;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnChangeBonus;
        private System.Windows.Forms.ToolStripButton btnHistoryBonus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        public System.Windows.Forms.ToolStripSplitButton tsbBonusFilter;
        private System.Windows.Forms.ToolStripMenuItem текущиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отмененныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton btnClose;
    }
}
