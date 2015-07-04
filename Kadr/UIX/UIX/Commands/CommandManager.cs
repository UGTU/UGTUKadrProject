using System;
using System.Collections.Generic;

namespace UIX.Commands
{    
      
    /// <summary>
    /// Стандартная реализация ICommandManager, ICommandManagerNotifies, ICommandRegister
    /// </summary>
    public class CommandManager : ICommandManagerNotifies, ICommandManager, ICommandRegister
    {
        private BatchCommand currentBatch;
        private Stack<ICommand> history = new Stack<ICommand>(100);
        private Stack<ICommand> redohistory = new Stack<ICommand>(100);
        
        /// <summary>
        /// Возвращает истину, если менеджер команд выполняет пакетную команду
        /// </summary>
        public bool IsInBatchMode
        {
            get
            {
                return currentBatch != null;
            }

        }

        /// <summary>
        /// Начинает новую пакетную команду
        /// </summary>
        /// <param name="isOneWayCommand">Является ли команда </param>
        public void BeginBatchCommand(bool isOneWayCommand)
        {
            if (currentBatch != null) throw new BatchException("Пакетная команда уже начата. Завершите предыдущую команду, вызвав EndBatchCommand() пред началом следующей.");

            currentBatch = new BatchCommand(isOneWayCommand);
            
            if (BatchCommandBegins != null)
            {
                CommandArgs commandArgs = new CommandArgs(currentBatch);
                BatchCommandBegins(this, commandArgs);
            }

        }
        /// <summary>
        /// Производит очистку списков выполненных и отменённых команд.
        /// </summary>
        public void ClearHistory()
        {
            if (IsInBatchMode) throw new BatchException("Очистка команд в пакетном режиме не допускается.");
            history.Clear();
            redohistory.Clear();

            if (HistoryCleaned != null)
                HistoryCleaned(this, EventArgs.Empty);


        }
        /// <summary>
        /// Начинает пакетную команду        
        /// </summary>
        /// <exception cref="BatchException">Менеджер уже находится в пакетном режиме</exception>        
        public void BeginBatchCommand()
        {
            BeginBatchCommand(false);
        }
        /// <summary>
        /// Возвращает интерфейс регистратора команд
        /// </summary>
        /// <returns>Интерфейс регистратора</returns>
        public ICommandRegister GetCommandRegister()
        {
            return this;
        }
        /// <summary>
        /// Зарегистрировать команду, выполненную вне контекста менеджера команд
        /// </summary>
        /// <param name="command">Команда</param>
        public void RegisterCommand(ICommand command)
        {
            RegisterCommandInStack(command, true);
            RaiseAfterExecuteEvent(command);
        }
        /// <summary>
        /// Заканчивает пакетную команду        
        /// </summary>
        /// <exception cref="BatchException"></exception>
        public void EndBatchCommand()
        {
            EndCurrentBatch(false);
        }

        public void TerminateBatchCommand()
        {
            EndCurrentBatch(true);
        }

        private void EndCurrentBatch(bool terminate)
        {
            if (currentBatch != null)
            {
                try
                {
                    if (terminate)
                        currentBatch.Unexecute(this);
                    else
                    {
                        if (!currentBatch.IsOneWayCommand(this))
                            history.Push(currentBatch);
                    }
                }
                finally
                {
                    currentBatch = null;
                }
                
                if (BatchCommandEnds != null)
                    BatchCommandEnds(this, EventArgs.Empty);

            }
            else
            {
                throw new BatchException("A batch command didn't start. Invoke BeginBatchCommand() method to get into the batch mode.");
            }
        }

        /// <summary>
        /// Выполнить команду с помещением её в стек выполненных команд
        /// </summary>
        /// <param name="command">Команда для выполнения</param>
        /// <param name="sender">Источник команды</param>
        public void Execute(ICommand command, object sender)
        {
            ExecuteInternal(command, sender, true);
        }

