﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Dialogs;
using Kadr.UI.Frames;
using Kadr.KadrTreeView;
using Kadr.Data.Common;
using Kadr.Controllers;
using Reports.Forms;
using System.Linq;
using APG.CodeHelper.UI;
using Kadr.Data;
using Kadr.UI.Common;
using Kadr.Interfaces;

namespace Kadr.UI.Forms
{
    public partial class KadrBaseForm : Form
    {
        #region Private fields
        private readonly APG.CodeHelper.Actions.ActionManager _actionManager = new APG.CodeHelper.Actions.ActionManager();
        private Kadr.UI.Frames.KadrBaseFrame _activeFrame;
        private ToolStripItem _actionMenuStripItem;
        private APG.CodeHelper.ContextMenuHelper.ContextMenuBuilder _contextMenuBuilder;
        private APG.CodeHelper.ContextMenuHelper.ContextMenuBuilder _actionButtonDropDownMenuBuilder;
        private readonly IKeyValueStorage _storage = new KeyValueStorage();


        internal APG.CodeHelper.ContextMenuHelper.ContextMenuBuilder ActionButtonDropDownMenuBuilder
        {
            get { return _actionButtonDropDownMenuBuilder; }
            
        }

        internal APG.CodeHelper.ContextMenuHelper.ContextMenuBuilder ContextMenuBuilder
        {
            get { return _contextMenuBuilder; }
        }

        /// <summary>
        /// Получает элмент меню, куда добавляются дополнительные действия
        /// </summary>
        public ToolStripItem ActionMenuStripItem
        {
            get { return _actionMenuStripItem; }
        }

        //
        private readonly ToolStripItem[] _nodeContextItems = new ToolStripItem[9]; 

        #endregion

        #region Private Methods

        private void CreateNodeContextItems()
        {
            _nodeContextItems[0] = new ToolStripMenuItem();
            _nodeContextItems[0].Text = "Развернуть";
            _nodeContextItems[0].Click += new EventHandler(развернутьToolStripMenuItem_Click);
           
            _nodeContextItems[1] = new ToolStripMenuItem();
            _nodeContextItems[1].Text = "Свернуть";
            _nodeContextItems[1].Click += new EventHandler(свернутьToolStripMenuItem_Click);

            _nodeContextItems[2] = new ToolStripSeparator();

            _nodeContextItems[3] = new ToolStripMenuItem();
            _nodeContextItems[3].Text = "Показать все";
            _nodeContextItems[3].Click += new EventHandler(показатьВсеToolStripMenuItem_Click);

            _nodeContextItems[4] = new ToolStripMenuItem();
            _nodeContextItems[4].Text = "Свернуть все";
            _nodeContextItems[4].Click += new EventHandler(свернутьВсеToolStripMenuItem_Click);
            
            _nodeContextItems[5] = new ToolStripSeparator();

            _nodeContextItems[6] = new ToolStripMenuItem();
            _nodeContextItems[6].Text = "Обновить";
            _nodeContextItems[6].Click += new EventHandler(обновитьToolStripMenuItem_Click);

            _nodeContextItems[7] = new ToolStripSeparator();

            _nodeContextItems[8] = new ToolStripMenuItem();
            _nodeContextItems[8].Text = "Действия";
            _nodeContextItems[8].Image = treeViewImageList.Images[4];
            _actionMenuStripItem = _nodeContextItems[8];

            //ContextMenuBuilder
            _contextMenuBuilder = new APG.CodeHelper.ContextMenuHelper.ContextMenuBuilder(treeNodeContextMenu, null,
                ActionMenuStripItem)
            {
                UserData = kadrTreeView1
            };
            _actionButtonDropDownMenuBuilder =
                new APG.CodeHelper.ContextMenuHelper.ContextMenuBuilder(tsbNew.DropDownItems, null)
                {
                    UserData = kadrTreeView1
                };

        }

        private void OnCommandExecute(object sender, EventArgs e)
        {
            RollbackMenuItem.Enabled = (sender as APG.CodeHelper.Actions.ActionManager).Executed.Count > 0;
        }

        private void OnCommandRollback(object sender, EventArgs e)
        {
            RedoMenuItem.Enabled = (sender as APG.CodeHelper.Actions.ActionManager).Rollbacked.Count > 0;
        }

        private void ExitApplication()
        {
            if (DisposeActiveFrame())
                Application.Exit();
        }

        private void ShowApplicationAbout()
        {
            using (var dlg = new ApplicationAboutDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void ApplicationAboutStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowApplicationAbout();
        }

        private void ExitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitApplication();
        }

