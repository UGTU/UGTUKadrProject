using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class PostType : INull
    {
        public override string ToString()
        {
            return PostTypeName;
        }

        bool INull.IsNull()
        {
            return false;
        }
    }

    public class NullPostType : PostType, INull
    {

        private NullPostType()
        {
            this.id = 0;
        }

        public static readonly NullPostType Instance = new NullPostType();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не задан)";
        }

        #endregion
    }
}
