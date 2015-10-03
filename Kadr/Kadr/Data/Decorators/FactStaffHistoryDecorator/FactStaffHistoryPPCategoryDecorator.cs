using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHistoryPPCategoryDecorator : FactStaffHistoryMinDecorator
    {
        public FactStaffHistoryPPCategoryDecorator(FactStaffHistory factStaffHistory)
            : base(factStaffHistory)
        {
        }

        [System.ComponentModel.DisplayName("Категория")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Категория ППС")]
        [System.ComponentModel.ReadOnly(false)]
        //[System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SalaryKoeffConvertor))]
        public Kadr.Data.SalaryKoeff SalaryKoeff
        {
            get
            {
                return factStaffHistory.SalaryKoeff;
            }
            set
            {
                factStaffHistory.SalaryKoeff = value;
            }
        }
    }
}
