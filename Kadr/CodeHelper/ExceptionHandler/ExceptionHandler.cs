using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APG.CodeHelper.ExceptionHandler
{
    public class ExceptionHandler
    {
        private const string NotAllowedExceptionMessage = " Эта ошибка не должна проявляться в системе. Следует отправить отчёт об ошибке разработчику.";

        /// <summary>
        /// Обработчик исключительных ситуаций
        /// </summary>
        /// <param name="e">Исключение</param>
        public static void HandleApplicationException(object sender, Exception e)
        {

            if (e is System.Data.SqlClient.SqlException)
            {
                HandleSqlClientException(sender, e as System.Data.SqlClient.SqlException);
                return;
            }

            if (e is NoNullAllowedException)
            {
                HandleNoNullAllowedException(e as NoNullAllowedException);
                return;
            }

            if (e is DataException)
            {
                HandleDataException(e as DataException);
                return;
            }

            if (e is ReadOnlyException)
            {
                HandleReadOnlyException(e as ReadOnlyException);
                return;
            }

            if (e is DBConcurrencyException)
            {
                HandleDBConcurrencyException(e as DBConcurrencyException);
                return;
            }

            if (e is DeletedRowInaccessibleException)
            {
                HandleDeletedRowInaccessibleException(e as DeletedRowInaccessibleException);
                return;
            }

            if (e is DuplicateNameException)
            {
                HandleDuplicateNameException(e as DuplicateNameException);
                return;
            }

            if (e is EvaluateException)
            {
                HandleEvaluateException(e as EvaluateException);
                return;
            }

            if (e is InRowChangingEventException)
            {
                HandleInRowChangingEventException(e as InRowChangingEventException);
                return;
            }

            if (e is InvalidConstraintException)
            {
                HandleInvalidConstraintException(e as InvalidConstraintException);
                return;
            }

            if (e is MissingPrimaryKeyException)
            {
                HandleMissingPrimaryKeyException(e as MissingPrimaryKeyException);
                return;
            }

            if (e is OperationAbortedException)
            {
                HandleOperationAbortedException(e as OperationAbortedException);
                return;
            }

            if (e is RowNotInTableException)
            {
                HandleRowNotInTableException(e as RowNotInTableException);
                return;
            }

            if (e is StrongTypingException)
            {
                HandleStrongTypingException(e as StrongTypingException);
                return;
            }

            if (e is SyntaxErrorException)
            {
                HandleSyntaxErrorException(e as SyntaxErrorException);
                return;
            }

            if (e is TypedDataSetGeneratorException)
            {
                HandleTypedDataSetGeneratorException(e as TypedDataSetGeneratorException);
                return;
            }

            if (e is VersionNotFoundException)
            {
                HandleVersionNotFoundException(e as VersionNotFoundException);
                return;
            }

            // System exceptions

            if (e is System.ArgumentException)
            {
                HandleArgumentException(e as ArgumentException);
                return;
            }

            if (e is ArgumentNullException)
            {
                HandlArgumentNullException(e as ArgumentNullException);
                return;
            }

            if (e is NullReferenceException)
            {
                HandleNullReferenceException(e as NullReferenceException);
                return;
            }


            if (e is System.ComponentModel.Win32Exception)
            {
                HandleWin32Exception(e as Win32Exception);
                return;
            }
            if (e is ApplicationException)
            {
                HandleApplicationException(e as ApplicationException);
            }

            // Обработка неизвестных исключений
            HandleUnhandledException(e);
   
        }

        private static void HandleApplicationException(ApplicationException e)
        {
            ShowExceptionDialog(e, "Эта исключительная ситуация предусмотрена приложением и требует ваших действий по корректировке описанной выше проблемы.", "Запланированное исключение", MessageBoxIcon.Information, true);
        }

        private static void HandleUnhandledException(Exception e)
        {
            ShowExceptionDialog(e, "В системе произошла необработанная исключительная ситуация. Если эта ошибка часто повторяется обратитесь к разработчику.", "Необработанное исключение", MessageBoxIcon.Warning, true);
        }

        private static void HandleWin32Exception(Win32Exception win32Exception)
        {
            ShowExceptionDialog(win32Exception, "Ошибка при доступе к однму из сервисов подсистемы Win32. Проверьте запущены ли все необходимые службы и повторите попытку.", "Ошибка Win32", MessageBoxIcon.Exclamation, true);
        }

        private static void HandleNullReferenceException(NullReferenceException nullReferenceException)
        {
            ShowExceptionDialog(nullReferenceException, "Попытка доступа к неинициализированному (null) объекту. " + NotAllowedExceptionMessage, "Неопознанная ошибка", MessageBoxIcon.Information, true);
    
        }

        private static void HandlArgumentNullException(ArgumentNullException argumentNullException)
        {
            ShowExceptionDialog(argumentNullException, "Недопустимо использовать нулевое (null) значение аргумента метода класса. " + NotAllowedExceptionMessage, "Неопознання ошибка", MessageBoxIcon.Information, true);
        }

        private static void HandleArgumentException(ArgumentException argumentException)
        {
            ShowExceptionDialog(argumentException, "Ошибка в одном или нескольких параметрах метода класса. " + NotAllowedExceptionMessage, "Неопознання ошибка", MessageBoxIcon.Information, true);
        }

        private static void ShowExceptionDialog(Exception exception, string exceptionMessage, string aboutMessage, MessageBoxIcon messageBoxIcon, bool bShowSendButton, System.Type detailDialogType)
        {
            ExceptionDialog exceptionDialog = new ExceptionDialog(exception);
            exceptionDialog.DetailDialogType = detailDialogType;
            exceptionDialog.ExceptionMessage = exceptionMessage;
            exceptionDialog.AboutMessage = aboutMessage;
            exceptionDialog.MessageIcon = messageBoxIcon;
            exceptionDialog.Text = Application.ProductName;
            exceptionDialog.BtnRaport.Visible = bShowSendButton;

            exceptionDialog.ShowDialog();
        }

        private static void ShowExceptionDialog(Exception exception, string exceptionMessage, string aboutMessage, MessageBoxIcon messageBoxIcon, bool bShowSendButton)
        {
            ShowExceptionDialog(exception, exceptionMessage, aboutMessage, messageBoxIcon, 
                bShowSendButton, typeof(MoreExceptionDialog));
        }

        /// <summary>
        /// Обработчик исключений от SQL Server 2005
        /// </summary>
        /// <param name="e"></param>
        private static void HandleSqlClientException(object sender, System.Data.SqlClient.SqlException e)
        {
            const int MSSQL_CONNECTION_ERROR = -1;
            const int MSSQL_SERVICE_STOPED = 2;
            const int MSSQL_SERVICE_PAUSED = 17142;
            const int MSSQL_CONSTRAINT_VIOLATED = 547;
            const int MSSQL_NULL_NOT_ALLOWED = 515;
            const int MSSQL_MSDTC_NOT_RUNNING = 8501;
            const int MSSQL_UNIQUE_VIOLATED = 2627;
            const int MSSQL_LOGIN_FAILED = 4060;
            const int MSSQL_FILE_ACCESS_DENIED = 5120;
            const int MSSQL_LOGIN_DENIED = 18456;
            const int MSSQL_CONNECTION_FAILED = 53;
            const int MSSQL_EXECUTE_TIMEOUT = 30;
            const int MSSQL_PERMISSION_DENIED = 229;
            const int MSSQL_CLR_DISABLED = 6263;

            string errorMessage = "Дополнительная информация об ошибке отсутствует.";
            
            switch (e.Number)
            {
                case MSSQL_CONNECTION_ERROR:
                    errorMessage = "Ошибка подключения к службе SQL Server. Убедитесь, что вы правильно указали имя сервера и что сервер принимает подключения. Обратитесь за помощью к администратору баз данных."; break;
                case MSSQL_SERVICE_STOPED: 
                    errorMessage = "Служба Microsoft SQL Server остановлена или указано неверное имя сервера. Убедитесь, что служба запущена и указано верное имя сервера. Обратитесь за помощью к администратору базы данных."; break;
                case MSSQL_SERVICE_PAUSED:
                    errorMessage = "Служба Microsoft SQL Server приостановлена или переведена в режим offline. Запустите службу и повторите попытку. Обратитесь за помощью к администратору баз данных."; break;
                case MSSQL_CONSTRAINT_VIOLATED:
                    errorMessage = "Выполнение опрации было отменено в результате срабатывания ограничений. Если вы проводите операцию добавления или изменения данных, то убедитесь, что вы заполнили все необходимые поля, данные имеют правильный формат и попадают в допустимый диапазон значений. Операция удаления могла быть отменена в результате наличия зависимости по данным. Удалите все зависимые данные и повторите попытку удаления."; break;
                case MSSQL_NULL_NOT_ALLOWED:
                    errorMessage = "Выполнение операции было отменено, так как не заданы значения в одном или нескольких необходимых к заполнению полях. Заполните необходимые поля и повторите операцию."; break;
                case MSSQL_MSDTC_NOT_RUNNING:
                    errorMessage = "Служба координатора распределённых транзакций не запущена. Воспользуйтесь оснасткой администрирования \"Службы\" (Панель управления -> Администрирование -> Службы) для запуска."; break;
                case MSSQL_UNIQUE_VIOLATED:
                    errorMessage = "Выполнение операции было отменено в результате срабатывания ограничения на уникальность. Эта ошибка возникает, если вы пытаетесь добавить в систему объект, информация о котором уже присутствует в базе данных. Проверьте корректность значений и повторите попытку."; break;
                case MSSQL_LOGIN_FAILED:
                    errorMessage = "Соединение с сервером установлено, но база данных на сервере отсутствует. Возможно, что файлы баз данных были отсоеденены от сервера. Для устранения этой ошибки обратитесь к администратору."; break;
                case MSSQL_FILE_ACCESS_DENIED:
                    errorMessage = "Доступ к файлам баз базы данных запрещён. Возможно файлы открыты в другой программе или для них выставлен атрибут \"Только для чтения\". Если используется файловая система NTFS проверьте также наличие соответствующих прав для доступа к файлам. Обратитесь к администратору за помощью."; break;
                case MSSQL_LOGIN_DENIED:
                    errorMessage = "Вам отказано в доступе к данным под указанным именем. Вероятно, системный администратор не внёс Вас в список пользователей сервера баз данных или ограничил доступ. Для решения проблемы обратитесь к администратору."; break;
                case MSSQL_CONNECTION_FAILED:
                    errorMessage = "Не удаётся установить связь с сервером баз данных SQL Server. Убедитесь, что вы правильно указали имя сервера и что сервер принимает подключения. Обратитесь за помощью к администратору баз данных."; break;
                case MSSQL_EXECUTE_TIMEOUT:
                    errorMessage = "Операция заняла много времени и сервер прервал её выполнение. Эта ошибка может проявляться при высокой загрузке сервера или выполнения операций над большим количеством объектов базы данных. Попробуйте разбить одну длинную операцию на несколько. Подождите снижения нагрузки на систему и повторите попытку.";
                    break;
                case MSSQL_PERMISSION_DENIED:
                    errorMessage ="Вам отказано в доступе к одному из объектов базы данных. Для решения проблемы обратитесь к системному администратору.";
                    break;
                case MSSQL_CLR_DISABLED:
                    errorMessage = "Для текущей базы данных запрещно использование CLR. Для включения поддержки CLR используйте опцию 'clr enable' процедуры sp_configure. Пример использования:\nsp_configure 'clr enabled', 1\nGO\nRECONFIGURE\nGO\nОбратитесь за помощью к администратору.";
                    break;
            }
           
            ShowExceptionDialog(e, errorMessage, "Microsoft SQL Server", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения ошибки доступа к удалённой версии набора данных
        private static void HandleVersionNotFoundException(VersionNotFoundException versionNotFoundException)
        {
            ShowExceptionDialog(versionNotFoundException, NotAllowedExceptionMessage, "Неопознання ошибка", MessageBoxIcon.Information, true);
        }

        
        // Обработчик исключения конфликта имён в строго-типизированном наборе данных
        private static void HandleTypedDataSetGeneratorException(TypedDataSetGeneratorException typedDataSetGeneratorException)
        {
            ShowExceptionDialog(typedDataSetGeneratorException, "Конфликт имён объектов в строго-типизированном наборе данных. " + NotAllowedExceptionMessage, "Неопознання ошибка", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения синтаксической ошибки в вычисляемом выражении
        private static void HandleSyntaxErrorException(SyntaxErrorException syntaxErrorException)
        {
            ShowExceptionDialog(syntaxErrorException, "Синтаксическая ошибка в вычисляемом поле набора данных. " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        //Обработчик исключения строго-типизированного набора данных при попытке доступа к DBNull
        private static void HandleStrongTypingException(StrongTypingException strongTypingException)
        {
            ShowExceptionDialog(strongTypingException, "Ошибка в строго-типизированном наборе данных. " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения доступа к строке, отсутствующей в наборе данных
        private static void HandleRowNotInTableException(RowNotInTableException rowNotInTableException)
        {
            ShowExceptionDialog(rowNotInTableException, "Была попытка доступа к строке данных в таблице, которая ей не принадлежит. " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения модификации столбца только для чтения
        private static void HandleReadOnlyException(ReadOnlyException readOnlyException)
        {
            ShowExceptionDialog(readOnlyException, "Попытка модификации поля, не предназначенного для изменения была отменена. " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        //Обработчик исключения отмены операции
        private static void HandleOperationAbortedException(OperationAbortedException operationAbortedException)
        {
            ShowExceptionDialog(operationAbortedException, "Операция была отменена.", "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения недопустимости вставки NULL
        private static void HandleNoNullAllowedException(NoNullAllowedException noNullAllowedException)
        {
            ShowExceptionDialog(noNullAllowedException, "Выполнение операции было отменено, так как не заданы значения в одном или нескольких необходимых к заполнению полях. Заполните необходимые поля и повторите операцию.", "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения доступа к таблице без первичного ключа
        private static void HandleMissingPrimaryKeyException(MissingPrimaryKeyException missingPrimaryKeyException)
        {
            ShowExceptionDialog(missingPrimaryKeyException, "В наборе данных отсутствует первичный ключ. " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения неправильного сосздания или использования ограничения
        private static void HandleInvalidConstraintException(InvalidConstraintException invalidConstraintException)
        {
            ShowExceptionDialog(invalidConstraintException, "Ошибка при назначении или использовании ограничений в наборе данных. " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения вызова метода EndEdit
        private static void HandleInRowChangingEventException(InRowChangingEventException inRowChangingEventException)
        {
            ShowExceptionDialog(inRowChangingEventException, "Произошла ошибка при вызове метода EndEdit(). " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }


        // Обработчик исключения ошибки вычисления выражения в вычисляемом поле набора данных
        private static void HandleEvaluateException(EvaluateException evaluateException)
        {
            ShowExceptionDialog(evaluateException, "Ошибка вычисления выражения в поле таблицы набора данных. " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения дублирующихся имён в наборе данных
        private static void HandleDuplicateNameException(DuplicateNameException duplicateNameException)
        {
            ShowExceptionDialog(duplicateNameException, "Ошибка вызвана наличием дублирующихся имён объектов в наборе данных. " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }


        //Обработчик исключения доступа к удалённой строке данных (DataRow)
        private static void HandleDeletedRowInaccessibleException(DeletedRowInaccessibleException deletedRowInaccessibleException)
        {
            ShowExceptionDialog(deletedRowInaccessibleException, "Ошибка доступа к строке данных таблицы, которая была из неё исключена. " + NotAllowedExceptionMessage, "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения адаптера, если операции Insert, Update, Delete вернули 0 обработанных строк
        private static void HandleDBConcurrencyException(DBConcurrencyException dBConcurrencyException)
        {
            ShowExceptionDialog(dBConcurrencyException, "Сохранение изменений отменено так как эти данные были модифицированы сразу несколькими пользователями. Обновите содержимое окна для загрузки последней версии данных и повторите попытку модификации.", "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

        // Обработчик исключения ADO.NET
        private static void HandleDataException(DataException dataException)
        {
            ShowExceptionDialog(dataException, "Эта ошибка проявляется, если пользователь заполнил не все нужные поля формы, либо ввёл недопустимое для поля значение. Проверьте правильность значений и повторите попытку ввода данных.", "Модификация базы данных отменена", MessageBoxIcon.Information, true);
        }

    }
}
