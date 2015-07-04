using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;

namespace Kadr.Data
{
    partial class PlanStaffHistory : UIX.Views.IDecorable, UIX.Views.IValidatable, IComparable
    {
        public override string ToString()
        {
            return "Изменение "+PlanStaff.ToString();
        }

        public bool IsLatest
        {
            get
            {
                if (this == PlanStaff.PlanStaffHistories.OrderBy(plStHist => plStHist.DateBegin).LastOrDefault())
                    return true;
                else
                    return false;
            }
        }

        #region partial Methods
        partial void OnCreated()
        {
            //Category = NullCategory.Instance;
            //Prikaz = NullPrikaz.Instance;
            //Prikaz1 = NullPrikaz.Instance;
            //Post = NullPost.Instance;
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
                /*if (PlanStaff.IsNull()) throw new ArgumentNullException("Элемент штатного расписания.");
                if (Employee.IsNull()) throw new ArgumentNullException("Сотрудник.");
                if (WorkType.IsNull()) throw new ArgumentNullException("Вид работы.");
                if (Prikaz.IsNull()) throw new ArgumentNullException("Приказ назначения.");
                if (this.DateBegin == null)
                    throw new ArgumentNullException("Дата назначения на работу.");
                if (StaffCount <= 0) throw new ArgumentOutOfRangeException("Количество ставок.");
                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;
                if ((DateEnd != null) && (DateEnd <= DateBegin))
                    throw new ArgumentOutOfRangeException("Дата увольнения должна быть позже даты назначения.");
                if ((Prikaz1 != null) && (Prikaz1 == Prikaz))
                    throw new ArgumentOutOfRangeException("Приказы назначения и увольнения не должны совпадать.");*/

                if (FinancingSource == null)
                    throw new ArgumentNullException("Прежний источник финансирования.");
                if (StaffCount == 0)
                    throw new ArgumentNullException("Kол-во ставок.");
                if (DateBegin == null) 
                    throw new ArgumentNullException("Дата изменения.");
                if (((Prikaz as Kadr.Data.Common.INull).IsNull()) || (Prikaz == null))
                    throw new ArgumentNullException("Приказ изменения.");
            }
        }
        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion

        public object GetDecorator()
        {
            return new PlanStaffHistoryDecorator(this);
        }


        public int CompareTo(object obj)
        {
            return this.DateBegin.CompareTo((obj as PlanStaffHistory).DateBegin);
        }

        int IComparable.CompareTo(object obj)
        {
            return this.DateBegin.CompareTo((obj as PlanStaffHistory).DateBegin);
        }
    }
}
