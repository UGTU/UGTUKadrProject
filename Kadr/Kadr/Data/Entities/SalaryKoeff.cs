using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
     
    public partial class SalaryKoeff
    {
        public override string ToString()
        {
            return SalaryKoeffc.ToString() + " (" + PKSubSubCategoryNumber.ToString()+")";
        }
    }
}
