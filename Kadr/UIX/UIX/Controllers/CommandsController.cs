using System;
using System.Collections.Generic;
using System.Text;

namespace UIX.Controllers
{
    /// <summary>
    /// Контроллер, интегрированный с менеджером комманд
    /// </summary>
    /// <typeparam name="TModel">Модель</typeparam>
    public class CommandsController<TModel> : GenericController<TModel>
        where TModel : /*System.ComponentModel.INotifyPropertyChanged, */new()
    {
        private Commands.CommandManager commandManager;

        /// <summary>
        /// Получает менеджер команд
        /// </summary>
        protected Commands.CommandManager Manager
        {
            get
            {
                if (commandManager == null)
                    commandManager = new Commands.CommandManager();
                return commandManager;
            }
        }

        public Commands.ICommandManager CommandManager
        {
            get
            {
                return Manager;
            }
        }

        /// <summary>
        /// Начать пакетную команду
        /// </summary>
        public void BeginBatchCommand()
        {
            Manager.BeginBatchCommand();
        }
        /// <summary>
        /// Завершить пакетную команду
        /// </summary>
        public void EndBatchCommand()
        {
            Manager.EndBatchCommand();
        }
        /// <summary>
        /// Возвращает истину, если контроллер находится в пакетном режиме
        /// </summary>
        public bool IsInBatchMode
        {
            get
            {
                return Manager.IsInBatchMode;
            }
        }

        public void TerminateBatchCommand()
        {
            Manager.TerminateBatchCommand();
        }

        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="command">Команда</param>
        public void Execute(Commands.ICommand command)
        {
            Manager.Execute(command, this);
        }
        /// <summary>
        /// Отменить последнюю команду
        /// </summary>
        public void Unexecute()
        {
            Manager.Unexecute(this);
        }
        /// <summary>
        /// Вернуть последнюю отмену
        /// </summary>
        public void Redo()
        {
            Manager.Redo(this);
        }

        /// <summary>
        /// Истина, если последняя команда может быть отменена
        /// </summary>
        public bool CanUnexecute
        {
            get
            {
                return Manager.CanUnexecute;
            }
        }
        /// <summary>
        /// Истина, если последняя отменённая команда может быть возвращена
        /// </summary>
        public bool CanRedo
        {
            get
            {
                return Manager.CanRedo;
            }
        }
        /// <summary>
        /// Интерфейс подписки на события менеджера команд
        /// </summary>
        public Commands.ICommandManagerNotifies CommandManagerNotifies
        {
            get
            {
                return Manager.GetCommandManagerNotifies();
            }
        }

        /// <summary>
        /// Получает имя команды
        /// </summary>
        /// <param name="command">Команда для которой нужно получить имя</param>
        /// <returns>Имя команды</returns>
        public string GetCommandName(Commands.ICommand command)
        {
            return Manager.GetCommandName(command);
        }

        

        
    }
}
