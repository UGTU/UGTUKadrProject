using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class Department : IObjectState
    {
        private Dep dep;
        public Dep Dep
        {
            get
            {
                if (dep == null)
                    dep = Kadr.Controllers.KadrController.Instance.Model.Deps.Where(dp => dp.id == id).FirstOrDefault();

                return dep;
            }
        }


        public override string ToString()
        {

            
            if (Dep != null)
            {
                return Dep.ToString();
             
            }
            else return null;
        }

        public decimal DepExtraordSum
        {
            get
            {
                return Dep.DepExtraordSum;
            }
            set
            {
                Dep.DepExtraordSum = value;
            }
        }

        public decimal DepPlanFundSum
        {
            get
            {
                return Dep.DepPlanFundSum;
            }
            set
            {
                Dep.DepPlanFundSum = value;
            }
        }

        public decimal DepFactFundSum
        {
            get
            {
                return Dep.DepFactFundSum;
            }
            set
            {
                Dep.DepFactFundSum = value;
            }
        }
        public Department ManagerDepartment
        {
            get
            {
                return KadrController.Instance.Model.Departments.Where(dep => dep.id == this.idManagerDepartment).FirstOrDefault();
            }
        }

        #region IObjectState Members

        public ObjectState State()
        {
            if ((dateExit == null) || (dateExit > DateTime.Today))
                return ObjectState.Current;
            else
                return ObjectState.Canceled;
        }

        #endregion
       /* #region INull Members

        bool INull.IsNull()
        {
            return false;
        }

        #endregion*/
    }


    /*public class NullDepartment : Department, INull
    {

        private NullDepartment()
        {
            this.id = -1;
            this.DepartmentName = "(Не задан)";
            this.DepartmentSmallName = "(Не задан)";
        }

        public static readonly NullDepartment Instance = new NullDepartment();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не задан)";
        }

        #endregion
    }*/

}

