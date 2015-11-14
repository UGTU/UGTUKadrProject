using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data 
{
    public partial class LanguageLevel : INullable, IComparable
    {
        public override string ToString()
        {
            return LevelName;
        }


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

        public override string ToString()
        {
            return "(Не заданo)";
        }

    }
}
