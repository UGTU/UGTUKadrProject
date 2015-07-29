using System.Data.Linq;
using System;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class EmployeeStanding : UIX.Views.IDecorable, UIX.Views.IValidatable
    {
        public override string ToString()
        {
            return "Запись трудовой книжки сотрудника " +Employee.EmployeeSmallName;
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

    }
}
