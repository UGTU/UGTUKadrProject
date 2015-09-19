using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
using UIX.Commands;
using UIX.Views;

namespace Kadr.Data
{
    /// <summary>
    /// Есть рекурсивная ссылка - если заполнена, то это доп соглашение к договору.
    /// </summary>
    public partial class Contract : IValidatable
    {
        public const int MaterialContract = 18;

        public Contract(ICommandManager CommandManager, Event curEvent, string contractName = "", DateTime? dateContract = null, DateTime? dateBegin = null, DateTime? dateEnd = null)
            : this()
        {
            CommandManager.Execute(new GenericPropertyCommand<Contract, string>(this, "ContractName", contractName, null), null);
            CommandManager.Execute(new GenericPropertyCommand<Contract, DateTime?>(this, "DateContract", dateContract, null), null); 
            CommandManager.Execute(new GenericPropertyCommand<Contract, DateTime?>(this, "DateBegin", dateBegin, null), null); 
            CommandManager.Execute(new GenericPropertyCommand<Contract, DateTime?>(this, "DateEnd", dateEnd, null), null); 
            CommandManager.Execute(new GenericPropertyCommand<Event, Contract>(curEvent, "Contract", this, null), null);
        }

        public override string ToString()
        {
            if (MainContract == null)
                return "Договор " + ContractName+ "  от "+DateContract.Value.ToShortDateString();
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
                if (Contract1 != this)
                    return Contract1;
                else
                    return null;
            }
            set
            {
                Contract1 = value;
            }
        }

 
        /// <summary>
        /// Признак основного договора (не доп соглашения) 
        /// </summary>
        public bool IsMainContract
        {
            get
            {
                return Contract1 == null;
            }
        }
        #endregion

        #region partial Methods


        partial void OnValidate(ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if ((ContractName == null) || (ContractName == ""))
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

        void IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion


    }
}
