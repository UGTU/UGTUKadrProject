using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class OK_DopInf : UIX.Views.IValidatable, UIX.Views.IDecorable
    {
        public override string ToString()
        {
            return "Запись дополнительных сведений "+Employee;
        }

        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {

                if (Employee.IsNull() || Employee == null) throw new ArgumentNullException("Сотрудник.");
                if (DopInf == "" || DopInf == null) throw new ArgumentNullException("Дополнительные сведения.");
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
            return new OK_DopInfDecorator(this);
        }

        #endregion
    }
}

