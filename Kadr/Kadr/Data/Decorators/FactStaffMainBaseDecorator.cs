using Kadr.Controllers;
using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class FactStaffMainBaseDecorator: FactStaffBaseDecorator
    {
        public FactStaffMainBaseDecorator(FactStaff factStaff)
            : base(factStaff)
        {

        }


        [System.ComponentModel.DisplayName("Должность в штатном расписании")]
        [System.ComponentModel.Category("\t\t\t\t\t\t\t\t\t\t\tОбщие")]
        [System.ComponentModel.Description("Должность в штатном расписании")]
        [System.ComponentModel.ReadOnly(false)]
        public Kadr.Data.PlanStaff PlanStaff
        {
            get
            {
                return factStaff.PlanStaff;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tФИО сотрудника")]
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

        [System.ComponentModel.DisplayName("ОКВЭД")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Код экономической деятельности")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.OKVEDConvertor))]
        public OKVED OKVED
        {
            get
            {
                return factStaff.OKVED;
            }
            set
            {
                factStaff.OKVED = value;
            }
        }

        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        [System.ComponentModel.ReadOnly(false)]
        public int? SalaryKoeff
        {
            get
            {
                if (factStaff.SalaryKoeff != null)
                    return factStaff.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                factStaff.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }


        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\tBид работы")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Название вида работы")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<WorkType>))]
        public Kadr.Data.WorkType WorkType
        {
            get
            {
                return factStaff.WorkType;
            }
            set
            {
                factStaff.WorkType = value;
            }
        }


        [System.ComponentModel.DisplayName("\t\t\t\t\t\tПриказ назначения")]
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

 
        #region ContractData
        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tОсновной договор")]
        [System.ComponentModel.Category("\t\t\tПараметры договора/ доп. соглашения")]
        [System.ComponentModel.Description("Основной договор")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
        public Contract CurrentContract
        {
            get
            {
                return factStaff.CurrentContract;
            }
            set
            {
                factStaff.CurrentContract = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tОсновной договор")]
        [System.ComponentModel.Category("\t\t\tПараметры договора/ доп. соглашения")]
        [System.ComponentModel.Description("Основной договор")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.ContractConvertor))]
        public Contract MainContract
        {
            get
            {
                return factStaff.MainContract;
            }
            set
            {
                factStaff.MainContract = value;
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
                if (factStaff.CurrentContract != null)
                    return factStaff.CurrentContract.ContractName;
                else
                    return null;
            }
            set
            {
                if (value != null)
                {
                    if (factStaff.CurrentContract != null)
                        factStaff.CurrentContract.ContractName = value;
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
                if (factStaff.CurrentContract != null)
                    return Convert.ToDateTime(factStaff.CurrentContract.DateContract);
                else
                    return DateTime.MinValue;
            }
            set
            {
                if ((value != null) && (value != DateTime.MinValue))
                {
                    if (factStaff.CurrentContract != null)
                        factStaff.CurrentContract.DateContract = value;
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
                if (factStaff.CurrentContract != null)
                    return Convert.ToDateTime(factStaff.CurrentContract.DateBegin);
                else
                    return DateTime.MinValue;
            }
            set
            {
                if ((value != null) && (value != DateTime.MinValue))
                {
                    if (factStaff.CurrentContract != null)
                        factStaff.CurrentContract.DateBegin = value;
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
                if (factStaff.CurrentContract != null)
                    return Convert.ToDateTime(factStaff.CurrentContract.DateEnd);
                else
                    return DateTime.MinValue;
            }
            set
            {
                if ((value != null) && (value != DateTime.MinValue))
                {
                    if (factStaff.CurrentContract != null)
                        factStaff.CurrentContract.DateEnd = value;
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
                return factStaff.CurrentChange.Address;
            }
            set
            {
                factStaff.CurrentChange.Address = value;
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
                return factStaff.CurrentChange.RegionType;
            }
            set
            {
                factStaff.CurrentChange.RegionType = value;
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
                return (factStaff.PlanStaff != null) ? factStaff.PlanStaff.Dep.CurrentAddress : null;
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
                return (factStaff.PlanStaff != null) ? factStaff.PlanStaff.Dep.CurrentRegionType : null;
            }
        }

        #endregion
    }
}
