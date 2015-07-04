using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;
using Kadr.Data;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Collections;


namespace Kadr.KadrTreeView
{
    /// <summary>
    /// Узел отдел университета
    /// </summary>
    public class RootNodeObject : KadrNodeObject
    {
        // список фильтров для объекта
        private ArrayList departmentFilters;

        
        
        /// <summary>
        /// 
        /// </summary>
        public ArrayList DepartmentFilters
        {
            get
            {
                return departmentFilters;
            }
            set
            {
                if ((value == null))
                {
                    departmentFilters = new ArrayList();
                }
                else
                {
                    if (departmentFilters != value)
                    {
                        departmentFilters = value;
                    }
                }
                Refresh();
            }
        }


        private Kadr.Data.Department department;

        public Kadr.Data.Department Department
        {
            get
            {
                return department;
                    //KadrController.Instance.Model.Departments.Where(dep => dep.id == objectID).First() as Department;
            }//KadrController.Instance.Model.Departments.Where(dep => dep.id == department.id).First() as Department; }
            set 
            { 
                if (department == value) return;
                department = value; 
                if (department != null)
                    department.PropertyChanged += new PropertyChangedEventHandler(department_PropertyChanged);
            }
        }

        //public dckadrDataContext Model
        //{
        //    get { return KadrController.Instance.Model; }
        //}


        void department_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            Node.Text = this.ToString();

        }


        /// <summary>
        /// При создании модели перезаписывает отдел
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Model_Created(object sender, EventArgs e)
        {

            if (department != null)
                if (KadrController.Instance.Model.Departments.Where(dep => dep.id == department.id).Count()>0)
                    department = KadrController.Instance.Model.Departments.Where(dep => dep.id == department.id).First() as Department; 


        }

        public RootNodeObject(TreeNode node)
            : base(node)
        {
            ObjectViewType = typeof(Kadr.UI.Frames.KadrRootFrame);
            node.ImageIndex = 0;
            node.SelectedImageIndex = 4;         
            if (departmentFilters == null)
            {
                departmentFilters = new ArrayList();
                departmentFilters.Add(ObjectState.Current);
            }
            KadrController.Instance.CreatingModel += new EventHandler(Model_Created);
        }

        /// <summary>
        /// Создание дочерних узлов 
        /// </summary>
        /// <returns></returns>
        protected override bool DoAddChildNodes()
        {
            
            //создаем узлы-отделы
            foreach (Kadr.Data.Department dep in department.Departments)
            {
                if (departmentFilters.Contains((dep as IObjectState).State()))
                {
                    System.Windows.Forms.TreeNode node =
                            CreateTreeNode(dep.ToString(), typeof(RootNodeObject));
                    RootNodeObject obj =
                            APG.CodeHelper.DBTreeView.DBTreeNodeObject.GetNodeObjectOfNode<RootNodeObject>(node);
                    obj.Department = dep;
                    //obj.objectID = dep.id;
                }
            }

            //создаем узлы-сотрудники в соответствии с фильтром
            foreach (PlanStaff planSt in department.PlanStaffs)
            {
                //проверяем на соответствие фильтру
                foreach (FactStaff factSt in planSt.FactStaffs)
                {
                    if (ObjectFilters.Contains((factSt as IObjectState).State()))
                    {
                        Employee empl = factSt.Employee;
                        if (empl != null)
                        {
                            System.Windows.Forms.TreeNode node =
                               CreateTreeNode(empl.EmployeeName, typeof(KadrEmployeeObject));
                            KadrEmployeeObject obj =
                                APG.CodeHelper.DBTreeView.DBTreeNodeObject.GetNodeObjectOfNode<KadrEmployeeObject>(node);
                            obj.FactStaff = factSt;
                        }
                    }
                }
            }

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
                nodeActions = new Kadr.KadrTreeView.NodeAction.RootTreeNodeActions(this);

            return nodeActions;
        }

        public override string ToString()
        {
            if (Department != null)
                return Department.ToString();
            else
                return base.ToString();
        }
    }
}
