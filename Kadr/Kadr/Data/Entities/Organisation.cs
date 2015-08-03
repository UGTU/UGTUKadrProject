using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class Organisation : INull, IComparable
    {
        public override string ToString()
        {
            return Name;
        }

        #region INull Members
        public bool IsNull()
        {
            return false;
        }
        #endregion

        public int CompareTo(object obj)
        {
            return Name.CompareTo(obj.ToString());
        }
    }
    public class NullOrganisation : Organisation, INull
    {

        private NullOrganisation()
        {
            this.id = 0;
        }

        public static readonly NullOrganisation Instance = new NullOrganisation();

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
