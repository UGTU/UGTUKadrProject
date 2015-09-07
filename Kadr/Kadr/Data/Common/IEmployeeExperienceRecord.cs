using System;
using APG.Base;

namespace Kadr.Data.Common
{
    /// <summary>
    /// Территориальные условия
    /// </summary>
    public enum TerritoryConditions
    {
        /// <summary>
        /// Район не приравненный к МКС или РКС
        /// </summary>
        Default = 1,
        /// <summary>
        /// РКС
        /// </summary>
        StrictNorth = 3,
        /// <summary>
        /// МКС
        /// </summary>
        North =2
    }
    /// <summary>
    /// Принадлежность стажа организации
    /// </summary>
    public enum Affilations
    {
        /// <summary>
        /// Стаж в организации
        /// </summary>
        Organization,
        /// <summary>
        /// Стаж не в организации
        /// </summary>
        External
    }
    /// <summary>
    /// Виды стажа
    /// </summary>
    public enum KindOfExperience
    {
        /// <summary>
        /// Педогогический
        /// </summary>
        Pedagogical = 2,
        /// <summary>
        /// Стаж на других должностях
        /// </summary>
        Other = 1       
    }
    /// <summary>
    /// Определяет типы записи стажа работника
    /// </summary>
    public interface IEmployeeExperienceRecord : IRange<DateTime>
    {
        /// <summary>
        /// Получает дату начала работы
        /// </summary>
        DateTime StartOfWork { get; }
        /// <summary>
        /// Получает дату окончания работы. Если дата не задана, то стаж является текущим
        /// </summary>
        DateTime? EndOfWork { get; }
        /// <summary>
        /// Получает территориальные условия работы
        /// </summary>
        TerritoryConditions Territory { get; }
        /// <summary>
        /// Получает вид стажа
        /// </summary>
        KindOfExperience Experience { get; }
        
        /// <summary>
        /// Получает принадлежность стажа организации
        /// </summary>
        Affilations Affilation { get; }
        
        /// <summary>
        /// Получает тип стажа в организации
        /// </summary>
        WorkOrganizationWorkType WorkWorkType { get; }


    }
}
