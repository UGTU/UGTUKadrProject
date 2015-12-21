using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APG.Base
{
    public static class CollectionExtensions
    {
        public static IEnumerable<T> AsSingle<T>(this T element)
        {
            yield return element;
        }
    }
}
