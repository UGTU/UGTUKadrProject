using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Dep : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState, IComparable
    {
        public Department FullDepartment
        {
            get
            {
                return KadrController.Instance.Model.Departments.Where(dep => dep.id == id).FirstOrDefault();
            }
        }

        public override string ToString()
        {

            if (PlanStaff != null)
            {
                try
                {
                    //берем первого руководителя из списка неуволенных
                    FactStaff factStaff = PlanStaff.FactStaffs.Where(fctStaff => fctStaff.Prikaz == null).First() as FactStaff;
                    if (factStaff != null)
                        return this.DepartmentSmallName + " (" + factStaff.ToString() + ")";
                }
                catch (InvalidOperationException)
                {
                    return this.DepartmentSmallName;
                }
            }
            return this.DepartmentSmallName;
        }

        public Department Department
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.Departments.Where(dp => dp.id == id).FirstOrDefault();
            }
        }

        #region DepartmentHistory Data

        /// <summary>
        /// Последнее изменение отдела
        /// </summary>
        public DepartmentHistory LastChange
        {
            get
            {
                if ((id < 1) && (DepartmentHistories.Count < 1))
                    return NullDepartmentHistory.Instance;
                DepartmentHistory lastChange = DepartmentHistories.OrderBy(depHist => depHist.DateBegin).ToArray().LastOrDefault();
                if (lastChange != null)
                    return lastChange;
                else
                    return NullDepartmentHistory.Instance;
            }
        }

        /// <summary>
        /// Первоначальное изменение отдела (фактически создание)
        /// </summary>
        public DepartmentHistory CreatingChange
        {
            get
            {
                if ((id < 1) && (DepartmentHistories.Count < 1))
                    return NullDepartmentHistory.Instance;
                DepartmentHistory lastChange = DepartmentHistories.OrderBy(depHist => depHist.DateBegin).ToArray().FirstOrDefault();
                if (lastChange != null)
                    return lastChange;
                else
                    return NullDepartmentHistory.Instance;
            }
        }
        
        /// <summary>
        /// Подчиненные отделы данного отдела
        /// </summary>
        public IEnumerable<Dep> Deps
        {
            get
            {
                IEnumerable<Department> departments = KadrController.Instance.Model.Departments.Where(dep => dep.idManagerDepartment == id).OrderBy(dep => dep.DepartmentName).ToArray();
                return KadrController.Instance.GetDepsForDepartments(departments);
            }
        }

        public DateTime dateCreate
        {
            get
            {
                if (CreatingChange == null)
                    return DateTime.Today;
                else
                    return CreatingChange.DateBegin;
            }
            set
            {
                CreatingChange.DateBegin = value;
            }
        }

        public Dep ManagerDepartment
        {
            get
            {
                if (LastChange == null)
                    return null;
                else
                    return LastChange.Dep1;
            }
            set
            {
                LastChange.Dep1 = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                if (LastChange == null)
                    return null;
                else
                    return LastChange.DepartmentName;
            }
            set
            {
                LastChange.DepartmentName = value;
            }
        }

        public string DepartmentSmallName
        {
            get
            {
                if (LastChange == null)
                    return null;
                else
                    return LastChange.DepartmentSmallName;
            }
            set
            {
                LastChange.DepartmentSmallName = value;
            }
        }

        public Prikaz PrikazBegin
        {
            get
            {
                if (LastChange == null)
                    return null;
                else
                    return LastChange.Prikaz;
            }
            set
            {
                LastChange.Prikaz = value;
            }
        }
        #endregion


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
                //if ((Prikaz.IsNull()))
                //    throw new ArgumentNullException("Приказ о создании отдела.");
                if (dateExit == DateTime.MinValue)
                    dateExit = null;
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
            if ((dateExit == null) || (dateExit>DateTime.Today))
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

    public class NullDepartment : Dep, INull
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
    }

}
