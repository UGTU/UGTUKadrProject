using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APG.Base
{
    public static class EnumExtensions
    {
        public static T ParseIntAsEnum<T>(this int val, T defaultValue)
        {
            var values = Enum.GetValues(typeof(T)).Cast<int>();
            if (values.Contains(val))
                return defaultValue;
            return defaultValue;
        }
    }
}
