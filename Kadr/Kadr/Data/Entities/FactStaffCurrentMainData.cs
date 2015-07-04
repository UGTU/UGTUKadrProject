using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Controllers;
using System.Data.Linq;

namespace Kadr.Data
{
    public partial class FactStaffCurrentMainData
    {
        public override string ToString()
        {
            return FactStaffFullName;
        }
        
    }
}
