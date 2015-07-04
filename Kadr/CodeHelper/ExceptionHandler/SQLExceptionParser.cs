using System;
using System.Collections.Generic;
using System.Text;

/*
 * SQL Server славен тем, что все сообщения о сработавших ограничениях выходят 
 * в неформализованой стройчной форме. Например:
 * 
 *  (ErrCode: 547) The DELETE statement conflicted with the REFERENCE constraint "FK_Visa_DaylyReport". 
 *  The conflict occurred in database "ISGBDB", table "dbo.Visa", column 'DailyReportID'.
 * 
 *  (ErrCode: 547) The INSERT statement conflicted with the FOREIGN KEY SAME TABLE constraint "FK_TVNode_TVNode". 
 *  The conflict occurred in database "AjaxTV", table "dbo.TVNode", column 'ID'.
 * 
 *  (ErrCode: 547) The UPDATE statement conflicted with the CHECK constraint "CK_Income". 
 *  The conflict occurred in database "ISGBDB", table "dbo.Income", column 'Count'.
 *
 * Класс SQL2005ExceptionParser предназначен для 
 * выделения из строки исключения данных о сработавшем декларативном ограничении.
 * Класс спроектирован как класс, сохраняющий состояние, т.о. вы сначала должны создать
 * объект класса SQL2005ExceptionParser, задать свойство SqlExceptionToParse, вызвать метод
 * Parse().
 */

namespace APG.CodeHelper.ExceptionHandler
{
    
    /// <summary>
    /// Класс синтаксического разбора исключения SQL Server 2005
    /// </summary>
    public class SQL2005ExceptionParser
    {
        /// <summary>
        /// Класс для описания декларативного ограничения на объекты БД
        /// </summary>
        public class Constraint
        {

            private ConstraintExceptionType constraintType = ConstraintExceptionType.UnknownConstraintException;
            private string constraintName = "";

            /// <summary>
            /// Тип декларативного ограничения на объекты БД
            /// </summary>
            public enum ConstraintExceptionType
            {
                UniqueConstraintException,
                ForeignKeyConstraintException,
                PrimaryKeyConstraintException,
                UnknownConstraintException
            }

            /// <summary>
            /// Возвращает тип сработавшего декларативного ограничения
            /// </summary>
            public ConstraintExceptionType ConstraintType
            {
                get
                {
                    return constraintType;
                }
            }

            /// <summary>
            /// Производит разбор исключения от SQL Server 2005
            /// </summary>
            /// <param name="e">Экземпляр класса с исключения SQL Server 2005</param>
            /// <returns>Истина, если разбор закончился удачей. 
            /// В противном случае возвращается ложь, значение свойства ConstaintType 
            /// устанавливается как ConstraintExceptionType.UnknownConstraintException. Значение свойства ConstraintName не определено.</returns>
            public bool ParseConstraint(System.Data.SqlClient.SqlException e)
            {
                constraintName = "";
                return true;
            }

            /// <summary>
            /// Возвращает имя сработавшего декларативного ограничения
            /// </summary>
            public string ConstraintName
            {
                get
                {
                    return constraintName;
                }
            }
        }

        private System.Data.SqlClient.SqlException sqlExceptionToParse;
        private string messageToParse;
        
        private string tableName;

        private Constraint exceptionConstraint = new Constraint();

        private string databaseName;

        private string columnName;

        private bool isParsed = false;

        private SqlCommandType commandType = SqlCommandType.SqlUnknownCommand;

        /// <summary>
        /// Описывает тип команды, которая привела к выбросу исключения
        /// </summary>
        public enum SqlCommandType
        {
            SqlInsertCommand,
            SqlDeleteCommand,
            SqlUpdateCommand,
            SqlUnknownCommand
        }

        /// <summary>
        /// Возвращает таблицу БД, с которой связано исключение
        /// </summary>
        public string TableName
        { 
            get
            {
                return tableName;
            }
        }

        /// <summary>
        /// Устанавливает или возвращает объект-ислючение для которого проводится разбор
        /// </summary>
        public System.Data.SqlClient.SqlException SqlExceptionToParse
        {
            get { return sqlExceptionToParse; }
            set 
            { 
                sqlExceptionToParse = value;
                tableName = "";
                columnName = "";
                databaseName = "";

                if (sqlExceptionToParse != null)
                    messageToParse = sqlExceptionToParse.Message;


            }
        }

        /// <summary>
        /// Возвращает описание декларативного ограничения
        /// </summary>
        public Constraint ExceptionConstraint
        {
            get
            {
                return exceptionConstraint;
            }
        }

        /// <summary>
        ///  Возвращает имя базы данных, связанную с декларативным ограничением
        /// </summary>
        public string DatabaseName
        {
            get
            {
                return databaseName;
            }
        }
        /// <summary>
        /// Возвращает имя столбца, связаного с декларативным ограничением
        /// </summary>
        public string ColumnName
        {
            get
            {
                return columnName;
            }
        }

        /// <summary>
        /// Возвращает истину, если последний вызов метода Parse был успешным
        /// </summary>
        public bool IsParsed
        {
            get
            {
                return isParsed;
            }
        }

        private enum ParsingState
        {
            InitParsingState,
            ParsedParsingState,
            CheckParsingSuperstate,
            ActionParsedState,
            UnParsedParsingState

        }

        ParsingState parsingState;
        
        /// <summary>
        /// Производит разбор исключения для выделения данных о сработавшем ограничении
        /// </summary>
        /// <returns>Истина, если разбор произведён успешно</returns>
        public bool Parse()
        {
            isParsed = false;
            parsingState = ParsingState.InitParsingState;

            if (SqlExceptionToParse == null)
                throw new ArgumentException("SqlExceptionToParse не задан.");

            while ((parsingState != ParsingState.ParsedParsingState) || (parsingState != ParsingState.UnParsedParsingState))
            {
                switch (parsingState)
                {
                    case ParsingState.InitParsingState:
                        InitParsingStateParse(); 
                        break;
                    case ParsingState.CheckParsingSuperstate:
                        CheckParsingSupersateParse();
                        break;

                }
            }
            return isParsed;
        }

        
        private void CheckParsingSupersateParse()
        {
            string[] actions = new string[3]{ "INSERT", "DELETE", "UPDATE" };    
            string actionTemplate = "The {0} statement conflicted with the";
            string action;
            parsingState = ParsingState.UnParsedParsingState;

            for (int i = 0; i < actions.Length; i++)
            {
                action = string.Format(actionTemplate, actions[i]);
                if (messageToParse.IndexOf(action, 0) != -1)
                {
                    parsingState = ParsingState.ActionParsedState;
                    commandType = (SqlCommandType)i;
                    break;
                }
            }
        }

        private void InitParsingStateParse()
        {
            if (SqlExceptionToParse.ErrorCode == 547)
            {
                parsingState = ParsingState.CheckParsingSuperstate;
            }
            else
                parsingState = ParsingState.UnParsedParsingState;

        }
        
    }
}
