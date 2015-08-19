using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    /// <summary>
    /// Реализация интерфейса IComparable
    /// </summary>
    public class CompareObject : IComparable
    {
        public int CompareTo(object obj)
        {
            return ToString().CompareTo(obj.ToString());
        }
    }
}
