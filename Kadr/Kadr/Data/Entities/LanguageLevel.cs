using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data 
{
    public partial class LanguageLevel : INull, IComparable
    {
        public override string ToString()
        {
            return LevelName;
        }

        #region INull Members
        public bool IsNull()
        {
            return false;
        }
        #endregion

        public int CompareTo(object obj)
        {
            return LevelName.CompareTo(obj.ToString());
        }
    }

    public class NullLanguageLevel : LanguageLevel, INull
    {

        private NullLanguageLevel()
        {
            this.id = 0;
        }

        public static readonly NullLanguageLevel Instance = new NullLanguageLevel();

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
