using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;
using UIX.Views;

namespace Kadr.Data
{
    public partial class BusinessTripRegionType : INull, IComparable, IDecorable, IValidatable
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

        public override string ToString()
        {
            if (DateBegin != null)
                return string.Format("С {0} по {1} в {2}", DateBegin.ToShortDateString(), DateEnd.ToShortDateString(), RegionType.RegionTypeName);
            else return "Не задано";
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
                if ((idBusinessTrip == 0)&&(BusinessTrip == null)) throw new ArgumentNullException("Командировка");
                if ((idRegionType == 0)&&(RegionType == null)) throw new ArgumentNullException("Регион пребывания");

                if (DateBegin > DateEnd) throw new ArgumentOutOfRangeException("Дата начала пребывания в регионе не может быть позже даты окончания!");
                if ((BusinessTrip.FactStaffPrikaz.DateBegin > DateBegin) || (BusinessTrip.FactStaffPrikaz.DateEnd < DateBegin)) throw new ArgumentOutOfRangeException("Дата начала пребывания выходит за рамки командировки!");
                if ((BusinessTrip.FactStaffPrikaz.DateBegin > DateEnd) || (BusinessTrip.FactStaffPrikaz.DateEnd < DateEnd)) throw new ArgumentOutOfRangeException("Дата начала пребывания выходит за рамки командировки!");
            }
        }

        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion


        #region INull Members

        bool INull.IsNull()
        {
            return false;
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

    }
}
