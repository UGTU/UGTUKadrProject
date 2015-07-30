﻿using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class BusinessTrip : UIX.Views.IDecorable, UIX.Views.IValidatable, INull, IObjectState, IComparable
    {
        #region Properties

        #endregion

        public override string ToString()
        {
            if (FactStaffPrikaz.FactStaff!=null)
            if (FactStaffPrikaz.FactStaff.Employee!=null)
            return string.Format("Командировка в {0} — сотрудник: {1}", TripTargetPlace, FactStaffPrikaz.FactStaff.Employee.ToString()); 
            return string.Format("Командировка в {0}", TripTargetPlace);

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
                if (FactStaffPrikaz == null) throw new ArgumentNullException("Приказ");

                if (FactStaffPrikaz.Prikaz == null) throw new ArgumentNullException("Приказ");

                if (BusinessTripRegionTypes.Count()==0) throw new ArgumentNullException("Регион пребывания");

                if (FinancingSource==null) throw new ArgumentNullException("Источник финансирования");

                if (TripTargetPlace == null) throw new ArgumentNullException("Место назначения");
                if (TripTargetPlace == "") throw new ArgumentNullException("Место назначения");

                if (FactStaffPrikaz.DateBegin == null) throw new ArgumentNullException("Срок начала командировки");
                if (FactStaffPrikaz.DateEnd == null) throw new ArgumentNullException("Срок окончания командировки");

                if (BusinessTripRegionTypes.First().DateBegin == null) throw new ArgumentNullException("Срок начала командировки");
                if (BusinessTripRegionTypes.First().DateEnd == null) throw new ArgumentNullException("Срок окончания командировки");

                if (FactStaffPrikaz.DateEnd < FactStaffPrikaz.DateBegin)
                        throw new ArgumentOutOfRangeException("Дата окончания командировки должна быть не раньше даты начала командировки");

                if (BusinessTripRegionTypes.First().DateBegin > BusinessTripRegionTypes.First().DateEnd)
                        throw new ArgumentOutOfRangeException("Дата начала пребывания в регионе не может быть больше даты окончания пребывания в регионе");

                if (BusinessTripRegionTypes.First().DateBegin < FactStaffPrikaz.DateBegin)
                        throw new ArgumentOutOfRangeException("Дата начала пребывания в регионе не может быть раньше даты начала командировки");

                if (BusinessTripRegionTypes.First().DateEnd > FactStaffPrikaz.DateEnd)
                        throw new ArgumentOutOfRangeException("Дата окончания пребывания в регионе не может быть позже даты окончания командировки");


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
            //return null;
            return new BusinessTripDecorator(this);
        }

        #endregion

        #region IObjectState Members

        ObjectState IObjectState.State()
        {
            //TODO: статус приказа по персоналу должен определяться тем, есть ли отменяющий его приказ
            return ObjectState.Current;

        }

        #endregion

        public int CompareTo(object obj)
        {
            return this.ToString().CompareTo(obj.ToString());
        }



    }
}
