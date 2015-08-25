using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;

namespace Kadr.Data
{
    public partial class DopEducType : INull
    {
        public override string ToString()
        {
            return DopEducName + (Duration != "" ? " (" + Duration + " часов)" : "");
        }

        public bool IsNull()
        {
            return false;
        }
    }
}