        private void RollbackMenuItem_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void CreateUndoRedoDropDownMenu(ToolStripSplitButton toolStripSplitButton, Stack<APG.CodeHelper.Actions.IAction> sourceItems)
        {
            ToolStripItem tsi;
            toolStripSplitButton.DropDownItems.Clear();

            foreach (APG.CodeHelper.Actions.IAction command in sourceItems)
            {
                tsi = new ToolStripMenuItem();
                tsi.Text = command.ToString();
                toolStripSplitButton.DropDownItems.Add(tsi);
            }

        }

        private void RollbackMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            CreateUndoRedoDropDownMenu(sender as ToolStripSplitButton, Commands.Executed);
        }

        private void RedoMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            CreateUndoRedoDropDownMenu(sender as ToolStripSplitButton, Commands.Rollbacked);
        }

        
        private static void EnterSearchComboBox(object sender)
        {
            // Очистка текста "введите текст" в окне поиска при установке фокуса
            (sender as ToolStripComboBox).ForeColor = SystemColors.WindowText;
            (sender as ToolStripComboBox).Text = "";
        }


        private static void LeaveSearchComboBox(object sender)
        {
            // При потере фокуса окном ввода запроса устанавливается текст "Введите текст"
            (sender as ToolStripComboBox).Text = "Введите текст";
            (sender as ToolStripComboBox).ForeColor = Color.Gray;
        }




        // Вызов контекстного меню для узла дерева 
        private void kadrTreeView1_MouseClick(object sender, MouseEventArgs e)
        {
            if ((SelectedObject == null) || (SelectedObject.NodeContextMenuStrip == null))
                return;

            if (e.Button == MouseButtons.Right)
            {
                SelectedObject.NodeContextMenuStrip.Items.AddRange(_nodeContextItems);
                //SelectedObject.NodeContextMenuStrip.Show(e.Location);
                ContextMenuBuilder.ContextMenuStrip = SelectedObject.NodeContextMenuStrip;
                ContextMenuBuilder.Receiver = SelectedObject.Actions;
                ContextMenuBuilder.PopupMenu(this, e.X, e.Y);
            }
        }

        private void kadrTreeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            // Переход на новый узел дерева вызывает отображение кадра, связанного  с 
            // заданным объектом узла
            ShowSelectedNodeFrame(e);

            // Назначает состояние элементам панели инструментов (toolStrip1) 
            // на основании возможности выполнения действий выбранным узлом
            // (метод UIAction.CanDoThis(UIObjectAction action))
            AssignToolStripItemState(sender);          

        }

        private void AssignToolStripItemState(object sender)
        {
            if (SelectedActions != null)
            {
                //tsbNew.Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taAdd];
                tsbDelete.Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taDelete];
                tsbEdit.Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taUpdate];

                //tsbNew.Enabled = SelectedActions.CanDoThis(sender, APG.CodeHelper.Actions.UIObjectAction.taAdd);
                tsbDelete.Enabled = SelectedActions.CanDoThis(sender, APG.CodeHelper.Actions.UIObjectAction.taDelete);
                tsbEdit.Enabled = SelectedActions.CanDoThis(sender, APG.CodeHelper.Actions.UIObjectAction.taUpdate);
                tsbCopy.Enabled = SelectedActions.CanDoThis(sender, APG.CodeHelper.Actions.UIObjectAction.taCopy);
                tsbPaste.Enabled = SelectedActions.CanDoThis(sender, APG.CodeHelper.Actions.UIObjectAction.taPaste);
                tsbCut.Enabled = SelectedActions.CanDoThis(sender, APG.CodeHelper.Actions.UIObjectAction.taCut);
            }
        }

        // Вызов отображения кадра для текущего узла дерева
        private void ShowSelectedNodeFrame(TreeViewEventArgs e)
        {
            System.Type frame = null;

            // Получить тип отображения, связанный с узлом
            Kadr.KadrTreeView.KadrNodeObject obj = (e.Node.Tag as Kadr.KadrTreeView.KadrNodeObject);

            // Связан ли с узлом объект и является ли объект типом DBTreeNodeObject
            if (obj != null)
            {
                frame = obj.ObjectViewType;


                        //Отобразить кадр
                        Frame = frame;

                CurrentObjectLabel.Text = obj.GetObjectName();
                
                CurrentObjectInfoLabel.Text = obj.GetObjectInfo();
                if (CurrentObjectInfoLabel.Text == "")
                    CurrentObjectInfoLabel.Visible = false;
                else
                    CurrentObjectInfoLabel.Visible = true;

               // (obj as Kadr.KadrTreeView.KadrNodeObject).GetObjectStatus();

                //если объект - отдел, отображаем фильтр по сотрудникам 
                if (obj is Kadr.KadrTreeView.RootNodeObject)
                {
                    tsbEmployeeFilter.Visible = true;
                    tsbDepartmentFilter.Visible = true;

                     //устанавливаем фильтр 
                    /*ArrayList EmployeeFilters = (_activeFrame.FrameNodeObject as RootNodeObject).ObjectFilters;
                    for (ObjectState objectState = ObjectState.Current; objectState <= ObjectState.Canceled; objectState++)
                    {
                        (tsbEmployeeFilter.DropDownItems[(int)objectState] as ToolStripMenuItem).Checked =
                            EmployeeFilters.Contains(objectState);
                    }

                    //устанавливаем фильтр 
                    ArrayList DepartmentFilters = (_activeFrame.FrameNodeObject as RootNodeObject).DepartmentFilters;
                    for (ObjectState objectState = ObjectState.Current; objectState <= ObjectState.Canceled; objectState++)
                    {
                        (tsbDepartmentFilter.DropDownItems[(int)objectState] as ToolStripMenuItem).Checked =
                            DepartmentFilters.Contains(objectState);
                    }*/

                    
                }
                else
                {
                    tsbEmployeeFilter.Visible = false;
                    tsbDepartmentFilter.Visible = false;

                }
            }


        }

        // Обновление предcтавления узла
        private void tsbUpdate_Click(object sender, EventArgs e)
        {
            if (SelectedObject != null)
            {
               // if (!(SelectedObject.Node.IsExpanded()))
                KadrController.Instance.DeleteModel();
                SelectedObject.Refresh();
            }
            
            if (ActiveFrame != null)
                ActiveFrame.RefreshFrame();

        }

        // Изменение заголовка кнопки добавления  объекта
        private void tsbNew_MouseEnter(object sender, EventArgs e)
        {
            //(sender as ToolStripItem).Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taAdd];
        }

        // Вызов действия удаления объекта
        private void tsbDelete_Click(object sender, EventArgs e)
        {
            if (SelectedActions != null)
            {
                SelectedActions.Execute(this, APG.CodeHelper.Actions.UIObjectAction.taDelete);
            }
        }

        // Вызов действия редактирования объекта
        private void tsbEdit_Click(object sender, EventArgs e)
        {
            if (SelectedActions != null)
            {
                SelectedActions.Execute(this, APG.CodeHelper.Actions.UIObjectAction.taUpdate);
            }
        }

        // Вызов действия вырезки объекта
        private void tsbCut_Click(object sender, EventArgs e)
        {
            (sender as ToolStripItem).Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taCut];
        }

        // Вызов действия копирования объекта
        private void tsbCopy_Click(object sender, EventArgs e)
        {
            (sender as ToolStripItem).Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taCopy];
        }

        // Вызов действия вставки объекта
        private void tsbPaste_Click(object sender, EventArgs e)
        {
            (sender as ToolStripItem).Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taPaste];
        }

        // Изменение заголовка кнопки удаления  объекта
        private void tsbDelete_MouseEnter(object sender, EventArgs e)
        {
           // (sender as ToolStripItem).Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taDelete];
        }

        // Изменение заголовка кнопки редактирования  объекта
        private void tsbEdit_MouseEnter(object sender, EventArgs e)
        {
            (sender as ToolStripItem).Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taUpdate];
        }

        // Изменение заголовка кнопки вырезки  объекта
        private void tsbCut_MouseEnter(object sender, EventArgs e)
        {
            (sender as ToolStripItem).Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taCut];
        }

        // Изменение заголовка кнопки копирования  объекта
        private void tsbCopy_MouseEnter(object sender, EventArgs e)
        {
            (sender as ToolStripItem).Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taCopy];
        }
        // Изменение заголовка кнопки вставки  объекта
        private void tsbPaste_MouseEnter(object sender, EventArgs e)
        {
            (sender as ToolStripItem).Text = SelectedActions[APG.CodeHelper.Actions.UIObjectAction.taPaste];
        }

        private void развернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedObject.Node.Expand();
        }

        private void свернутьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedObject.Node.Collapse(true);
        }

        private void показатьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedObject.Node.ExpandAll();
        }

        private void свернутьВсеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedObject.Node.Collapse(false);
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SelectedObject.Refresh();
        }

        private void развернутьToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Enabled = !(SelectedObject.Node.IsExpanded);
        }

        private void свернутьToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            (sender as ToolStripMenuItem).Enabled = SelectedObject.Node.IsExpanded;
        }



        private void KadrBaseForm_Load(object sender, EventArgs e)
        {
            KadrController.Instance.CheckDataBaseVersion();
            //ImportDailyReportFiles();
            kadrTreeView1.CreateRootNodes();
            CreateNodeContextItems();
            SetupFormTitle();
            tscbFindType.SelectedIndex = 0;

            //kadrTreeView1.FindAndSelectDepartment(Kadr.Controllers.KadrController.Instance.Model.Departments.Where(x => x.id ==63 ).FirstOrDefault());
        }

        private void SetupFormTitle()
        {
            var conn = KadrController.Instance.Model.Connection;
            var purpose = string.Empty;
            if (conn!=null)
                switch (conn.GetDbPurpose())
                {
                    case DbConnectionPurpose.Release:
                        break;
                    case DbConnectionPurpose.LocalDebug:
                        purpose = " - Для отладки";
                        break;
                    case DbConnectionPurpose.PublicTest:
                        purpose = " - Для тестов";
                        break;
                    case DbConnectionPurpose.Unknown:
                        purpose = " - Назначение не известно";
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            Text = string.Format("{0} ({1}) {2}", "ИС \"Кадры\" УГТУ", DateTime.Today.ToShortDateString(), purpose);
        }

        // Импортирует файлы, переданные через командную сроку
        //private void ImportDailyReportFiles()
        //{            
        //    if (Environment.GetCommandLineArgs().Length > 1)
        //    {
        //        string[] args = new string[Environment.GetCommandLineArgs().Length - 1];
        //        for (int i = 1; i < Environment.GetCommandLineArgs().Length; i++)
        //        {
        //            args[i-1] = Environment.GetCommandLineArgs()[i];
        //        }
        //        ISGB.Controllers.ISGBDailyReportImportExportController.Instance.ImportDocuments(args);
        //    }

        //}

        private void frame_FrameDataChangedEvent(object sender, Kadr.UI.Frames.FrameDataChangedArgs e)
        {
            if ((SelectedObject != null))
            {
                SelectedObject.Notify(sender);
            }
        }

        #endregion

        #region Protected Methods

        protected Kadr.UI.Frames.KadrBaseFrame CreateFrame(System.Type frameType, System.Windows.Forms.Control parent)
        {
            return CreateFrame(frameType, parent, null);
        }

        /// <summary>
        /// Пул фреймов различных типов для повторного использования
        /// </summary>
        //private IDictionary<string, ISGBBaseFrame> framePool = 
        //    new Dictionary<string, ISGBBaseFrame>(10);
        /// <summary>
        ///  Создаёт новый объект фрейма по его типу, размещает его на панели просмотра и обновляет его содержание через
        ///  задание свойства FrameObject и метод RefreshFrame().
        ///  Если объект заданного типа уже существует, то новый объект не создаётся, а извлекается из пула.
        /// </summary>
        /// <param name="frameType">Тип фрейма для создания</param>
        /// <param name="parent">Объект System.Windows.Forms.Control где будет распологаться фрейм</param>
        /// <param name="AObject">Пользовательский объект фрейма</param>
        /// <returns>Объект типа ISGB.Frames.ISGBBaseFrame</returns>
        protected Kadr.UI.Frames.KadrBaseFrame CreateFrame(System.Type frameType, System.Windows.Forms.Control parent, object AObject)
        {
            Kadr.UI.Frames.KadrBaseFrame frame = null;

            //try
            //{
                //if (framePool.ContainsKey(frameType.FullName))
                //{
                //    frame = framePool[frameType.FullName];           
                //}
                //else
                //{
                // Если фрейм уже создан, то извелечь его из пула
                // Объект такого типа фрейма ещё не создавался

                frame = Activator.CreateInstance(frameType, AObject) as Kadr.UI.Frames.KadrBaseFrame;
                frame.FrameDataChangedEvent += new Kadr.UI.Frames.FrameDataChangedDelegate(frame_FrameDataChangedEvent);
                //    framePool.Add(frameType.FullName, frame);
                // }
                frame.FrameObject = AObject;
                frame.FrameGuiObject = kadrTreeView1.SelectedNode;
                frame.FrameNodeObject = kadrTreeView1.SelectedObject;
                frame.Parent = parent;
                frame.Dock = DockStyle.Fill;

                // Связать фрейм с текущим узлом
                BindCurrentFrameWithNodeObject(frame);

                //зарегестрировать фрейм в качестве предсталения 
                KadrController.Instance.AddView(frame);

                if (frame is KadrEmployeeFrame)
                {
                    //tsbBonusFilter.Visible = true;
                    //устанавливаем фильтр на фрейме
                    CopyFilter(tsbBonusFilter, (frame as KadrEmployeeFrame).tsbBonusFilter);
                }

                if (frame is KadrRootFrame)
                {
                    (frame as KadrRootFrame).BonusFilterSetting = ObjectStateController.Instance.GetObjectStatesForFilter(tsbBonusFilter, null);
                    (frame as KadrRootFrame).DepFilterSetting = ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepartmentFilter, null);
                    (frame as KadrRootFrame).StaffFilterSetting = ObjectStateController.Instance.GetObjectStatesForFilter(tsbEmployeeFilter, null);
                }

                frame.RefreshFrame();

                frame.Show();
            //}
            /*catch (Exception)
            {
                if (frame != null)
                {
                    frame.Dispose();
                    frame = null;
                }
                throw;
            }*/

            return frame;
        }

        // Связывает созданный фрейм с узлом текущим дерева
        private void BindCurrentFrameWithNodeObject(Kadr.UI.Frames.KadrBaseFrame frame)
        {
            BindCurrentFrameWithNodeObject(frame, SelectedObject);
        }

        // Связывает фрейм с заданным узлом дерева
        private void BindCurrentFrameWithNodeObject(Kadr.UI.Frames.KadrBaseFrame kadrBaseFrame, APG.CodeHelper.DBTreeView.DBTreeNodeObject SelectedObject)
        {
            if ((SelectedObject != null) && (kadrBaseFrame != null))
            {
                SelectedObject.ObjectView = kadrBaseFrame;
                //kadrBaseFrame.RestoreFrameState(SelectedObject.Store);
            }
        }

        #endregion

        #region Public properties

        public APG.CodeHelper.Actions.ActionManager Commands
        {
            get { return _actionManager; }
        }

        public Kadr.UI.Frames.KadrBaseFrame ActiveFrame
        {
            get { return _activeFrame; }
        }

        public System.Type Frame
        {
            set
            {
                if (DisposeActiveFrame())
                    if (value != null)
                    {
                        _activeFrame = CreateFrame(value, splitContainer1.Panel2, kadrTreeView1.SelectedObject);
                        _activeFrame.Restore(_storage);
                        _activeFrame.Caption = kadrTreeView1.SelectedNode.FullPath;
                    }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private bool DisposeActiveFrame()
        {
            bool result = true;

            if (_activeFrame != null)
            {
                _activeFrame.Store(_storage);
                if (_activeFrame.IsModified)
                {
                    switch (MessageBox.Show(string.Format("Данные кадра \"{0}\" были изменены.\nСледует сохранить изменения в базе данных?", _activeFrame.FrameName), "Сохранение данных", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question))
                    {
                        case DialogResult.Yes:
                            _activeFrame.Apply();
                            DisposeActiveFrameInternal();
                            break;
                        case DialogResult.No:
                            _activeFrame.Cancel();
                            DisposeActiveFrameInternal();
                            break;
                        default:
                            result = false;
                            break;
                    }
                    
                }
                else
                    DisposeActiveFrameInternal();
            }
            

            return result;
        }

        private void DisposeActiveFrameInternal()
        {
            if (_activeFrame != null)
            {
                //_activeFrame.Dispose();
                _activeFrame.IsModified = false;
                _activeFrame.Hide();
                _activeFrame = null;
            }
        }

        public APG.CodeHelper.DBTreeView.DBTreeNodeObject SelectedObject
        {
            get { return kadrTreeView1.SelectedObject; }
        }

        public APG.CodeHelper.DBTreeView.DBTreeNodeAction SelectedActions
        {
            get { return kadrTreeView1.SelectedActions; }
        }

        #endregion

        #region Public Methods

        public KadrBaseForm()
        {
            InitializeComponent();

            LeaveSearchComboBox(this.tscbTextSearch);

            Commands.OnExecute += new EventHandler(OnCommandExecute);
            Commands.OnRollback += new EventHandler(OnCommandRollback);

            //KadrController.Instance.AddView(kadrTreeView1);
        }

        #endregion

        private void KadrBaseForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (!DisposeActiveFrame());
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            //using (System.Windows.Forms.Form dlg = new ISGB.Dialogs.ISGBSteelDialog())
            //{
            //    dlg.ShowDialog();
            //}
        }

        private void tsbNew_ButtonClick(object sender, EventArgs e)
        {
            if (SelectedActions != null)
            {
                SelectedActions.Execute(this, APG.CodeHelper.Actions.UIObjectAction.taAdd);
            }
        }

        private void tsbUpdate_MouseEnter(object sender, EventArgs e)
        {
            if (SelectedObject != null)
            {
                (sender as ToolStripItem).Text = string.Format("Обновить: {0}", SelectedObject.Node.Text);
            }
        }

        private void KadrBaseForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            //if (e.CloseReason == CloseReason.ApplicationExitCall)
            //{
            //    ISGB.Properties.Settings.Default.Save();
            //}
        }

        private void kadrTreeView1_NodeChildsAddedEvent(object sender, EventArgs e)
        {
            if (ActiveFrame != null)
                ActiveFrame.RefreshFrame();
        }

        private void оглавлениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, helpProvider1.HelpNamespace);
        }

        private void toolStripTextBox1_DropDownOpening(object sender, EventArgs e)
        {
            //if (SelectedObject is ReportNodeObject)
            //{
            //    miExportReport.Text = string.Format("Экспортировать {0}...", SelectedObject.Node.Text);
            //    miExportReport.Enabled = true;
            //}
            //else
            //    miExportReport.Enabled = false;
        }

        private void miExportReport_Click(object sender, EventArgs e)
        {
            //ExportDayliReport();
        }


        private void импортироватьСуточныйРапортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //ImportDayliReport();
        }


        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {
        }


        private void miImport_Click(object sender, EventArgs e)
        {
            //ImportDictionaries();
        }


        private void tsbNew_DropDownOpening(object sender, EventArgs e)
        {
            BuildActionDropDownMenu();
        }

        private void BuildActionDropDownMenu()
        {
            ActionButtonDropDownMenuBuilder.Receiver = SelectedActions;
            ActionButtonDropDownMenuBuilder.BuildToolStripItemCollection();
        }


        private void tsmiActions_DropDownOpening(object sender, EventArgs e)
        {
            BuildActionDropDownMenu();
            tsmiActions.DropDown.Items.Clear();
            ToolStripItem[] items = new ToolStripItem[ActionButtonDropDownMenuBuilder.ToolStripItemCollection.Count];
            ActionButtonDropDownMenuBuilder.ToolStripItemCollection.CopyTo(items, 0);
            tsmiActions.DropDown.Items.AddRange(items);
        }

        private void KadrBaseForm_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent("FileDrop"))
            {
                e.Effect = DragDropEffects.Link;
            }
            else
                e.Effect = DragDropEffects.None;

            //foreach (string f in e.Data.GetFormats())
            //{
            //    System.Diagnostics.Debug.WriteLine(f);
            //}
        }

        private delegate void ImportDocsDelegate();

        private void KadrBaseForm_DragDrop(object sender, DragEventArgs e)
        {
            //string[] files = (string[])e.Data.GetData("FileDrop");
            //if (files != null)
            //{
            //    ImportDocsDelegate importDocsDelegate = delegate()
            //    {
            //        Controllers.ISGBDailyReportImportExportController.Instance.ImportDocuments(files);
            //    };

            //    this.BeginInvoke(importDocsDelegate);
            //    //Controllers.ISGBDailyReportImportExportController.Instance.ImportDocuments(files);
            //}
        }


        private void справочникиToolStripMenuItem_DropDownOpened(object sender, EventArgs e)
        {
        }

        private void kadrTreeView1_BeforeSelect(object sender, TreeViewCancelEventArgs e)
        {
            //SelectedObject.Node
            if ((ActiveFrame != null) && (SelectedObject != null))
                ActiveFrame.Store(_storage);
        }


        private void toolStripMenuItem12_Click(object sender, EventArgs e)
        {
            //ExportDictionaries(true);
        }


        /// <summary>
        /// Справочник типов надбавок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void типНадбавкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BonusSuperTypeDialog dlg = new BonusSuperTypeDialog())
            {
                //dlg.UseInternalCommandManager = true;
                //dlg.Text = "Редактирование штатного расписания отдела " + Department.DepartmentName;

                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Справочник видов надбавок
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void видToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (BonusTypeDialog dlg = new BonusTypeDialog())
            {
                dlg.ShowDialog();
            }
        }


        /// <summary>
        /// Справочник профессионально-квалификационных групп
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void пКГToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PKGroupDialog dlg = new PKGroupDialog())
            {
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Справочник видов работ
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void видРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (WorkTypeDialog dlg = new WorkTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Справочник Гражданство
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void гражданствоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GrazdDialog dlg = new GrazdDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void семейноеПоложениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SemPolDialog dlg = new SemPolDialog())
            {
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// Профессионально-квалификационная категория
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void категорияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PKCategoryDialog dlg = new PKCategoryDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void должностьToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void категорииПерсоналаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CategoryDialog dlg = new CategoryDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void tsbEmployeeFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (_activeFrame is KadrRootFrame)
            {
                (_activeFrame.FrameNodeObject as RootNodeObject).ObjectFilters = ObjectStateController.Instance.GetObjectStatesForFilter(tsbEmployeeFilter, e);
                (ActiveFrame as KadrRootFrame).StaffFilterSetting = ObjectStateController.Instance.GetObjectStatesForFilter(tsbEmployeeFilter, e); //tspHourFactStaffFilter
            }
        }

        private void tsbDepartmentFilter_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //ищем самый верхний узел дерева 
            //RootNodeObject MainParent = 
            //(_activeFrame.FrameNodeObject as RootNodeObject).Parent
            if (_activeFrame is KadrRootFrame)
            {
                (_activeFrame.FrameNodeObject as RootNodeObject).DepartmentFilters = ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepartmentFilter, e);
                (ActiveFrame as KadrRootFrame).DepFilterSetting = ObjectStateController.Instance.GetObjectStatesForFilter(tsbDepartmentFilter, e);
            }
        }

        private void типыПриказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrikazSuperTypeDialog dlg = new PrikazSuperTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void видыПриказовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PrikazTypeDialog dlg = new PrikazTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void источникФинансированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FinancingSourceDialog dlg = new FinancingSourceDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void базовыеОкладыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SalaryDialog dlg = new SalaryDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void приказыМинистерстваToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (GlobalPrikazDialog dlg = new GlobalPrikazDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void единицыИзмеренияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BonusMeasureDialog dlg = new BonusMeasureDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void причинаСовмещенияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FactStaffReplacementReasonDialog dlg = new FactStaffReplacementReasonDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void графикБуренияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportForm repForm = new BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetBonusByBonusTypeResult));
                //repForm.Show();
                repForm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void toolStripComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void tscbFindType_SelectedIndexChanged(object sender, EventArgs e)
        {
            tscbTextSearch.Items.Clear();
            if (tscbFindType.SelectedIndex == 1) //по отделу
            {
                foreach (Dep dep in KadrController.Instance.Model.Deps.ToArray().OrderBy(dep => dep.DepartmentName))
                {
                    tscbTextSearch.Items.Add(dep);
                }
            }

            if (tscbFindType.SelectedIndex == 0) //по cотруднику
            {
                foreach (Employee empl in KadrController.Instance.Model.Employees.Where(empl => empl.FactStaffs.Count() > 0).OrderBy(empl => empl.LastName).ThenBy(empl => empl.FirstName).ThenBy(empl => empl.Otch))
                {
                    tscbTextSearch.Items.Add(empl);
                }
            }
        }

        private void tscbTextSearch_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tscbFindType.SelectedIndex == 1) //по отделу
            {
                kadrTreeView1.FindAndSelectDepartment(tscbTextSearch.SelectedItem as Dep);
            }
            if (tscbFindType.SelectedIndex == 0) //по сотрудникам
            {
                Employee employee = KadrController.Instance.Model.Employees.SingleOrDefault(empl => empl.id == (tscbTextSearch.SelectedItem as Employee).id);
                kadrTreeView1.FindAndSelectEmployee(employee);
            }
        }

        private void kadrTreeView1_AfterExpand(object sender, TreeViewEventArgs e)
        {
        }

        private void надбавкиПоОтделамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (Reports.Forms.BaseReportForm repForm = new Reports.Forms.BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetDepartmentBonusWithSettingsResult), 3);
                //repForm.ShowDialog();
            }
        }

        private void статусДняToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TimeSheetDayStateDialog dlg = new TimeSheetDayStateDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void графикиРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (TimeSheetSheduleTypeDialog dlg = new TimeSheetSheduleTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void видыОтчетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BonusReportDialog dlg = new BonusReportDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void последовательностьДанныхToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BonusReportColumnsDialog dlg = new BonusReportColumnsDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void поЦентрамФинансированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportFormWithYear dlg = new BaseReportFormWithYear())
            {
                dlg.ShowDialog();
            }
        }

        private void надбавкиПоВидуРаботыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportForm repForm = new BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetDepartmentBonusWithSettingsResult));
                //repForm.Show();
                repForm.ShowDialog();
            }
        }

        private void toolStripSplitButton2_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (ActiveFrame is KadrEmployeeFrame)
            {
                KadrEmployeeFrame frame = ActiveFrame as KadrEmployeeFrame;
                //устанавливаем фильтр на фрейме
                CopyFilter(tsbBonusFilter, frame.tsbBonusFilter);
                int clickedItemNumber = tsbBonusFilter.DropDownItems.IndexOf(e.ClickedItem);
                (frame.tsbBonusFilter.DropDownItems[clickedItemNumber] as ToolStripMenuItem).Checked = !(tsbBonusFilter.DropDownItems[clickedItemNumber] as ToolStripMenuItem).Checked;
                frame.RefreshBonusFilter();
            }
            if (ActiveFrame is KadrRootFrame)
            {
                (ActiveFrame as KadrRootFrame).BonusFilterSetting = ObjectStateController.Instance.GetObjectStatesForFilter(tsbBonusFilter, e);
            }
        }


        private void CopyFilter(ToolStripSplitButton Filter, ToolStripSplitButton TargetFilter)
        {
            for (int i = 0; i < Filter.DropDownItems.Count; i++)
            {
                (TargetFilter.DropDownItems[i] as ToolStripMenuItem).Checked = (Filter.DropDownItems[i] as ToolStripMenuItem).Checked;
            }
        }

        private void центрыФинансированияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FundingCenterDialog dlg = new FundingCenterDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void профессиональноквалификационыеПодподкатегорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SalaryKoeffDialog dlg = new SalaryKoeffDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void видыДолжностейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PostTypeDialog dlg = new PostTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void надбавкиПоДолжностямToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportForm repForm = new BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetDepartmentBonusWithSettingsResult), 1);
                //repForm.Show();
                repForm.ShowDialog();
            }
        }

        private void надбавкиТ3ПоППСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportForm repForm = new BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetPPSDepartmentBonusForT3Result));
                repForm.ShowDialog();
            }
        }

        private void комплексныйОтчетПоНадбавкамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportForm repForm = new BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetDepartmentBonusWithSettingsResult), 2);
                //repForm.Show();
                repForm.ShowDialog();
            }
        }

        private void отчетТ3ПоППСToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportForm repForm = new BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetPPSDepartmentBonusForT3Result), 1);
                repForm.ShowDialog();
            }
        }

        private void поискНадбавокПоПриказуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportForm repForm = new BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetDepartmentBonusWithSettingsResult), 5);
                repForm.ShowDialog();
            }
        }

        private void продлитьНадбавкуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BonusProlongDialog dlg = new BonusProlongDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void назначитьНадбавкиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FactStaffBonusDialog bonForm = new FactStaffBonusDialog())
            {
                bonForm.ShowDialog();
            }
        }

        private void сеткаПоДолжностямИОкладамToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportForm repForm = new BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetAllPostsResult));
                repForm.ShowDialog();
            }
        }

        private void фОТПоКатегориямБезИсточниковToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BaseReportForm repForm = new BaseReportForm())
            {
                repForm.LoadData(typeof (Reports.GetDepartmentBonusWithSettingsResult), 6);
                //repForm.Show();
                repForm.ShowDialog();
            }
        }

        private void категорииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (CategoryVPODialog dlg = new CategoryVPODialog())
            {
                dlg.ShowDialog();
            }
        }

        private void категорииToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            using (CategoryZPDialog dlg = new CategoryZPDialog())
            {
                dlg.ShowDialog();
            }
        }

        //private void назначитьЧасыToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    using (FactStaffHourDialog dlg = new FactStaffHourDialog())
        //    {
        //        dlg.ShowDialog();
        //    }
        //}

        private void назначитьЧасыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FactStaffHourDialog dlg = new FactStaffHourDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void оКВЭДToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (OKVEDDialog dlg = new OKVEDDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void типыОтделовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (DepartmentTypeDialog dlg = new DepartmentTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void группыДолжностейToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (PostGroupDialog dlg = new PostGroupDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void продлитьНадбавкурасширеннаяФормаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (BonusProlongFullDialog dlg = new BonusProlongFullDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void типыРегионовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (RegionTypeDialog dlg = new RegionTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void видыСтажаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new StandingTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void организацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new OrganisationDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void типОбразованияToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new EducationTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void степеньВладенияЯзыкомToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new LanguageLevelDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void языкToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new LanguageDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void типыДокументовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new DocumentTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void типПовышенияКвалификацииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new DopEducTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void категорииЗапасаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new MilitaryCategoryDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void воинскоеЗваниеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new MilitaryRankDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void воинскийСоставпрофильToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new MilitaryStructureDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void категорияГодностиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new MilitaryFitnessDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void типВоискогоУчетаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new MilitaryTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void видБольничногоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new InkapacityTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void социальныеЛоготыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new SocialStatusDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void видНаградToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new AwardTypeDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void уровеньНаградToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new AwardLevelDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void ведомстваВыдавшиеНаградуToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new GovDepartmentDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void причиныУвольненийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (var dlg = new LeaveReasonDialog())
            {
                dlg.ShowDialog();
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void настроитьПапкуДляОтчетовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var settings = new SettingsDecorator(Properties.Settings.Default);
            using (var dlg = new UIX.UI.PropertyGridViewerDialog())
            {
                dlg.SelectedObject = settings;
                dlg.ShowDialog();

            }
        }
    }
}