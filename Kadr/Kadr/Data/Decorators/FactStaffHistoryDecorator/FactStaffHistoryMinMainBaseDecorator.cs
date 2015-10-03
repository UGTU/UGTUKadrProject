using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHistoryMinMainBaseDecorator : FactStaffHistoryBaseDecorator
    {
        public FactStaffHistoryMinMainBaseDecorator(FactStaffHistory factStaffHistory)
            : base(factStaffHistory)
        {
        }

        [System.ComponentModel.DisplayName("Должность в штатном расписании")]
        [System.ComponentModel.Category("\t\t\t\t\t\t\t\t\t\t\tОбщие")]
        [System.ComponentModel.Description("Должность в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
        public Kadr.Data.FactStaff FactStaff
        {
            get
            {
                return factStaffHistory.FactStaff;
            }
        }

        [System.ComponentModel.DisplayName("Должность в штатном расписании")]
        [System.ComponentModel.Category("\t\t\t\t\t\t\t\t\t\t\tОбщие")]
        [System.ComponentModel.Description("Должность в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.PlanStaff PlanStaff
        {
            get
            {
                return factStaffHistory.FactStaff.PlanStaff;
            }
        }

        /*[System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        [System.ComponentModel.ReadOnly(false)]
        public int? SalaryKoeff
        {
            get
            {
                if (factStaffHistory.SalaryKoeff != null)
                    return factStaffHistory.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                factStaffHistory.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }*/

        

    }
}
