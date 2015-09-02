using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class AwardLevel : IComparable
    {
        public override string ToString()
        {
            return this.Name;
        }

        public int CompareTo(object obj)
        {
            if (obj is AwardLevel) return ((int)(this.AwardLevel1 - (obj as AwardLevel).AwardLevel1));
            else 
            return this.ToString().CompareTo(obj.ToString());
        }
    }
}
