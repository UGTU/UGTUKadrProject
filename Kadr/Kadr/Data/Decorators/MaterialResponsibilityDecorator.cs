using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using Kadr.Controllers;

namespace Kadr.Data
{

    internal class MaterialResponsibilityDecorator
    {
        private MaterialResponsibility materialResponsibility;

        public MaterialResponsibilityDecorator(MaterialResponsibility materialResponsibility)
        {
            this.materialResponsibility = materialResponsibility;
        }

        public override string ToString()
        {
            return materialResponsibility.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код материальной ответственности")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]

        public int Id
        {
            get
            {
                return materialResponsibility.id;
            }
        }

        [System.ComponentModel.DisplayName("\tПриказ")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ, назначающий мат. ответственность")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
        {
            get
            {
                return materialResponsibility.PrikazBegin;
            }
            set
            {
                materialResponsibility.PrikazBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\tДата начала")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата начала мат. ответственности, значащаяся в приказе")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateBegin
        {
            get
            {
                return materialResponsibility.FactStaffPrikaz.DateBegin.Value;
            }
            set
            {
                materialResponsibility.FactStaffPrikaz.DateBegin = value;
            }
        }



        [System.ComponentModel.DisplayName("Дата окончания")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата окончания мат. ответственности, значащаяся в приказе")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime? DateEnd
        {
            get { return materialResponsibility.FactStaffPrikaz.DateEnd; }
            set
            {
                materialResponsibility.FactStaffPrikaz.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Сумма выплаты")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Сумма выплаты за мат. ответственность по приказу")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal Sum
        {
            get
            {
                if (Percent != null)
                    materialResponsibility.Sum =
                        Decimal.Round(
                            (decimal)
                                ((Percent/100)*
                                 (Convert.ToDecimal(materialResponsibility.FactStaff.PlanStaff.SalarySize)*
                                  materialResponsibility.FactStaff.LastChange.StaffCount)), 2);
                return materialResponsibility.Sum;
            }
            set
            {
                  materialResponsibility.Sum = value;
            }
        }

        [System.ComponentModel.DisplayName("Процент выплаты")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Процент выплаты от оклада за мат. ответственность")]
        [RefreshProperties(RefreshProperties.All)]
        [System.ComponentModel.ReadOnly(false)]
        public decimal? Percent
        {
            get
            {
                return materialResponsibility.Perc;
            }
            set
            {
                materialResponsibility.Perc = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер договора")]
        [System.ComponentModel.Category("Договор")]
        [System.ComponentModel.Description("Номер договора о мат. ответственности")]
        [System.ComponentModel.ReadOnly(false)]
        public string ContractName
        {
            get
            {
                return materialResponsibility.ContractName;
            }
            set
            {
                materialResponsibility.Contract.ContractName = value;
            }
        }
        [System.ComponentModel.DisplayName("Дата договора")]
        [System.ComponentModel.Category("Договор")]
        [System.ComponentModel.Description("Дата договора о мат. ответственности")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateContract
        {
            get
            {
                return materialResponsibility.DateContract;
            }
            set
            {
                materialResponsibility.DateContract = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ о прекращении мат. ответственности")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ о прекращении мат. ответственности")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return materialResponsibility.FactStaffPrikaz1 == null ? null : materialResponsibility.FactStaffPrikaz1.Prikaz;
            }
            set
            {
                if ((value != null)&&( materialResponsibility.FactStaffPrikaz1 == null))
                {
                         materialResponsibility.FactStaffPrikaz1 = new FactStaffPrikaz()
                         {
                             FactStaff = materialResponsibility.FactStaff
                         }; 
                }
                materialResponsibility.FactStaffPrikaz1.Prikaz = value;
                if (value == null) materialResponsibility.FactStaffPrikaz1 = null;
            }
        }

        internal MaterialResponsibility GetMaterial()
        {
            return materialResponsibility;
        }
    }
}
