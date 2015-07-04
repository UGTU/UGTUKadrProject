using System;
namespace UIX.Commands
{
    /// <summary>
    /// Интерфейс подписчика на события менеджера команд
    /// </summary>
    public interface ICommandManagerNotifies
    {
        /// <summary>
        /// Событие, возникающее после исполнения команды менеджером команд
        /// </summary>
        event EventHandler<CommandArgs> AfterCommandExecute;
        /// <summary>
        /// Событие, возникающее после отмены команды менеджером команд
        /// </summary>
        event EventHandler<CommandArgs> AfterCommandUnexecute;
        /// <summary>
        /// Событие, возникающее при переводе в пакетный режим менеджера команд
        /// </summary>
        event EventHandler<CommandArgs> BatchCommandBegins;
        /// <summary>
        /// Событие, возникающее при выходе из пакетного режима менеджера команд
        /// </summary>
        event EventHandler<EventArgs> BatchCommandEnds;
        /// <summary>
        /// Событие, возникающее перед выполнением команды менеджером команд
        /// </summary>
        event EventHandler<CommandHandledArgs> BeforeCommandExecute;
        /// <summary>
        /// Событие, возникающее перед отмной команды менеджером команд
        /// </summary>
        event EventHandler<CommandHandledArgs> BeforeCommandUnexecute;
        /// <summary>
        /// Событие, возникающее после очистки списков отменённых и воспроизведённых команд
        /// </summary>
        event EventHandler HistoryCleaned;
        /// <summary>
        /// Событие возникает в дискретной команде при переходе к следующему шагу
        /// </summary>
        event EventHandler<CommandProgressArgs> CommandProgress;
    }
}
