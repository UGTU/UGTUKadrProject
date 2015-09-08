using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace APG.Base
{
    public static class ComparableExtensions
    {
        /// <summary>
        /// Возвращает истину, если значение объекта меньше значения параметра
        /// </summary>
        /// <param name="source">Сравниваемый объект</param>
        /// <param name="other">Объект с которым производится сравнение</param>
        /// <returns>Истина, если условие удовлетворено</returns>
        public static bool Less(this IComparable source, IComparable other)
        {
            return source.CompareTo(other) < 0;
        }
        /// <summary>
        /// Возвращает истину, если значение объекта меньше или равно значению параметра
        /// </summary>
        /// <param name="source">Сравниваемый объект</param>
        /// <param name="other">Объект с которым производится сравнение</param>
        /// <returns>Истина, если условие удовлетворено</returns>
        public static bool LessOrEq(this IComparable source, IComparable other)
        {
            return source.CompareTo(other) <= 0;
        }
        /// <summary>
        /// Возвращает истину, если значение объекта равно значению параметра
        /// </summary>
        /// <param name="source">Сравниваемый объект</param>
        /// <param name="other">Объект с которым производится сравнение</param>
        /// <returns>Истина, если условие удовлетворено</returns>
        public static bool Eq(this IComparable source, IComparable other)
        {
            return source.CompareTo(other) == 0;
        }

        /// <summary>
        /// Возвращает истину, если значение объекта больше или равно значению параметра
        /// </summary>
        /// <param name="source">Сравниваемый объект</param>
        /// <param name="other">Объект с которым производится сравнение</param>
        /// <returns>Истина, если условие удовлетворено</returns>
        public static bool GreaterOrEq(this IComparable source, IComparable other)
        {
            return source.CompareTo(other) >= 0;
        }
        /// <summary>
        /// Возвращает истину, если значение объекта больше значения параметра
        /// </summary>
        /// <param name="source">Сравниваемый объект</param>
        /// <param name="other">Объект с которым производится сравнение</param>
        /// <returns>Истина, если условие удовлетворено</returns>
        public static bool Greater(this IComparable source, IComparable other)
        {
            return source.CompareTo(other) > 0;
        }
        /// <summary>
        /// Возвращает истину, если значение не равно значению параметра
        /// </summary>
        /// <param name="source">Сравниваемый объект</param>
        /// <param name="other">Объект с которым производится сравнение</param>
        /// <returns>Истина, если условие удовлетворено</returns>
        public static bool NotEq(this IComparable source, IComparable other)
        {
            return source.CompareTo(other) != 0;
        }
    }
}
