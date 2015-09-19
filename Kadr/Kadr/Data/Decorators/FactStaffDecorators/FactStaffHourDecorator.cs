using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHourDecorator: FactStaffHourBaseDecorator
    {
        public FactStaffHourDecorator(FactStaff factStaff)
            : base(factStaff)
        {
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\tФИО сотрудника")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("ФИО сотрудника, назначенного на должность")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.EmployeeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Employee Employee
        {
            get
            {
                return factStaff.Employee;
            }
            set
            {
                factStaff.Employee = value;
            }
        }


        [System.ComponentModel.DisplayName("Приказ утверждения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Приказ назначения сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
        {
            get
            {
                return factStaff.PrikazBegin;
            }
            set
            {
                factStaff.PrikazBegin = value;
            }
        }


    }

}
