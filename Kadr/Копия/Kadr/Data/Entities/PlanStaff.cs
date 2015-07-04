using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
//using System.Diagnostics.;

namespace Kadr.Data
{
    public partial class PlanStaff : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState
    {
        public override string ToString()
        {
            string depStr = Dep.DepartmentName + ", " + Post.PostName + " (" + Post.PKCategory.ToString() + ")";;
            if (FinancingSource != null)
                depStr = Dep.DepartmentName + ", " + Post.PostName + " (" + Post.PKCategory.ToString() + "), " + FinancingSource.ToString();                 
            if (PrikazBegin != null)
                depStr += ", " + PrikazBegin.ToString();
            return depStr;
        }


        public decimal FactStaffCount
        {
            get
            {
                return FactStaffs.Where(factSt => ((factSt.Prikaz == null) || (factSt.DateEnd > DateTime.Today)) && (!factSt.IsReplacement)).Sum(factSt => factSt.StaffCount);
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
                    return planStaffSalary.SalarySize.ToString("N2");
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

        public PlanStaffSalary planStaffSalary
        {
            get
            {
                //Contract.Requires(PlanStaffSalaries != null);
                if (PlanStaffSalaries.Where(plStSal => (plStSal.DateEnd == null) && (plStSal.SalarySize > 0)).Count() > 0)
                    return PlanStaffSalaries.Where(plStSal => (plStSal.DateEnd == null) && (plStSal.SalarySize > 0)).Last();
                else return null;
            }
        }
        
        /// <summary>
        /// показатель индивидуального оклада
        /// </summary>
        public bool HaveIndivSal
        {
            get
            {
                return (planStaffSalary != null);
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

        /// <summary>
        /// возвращает последнее изменение
        /// </summary>
        public PlanStaffHistory LastChange
        {
            get
            {
                return PlanStaffHistories.OrderBy(plStChange => plStChange.DateBegin).LastOrDefault();
            }
        }

        #region partial Methods

        /// <summary>
        /// возвращает первоначальное изменение
        /// </summary>
        public PlanStaffHistory FirstDesignate
        {
            get
            {
                return PlanStaffHistories.OrderBy(plStHistory => plStHistory.DateBegin).FirstOrDefault();

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
                if (LastChange == null)
                    return null;
                else
                    return LastChange.FinancingSource;
            }
            set
            {
                LastChange.FinancingSource = value;
            }
        }

        public decimal StaffCount
        {
            get
            {
                if (LastChange == null)
                    return 0;
                else
                    return LastChange.StaffCount;
            }
            set
            {
                LastChange.StaffCount = value;
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
        
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {            
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (FinancingSource.IsNull()) throw new ArgumentNullException("Источник финансирования в записи штатного расписания.");
                if (Post.IsNull()) throw new ArgumentNullException("Должность в записи штатного расписания.");
                if (StaffCount <= 0) throw new ArgumentOutOfRangeException("Количество ставок в записи штатного расписания.");
                /*if ((Prikaz1 != null) && (Prikaz1 == Prikaz))
                    throw new ArgumentOutOfRangeException("Приказы назначения и отмены не должны совпадать.");*/

                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;
                if ((DateEnd != null) && (DateEnd <= DateBegin))
                    throw new ArgumentOutOfRangeException("Дата отмены должна быть позже даты назначения.");


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

        #region INull Members

        bool INull.IsNull()
        {
            return false;
        }

        #endregion


        #region IObjectState Members

        ObjectState IObjectState.State()
        {
            if ((Prikaz == null) || (Prikaz.DatePrikaz > DateTime.Today))
                return ObjectState.Current;
            else
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
