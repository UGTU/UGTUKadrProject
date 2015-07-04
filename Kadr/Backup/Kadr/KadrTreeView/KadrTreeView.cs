using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using UIX.Views;

namespace Kadr.KadrTreeView
{
    public partial class KadrTreeView : APG.CodeHelper.DBTreeView.DBTreeView, IView
    {


 //       public Kadr.Data.dckadrDataContext Model
 //       {
 //           get { return Kadr.Controllers.KadrController.Instance.Model; }
 ////           set { model = value; }
 //       }

        /// <summary>
        /// Создание корневых узлов дерева
        /// </summary>
        protected void CreateRootNodes()
        {

            //создаем узлы-отделы
            IEnumerable<Kadr.Data.Department> deps;
            deps = KadrController.Instance.Model.Departments.Where(dep => dep.Department1 == null);
            foreach (Kadr.Data.Department dep in deps)
            {
                System.Windows.Forms.TreeNode node = 
                        CreateTreeNode(null, dep.ToString(), typeof(Kadr.KadrTreeView.RootNodeObject));
                Kadr.KadrTreeView.RootNodeObject obj =
                        APG.CodeHelper.DBTreeView.DBTreeNodeObject.GetNodeObjectOfNode<Kadr.KadrTreeView.RootNodeObject>(node);
                obj.Department = dep;
                //obj.objectID = dep.id;
            }

            //узел Приказы
            System.Windows.Forms.TreeNode prikNode =
                                    CreateTreeNode(null, "Приказ", typeof(KadrPrikazObject));
            KadrPrikazObject prikObj =
                    APG.CodeHelper.DBTreeView.DBTreeNodeObject.GetNodeObjectOfNode<KadrPrikazObject>(prikNode);

            //узел Должность
            System.Windows.Forms.TreeNode postNode =
                                    CreateTreeNode(null, "Должность", typeof(KadrPostObject));
            KadrPostObject postObj =
                    APG.CodeHelper.DBTreeView.DBTreeNodeObject.GetNodeObjectOfNode<KadrPostObject>(postNode);

        }

        public override void Refresh()
        {
            base.Refresh();
        }

        public KadrTreeView()
        {
            InitializeComponent();
            //CreateSearchNodes();
            CreateRootNodes();

        }

        public KadrTreeView(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
          //  CreateSearchNodes();
            
            CreateRootNodes();
        }



        #region Члены IView

        public void Update(object Sender)
        {
            
            Refresh();
        }

        #endregion
    }
}
