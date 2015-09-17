using Kadr.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common.BonusRules
{
    class SimpleLadderBonusRule : IBonusRule
    {
        protected TerritoryConditions Territory;
        protected ExpirienceType ExpType;
        protected TimeSpan Period;
        protected int TopPercent;
        protected int IncPercent;
        protected int InitialPercent;

        public  SimpleLadderBonusRule(TerritoryConditions terr, ExpirienceType exptype, TimeSpan period, int toppercent, int incpercent, int initpercent)
        {
            Territory = terr;
            ExpType = exptype;
            Period = period;
            TopPercent = toppercent;
            InitialPercent = initpercent;
            IncPercent = incpercent;  
        }

        public virtual int GetPercent(IBonused bonused)
        {
            int percent = InitialPercent;
            TimeSpan time = bonused.WorkingTime;

            if ((ExpType == bonused.TypeOfWork) && (Territory == bonused.Territory))
                while (((time -= Period) > TimeSpan.FromDays(0))&&(percent<=TopPercent)) percent += IncPercent;
            return percent;
        }
    }
}
