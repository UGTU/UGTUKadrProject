using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kadr.KadrTreeView
{
    /// <summary>
    /// Узел приказ
    /// </summary>
    class KadrPostObject: KadrNodeObject
    {

        public KadrPostObject(TreeNode node)
            : base(node)
        {
            ObjectViewType = typeof(Kadr.UI.Frames.KadrPostFrame);
            node.ImageIndex = 3;
            node.SelectedImageIndex = 4;
        }

        public override string ToString()
        {
            return "Должность";
        }

        /// <summary>
        /// Создание дочерних узлов 
        /// </summary>
        /// <returns></returns>
        protected override bool DoAddChildNodes()
        {
            return true;
        }

        private APG.CodeHelper.DBTreeView.DBTreeNodeAction nodeActions;

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected override APG.CodeHelper.DBTreeView.DBTreeNodeAction GetActions()
        {
            if (nodeActions == null)
                nodeActions = new Kadr.KadrTreeView.NodeAction.PostTreeNodeActions(this);

            return nodeActions;
        }


    }
}


