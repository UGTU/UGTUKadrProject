using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Department : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState, IComparable
    {
        
        public override string ToString()
        {

            if (PlanStaff != null)
            {
                try
                {
                    //берем первого руководителя из списка неуволенных
                    FactStaff factStaff = PlanStaff.FactStaffs.Where(fctStaff => fctStaff.Prikaz1 == null).First() as FactStaff;
                    if (factStaff != null)
                        return this.DepartmentName + " (" + factStaff.ToString() + ")";
                }
                catch (InvalidOperationException)
                {
                    return this.DepartmentName;
                }
            }
            return this.DepartmentName;
        }

        #region partial Methods

        partial void OnCreated()
        {
            DepartmentName = "Новый отдел";
            DepartmentSmallName = "Новый отдел";
            dateCreate = DateTime.Today;
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if ((DepartmentName == null) || (DepartmentName == ""))
                    throw new ArgumentNullException("Название отдела.");
                if ((DepartmentSmallName == null) || (DepartmentSmallName == ""))
                    throw new ArgumentNullException("Краткое название отдела.");
                //if (PlanStaff.IsNull())
                //    PlanStaff = null;
            }
        }

        partial void OnLoaded()
        {
            //if (PlanStaff == null)
            //    PlanStaff = NullPlanStaff.Instance;

        }


        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            return new DepartmentDecorator(this);
        }

        #endregion


        #region INull Members

        bool INull.IsNull()
        {
            return false;
        }

        #endregion

        #region IValidatable Members

        public void Validate()
        {
            OnValidate(ChangeAction.Insert);            
        }

        #endregion

        #region IObjectState Members

        public ObjectState State()
        {
            if (dateExit == null)
                return ObjectState.Current;
            else
                return ObjectState.Canceled;
        }

        #endregion

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return (DepartmentName.CompareTo(obj.ToString()));
        }

        #endregion
    }

    public class NullDepartment : Department, INull
    {

        private NullDepartment()
        {
            this.id = 0;
            this.DepartmentName = "(Не задан)";
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
    }

}
