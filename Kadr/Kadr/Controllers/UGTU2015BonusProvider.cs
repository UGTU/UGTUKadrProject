using Kadr.Data.Common.BonusRules;
using Kadr.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Controllers
{
    class UGTU2015BonusProvider:BonusProvider
    {
        public UGTU2015BonusProvider()
        {
            List<IBonusRule> rules = new List<IBonusRule>();

            rules.Add(new YoungLadderNorthBonusRule());
            rules.Add(new YoungLadderStrictNorthBonusRule());

            //надо сделать правила
            //rules.Add(new LadderNorthBonusRule());
            //rules.Add(new LadderStrictNorthBonusRule());

            Rules = rules;
        }
    }
}
