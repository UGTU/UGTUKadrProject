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

        public static EventKind ReplacementBeginEventKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 10);
            }
        }

        public static EventKind FactStaffChangeMainEventKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 2);
            }
        }

        public static IEnumerable<EventKind> FactStaffChangeEventKinds
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Where(x => x.EventKind1 == MagicNumberController.FactStaffChangeMainEventKind).ToArray();
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
                return KadrController.Instance.Model.EventKinds.SingleOrDefault(x => x.id == 18);
            }
        }
        public static EventKind VacationKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.SingleOrDefault(x => x.id == 15);
            }
        }

        public static PrikazType BusinessTripPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 42);
            }
        }

        public static PrikazType MaterialPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 18);
            }
        }

        public static PrikazType DopEducPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 44);
            }
        }

        public static PrikazType SocialFareTransitPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 43);
            }
        }

        public static PrikazType OtpuskPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 21);
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

        public static EventType ChangeTermsEventType { 
            get
            {
                return KadrController.Instance.Model.EventTypes.Single(x => x.id == 3);
            }
        }
    }
}
