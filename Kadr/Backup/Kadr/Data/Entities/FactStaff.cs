using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;


namespace Kadr.Data
{

    public partial class FactStaff : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState
    {
        #region Properties


        public Kadr.Data.Department Department
        {
            get
            {
                return PlanStaff.Department;
            }
            set
            {
                PlanStaff.Department = value;
            }
        }

        public Kadr.Data.Post Post
        {
            get
            {
                return PlanStaff.Post;
            }
            set
            {
                PlanStaff.Post = value;
            }
        }

        #endregion 

        public override string ToString()
        {
            return this.PlanStaff.Post.ToString() + ", " + Employee.ToString();
        }


        #region partial Methods

        partial void OnCreated()
        {
            //PlanStaff = NullPlanStaff.Instance;
            //Employee = NullEmployee.Instance;
            //WorkType = NullWorkType.Instance;
            //Prikaz = NullPrikaz.Instance;
            StaffCount = 1;
            DateBegin = DateTime.Today;
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (PlanStaff.IsNull()) throw new ArgumentNullException("Элемент штатного расписания.");
                if (Employee.IsNull()) throw new ArgumentNullException("Сотрудник.");
                if (WorkType.IsNull()) throw new ArgumentNullException("Вид работы.");
                if (Prikaz.IsNull()) throw new ArgumentNullException("Приказ назначения.");
                if (this.DateBegin == null)
                    throw new ArgumentNullException("Дата назначения на работу.");
                if (StaffCount <= 0) throw new ArgumentOutOfRangeException("Количество ставок.");
                if ((DateEnd != null) && (DateEnd<=DateBegin))
                    throw new ArgumentOutOfRangeException("Дата увольнения должна быть позже даты назначения.");
                if ((Prikaz1 != null) && (Prikaz1 == Prikaz))
                    throw new ArgumentOutOfRangeException("Приказы назначения и увольнения не должны совпадать.");


            }
        }

        #endregion


        #region IDecorable Members

        public object GetDecorator()
        {
            return new FactStaffDecorator(this);
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
            if ((Prikaz1 == null) && (DateEnd == null))
                return ObjectState.Current;
            else
                return ObjectState.Canceled;

        }

        #endregion
    }


    public class NullFactStaff : FactStaff, INull
    {

        private NullFactStaff()
        {
            this.id = 0;
        }

        public static readonly NullFactStaff Instance = new NullFactStaff();

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
