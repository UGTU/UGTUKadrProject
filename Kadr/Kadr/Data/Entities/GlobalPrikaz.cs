using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class GlobalPrikaz : UIX.Views.IValidatable,INull,IComparable
    {
        public override string ToString()
        {
            return Convert.ToString(this.PrikazNumber);
        }



        #region partial Methods

        partial void OnCreated()
        {
            //DateBegin = DateTime.Today;
            //this.
        }

        /// <summary>
        /// Проверка всех параметров перед сохранением
        /// </summary>
        /// <param name="action"></param>
        partial void OnValidate(System.Data.Linq.ChangeAction action)
        {
            if ((action == ChangeAction.Insert) || (action == ChangeAction.Update))
            {
            }
        }
        #endregion


        #region IValidatable Members

        void UIX.Views.IValidatable.Validate()
        {
            OnValidate(ChangeAction.Insert);
        }

        #endregion



        #region Члены INull

        bool INull.IsNull()
        {
            return false;
        }

        #endregion

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return PrikazNumber.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullGlobalPrikaz : GlobalPrikaz, INull
    {

        private NullGlobalPrikaz()
        {
            this.id = 0;
        }

        public static readonly NullGlobalPrikaz Instance = new NullGlobalPrikaz();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }
        public override string ToString()
        {
            return "(Не задан)";
        }

        #endregion
    }

}





