using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;

namespace Kadr.Controllers
{
    class MagicNumberController
    {
        public static EventKind MatResponsibilityKind()
        {
            return KadrController.Instance.Model.EventKinds.Single(x => x.id == 16);
        }

        public static EventType BeginEventType()
        {
            return KadrController.Instance.Model.EventTypes.Single(x => x.id == 1);
        }

        public static EventType EndEventType()
        {
            return KadrController.Instance.Model.EventTypes.Single(x => x.id == 2);
        }
    }
}
