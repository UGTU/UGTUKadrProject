using System;
namespace UIX.Commands
{
    /// <summary>
    /// Интерфейс регистраторов команд. Реализация регистратора включает в себя код сохранение команды в списке (стеке) без её выполнения.
    /// </summary>
    public interface ICommandRegister
    {
        /// <summary>
        /// Зарегистрировать команду в списке.
        /// </summary>
        /// <param name="command">Команда</param>
        void RegisterCommand(ICommand command);
    }
}
