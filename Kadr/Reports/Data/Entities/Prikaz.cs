using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Reports
{
    public partial class Prikaz
    {

        public override string ToString()
        {
            return this.PrikazName + " от " + this.DatePrikaz.GetValueOrDefault().ToShortDateString();
        }
    }
}
