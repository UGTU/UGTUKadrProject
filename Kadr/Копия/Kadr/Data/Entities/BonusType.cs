using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class BonusType : INull, IComparable
    {
        public override string ToString()
        {
            return this.BonusTypeName+" ("+BonusMeasure.Sign+")";
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
                if (BonusSuperType.IsNull()) throw new ArgumentNullException("Тип надбавки.");
                if ((BonusTypeName == null))
                    throw new ArgumentNullException("Название вида надбавки.");
            }
        }

        #endregion



        #region IValidatable Members


        #endregion

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return BonusTypeName.CompareTo(obj.ToString());
        }

        #endregion

        #region Члены INull

        bool INull.IsNull()
        {
            return false;

        }

        #endregion
    }

    public class NullBonusType : BonusType, INull
    {

        private NullBonusType()
        {
            this.id = 0;
        }

        public static readonly NullBonusType Instance = new NullBonusType();

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
