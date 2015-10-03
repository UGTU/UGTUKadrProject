using Kadr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHistoryReplacementDecorator: FactStaffHistoryMainBaseDecorator
    {

        public FactStaffHistoryReplacementDecorator(FactStaffHistory factStaffHistory): base(factStaffHistory)
        {
        }

 
        
        [System.ComponentModel.DisplayName("ФИО замещаемого сотрудника")]
        [System.ComponentModel.Category("\t\t\t\t\t\t\t\t\t\t\tОбщие")]
        [System.ComponentModel.Description("ФИО совмещаемого сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Employee ReplacedEmployee
        {
            get
            {
                return factStaffHistory.FactStaff.FactStaffReplacement.ReplacedFactStaff.Employee;
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.ReplacedFactStaff.Employee = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t% замещения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("% замещения сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal StaffCount
        {
            get
            {
                return factStaffHistory.FactStaff.FactStaffReplacement.ReplacedPercent;
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.ReplacedPercent = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tПричина замещения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Причина замещения сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<FactStaffReplacementReason>))]
        public Kadr.Data.FactStaffReplacementReason FactStaffReplacementReason
        {
            get
            {
                return factStaffHistory.FactStaff.FactStaffReplacement.FactStaffReplacementReason;
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.FactStaffReplacementReason = value;
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
                return Convert.ToDateTime(factStaffHistory.FactStaff.FactStaffReplacement.DateEnd);
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.DateEnd = value;
                if (value == DateTime.MinValue)
                    factStaffHistory.FactStaff.FactStaffReplacement.DateEnd = null;
                if (factStaffHistory.FactStaff.FactStaffReplacement.DateEnd == null)
                    factStaffHistory.FactStaff.FactStaffReplacement.FactStaff1.IsReplacement = true;
                else
                    factStaffHistory.FactStaff.FactStaffReplacement.FactStaff1.IsReplacement = false;
            }
        }

    }
}
