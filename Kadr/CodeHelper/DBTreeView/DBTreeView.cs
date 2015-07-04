using System;
using System.Reflection;
using System.ComponentModel;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace APG.CodeHelper.DBTreeView
{
    public delegate void NodeChildsAdded(object sender, EventArgs e); 
    
    /// <summary>
    /// Базовый класс для дерева, связаннного с источником данных
    /// </summary>
    public partial class DBTreeView
    {
        public event NodeChildsAdded NodeChildsAddedEvent;

        protected bool IsSeaching; //признак поиска узла - тоогда не нужно переходить на открываемый узел
        /// <summary>
        /// Создаёт объект ISGBDS.DBTreeView
        /// </summary>
        public DBTreeView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Создаёт объект ISGBDS.DBTreeView
        /// </summary>
        /// <param name="container"></param>
        public DBTreeView(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        protected override void  OnBeforeExpand(TreeViewCancelEventArgs e)
        {
            base.OnBeforeExpand(e);

            if (!IsSeaching)    //если не в поиске, то переходим на раскрываемый узел
                SelectedNode = e.Node;
            GetNodeObject(e.Node).AddChildNodes();
            //{
            //    //GetNodeObject();
            //    SelectedNode = e.Node;

            //     if (SelectedObject != null)
            //        SelectedObject.AddChildNodes();

            //}


                      
        }

        /// <summary>
        /// Возвращает выделенный объект
        /// </summary>
        public DBTreeNodeObject SelectedObject
        {
            get
            {
                return GetNodeObject(SelectedNode);
            }
        }

        public T GetSelectedObject<T>() where T:APG.CodeHelper.DBTreeView.DBTreeNodeObject
        {
            return (T)SelectedObject;
        }

        /// <summary>
        /// Объявляет содержимое выделенного узла не действительным, позволяя 
        /// обновить ему дочерние узлы
        /// </summary>
        public void RefreshNode()
        {
            if (GetNodeObject(SelectedNode) != null)
            {
                GetNodeObject(SelectedNode).Refresh();
            }
        }

        /// <summary>
        /// Создаёт новый узел дерева
        /// </summary>
        /// <param name="parentNode">Дочерний узел</param>
        /// <param name="Caption">Заголовок</param>
        /// <param name="nodeType">Тип узла</param>
        /// <returns>Созданный объект узла</returns>
        public TreeNode CreateTreeNode(TreeNode parentNode, string Caption, System.Type nodeType)
        {
            TreeNode node = CreateTreeNode(parentNode, Caption);
            DBTreeNodeObject treeObj = CreateDBObjectInstance(nodeType, node);
            return node;
            
        }

        public TreeNode CreateTreeNode<T>(TreeNode parentNode, string Caption, out T outNodeObject) where T:APG.CodeHelper.DBTreeView.DBTreeNodeObject
        {
            return CreateTreeNode(parentNode, Caption, null, out outNodeObject);
        }

        public TreeNode CreateTreeNode<T>(TreeNode parentNode, string Caption, string Key, out T outNodeObject) where T : APG.CodeHelper.DBTreeView.DBTreeNodeObject
        {
            TreeNode node = CreateTreeNode(parentNode, Caption, Key);
            outNodeObject = (T)CreateDBObjectInstance(typeof(T), node);
            outNodeObject.Key = Key;
            return node;
        }
        
        
        /// <summary>
        /// Выполняет команду "Add" над выделенным узлом
        /// </summary>
        public void AddExecute()
        {
            if (GetNodeAction(SelectedNode) != null)
                GetNodeAction(SelectedNode).Execute(this, APG.CodeHelper.Actions.UIObjectAction.taAdd);

        }

        /// <summary>
        /// Выполняет команду "Delete" над выделенным узлом
        /// </summary>
        public void DeleteExecute()
        {
            if (GetNodeAction(SelectedNode) != null)
                GetNodeAction(SelectedNode).Execute(this, APG.CodeHelper.Actions.UIObjectAction.taDelete);

        }

        /// <summary>
        /// Выполняет команду "Paste" над выделенным узлом
        /// </summary>
        public void PasteExecute()
        {
            if (GetNodeAction(SelectedNode) != null)
                GetNodeAction(SelectedNode).Execute(this, APG.CodeHelper.Actions.UIObjectAction.taPaste);

        }

        /// <summary>
        /// Выполняет команду "Cut" над выделенным узлом
        /// </summary>
        public void CutExecute()
        {
            if (GetNodeAction(SelectedNode) != null)
                GetNodeAction(SelectedNode).Execute(this, APG.CodeHelper.Actions.UIObjectAction.taCut);

        }

        /// <summary>
        /// Выполняет команду "Copy" над выделенным узлом
        /// </summary>
        public void CopyExecute()
        {
            if (GetNodeAction(SelectedNode) != null)
                GetNodeAction(SelectedNode).Execute(this, APG.CodeHelper.Actions.UIObjectAction.taCopy);

        }

        /// <summary>
        /// Выполняет команду "Update" над выделенным узлом
        /// </summary>
        public void UpdateExecute()
        {
            if (GetNodeAction(SelectedNode) != null)
                GetNodeAction(SelectedNode).Execute(this, APG.CodeHelper.Actions.UIObjectAction.taUpdate);

        }

        /// <summary>
        /// Проверяет возможность выполнения команды "Add" над выделенным узлом
        /// </summary>
        /// <returns>Возможность выполнения операции</returns>
        public bool CanAdd()
        {
            bool result = false;
            if (GetNodeAction(SelectedNode) != null)
                result = GetNodeAction(SelectedNode).CanDoThis(this, APG.CodeHelper.Actions.UIObjectAction.taAdd);
            return result;

        }

        /// <summary>
        /// Проверяет возможность выполнения команды "Delete" над выделенным узлом
        /// </summary>
        /// <returns>Возможность выполнения операции</returns>
        public bool CanDelete()
        {
            bool result = false;
            if (GetNodeAction(SelectedNode) != null)
                result = GetNodeAction(SelectedNode).CanDoThis(this, APG.CodeHelper.Actions.UIObjectAction.taDelete);
            return result;

        }

        /// <summary>
        /// Проверяет возможность выполнения команды "Cut" над выделенным узлом
        /// </summary>
        /// <returns>Возможность выполнения операции</returns>
        public bool CanCut()
        {
            bool result = false;
            if (GetNodeAction(SelectedNode) != null)
                result = GetNodeAction(SelectedNode).CanDoThis(this, APG.CodeHelper.Actions.UIObjectAction.taCut);
            return result;

        }

        /// <summary>
        /// Проверяет возможность выполнения команды "Update" над выделенным узлом
        /// </summary>
        /// <returns>Возможность выполнения операции</returns>
        public bool CanUpdate()
        {
            bool result = false;
            if (GetNodeAction(SelectedNode) != null)
                result = GetNodeAction(SelectedNode).CanDoThis(this, APG.CodeHelper.Actions.UIObjectAction.taUpdate);
            return result;

        }

        /// <summary>
        /// Проверяет возможность выполнения команды "Paste" над выделенным узлом
        /// </summary>
        /// <returns>Возможность выполнения операции</returns>
        public bool CanPaste()
        {
            bool result = false;
            if (GetNodeAction(SelectedNode) != null)
                result = GetNodeAction(SelectedNode).CanDoThis(this, APG.CodeHelper.Actions.UIObjectAction.taPaste);
            return result;

        }
        /// <summary>
        /// Проверяет возможность выполнения команды "Copy" над выделенным узлом
        /// </summary>
        /// <returns>Возможность выполнения операции</returns>
        public bool CanCopy()
        {
            bool result = false;
            if (GetNodeAction(SelectedNode) != null)
                result = GetNodeAction(SelectedNode).CanDoThis(this, APG.CodeHelper.Actions.UIObjectAction.taCopy);
            return result;

        }

        /// <summary>
        /// Возращает зголовок заданной команды, связанной с выделенным узлом
        /// </summary>
        /// <param name="nodeAction"></param>
        /// <returns></returns>
        public string SelectedActionCaption(APG.CodeHelper.Actions.UIObjectAction nodeAction)
        {
            string result = "";
            if (GetNodeAction(SelectedNode) != null)
                result = GetNodeAction(SelectedNode)[nodeAction];
            return result;
        }

        /// <summary>
        /// Возвращает объект команд, связанных с выделенным узлом
        /// </summary>
        public DBTreeNodeAction SelectedActions
        {
            get
            {
                return GetNodeAction(SelectedNode);
            }
        }

        /// <summary>
        /// Возвращает объект, связанный с узлом
        /// </summary>
        /// <param name="treeNode">Узел</param>
        /// <returns>Объект</returns>
        public DBTreeNodeObject GetNodeObject(TreeNode treeNode)
        {
            DBTreeNodeObject nodeObj = null;
            if (treeNode != null)
                nodeObj = treeNode.Tag as DBTreeNodeObject;
            return nodeObj;
        }
        public T GetNodeObject<T>(TreeNode treeNode) where T:DBTreeNodeObject
        {
            return (T)GetNodeObject(treeNode);
        }

        private TreeNode CreateTreeNode(TreeNode parentNode, string Caption)
        {
            return CreateTreeNode(parentNode, Caption, string.Empty);
        }

        private TreeNode CreateTreeNode(TreeNode parentNode, string Caption, string Key)
        {
            TreeNode node = null;

            BeginUpdate();
            try
            {
                if (parentNode == null)
                {
                    node = Nodes.Add(Caption);
                }
                else
                {
                    node = parentNode.Nodes.Add(Key, Caption);
                }
                
                node.Nodes.Add("");
                
                }
                finally
                {
                    EndUpdate();
                }

            return node;
        }

        private DBTreeNodeObject CreateDBObjectInstance(Type nodeType, TreeNode node)
        {
            return (Activator.CreateInstance(nodeType, node) as DBTreeNodeObject);
        }

        private DBTreeNodeAction GetNodeAction(TreeNode treeNode)
        {
            DBTreeNodeAction nodeAction = null;

            if (GetNodeObject(treeNode) != null)
                nodeAction = GetNodeObject(treeNode).Actions;
            return nodeAction;
        }

        public void OnChildsAddedEvent()
        {
            if (NodeChildsAddedEvent!=null)
                NodeChildsAddedEvent(this, new EventArgs());
        }

    }
}
