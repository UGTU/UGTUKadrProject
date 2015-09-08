using System.Data.Linq;
using System;
using Kadr.Data.Common;
using Kadr.Interfaces;

namespace Kadr.Data
{
    public partial class EmployeeStanding : UIX.Views.IDecorable, UIX.Views.IValidatable, IEmployeeExperienceRecord
    {
        public override string ToString()
        {
            return "Запись трудовой книжки сотрудника " + Employee.EmployeeSmallName;
        }

        #region IDecorable Members

        public object GetDecorator()
        {
            return new EmployeeStandingDecorator(this);
        }


        #endregion


        #region partial Methods


        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
                if (DateBegin == null) throw new ArgumentNullException("Дата приема на работу.");
                if (DateEnd == null) throw new ArgumentNullException("Дата увольнения.");
                if (RegionType.IsNull() || RegionType == null) throw new ArgumentNullException("Тип региона.");
                if ((StandingType == null) || (StandingType.IsNull())) throw new ArgumentNullException("Тип стажа.");
                if ((Employee == null) || (Employee.IsNull())) throw new ArgumentNullException("Сотрудник.");
                if (DateEnd != null)
                    if (DateEnd <= DateBegin)
                        throw new ArgumentOutOfRangeException("Дата увольнения должна быть позже даты приема на работу.");
            }
        }


        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion

        public DateTime StartOfWork
        {
            get { return DateBegin; }
        }
        public DateTime? EndOfWork
        {
            get { return DateEnd; }
        }
        public TerritoryConditions Territory { get { return RegionType.GetTerritoryCondition(); } }
        public KindOfExperience Experience
        {
            get { return StandingType.GetKindOfExperience(); }
        }
        /// <summary>
        /// Получает место работы по записи в трудовой книжке. Книжка содержит данные 
        /// по работе в других организациях, работа в этой организации содержится в записях 
        /// штатного расписания
        /// </summary>
        public Affilations Affilation
        {
            get { return Affilations.External; }
        }

        public WorkOrganizationWorkType WorkWorkType
        {
            get
            {
                return WorkOrganizationWorkType.Other;
            }
        }

        public DateTime Start
        {
            get { return DateBegin; }
            set { }
        }
        public DateTime Stop
        {
            get { return DateEnd; }
            set { }
        }
    }
}
