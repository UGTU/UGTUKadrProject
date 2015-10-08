using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
using Kadr.Data;


namespace Kadr.Data
{
    public partial class CategoryVPO : INullable
    {
        public override string ToString()
        {
            return CategoryVPOName;
        }


    }

    public class NullCategoryVPO : CategoryVPO, INull
    {

        private NullCategoryVPO()
        {
            this.id = 0;
        }

        public static readonly NullCategoryVPO Instance = new NullCategoryVPO();

        #region INull Members


        public override string ToString()
        {
            return "(Не задана)";
        }

        #endregion
    }
}
