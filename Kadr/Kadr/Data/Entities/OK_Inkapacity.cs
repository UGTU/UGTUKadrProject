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
            return string.Format("Больничный с {1} по {2}, сотрудник: {0}", Employee.EmployeeSmallName, DateBegin, DateEnd);
        }

        #region partial Methods


        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {

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
            return null;
            //return new BusinessTripDecorator(this);
        }

        #endregion

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }
    }
}
