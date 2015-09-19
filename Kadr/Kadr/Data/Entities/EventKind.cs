using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class EventKind
    {
        static public EventKind BusinessTripKind
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.EventKinds.Where(x => x.id == 17).SingleOrDefault();
            }
        }

        public override string ToString()
        {
            return EventKindName;
        }
    }
}
