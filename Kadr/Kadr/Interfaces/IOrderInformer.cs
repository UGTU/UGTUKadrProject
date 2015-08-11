using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Interfaces
{
    interface IOrderInformer
    {
        //возвращает для определенного типа массив названий полей, по которому объекты этого типа следует сортировать в данном контексте 
        //сформировано заумно, но реализуется очень просто:
        //
        //class AwardDecorator : IOrderInformer
        //{
        //    ...
        //     public string[] GetOrderProperties(Type T)
        //    {
        //    if (T == typeof(AwardType)) return new string[2] { "Name", "ID" };
        //    return null;
        //    }
        //}
        // теперь при отображении типов наград для декоратора AwardDecorator будет применятся сортировка по Name, а потом по ID 

        string[] GetOrderProperties(Type T);
    }
}
