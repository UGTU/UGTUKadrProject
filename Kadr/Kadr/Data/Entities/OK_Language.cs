using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Language : INullable, IComparable
    {
        public override string ToString()
        {
            return languagename;
        }

        public bool IsNull()
        {
            return false;
        }

        public int CompareTo(object obj)
        {
            return languagename.CompareTo(obj.ToString());
        }
    }

    public class NullOK_Language : OK_Language, INull
    {

        private NullOK_Language()
        {
            this.idlanguage = 0;
        }

        public static readonly NullOK_Language Instance = new NullOK_Language();

        public override string ToString()
        {
            return "(Не заданo)";
        }

    }
}
