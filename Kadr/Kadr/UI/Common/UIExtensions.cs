using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Microsoft.ReportingServices.DataProcessing;
using IDbConnection = System.Data.IDbConnection;

namespace Kadr.UI.Common
{
    public enum DbConnectionPurpose
    {
        /// <summary>
        /// Релизная версия продукта
        /// </summary>
        Release,
        /// <summary>
        /// Локальная версия для тестирования и отладки
        /// </summary>
        LocalDebug,
        /// <summary>
        /// Общедоступная версия продукта для тестирования
        /// </summary>
        PublicTest,
        /// <summary>
        /// Не известно назначение продукта
        /// </summary>
        Unknown
    }

    public static class UiExtensions
    {
        /// <summary>
        /// Получает назначение базы данных, основываясь на её имени
        /// </summary>
        /// <param name="connection">Соединение</param>
        /// <returns>Назначение базы данных</returns>
        public static DbConnectionPurpose GetDbPurpose(this IDbConnection connection)
        {
            if (connection == null) throw new ArgumentNullException("connection");

            const string publicTestSubstring = "TEST";
            const string localDebugSubstring = "DEBUG";

            var cs = new SqlConnectionStringBuilder(connection.ConnectionString).InitialCatalog;

            if (string.IsNullOrEmpty(cs))
                return DbConnectionPurpose.Unknown;
            if (cs.ToUpper().Contains(publicTestSubstring))
                return DbConnectionPurpose.PublicTest;
            return cs.ToUpper().Contains(localDebugSubstring) 
                ? DbConnectionPurpose.LocalDebug : DbConnectionPurpose.Release;
        }
    }
}
