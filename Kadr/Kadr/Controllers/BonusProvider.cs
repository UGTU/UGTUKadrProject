using Kadr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Controllers
{
    abstract class BonusProvider
    {
        protected IEnumerable<IBonusRule> Rules;

        public int GetBonusPercentage(IEnumerable<IBonused> bonused)
        {
            int percents = 0;
            int cur;

            foreach (IBonused b in bonused)
                foreach (IBonusRule r in Rules)
                {
                    cur = r.GetPercent(b);
                    if (percents < cur) percents = cur;
                }
            return percents;
        }
    }
}
