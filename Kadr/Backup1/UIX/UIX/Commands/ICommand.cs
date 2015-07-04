using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIX.Commands
{
    /// <summary>
    /// Интерфейс команд. Команда рассматривается как единица работы в системе, которая может быть выполнена или отменена.
    /// Этот интерфейс должен реализовать любой класс, требующий регистрации действий в менеджере команд: ICommandManager, ICommandRegister
    /// </summary>
    public interface ICommand
    {        
        /// <summary>
        /// Инициирует выполнение команды
        /// </summary>
        /// <param name="sender">источник сообщения</param>
        /// <exception cref="CommandOperationException"></exception>
        void Execute(object sender);
        /// <summary>
        /// Инициирует отмену команды
        /// </summary>
        /// <param name="sender">Источник сообщения</param>
        /// <exception cref="CommandOperationException"></exception>
        void Unexecute(object sender);
        /// <summary>
        /// Может ли быть эта команда отменена
        /// </summary>
        /// <param name="sender">Источник сообщения</param>
        /// <returns>Истина, если команда может быть отменена для данного источника сообщений</returns>
        /// <exception cref="CommandOperationException"></exception>
        bool IsOneWayCommand(object sender);
    }

    /// <summary>
    /// Команда, выполняющая работу некоторыми порциями. 
    /// </summary>
    public interface IDiscreteCommand : ICommand 
    {
        /// <summary>
        /// Получает общее число шагов команды
        /// </summary>
        int Total { get; }

        /// <summary>
        /// Инициирует отмену выполнения команды
        /// </summary>
        void Cancel();
        
    }
    
}
