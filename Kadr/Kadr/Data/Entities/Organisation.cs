using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class Organisation : INullable, IComparable
    {
        public override string ToString()
        {
            return Name;
        }

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


        public override string ToString()
        {
            return "(Не заданo)";
        }

    }
}
