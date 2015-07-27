using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class BusinessTripRegionType : UIX.Views.IValidatable, INull, IComparable
    {
        #region Properties

        #endregion

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
            return null;
            //return new BusinessTripDecorator(this);
        }

        #endregion


        public int CompareTo(object obj)
        {
            return ToString().CompareTo(obj.ToString());
        }

    }
}
