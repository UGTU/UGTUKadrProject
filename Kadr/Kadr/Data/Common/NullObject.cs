using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    /// <summary>
    /// Реализация интерфейса INull
    /// </summary>
    class NullObject: INull
    {
        bool INull.IsNull()
        {
            return false;

        }
    }
}
