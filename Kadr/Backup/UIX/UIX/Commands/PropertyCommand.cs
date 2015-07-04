using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIX.Commands
{
    /// <summary>
    /// Команда изменения значения свойства
    /// </summary>
    class PropertyCommand : ICommand
    {
        object obj;
        object newValue;
        object oldValue;
        string propertyName;
        object[] index;
        /// <summary>
        /// Создаёт новую команду для изменения свойства
        /// </summary>
        /// <param name="obj">Объект в котором изменяется значение свойства</param>
        /// <param name="propertyName">Имя свойства</param>
        /// <param name="newValue">Значение свойства</param>
        /// <param name="index">Индексные параметры свойства. Могут быть null для не индексных свойств.</param>
        public PropertyCommand(object obj, string propertyName, object newValue, params object[] index)
        {
            this.obj = obj;
            this.propertyName = propertyName;
            this.newValue = newValue;
            this.index = index;
        }

        /// <summary>
        /// Создаёт новую команду для изменения свойства. Используйте этот конструктор, если значение свойства уже было изменено вне команды
        /// и вы только хотите зарегистрировать это действие.
        /// </summary>
        /// <param name="obj">Объект в котором изменяется значение свойства</param>
        /// <param name="propertyName">Имя свойства</param>
        /// <param name="newValue">Значение свойства</param>
        /// <param name="oldValue">Значение свойства до изменения.</param>
        /// <param name="index">Индексные параметры свойства. Могут быть null для не индексных свойств.</param>
        public PropertyCommand(object obj, string propertyName, object newValue, object oldValue, params object[] index)
        {
            this.obj = obj;
            this.propertyName = propertyName;
            this.newValue = newValue;
            this.oldValue = oldValue;
            this.index = index;
        }

        #region ICommand Members
        /// <summary>
        /// Изменяет значение свойства
        /// </summary>
        /// <param name="sender">Источник команды</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Execute(object sender)
        {
            if (obj == null)
                throw new ArgumentNullException("Argument <<obj>> can't be null.");

            System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(propertyName);

            if (pi == null)
                throw new ArgumentException(string.Format("Can't find argument <<{0}>>.", propertyName));

            oldValue = pi.GetValue(obj, index);
            pi.SetValue(obj, newValue, index);
            
        }

        /// <summary>
        /// Отменяет изменение значения свойства
        /// </summary>
        /// <param name="sender">Источник сообщения</param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void Unexecute(object sender)
        {
            if (obj == null)
                throw new ArgumentNullException("Argument <<obj>> can't be null.");

            System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(propertyName);

            if (pi == null)
                throw new ArgumentException(string.Format("Can't find argument <<{0}>>.", propertyName));

            pi.SetValue(obj, oldValue, index);            
        }

        #endregion

        #region ICommand Members


        public bool IsOneWayCommand(object sender)
        {
            return false;
        }

        #endregion
    }
}
