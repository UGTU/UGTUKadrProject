using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class DopEducType : INullable
    {
        public override string ToString()
        {
            return DopEducName;
        }

        public bool IsNull()
        {
            return false;
        }
    }
}
