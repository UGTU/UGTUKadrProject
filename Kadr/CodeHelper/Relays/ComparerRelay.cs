using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace APG.Relays
{
    public class ComparerRelay<T> : IComparer<T>
    {
        private readonly Func<T, T, int> _compare;

        public ComparerRelay(Func<T, T, int> compare)
        {
            if (compare == null)
                throw new ArgumentNullException("compare");
            _compare = compare;
        } 
        public int Compare(T x, T y)
        {
            return _compare(x, y);
        }
    }
}
