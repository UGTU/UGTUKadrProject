using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class OK_Inkapacity : UIX.Views.IDecorable, UIX.Views.IValidatable
    {

        public override string ToString()
        {
            if (DateEnd != null)
                return string.Format("Больничный с {1} по {2}, сотрудник: {0}", Employee.EmployeeSmallName, DateBegin, DateEnd);
            else
                return string.Format("Больничный с {1}, сотрудник: {0}", Employee.EmployeeSmallName, DateBegin);
        }

        #region partial Methods


        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if ((EducDocument == null)&&((NInkapacity==null)||(NInkapacity==""))) throw new ArgumentNullException("Подтверждающий документ"); else

                if (DateBegin == null) throw new ArgumentNullException("Дата начала периода");
                if (DateEnd == null) throw new ArgumentNullException("Дата окончания периода");

                if (DateBegin > DateEnd) throw new ArgumentOutOfRangeException("Дата начала периода не может быть позже даты окончания");

            }
        }

        #endregion

        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion

        #region IDecorable Members

        public object GetDecorator()
        {
            //return null;
            return new InkapacityDecorator(this);
        }

        #endregion

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
    }
}
