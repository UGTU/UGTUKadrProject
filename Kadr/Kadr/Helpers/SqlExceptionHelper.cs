using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Kadr.Helpers
{
    public enum UniqueType
    {
        Primary,
        Unique,
        Foreign,
        Unknown
    }
    public enum OperationType
    {
        Insert,
        Update,
        Delete,
        Select,
        Unknown
    }
    public static class SqlExceptionHelper
    {
        //Cannot insert duplicate key row in object '%.*ls' with unique index '%.*ls'.
        public const int DuplicateKeyNumber = 2601;
        public const int KeyViolationNumber = 2627;
        public const int CheckConstraintViolationNumber = 547;
        public const int InvalidColumnNameNumber = 207;
        public const int InvalidObjectNameNumber = 208;

        private static bool IsEqualsToNumber(this SqlException source, int number)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            return (source.Number == number);
        }
        public static bool IsDuplicateKey(this SqlException source)
        {
            return source.IsEqualsToNumber(DuplicateKeyNumber);
        }
        public static bool IsInvalidObjectName(this SqlException source)
        {
            return source.IsEqualsToNumber(InvalidObjectNameNumber);
        }
        public static bool IsInvalidColumnName(this SqlException source)
        {
            return source.IsEqualsToNumber(InvalidColumnNameNumber);
        }
        /// <summary>
        /// Является ли исключение нарушением первичного, внешнего ключа или ограничения уникальности
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsKeyViolation(this SqlException source)
        {
            return source.IsEqualsToNumber(KeyViolationNumber);
        }
        /// <summary>
        /// Является ли исключение нарушением ограничения оператора Check
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static bool IsCheckConstraintViolation(this SqlException source)
        {
            return source.IsEqualsToNumber(CheckConstraintViolationNumber);
        }


        public static UniqueType GetUniqueType(this SqlException source)
        {
            var keyString = new[] {"PRIMARY", "UNIQUE", "FOREIGN"};
            
            if (!source.IsKeyViolation())
                throw new InvalidOperationException("Исключение не является ограничением ключа.");
            var parsed = keyString.FirstOrDefault(x=>source.Message.Contains(x));
            if (parsed != null)
            {
                return (UniqueType) Enum.Parse(typeof (UniqueType), parsed, true);
            }
            return UniqueType.Unknown;
        }

        public static OperationType GetOperationType(this SqlException source)
        {
            var keyString = new[] { "INSERT", "UPDATE", "DELETE", "SELECT" };

            var parsed = keyString.FirstOrDefault(x => source.Message.Contains(x));
            if (parsed != null)
            {
                return (OperationType)Enum.Parse(typeof(OperationType), parsed, true);
            }
            return OperationType.Unknown;
        }
    }
}
