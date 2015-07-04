using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace APG.CodeHelper.Actions
{
    /// <summary>
    /// Интерфейс команд
    /// </summary>
    public interface IAction
    {
        /// <summary>
        /// Выполнить команду
        /// </summary>
        /// <param name="sender">Объект, пославший сообщение</param>
        void Execute(object sender);

        /// <summary>
        /// Отменить команду
        /// </summary>
        /// <param name="sender">Объект, пославший сообщение</param>
        void Rollback(object sender);

        /// <summary>
        /// Подсказка для команды
        /// </summary>
        string ActionHint
        {
            get;
        }

        /// <summary>
        /// Проверка может ли выполненная команда быть отменена
        /// </summary>
        bool CanBeRollbacked
        {
            get;
        }
    }

    /// <summary>
    /// Менеджер команд
    /// Определяет методы для управления выполнением и отменой команд
    /// </summary>
    public class ActionManager
    {
        private Stack<IAction> executedActions = new Stack<IAction>();
        private Stack<IAction> rollbackedActions = new Stack<IAction>();

        public event EventHandler OnExecute;
        public event EventHandler OnRollback;

        /// <summary>
        /// Стек выполненных команд
        /// </summary>
        public Stack<IAction> Executed
        {
            get
            {
                return executedActions;
            }
        }

        /// <summary>
        /// Стек отменённых команд
        /// </summary>
        public Stack<IAction> Rollbacked
        {
            get
            {
                return rollbackedActions;
            }
        }

        
        /// <summary>
        /// Создаёт объект заданной команды, 
        /// выполняет команду и помещает объект в стек выполненных команд
        /// </summary>
        /// <param name="sender">Объект, оправивший сообщение</param>
        /// <param name="actionType">Класс команды, экземпляр котрого будет создан</param>
        /// <param name="actionParams">Параметры конструктора. 
        ///  Может быть null для вызова пустого конструктора</param>
        public void Execute(object sender, System.Type actionType, params object[] actionParams)
        {
            IAction action = Activator.CreateInstance(actionType, actionParams) as IAction;
            action.Execute(sender);
            Executed.Push(action);
            OnExecute(this, new EventArgs());
        }

        /// <summary>
        /// Отменяет последнюю команду
        /// </summary>
        /// <param name="sender">Объект, пославший сообщение</param>
        public void Rollback(object sender)
        {
            if (Executed.Count != 0)
            {
                IAction action = Executed.Pop();
                action.Rollback(sender);
                Rollbacked.Push(action);
                OnRollback(this, new EventArgs());
            }
        }

        /// <summary>
        /// Повторяет отменённую команду
        /// </summary>
        /// <param name="sender">Объект, пославший сообщение</param>
        public void Redo(object sender)
        {
            if (Rollbacked.Count != 0)
            {
                IAction action = Rollbacked.Pop();
                action.Execute(sender);
                Executed.Push(action);
                OnExecute(this, new EventArgs());
            }
        }
    }
}
