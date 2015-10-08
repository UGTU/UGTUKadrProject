﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Reason: CompareObject, INullable
    {
        public override string ToString()
        {
            return reasonname;
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
