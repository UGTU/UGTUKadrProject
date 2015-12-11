using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Reason: CompareObject, INullable
    {
        public static int NotFired = 253;

        public override string ToString()
        {
            return reasonname;
        }


        partial void OnCreated()
        {
            isUvoln = true;

        }

    }

    public class NullOK_Reason : OK_Reason, INull
    {

        private NullOK_Reason()
        {
            this.idreason = 0;
        }

        public static readonly NullOK_Reason Instance = new NullOK_Reason();


        public override string ToString()
        {
            return "(Не заданa)";
        }

    }

}
