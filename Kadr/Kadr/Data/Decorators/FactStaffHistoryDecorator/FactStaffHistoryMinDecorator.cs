using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    /// <summary>
    /// декоратор с минимальными данными для редактирования
    /// </summary>
    class FactStaffHistoryMinDecorator : FactStaffHistoryMinMainBaseDecorator
    {
        public FactStaffHistoryMinDecorator(FactStaffHistory factStaffHistory)
            : base(factStaffHistory)
        {
        }

        
    }
}
