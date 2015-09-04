using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Controllers;

namespace Kadr.Data
{
    class FactStaffHistoryMainBaseDecorator: FactStaffHistoryBaseDecorator
    {
        public FactStaffHistoryMainBaseDecorator(FactStaffHistory factStaffHistory)
            : base(factStaffHistory)
        {
        }

        [System.ComponentModel.DisplayName("Подподкатегория")]
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
        }

        #region ContractData
        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tОсновной договор")]
        [System.ComponentModel.Category("\t\t\tПараметры договора/ доп. соглашения")]
        [System.ComponentModel.Description("Основной договор")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.ContractConvertor))]
        public Contract MainContract
        {
            get
            {
                if (factStaffHistory.Contract != null)
                    return factStaffHistory.Contract.MainContract;
                else
                    return null;
            }
            set
            {
                factStaffHistory.Contract.MainContract = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\tНомер договора/ доп. соглашения")]
        [System.ComponentModel.Category("\t\t\tПараметры договора/ доп. соглашения")]
        [System.ComponentModel.Description("Номер договора/ доп. соглашения")]
        [System.ComponentModel.ReadOnly(false)]
        public string CurrentContractName
        {
            get
            {
                if (factStaffHistory.Contract != null)
                    return factStaffHistory.Contract.ContractName;
                else
                    return null;
            }
            set
            {
                if (value != null)
                {
                    if (factStaffHistory.Contract != null)
                        factStaffHistory.Contract.ContractName = value;
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата договора/ доп. соглашения")]
        [System.ComponentModel.Category("\t\t\tПараметры договора/ доп. соглашения")]
        [System.ComponentModel.Description("Дата составления договора/ доп. соглашения")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateContract
        {
            get
            {
                if (factStaffHistory.Contract != null)
                    return Convert.ToDateTime(factStaffHistory.Contract.DateContract);
                else
                    return DateTime.MinValue;
            }
            set
            {
                if ((value != null) && (value != DateTime.MinValue))
                {
                    if (factStaffHistory.Contract != null)
                        factStaffHistory.Contract.DateContract = value;
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата начала договора/ доп. соглашения")]
        [System.ComponentModel.Category("\t\t\tПараметры договора/ доп. соглашения")]
        [System.ComponentModel.Description("Дата начала действия договора/ доп. соглашения")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime ContractDateBegin
        {
            get
            {
                if (factStaffHistory.Contract != null)
                    return Convert.ToDateTime(factStaffHistory.Contract.DateBegin);
                else
                    return DateTime.MinValue;
            }
            set
            {
                if ((value != null) && (value != DateTime.MinValue))
                {
                    if (factStaffHistory.Contract != null)
                        factStaffHistory.Contract.DateBegin = value;
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания договора/ доп. соглашения")]
        [System.ComponentModel.Category("\t\t\tПараметры договора/ доп. соглашения")]
        [System.ComponentModel.Description("Дата окончания действия договора/ доп. соглашения")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime ContractDateEnd
        {
            get
            {
                if (factStaffHistory.Contract != null)
                    return Convert.ToDateTime(factStaffHistory.Contract.DateEnd);
                else
                    return DateTime.MinValue;
            }
            set
            {
                if ((value != null) && (value != DateTime.MinValue))
                {
                    if (factStaffHistory.Contract != null)
                        factStaffHistory.Contract.DateEnd = value;
                }
            }
        }
        #endregion

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
