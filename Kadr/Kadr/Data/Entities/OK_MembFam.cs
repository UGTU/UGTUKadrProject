using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Linq;
using Kadr.Data.Common;

namespace Kadr.Data
{
    partial class OK_MembFam : UIX.Views.IValidatable, INull
    {
        public override string ToString()
        {
            return membfamname;
        }

        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {

                //if (Employee.IsNull() || Employee == null) throw new ArgumentNullException("Сотрудник.");
                //if (phone == "" || phone == null) throw new ArgumentNullException("Номер телефона.");
            }
        }


        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion

        #region Члены INull

        bool INull.IsNull()
        {
            return false;

        }

        #endregion
    }

    public class NullOK_MembFam : OK_MembFam, INull
    {

        private NullOK_MembFam()
        {
            this.idmembfam = 0;
        }

        public static readonly NullOK_MembFam Instance = new NullOK_MembFam();

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

