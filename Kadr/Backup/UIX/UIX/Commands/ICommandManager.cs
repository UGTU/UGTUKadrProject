using System;
namespace UIX.Commands
{
    /// <summary>
    /// Интерфейс менеджеров команд
    /// </summary>
    public interface ICommandManager
    {
        /// <summary>
        /// Начать пакетную команду
        /// </summary>
        void BeginBatchCommand();
        /// <summary>
        /// Закончить пакетную команду
        /// </summary>
        void EndBatchCommand();
        /// <summary>
        /// Откатывает ещё незавершённую пакетную команду, не помещая её в список выполненных команд
        /// </summary>
        void TerminateBatchCommand();
        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="command">Команда</param>
        /// <param name="sender">Источник сообщения</param>
        void Execute(ICommand command, object sender);
        /// <summary>
        /// ПОлучить название команды
        /// </summary>
        /// <param name="command">Команда</param>
        /// <returns>Описание</returns>
        string GetCommandName(ICommand command);
        /// <summary>
        /// Возвращает истина, если менеджер команд находится в пакетном режиме
        /// </summary>
        bool IsInBatchMode { get; }
        /// <summary>
        /// Повторить последнюю отменённую команду
        /// </summary>
        /// <param name="sender">Источник сообщения</param>
        void Redo(object sender);
        /// <summary>
        /// Отменить последнюю команду
        /// </summary>
        /// <param name="sender">Источник сообщения</param>
        void Unexecute(object sender);
        /// <summary>
        /// Получает ссылку на интерфейс регистратора команд
        /// </summary>
        /// <returns></returns>
        ICommandRegister GetCommandRegister();
        /// <summary>
        /// Получает ссылку на интерфейс событий менеджера команд
        /// </summary>
        /// <returns></returns>
        ICommandManagerNotifies GetCommandManagerNotifies();
        /// <summary>
        /// Возвращает имя команды, которая будет отменена следующей при вызове метода Unexecute
        /// </summary>
        /// <returns>Имя команды</returns>
        string GetNextUndoCommandName();
        /// <summary>
        /// Возвращает имя команды, которая будет повторена следующей при вызове метода Redo
        /// </summary>
        /// <returns>Имя команды</returns>
        string GetNextRedoCommandName();
        /// <summary>
        /// Производит очистку списков отменённых и воспроизведённых команд
        /// </summary>
        void ClearHistory();
        /// <summary>
        /// Возвращает массив выполненных команд
        /// </summary>
        /// <returns></returns>
        ICommand[] CopyHistory();

        /// <summary>
        /// Команда инициирует следующий шаг
        /// </summary>
        /// <param name="sourceCommand">Команда, вызвавшая переход к следующему шагу</param>
        /// <param name="stepNumber">Номер шага</param>
        /// <param name="message">Текст сообщения, связанный с шагом</param>
        void Step(IDiscreteCommand sourceCommand, int stepNumber, string message);
    }
    
}
