using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;
using UIX.Views;

namespace Kadr.Data
{
    public partial class PostGroup : INull
    {
        public override string ToString()
        {
            return GroupName;
        }

        #region INull Members

        bool INull.IsNull()
        {
            return false;
        }

        #endregion
    }


    public class NullPostGroup : PostGroup, INull
    {

        private NullPostGroup()
        {
            this.id = 0;
        }

        public static readonly NullPostGroup Instance = new NullPostGroup();

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
