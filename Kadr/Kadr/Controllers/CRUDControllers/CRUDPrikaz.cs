using Kadr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UIX.Commands;

namespace Kadr.Controllers.CRUDControllers
{
    public static class CRUDPrikaz
    {
        public static Prikaz Create(string Name, PrikazType pt, DateTime? Date, DateTime? DateBegin, DateTime? DateEnd)
        {
            Prikaz p = new Prikaz();
            p.PrikazType = pt;
            p.PrikazName = Name;
            p.DatePrikaz = Date;
            p.DateBegin = DateBegin;
            p.DateEnd = DateEnd;
            KadrController.Instance.Model.Prikazs.InsertOnSubmit(p);
            //KadrController.Instance.Model.SubmitChanges();
            return p;
        }

        public static void Read()
        {

        }

        public static void Update()
        {
            
        }

        public static void Delete(Prikaz p)
        {
            KadrController.Instance.Model.Prikazs.DeleteOnSubmit(p);
            KadrController.Instance.Model.SubmitChanges();
        }
    }
}
