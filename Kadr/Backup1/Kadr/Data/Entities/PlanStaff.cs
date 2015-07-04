using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class PlanStaff : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState
    {
        public override string ToString()
        {
            return  Department.ToString()+", "+ Post.PostName+", "+Prikaz.ToString();               
        }

        public string SalarySize
        {
            get
            {
                //если есть индивидуальный оклад, загружаем его
                if (HaveIndivSal)
                {
                    return planStaffSalary.SalarySize.ToString();
                }
                //иначе - оклад смотрим по категории
                else
                {
                    if (Post.PKCategory.HaveSalary)
                        return Post.PKCategory.PKCategorySalary.SalarySize.ToString();
                }
                return "     – ";
            }
        }

        public PlanStaffSalary planStaffSalary
        {
            get
            {
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

        #region partial Methods
        partial void OnCreated()
        {
            //Category = NullCategory.Instance;
            //Prikaz = NullPrikaz.Instance;
            //Prikaz1 = NullPrikaz.Instance;
            //Post = NullPost.Instance;
            StaffCount = 1;

        }

        //partial void OnDeleted()
        //{
        //}

        
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {            
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (FinancingSource.IsNull()) throw new ArgumentNullException("Источник финансирования в записи штатного расписания.");
                if (Category.IsNull()) throw new ArgumentNullException("Категория в записи штатного расписания.");
                if (Post.IsNull()) throw new ArgumentNullException("Должность в записи штатного расписания.");
                if (Prikaz.IsNull()) throw new ArgumentNullException("Приказ в записи штатного расписания.");
                if (StaffCount <= 0) throw new ArgumentOutOfRangeException("Количество ставок в записи штатного расписания.");
                if ((Prikaz1 != null) && (Prikaz1 == Prikaz))
                    throw new ArgumentOutOfRangeException("Приказы назначения и отмены не должны совпадать.");
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
            if ((Prikaz1 == null))
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
