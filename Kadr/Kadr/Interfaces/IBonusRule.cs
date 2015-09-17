using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Interfaces
{
    interface IBonusRule
    {
        int GetPercent(IBonused bonused);
    }
}
