using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class SemPol : INull, IComparable
    {
        public override string ToString()
        {
            return this.sempolName;
        }



        #region INull Members

        bool INull.IsNull()
        {
            return false;

        }

        #endregion

        public int CompareTo(object obj)
        {
            return sempolName.CompareTo(obj.ToString());
        }
    }

    public class NullSemPol : SemPol, INull
    {

        private NullSemPol()
        {
            this.id = 0;
        }

        public static readonly NullSemPol Instance = new NullSemPol();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }
        public override string ToString()
        {
            return "(Не заданo)";
        }

        #endregion
    }
}

