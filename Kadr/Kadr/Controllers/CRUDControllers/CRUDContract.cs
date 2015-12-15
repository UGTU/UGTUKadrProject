using System;

using Kadr.Data;

namespace Kadr.Controllers
{
    class CRUDContract
    {
        public static Contract Create(string Name, DateTime? Date, DateTime? DateBegin, DateTime? DateEnd)
        {
            Contract c = new Contract();
            c.ContractName = Name;
            c.DateContract = Date;
            c.DateBegin = DateBegin;
            c.DateEnd = DateEnd;
            KadrController.Instance.Model.Contracts.InsertOnSubmit(c);
            //KadrController.Instance.Model.SubmitChanges();
            return c;
        }
    }
}
