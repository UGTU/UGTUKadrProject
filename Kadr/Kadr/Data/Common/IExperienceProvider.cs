using System.Collections.Generic;

namespace Kadr.Data.Common
{
    /// <summary>
    /// Определяет типы, возвращающие коллекцию записей по стажу
    /// </summary>
    public interface IExperienceProvider
    {
        /// <summary>
        /// Получает коллекцию записей стажа
        /// </summary>
        IEnumerable<IEmployeeExperienceRecord> EmployeeExperiences { get; }
    }
}
