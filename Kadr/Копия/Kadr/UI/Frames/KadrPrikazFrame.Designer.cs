namespace Kadr.UI.Frames
{
    partial class KadrPrikazFrame
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KadrPrikazFrame));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddPrikazBtn = new System.Windows.Forms.ToolStripButton();
            this.EditPrikazBtn = new System.Windows.Forms.ToolStripButton();
            this.DeletePrikazBtn = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.btnPrikazToExcel = new System.Windows.Forms.ToolStripButton();
            this.dgvPrikaz = new System.Windows.Forms.DataGridView();
            this.prikazDecoratorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.prikazTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.prikazNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.datePrikazDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrikaz)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazDecoratorBindingSource)).BeginInit();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tableLayoutPanel1);
            this.groupBox1.Size = new System.Drawing.Size(541, 353);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddPrikazBtn,
            this.EditPrikazBtn,
            this.DeletePrikazBtn,
            this.toolStripSeparator1,
            this.btnPrikazToExcel});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(535, 26);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddPrikazBtn
            // 
            this.AddPrikazBtn.Image = global::Kadr.Properties.Resources.AddTableHS;
            this.AddPrikazBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.AddPrikazBtn.Name = "AddPrikazBtn";
            this.AddPrikazBtn.Size = new System.Drawing.Size(120, 23);
            this.AddPrikazBtn.Text = "Добавить приказ";
            this.AddPrikazBtn.Click += new System.EventHandler(this.AddPrikazBtn_Click);
            // 
            // EditPrikazBtn
            // 
            this.EditPrikazBtn.Image = global::Kadr.Properties.Resources.EditTableHS;
            this.EditPrikazBtn.ImageTransparentColor = System.Drawing.Color.Black;
            this.EditPrikazBtn.Name = "EditPrikazBtn";
            this.EditPrikazBtn.Size = new System.Drawing.Size(107, 23);
            this.EditPrikazBtn.Text = "Редактировать";
            this.EditPrikazBtn.Click += new System.EventHandler(this.EditPrikazBtn_Click);
            // 
            // DeletePrikazBtn
            // 
            this.DeletePrikazBtn.Image = global::Kadr.Properties.Resources.DelTableHS;
            this.DeletePrikazBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DeletePrikazBtn.Name = "DeletePrikazBtn";
            this.DeletePrikazBtn.Size = new System.Drawing.Size(71, 23);
            this.DeletePrikazBtn.Text = "Удалить";
            this.DeletePrikazBtn.Click += new System.EventHandler(this.DeletePrikazBtn_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 26);
            // 
            // btnPrikazToExcel
            // 
            this.btnPrikazToExcel.Image = ((System.Drawing.Image)(resources.GetObject("btnPrikazToExcel.Image")));
            this.btnPrikazToExcel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnPrikazToExcel.Name = "btnPrikazToExcel";
            this.btnPrikazToExcel.Size = new System.Drawing.Size(142, 23);
            this.btnPrikazToExcel.Text = "Выгрузить в MS Excel";
            this.btnPrikazToExcel.Click += new System.EventHandler(this.btnPrikazToExcel_Click);
            // 
            // dgvPrikaz
            // 
            this.dgvPrikaz.AllowUserToAddRows = false;
            this.dgvPrikaz.AllowUserToDeleteRows = false;
            this.dgvPrikaz.AutoGenerateColumns = false;
            this.dgvPrikaz.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrikaz.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.prikazTypeDataGridViewTextBoxColumn,
            this.prikazNameDataGridViewTextBoxColumn,
            this.datePrikazDataGridViewTextBoxColumn});
            this.dgvPrikaz.DataSource = this.prikazDecoratorBindingSource;
            this.dgvPrikaz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvPrikaz.Location = new System.Drawing.Point(3, 29);
            this.dgvPrikaz.Name = "dgvPrikaz";
            this.dgvPrikaz.ReadOnly = true;
            this.dgvPrikaz.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrikaz.Size = new System.Drawing.Size(529, 302);
            this.dgvPrikaz.TabIndex = 1;
            this.dgvPrikaz.DoubleClick += new System.EventHandler(this.dgvPrikaz_DoubleClick);
            // 
            // prikazDecoratorBindingSource
            // 
            this.prikazDecoratorBindingSource.DataSource = typeof(Kadr.Data.PrikazDecorator);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.dgvPrikaz, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.toolStrip1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(535, 334);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // prikazTypeDataGridViewTextBoxColumn
            // 
            this.prikazTypeDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.AllCells;
            this.prikazTypeDataGridViewTextBoxColumn.DataPropertyName = "PrikazType";
            this.prikazTypeDataGridViewTextBoxColumn.HeaderText = "Вид приказа";
            this.prikazTypeDataGridViewTextBoxColumn.Name = "prikazTypeDataGridViewTextBoxColumn";
            this.prikazTypeDataGridViewTextBoxColumn.ReadOnly = true;
            this.prikazTypeDataGridViewTextBoxColumn.Width = 96;
            // 
            // prikazNameDataGridViewTextBoxColumn
            // 
            this.prikazNameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.prikazNameDataGridViewTextBoxColumn.DataPropertyName = "PrikazName";
            this.prikazNameDataGridViewTextBoxColumn.HeaderText = "Название приказа";
            this.prikazNameDataGridViewTextBoxColumn.MinimumWidth = 100;
            this.prikazNameDataGridViewTextBoxColumn.Name = "prikazNameDataGridViewTextBoxColumn";
            this.prikazNameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // datePrikazDataGridViewTextBoxColumn
            // 
            this.datePrikazDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.ColumnHeader;
            this.datePrikazDataGridViewTextBoxColumn.DataPropertyName = "DatePrikaz";
            this.datePrikazDataGridViewTextBoxColumn.HeaderText = "Дата вступления в силу";
            this.datePrikazDataGridViewTextBoxColumn.Name = "datePrikazDataGridViewTextBoxColumn";
            this.datePrikazDataGridViewTextBoxColumn.ReadOnly = true;
            this.datePrikazDataGridViewTextBoxColumn.Width = 94;
            // 
            // KadrPrikazFrame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Name = "KadrPrikazFrame";
            this.Size = new System.Drawing.Size(541, 353);
            this.groupBox1.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrikaz)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.prikazDecoratorBindingSource)).EndInit();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.DataGridView dgvPrikaz;
        private System.Windows.Forms.BindingSource prikazDecoratorBindingSource;
        private System.Windows.Forms.ToolStripButton AddPrikazBtn;
        private System.Windows.Forms.ToolStripButton EditPrikazBtn;
        private System.Windows.Forms.ToolStripButton DeletePrikazBtn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateBeginDataGridViewTextBoxColumn;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton btnPrikazToExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikazTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn prikazNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn datePrikazDataGridViewTextBoxColumn;
    }
}
