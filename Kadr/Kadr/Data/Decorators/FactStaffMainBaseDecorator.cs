using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffMainBaseDecorator: FactStaffBaseDecorator
    {
        public FactStaffMainBaseDecorator(FactStaff factStaff)
            : base(factStaff)
        {
        }

    }
}
