using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIX.Algorithms
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Item<T>
    {
        T state;
        Item<T> parent;
        /// <summary>
        /// 
        /// </summary>
        public T State
        {
            get { return state; }
        }
        /// <summary>
        /// 
        /// </summary>
        public Item<T> Parent
        {
            get { return parent; }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="state"></param>
        /// <param name="parent"></param>
        public Item(T state, Item<T> parent )
        {
            this.state = state;
            this.parent = parent;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            Item<T> item = (Item<T>)obj;
            if (item != null)
                return item.State.Equals(this.State);
            else
                return false;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.State.GetHashCode();
        }

    }

    internal interface IOpenedStatesCollection<T>
    {
        void Put(T item);
        T Get();
        bool Contains(T item);
        int Count { get; }

    }

    internal class QueueStatesCollection<T> : IOpenedStatesCollection<T>
    {
        private Queue<T> queue = new Queue<T>();

        #region IOpenedStatesCollection<T> Members

        public void Put(T item)
        {
            queue.Enqueue(item);
        }

        public T Get()
        {
            return queue.Dequeue();
        }

        public bool Contains(T item)
        {
            return queue.Contains(item);
        }

        public int Count
        {
            get
            {
                return queue.Count;
            }
        }

        #endregion
    }
    internal class StackStatesCollection<T> : IOpenedStatesCollection<T>
    {

        private Stack<T> stack = new Stack<T>();

        #region IOpenedStatesCollection<T> Members

        public void Put(T item)
        {
            stack.Push(item);
        }

        public T Get()
        {
            return stack.Pop();
        }

        public bool Contains(T item)
        {
            return stack.Contains(item);
        }

        public int Count
        {
            get
            {
                return stack.Count;
            }
        }


        #endregion
    }

    public interface ISearchAlgorithm<T>
    {
        Item<T> GetPath(T initialState, Func<T, bool> testFinalStateFunc, Func<T, IEnumerable<T>> nextStatesFunc);
    }

    internal class SearchBase
    {
        internal static Item<T> GetPath<T>(T initialState, Func<T, bool> testFinalStateFunc, 
            Func<T, IEnumerable<T>> nextStatesFunc, IOpenedStatesCollection<Item<T>> openedStates)
        {
            // Закрытые состояния
            List<Item<T>> closed = new List<Item<T>>();

            //Начальное состояние поместить в открытые
            openedStates.Put(new Item<T>(initialState, null));

            //Пока не просмотрели все состояния            
            while (openedStates.Count > 0)
            {
                // Удалить крайнее открытое состояние
                Item<T> left = openedStates.Get();
                // Если это целевое состояние, то закончить поиск
                if (testFinalStateFunc(left.State))
                    return left;

                // Переместить в список закрытых для исключения циклов
                closed.Add(left);

                // Получить следующие возможные состояния
                IEnumerable<T> nextState = nextStatesFunc(left.State);
                if (nextState != null)
                {
                    // Поместить в очередь открытых, только те, что ещё не были рассмотрены (исключение циклов)
                    foreach (T state in nextState)
                    {
                        Item<T> newItem = new Item<T>(state, left);
                        if (!openedStates.Contains(newItem) && (!closed.Contains(newItem)))
                            openedStates.Put(newItem);
                    }

                }
            }
            // Целевого состояния не найдено
            return null;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class BreadthSearch<T>:ISearchAlgorithm<T>
    {
        #region ISearchAlgorithm<T> Members

        public Item<T> GetPath(T initialState, Func<T, bool> testFinalStateFunc, Func<T, IEnumerable<T>> nextStatesFunc)
        {
            return SearchBase.GetPath(initialState, testFinalStateFunc, nextStatesFunc, new QueueStatesCollection<Item<T>>());
        }

        #endregion
    }
}
