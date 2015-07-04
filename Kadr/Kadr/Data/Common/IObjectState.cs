using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Windows.Forms;

namespace Kadr.Data.Common
{
    /// <summary>
    /// Состояние объекта - текущий или отмененный (уволенный)
    /// </summary>
    public enum ObjectState { Current = 0, Canceled = 1 };

    interface IObjectState
    {
        ObjectState State();
        //int StateNumber();

    }

    class ObjectStateController
    {
        private static ObjectStateController instance;


        private ObjectStateController()
        {
        }


        /// <summary>
        /// Получает единственный экземпляр контроллера
        /// </summary>
        public static ObjectStateController Instance
        {
            get
            {
                if (instance == null)
                    instance = new ObjectStateController();
                return instance;
            }
        }

        /// <summary>
        /// Возвращает список элементов, которые должны быть включены согласно заданному фильтру
        /// </summary>
        /// <param name="Filter">ФИльтр - элемент меню</param>
        /// <param name="e">Выбранный в данный момент элемент фильтра</param>
        /// <returns></returns>
        public ArrayList GetObjectStatesForFilter(ToolStripSplitButton Filter, ToolStripItemClickedEventArgs e)
        {
            ArrayList FilterObjectStates = new ArrayList();
            for (ObjectState objectState = ObjectState.Current; objectState <= ObjectState.Canceled; objectState++)
            {

                if ((e != null) && (Filter.DropDownItems[(int)objectState] == e.ClickedItem))
                {
                    if (!(Filter.DropDownItems[(int)objectState] as ToolStripMenuItem).Checked)
                        FilterObjectStates.Add(objectState);
                }
                else
                {
                    if ((Filter.DropDownItems[(int)objectState] as ToolStripMenuItem).Checked)
                        FilterObjectStates.Add(objectState);
                }

            }
            return FilterObjectStates;
        }

        /// <summary>
        /// Применяет пререданный отфильтрованный список состояний к компоненту формы 
        /// </summary>
        /// <param name="Filter">Фильтр-компонент формы</param>
        /// <param name="FilterObjectStates">Переданный отфильтрованный список</param>
        public void GetFilterForObjectState(ToolStripSplitButton Filter, ArrayList FilterObjectStates)
        {
            if ((Filter == null) || (FilterObjectStates == null))
                return;
            for (ObjectState objectState = ObjectState.Current; objectState <= ObjectState.Canceled; objectState++)
            {
                (Filter.DropDownItems[(int)objectState] as ToolStripMenuItem).Checked = FilterObjectStates.Contains(objectState);
            }
        }
    }

}
