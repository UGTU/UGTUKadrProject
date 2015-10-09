using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
     
    public partial class SalaryKoeff: INullable
    {
        public override string ToString()
        {
            return CategoryPPName + " (" + PKSubSubCategoryNumber.ToString()+")";
        }
    }

    public class NullSalaryKoeff : SalaryKoeff, INull
    {

        private NullSalaryKoeff()
        {
            this.id = 0;
            PKSubSubCategoryNumber = 0;
        }

        public static readonly NullSalaryKoeff Instance = new NullSalaryKoeff();

        public override string ToString()
        {
            return "(Не задана)";
        }

    }
}
