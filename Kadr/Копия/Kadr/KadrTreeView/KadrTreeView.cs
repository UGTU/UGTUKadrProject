using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using UIX.Views;
using Kadr.Data;
using Kadr.Data.Common;
using APG.CodeHelper.DBTreeView;
using System.Windows.Forms;

namespace Kadr.KadrTreeView
{
    public partial class KadrTreeView : APG.CodeHelper.DBTreeView.DBTreeView, IView
    {


 //       public Kadr.Data.dckadrDataContext Model
 //       {
 //           get { return Kadr.Controllers.KadrController.Instance.Model; }
 ////           set { model = value; }
 //       }

        ArrayList depObjects;

        /// <summary>
        /// Создание корневых узлов дерева
        /// </summary>
        protected void CreateRootNodes()
        {

            //создаем узлы-отделы
            IEnumerable<Kadr.Data.Dep> deps;
            deps = KadrController.Instance.GetDepsForDepartments(KadrController.Instance.Model.Departments.Where(dep => dep.idManagerDepartment == null)).ToArray();
            depObjects = new ArrayList();
            foreach (Kadr.Data.Dep dep in deps)
            {
                System.Windows.Forms.TreeNode node = 
                        CreateTreeNode(null, dep.ToString(), typeof(Kadr.KadrTreeView.RootNodeObject));
                Kadr.KadrTreeView.RootNodeObject obj =
                        APG.CodeHelper.DBTreeView.DBTreeNodeObject.GetNodeObjectOfNode<Kadr.KadrTreeView.RootNodeObject>(node);
                obj.Department = dep;
                depObjects.Add(obj);
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


        /// <summary>
        /// Поиск и выбор отдела в дереве
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        public Kadr.KadrTreeView.RootNodeObject FindAndSelectDepartment(Department Department)
        {
            IsSeaching = true;
            try
            {
                //если такого отдела нет 
                Dep department = KadrController.Instance.Model.Deps.Where(dep => dep.id == Department.id).FirstOrDefault(); 
                if (KadrController.Instance.Model.Deps.Where(dep => dep == department).First() == null)
                    return null;

                Dep rootDep;
                rootDep = department;
                //находим узловой-отдел (самого верхнего уровня)
                while (rootDep.ManagerDepartment != null)
                {
                    rootDep = rootDep.ManagerDepartment;
                }

                //найдем узловой отдел в узлах дерева
                Kadr.KadrTreeView.RootNodeObject rootObj = depObjects.ToArray().Where(dep
                    => (dep as Kadr.KadrTreeView.RootNodeObject).Department == rootDep).First() as Kadr.KadrTreeView.RootNodeObject;
                Dep nodeDep;
                while ((rootDep != department) && (!rootObj.IsTerminalNode))
                {
                    nodeDep = department;
                    while (nodeDep.ManagerDepartment != rootDep)
                    {
                        nodeDep = nodeDep.ManagerDepartment;
                    }
                    //если состояние дочернего узла не соответствует выставленному фильтру, добавляем его
                    if (!rootObj.DepartmentFilters.Contains((nodeDep as IObjectState).State()))
                    {
                        rootObj.DepartmentFilters.Add((nodeDep as IObjectState).State());
                    }
                    rootObj.AddChildNodes();
                    rootObj = rootObj.Where(depObj
                        => (depObj as Kadr.KadrTreeView.RootNodeObject).Department == nodeDep).First() as Kadr.KadrTreeView.RootNodeObject;
                    //this.SelectedNode = rootObj.Node;
                    rootDep = nodeDep;
                }
                SelectedNode = rootObj.Node;
                return rootObj;
            }
            finally
            {
                IsSeaching = false;
           }

 
        }

        /// <summary>
        /// Поиск и выбор сотрудника в дереве
        /// </summary>
        /// <param name="employee"></param>
        public bool FindAndSelectEmployee(Employee employee)
        {

            //поиск соответствующей записи в штатном
            IEnumerable<FactStaff> emplFactStaffs = employee.FactStaffs;
            if (emplFactStaffs.Count() == 0)
                return false;
            FactStaff seachFactStaff = null;
            //по возможности выбираем ту запись штатного, которая в текущем состоянии и с основным видом работы
            if (emplFactStaffs.Where(fcSt => (fcSt as IObjectState).State() == ObjectState.Current).Count() > 0)
            {
                if (emplFactStaffs.Where(fcSt => (fcSt as IObjectState).State() == ObjectState.Current).Where(fcSt => fcSt.WorkType.IsMain).Count() > 0)
                    seachFactStaff = emplFactStaffs.Where(fcSt =>
                        (fcSt as IObjectState).State() == ObjectState.Current).Where(fcSt => fcSt.WorkType.IsMain).First();
                else
                    seachFactStaff = emplFactStaffs.Where(fcSt =>
                        (fcSt as IObjectState).State() == ObjectState.Current).First();
            }
            //seachFactStaff = emplFactStaffs.Where(fcSt => fcSt.WorkType.IsMain).FirstOrDefault();
            if (seachFactStaff == null)
                seachFactStaff = emplFactStaffs.Where(fcSt => fcSt.WorkType.IsMain).FirstOrDefault();
            if (seachFactStaff == null)
                seachFactStaff = emplFactStaffs.OrderByDescending(fcSt => fcSt.DateEnd).FirstOrDefault();

            Kadr.KadrTreeView.RootNodeObject depObj = FindAndSelectDepartment(KadrController.Instance.Model.Departments.Where(dep => dep.id == seachFactStaff.PlanStaff.Dep.id).FirstOrDefault());
            if (depObj == null)
                return false;

            if (!depObj.ObjectFilters.Contains((seachFactStaff as IObjectState).State()))
            {
                depObj.ObjectFilters.Add((seachFactStaff as IObjectState).State());
            }

            IsSeaching = true;
            try
            {
                depObj.AddChildNodes();
                KadrEmployeeObject emplObj = depObj.Where(dObj => dObj is Kadr.KadrTreeView.KadrEmployeeObject).Where(dObj
                    => (dObj as Kadr.KadrTreeView.KadrEmployeeObject).Employee == employee).FirstOrDefault() as KadrEmployeeObject;

                if (emplObj != null)
                {
                    TreeNode node = emplObj.Node as TreeNode;
                    this.SelectedNode = node;
                    return true;
                }

            }
            finally
            {
                IsSeaching = false;

            }
            return false;

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
