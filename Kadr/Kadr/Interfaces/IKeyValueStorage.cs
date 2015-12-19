using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Interfaces
{
    public interface IKeyValueStorage
    {
        void Store(object key, object value);

        object GetValue(object key);

    }
}
