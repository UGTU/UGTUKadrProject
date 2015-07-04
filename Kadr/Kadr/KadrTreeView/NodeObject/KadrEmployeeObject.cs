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

namespace Kadr.KadrTreeView
{
    /// <summary>
    /// Объект "Сотрудник" дерева
    /// </summary>
    class KadrEmployeeObject : KadrNodeObject
    {
        //private Employee employee;

        public Employee Employee
        {
            get {
                if (factStaff!= null)
                    return factStaff.Employee;
                return NullEmployee.Instance;
            }
        }


    private FactStaff factStaff;

        public FactStaff FactStaff
        {
            get { return factStaff; }
            set
            {
                if (factStaff == value) return;
                factStaff = value;
                /*if (factStaff!=null)
                    employee = FactStaff.Employee;*/
            }
        }



        public KadrEmployeeObject(TreeNode node)
            : base(node)
        {
            ObjectViewType = typeof(Kadr.UI.Frames.KadrEmployeeFrame);
            node.ImageIndex = 9;
            node.SelectedImageIndex = 4;
           
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
                nodeActions = new Kadr.KadrTreeView.NodeAction.EmployeeTreeNodeActions(this);

            return nodeActions;
        }

        public override string ToString()
        {
            if (Employee != null)
                return Employee.ToString();
            else
                return base.ToString();
        }
    }
}
