using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
        /// Возвращает записи стажа, соответствующие непрерывному стажу
        /// </summary>
        /// <param name="experienceSet"></param>
        /// <returns>Записи, соответствующие непрерывному стажу</returns>
        public static IEnumerable<IEmployeeExperienceRecord> Continious(
            this IEnumerable<IEmployeeExperienceRecord> experienceSet)
        {
            var ordered = experienceSet.OrderByDescending(e => e.EndOfWork, 
                new APG.Relays.ComparerRelay<DateTime?>(
                (x, y) =>
                {
                    if (x.HasValue && y.HasValue) return x.Value.CompareTo(y.Value);
                    if (!x.HasValue && !y.HasValue) return 0;
                    return x.HasValue ? 1 : 0;
                }));
            //IEmployeeExperienceRecord prevRecord = null;
            //foreach (var record in ordered)
            //{
            //    if (prevRecord == null)
            //        yield return record;
            //    if (prevRecord.StartOfWork - record.EndOfWork.Get)
            //    prevRecord = record;
            //}
            return ordered;
        }
    }
}
