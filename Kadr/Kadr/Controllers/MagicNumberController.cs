using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;

namespace Kadr.Controllers
{
    class MagicNumberController
    {
        #region EventKinds
        public static EventKind MatResponsibilityKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 16);
            }
        }

        public static EventKind DopEducKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 19);
            }
        }

        public static EventKind FactStaffCreateEventKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 1);
            }
        }

        public static EventKind VacationEventKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 15);
            }
        }

        #endregion

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
                return Kadr.Controllers.KadrController.Instance.Model.EventKinds.SingleOrDefault(x => x.id == 17);
            }
        }

        public static EventKind ValidationKind
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.EventKinds.SingleOrDefault(x => x.id == 18);
            }
        }
        public static EventKind VacationKind
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.EventKinds.SingleOrDefault(x => x.id == 15);
            }
        }

        public static PrikazType BusinessTripPrikazType
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 42);
            }
        }

        static public StandingType DefaultStandingType
        {
            get
            {
                return KadrController.Instance.Model.StandingTypes.Single(x => x.id == 1);
            }

        }

        static public RegionType DefaultRegionType
        {
            get
            {
                return KadrController.Instance.Model.RegionTypes.Single(x => x.id == 1);
            }
        }
    }
}
