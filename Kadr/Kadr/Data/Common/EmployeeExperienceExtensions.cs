using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    public class Experience
    {
        /// <summary>
        /// Получает трудовой стаж сотрудника
        /// </summary>
        public TimeSpan Total { get; set; }
    }
    public static class EmployeeExperienceExtensions
    {
        public static Experience GetExperience(this IExperienceProvider provider)
        {
            return new Experience()
            {
                Total =
                    TimeSpan.FromDays(
                        provider.EmployeeExperiences.Sum(
                            x => ((x.EndOfWork.HasValue ? x.EndOfWork.Value : DateTime.Today) - x.StartOfWork).Days))
            };
        }
    }
}
