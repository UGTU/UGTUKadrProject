﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class Dep : UIX.Views.IDecorable, UIX.Views.IValidatable, INullable, IObjectState, IComparable
    {
        private System.Collections.Generic.List<DepartmentHistory> _departmentHistoriesCache = null;
        public IList<DepartmentHistory> DepartmentHistoriesCache
        {
            get
            {

                if (_departmentHistoriesCache == null)
                {
                    if (DepartmentHistories.Count == 0) return DepartmentHistories;
                    _departmentHistoriesCache = DepartmentHistories.ToList();
                }

                return _departmentHistoriesCache;
            }
        }

        private DepartmentHistory lastChange = null;
        //private DepartmentHistory currentChange = null;

        

        protected Department fullDepartment = null;

        public Department FullDepartment
        {
            get
            {
                if (fullDepartment == null)
                {
                    fullDepartment = KadrController.Instance.Model.Departments.SingleOrDefault(dep => dep.id == id);
                }
                return fullDepartment;
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

            return FullDepartment.DepartmentName + GetDepartmentManager() ;
        }

        protected FactStaff departmentManager = null;

        public string GetDepartmentManager()
        {
            try
            {
                if (departmentManager == null)
                {
                    if (PlanStaff != null)
                    {
                        //берем первого руководителя из списка неуволенных
                        departmentManager = PlanStaff.FactStaffs.Where(fctStaff => fctStaff.Prikaz == null).First() as FactStaff;
                    }
                }

                if (departmentManager != null)
                    return " (" + departmentManager.Employee.EmployeeName + ")";

            }
            catch (InvalidOperationException)
            {
                return "";
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
                //if ((id < 1) && (DepartmentHistories.Count < 1))
                //    return NullDepartmentHistory.Instance;

                if (lastChange.IsNull())
                    /*.Where(dep => dep.DateBegin<= DateTime.Today)*/
                    lastChange = DepartmentHistoriesCache.FirstOrDefault(depHist => DepartmentHistoriesCache.Max(p=>p.DateBegin)==depHist.DateBegin);

                if (lastChange.IsNull())
                    lastChange = NullDepartmentHistory.Instance;

                    return lastChange;
                }
        }

        /// <summary>
        /// Текущее (действующее) изменение отдела
        /// </summary>
        public Department CurrentChange
        {
            get
            {
                //if ((id < 1) && (DepartmentHistoriesCache.Count < 1))
                // return NullDepartmentHistory.Instance;
                //if (currentChange == null)
                    //currentChange = DepartmentHistories.Where(dep => dep.DateBegin <= DateTime.Today).OrderBy(depHist => depHist.DateBegin).LastOrDefault(/*depHist => DepartmentHistoriesCache.Max(p => p.DateBegin) == depHist.DateBegin*/);
                //DepartmentHistory currentChange = DepartmentHistories.Where(dep => dep.DateBegin <= DateTime.Today).OrderBy(depHist => depHist.DateBegin).ToArray().LastOrDefault();
                //if (currentChange.IsNull())
                    //currentChange = CurrentChange;

                return FullDepartment;
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

        /// <summary>
        /// адрес текущий
        /// </summary>
        public string CurrentAddress
        {
            get
            {
                return (CurrentChange == null) ? null : CurrentChange.Address;
            }
            set
            {
                if (CurrentChange != null)
                    CurrentChange.Address = value;
            }
        }

        public RegionType CurrentRegionType
        {
            get
            {
                return (CurrentChange == null) ? null : CurrentChange.RegionType;
            }
            /*set
            {
                if (CurrentChange != null)
                    CurrentChange.RegionType = value;
            }*/
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
                //if ((id < 1) && (DepartmentHistoriesCache.Count < 1))
                //    return NullDepartmentHistory.Instance;
                DepartmentHistory lc = DepartmentHistoriesCache.OrderBy(depHist => depHist.DateBegin).ToArray().FirstOrDefault();
                if (lc != null)
                    return lc;
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
                return DepartmentHistories1.Select(x => x.Dep);

                //IEnumerable<Department> departments = KadrController.Instance.Model.Departments.Where(dep => dep.idManagerDepartment == id).OrderBy(dep => dep.DepartmentName).ToArray();
                //return KadrController.Instance.GetDepsForDepartments(departments);
            }
        }

        public DateTime dateBegin
        {
            get
            {
                if (CurrentChange == null)
                    return DateTime.Today;
                else
                    return CurrentChange.dateCreate;
            }
            set
            {
                CurrentChange.dateCreate = value;
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
                if (CurrentChange == null)
                    return -1;
                else
                    return CurrentChange.idManagerDepartment;
            }
            set
            {
                CurrentChange.idManagerDepartment = value;
            }
        }

        public string DepartmentName
        {
            get
            {
                if (CurrentChange == null)
                    return null;
                else
                    return CurrentChange.DepartmentName;
            }
            set
            {
                if (CurrentChange != null)
                    CurrentChange.DepartmentName = value;
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
                if (CurrentChange != null)
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


        #region IValidatable Members

        public void Validate()
        {
            OnValidate(ChangeAction.Insert);            
        }

        #endregion

        #region IObjectState Members

        public ObjectState State()
        {
            if (((dateExit == null) || (dateExit > DateTime.Today)) && (dateBegin <= DateTime.Today))
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



        public override string ToString()
        {
            return "(Не задан)";
        }

    }

}
