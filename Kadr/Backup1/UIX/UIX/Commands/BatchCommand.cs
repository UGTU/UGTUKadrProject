using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIX.Commands
{
    /// <summary>
    /// Класс пакетных команд
    /// </summary>
    [System.ComponentModel.DisplayName("Пакетная команда")]
    public class BatchCommand : ICommand, IEnumerable<ICommand>, ICollection<ICommand>
    {        
        private IList<ICommand> commands = new List<ICommand>(10);
        private bool isTransacted;        
        private void RollbackFrom(Stack<ICommand> executed, object sender)
        {
            while (executed.Count > 0)
                executed.Pop().Unexecute(sender);
        }

        public BatchCommand()
        {
            isOneWayCommand = false;
        }

        private bool isOneWayCommand;
        public BatchCommand(bool isOneWayCommand)
        {
            this.isOneWayCommand = isOneWayCommand;
        }

        #region ICommand Members
        /// <summary>
        /// Выполнить пакет команд
        /// </summary>
        /// <param name="sender">Источник сообщения</param>
        public void Execute(object sender)
        {
            // Стек для регистрации выполненых команд. Требуется для выполнения отмены в случае исключения 
            // в режиме транзакции
            Stack<ICommand> executed = new Stack<ICommand>(commands.Count);

            foreach (ICommand command in commands)
            {
                try
                {
                    command.Execute(sender);
                    executed.Push(command);
                }
                catch (Exception e)
                {
                    if (IsTransacted)
                        RollbackFrom(executed, sender);
                    throw new BatchTransactionException("Transaction aborted.", e, 
                        BatchTransactionException.BatchStage.Execute);
                }
            }
        }
        
        /// <summary>
        /// Отменить выполнение пакета команд
        /// </summary>
        /// <param name="sender">Источник сообщения</param>
        public void Unexecute(object sender)
        {
            // Стек для регистрации выполненых команд. Требуется для выполнения отмены в случае исключения 
            // в режиме транзакции
            Stack<ICommand> unexecuted = new Stack<ICommand>(commands.Count);
            for (int i = commands.Count - 1; i >= 0; i--)
            {
                try
                {
                    commands[i].Unexecute(sender);
                    unexecuted.Push(commands[i]);
                }
                catch (Exception e)
                {
                    if (IsTransacted)
                        RollbackFrom(unexecuted, sender);
                    throw new BatchTransactionException("Transaction aborted.", e, 
                        BatchTransactionException.BatchStage.Unexecute);
                }
            }
        }
        /// <summary>
        /// Истина, если пакет выполняется (и отменяется) как одна транзакция
        /// </summary>
        [System.ComponentModel.DefaultValue(false)]
        public bool IsTransacted
        {
            get { return isTransacted; }
            set { isTransacted = value; }
        }
        /// <summary>
        /// Количество команд в пакете
        /// </summary>
        public int Count
        {
            get
            {
                return commands.Count;
            }
        }

        #endregion

        #region IEnumerable<ICommand> Members
        /// <summary>
        /// Возвратить перечислитель
        /// </summary>
        /// <returns></returns>
        IEnumerator<ICommand> IEnumerable<ICommand>.GetEnumerator()
        {
            return commands.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        /// <summary>
        /// Возвратить перечислитель
        /// </summary>
        /// <returns></returns>
        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return commands.GetEnumerator();
        }

        #endregion

        #region ICollection<ICommand> Members

        /// <summary>
        /// Очистить пакет команд
        /// </summary>
        public void Clear()
        {
            commands.Clear();
        }

        /// <summary>
        /// Истина, если коллеция содержит команду
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public bool Contains(ICommand item)
        {
            return commands.Contains(item);
        }

        /// <summary>
        /// Копировать коллекцию в массив
        /// </summary>
        /// <param name="array">Массив</param>
        /// <param name="arrayIndex">Начать с индекса</param>
        public void CopyTo(ICommand[] array, int arrayIndex)
        {
            commands.CopyTo(array, arrayIndex);
        }

        /// <summary>
        /// Истина, если коллекция только для чтения
        /// </summary>
        public bool IsReadOnly
        {
            get { return commands.IsReadOnly; }
        }

        /// <summary>
        /// Удалить команду из пакета
        /// </summary>
        /// <param name="item">Команда</param>
        /// <returns>Истина, если команда удалена из пакета</returns>
        public bool Remove(ICommand item)
        {
            return commands.Remove(item);
        }

        /// <summary>
        /// Добавить команду в пакет
        /// </summary>
        /// <param name="item">Команда</param>        
        public void Add(ICommand item)
        {
            commands.Add(item);
        }

        #endregion

        #region ICommand Members


        public bool IsOneWayCommand(object sender)
        {
            return isOneWayCommand;
        }

        #endregion
    }

    /// <summary>
    /// Ошибка в транзакции в пакетной команде
    /// </summary>
    public class BatchTransactionException : Exception
    {
        private BatchStage stage;

        public BatchStage Stage
        {
            get { return stage; }

        }
        public enum BatchStage {Execute, Unexecute}

        public BatchTransactionException(string message, Exception innerException, BatchStage stage)
            :base(message, innerException)
        {
            this.stage = stage;
        }
    }

}
