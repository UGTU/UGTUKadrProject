namespace Kadr.UI.Forms
{
    partial class KadrBonusForm
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
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.dgvBonusFactStaff = new System.Windows.Forms.DataGridView();
            this.bonusTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.BonusCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.LastPrikazBegin = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.IntermediateDateEnd = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateEndDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Prikaz = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Comment = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bonusBindingSource = new System.Windows.Forms.BindingSource(this.components);
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
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn19 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn20 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusFactStaff)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusBindingSource)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            this.tableLayoutPanel2.Size = new System.Drawing.Size(811, 369);
            this.tableLayoutPanel2.TabIndex = 2;
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
            this.dgvBonusFactStaff.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvBonusFactStaff.Size = new System.Drawing.Size(805, 337);
            this.dgvBonusFactStaff.TabIndex = 0;
            this.dgvBonusFactStaff.RowPrePaint += new System.Windows.Forms.DataGridViewRowPrePaintEventHandler(this.dgvBonusFactStaff_RowPrePaint);
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
            // BonusCount
            // 
            this.BonusCount.DataPropertyName = "BonusCount";
            this.BonusCount.HeaderText = "Размер надбавки";
            this.BonusCount.Name = "BonusCount";
            this.BonusCount.ReadOnly = true;
            this.BonusCount.Width = 80;
            // 
            // DateBegin
            // 
            this.DateBegin.DataPropertyName = "DateBegin";
            this.DateBegin.HeaderText = "Дата назначения";
            this.DateBegin.Name = "DateBegin";
            this.DateBegin.ReadOnly = true;
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
            // bonusBindingSource
            // 
            this.bonusBindingSource.DataSource = typeof(Kadr.Data.Bonus);
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
            this.toolStrip1.Size = new System.Drawing.Size(811, 25);
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
            this.EditBonusBtn.Click += new System.EventHandler(this.EditBonusBtn_Click);
            // 
            // DelBonusBtn
            // 
            this.DelBonusBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DelBonusBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelBonusBtn.Name = "DelBonusBtn";
            this.DelBonusBtn.Size = new System.Drawing.Size(71, 22);
            this.DelBonusBtn.Text = "Удалить";
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
            this.btnChangeBonus.ToolTipText = "Изменить по приказу";
            this.btnChangeBonus.Click += new System.EventHandler(this.btnChangeBonus_Click);
            // 
            // btnHistoryBonus
            // 
            this.btnHistoryBonus.Image = global::Kadr.Properties.Resources.FillUpHS;
            this.btnHistoryBonus.ImageTransparentColor = System.Drawing.Color.Black;
            this.btnHistoryBonus.Name = "btnHistoryBonus";
            this.btnHistoryBonus.Size = new System.Drawing.Size(74, 22);
            this.btnHistoryBonus.Text = "История";
            this.btnHistoryBonus.ToolTipText = "История изменений";
            this.btnHistoryBonus.Click += new System.EventHandler(this.btnHistoryBonus_Click);
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
            this.tsbBonusFilter.Size = new System.Drawing.Size(159, 22);
            this.tsbBonusFilter.Text = "Фильтр по надбавкам";
            this.tsbBonusFilter.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbBonusFilter_DropDownItemClicked);
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
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "BonusType";
            this.dataGridViewTextBoxColumn1.HeaderText = "Вид надбавки";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn2.DataPropertyName = "BonusCount";
            this.dataGridViewTextBoxColumn2.HeaderText = "Размер надбавки";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn3.HeaderText = "Приказ назначения";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn4.HeaderText = "Дата назначения";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn5.HeaderText = "Дата отмены";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.dataGridViewTextBoxColumn6.DataPropertyName = "Prikaz1";
            this.dataGridViewTextBoxColumn6.HeaderText = "Приказ отмены";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn7.DataPropertyName = "id";
            this.dataGridViewTextBoxColumn7.HeaderText = "id";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn8.DataPropertyName = "BonusCount";
            this.dataGridViewTextBoxColumn8.HeaderText = "BonusCount";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "DateBegin";
            this.dataGridViewTextBoxColumn9.HeaderText = "DateBegin";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "DateEnd";
            this.dataGridViewTextBoxColumn10.HeaderText = "DateEnd";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "idBonusType";
            this.dataGridViewTextBoxColumn11.HeaderText = "idBonusType";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.DataPropertyName = "idPrikaz";
            this.dataGridViewTextBoxColumn12.HeaderText = "idPrikaz";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.DataPropertyName = "idEndPrikaz";
            this.dataGridViewTextBoxColumn13.HeaderText = "idEndPrikaz";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.DataPropertyName = "BonusPlanStaff";
            this.dataGridViewTextBoxColumn14.HeaderText = "BonusPlanStaff";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            // 
            // dataGridViewTextBoxColumn15
            // 
            this.dataGridViewTextBoxColumn15.DataPropertyName = "BonusFactStaff";
            this.dataGridViewTextBoxColumn15.HeaderText = "BonusFactStaff";
            this.dataGridViewTextBoxColumn15.Name = "dataGridViewTextBoxColumn15";
            // 
            // dataGridViewTextBoxColumn16
            // 
            this.dataGridViewTextBoxColumn16.DataPropertyName = "BonusEmployee";
            this.dataGridViewTextBoxColumn16.HeaderText = "BonusEmployee";
            this.dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            // 
            // dataGridViewTextBoxColumn17
            // 
            this.dataGridViewTextBoxColumn17.DataPropertyName = "BonusPost";
            this.dataGridViewTextBoxColumn17.HeaderText = "BonusPost";
            this.dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            // 
            // dataGridViewTextBoxColumn18
            // 
            this.dataGridViewTextBoxColumn18.DataPropertyName = "Prikaz";
            this.dataGridViewTextBoxColumn18.HeaderText = "Prikaz";
            this.dataGridViewTextBoxColumn18.Name = "dataGridViewTextBoxColumn18";
            // 
            // dataGridViewTextBoxColumn19
            // 
            this.dataGridViewTextBoxColumn19.DataPropertyName = "Prikaz1";
            this.dataGridViewTextBoxColumn19.HeaderText = "Prikaz1";
            this.dataGridViewTextBoxColumn19.Name = "dataGridViewTextBoxColumn19";
            // 
            // dataGridViewTextBoxColumn20
            // 
            this.dataGridViewTextBoxColumn20.DataPropertyName = "BonusType";
            this.dataGridViewTextBoxColumn20.HeaderText = "BonusType";
            this.dataGridViewTextBoxColumn20.Name = "dataGridViewTextBoxColumn20";
            // 
            // KadrBonusForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(811, 369);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Name = "KadrBonusForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Надбавки";
            this.Load += new System.EventHandler(this.KadrBonusForm_Load);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBonusFactStaff)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bonusBindingSource)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.DataGridView dgvBonusFactStaff;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddBonusBtn;
        private System.Windows.Forms.ToolStripButton EditBonusBtn;
        private System.Windows.Forms.ToolStripButton DelBonusBtn;
        private System.Windows.Forms.BindingSource bonusBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolStripButton btnClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSplitButton tsbBonusFilter;
        private System.Windows.Forms.ToolStripMenuItem текущиеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem отмененныеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn18;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn19;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn20;
        private System.Windows.Forms.ToolStripButton btnHistoryBonus;
        private System.Windows.Forms.ToolStripButton btnChangeBonus;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikazDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bonusTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn BonusCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn LastPrikazBegin;
        private System.Windows.Forms.DataGridViewTextBoxColumn IntermediateDateEnd;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEndDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Prikaz;
        private System.Windows.Forms.DataGridViewTextBoxColumn Comment;

    }
}