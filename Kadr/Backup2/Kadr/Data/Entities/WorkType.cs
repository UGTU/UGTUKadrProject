using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class WorkType : INull, IComparable
    {
        public override string ToString()
        {
            return this.TypeWorkName;
        }


        #region INull Members

        bool INull.IsNull()
        {
            return false;
        }

        #endregion

        #region Члены IComparable

        public int CompareTo(object obj)
        {
            return TypeWorkName.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullWorkType : WorkType, INull
    {

        private NullWorkType()
        {
            this.id = 0;
        }

        public static readonly NullWorkType Instance = new NullWorkType();

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
