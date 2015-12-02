using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.AccessControl;
using System.Text;

namespace APG.Base
{

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
                if (orderSelector(prevItem).Greater(orderSelector(item)))
                    return false;
                prevItem = item;
            }
            return true;
        }

        /// <summary>
        /// Возвращает коллекцию не пересекающихся отрезков (IRange)
        /// </summary>
        /// <typeparam name="T">Тип элемента коллекцуии</typeparam>
        /// <typeparam name="TU">Тип задающий начало и коней отрезка </typeparam>
        /// <param name="source">Коллекция отрезков</param>
        /// <param name="producerFunc">Функция для продуцирования нового отрезка, который не пересекается с другими в коллекции</param>
        /// <returns>Коллекция не пересекающихся отрезков</returns>
        public static IEnumerable<T> Sequence<T, TU>
            (this IEnumerable<T> source, Func<T, TU, TU, T> producerFunc)
            where T : IRange<TU>
            where TU : IComparable
        {
            if (source == null) throw new ArgumentNullException("source");
            if (producerFunc == null) throw new ArgumentNullException("producerFunc");

            var collection = source.ToList();

            if (!collection.Any())
                yield break;

            var startOrdered = collection.OrderBy(x => x.Start).ToList();
            var stopOrdered = collection.OrderBy(x => x.Stop).ToList();
            var ctxItem = startOrdered.First();
            var startPoint = ctxItem.Start;
            while (true)
            {
                var nextStart = startOrdered.FirstOrDefault(x => x.Start.Greater(startPoint));
                var nextStop = stopOrdered.FirstOrDefault(x => x.Stop.Greater(startPoint));
                
                // Проверка корректности параметров интервала
                nextStop?.CheckRange();
                nextStart?.CheckRange();

                if (nextStop == null && nextStart == null)
                    yield break;

                var item = ctxItem;
                TU stopPoint;

                if ((nextStop != null) && (nextStart != null))
                {

                    if (nextStop.Stop.Less(nextStart.Start))
                    {
                        stopPoint = nextStop.Stop;
                        if (ctxItem.Stop.Less(nextStop.Start)) item = nextStop;
                        if (nextStop.Stop.Greater(ctxItem.Stop)) ctxItem = nextStop;
                    }
                    else
                    {
                        stopPoint = nextStart.Start;
                        item = nextStart;
                    }

                }
                else
                {
                    if (nextStart == null)
                    {
                        stopPoint = nextStop.Stop;
                        if (stopPoint.Greater(ctxItem.Stop))
                            ctxItem = nextStop;
                    }
                    else
                    {
                        stopPoint = nextStart.Stop;
                        ctxItem = nextStart;
                    }
                }
                if (startOrdered.Any(x => x.GetRelationTo(startPoint, stopPoint) == RangeRelation.Includes 
                || x.GetRelationTo(startPoint, stopPoint) == RangeRelation.Equals))
                    yield return producerFunc(ctxItem, startPoint, stopPoint);
                ctxItem = item;
                startPoint = stopPoint;
            }

            #region OLD

            //var ctxCollection = new List<T>() {startOrdered.First()};
            //var restCollection = startOrdered.Skip(1).ToList();
            //while (ctxCollection.Any())
            //{
            //    var contextItem = ctxCollection.Last();
            //    var currrentItem = restCollection.FirstOrDefault();            

            //    if (currrentItem != null && 
            //        contextItem.GetRelationTo(currrentItem) != RangeRelation.NotIn)
            //    {
            //        yield return producerFunc(contextItem, contextItem.Start,
            //            currrentItem.Start);
            //        ctxCollection.Add(currrentItem);
            //    }
            //    else
            //    {
            //        var ctxIntersects = ctxCollection.Where(x => !x.Equals(contextItem) && x.GetRelationTo(contextItem)!=RangeRelation.NotIn).ToList();
            //        if (ctxIntersects.Any())
            //        {
            //            foreach (var ctxItem in ctxIntersects)
            //            {
            //                var tstResult = ctxItem.GetRelationTo(contextItem);
            //                if (tstResult == RangeRelation.EndsIn) //|| tstResult == RangeRelation.Includes
            //                {
            //                    yield return producerFunc(contextItem, contextItem.Start, ctxItem.Stop);
            //                    ctxCollection.Remove(ctxItem);
            //                }
            //            }
            //        }
            //        else { yield return contextItem;}
            //        ctxCollection.Remove(contextItem);
            //    }
            //    restCollection = restCollection.Skip(1).ToList();

            #endregion

        }
    }
}
