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
            return string.Format("{0} {1}, {2} {3}, {4} {5}", years, years.GetYearStr(), monthes, monthes.GetMonthStr(), days, days.GetDayStr());
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
            return TimeSpan.FromDays(
                experienceSet.Sum(
                    x => ((x.EndOfWork.HasValue
                        ? x.EndOfWork.Value.AddDays(1)
                        : DateTime.Today.AddDays(1)) - x.StartOfWork).Days));
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
            var ordered = experienceSet.OrderByDescending(e => e.EndOfWork,
                new APG.Relays.ComparerRelay<DateTime?>(
                (x, y) =>
                {
                    if (x.HasValue && y.HasValue) return x.Value.CompareTo(y.Value);
                    if (!x.HasValue && !y.HasValue) return 0;
                    return x.HasValue ? -1 : 1;
                }));
            IEmployeeExperienceRecord prevItem = null;
            var acceptableHole = TimeSpan.FromDays(1);

            foreach (var item in ordered)
            {
                if (prevItem == null || !(item.EndOfWork.HasValue)) yield return item;
                else if (prevItem.StartOfWork - item.EndOfWork.Value <= acceptableHole)
                    yield return item;
                else
                    yield break;
                prevItem = item;
            }
        }
    }
}
