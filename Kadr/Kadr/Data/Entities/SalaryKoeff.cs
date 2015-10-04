using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
     
    public partial class SalaryKoeff: INull
    {
        public override string ToString()
        {
            return CategoryPPName + " (" + PKSubSubCategoryNumber.ToString()+")";
        }

        #region Члены INull

        bool INull.IsNull()
        {
            return false;
        }

        #endregion
    }

    public class NullSalaryKoeff : SalaryKoeff, INull
    {

        private NullSalaryKoeff()
        {
            this.id = 0;
            PKSubSubCategoryNumber = 0;
        }

        public static readonly NullSalaryKoeff Instance = new NullSalaryKoeff();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не задана)";
        }

        #endregion
    }
}
