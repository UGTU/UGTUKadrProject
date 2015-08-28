using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class OK_Reason: CompareObject
    {
        public override string ToString()
        {
            return reasonname;
        }
    }
}
