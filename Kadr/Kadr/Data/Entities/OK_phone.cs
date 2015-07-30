using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class OK_phone : UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        public override string ToString()
        {
            return "Номер телефона " + Employee.EmployeeSmallName;
        }

        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {

                if (Employee.IsNull() || Employee == null) throw new ArgumentNullException("Сотрудник.");
                if (phone == "" || phone == null) throw new ArgumentNullException("Номер телефона.");
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
            return new OK_phoneDecorator(this);
        }

        #endregion
    }
}
