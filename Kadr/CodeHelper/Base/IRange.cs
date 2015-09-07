using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using APG.Relays;

namespace APG.Base
{
    public interface IRange<TU> where TU : IComparable
    {
        TU Start { get; set; }
        TU Stop { get; set; }
    }

    public enum PointRangeRelation
    {
        In,
        Before,
        After
    }

    public enum RangeRelation
    {
        /// <summary>
        /// Интервалы равны
        /// </summary>
        Equals,
        /// <summary>
        /// Интервал находится внутри другого интервала
        /// </summary>
        Within,
        /// <summary>
        /// Интервал не пересекается с другим интервалом
        /// </summary>
        NotIn,
        /// <summary>
        /// Конец интервала находится внутри другого интервала
        /// </summary>
        EndsIn,
        /// <summary>
        /// Начало интервала находится внутри другого интервала
        /// </summary>
        StartsIn,
        /// <summary>
        /// Интервал полностью включает в себя интервал
        /// </summary>
        Includes
    }

    public static class RangeExtensions
    {
        public static RangeRelation GetRelationTo<TU>(this IRange<TU> sourceRange, TU start, TU stop) where TU :
            IComparable
        {
            var startStartResult = sourceRange.Start.CompareTo(start);
            var stopStopResult = sourceRange.Stop.CompareTo(stop);
            //var startStopResult = sourceRange.Start.CompareTo(stop);
            //var stopStartResult = sourceRange.Stop.CompareTo(start);

            if (stopStopResult == 0 && startStartResult == 0)
                return RangeRelation.Equals;
            if ((startStartResult <= 0) && (stopStopResult >= 0))
                return RangeRelation.Includes;
            if ((startStartResult > 0) &&
                (stopStopResult < 0))
                return RangeRelation.Within;
            if (sourceRange.GetRelationTo(start) == PointRangeRelation.In)
                return RangeRelation.StartsIn;
            if (sourceRange.GetRelationTo(stop) == PointRangeRelation.In)
                return RangeRelation.EndsIn;
            return RangeRelation.NotIn;
        }

        /// <summary>
        /// Получает результат отношения отрезка к заданному
        /// </summary>
        /// <typeparam name="TU"></typeparam>
        /// <param name="sourceRange"></param>
        /// <param name="point"></param>
        /// <returns></returns>
        public static PointRangeRelation GetRelationTo<TU>(this IRange<TU> sourceRange, TU point) where TU :
            IComparable
        {
            if ((sourceRange.Start.CompareTo(point) > 0)) return PointRangeRelation.Before;
            return
                (sourceRange.Stop.CompareTo(point) < 0) ? PointRangeRelation.After : PointRangeRelation.In;
        }
        /// <summary>
        /// Вычисляет отношение интервала к другому интервалу
        /// </summary>
        /// <typeparam name="TU">Тип значений начала и конца интервала</typeparam>
        /// <param name="sourceRange">Исходный интервал</param>
        /// <param name="otherRange">Другой интервал</param>
        /// <returns>Отношение интервалов</returns>
        public static RangeRelation GetRelationTo<TU>(this IRange<TU> sourceRange, IRange<TU> otherRange)
            where TU : IComparable
        {
            if (sourceRange == null) throw new ArgumentNullException("sourceRange");
            if (otherRange == null) throw new ArgumentNullException("otherRange");

            return sourceRange.GetRelationTo(otherRange.Start, otherRange.Stop);
        }


        public static bool IsIntersected<T, TU>(this IEnumerable<T> sourceRange) where T : IRange<TU> where TU : IComparable
        {
            if (sourceRange == null) throw new ArgumentNullException("sourceRange");
            var range = sourceRange.ToList();
            return
                (from itemI in range
                 from itemJ in range.Where(itemJ => !itemJ.Equals(itemI))
                 where itemI.GetRelationTo(itemJ) != RangeRelation.NotIn
                 select itemI).Any();
        }

        public static bool IsIntersected<TU>(this IEnumerable<IRange<TU>> sourceRange, IEnumerable<IRange<TU>> otherRange) where TU : IComparable
        {
            var intersection = sourceRange.Intersect(otherRange,
                new EqualityComparerRelay<IRange<TU>>((x, y) => x.GetRelationTo(y) != RangeRelation.NotIn));
            return !intersection.Any();
        }
        public static bool IsIntersected<TU>(this IEnumerable<IRange<TU>> sourceRange, IRange<TU> otherRange) where TU : IComparable
        {
            return sourceRange.All(x => x.GetRelationTo(otherRange) == RangeRelation.NotIn);
        }

    }

}