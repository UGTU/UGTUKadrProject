using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.KadrTreeView
{

    /// <summary>
    /// Возможные состояния узлов дерева
    /// </summary>
    public enum KadrNodeState
    {
        /// <summary>
        /// Корректное состояние
        /// </summary>
        ConsistentNodeState,
        /// <summary>
        /// Некорректное состояние
        /// </summary>
        UnconsistentNodeState, 
        /// <summary>
        /// Неопределённое состояние
        /// </summary>
        UnknownNodeState 
    }







    public abstract class KadrNodeObject : APG.CodeHelper.DBTreeView.DBTreeNodeObject
    {

        // список фильтров для объекта
        private ArrayList objectFilters;

        /// <summary>
        /// 
        /// </summary>
        public ArrayList ObjectFilters
        {
            get
            {
                return objectFilters;
            }
            set
            {
                if ((value == null))
                {
                    objectFilters = new ArrayList();
                }
                else
                {
                    if (objectFilters != value)
                    {
                        objectFilters = value;
                    }
                }
                Refresh();

            }
        }

        private KadrNodeState nodeState;

        /// <summary>
        /// Изменяет или получает состояние узла дерева
        /// </summary>
        public KadrNodeState NodeState
        {
            get { return nodeState; }
            set { nodeState = value; }
        }

        protected KadrNodeObject(System.Windows.Forms.TreeNode node) : base(node) 
        {
            if (objectFilters == null)
            {
                objectFilters = new ArrayList();
                objectFilters.Add(ObjectState.Current);
            }



        }

        /// <summary>
        /// Возвращает статус объекта дерева
        /// </summary>
        /// <returns></returns>
        public virtual string GetObjectInfo()
        {
            return "";
        }

        /// <summary>
        /// Возвращает название объекта дерева
        /// </summary>
        /// <returns></returns>
        public virtual string GetObjectName()
        {
            return this.ToString();
        }



    }
}

