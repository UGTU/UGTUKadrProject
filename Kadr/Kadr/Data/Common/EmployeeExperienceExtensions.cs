using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using APG.Base;

namespace Kadr.Data.Common
{
    public static class EmployeeExperienceExtensions
    {
        private const int Month = 30;
        const int YearMonthes = 12;
        private const int YearDays = Month * YearMonthes;

        /// <summary>
        /// Возвращает число лет трудового стажа
        /// </summary>
        /// <param name="timeSpan">Трудовой стаж</param>
        /// <returns>Число лет трудового стажа</returns>
        public static int GetExperienceYears(this TimeSpan timeSpan)
        {
            return timeSpan.Days / YearDays;
        }
        /// <summary>
        /// Вычисляет число месяцев трудового стажа
        /// </summary>
        /// <param name="timeSpan">Стаж</param>
        /// <returns>Число месяцев трудового стажа</returns>
        public static int GetExperienceMonthes(this TimeSpan timeSpan)
        {
            return (timeSpan.Days % YearDays) / Month;
        }
        /// <summary>
        /// Возвращает число дней трудового стажа
        /// </summary>
        /// <param name="timeSpan">Стаж</param>
        /// <returns>Число дней трудового стажа</returns>
        public static int GetExperienceDays(this TimeSpan timeSpan)
        {
            return (timeSpan.Days % YearDays % Month);
        }

        /// <summary>
        /// Возвращает строку с данными по стажу
        /// </summary>
        /// <param name="tsExperience">Стаж в объекте TimeSpan</param>
        /// <returns>Строка данных стажа</returns>
        public static string FormatAsExperience(this TimeSpan tsExperience)
        {
            var years = tsExperience.GetExperienceYears();
            var monthes = tsExperience.GetExperienceMonthes();
            var days = tsExperience.GetExperienceDays();
            return NumericExtensions.FormatDate(years, monthes, days);
        }

        /// <summary>
        /// Возвращает строку с данными по стажу
        /// </summary>
        /// <param name="dateSpanExperience"></param>
        /// <returns></returns>
        public static string FormatAsExperience(this DateSpan dateSpanExperience)
        {
            if (dateSpanExperience == null) throw new ArgumentNullException(nameof(dateSpanExperience));
            var years = dateSpanExperience.Years;
            var monthes = dateSpanExperience.Months;
            var days = dateSpanExperience.Days;
            return NumericExtensions.FormatDate(years, monthes, days);
        }
        /// <summary>
        /// Получает из заданной коллекции элементы северного стажа.
        /// </summary>
        /// <param name="source">Коллекция элементов стажа</param>
        /// <returns>Коллекция элементов северного стажа</returns>
        public static IEnumerable<IEmployeeExperienceRecord> FilterNorthExperience
            (this IEnumerable<IEmployeeExperienceRecord> source)
        {
            return source.Where(x => (x.Territory == TerritoryConditions.North
                                     || x.Territory == TerritoryConditions.StrictNorth)
                                     && (x.Affilation == Affilations.External
                                         || x.WorkWorkType == WorkOrganizationWorkType.Internal));
        }
        /// <summary>
        /// Получает коллекцию не пересекающихся интервалов ExperienceInterval по заданной коллекции IEmployeeExperienceRecord 
        /// </summary>
        /// <param name="source">Коллекция IEmployeeExperienceRecord</param>
        /// <returns></returns>
        public static IEnumerable<IEmployeeExperienceRecord> SequenceInterval(
            this IEnumerable<IEmployeeExperienceRecord> source)
        {
            if (source == null) throw new ArgumentNullException("source");
            return source.Sequence<IEmployeeExperienceRecord, DateTime>
                ((x, s, e) => new ExperienceInterval(x, s, e));
        }