        private void ExecuteInternal(ICommand command, object sender, bool clearredo)
        {
            // Fire before execute
            if (BeforeCommandExecute != null)
            {
                CommandHandledArgs beforeArgs = new CommandHandledArgs(command);
                BeforeCommandExecute(this, beforeArgs);
                if (!beforeArgs.Allow)
                    return;
            }

            try
            {
                // Execute
                command.Execute(sender);

                if (!command.IsOneWayCommand(sender))
                    // Register executed in stack
                    RegisterCommandInStack(command, clearredo);
            }

            finally
            {
                // Raise the event
                RaiseAfterExecuteEvent(command);
            }
             
        }

        /// <summary>
        /// Получить интерфейс событий менеджера команд
        /// </summary>
        /// <returns></returns>
        public ICommandManagerNotifies GetCommandManagerNotifies()
        {
            return this;
        }

        private void RaiseAfterExecuteEvent(ICommand command)
        {
            // Fire after execute
            if (AfterCommandExecute != null)
            {
                CommandArgs afterArgs = new CommandArgs(command);
                AfterCommandExecute(this, afterArgs);
            }
        }

        private void RegisterCommandInStack(ICommand command, bool clearredo)
        {
            if (currentBatch == null)
                history.Push(command);
            else
                currentBatch.Add(command);

            if (clearredo)
                redohistory.Clear();
        }

        /// <summary>
        /// Отменяет последнюю команду
        /// </summary>
        /// <param name="sender">Источник</param>
        /// <exception cref="BatchException"></exception>
        public void Unexecute(object sender)
        {
            if (currentBatch != null)
                throw new BatchException("To unexecute the last command the current batch command must be completed using EndBatchCommand() method.");
            if (history.Count > 0)
            {
                // Fire before unexecute
                if (BeforeCommandUnexecute != null)
                {
                    ICommand command = history.Peek();
                    CommandHandledArgs beforeArgs = new CommandHandledArgs(command);
                    BeforeCommandUnexecute(this, beforeArgs);
                    if (!beforeArgs.Allow)
                        return;
                }

                ICommand cmd = history.Pop();
                cmd.Unexecute(sender);
                redohistory.Push(cmd);
                
                // Fire after unexecute
                if (AfterCommandUnexecute != null)
                {
                    CommandArgs afterArgs = new CommandArgs(cmd);
                    AfterCommandUnexecute(this, afterArgs);
                }
            }             
        }

        /// <summary>
        /// Повторить последнюю отменённую команду
        /// </summary>
        /// <param name="sender">Источник сообщения</param>
        /// <exception cref="BatchException"></exception>
        public void Redo(object sender)
        {
            if (currentBatch != null)
                throw new BatchException("To redo the last unexecuted command the current batch command must be completed using EndBatchCommand() method.");
            
            if (redohistory.Count > 0)
            {

                ICommand cmd = redohistory.Pop();
                ExecuteInternal(cmd, sender, false);
            }
        }

        /// <summary>
        /// Число команд в стеке отмены
        /// </summary>
        public int HistoryCount
        {
            get
            {
                return history.Count;
            }
        }
        /// <summary>
        /// Число команд в стеке позврата
        /// </summary>
        public int RedoHistoryCount
        {
            get
            {
                return redohistory.Count;
            }
        }
        /// <summary>
        /// Истина, если есть команда, которую можно отменить
        /// </summary>
        public bool CanUnexecute
        {
            get
            {
                return HistoryCount > 0;
            }
        }
        /// <summary>
        /// Истина, если есть команда которую можно вернуть
        /// </summary>
        public bool CanRedo
        {
            get
            {
                return RedoHistoryCount > 0;
            }
        }

        public  string GetNextUndoCommandName()
        {
            if (history.Count > 0)
                return GetCommandName(history.Peek());
            else
                return string.Empty;
        }


        public string GetNextRedoCommandName()
        {
            if (redohistory.Count > 0)
                return GetCommandName(redohistory.Peek());
            else
                return string.Empty;
        }

        /// <summary>
        /// Копирует стек отмены в массив
        /// </summary>
        /// <returns>Массив команд</returns>
        public ICommand[] CopyHistory()
        {
            return history.ToArray();
        }

        /// <summary>
        /// Копирует стек повтора в массив
        /// </summary>
        /// <returns>Массив команд</returns>
        public ICommand[] CopyRedo()
        {
            return redohistory.ToArray();
        }

