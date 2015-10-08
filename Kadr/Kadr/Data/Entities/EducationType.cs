using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class EducationType : INullable, IComparable
    {
        public override string ToString()
        {
            return EduTypeName;
        }

        public int CompareTo(object obj)
        {
            return EduTypeName.CompareTo(obj.ToString());
        }
    }

    public class NullEducationType : EducationType, INull
    {

        private NullEducationType()
        {
            this.id = 0;
        }

        public static readonly NullEducationType Instance = new NullEducationType();


        public override string ToString()
        {
            return "(Не заданo)";
        }

    }
}
