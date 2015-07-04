using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public class FactStaffHourContract : UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        private FactStaff factStaff;
        public FactStaff FactStaff
        {
            get
            {
                return factStaff;
            }
        }

        public FactStaffHourContract(FactStaff factStaff)
        {
            this.factStaff = factStaff;
        }

        public FactStaffHourContract()
        {
            this.factStaff = new Data.FactStaff();
        }

        public override string ToString()
        {
            return FactStaff.ToString();
        }

        #region IDecorable Members

        public object GetDecorator()
        {
            return new FactStaffHourContractDecorator(FactStaff);
        }


        #endregion



        #region partial Methods


        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        private void OnValidate(System.Data.Linq.ChangeAction action)
        {
            UIX.Views.IValidatable validatable = (factStaff as UIX.Views.IValidatable);
            if (validatable != null)
                validatable.Validate();
        }

        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion
    }



}




