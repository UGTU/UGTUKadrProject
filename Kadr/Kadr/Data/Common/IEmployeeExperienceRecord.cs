using System;

namespace Kadr.Data.Common
{
    public enum TerritoryConditions
    {
        /// <summary>
        /// Район не приравненный к МКС или РКС
        /// </summary>
        Default,
        /// <summary>
        /// РКС
        /// </summary>
        StrictNorth,
        /// <summary>
        /// МКС
        /// </summary>
        North        
    }

    public enum Affilations
    {
        Organization,
        External
    }
    public enum KindOfExperience
    {
        /// <summary>
        /// Педогогический
        /// </summary>
        Pedagogical,
        /// <summary>
        /// Стаж на других должностях и (или) в других предприятиях
        /// </summary>
        Other            
    }

    public interface IEmployeeExperienceRecord
    {
        DateTime StartOfWork { get; }
        DateTime? EndOfWork { get; }
        TerritoryConditions Territory { get; }
        KindOfExperience Experience { get; }
        Affilations Affilation { get; }
    }
}
