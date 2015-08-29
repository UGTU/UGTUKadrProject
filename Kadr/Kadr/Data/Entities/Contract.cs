using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    /// <summary>
    /// Есть рекурсивная ссылка - если заполнена, то это доп соглашение к договору.
    /// </summary>
    public partial class Contract : UIX.Views.IValidatable
    {
        public Contract(FactStaffHistory factStaffHistory, string contractName = null, DateTime? dateContract = null, DateTime? dateBegin = null, DateTime? dateEnd = null): this()
        {
            factStaffHistory.Contract = this;
            ContractName = contractName;
            DateContract = dateContract;
            DateBegin = dateBegin;
            DateEnd = dateEnd;
        }

        public Contract MainContract
        {
            get
            {
                return Contract1;
            }
            set
            {
                Contract1 = value;
            }
        }


        public override string ToString()
        {
            if (MainContract == null)
                return "Договор " +  ContractName;
            else
                return "Доп соглашение " + ContractName + " к договору " + MainContract.ToString();
        }



        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;

                if (DateBegin == DateTime.MinValue)
                    DateBegin = null;

                if (DateContract == DateTime.MinValue)
                    DateContract = null;

                if ((DateEnd != null) && (DateBegin != null))
                    if (DateEnd <= DateBegin)
                        throw new ArgumentOutOfRangeException("Дата окончания договора должна быть позже даты начала.");
            }
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
