using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace APG.Relays
{
    public class EqualityComparerRelay<T> : IEqualityComparer<T>
    {
        private readonly Func<T, T, bool> _compare;

        public EqualityComparerRelay(Func<T, T, bool> compare)
        {
            if (compare == null)
                throw new ArgumentNullException("compare");
            _compare = compare;
        }
        
        /// <summary>
        /// Determines whether the specified objects are equal.
        /// </summary>
        /// <returns>
        /// true if the specified objects are equal; otherwise, false.
        /// </returns>
        /// <param name="x">The first object of type <paramref name="T"/> to compare.</param><param name="y">The second object of type <paramref name="T"/> to compare.</param>
        public bool Equals(T x, T y)
        {
            return _compare(x, y);
        }

        /// <summary>
        /// Returns a hash code for the specified object.
        /// </summary>
        /// <returns>
        /// A hash code for the specified object.
        /// </returns>
        /// <param name="obj">The <see cref="T:System.Object"/> for which a hash code is to be returned.</param><exception cref="T:System.ArgumentNullException">The type of <paramref name="obj"/> is a reference type and <paramref name="obj"/> is null.</exception>
        public int GetHashCode(T obj)
        {
            throw new NotImplementedException();
        }
    }
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
