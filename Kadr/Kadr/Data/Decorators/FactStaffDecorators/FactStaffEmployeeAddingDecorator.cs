﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffEmployeeAddingDecorator: FactStaffMainBaseDecorator
    {
        public FactStaffEmployeeAddingDecorator(FactStaff factStaff)
            : base(factStaff)
        {

        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tФИО сотрудника")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("ФИО сотрудника, назначенного на должность")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Employee Employee
        {
            get
            {
                return factStaff.Employee;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\tКоличество ставок")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Занимаемое сотрудником по факту количество ставок")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal StaffCount
        {
            get
            {
                return factStaff.StaffCount;
            }
            set
            {
                factStaff.StaffCount = value;
            }
        }

    }
}
