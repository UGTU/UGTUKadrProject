using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Otpuskvid : INull
    {
        public override string ToString()
        {
            return this.otpuskvidname;
        }

        #region Члены INull

        bool INull.IsNull()
        {
            return false;

        }

        #endregion
    }

    public class NullOK_Otpuskvid : OK_Otpuskvid, INull
    {

        private NullOK_Otpuskvid()
        {
            this.idotpuskvid = 0;
        }

        public static readonly NullOK_Otpuskvid Instance = new NullOK_Otpuskvid();

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

