using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffSubContractDecorator: FactStaffBaseDecorator
    {
        public FactStaffSubContractDecorator(FactStaff factStaff)
            : base(factStaff)
        {
        }
    }
}
