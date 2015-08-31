using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class OK_Adress : UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        public override string ToString()
        {
            return "Адрес " + Employee.EmployeeSmallName;
        }

        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {

                if (Employee.IsNull() || Employee == null) throw new ArgumentNullException("Сотрудник.");
                if ((Adress == null) || (Adress == "")) throw new ArgumentNullException("Адрес.");
                if (DateReg == DateTime.MinValue)
                    DateReg = null;
                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;
            }
        }


        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion

        #region Члены IDecorable

        public object GetDecorator()
        {
            return new OK_AdressDecorator(this);
        }

        #endregion
    }
}