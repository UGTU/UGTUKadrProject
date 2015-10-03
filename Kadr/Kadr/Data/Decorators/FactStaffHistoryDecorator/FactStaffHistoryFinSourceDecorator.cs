using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHistoryFinSourceDecorator : FactStaffHistoryMinMainBaseDecorator
    {
        public FactStaffHistoryFinSourceDecorator(FactStaffHistory factStaffHistory)
            : base(factStaffHistory)
        {

        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\tИсточник финансирования")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Источник финансирования сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.FinancingSourceConvertor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return factStaffHistory.FinancingSource;
            }
            set
            {
                factStaffHistory.FinancingSource = value;
            }
        }

    }
}
