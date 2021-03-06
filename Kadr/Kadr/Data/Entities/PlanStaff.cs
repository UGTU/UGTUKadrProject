﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
//using System.Diagnostics.;

namespace Kadr.Data
{
    public partial class PlanStaff : UIX.Views.IDecorable, UIX.Views.IValidatable, INullable, IObjectState
    {
        public override string ToString()
        {
            string depStr = Dep.DepartmentName + ", " + Post.PostName + " (" + Post.PKCategory.ToString() + ")";
            if (FinancingSource != null)
                depStr = Dep.DepartmentName + ", " + Post.PostName + " (" + Post.PKCategory.ToString() + "), " + FinancingSource.ToString();                 
            if (PrikazBegin != null)
                depStr += ", " + PrikazBegin.ToString();
            return depStr;
        }

        public bool CanAddFactStaff
        {
            get
            {
                return (StaffCount > FactStaffCount);
                    
            }
        }

        /// <summary>
        /// кол-во вакансий (свободных ставок без учета замещений)
        /// </summary>
        public decimal FreeFactStaffCount
        {
            get
            {
                return (StaffCount - FactStaffCount);
            }
        }

        
        /// /// <summary>
        /// кол-во занятых ставок без замещений
        /// </summary>
        public decimal FactStaffCount
        {
            get
            {
                return FactStaffs.Where(factSt => ((factSt.Prikaz == null) || (factSt.DateEnd > DateTime.Today)) && (!factSt.IsReplacement)).Sum(factSt => factSt.StaffCount);
            }
        }

        /// <summary>
        /// кол-во занятых ставок с учетом замещений
        /// </summary>
        public decimal AllFactStaffCount
        {
            get
            {
                return FactStaffs.Where(factSt => ((factSt.Prikaz == null) || (factSt.DateEnd > DateTime.Today))).Sum(factSt => factSt.StaffCount);
            }
        }

        public Category Category
        {
            get
            {
                if (Post.Category == null)
                    return NullCategory.Instance;
                return Post.Category;
            }
        }

        public decimal FreeStaffCount
        {
            get
            {
                return (StaffCount - FactStaffCount);
            }
        }
        /*public int idCategory
        {
            get
            {
                if (Post.Category == null)
                    return 0;
                return Post.Category.id;
            }
        }*/

        public string SalarySize
        {
            get
            {
                //если есть индивидуальный оклад, загружаем его
                if (HaveIndivSal)
                {
                    return PlanStaffSalary.SalarySize.ToString("N2");
                }
                //иначе - оклад смотрим по категории
                else
                {
                    //Contract.Requires(Post != null);
                    //Contract.Requires(Post.PKCategory != null);
                    //Contract.Requires(Post.PKCategory.PKCategorySalary != null);

                    if (Post.PKCategory.HaveSalary)
                        return Post.PKCategory.PKCategorySalary.SalarySize.ToString("N2");
                }
                return "     – ";
            }
        }

        public PlanStaffSalary PlanStaffSalary
        {
            get
            {
                //Contract.Requires(PlanStaffalaries != null);
                if (PlanStaffSalaries.Count() >0)
                    if (PlanStaffSalaries.Where(plStSal => ((plStSal.DateEnd == null) || (plStSal.DateEnd > DateTime.Today)) && (plStSal.SalarySize > 0)).Count() > 0)
                        return PlanStaffSalaries.Where(plStSal => ((plStSal.DateEnd == null) || ((plStSal.DateBegin <= DateTime.Today) && (plStSal.DateEnd > DateTime.Today))) && (plStSal.SalarySize > 0)).LastOrDefault();
                return null;
            }
        }
        
        /// <summary>
        /// показатель индивидуального оклада
        /// </summary>
        public bool HaveIndivSal
        {
            get
            {
                return (PlanStaffSalary != null);
            }
        }

        /// <summary>
        /// показатель руководителя
        /// </summary>
        public bool ManagerBit
        {
            get
            {
                //Contract.Requires(Post != null);
                return Post.ManagerBit;
            }
        }


