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
        public static Dep UGTUDep
        {
            get
            {
                return KadrController.Instance.Model.Deps.Where(dep => dep.id == 1).SingleOrDefault();
            }
        }
        
        public Department FullDepartment
        {
            get
            {
                return KadrController.Instance.Model.Departments.Where(dep => dep.id == id).FirstOrDefault();
            }
        }


        /// <summary>
        /// возвращает текущую норму времени для отдела по источнику финансирования
        /// </summary>
        /// <param name="financingSource"></param>
        /// <returns></returns>
        public decimal GetTimeNormForFinSource(FinancingSource FinancingSource)
        {
            DepartmentTimeNorm norm =
                DepartmentTimeNorms.Where(tn =>
                    tn.FinancingSource == FinancingSource).Where(tn =>
                    tn.DateBegin <= DateTime.Today).OrderByDescending(tn => tn.DateBegin).FirstOrDefault();
            if (norm != null)
                return norm.NormHoursCount;
            return 0;
        }

        /// <summary>
        /// Возвращает занятое кол-во часов (почасовой работы) для источника финансирования
        /// </summary>
        /// <param name="FinancingSource"></param>
        /// <returns></returns>
        public decimal GetBusyHourCountForFinSource(FinancingSource FinancingSource)
        {
            decimal busyHourCount = 0;
            foreach (FactStaff hourFcSt in FactStaffs)
            {
                if (((hourFcSt as IObjectState).State() == ObjectState.Current) && (hourFcSt.FinancingSource == FinancingSource))
                    busyHourCount += Convert.ToDecimal(hourFcSt.HourCount);
            }
            return busyHourCount;
        }

        public override string ToString()
        {

            return this.DepartmentSmallName + GetDepartmentManager() ;
        }

        public string GetDepartmentManager()
        {
            if (PlanStaff != null)
            {
                try
                {
                    //берем первого руководителя из списка неуволенных
                    FactStaff factStaff = PlanStaff.FactStaffs.Where(fctStaff => fctStaff.Prikaz == null).First() as FactStaff;
                    if (factStaff != null)
                        return " ("+factStaff.ToString()+")";
                }
                catch (InvalidOperationException)
                {
                    return "";
                }
            }
            return "";
        }

        public Department Department
        {
            get
            {
                if (Kadr.Controllers.KadrController.Instance.Model.Departments.Where(dp => dp.id == id).Count() > 0)
                    return Kadr.Controllers.KadrController.Instance.Model.Departments.Where(dp => dp.id == id).FirstOrDefault();
                else return null;
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
                DepartmentHistory lastChange = DepartmentHistories/*.Where(dep => dep.DateBegin<= DateTime.Today)*/.OrderBy(depHist => depHist.DateBegin).ToArray().LastOrDefault();
                if (lastChange != null)
                    return lastChange;
                else
                    return NullDepartmentHistory.Instance;
            }
        }

        /// <summary>
        /// Текущее (действующее) изменение отдела
        /// </summary>
        public DepartmentHistory CurrentChange
        {
            get
            {
                if ((id < 1) && (DepartmentHistories.Count < 1))
                    return NullDepartmentHistory.Instance;
                DepartmentHistory currentChange = DepartmentHistories.Where(dep => dep.DateBegin <= DateTime.Today).OrderBy(depHist => depHist.DateBegin).ToArray().LastOrDefault();
                if (currentChange != null)
                    return currentChange;
                return LastChange;
            }
        }
        /// <summary>
        /// Последний бюдж. фонд отдела
        /// </summary>
        public DepartmentFund LastFund
        {
            get
            {
                if ((id < 1) && (DepartmentFunds.Count < 1))
                    return NullDepartmentFund.Instance;
                DepartmentFund lastFund = DepartmentFunds.OrderBy(depFund => depFund.DateBegin).ToArray().LastOrDefault();
                if (lastFund != null)
                    return lastFund;
                else
                    return NullDepartmentFund.Instance;
            }
        }

        /// <summary>
        /// Текущий бюдж. фонд отдела
        /// </summary>
        public DepartmentFund CurrentFund
        {
            get
            {
                if ((id < 1) && (DepartmentFunds.Count < 1))
                    return NullDepartmentFund.Instance;
                DepartmentFund lastFund = DepartmentFunds.Where(depFund => depFund.DateBegin <= DateTime.Today).OrderBy(depFund => depFund.DateBegin).ToArray().LastOrDefault();
                if (lastFund != null)
                    return lastFund;
                else
                    return NullDepartmentFund.Instance;
            }
        }

        public decimal DepExtraordSum
        {
            get
            {
                return CurrentFund.ExtraordSum;
            }
            set
            {
                CurrentFund.ExtraordSum = value;
            }
        }

        public decimal DepPlanFundSum
        {
            get
            {
                return CurrentFund.PlanFundSum;
            }
            set
            {
                CurrentFund.PlanFundSum = value;
            }
        }

        public decimal DepFactFundSum
        {
            get
            {
                return CurrentFund.FactFundSum;
            }
            set
            {
                CurrentFund.FactFundSum = value;
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

        public int? idManagerDepartment
        {
            get
            {
                if (LastChange == null)
                    return -1;
                else
                    return LastChange.idManagerDepartment;
            }
            set
            {
                LastChange.idManagerDepartment = value;
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
                if (CurrentChange == null)
                    return null;
                else
                    return CurrentChange.DepartmentSmallName;
            }
            set
            {
                CurrentChange.DepartmentSmallName = value;
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
                if (dateExit == DateTime.MinValue)
                    dateExit = null;
                if (FundingCenter.IsNull())
                    FundingCenter = null;
                if (OKVED != null)
                    if (OKVED.IsNull())
                        OKVED = null;

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
            if (((dateExit == null) || (dateExit > DateTime.Today)) && (dateCreate <= DateTime.Today))
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
