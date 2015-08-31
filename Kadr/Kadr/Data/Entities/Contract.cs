﻿using System;
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

        public override string ToString()
        {
            if (MainContract == null)
                return "Договор " + ContractName;
            else
                return "Доп соглашение " + ContractName + " к договору " + MainContract.ToString();
        }

        #region MainContractData

        /// <summary>
        /// Основной договор, если есть
        /// </summary>
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

        /// <summary>
        /// Признак договора - используется при создании объекта
        /// </summary>
        private bool? isMainContract = null;


        /// <summary>
        /// Признак основного договора (не доп соглашения) 
        /// </summary>
        public bool IsMainContract
        {
            get
            {
                if (isMainContract == null)
                    return (MainContract == null);
                else
                    return isMainContract.Value;
            }
            set
            {
                isMainContract = value;
            }
        }
        #endregion

        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (ContractName == null)
                    throw new ArgumentNullException("Номер договора.");
                
                if (DateEnd == DateTime.MinValue)
                    DateEnd = null;

                if (DateBegin == DateTime.MinValue)
                    DateBegin = null;

                if (DateContract == DateTime.MinValue)
                    DateContract = null;

                if ((DateEnd != null) && (DateBegin != null))
                    if (DateEnd < DateBegin)
                        throw new ArgumentOutOfRangeException("Дата окончания договора/доп. соглашения должна быть позже даты начала.");
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