        public string PlanStaffCategory
        {
            get
            {

                //Contract.Requires<ArgumentNullException>(Post!= null);
                //Contract.Requires<ArgumentNullException>(Post.PKCategory != null);
                return this.Post.PKCategory.ToString();
            }
        }

        private PlanStaffHistory currentChange;

        /// <summary>
        /// возвращает последнее изменение
        /// </summary>
        public PlanStaffHistory CurrentChange
        {
            get
            {
                if (currentChange == null)
                    currentChange = PlanStaffHistories.Where(plStChange => plStChange.DateBegin <= DateTime.Today.Date).OrderBy(plStChange => plStChange.DateBegin).LastOrDefault();
                if (currentChange == null)
                    currentChange = FirstDesignate;
                return currentChange;
            }
        }

        #region partial Methods

        private PlanStaffHistory firstDesignate;

        /// <summary>
        /// возвращает первоначальное изменение
        /// </summary>
        public PlanStaffHistory FirstDesignate
        {
            get
            {
                if (firstDesignate == null)
                    firstDesignate = PlanStaffHistories.OrderBy(plStHistory => plStHistory.DateBegin).FirstOrDefault();
                return firstDesignate;

            }
        }

        /// <summary>
        /// Дата начала (первоначальная дата назначения)
        /// </summary>
        public DateTime DateBegin
        {
            get
            {
                if (FirstDesignate == null)
                    return DateTime.Today;
                else
                    return FirstDesignate.DateBegin;
            }
            set
            {
                FirstDesignate.DateBegin = value;
            }
        }


        public FinancingSource FinancingSource
        {
            get
            {
                if (CurrentChange == null)
                    return null;
                else
                    return CurrentChange.FinancingSource;
            }
            set
            {
                CurrentChange.FinancingSource = value;
            }
        }

        public decimal StaffCount
        {
            get
            {
                if (CurrentChange == null)
                    return 0;
                else
                    return CurrentChange.StaffCount;
            }
            set
            {
                CurrentChange.StaffCount = value;
            }
        }

        public Prikaz PrikazBegin
        {
            get
            {
                if (CurrentChange == null)
                    return null;
                else
                    return CurrentChange.Prikaz;
            }
            set
            {
                CurrentChange.Prikaz = value;
            }
        }
        
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {            
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (FinancingSource.IsNull()) throw new ArgumentNullException("Источник финансирования в записи штатного расписания.");
                if (Post.IsNull()) throw new ArgumentNullException("Должность в записи штатного расписания.");
                if (WorkShedule == null) throw new ArgumentNullException("График работы в записи штатного расписания.");
                if (StaffCount <= 0) throw new ArgumentOutOfRangeException("Количество ставок в записи штатного расписания.");
                /*if ((Prikaz1 != null) && (Prikaz1 == Prikaz))
                    throw new ArgumentOutOfRangeException("Приказы назначения и отмены не должны совпадать.");*/

                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;
                if (DateEnd != null)
                    if (DateEnd <= DateBegin)
                        throw new ArgumentOutOfRangeException("Дата отмены должна быть позже даты назначения.");
                    else
                        DateEnd = DateEnd.Value.Date;


            }
        }

        partial void OnLoaded()
        {

        }

        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            return new PlanStaffDecorator(this);
        }

        #endregion        

        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);            
        }

        #endregion


        #region IObjectState Members

        ObjectState IObjectState.State()
        {
            if (((Prikaz == null) || (DateEnd > DateTime.Today)) && (FirstDesignate.DateBegin <= DateTime.Today))                 
                return ObjectState.Current;
            return ObjectState.Canceled;
        }

        #endregion
    }


    public class NullPlanStaff : PlanStaff, INull
    {

        private NullPlanStaff()
        {
            this.id = 0;
        }

        public static readonly NullPlanStaff Instance = new NullPlanStaff();

        public override string ToString()
        {
            return "(Не задан)";
        }
    }

}
