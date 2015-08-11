using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class EducationType : INull, IComparable
    {
        public override string ToString()
        {
            return EduTypeName;
        }

        public bool IsNull()
        {
            return false;
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
