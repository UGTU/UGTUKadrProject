using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHistoryStaffCountDecorator : FactStaffHistoryMinDecorator
    {
        public FactStaffHistoryStaffCountDecorator(FactStaffHistory factStaffHistory)
            : base(factStaffHistory)
        {
        }

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Kоличество ставок сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal StaffCount
        {
            get
            {
                return factStaffHistory.StaffCount;
            }
            set
            {
                if (value >= 0.1M)
                {
                    factStaffHistory.StaffCount = value;
                }
                else
                    throw new ApplicationException("Количество ставок не может быть меньше 0,1.");
            }
        }

    }
}


