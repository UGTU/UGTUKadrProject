using Kadr.Data.Common.BonusRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Interfaces;

namespace Kadr.Data.Common.BonusRules
{
    class YoungLadderStrictNorthBonusRule:SimpleLadderBonusRule
    {
            public YoungLadderStrictNorthBonusRule() : base(TerritoryConditions.StrictNorth, Interfaces.ExpirienceType.WorkingYoung, TimeSpan.FromDays(182), 80, 20, 20) { }

        public override int GetPercent(IBonused bonused)
        {
            int basepercents = base.GetPercent(bonused);
            if ((basepercents == 80) && (bonused.WorkingTime.Days / Period.Days < 4)) return basepercents - IncPercent;
            else return basepercents;
        }
    }
}

