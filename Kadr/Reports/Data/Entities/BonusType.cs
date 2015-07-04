using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reports
{
    public partial class BonusType 
    {
        public override string ToString()
        {
            return this.BonusTypeName + " (" + BonusMeasure.Sign + ")";
        }

    }

}
