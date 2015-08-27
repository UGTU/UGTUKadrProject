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
    public partial class Contract
    {
        
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
    }
}
