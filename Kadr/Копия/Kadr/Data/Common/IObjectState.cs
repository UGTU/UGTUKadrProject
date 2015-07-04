using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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
}
