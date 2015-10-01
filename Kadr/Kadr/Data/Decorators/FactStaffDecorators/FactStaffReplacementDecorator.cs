using Kadr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffReplacementDecorator : FactStaffDecorator
    {
        private FactStaffReplacement factStaffReplacement;
        public FactStaffReplacementDecorator(FactStaffReplacement factStaffReplacement): base(factStaffReplacement.MainFactStaff)
        {
            this.factStaffReplacement = factStaffReplacement;
        }


        public override string ToString()
        {
            string res = "Замещение сотрудника ";

            if (factStaffReplacement.ReplacedFactStaff!=null)
                res = res + factStaffReplacement.ReplacedFactStaff.ToString();
            return res;
        }

        /*[System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tФИО замещающего сотрудника")]
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
        }*/

        [System.ComponentModel.DisplayName("Замещаемый сотрудник")]
        [System.ComponentModel.Category("\t\t\t\t\t\t\t\t\t\t\tОбщие")]
        [System.ComponentModel.Description("Замещаемый сотрудник")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.FactStaff ReplacedFactStaff
        {
            get
            {
                return factStaffReplacement.ReplacedFactStaff;
            }
        }

        /*[System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t% замещения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("% замещения сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal ReplacedPercent
        {
            get
            {
                return factStaffReplacement.ReplacedPercent;
            }
            set
            {
                factStaffReplacement.ReplacedPercent = value;
            }
        }*/

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tПричина замещения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Причина замещения сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<FactStaffReplacementReason>))]
        public Kadr.Data.FactStaffReplacementReason FactStaffReplacementReason
        {
            get
            {
                return factStaffReplacement.FactStaffReplacementReason;
            }
            set
            {
                factStaffReplacement.FactStaffReplacementReason = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания замещения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Дата окончания замещения")]
        [System.ComponentModel.ReadOnly(false)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime ReplacementDataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaffReplacement.DateEnd);
            }
            set
            {
                factStaffReplacement.DateEnd = value;
                if (value == DateTime.MinValue)
                    factStaffReplacement.DateEnd = null;
                if ((factStaffReplacement.DateEnd == null) || (factStaffReplacement.DateEnd>= DateTime.Today))
                    factStaffReplacement.FactStaff1.IsReplacement = true;
                else
                    factStaffReplacement.FactStaff1.IsReplacement = false;
            }
        }

    }
}
