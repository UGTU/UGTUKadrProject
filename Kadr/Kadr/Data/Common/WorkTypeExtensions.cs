using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    /// <summary>
    /// Вид работы в организации
    /// </summary>
    public enum WorkOrganizationWorkType
    {
        /// <summary>
        /// Основная ставка
        /// </summary>
        Internal = 1,
        /// <summary>
        /// Совместительство
        /// </summary>
        Combined = 2,
        /// <summary>
        /// Внешний
        /// </summary>
        External = 6,
        /// <summary>
        /// Другие виды
        /// </summary>
        Other = 0
    }
    public static class WorkTypeExtensions
    {
        /// <summary>
        /// Получает вид работы в организации 
        /// </summary>
        /// <param name="workType">Виды работ</param>
        /// <returns>Вид работы в организации</returns>
        public static WorkOrganizationWorkType GetOrganizationWorkType(this WorkType workType)
        {
            var values = Enum.GetValues(typeof(WorkOrganizationWorkType)).Cast<int>();
            if (values.Contains(workType.id))
                return (WorkOrganizationWorkType)workType.id;
            return WorkOrganizationWorkType.Other;

        }
    }
}
