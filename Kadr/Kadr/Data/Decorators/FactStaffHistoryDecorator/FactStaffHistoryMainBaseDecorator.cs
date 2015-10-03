using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Controllers;

namespace Kadr.Data
{
    class FactStaffHistoryMainBaseDecorator : FactStaffHistoryMinMainBaseDecorator
    {
        public FactStaffHistoryMainBaseDecorator(FactStaffHistory factStaffHistory)
            : base(factStaffHistory)
        {
        }


        #region RegionTypeData

        [System.ComponentModel.DisplayName("Адрес рабочего места")]
        [System.ComponentModel.Category("Территориальные условия")]
        [System.ComponentModel.Description("Адрес рабочего места сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        public string Address
        {
            get
            {
                return factStaffHistory.Address;
            }
            set
            {
                factStaffHistory.Address = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\tТерриториальные условия сотрудника")]
        [System.ComponentModel.Category("Территориальные условия")]
        [System.ComponentModel.Description("Территориальные условия сотрудника")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.RegionConverter))]
        [System.ComponentModel.ReadOnly(false)]
        public RegionType RegionType
        {
            get
            {
                return factStaffHistory.RegionType;
            }
            set
            {
                factStaffHistory.RegionType = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\tАдрес отдела")]
        [System.ComponentModel.Category("Территориальные условия")]
        [System.ComponentModel.Description("Адрес отдела сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public string DepAddress
        {
            get
            {
                return (factStaffHistory.FactStaff.PlanStaff != null) ? factStaffHistory.FactStaff.PlanStaff.Dep.CurrentAddress : null;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\tТерриториальные условия отдела")]
        [System.ComponentModel.Category("Территориальные условия")]
        [System.ComponentModel.Description("Территориальные условия сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public RegionType DepRegionType
        {
            get
            {
                return (factStaffHistory.FactStaff.PlanStaff != null) ? factStaffHistory.FactStaff.PlanStaff.Dep.CurrentRegionType : null;
            }
        }

        #endregion

    }
}
