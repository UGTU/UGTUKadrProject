using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class OK_Fam : UIX.Views.IValidatable, UIX.Views.IDecorable
    {
        public override string ToString()
        {
            return "Родственник "+Employee;
        }

        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {

                if (Employee.IsNull() || Employee == null) throw new ArgumentNullException("Сотрудник.");
                if (OK_MembFam.IsNull() || OK_MembFam == null) throw new ArgumentNullException("Степень родства.");
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
            return new OK_FamDecorator(this);
        }

        #endregion
    }
}