        private T[] GetCommandAttribute<T>(ICommand command)
        {
            T[] result = default(T[]);
            if (command == null)
                return result;
            result = command.GetType().GetCustomAttributes(typeof(T), false) as T[];
            return result;
        }
        
        /// <summary>
        /// Получает имя команды через атрибут DisplayNameAtribute
        /// </summary>
        /// <param name="command">Команда для которой необходимо узнать имя</param>
        /// <returns>Имя команды</returns>
        public string GetCommandName(ICommand command)
        {
            System.ComponentModel.DisplayNameAttribute[] attributes =
                GetCommandAttribute<System.ComponentModel.DisplayNameAttribute>(command);
            if ((attributes != null) && (attributes.Length == 1))
            {
                return attributes[0].DisplayName;
            }
            else
                return null;
        }

        public void Step(IDiscreteCommand sourceCommand, int stepNumber, string message)
        {
            if (CommandProgress!= null)
                CommandProgress(this, new CommandProgressArgs(stepNumber, message, sourceCommand));
        }

        
        public event EventHandler<CommandArgs> AfterCommandExecute;
        public event EventHandler<CommandArgs> AfterCommandUnexecute;
        public event EventHandler<CommandHandledArgs> BeforeCommandExecute;
        public event EventHandler<CommandHandledArgs> BeforeCommandUnexecute;
        public event EventHandler<CommandArgs> BatchCommandBegins;
        public event EventHandler<EventArgs> BatchCommandEnds;
        public event EventHandler HistoryCleaned;
        public event EventHandler<CommandProgressArgs> CommandProgress;

                       
    }

    /// <summary>
    /// Аргументы события при выполнении или отмены команды
    /// </summary>
    public class CommandArgs:EventArgs
    {
        private ICommand command;
        /// <summary>
        /// Выполненная или отменённая команда
        /// </summary>
        public ICommand Command
        {
            get
            {
                return command;
            }
        }
        /// <summary>
        /// Создаёт экземпляр CommandArgs
        /// </summary>
        /// <param name="command">Выполненная или отменённая команда</param>
 
        internal CommandArgs(ICommand command)
        {
            this.command = command;
        }
    }

    /// <summary>
    /// Аргументы события, возникающего перед выполнением или отменой команды
    /// </summary>
    public class CommandHandledArgs : EventArgs
    {
        private ICommand command;
        private bool allow;

        /// <summary>
        /// Истина, если нужно отменить выполнение или отмену команды
        /// </summary>
        public bool Allow
        {
            get { return allow; }
            set { allow = value; }
        }
        /// <summary>
        /// Команда, запросившая выполнение или отмену
        /// </summary>
        public ICommand Command
        {
            get
            {
                return command;
            }
        }

        
        /// <summary>
        /// Создаёт экземпляр CommandHandledArgs
        /// </summary>
        /// <param name="command">Команда, запросившая отмену или выполнение</param>
        internal CommandHandledArgs(ICommand command)
        {
            this.command = command;
            Allow = true;
        }
    }

    public class CommandProgressArgs : EventArgs
    {
        public int Step { get; private set; }
        public string Message { get; private set; }
        public IDiscreteCommand Command { get; private set; }
        public CommandProgressArgs(int step, string message, IDiscreteCommand command)
        {
            this.Step = step;
            this.Message = message;
            this.Command = command;
        }

        public override string ToString()
        {
            return string.Format("Step='{0}' Message='{1}' Command='{2}'", Step, Message, Command);
        }
    }

    /// <summary>
    /// Исключение при выполнении пакетной команды
    /// </summary>
    public class BatchException : ApplicationException
    {
        /// <summary>
        /// Создаёт экземпляр BatchException
        /// </summary>
        /// <param name="message">Сообщение</param>
        internal BatchException(string message) : base(message) { }
    }
    /// <summary>
    /// Исключение команд. Должно выбрасываться при невозможности выполнить одну из операций команды: Execute, Unexecute
    /// </summary>
    public class CommandOperationException : System.InvalidOperationException
    {
        public CommandOperationException(string message) : base(message) { }
        public CommandOperationException(string message, Exception innerException) : base(message, innerException) { }
        public CommandOperationException() : base() { }
    }
}
