using Kadr.Controllers;
using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class FactStaffDecorator
    {
        private FactStaff factStaff;
        public FactStaffDecorator(FactStaff factStaff)
        {
            this.factStaff = factStaff;
        }

        public override string ToString()
        {
            return "Распределение штатов отдела " + factStaff.Department.ToString().ToLower() + ", " +
               factStaff.Post.ToString().ToLower();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код сотрудника в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        
        public int ID
        {
            get
            {
                return factStaff.id;
            }
            set
            {
                factStaff.id = value;
            }
        }

        [System.ComponentModel.DisplayName("ФИО сотрудника")]
        [System.ComponentModel.Category("Основные параметры")]
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

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Основные параметры")]
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


        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("Основные параметры")]
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


        [System.ComponentModel.DisplayName("Должность в штатном расписании")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Должность в штатном расписании")]
        [System.ComponentModel.ReadOnly(false)]
        public Kadr.Data.PlanStaff PlanStaff
        {
            get
            {
                return factStaff.PlanStaff;
            }
        }

        [System.ComponentModel.DisplayName("Название вида работы")]
        [System.ComponentModel.Category("Основные параметры")]
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


        /*[System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Источник финансирования (редактировать для почасовиков)")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return factStaff.FinancingSource;
            }
            set
            {
                factStaff.FinancingSource = value;
            }
        }*/

        [System.ComponentModel.DisplayName("ОКВЭД")]
        [System.ComponentModel.Category("Основные параметры")]
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

        [System.ComponentModel.DisplayName("Приказ утверждения")]
        [System.ComponentModel.Category("Основные параметры")]
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

        [System.ComponentModel.DisplayName("Приказ увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Приказ увольнения сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return factStaff.Prikaz;
            }
            set
            {
                factStaff.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения на должность")]
        [System.ComponentModel.ReadOnly(false)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(factStaff.DateBegin);
            }
            set
            {
                factStaff.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Дата увольнения с должности")]
        [System.ComponentModel.ReadOnly(false)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaff.DateEnd);
            }
            set
            {
                factStaff.DateEnd = value;
                //если есть замещения данного сотрудника, то их надо отменить (указать дату окончания)
                /*if ((value != null) )
                {
                    foreach (FactStaffReplacement replacement in FactStaff.FactStaffReplacements)
                    {
                        replacement.DateEnd = value;
                        replacement.FactStaff1.IsReplacement = false;
                    }
                }*/
            }

        }


        [System.ComponentModel.DisplayName("Причина увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Причина увольнения")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<OK_Reason>))]
        public OK_Reason OK_Reason
        {
            get
            {
                return factStaff.OK_Reason;
            }
            set
            {
                factStaff.OK_Reason = value;
            }
        }

        [System.ComponentModel.DisplayName("Центр затрат")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Центр затрат")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(FundingCenterEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FundingCenter FundingCenter
        {
            get
            {
                return factStaff.FundingCenter;
            }
            set
            {
                factStaff.FundingCenter = value;
            }
        }

        /*[System.ComponentModel.DisplayName("Центр затрат")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Центр затрат")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(FundingCenterEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FundingCenter FundingCenter
        {
            get
            {
                return factStaff;
            }
            set
            {
                factStaff.FundingCenter = value;
            }
        }*/

        [System.ComponentModel.DisplayName("Номер договора")]
        [System.ComponentModel.Category("Параметры договора")]
        [System.ComponentModel.Description("Номер договора")]
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
                    else
                    {
                        factStaff.CurrentContract = new Contract(factStaff.CurrentChange, value, DateTime.Today.Date, DateTime.Today.Date, DateTime.Today.AddDays(1).Date);
                        //factStaff.CurrentContract.ContractName = value;
                    }
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата договора")]
        [System.ComponentModel.Category("Параметры договора")]
        [System.ComponentModel.Description("Дата составления договора")]
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
                    else
                    {
                        factStaff.CurrentContract = new Contract(factStaff.CurrentChange, null, value, value, value.AddDays(1).Date);
                        //factStaff.CurrentContract.ContractName = value;
                    }
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата начала договора")]
        [System.ComponentModel.Category("Параметры договора")]
        [System.ComponentModel.Description("Дата начала действия договора")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateBegin
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
                    else
                    {
                        factStaff.CurrentContract = new Contract(factStaff.CurrentChange, null, value, value, value.AddDays(1).Date);
                        //factStaff.CurrentContract.ContractName = value;
                    }
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания договора")]
        [System.ComponentModel.Category("Параметры договора")]
        [System.ComponentModel.Description("Дата окончания действия договора")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateEnd
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
                    else
                    {
                        factStaff.CurrentContract = new Contract(factStaff.CurrentChange, null, value.AddDays(-1), value.AddDays(-1), value);
                        //factStaff.CurrentContract.ContractName = value;
                    }
                }
            }
        }

    }

}
