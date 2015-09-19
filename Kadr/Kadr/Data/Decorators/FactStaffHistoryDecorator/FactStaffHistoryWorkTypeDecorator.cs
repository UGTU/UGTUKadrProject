using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Decorators
{
    class FactStaffHistoryWorkTypeDecorator: FactStaffHistoryMainBaseDecorator
    {
        public FactStaffHistoryWorkTypeDecorator(FactStaffHistory factStaffHistory)
            : base(factStaffHistory)
        {

        }
    }
}
