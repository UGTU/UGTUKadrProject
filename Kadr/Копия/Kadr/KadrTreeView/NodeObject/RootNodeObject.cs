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

        public override string GetObjectInfo()
        {
            string objectInfo = "";
            decimal CatPlanStaffCount, CatFactStaffCount;
            foreach (Kadr.Data.Category cat in KadrController.Instance.Model.Categories)
            {

                if (Department.PlanStaffs.Where(planSt => (planSt.Post.Category == cat) && (planSt.Prikaz == null)).Count() > 0)
                {
                    CatPlanStaffCount = Department.PlanStaffs.Where(planSt => (planSt.Post.Category == cat) && (planSt.Prikaz == null)).Sum(planSt => planSt.StaffCount);
                    CatFactStaffCount = Department.PlanStaffs.Where(planSt => (planSt.Post.Category == cat) && (planSt.Prikaz == null)).Sum(planSt => planSt.FactStaffCount); 
                    //CatStaffCount = KadrController.Instance.Model.PlanStaffs.Where(planSt => planSt.Department == Department).Where(planSt => planSt.Category == cat).Where(planSt => planSt.Prikaz1==null).Sum(planSt => planSt.StaffCount);
                    objectInfo += "   " + cat.CategorySmallName + " " + CatPlanStaffCount.ToString() + "/ " + CatFactStaffCount.ToString();
                }
            }

            return objectInfo;
        }

        private Kadr.Data.Dep department;

        public Kadr.Data.Dep Department
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
                if (KadrController.Instance.Model.Deps.Where(dep => dep.id == department.id).Count()>0)
                    department = KadrController.Instance.Model.Deps.Where(dep => dep.id == department.id).First() as Dep; 


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
            IOrderedEnumerable<Dep> deps = department.Deps.Where(dep => departmentFilters.Contains((dep as IObjectState).State())).OrderBy(dep => dep.DepartmentName);
            
            //создаем узлы-отделы
            foreach (Kadr.Data.Dep dep in deps)
            {
                System.Windows.Forms.TreeNode node =
                        CreateTreeNode(dep.ToString(), typeof(RootNodeObject));
                RootNodeObject obj =
                        APG.CodeHelper.DBTreeView.DBTreeNodeObject.GetNodeObjectOfNode<RootNodeObject>(node);
                obj.Department = dep;
                //obj.objectID = dep.id;
            }

            IOrderedQueryable<FactStaff> factStaffs = KadrController.Instance.Model.FactStaffs.Where(factSt =>
                    (factSt.PlanStaff.Dep == department)).Where(factSt =>
                    (factSt.PlanStaff.Dep == department)).OrderBy(factSt => factSt.Employee.LastName).ThenBy(factSt =>
                     factSt.Employee.FirstName).ThenBy(factSt => factSt.Employee.Otch);
            //создаем узлы-сотрудники в соответствии с фильтром
            //foreach (PlanStaff planSt in department.PlanStaffs)
            //{
                //проверяем на соответствие фильтру
            Employee empl = null;    
            foreach (FactStaff factSt in factStaffs)
                {
                    if (ObjectFilters.Contains((factSt as IObjectState).State()))
                    {
                        if (empl != null)
                            if (empl == factSt.Employee)
                                continue;
                        empl = factSt.Employee;
                        if (empl != null)
                        {
                            System.Windows.Forms.TreeNode node =
                               CreateTreeNode(empl.EmployeeName, typeof(KadrEmployeeObject));
                            KadrEmployeeObject obj =
                                APG.CodeHelper.DBTreeView.DBTreeNodeObject.GetNodeObjectOfNode<KadrEmployeeObject>(node);
                            obj.Employee = empl;
                            //obj.FactStaff = factSt;
                        }
                    }
                }
            //}
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
