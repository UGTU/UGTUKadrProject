using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    public partial class MilitaryFitness
    {
        public override string ToString()
        {
            return String.Format("{0} ({1})", Letter, Description);
        }
    }
}
