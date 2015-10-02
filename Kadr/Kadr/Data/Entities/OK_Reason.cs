using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Reason: CompareObject, INull
    {
        public override string ToString()
        {
            return reasonname;
        }

        #region INull Members

        bool INull.IsNull()
        {
            return false;
        }

        #endregion
    }

    public class NullOK_Reason : OK_Reason, INull
    {

        private NullOK_Reason()
        {
            this.idreason = 0;
        }

        public static readonly NullOK_Reason Instance = new NullOK_Reason();

        #region INull Members

        bool INull.IsNull()
        {
            return true;
        }

        public override string ToString()
        {
            return "(Не заданa)";
        }

        #endregion
    }

}
