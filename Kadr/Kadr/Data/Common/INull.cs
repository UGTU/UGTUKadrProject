using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    /// <summary>
    /// Тип, поддерживающий Null-объекты
    /// </summary>
    interface INullable
    {

    }

    interface INull:INullable
    {

    }

    static class NullExtentsions
    {
        /// <summary>
        /// Является ли объект null-объектом
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Истина, если объект является null-объектом</returns>
        public static bool IsNull(this INullable obj)
        {
            if (obj == null) throw new ArgumentNullException("Obj");
            return (obj is INull);
        }
        /// <summary>
        /// Получает INull интерфейс объекта
        /// </summary>
        /// <param name="obj">Объект</param>
        /// <returns>Интерфейс типа INull</returns>
        public static INullable AsNull(this INullable obj)
        {
            return obj;
        }
    }
}
