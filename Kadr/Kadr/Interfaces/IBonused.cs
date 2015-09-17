using Kadr.Data.Common;
using System;

namespace Kadr.Interfaces
{
    public enum ExpirienceType { Working, WorkingYoung}

    public interface IBonused
    {
        /// <summary>
        /// Получает время работы
        /// </summary>
        TimeSpan WorkingTime { get; }

        /// <summary>
        /// Получает вид стажа
        /// </summary>
        ExpirienceType TypeOfWork { get; }

        /// <summary>
        /// Получает территориальные условия работы
        /// </summary>
        TerritoryConditions Territory { get; }
    }
}