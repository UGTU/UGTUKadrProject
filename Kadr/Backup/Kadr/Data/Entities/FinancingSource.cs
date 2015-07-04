using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class FinancingSource : INull, IComparable
    {
        public override string ToString()
        {
            return this.FinancingSourceName;
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
            return FinancingSourceName.CompareTo(obj.ToString());
        }

        #endregion
    }

    public class NullFinancingSource : FinancingSource, INull
    {

        private NullFinancingSource()
        {
            this.id = 0;
        }

        public static readonly NullFinancingSource Instance = new NullFinancingSource();

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

