using Kadr.Controllers;
using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class FactStaffDecorator : FactStaffMainBaseDecorator
    {
        public FactStaffDecorator(FactStaff factStaff): base(factStaff)
        {

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


        [System.ComponentModel.DisplayName("Должность в штатном расписании")]
        [System.ComponentModel.Category("\t\t\t\t\tОбщие")]
        [System.ComponentModel.Description("Должность в штатном расписании")]
        [System.ComponentModel.ReadOnly(false)]
        public Kadr.Data.PlanStaff PlanStaff
        {
            get
            {
                return factStaff.PlanStaff;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\tBид работы")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\t\tПриказ утверждения")]
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

        [System.ComponentModel.DisplayName("\t\t\t\tНомер договора")]
        [System.ComponentModel.Category("\t\t\tПараметры договора")]
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
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата договора")]
        [System.ComponentModel.Category("\t\t\tПараметры договора")]
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
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата начала договора")]
        [System.ComponentModel.Category("\t\t\tПараметры договора")]
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
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания договора")]
        [System.ComponentModel.Category("\t\t\tПараметры договора")]
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
                }
            }
        }

    }

}
