using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using UIX.Views;
using UIX.Commands;

namespace Kadr.Data
{
    public partial class BusinessTripRegionType :  IComparable, IDecorable, IValidatable, IEmployeeExperienceRecord
    {
      
        #region Properties

        //public int ID { get { return idRegionType; } set { idRegionType = value; } }

        #endregion

        public BusinessTripRegionType(DateTime beg, DateTime end, RegionType regiontype)
        {
            DateBegin = beg;
            DateEnd = end;
            RegionType = regiontype;
        }

        public BusinessTripRegionType(ICommandManager commandManager, 
            BusinessTrip trip, DateTime beg, DateTime end, RegionType regionType) : this()
        {
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTripRegionType, DateTime>(this, "DateBegin", beg, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTripRegionType, DateTime>(this, "DateEnd", end, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTripRegionType, RegionType>(this, "RegionType", regionType, null), null);
            commandManager.Execute(new UIX.Commands.GenericPropertyCommand<BusinessTripRegionType, BusinessTrip>(this, "BusinessTrip", trip, null), null);
        }

        public override string ToString()
        {
            
            return $"С {DateBegin.ToShortDateString()} по {DateEnd.ToShortDateString()} в {RegionType.RegionTypeName}";
            
        }

        #region partial Methods


        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if ((idBusinessTrip == 0) && (BusinessTrip == null)) throw new ArgumentNullException("Командировка");
                if ((idRegionType == 0) && (RegionType == null)) throw new ArgumentNullException("Регион пребывания");

                if (DateBegin > DateEnd) throw new ArgumentOutOfRangeException("Дата начала пребывания в регионе не может быть позже даты окончания!");
                if ((BusinessTrip.Event.DateBegin > DateBegin) || (BusinessTrip.Event.DateEnd < DateBegin)) throw new ArgumentOutOfRangeException("Дата начала пребывания выходит за рамки командировки!");
                if ((BusinessTrip.Event.DateBegin > DateEnd) || (BusinessTrip.Event.DateEnd < DateEnd)) throw new ArgumentOutOfRangeException("Дата окончания пребывания выходит за рамки командировки!");
            }
        }

        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion


        #region IDecorable Members

        public object GetDecorator()
        {
            return new BusinessTripRegionTypeDecorator(this);
        }

        #endregion


        public int CompareTo(object obj)
        {
            return ToString().CompareTo(obj.ToString());
        }


        public DateTime StartOfWork => DateBegin;

        public DateTime? EndOfWork => DateEnd;

        public TerritoryConditions Territory => (RegionType??RegionType.Default).GetTerritoryCondition();

        public KindOfExperience Experience => BusinessTrip.Event.FactStaff.Experience;

        public Affilations Affilation => Affilations.Organization;

        public WorkOrganizationWorkType WorkWorkType => BusinessTrip.Event
            .FactStaff.WorkType.GetOrganizationWorkType();

        public DateTime Start { get { return StartOfWork; }
            set { DateBegin = value; }
        }
        public DateTime Stop { get { return DateEnd; }
            set { DateEnd = value; }
        }
        /// <summary>
        /// <remarks>Командировки всегда имеют дату завершения, 
        /// а потому считаются событиями завершёнными</remarks>
        /// </summary>
        public bool IsEnded => true;
    }
}
