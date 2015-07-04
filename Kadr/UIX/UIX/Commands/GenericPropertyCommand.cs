using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIX.Commands
{
    /// <summary>
    /// Обобщённая команда изменения свойства
    /// </summary>
    /// <typeparam name="T">Тип объекта</typeparam>
    /// <typeparam name="TValue">Тип свойства</typeparam>
    public class GenericPropertyCommand<T, TValue> : UIX.Commands.ICommand
    {

        T obj;
        TValue newValue;
        TValue oldValue;
        string propertyName;
        object[] index;
        /// <summary>
        /// Создаёт экземпляр класса обобщённой комманды изменения свойства
        /// </summary>
        /// <param name="obj">Объект, свойство которого меняется</param>
        /// <param name="propertyName">Имя свойства</param>
        /// <param name="newValue">Новое значение свойства</param>
        /// <param name="index">Если свойство индексное, то передаётся набор индексов. В противном случае null.</param>
        public GenericPropertyCommand(T obj, string propertyName, TValue newValue, params object[] index)
        {
            this.obj = obj;
            this.propertyName = propertyName;
            this.newValue = newValue;
            this.index = index;
        }

        //public GenericPropertyCommand(T obj, string propertyName, TValue newValue, TValue oldValue, params object[] index)
        //{
        //    this.obj = obj;
        //    this.propertyName = propertyName;
        //    this.newValue = newValue;
        //    this.oldValue = oldValue;
        //    this.index = index;
        //}

        #region ICommand Members
      

        public void Execute(object sender)
        {

            if (obj == null)
                throw new ArgumentNullException("Argument <<obj>> can't be null.");

            System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(propertyName);

            if (pi == null)
                throw new ArgumentException(string.Format("Can't find argument <<{0}>>.", propertyName));


            if (pi.PropertyType == typeof(TValue))
            {
                oldValue = (TValue)pi.GetValue(obj, index);
                pi.SetValue(obj, newValue, index);
            }
            else
                throw new ArgumentException("Type property and value ones mismatch.");

        }

        public void Unexecute(object sender)
        {
            if (obj == null)
                throw new ArgumentNullException("Argument <<obj>> can't be null.");

            System.Reflection.PropertyInfo pi = obj.GetType().GetProperty(propertyName);

            if (pi == null)
                throw new ArgumentException(string.Format("Can't find argument <<{0}>>.", propertyName));

            if (pi.PropertyType == typeof(TValue))
            {
                pi.SetValue(obj, oldValue, index);
            }
            else
                throw new ArgumentException("Type property and value ones mismatch.");
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
