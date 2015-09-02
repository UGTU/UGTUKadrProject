using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace APG.Base
{
    public interface IRange<T> where T : IComparable
    {
        T Start { get; set; }
        T Stop { get; set; }        
    }

    public enum IntervalPoint
    {
        Begin,
        End
    };

    public static class IntervalExtensions
    {
        /// <summary>
        /// Получает признак того, что коллекция отсортирована по заданному полю
        /// </summary>
        /// <typeparam name="T">Тип элемента коллекции</typeparam>
        /// <typeparam name="TU">Тип атрибута для стравнения</typeparam>
        /// <param name="source">Коллекция</param>
        /// <param name="orderSelector">Лямбда-выражение для выбора свойства сортировки</param>
        /// <returns>Истина, если коллекция отсортирована</returns>
        public static bool IsOrdered<T, TU>(this IEnumerable<T> source, Func<T, TU> orderSelector)
            where TU : IComparable
        {
            var sourceList = source.ToList();
            var prevItem = sourceList.FirstOrDefault();
            if (prevItem == null)
                return true;
            foreach (var item in sourceList.Skip(1))
            {
                if (orderSelector(prevItem).CompareTo(orderSelector(item)) > 0)
                    return false;
                prevItem = item;
            }
            return true;
        }

        public static IEnumerable<T> Sequence<T, TU>
            (this IEnumerable<T> source) 
            where T : IRange<TU>
            where TU : IComparable            
        {
            var startOrdered = source.OrderBy(x => x.Start).ToList();

            return startOrdered;
        }
    }
}
