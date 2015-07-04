using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace APG.CodeHelper.DBTreeView
{
    /// <summary>
    /// Базовый класс для объектов ула компонента DBTreeView
    /// </summary>
    public abstract class DBTreeNodeObject:IEnumerable<DBTreeNodeObject>
    {
                                
        private bool isTerminalNode = false;

        // Узел не должен содержать дочерних узлов
        // Это свойство переопределяется каждым производным объектом узла
        /// <summary>
        /// Определяет, является ли узел терминальным
        /// </summary>
        public bool IsTerminalNode
        {
            get 
            { 
                return isTerminalNode; 
            }
            protected set 
            { 
                isTerminalNode = value; 
            }
  
        }

        private TreeNode treeNode;
        
        private object objectTag;

        private bool bChildAdded = false;

        private string key;

        public string Key
        {
            get
            {
                return key;
            }
            set
            {
                key = value;
            }
        }

        private TreeNode GetParentNode()
        {
            TreeNode treeNode = null;
            if (Node != null)
                treeNode = Node.Parent;
            return treeNode;
        }

        private System.Type objectViewType;
        private object objectView;

        /// <summary>
        /// Получает представление (фрейм, окно), которое связано с узлом.
        /// </summary>
        public object ObjectView
        {
            get 
            { 
                return objectView; 
            }
            set
            {
                objectView = value;
            }
        }
        private System.Collections.IDictionary store;

        /// <summary>
        /// Позволяет различным клиентам сохранять своё состояние для дальнейшего использования (Pattern Memento)
        /// </summary>
        public System.Collections.IDictionary Store
        {
            get 
            {
                if (store == null)
                    store = new System.Collections.Hashtable();
                return store; 
            }           
        }


        /// <summary>
        /// Следует вызвать этот конструктор в производном классе
        /// </summary>
        /// <param name="node">Узел дерева с которым связан этот объект</param>
        protected DBTreeNodeObject(TreeNode node)
        {
            if (node != null)
            {
                node.Tag = this;
                treeNode = node;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private DBTreeNodeObject GetParentObject()
        {
            DBTreeNodeObject nodeObj = null;
            if (GetParentNode() != null)
                nodeObj = GetParentNode().Tag as DBTreeNodeObject;
            return nodeObj;
        }

        
        /// <summary>
        /// Переопределите в производном классе для добавления дочерних узлов
        /// </summary>
        /// <returns></returns>
        protected abstract bool DoAddChildNodes();
        
        /// <summary>
        /// Добавляет дочерние узлы
        /// </summary>
        public void AddChildNodes()
        {
            
            // Если дочерние узлы ещё не добавлены
            if (!bChildAdded)
            {
                treeView.BeginUpdate();

                try
                {
                    Node.Nodes.Clear();
                    
                    // Если это не терминальный узел, то узлы добавляются
                    if (!IsTerminalNode)
                    {

                        bChildAdded = DoAddChildNodes();
                        treeView.OnChildsAddedEvent();
                    }                    
                }
                finally
                {
                    treeView.EndUpdate();
                }
            }
        }

        /// <summary>
        /// Обновляет представление узла
        /// </summary>
        public void Refresh()
        {
            // Состояние узла до обновления            
            bool IsNodeExpanded = Node.IsExpanded;

            // Провести добавление дочерних узлов
            bChildAdded = false;
            AddChildNodes();

            // Призвести форматирование текущего узла
            FormatNode();

            // Если узел был раскрыт до обновления, то раскрыть его после операции обновления
            if (IsNodeExpanded)
            Node.Expand();
            treeView.SelectedNode = Node;
        }

        /// <summary>
        /// Переопределите в производном классе для получения объекта команд узла
        /// </summary>
        /// <returns></returns>
        protected virtual DBTreeNodeAction GetActions()
        {
            return null;
        }

        DBTreeNodeAction actions;

        /// <summary>
        /// Объект "команда", связаная с данным узлом
        /// </summary>
        public DBTreeNodeAction Actions
        {
            get
            {
                if (actions == null)
                    actions =  GetActions();
                return actions;
            }
        }

        /// <summary>
        ///  Узел дерева, с которым связан этот объект
        /// </summary>
        public TreeNode Node
        {
            get
            {
                return treeNode;
            }
        }

        /// <summary>
        /// Дерево, с которым связан этот объект
        /// </summary>
        public DBTreeView treeView
        {
            get
            {
                DBTreeView tv = null;
                if (Node != null)
                    tv = Node.TreeView as DBTreeView;
                return tv;
            }
        }
        
        

        /// <summary>
        /// Родительский объект
        /// </summary>
        public DBTreeNodeObject Parent
        {
            get
            {
                return GetParentObject();
            }
        }
        /// <summary>
        /// Получает или устанавливает тип представления (Фрейм) для данного узла
        /// </summary>
        public System.Type ObjectViewType
        {
            get
            {
                return objectViewType;
            }
            set
            {
                objectViewType = value;

            }
        }

        /// <summary>
        /// Получает или устанавливает объект, связаный с узлом
        /// </summary>
        public object ObjectTag
        {
            get
            {
                return objectTag;
            }
            set
            {
                objectTag = value;
                FormatNode();
            }
        }

        /// <summary>
        /// Добавляет дочерние узлы в узел, связанный с этим объектом
        /// </summary>
        /// <param name="Caption">Заголовок</param>
        /// <param name="nodeType">Тип узла</param>
        /// <returns>Новый узел</returns>
        public TreeNode CreateTreeNode(string Caption, System.Type nodeType)
        {
            return treeView.CreateTreeNode(treeNode, Caption, nodeType);
        }

        /// <summary>
        /// Создаёт новый узел в дереве
        /// </summary>
        /// <typeparam name="T">Тип объекта узла</typeparam>
        /// <param name="Caption">Текст узла</param>
        /// <param name="outNodeObject">Созданный объект узла</param>
        /// <returns>Узел дерева</returns>
        public TreeNode CreateTreeNode<T>(string Caption, out T outNodeObject) where T : DBTreeNodeObject
        {
            return treeView.CreateTreeNode<T>(treeNode, Caption, string.Empty, out outNodeObject);
        }

        public TreeNode CreateTreeNode<T>(string Caption, string Key, out T outNodeObject) where T : DBTreeNodeObject
        {
            return treeView.CreateTreeNode<T>(treeNode, Caption, Key, out outNodeObject);
        }

        /// <summary>
        /// Получает контекстное меню, связанное с этим объектом
        /// </summary>
        public ContextMenuStrip NodeContextMenuStrip
        {
            get
            {
                if (treeNode.ContextMenuStrip == null)
                    treeNode.ContextMenuStrip = CreateContextMenuStrip();

                return treeNode.ContextMenuStrip;
            }
        }

        /// <summary>
        /// Возвращает объект заданного типа, связанного с узлом
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="node"></param>
        /// <returns></returns>
        public static T GetNodeObjectOfNode<T>(TreeNode node) where T : DBTreeNodeObject
        {
            if (node == null) return default(T);
            return (node.Tag as T);
        }

        private ContextMenuStrip CreateContextMenuStrip()
        {
            if (Actions == null) return null;
                

            ContextMenuStrip menuStrip = new ContextMenuStrip(treeView.Container);
            
            menuStrip.Opening += new System.ComponentModel.CancelEventHandler(menuStrip_Opening);
            menuStrip.Tag = this;
            
            ToolStripItem tsi;
            for (int i = 0; i < APG.CodeHelper.Actions.UIAction.Count; i++)
            {
                tsi = menuStrip.Items.Add(Actions[(APG.CodeHelper.Actions.UIObjectAction)i]);
                tsi.Click += new EventHandler(tsi_Click);
                tsi.Tag = (APG.CodeHelper.Actions.UIObjectAction)i;
            }
         
            return menuStrip;
        }

        void menuStrip_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {
            foreach (ToolStripItem item in (sender as ContextMenuStrip).Items)
            {
                if (item.Tag != null)
                {
                    item.Visible = Actions.CanDoThis(this, (APG.CodeHelper.Actions.UIObjectAction)item.Tag);
                }
            }

        }

        void tsi_Click(object sender, EventArgs e)
        {
            Actions.Execute(this, (APG.CodeHelper.Actions.UIObjectAction)((sender as ToolStripItem).Tag));
        }


        protected void HandleBDException(System.Exception e)
        {
        
        }

        #region IEnumerable<DBTreeNodeObject> Members

        IEnumerator<DBTreeNodeObject> IEnumerable<DBTreeNodeObject>.GetEnumerator()
        {
            for (int i = 0; i < Node.Nodes.Count; i++ )
            {
                yield return Node.Nodes[i].Tag as DBTreeNodeObject;
            }
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            for (int i = 0; i < Node.Nodes.Count; i++)
            {
                yield return Node.Nodes[i].Tag as DBTreeNodeObject;
            }
        }

        #endregion

        /// <summary>
        /// Уведомляет ио изменениях в модели
        /// </summary>
        /// <param name="sender">Объект-создатель сообщения</param>
        public virtual void Notify(object sender)
        {
            //throw new Exception("The method or operation is not implemented.");
        }

        /// <summary>
        /// Переопределите в производных классах для изменения формата представления узла
        /// </summary>
        protected virtual void FormatNode()
        {

        }
    }

    
}
