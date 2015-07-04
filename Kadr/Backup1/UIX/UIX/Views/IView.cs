using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UIX.Views
{
    /// <summary>
    /// Интерфейс, описывающий представления
    /// </summary>
    public interface IView
    {        
        /// <summary>
        /// Обновить представление
        /// </summary>
        /// <param name="Sender">Объект, который послал сообщение. Обычно объектом является класс, реализующий <see cref="UIX.Controllers.IController"/> </param>
        void Update(object Sender);
    }
}
