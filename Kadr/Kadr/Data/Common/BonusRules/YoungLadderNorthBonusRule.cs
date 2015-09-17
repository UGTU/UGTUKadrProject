using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common.BonusRules
{
    class YoungLadderNorthBonusRule : SimpleLadderBonusRule
    {
        public YoungLadderNorthBonusRule() : base(TerritoryConditions.North, Interfaces.ExpirienceType.WorkingYoung, TimeSpan.FromDays(30), 50, 10, 10) { }
    }
}
