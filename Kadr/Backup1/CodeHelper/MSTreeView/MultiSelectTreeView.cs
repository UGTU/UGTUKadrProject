using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;

namespace MultiSelectTreeView
{
    public partial class MiltiSelectTreeView : TreeView
    {        
        public MiltiSelectTreeView()
        {
            fSelectedNodes = new List<TreeNode>();
            fSelectedBackColor = Color.RoyalBlue;
            fSelectedForeColor = Color.White;
            InitializeComponent();
        }

        private List<TreeNode> fSelectedNodes;
        private Color fSelectedBackColor;
        private Color fSelectedForeColor;

        //Цвет шрифта выделяемых элементов
        public Color SelectedForeColor
        {
            get { return fSelectedForeColor; }
            set { fSelectedForeColor = value; }
        }

        //Цвет заливки выделяемых элементов
        public Color SelectedBackColor
        {
            get { return fSelectedBackColor; }
            set { fSelectedBackColor = value; }
        }

        //Список всех выделенных элементов дерева
        [Browsable(false)]
        public List<TreeNode> SelectedNodes
        {
            get { return fSelectedNodes; }
        }

        protected override void OnDrawNode(DrawTreeNodeEventArgs e)
        {
            base.OnDrawNode(e);
            SolidBrush currentBackBrush = new SolidBrush(BackColor);
            SolidBrush currentForeBrush = new SolidBrush(ForeColor);

            //if (e.State == ((TreeNodeStates.Focused) & (TreeNodeStates.Selected)) || (IsInSelected(e.Node)))
            if (IsInSelected(e.Node))
            {
                currentBackBrush.Color = SelectedBackColor;
                currentForeBrush.Color = SelectedForeColor;
            }
                    
            e.Graphics.FillRectangle(currentBackBrush, e.Bounds);
            e.Graphics.DrawString(e.Node.Text, this.Font, currentForeBrush, e.Bounds.Location);
                       
            
        }

        private bool IsInSelected(TreeNode treeNode)
        {
            return (SelectedNodes.Contains(treeNode));
        }

        //После выделения одной из верши, она либо добавляется в список выделяемых (при условии нажатия Ctrl),
        //либо все существующие элементы удаляются из списка выделенных вершин и в него добавляется последняя
        //выделенная вершина (если при выделении ни одна из клавиш клавиатуры не нажата)
        protected override void OnAfterSelect(TreeViewEventArgs e)
        {
            TreeNode node = e.Node;

            switch (Control.ModifierKeys)
            {
                case Keys.Control:
                    {
                        //Если эта вершина уже выделена - она удаляется из списка
                        ReverseNodeState(node);
                        
                        break;                    
                    }
                //Надо написать обработчик
                case Keys.Shift:
                    {
                        
                        //ReverseNodeState(node);
                        break; 
                    }
                default:
                    {
                        fSelectedNodes.Clear();
                        fSelectedNodes.Add(SelectedNode);
                        break;
                    }
            }
            Invalidate();
           // MultiSelectTreeVeiwRedraw();
            base.OnAfterSelect(e);
            
        }

        private void ReverseNodeState(TreeNode node)
        {
            if (IsInSelected(node))
                SelectedNodes.Remove(node);
            else
                SelectedNodes.Add(node);
        }


        //Перерисова дерева - выделяет выделенные ветви
        public void MultiSelectTreeVeiwRedraw()
        {
            //Очистка всего дерева ДО ВТОРОГО УРОВНЯ!
            TreeNodeCollection nodes = this.Nodes;
            TreeNode node = TopNode;
            //while (node != null)
            //{
            //    foreach (TreeNode n in node.Nodes)
            //    {
            //        n.BackColor = this.BackColor;
            //        n.ForeColor = this.ForeColor;

            //    }
            //    node = node.Nodes[1];
            //}
            foreach (TreeNode n in nodes)
            {
                foreach (TreeNode tn in n.Nodes)
                {
                    tn.BackColor = this.BackColor;
                    tn.ForeColor = this.ForeColor;
                }
                n.BackColor = this.BackColor;
                n.ForeColor = this.ForeColor;
            }

            //ЗАливка Выделенных ветвей
            foreach (TreeNode n in SelectedNodes)
            {
                n.BackColor = fSelectedBackColor;
                n.ForeColor = fSelectedForeColor;
            }
        }


    }

}