        /// <summary>
        /// Расчитывает и возвращает стаж сотрудника
        /// </summary>
        /// <param name="experienceSet">Записи стажа</param>        
        /// <returns>Стаж сотрудника</returns>
        public static TimeSpan GetExperience(this IEnumerable<IEmployeeExperienceRecord> experienceSet)
        {
            // Стаж расчитывается с учётом того, что день увольнения считается рабочим днём
            // Если сотрудник продолжает работать в день расчёта стажа, то считается, что 
            // текущий день вошёл в стаж.
            var nextDay = DateTime.Today.AddDays(1);
            var enumerable = experienceSet as IList<IEmployeeExperienceRecord> ?? experienceSet.ToList();
            var extraDays = CalculateExtraDays(enumerable);
            return TimeSpan.FromDays(enumerable.Sum(x=> ((x.IsEnded ? x.Stop.AddDays(1) : nextDay) - x.Start).Days) - extraDays);
        }
        /// <summary>
        /// Расчитывает и возвращает стаж сотрудника
        /// </summary>
        /// <param name="experienceSet">Записи стажа</param>        
        /// <returns>Стаж сотрудника</returns>
        public static DateSpan GetExperienceDates(this IEnumerable<IEmployeeExperienceRecord> experienceSet)
        {
            // Стаж расчитывается с учётом того, что день увольнения считается рабочим днём
            // Если сотрудник продолжает работать в день расчёта стажа, то считается, что 
            // текущий день вошёл в стаж.
            var nextDay = DateTime.Today.AddDays(1);
            var enumerable = experienceSet as IList<IEmployeeExperienceRecord> ?? experienceSet.ToList();
            var extraDays = CalculateExtraDays(enumerable);
            //return TimeSpan.FromDays(enumerable.Sum(x => ((x.IsEnded ? x.Stop.AddDays(1) : nextDay) - x.Start).Days) - extraDays);
            var result = 
                enumerable.Select(
                    x => new DateSpanDifference((x.IsEnded ? x.Stop.AddDays(1) : nextDay), x.Start.AddDays(extraDays)))
                    .Aggregate(new DateSpan(0, 0, 0), (a, b) => a+b, r=>r);
            return result;

        }
        /// <summary>
        /// Есди даты окончания и начала следующей записи стажа совпадают, то следует учитывать, что 
        /// стаж непрерывен и не требуется учитывать день увольнения
        /// </summary>
        /// <param name="enumerable"></param>
        /// <returns></returns>
        private static int CalculateExtraDays(IEnumerable<IEmployeeExperienceRecord> enumerable)
        {
            IEmployeeExperienceRecord prevItem = null;
            var extraDays = 0;
            foreach (var item in enumerable)
            {
                if (prevItem != null && prevItem.Stop == item.Start) ++extraDays;
                prevItem = item;
            }
            return extraDays;
        }

        /// <summary>
        /// Возвращает записи стажа, соответствующие непрерывному стажу. 
        /// Непрерывный стаж считается, если время между событиями увольнения 
        /// с должности и приёма на работу составляют не более одного дня.
        /// </summary>
        /// <param name="experienceSet"></param>
        /// <returns>Записи, соответствующие непрерывному стажу.</returns>
        public static IEnumerable<IEmployeeExperienceRecord> Continious(
            this IEnumerable<IEmployeeExperienceRecord> experienceSet)
        {
            if (experienceSet == null) throw new ArgumentNullException("experienceSet");
            
            // Сортировка по убыванию даты окончания. Записи стажа не имеющие даты окончания,
            // имеют приоритет и будут в начале выходной коллекции
            var comparer = new APG.Relays.ComparerRelay<IEmployeeExperienceRecord>(
                (x, y) =>
                {
                    var today = DateTime.Today;
                    var dx = x.IsEnded ? x.Stop : today;
                    var dy = y.IsEnded ? y.Stop : today;
                    return dx.CompareTo(dy);
                });
            
            var ordered = experienceSet.OrderByDescending(e => e, comparer).ToList();
            IEmployeeExperienceRecord prevItem = null;
            // Для того, что бы считать стаж непрерывным требуется, что бы между записями даты окончания предыдущего стажа и датой начала следующего
            // было не более одного дня
            var acceptableHole = TimeSpan.FromDays(1);

            foreach (var item in ordered)
            {
                // Если это первая запись в списке или запись стажа не имеет даты окончания, то
                // она включается в непрерывный стаж
                if (prevItem == null || (!item.IsEnded)) yield return item;
                // Если даты окончания и начала имеют не более одного дня перерыва, то они также включаются в непрерывный стаж
                else if (prevItem.Start - item.Stop <= acceptableHole)
                    yield return item;
                else
                    yield break;
                prevItem = item;
            }
        }
    }
}
