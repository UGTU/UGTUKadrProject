using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;

namespace Kadr.Controllers
{
    class MagicNumberController
    {
        /// <summary>
        /// возвращает вид работы "почасовики"
        /// </summary>
        public static WorkType hourWorkType
        {
            get
            {
                return KadrController.Instance.Model.WorkTypes.Where(wt => wt.id == 19).FirstOrDefault();
            }
        }

        /// <summary>
        /// возвращает основной вид работы
        /// </summary>
        static public WorkType MainWorkType
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.WorkTypes.Where(wt => wt.id == 1).First();
            }
        }

        public static Dep UGTUDep
        {
            get
            {
                return KadrController.Instance.Model.Deps.SingleOrDefault(dep => dep.id == 1);
            }
        }

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

        public static EventKind FactStaffTransferEventKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 3);
            }
        }

        public static EventKind FactStaffHourCreateEventKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 11);
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

        public static EventKind FactStaffFinSourceChangeEventKind
        {
            get
            {
                return KadrController.Instance.Model.EventKinds.Single(x => x.id == 4);
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

        #endregion

        #region EventTypes

        public static EventType BeginEventType
        {
            get
            {
                return KadrController.Instance.Model.EventTypes.Single(x => x.id == 1);
            }
        }

        public static int BeginEventTypeId
        {
            get
            {
                return 1;
            }
        }

        public static EventType EndEventType
        {
            get
            {
                return KadrController.Instance.Model.EventTypes.Single(x => x.id == 2);
            }
        }

        #endregion

        #region PrikazType

        //Прием сотрудника
        public static PrikazType HiredPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 10);
            }
        }

        //Увольнение сотрудника
        public static PrikazType FiredPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 5);
            }
        }
        
        //Командировка
        public static PrikazType BusinessTripPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 42);
            }
        }

        //Материальная ответственность
        public static PrikazType MaterialPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 18);
            }
        }

        //Дополнительное образование
        public static PrikazType DopEducPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 44);
            }
        }

        //Отпуск
        public static PrikazType OtpuskPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 21);
            }
        }

        //Льготный проезд
        public static PrikazType SocialFareTransitPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 43);
            }
        }

        //Аттестации
        public static PrikazType ValidationPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 45);
            }
        }

        /// <summary>
        /// Договор
        /// </summary>
        public static PrikazType ContractPrikazType
        {
            get
            {
                return KadrController.Instance.Model.PrikazTypes.SingleOrDefault(x => x.id == 27);
            }
        }

        #endregion

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





        #region FinSource
        static public FinancingSource budgetFinancingSource
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.FinancingSources.Where(finS => finS.id == 1).First();
            }
        }

        static public FinancingSource extrabudgetFinancingSource
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.FinancingSources.Where(finS => finS.id == 2).First();
            }
        }

        static public FinancingSource DefaultFinancingSource
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.FinancingSources.Where(finS => finS.id == 0).First();
            }
        }

        #endregion

        static public OK_Reason TransferReason
        {
            get
            {
                return Kadr.Controllers.KadrController.Instance.Model.OK_Reasons.Where(x => x.idreason == 218).First();
            }
        }
    }
}
