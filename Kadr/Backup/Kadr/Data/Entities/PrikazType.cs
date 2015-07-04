using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;


namespace Kadr.Data
{
    public partial class PrikazType :  INull, IComparable
    {
        public override string ToString()
        {
            return this.PrikazTypeName;
        }


        #region Члены INull

        bool INull.IsNull()
        {
            return false;
        }

        #endregion

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return PrikazTypeName.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullPrikazType : PrikazType, INull
    {

        private NullPrikazType()
        {
            this.id = 0;
            //this.PrikazLongName = "(Не задан)";
        }

        public static readonly NullPrikazType Instance = new NullPrikazType();

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
