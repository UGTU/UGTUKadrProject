namespace Kadr.UI.Forms
{
    partial class KadrBaseForm
    {

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
            System.Windows.Forms.ToolStripMenuItem tsmiDismissedEmployees;
            System.Windows.Forms.ToolStripMenuItem toolStripMenuItem10;
            System.Windows.Forms.ToolStrip toolStrip1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(KadrBaseForm));
            this.tsbNew = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbDelete = new System.Windows.Forms.ToolStripButton();
            this.tsbEdit = new System.Windows.Forms.ToolStripButton();
            this.tsbUpdate = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCut = new System.Windows.Forms.ToolStripButton();
            this.tsbCopy = new System.Windows.Forms.ToolStripButton();
            this.tsbPaste = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RollbackMenuItem = new System.Windows.Forms.ToolStripSplitButton();
            this.RedoMenuItem = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tscbFindType = new System.Windows.Forms.ToolStripComboBox();
            this.tscbTextSearch = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSplitButton1 = new System.Windows.Forms.ToolStripSplitButton();
            this.расширенныйПоискToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator11 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbEmployeeFilter = new System.Windows.Forms.ToolStripSplitButton();
            this.tsmiCurrentEmployees = new System.Windows.Forms.ToolStripMenuItem();
            this.tsbDepartmentFilter = new System.Windows.Forms.ToolStripSplitButton();
            this.toolStripMenuItem13 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem14 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.CurrentObjectLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.CurrentObjectInfoLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.treeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripTextBox1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem12 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator9 = new System.Windows.Forms.ToolStripSeparator();
            this.miImport = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.miExportReport = new System.Windows.Forms.ToolStripMenuItem();
            this.импортироватьСуточныйРапортToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.печатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmiActions = new System.Windows.Forms.ToolStripMenuItem();
            this.справочникиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ВидНадбавкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.единицыИзмеренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типНадбавкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.gRToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.пКГToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.категорииПерсоналаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видРаботыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.персоналToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.гражданствоToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.семейноеПоложениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приказыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.типыПриказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видыПриказовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.приказыМинистерстваToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.окладToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.источникФинансированияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.базовыеОкладыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.совмещенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.причинаСовмещенияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.табельToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.статусДняToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.графикиРаботыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отчётыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.графикБуренияToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.надбавкиПоОтделамToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.НастройкиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видыОтчетовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.последовательностьДанныхToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.правкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.отменитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.повторитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.вырезатьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.копироватьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.вставитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripSeparator();
            this.выделитьВсёToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.панельИнструментовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.строкаСтатусаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.деревоПромысловыхОбъектовToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.сервисToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.параметрыToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.оглавлениеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ApplicationAboutStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.treeNodeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem7 = new System.Windows.Forms.ToolStripSeparator();
            this.развернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem8 = new System.Windows.Forms.ToolStripSeparator();
            this.показатьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.свернутьВсеToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem9 = new System.Windows.Forms.ToolStripSeparator();
            this.обновитьToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.departmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.kadrTreeView1 = new Kadr.KadrTreeView.KadrTreeView(this.components);
            tsmiDismissedEmployees = new System.Windows.Forms.ToolStripMenuItem();
            toolStripMenuItem10 = new System.Windows.Forms.ToolStripMenuItem();
            toolStrip1 = new System.Windows.Forms.ToolStrip();
            toolStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.treeNodeContextMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tsmiDismissedEmployees
            // 
            tsmiDismissedEmployees.CheckOnClick = true;
            tsmiDismissedEmployees.Name = "tsmiDismissedEmployees";
            tsmiDismissedEmployees.Size = new System.Drawing.Size(203, 22);
            tsmiDismissedEmployees.Text = "Уволенные сотрудники";
            // 
            // toolStripMenuItem10
            // 
            toolStripMenuItem10.CheckOnClick = true;
            toolStripMenuItem10.Name = "toolStripMenuItem10";
            toolStripMenuItem10.Size = new System.Drawing.Size(205, 22);
            toolStripMenuItem10.Text = "Уволенные сотрудники";
            // 
            // toolStrip1
            // 
            toolStrip1.Dock = System.Windows.Forms.DockStyle.None;
            toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbNew,
            this.toolStripSeparator2,
            this.tsbDelete,
            this.tsbEdit,
            this.tsbUpdate,
            this.toolStripSeparator4,
            this.tsbCut,
            this.tsbCopy,
            this.tsbPaste,
            this.toolStripSeparator3,
            this.RollbackMenuItem,
            this.RedoMenuItem,
            this.toolStripSeparator5,
            this.tscbFindType,
            this.tscbTextSearch,
            this.toolStripSplitButton1,
            this.toolStripSeparator11,
            this.tsbEmployeeFilter,
            this.tsbDepartmentFilter});
            toolStrip1.Location = new System.Drawing.Point(3, 24);
            toolStrip1.Name = "toolStrip1";
            toolStrip1.Size = new System.Drawing.Size(723, 25);
            toolStrip1.TabIndex = 1;
            // 
            // tsbNew
            // 
            this.tsbNew.Image = global::Kadr.Properties.Resources.NewReportHS;
            this.tsbNew.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbNew.Name = "tsbNew";
            this.tsbNew.Size = new System.Drawing.Size(132, 22);
            this.tsbNew.Text = "Создать объект...";
            this.tsbNew.ButtonClick += new System.EventHandler(this.tsbNew_ButtonClick);
            this.tsbNew.DropDownOpening += new System.EventHandler(this.tsbNew_DropDownOpening);
            this.tsbNew.MouseEnter += new System.EventHandler(this.tsbNew_MouseEnter);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbDelete
            // 
            this.tsbDelete.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDelete.Image = global::Kadr.Properties.Resources.DeleteHS;
            this.tsbDelete.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbDelete.Name = "tsbDelete";
            this.tsbDelete.Size = new System.Drawing.Size(23, 22);
            this.tsbDelete.Click += new System.EventHandler(this.tsbDelete_Click);
            this.tsbDelete.MouseEnter += new System.EventHandler(this.tsbDelete_MouseEnter);
            // 
            // tsbEdit
            // 
            this.tsbEdit.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEdit.Image = global::Kadr.Properties.Resources.EditInformationHS;
            this.tsbEdit.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEdit.Name = "tsbEdit";
            this.tsbEdit.Size = new System.Drawing.Size(23, 22);
            this.tsbEdit.Click += new System.EventHandler(this.tsbEdit_Click);
            this.tsbEdit.MouseEnter += new System.EventHandler(this.tsbEdit_MouseEnter);
            // 
            // tsbUpdate
            // 
            this.tsbUpdate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbUpdate.Image = global::Kadr.Properties.Resources.RefreshDocViewHS;
            this.tsbUpdate.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbUpdate.Name = "tsbUpdate";
            this.tsbUpdate.Size = new System.Drawing.Size(23, 22);
            this.tsbUpdate.Click += new System.EventHandler(this.tsbUpdate_Click);
            this.tsbUpdate.MouseEnter += new System.EventHandler(this.tsbUpdate_MouseEnter);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator4.Visible = false;
            // 
            // tsbCut
            // 
            this.tsbCut.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCut.Image = global::Kadr.Properties.Resources.Edit_Cut;
            this.tsbCut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsbCut.Name = "tsbCut";
            this.tsbCut.Size = new System.Drawing.Size(23, 22);
            this.tsbCut.Visible = false;
            this.tsbCut.Click += new System.EventHandler(this.tsbCut_Click);
            this.tsbCut.MouseEnter += new System.EventHandler(this.tsbCut_MouseEnter);
            // 
            // tsbCopy
            // 
            this.tsbCopy.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbCopy.Image = global::Kadr.Properties.Resources.CopyHS;
            this.tsbCopy.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbCopy.Name = "tsbCopy";
            this.tsbCopy.Size = new System.Drawing.Size(23, 22);
            this.tsbCopy.Visible = false;
            this.tsbCopy.Click += new System.EventHandler(this.tsbCopy_Click);
            this.tsbCopy.MouseEnter += new System.EventHandler(this.tsbCopy_MouseEnter);
            // 
            // tsbPaste
            // 
            this.tsbPaste.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbPaste.Image = global::Kadr.Properties.Resources.PasteHS;
            this.tsbPaste.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbPaste.Name = "tsbPaste";
            this.tsbPaste.Size = new System.Drawing.Size(23, 22);
            this.tsbPaste.Visible = false;
            this.tsbPaste.Click += new System.EventHandler(this.tsbPaste_Click);
            this.tsbPaste.MouseEnter += new System.EventHandler(this.tsbPaste_MouseEnter);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator3.Visible = false;
            // 
            // RollbackMenuItem
            // 
            this.RollbackMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RollbackMenuItem.Enabled = false;
            this.RollbackMenuItem.Image = global::Kadr.Properties.Resources.Edit_Undo;
            this.RollbackMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RollbackMenuItem.Name = "RollbackMenuItem";
            this.RollbackMenuItem.Size = new System.Drawing.Size(32, 22);
            this.RollbackMenuItem.Text = "toolStripSplitButton1";
            this.RollbackMenuItem.Visible = false;
            this.RollbackMenuItem.DropDownOpening += new System.EventHandler(this.RollbackMenuItem_DropDownOpening);
            this.RollbackMenuItem.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.RollbackMenuItem_DropDownItemClicked);
            // 
            // RedoMenuItem
            // 
            this.RedoMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.RedoMenuItem.Enabled = false;
            this.RedoMenuItem.Image = global::Kadr.Properties.Resources.Edit_Redo;
            this.RedoMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RedoMenuItem.Name = "RedoMenuItem";
            this.RedoMenuItem.Size = new System.Drawing.Size(32, 22);
            this.RedoMenuItem.Text = "toolStripSplitButton2";
            this.RedoMenuItem.Visible = false;
            this.RedoMenuItem.DropDownOpening += new System.EventHandler(this.RedoMenuItem_DropDownOpening);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 25);
            this.toolStripSeparator5.Visible = false;
            // 
            // tscbFindType
            // 
            this.tscbFindType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbFindType.Items.AddRange(new object[] {
            "Поиск сотрудника",
            "Поиск отдела"});
            this.tscbFindType.MergeAction = System.Windows.Forms.MergeAction.MatchOnly;
            this.tscbFindType.Name = "tscbFindType";
            this.tscbFindType.Size = new System.Drawing.Size(160, 25);
            this.tscbFindType.SelectedIndexChanged += new System.EventHandler(this.tscbFindType_SelectedIndexChanged);
            // 
            // tscbTextSearch
            // 
            this.tscbTextSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.tscbTextSearch.Name = "tscbTextSearch";
            this.tscbTextSearch.Size = new System.Drawing.Size(270, 25);
            this.tscbTextSearch.SelectedIndexChanged += new System.EventHandler(this.tscbTextSearch_SelectedIndexChanged);
            this.tscbTextSearch.Enter += new System.EventHandler(this.tscbTextSearch_Enter);
            this.tscbTextSearch.Leave += new System.EventHandler(this.tscbTextSearch_Leave);
            // 
            // toolStripSplitButton1
            // 
            this.toolStripSplitButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripSplitButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.расширенныйПоискToolStripMenuItem});
            this.toolStripSplitButton1.Image = global::Kadr.Properties.Resources.PlayHS;
            this.toolStripSplitButton1.ImageTransparentColor = System.Drawing.Color.Black;
            this.toolStripSplitButton1.Name = "toolStripSplitButton1";
            this.toolStripSplitButton1.Size = new System.Drawing.Size(32, 22);
            this.toolStripSplitButton1.Text = "toolStripSplitButton1";
            this.toolStripSplitButton1.Visible = false;
            this.toolStripSplitButton1.ButtonClick += new System.EventHandler(this.toolStripSplitButton1_ButtonClick);
            // 
            // расширенныйПоискToolStripMenuItem
            // 
            this.расширенныйПоискToolStripMenuItem.Name = "расширенныйПоискToolStripMenuItem";
            this.расширенныйПоискToolStripMenuItem.Size = new System.Drawing.Size(199, 22);
            this.расширенныйПоискToolStripMenuItem.Text = "Расширенный поиск...";
            // 
            // toolStripSeparator11
            // 
            this.toolStripSeparator11.Name = "toolStripSeparator11";
            this.toolStripSeparator11.Size = new System.Drawing.Size(6, 25);
            // 
            // tsbEmployeeFilter
            // 
            this.tsbEmployeeFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbEmployeeFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmiCurrentEmployees,
            tsmiDismissedEmployees});
            this.tsbEmployeeFilter.Image = global::Kadr.Properties.Resources.Filter2HS;
            this.tsbEmployeeFilter.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbEmployeeFilter.Name = "tsbEmployeeFilter";
            this.tsbEmployeeFilter.Size = new System.Drawing.Size(32, 22);
            this.tsbEmployeeFilter.Tag = "";
            this.tsbEmployeeFilter.Text = "Фильтр по сотрудникам";
            this.tsbEmployeeFilter.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbEmployeeFilter_DropDownItemClicked);
            // 
            // tsmiCurrentEmployees
            // 
            this.tsmiCurrentEmployees.Checked = true;
            this.tsmiCurrentEmployees.CheckOnClick = true;
            this.tsmiCurrentEmployees.CheckState = System.Windows.Forms.CheckState.Checked;
            this.tsmiCurrentEmployees.Name = "tsmiCurrentEmployees";
            this.tsmiCurrentEmployees.Size = new System.Drawing.Size(203, 22);
            this.tsmiCurrentEmployees.Text = "Текущие сотрудники";
            // 
            // tsbDepartmentFilter
            // 
            this.tsbDepartmentFilter.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsbDepartmentFilter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem13,
            this.toolStripMenuItem14});
            this.tsbDepartmentFilter.Image = global::Kadr.Properties.Resources.Filter2HS;
            this.tsbDepartmentFilter.ImageTransparentColor = System.Drawing.Color.Black;
            this.tsbDepartmentFilter.Name = "tsbDepartmentFilter";
            this.tsbDepartmentFilter.Size = new System.Drawing.Size(32, 22);
            this.tsbDepartmentFilter.Text = "Фильтр по отделам";
            this.tsbDepartmentFilter.DropDownItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.tsbDepartmentFilter_DropDownItemClicked);
            // 
            // toolStripMenuItem13
            // 
            this.toolStripMenuItem13.Checked = true;
            this.toolStripMenuItem13.CheckOnClick = true;
            this.toolStripMenuItem13.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem13.Name = "toolStripMenuItem13";
            this.toolStripMenuItem13.Size = new System.Drawing.Size(230, 22);
            this.toolStripMenuItem13.Text = "Текущие отделы";
            // 
            // toolStripMenuItem14
            // 
            this.toolStripMenuItem14.CheckOnClick = true;
            this.toolStripMenuItem14.Name = "toolStripMenuItem14";
            this.toolStripMenuItem14.Size = new System.Drawing.Size(230, 22);
            this.toolStripMenuItem14.Text = "Расформированные отделы";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.splitContainer1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(835, 389);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(835, 462);
            this.toolStripContainer1.TabIndex = 0;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.menuStrip1);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(toolStrip1);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CurrentObjectLabel,
            this.CurrentObjectInfoLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(835, 24);
            this.statusStrip1.TabIndex = 0;
            // 
            // CurrentObjectLabel
            // 
            this.CurrentObjectLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.CurrentObjectLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.CurrentObjectLabel.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.CurrentObjectLabel.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.CurrentObjectLabel.Name = "CurrentObjectLabel";
            this.CurrentObjectLabel.Size = new System.Drawing.Size(59, 19);
            this.CurrentObjectLabel.Text = "Текущее";
            // 
            // CurrentObjectInfoLabel
            // 
            this.CurrentObjectInfoLabel.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)
                        | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.CurrentObjectInfoLabel.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.CurrentObjectInfoLabel.Name = "CurrentObjectInfoLabel";
            this.CurrentObjectInfoLabel.Size = new System.Drawing.Size(122, 19);
            this.CurrentObjectInfoLabel.Text = "toolStripStatusLabel1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.kadrTreeView1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.splitContainer1.Size = new System.Drawing.Size(835, 389);
            this.splitContainer1.SplitterDistance = 193;
            this.splitContainer1.TabIndex = 0;
            // 
            // treeViewImageList
            // 
            this.treeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("treeViewImageList.ImageStream")));
            this.treeViewImageList.TransparentColor = System.Drawing.Color.Black;
            this.treeViewImageList.Images.SetKeyName(0, "");
            this.treeViewImageList.Images.SetKeyName(1, "");
            this.treeViewImageList.Images.SetKeyName(2, "");
            this.treeViewImageList.Images.SetKeyName(3, "");
            this.treeViewImageList.Images.SetKeyName(4, "");
            this.treeViewImageList.Images.SetKeyName(5, "");
            this.treeViewImageList.Images.SetKeyName(6, "");
            this.treeViewImageList.Images.SetKeyName(7, "");
            this.treeViewImageList.Images.SetKeyName(8, "im1.bmp");
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.tsmiActions,
            this.справочникиToolStripMenuItem,
            this.отчётыToolStripMenuItem,
            this.правкаToolStripMenuItem,
            this.видToolStripMenuItem,
            this.сервисToolStripMenuItem,
            this.справкаToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(835, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripTextBox1,
            this.toolStripSeparator6,
            this.печатьToolStripMenuItem,
            this.toolStripMenuItem4,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "&Файл";
            // 
            // toolStripTextBox1
            // 
            this.toolStripTextBox1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem11,
            this.toolStripMenuItem12,
            this.toolStripSeparator9,
            this.miImport,
            this.toolStripSeparator7,
            this.miExportReport,
            this.импортироватьСуточныйРапортToolStripMenuItem});
            this.toolStripTextBox1.Name = "toolStripTextBox1";
            this.toolStripTextBox1.Size = new System.Drawing.Size(175, 22);
            this.toolStripTextBox1.Text = "Импорт и экспорт";
            this.toolStripTextBox1.Visible = false;
            this.toolStripTextBox1.DropDownOpening += new System.EventHandler(this.toolStripTextBox1_DropDownOpening);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(386, 22);
            // 
            // toolStripMenuItem12
            // 
            this.toolStripMenuItem12.Name = "toolStripMenuItem12";
            this.toolStripMenuItem12.Size = new System.Drawing.Size(386, 22);
            this.toolStripMenuItem12.Text = "Экспортировать справочники (режим совместимости)...";
            this.toolStripMenuItem12.Click += new System.EventHandler(this.toolStripMenuItem12_Click);
            // 
            // toolStripSeparator9
            // 
            this.toolStripSeparator9.Name = "toolStripSeparator9";
            this.toolStripSeparator9.Size = new System.Drawing.Size(383, 6);
            // 
            // miImport
            // 
            this.miImport.Name = "miImport";
            this.miImport.Size = new System.Drawing.Size(386, 22);
            this.miImport.Text = "Импортировать справочники...";
            this.miImport.Click += new System.EventHandler(this.miImport_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(383, 6);
            // 
            // miExportReport
            // 
            this.miExportReport.Name = "miExportReport";
            this.miExportReport.Size = new System.Drawing.Size(386, 22);
            this.miExportReport.Text = "Экспортировать суточный рапорт...";
            this.miExportReport.Click += new System.EventHandler(this.miExportReport_Click);
            // 
            // импортироватьСуточныйРапортToolStripMenuItem
            // 
            this.импортироватьСуточныйРапортToolStripMenuItem.Name = "импортироватьСуточныйРапортToolStripMenuItem";
            this.импортироватьСуточныйРапортToolStripMenuItem.Size = new System.Drawing.Size(386, 22);
            this.импортироватьСуточныйРапортToolStripMenuItem.Text = "Импортировать суточный рапорт...";
            this.импортироватьСуточныйРапортToolStripMenuItem.Click += new System.EventHandler(this.импортироватьСуточныйРапортToolStripMenuItem_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(172, 6);
            this.toolStripSeparator6.Visible = false;
            // 
            // печатьToolStripMenuItem
            // 
            this.печатьToolStripMenuItem.Name = "печатьToolStripMenuItem";
            this.печатьToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.печатьToolStripMenuItem.Text = "Печать...";
            this.печатьToolStripMenuItem.Visible = false;
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(172, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.ExitToolStripMenuItem.Text = "&Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItem_Click);
            // 
            // tsmiActions
            // 
            this.tsmiActions.Name = "tsmiActions";
            this.tsmiActions.Size = new System.Drawing.Size(70, 20);
            this.tsmiActions.Text = "Действия";
            this.tsmiActions.DropDownOpening += new System.EventHandler(this.tsmiActions_DropDownOpening);
            // 
            // справочникиToolStripMenuItem
            // 
            this.справочникиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ВидНадбавкиToolStripMenuItem,
            this.toolStripSeparator8,
            this.gRToolStripMenuItem,
            this.персоналToolStripMenuItem,
            this.приказыToolStripMenuItem,
            this.окладToolStripMenuItem,
            this.совмещенияToolStripMenuItem,
            this.табельToolStripMenuItem});
            this.справочникиToolStripMenuItem.Name = "справочникиToolStripMenuItem";
            this.справочникиToolStripMenuItem.Size = new System.Drawing.Size(94, 20);
            this.справочникиToolStripMenuItem.Text = "&Справочники";
            this.справочникиToolStripMenuItem.DropDownOpened += new System.EventHandler(this.справочникиToolStripMenuItem_DropDownOpened);
            // 
            // ВидНадбавкиToolStripMenuItem
            // 
            this.ВидНадбавкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.единицыИзмеренияToolStripMenuItem,
            this.типНадбавкиToolStripMenuItem,
            this.видToolStripMenuItem1});
            this.ВидНадбавкиToolStripMenuItem.Name = "ВидНадбавкиToolStripMenuItem";
            this.ВидНадбавкиToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.ВидНадбавкиToolStripMenuItem.Text = "Надбавки";
            // 
            // единицыИзмеренияToolStripMenuItem
            // 
            this.единицыИзмеренияToolStripMenuItem.Name = "единицыИзмеренияToolStripMenuItem";
            this.единицыИзмеренияToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.единицыИзмеренияToolStripMenuItem.Text = "Единицы измерения";
            this.единицыИзмеренияToolStripMenuItem.Visible = false;
            this.единицыИзмеренияToolStripMenuItem.Click += new System.EventHandler(this.единицыИзмеренияToolStripMenuItem_Click);
            // 
            // типНадбавкиToolStripMenuItem
            // 
            this.типНадбавкиToolStripMenuItem.Name = "типНадбавкиToolStripMenuItem";
            this.типНадбавкиToolStripMenuItem.Size = new System.Drawing.Size(186, 22);
            this.типНадбавкиToolStripMenuItem.Text = "Типы надбавок...";
            this.типНадбавкиToolStripMenuItem.Click += new System.EventHandler(this.типНадбавкиToolStripMenuItem_Click);
            // 
            // видToolStripMenuItem1
            // 
            this.видToolStripMenuItem1.Name = "видToolStripMenuItem1";
            this.видToolStripMenuItem1.Size = new System.Drawing.Size(186, 22);
            this.видToolStripMenuItem1.Text = "Виды надбавок...";
            this.видToolStripMenuItem1.Click += new System.EventHandler(this.видToolStripMenuItem1_Click);
            // 
            // toolStripSeparator8
            // 
            this.toolStripSeparator8.Name = "toolStripSeparator8";
            this.toolStripSeparator8.Size = new System.Drawing.Size(166, 6);
            // 
            // gRToolStripMenuItem
            // 
            this.gRToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.пКГToolStripMenuItem,
            this.категорияToolStripMenuItem,
            this.категорииПерсоналаToolStripMenuItem,
            this.видРаботыToolStripMenuItem});
            this.gRToolStripMenuItem.Name = "gRToolStripMenuItem";
            this.gRToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.gRToolStripMenuItem.Text = "Должности";
            // 
            // пКГToolStripMenuItem
            // 
            this.пКГToolStripMenuItem.Name = "пКГToolStripMenuItem";
            this.пКГToolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.пКГToolStripMenuItem.Text = "Профессионально-квалификационные группы...";
            this.пКГToolStripMenuItem.Click += new System.EventHandler(this.пКГToolStripMenuItem_Click);
            // 
            // категорияToolStripMenuItem
            // 
            this.категорияToolStripMenuItem.Name = "категорияToolStripMenuItem";
            this.категорияToolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.категорияToolStripMenuItem.Text = "Профессионально-квалификационные категории...";
            this.категорияToolStripMenuItem.Click += new System.EventHandler(this.категорияToolStripMenuItem_Click);
            // 
            // категорииПерсоналаToolStripMenuItem
            // 
            this.категорииПерсоналаToolStripMenuItem.Name = "категорииПерсоналаToolStripMenuItem";
            this.категорииПерсоналаToolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.категорииПерсоналаToolStripMenuItem.Text = "Категории персонала...";
            this.категорииПерсоналаToolStripMenuItem.Click += new System.EventHandler(this.категорииПерсоналаToolStripMenuItem_Click);
            // 
            // видРаботыToolStripMenuItem
            // 
            this.видРаботыToolStripMenuItem.Name = "видРаботыToolStripMenuItem";
            this.видРаботыToolStripMenuItem.Size = new System.Drawing.Size(361, 22);
            this.видРаботыToolStripMenuItem.Text = "Виды работ...";
            this.видРаботыToolStripMenuItem.Click += new System.EventHandler(this.видРаботыToolStripMenuItem_Click);
            // 
            // персоналToolStripMenuItem
            // 
            this.персоналToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.гражданствоToolStripMenuItem,
            this.семейноеПоложениеToolStripMenuItem});
            this.персоналToolStripMenuItem.Name = "персоналToolStripMenuItem";
            this.персоналToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.персоналToolStripMenuItem.Text = "Личные данные";
            // 
            // гражданствоToolStripMenuItem
            // 
            this.гражданствоToolStripMenuItem.Name = "гражданствоToolStripMenuItem";
            this.гражданствоToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.гражданствоToolStripMenuItem.Text = "Гражданство...";
            this.гражданствоToolStripMenuItem.Click += new System.EventHandler(this.гражданствоToolStripMenuItem_Click);
            // 
            // семейноеПоложениеToolStripMenuItem
            // 
            this.семейноеПоложениеToolStripMenuItem.Name = "семейноеПоложениеToolStripMenuItem";
            this.семейноеПоложениеToolStripMenuItem.Size = new System.Drawing.Size(205, 22);
            this.семейноеПоложениеToolStripMenuItem.Text = "Семейное положение...";
            this.семейноеПоложениеToolStripMenuItem.Click += new System.EventHandler(this.семейноеПоложениеToolStripMenuItem_Click);
            // 
            // приказыToolStripMenuItem
            // 
            this.приказыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.типыПриказовToolStripMenuItem,
            this.видыПриказовToolStripMenuItem,
            this.приказыМинистерстваToolStripMenuItem});
            this.приказыToolStripMenuItem.Name = "приказыToolStripMenuItem";
            this.приказыToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.приказыToolStripMenuItem.Text = "Приказы";
            // 
            // типыПриказовToolStripMenuItem
            // 
            this.типыПриказовToolStripMenuItem.Name = "типыПриказовToolStripMenuItem";
            this.типыПриказовToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.типыПриказовToolStripMenuItem.Text = "Типы приказов...";
            this.типыПриказовToolStripMenuItem.Click += new System.EventHandler(this.типыПриказовToolStripMenuItem_Click);
            // 
            // видыПриказовToolStripMenuItem
            // 
            this.видыПриказовToolStripMenuItem.Name = "видыПриказовToolStripMenuItem";
            this.видыПриказовToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.видыПриказовToolStripMenuItem.Text = "Виды приказов...";
            this.видыПриказовToolStripMenuItem.Click += new System.EventHandler(this.видыПриказовToolStripMenuItem_Click);
            // 
            // приказыМинистерстваToolStripMenuItem
            // 
            this.приказыМинистерстваToolStripMenuItem.Name = "приказыМинистерстваToolStripMenuItem";
            this.приказыМинистерстваToolStripMenuItem.Size = new System.Drawing.Size(212, 22);
            this.приказыМинистерстваToolStripMenuItem.Text = "Приказы министерства...";
            this.приказыМинистерстваToolStripMenuItem.Click += new System.EventHandler(this.приказыМинистерстваToolStripMenuItem_Click);
            // 
            // окладToolStripMenuItem
            // 
            this.окладToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.источникФинансированияToolStripMenuItem,
            this.базовыеОкладыToolStripMenuItem});
            this.окладToolStripMenuItem.Name = "окладToolStripMenuItem";
            this.окладToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.окладToolStripMenuItem.Text = "Финансирование";
            // 
            // источникФинансированияToolStripMenuItem
            // 
            this.источникФинансированияToolStripMenuItem.Name = "источникФинансированияToolStripMenuItem";
            this.источникФинансированияToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.источникФинансированияToolStripMenuItem.Text = "Источники финансирования...";
            this.источникФинансированияToolStripMenuItem.Click += new System.EventHandler(this.источникФинансированияToolStripMenuItem_Click);
            // 
            // базовыеОкладыToolStripMenuItem
            // 
            this.базовыеОкладыToolStripMenuItem.Name = "базовыеОкладыToolStripMenuItem";
            this.базовыеОкладыToolStripMenuItem.Size = new System.Drawing.Size(242, 22);
            this.базовыеОкладыToolStripMenuItem.Text = "Базовые оклады";
            this.базовыеОкладыToolStripMenuItem.Visible = false;
            this.базовыеОкладыToolStripMenuItem.Click += new System.EventHandler(this.базовыеОкладыToolStripMenuItem_Click);
            // 
            // совмещенияToolStripMenuItem
            // 
            this.совмещенияToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.причинаСовмещенияToolStripMenuItem});
            this.совмещенияToolStripMenuItem.Name = "совмещенияToolStripMenuItem";
            this.совмещенияToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.совмещенияToolStripMenuItem.Text = "Совмещения";
            // 
            // причинаСовмещенияToolStripMenuItem
            // 
            this.причинаСовмещенияToolStripMenuItem.Name = "причинаСовмещенияToolStripMenuItem";
            this.причинаСовмещенияToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.причинаСовмещенияToolStripMenuItem.Text = "Причины совмещения";
            this.причинаСовмещенияToolStripMenuItem.Click += new System.EventHandler(this.причинаСовмещенияToolStripMenuItem_Click);
            // 
            // табельToolStripMenuItem
            // 
            this.табельToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.статусДняToolStripMenuItem,
            this.графикиРаботыToolStripMenuItem});
            this.табельToolStripMenuItem.Name = "табельToolStripMenuItem";
            this.табельToolStripMenuItem.Size = new System.Drawing.Size(169, 22);
            this.табельToolStripMenuItem.Text = "Табель";
            this.табельToolStripMenuItem.Visible = false;
            // 
            // статусДняToolStripMenuItem
            // 
            this.статусДняToolStripMenuItem.Name = "статусДняToolStripMenuItem";
            this.статусДняToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.статусДняToolStripMenuItem.Text = "Статус дня";
            this.статусДняToolStripMenuItem.Click += new System.EventHandler(this.статусДняToolStripMenuItem_Click);
            // 
            // графикиРаботыToolStripMenuItem
            // 
            this.графикиРаботыToolStripMenuItem.Name = "графикиРаботыToolStripMenuItem";
            this.графикиРаботыToolStripMenuItem.Size = new System.Drawing.Size(166, 22);
            this.графикиРаботыToolStripMenuItem.Text = "Графики работы";
            this.графикиРаботыToolStripMenuItem.Click += new System.EventHandler(this.графикиРаботыToolStripMenuItem_Click);
            // 
            // отчётыToolStripMenuItem
            // 
            this.отчётыToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.графикБуренияToolStripMenuItem,
            this.надбавкиПоОтделамToolStripMenuItem,
            this.НастройкиToolStripMenuItem});
            this.отчётыToolStripMenuItem.Name = "отчётыToolStripMenuItem";
            this.отчётыToolStripMenuItem.Size = new System.Drawing.Size(60, 20);
            this.отчётыToolStripMenuItem.Text = "&Отчёты";
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(193, 6);
            // 
            // графикБуренияToolStripMenuItem
            // 
            this.графикБуренияToolStripMenuItem.Name = "графикБуренияToolStripMenuItem";
            this.графикБуренияToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.графикБуренияToolStripMenuItem.Text = "Вид надбавки";
            this.графикБуренияToolStripMenuItem.Click += new System.EventHandler(this.графикБуренияToolStripMenuItem_Click);
            // 
            // надбавкиПоОтделамToolStripMenuItem
            // 
            this.надбавкиПоОтделамToolStripMenuItem.Name = "надбавкиПоОтделамToolStripMenuItem";
            this.надбавкиПоОтделамToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.надбавкиПоОтделамToolStripMenuItem.Text = "Надбавки по отделам";
            this.надбавкиПоОтделамToolStripMenuItem.Click += new System.EventHandler(this.надбавкиПоОтделамToolStripMenuItem_Click);
            // 
            // НастройкиToolStripMenuItem
            // 
            this.НастройкиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.видыОтчетовToolStripMenuItem,
            this.последовательностьДанныхToolStripMenuItem});
            this.НастройкиToolStripMenuItem.Name = "НастройкиToolStripMenuItem";
            this.НастройкиToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.НастройкиToolStripMenuItem.Text = "Настройки (надбавки)";
            // 
            // видыОтчетовToolStripMenuItem
            // 
            this.видыОтчетовToolStripMenuItem.Name = "видыОтчетовToolStripMenuItem";
            this.видыОтчетовToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.видыОтчетовToolStripMenuItem.Text = "Виды отчетов";
            this.видыОтчетовToolStripMenuItem.Click += new System.EventHandler(this.видыОтчетовToolStripMenuItem_Click);
            // 
            // последовательностьДанныхToolStripMenuItem
            // 
            this.последовательностьДанныхToolStripMenuItem.Name = "последовательностьДанныхToolStripMenuItem";
            this.последовательностьДанныхToolStripMenuItem.Size = new System.Drawing.Size(232, 22);
            this.последовательностьДанныхToolStripMenuItem.Text = "Последовательность данных";
            this.последовательностьДанныхToolStripMenuItem.Click += new System.EventHandler(this.последовательностьДанныхToolStripMenuItem_Click);
            // 
            // правкаToolStripMenuItem
            // 
            this.правкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.отменитьToolStripMenuItem,
            this.повторитьToolStripMenuItem,
            this.toolStripMenuItem5,
            this.вырезатьToolStripMenuItem,
            this.копироватьToolStripMenuItem,
            this.вставитьToolStripMenuItem,
            this.toolStripMenuItem6,
            this.выделитьВсёToolStripMenuItem});
            this.правкаToolStripMenuItem.Name = "правкаToolStripMenuItem";
            this.правкаToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.правкаToolStripMenuItem.Text = "&Правка";
            this.правкаToolStripMenuItem.Visible = false;
            // 
            // отменитьToolStripMenuItem
            // 
            this.отменитьToolStripMenuItem.Image = global::Kadr.Properties.Resources.Edit_Undo;
            this.отменитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.отменитьToolStripMenuItem.Name = "отменитьToolStripMenuItem";
            this.отменитьToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.отменитьToolStripMenuItem.Text = "Отменить";
            // 
            // повторитьToolStripMenuItem
            // 
            this.повторитьToolStripMenuItem.Image = global::Kadr.Properties.Resources.Edit_Redo;
            this.повторитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.повторитьToolStripMenuItem.Name = "повторитьToolStripMenuItem";
            this.повторитьToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.повторитьToolStripMenuItem.Text = "Повторить";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(145, 6);
            // 
            // вырезатьToolStripMenuItem
            // 
            this.вырезатьToolStripMenuItem.Image = global::Kadr.Properties.Resources.Edit_Cut;
            this.вырезатьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.вырезатьToolStripMenuItem.Name = "вырезатьToolStripMenuItem";
            this.вырезатьToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.вырезатьToolStripMenuItem.Text = "Вырезать";
            // 
            // копироватьToolStripMenuItem
            // 
            this.копироватьToolStripMenuItem.Image = global::Kadr.Properties.Resources.CopyHS;
            this.копироватьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.копироватьToolStripMenuItem.Name = "копироватьToolStripMenuItem";
            this.копироватьToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.копироватьToolStripMenuItem.Text = "Копировать";
            // 
            // вставитьToolStripMenuItem
            // 
            this.вставитьToolStripMenuItem.Image = global::Kadr.Properties.Resources.PasteHS;
            this.вставитьToolStripMenuItem.ImageTransparentColor = System.Drawing.Color.Black;
            this.вставитьToolStripMenuItem.Name = "вставитьToolStripMenuItem";
            this.вставитьToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.вставитьToolStripMenuItem.Text = "Вставить";
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(145, 6);
            // 
            // выделитьВсёToolStripMenuItem
            // 
            this.выделитьВсёToolStripMenuItem.Name = "выделитьВсёToolStripMenuItem";
            this.выделитьВсёToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.выделитьВсёToolStripMenuItem.Text = "Выделить всё";
            // 
            // видToolStripMenuItem
            // 
            this.видToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.панельИнструментовToolStripMenuItem,
            this.строкаСтатусаToolStripMenuItem,
            this.деревоПромысловыхОбъектовToolStripMenuItem});
            this.видToolStripMenuItem.Name = "видToolStripMenuItem";
            this.видToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.видToolStripMenuItem.Text = "&Вид";
            this.видToolStripMenuItem.Visible = false;
            // 
            // панельИнструментовToolStripMenuItem
            // 
            this.панельИнструментовToolStripMenuItem.Name = "панельИнструментовToolStripMenuItem";
            this.панельИнструментовToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.панельИнструментовToolStripMenuItem.Text = "Панель инструментов";
            // 
            // строкаСтатусаToolStripMenuItem
            // 
            this.строкаСтатусаToolStripMenuItem.Name = "строкаСтатусаToolStripMenuItem";
            this.строкаСтатусаToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.строкаСтатусаToolStripMenuItem.Text = "Строка статуса";
            // 
            // деревоПромысловыхОбъектовToolStripMenuItem
            // 
            this.деревоПромысловыхОбъектовToolStripMenuItem.Name = "деревоПромысловыхОбъектовToolStripMenuItem";
            this.деревоПромысловыхОбъектовToolStripMenuItem.Size = new System.Drawing.Size(250, 22);
            this.деревоПромысловыхОбъектовToolStripMenuItem.Text = "Дерево промысловых объектов";
            // 
            // сервисToolStripMenuItem
            // 
            this.сервисToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.параметрыToolStripMenuItem});
            this.сервисToolStripMenuItem.Name = "сервисToolStripMenuItem";
            this.сервисToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.сервисToolStripMenuItem.Text = "Се&рвис";
            this.сервисToolStripMenuItem.Visible = false;
            // 
            // параметрыToolStripMenuItem
            // 
            this.параметрыToolStripMenuItem.Name = "параметрыToolStripMenuItem";
            this.параметрыToolStripMenuItem.Size = new System.Drawing.Size(67, 22);
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.оглавлениеToolStripMenuItem,
            this.toolStripSeparator1,
            this.ApplicationAboutStripMenuItem});
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справ&ка";
            // 
            // оглавлениеToolStripMenuItem
            // 
            this.оглавлениеToolStripMenuItem.Name = "оглавлениеToolStripMenuItem";
            this.оглавлениеToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.оглавлениеToolStripMenuItem.Text = "&Содержание...";
            this.оглавлениеToolStripMenuItem.Click += new System.EventHandler(this.оглавлениеToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(155, 6);
            // 
            // ApplicationAboutStripMenuItem
            // 
            this.ApplicationAboutStripMenuItem.Name = "ApplicationAboutStripMenuItem";
            this.ApplicationAboutStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.ApplicationAboutStripMenuItem.Text = "О программе...";
            this.ApplicationAboutStripMenuItem.Click += new System.EventHandler(this.ApplicationAboutStripMenuItem_Click);
            // 
            // treeNodeContextMenu
            // 
            this.treeNodeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem7,
            this.развернутьToolStripMenuItem,
            this.свернутьToolStripMenuItem,
            this.toolStripMenuItem8,
            this.показатьВсеToolStripMenuItem,
            this.свернутьВсеToolStripMenuItem,
            this.toolStripMenuItem9,
            this.обновитьToolStripMenuItem});
            this.treeNodeContextMenu.Name = "treeNodeContextMenu";
            this.treeNodeContextMenu.Size = new System.Drawing.Size(147, 132);
            // 
            // toolStripMenuItem7
            // 
            this.toolStripMenuItem7.Name = "toolStripMenuItem7";
            this.toolStripMenuItem7.Size = new System.Drawing.Size(143, 6);
            // 
            // развернутьToolStripMenuItem
            // 
            this.развернутьToolStripMenuItem.Name = "развернутьToolStripMenuItem";
            this.развернутьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.развернутьToolStripMenuItem.Text = "Развернуть";
            this.развернутьToolStripMenuItem.DropDownOpening += new System.EventHandler(this.развернутьToolStripMenuItem_DropDownOpening);
            this.развернутьToolStripMenuItem.Click += new System.EventHandler(this.развернутьToolStripMenuItem_Click);
            // 
            // свернутьToolStripMenuItem
            // 
            this.свернутьToolStripMenuItem.Name = "свернутьToolStripMenuItem";
            this.свернутьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.свернутьToolStripMenuItem.Text = "Свернуть";
            this.свернутьToolStripMenuItem.DropDownOpening += new System.EventHandler(this.свернутьToolStripMenuItem_DropDownOpening);
            this.свернутьToolStripMenuItem.Click += new System.EventHandler(this.свернутьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem8
            // 
            this.toolStripMenuItem8.Name = "toolStripMenuItem8";
            this.toolStripMenuItem8.Size = new System.Drawing.Size(143, 6);
            // 
            // показатьВсеToolStripMenuItem
            // 
            this.показатьВсеToolStripMenuItem.Name = "показатьВсеToolStripMenuItem";
            this.показатьВсеToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.показатьВсеToolStripMenuItem.Text = "Показать все";
            this.показатьВсеToolStripMenuItem.Click += new System.EventHandler(this.показатьВсеToolStripMenuItem_Click);
            // 
            // свернутьВсеToolStripMenuItem
            // 
            this.свернутьВсеToolStripMenuItem.Name = "свернутьВсеToolStripMenuItem";
            this.свернутьВсеToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.свернутьВсеToolStripMenuItem.Text = "Свернуть все";
            this.свернутьВсеToolStripMenuItem.Click += new System.EventHandler(this.свернутьВсеToolStripMenuItem_Click);
            // 
            // toolStripMenuItem9
            // 
            this.toolStripMenuItem9.Name = "toolStripMenuItem9";
            this.toolStripMenuItem9.Size = new System.Drawing.Size(143, 6);
            // 
            // обновитьToolStripMenuItem
            // 
            this.обновитьToolStripMenuItem.Name = "обновитьToolStripMenuItem";
            this.обновитьToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.обновитьToolStripMenuItem.Text = "Обновить";
            this.обновитьToolStripMenuItem.Click += new System.EventHandler(this.обновитьToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Checked = true;
            this.toolStripMenuItem1.CheckOnClick = true;
            this.toolStripMenuItem1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(205, 22);
            this.toolStripMenuItem1.Text = "Текущие сотрудники";
            // 
            // departmentBindingSource
            // 
            this.departmentBindingSource.DataSource = typeof(Kadr.Data.Department);
            // 
            // kadrTreeView1
            // 
            this.kadrTreeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.kadrTreeView1.ImageIndex = 0;
            this.kadrTreeView1.ImageList = this.treeViewImageList;
            this.kadrTreeView1.Location = new System.Drawing.Point(0, 0);
            this.kadrTreeView1.Name = "kadrTreeView1";
            this.kadrTreeView1.SelectedImageIndex = 0;
            this.kadrTreeView1.Size = new System.Drawing.Size(191, 387);
            this.kadrTreeView1.TabIndex = 0;
            this.kadrTreeView1.NodeChildsAddedEvent += new APG.CodeHelper.DBTreeView.NodeChildsAdded(this.kadrTreeView1_NodeChildsAddedEvent);
            this.kadrTreeView1.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.kadrTreeView1_BeforeSelect);
            this.kadrTreeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.kadrTreeView1_AfterSelect);
            this.kadrTreeView1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.kadrTreeView1_MouseClick);
            // 
            // KadrBaseForm
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(835, 462);
            this.Controls.Add(this.toolStripContainer1);
            this.helpProvider1.SetHelpKeyword(this, "Главное окно программы");
            this.helpProvider1.SetHelpNavigator(this, System.Windows.Forms.HelpNavigator.TableOfContents);
            this.helpProvider1.SetHelpString(this, "");
            this.Name = "KadrBaseForm";
            this.helpProvider1.SetShowHelp(this, true);
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "АИС \"Штатное расписание\"";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.KadrBaseForm_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.KadrBaseForm_FormClosed);
            this.Load += new System.EventHandler(this.KadrBaseForm_Load);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.KadrBaseForm_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.KadrBaseForm_DragEnter);
            toolStrip1.ResumeLayout(false);
            toolStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.treeNodeContextMenu.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.departmentBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        protected System.Windows.Forms.ToolStripContainer toolStripContainer1;
        protected System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem правкаToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem справочникиToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem сервисToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem оглавлениеToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem ApplicationAboutStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem параметрыToolStripMenuItem;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        protected System.Windows.Forms.ToolStripMenuItem отчётыToolStripMenuItem;
        protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        protected System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        protected System.Windows.Forms.ToolStripMenuItem расширенныйПоискToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem печатьToolStripMenuItem;
        protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        protected System.Windows.Forms.ToolStripMenuItem отменитьToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem повторитьToolStripMenuItem;
        protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        protected System.Windows.Forms.ToolStripMenuItem вырезатьToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem копироватьToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem вставитьToolStripMenuItem;
        protected System.Windows.Forms.ToolStripSeparator toolStripMenuItem6;
        protected System.Windows.Forms.ToolStripMenuItem выделитьВсёToolStripMenuItem;
        protected System.Windows.Forms.SplitContainer splitContainer1;
        protected System.Windows.Forms.ToolStripMenuItem ВидНадбавкиToolStripMenuItem;
        protected System.Windows.Forms.MenuStrip menuStrip1;
        protected System.Windows.Forms.HelpProvider helpProvider1;
        protected System.Windows.Forms.StatusStrip statusStrip1;
        protected System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem панельИнструментовToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem строкаСтатусаToolStripMenuItem;
        protected System.Windows.Forms.ToolStripMenuItem деревоПромысловыхОбъектовToolStripMenuItem;
        protected System.Windows.Forms.ToolStripSplitButton tsbNew;
        protected System.Windows.Forms.ToolStripButton tsbDelete;
        protected System.Windows.Forms.ToolStripButton tsbEdit;
        protected System.Windows.Forms.ToolStripButton tsbUpdate;
        protected System.Windows.Forms.ToolStripButton tsbCut;
        protected System.Windows.Forms.ToolStripButton tsbCopy;
        protected System.Windows.Forms.ToolStripButton tsbPaste;
        protected System.Windows.Forms.ToolStripSplitButton RollbackMenuItem;
        protected System.Windows.Forms.ToolStripSplitButton RedoMenuItem;
        protected System.Windows.Forms.ToolStripSplitButton toolStripSplitButton1;
        private System.ComponentModel.IContainer components;
        private System.Windows.Forms.ImageList treeViewImageList;
        private System.Windows.Forms.ContextMenuStrip treeNodeContextMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem7;
        private System.Windows.Forms.ToolStripMenuItem развернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem8;
        private System.Windows.Forms.ToolStripMenuItem показатьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem свернутьВсеToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem9;
        private System.Windows.Forms.ToolStripMenuItem обновитьToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripTextBox1;
        private System.Windows.Forms.ToolStripMenuItem miImport;
        private System.Windows.Forms.ToolStripMenuItem miExportReport;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem импортироватьСуточныйРапортToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикБуренияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem11;
        private System.Windows.Forms.ToolStripMenuItem tsmiActions;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator8;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem12;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator9;
        private System.Windows.Forms.ToolStripMenuItem типНадбавкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem gRToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem пКГToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видРаботыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem персоналToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem гражданствоToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem семейноеПоложениеToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem категорииПерсоналаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem окладToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton tsbEmployeeFilter;
        private System.Windows.Forms.ToolStripMenuItem tsmiCurrentEmployees;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator11;
        private System.Windows.Forms.ToolStripMenuItem приказыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem типыПриказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видыПриказовToolStripMenuItem;
        private System.Windows.Forms.ToolStripSplitButton tsbDepartmentFilter;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem13;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem14;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem источникФинансированияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem базовыеОкладыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem приказыМинистерстваToolStripMenuItem;
        protected KadrTreeView.KadrTreeView kadrTreeView1;
        private System.Windows.Forms.ToolStripMenuItem единицыИзмеренияToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel CurrentObjectLabel;
        private System.Windows.Forms.ToolStripMenuItem совмещенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem причинаСовмещенияToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel CurrentObjectInfoLabel;
        private System.Windows.Forms.BindingSource departmentBindingSource;
        protected System.Windows.Forms.ToolStripComboBox tscbTextSearch;
        private System.Windows.Forms.ToolStripComboBox tscbFindType;
        private System.Windows.Forms.ToolStripMenuItem надбавкиПоОтделамToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem табельToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem статусДняToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem графикиРаботыToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem НастройкиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видыОтчетовToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem последовательностьДанныхToolStripMenuItem;

    }
}
