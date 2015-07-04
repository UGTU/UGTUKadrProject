using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    /// <summary>
    /// Тип, поддерживающий Null-объекты
    /// </summary>
    interface INull
    {
        bool IsNull();
    }

    static class NullExtentsions
    {
        /// <summary>
        /// Является ли объект null-объектом
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Истина, если объект является null-объектом</returns>
        public static bool IsNull(this INull obj)
        {
            return obj.IsNull(); 
        }
        /// <summary>
        /// Получает INull интерфейс объекта
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Интерфейс типа INull</returns>
        public static INull AsNull(this INull obj)
        {
            return obj;
        }
    }
}
