using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace UIX.Controllers
{
    /// <summary>
    /// Базовая реализация IController
    /// </summary>
    /// <typeparam name="TModel">Тип модели, управляемой контроллером</typeparam>
    public class GenericController<TModel> : 
        IEnumerable<Views.IView>,
        IController<TModel> where TModel : /*System.ComponentModel.INotifyPropertyChanged, */ new()
     
    {
        /// <summary>
        /// Определяет операции, которые необходимо выполнить после создания экземпляра модели
        /// </summary>
        protected virtual void OnModelCreated()
        {
            //PropertyChangedEventArgs arg = new PropertyChangedEventArgs("Model");
            //model_PropertyChanged(this, arg);
            UpdateViews();

        }

        #region SuspendedList class
        private class SuspendedViews : IEnumerable<KeyValuePair<Views.IView, int>>
        {
            IDictionary<Views.IView, int> suspendedViews = new Dictionary<Views.IView, int>();
            public void Suspend(Views.IView view)
            {
                if (suspendedViews.ContainsKey(view))
                    ++suspendedViews[view];
                else
                    suspendedViews[view] = 1;

            }

            public void Resume(Views.IView view)
            {
                if (suspendedViews.ContainsKey(view))
                {
                    if (--suspendedViews[view] == 0)
                        suspendedViews.Remove(view);

                }
            }

            public bool IsSuspended(Views.IView view)
            {
                return suspendedViews.ContainsKey(view);
            }





            #region IEnumerable<KeyValuePair<IView,int>> Members

            public IEnumerator<KeyValuePair<UIX.Views.IView, int>> GetEnumerator()
            {
                return suspendedViews.GetEnumerator();
            }

            #endregion

            #region IEnumerable Members

            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return suspendedViews.GetEnumerator();
            }

            #endregion
        }
        #endregion

        #region Private Fields
        private IList<Views.IView> views;
        private IList<Views.IView> Views
        {
            get
            {
                if (views == null)
                    views = new List<Views.IView>(5);
                return views;

            }
        }
        private TModel model = default(TModel);
        private SuspendedViews suspendedViews;
        private SuspendedViews Suspended
        {
            get
            {
                if (suspendedViews == null)
                    suspendedViews = new GenericController<TModel>.SuspendedViews();
                return suspendedViews;
            }
        }
        private IDictionary<Views.IView, HashSet<string>> subscribers;
        private IDictionary<Views.IView, HashSet<string>> Subscribers
        {
            get
            {
                if (subscribers == null)
                    subscribers = new Dictionary<Views.IView, HashSet<string>>();
                return subscribers;
            }
        }
        
        #endregion

        #region Private Methods

        private void UpdateViewsOnPropertyChanged(string propertyName)
        {
            foreach (Views.IView view in Views)
            {
                if (!Suspended.IsSuspended(view))
                {
                    if ((Subscribers.ContainsKey(view)) && (Subscribers[view].Contains(propertyName)))
                    {
                        UpdateViewInternal(view);
                    }
                }

            }
        }

        void model_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            UpdateViewsOnPropertyChanged(e.PropertyName);
        }

        private void FireOnViewChanged(Views.IView view, ViewsChangedArgs.ViewAction action)
        {
            OnViewChanged(this, new ViewsChangedArgs(view, action));
        }

        private void UpdateViewInternal(Views.IView view)
        {
            FireOnViewChanged(view, ViewsChangedArgs.ViewAction.Updating);

            view.Update(this);

            FireOnViewChanged(view, ViewsChangedArgs.ViewAction.Updated);
        }

        private void RemoveViewFromSubscribers(UIX.Views.IView view)
        {
            if (Subscribers.ContainsKey(view))
            {
                Subscribers.Remove(view);
            }
        }

        private void RemoveViewFromSuspended(UIX.Views.IView view)
        {
            while (Suspended.IsSuspended(view))
                Suspended.Resume(view);
        }


        #endregion
        #region Public properties and methods
        public int ViewsCount
        {
            get
            {
                return Views.Count;
            }
        }

        #endregion

        #region IController<TModel> Members

        public TModel Model
        {
            get
            {
                if (model == null)
                {
                    model = new TModel();
                    SubscribeNotifyPropertyChanged();
                    OnModelCreated();
                }
                return model;
            }
            set
            {
                UnsubscribeNotifyPropertyChanged();
                model = value;
                SubscribeNotifyPropertyChanged();
            }

        }

        //public TModel CreateNewModel()
        //{
        //       // model.
        //}

        private System.ComponentModel.PropertyChangedEventHandler propertyChangedHandler;
            

        private void UnsubscribeNotifyPropertyChanged()
        {
            if (model is System.ComponentModel.INotifyPropertyChanged)
            {
                if (propertyChangedHandler != null)
                    (model as System.ComponentModel.INotifyPropertyChanged).PropertyChanged -= propertyChangedHandler;
                    
            }
        }

        private void SubscribeNotifyPropertyChanged()
        {           
            if (model is System.ComponentModel.INotifyPropertyChanged)
            {
                if (propertyChangedHandler == null)
                    propertyChangedHandler = new System.ComponentModel.PropertyChangedEventHandler(model_PropertyChanged);
                (model as System.ComponentModel.INotifyPropertyChanged).PropertyChanged += propertyChangedHandler;
            }
        }

        public void SuspendUpdate(UIX.Views.IView view)
        {
            Suspended.Suspend(view);
        }

        public void ResumeUpdate(UIX.Views.IView view)
        {
            Suspended.Resume(view);
        }

        public void UpdateViews()
        {
            foreach (Views.IView view in this)
            {
                if (!Suspended.IsSuspended(view))
                {
                    UpdateViewInternal(view);

                }
            }
        }
        
        public void Subscribe(Views.IView view, params string[] Properties)
        {
            if (!Views.Contains(view))
                throw new ArgumentException("You must add this view under the controller first, using AddView(Views.IView) method.");

            if (!Subscribers.ContainsKey(view))
            {
                Subscribers.Add(new KeyValuePair<UIX.Views.IView, HashSet<string>>(view, new HashSet<string>()));
            }

            Subscribers[view].UnionWith(Properties);
        }



        public void UnSubscribe(Views.IView view, params string[] Properties)
        {
            if (Subscribers.ContainsKey(view))
            {
                Subscribers[view].ExceptWith(Properties);
            }
            else
                throw new ArgumentException("You must subscribe this view first, using Subscribe(Views.IView, params string[] Properties) method.");

        }

        /// <summary>
        /// Реализация IController<typeparamref name="Model"/>.AddView(IView view)
        /// </summary>
        /// <param name="view"></param>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="ArgumentException"></exception>
        public void AddView(Views.IView view)
        {
            if (view == null)
                throw new ArgumentNullException("view", "\"view\" can't be <<null>>.");

            if (Views.Contains(view))
                throw new ArgumentException("The view you've specified in the argument is under controller already.");


            Views.Add(view);
            FireOnViewChanged(view, ViewsChangedArgs.ViewAction.Added);

            UpdateViewInternal(view);
        }
        public void RemoveView(Views.IView view)
        {
            if (view == null)
                throw new ArgumentNullException("view", "\"view\" can't be <<null>>.");

            if (!Views.Contains(view))
                throw new ArgumentException("You must add this view under the controller first, using AddView(Views.IView) method.");

            FireOnViewChanged(view, ViewsChangedArgs.ViewAction.Removing);

            RemoveViewFromSuspended(view);
            RemoveViewFromSubscribers(view);
            
            
            Views.Remove(view);

            
        }        
        public event EventHandler<ViewsChangedArgs> ViewsChanged;

        #endregion       

        #region Protected Methods
        protected virtual void OnViewChanged(object sender, ViewsChangedArgs e)
        {
            if (ViewsChanged != null)
            {
                ViewsChanged(sender, e);
            }
        }
        #endregion


        #region IEnumerable<IView> Members

        public IEnumerator<UIX.Views.IView> GetEnumerator()
        {
            return Views.GetEnumerator();
        }

        #endregion

        #region IEnumerable Members

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return Views.GetEnumerator();
        }

        #endregion

        #region Debug Helpers
#if DEBUG
        public bool IsSuspended(Views.IView view)
        {
            return Suspended.IsSuspended(view);
        }
        public bool IsSubscribed(Views.IView view)
        {
            return Subscribers.ContainsKey(view);
        }
#endif

        #endregion
    }

    
}
