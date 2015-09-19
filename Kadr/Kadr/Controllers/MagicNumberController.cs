using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;

namespace Kadr.Controllers
{
    class MagicNumberController
    {
        public static EventKind MatResponsibilityKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 16);
            }
        }

        public static EventType BeginEventType
        {
            get
            {
                return KadrController.Instance.Model.EventTypes.Single(x => x.id == 1);
            }
        }

        public static EventType EndEventType
        {
            get
            {
                return KadrController.Instance.Model.EventTypes.Single(x => x.id == 2);
            }
        }

        static public EventKind BusinessTripKind
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.EventKinds.Where(x => x.id == 17).SingleOrDefault();
            }
        }
    }
}
