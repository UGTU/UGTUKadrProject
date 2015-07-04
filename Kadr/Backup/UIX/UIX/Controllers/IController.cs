using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIX.Controllers
{
    /// <summary>
    /// Интерфейс контроллеров
    /// </summary>
    /// <typeparam name="TModel">Тип модели, которой будет управлять контроллер</typeparam>
    public interface IController<TModel> where TModel : /*System.ComponentModel.INotifyPropertyChanged,*/ new() 
    {
        /// <summary>
        /// Получает модель, управляемую контроллером 
        /// </summary>
        TModel Model { get; set; }
        /// <summary>
        /// Приостанавливает посылку команды обновления заданному представлению
        /// </summary>
        /// <param name="view">Представление</param>
        void SuspendUpdate(Views.IView view);
        /// <summary>
        /// Возобновляет посылку команды обновления заданному представлению
        /// </summary>
        /// <param name="view">Представление</param>
        void ResumeUpdate(Views.IView view);
        /// <summary>
        /// Обновляет все зарегистрированные представления
        /// </summary>
        void UpdateViews();
        /// <summary>
        /// Позволяет подписаться представлению на сообщения об изменении значений свойств от модели
        /// </summary>
        /// <param name="view">Представление</param>
        /// <param name="Properties">Имена свойств изменение значений которых приводит к уведомлению представления</param>
        void Subscribe(Views.IView view, params string[] Properties);
        /// <summary>
        /// Позволяет отписаться от заданных сообщений модели об изменении значений её свойств
        /// </summary>
        /// <param name="view">Представление</param>
        /// <param name="Properties">Имена свойств от изменения значений которых требуется отписаться</param>
        void UnSubscribe(Views.IView view, params string[] Properties);
        /// <summary>
        /// Добавляет представление в контроллер
        /// </summary>
        /// <param name="view">Представление</param>
        void AddView(Views.IView view);
        /// <summary>
        /// Удаляет представление из контроллера
        /// </summary>
        /// <param name="view">Представление</param>
        void RemoveView(Views.IView view);

        /// <summary>
        /// Событие возникает при изменениях в списке представлений контроллера и обновлении представления
        /// </summary>
        event EventHandler<ViewsChangedArgs> ViewsChanged;
    }

    /// <summary>
    /// Класс описывает аргументы события ViewChanged
    /// </summary>
    public class ViewsChangedArgs:EventArgs
    {
        /// <summary>
        /// Действия над представлениями
        /// </summary>
        public enum ViewAction 
        { 
            /// <summary>
            /// Указывает, что в контроллер было добавлено новое представление
            /// </summary>
            Added, 
            /// <summary>
            /// Указывает, что представление будет отсоеденино от контроллера 
            /// </summary>
            Removing, 
            /// <summary>
            /// Указывает, что представлению было послано событие обновления
            /// </summary>
            Updating,
            /// <summary>
            /// Указывает, что представление было обновлено контроллером
            /// </summary>
            Updated
        }
                
        /// <summary>
        /// Создаёт новый экземпляр ViewChangedArgs
        /// </summary>
        /// <param name="view">Представление</param>
        /// <param name="viewAction">Действие</param>
        public ViewsChangedArgs(Views.IView view, ViewAction viewAction)
        {
            this.view = view;
            this.viewAction = viewAction;
        }
        /// <summary>
        /// Представление
        /// </summary>
        public Views.IView ChangedView
        {
            get
            {
                return view;
            }
        }
        /// <summary>
        /// Показывает какое действие было совершено над представлением
        /// </summary>
        public ViewAction PerfomedAction
        {
            get
            {
                return viewAction;
            }
        }

        #region Private Fields
        private Views.IView view;
        private ViewAction viewAction;
        #endregion

    }
}
