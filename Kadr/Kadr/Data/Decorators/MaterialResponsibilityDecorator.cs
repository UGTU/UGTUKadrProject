using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

        [System.ComponentModel.DisplayName("Приказ")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ, назначающий мат. ответственность")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz Prikaz
        {
            get
            {
                return materialResponsibility.FactStaffPrikaz.Prikaz;
            }
            set
            {
                if (value != null) materialResponsibility.FactStaffPrikaz.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата начала")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата начала мат. ответственности, значащаяся в приказе")]
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

        public DateTime DateEnd
        {
            get
            {
                return materialResponsibility.FactStaffPrikaz.DateEnd != null ? materialResponsibility.FactStaffPrikaz.DateEnd.Value : new DateTime();
            }
            set
            {
                materialResponsibility.FactStaffPrikaz.DateEnd = value;
                if (value == DateTime.MinValue)
                    materialResponsibility.FactStaffPrikaz.DateEnd = null;
            }
        }

        [System.ComponentModel.DisplayName("Сумма выплаты")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Сумма выплаты за мат. ответственность по приказу")]
        public decimal Sum
        {
            get
            {
                return materialResponsibility.Sum;
            }
            set
            {
                materialResponsibility.Sum = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер договора")]
        [System.ComponentModel.Category("Договор")]
        [System.ComponentModel.Description("Номер договора о мат. ответственности")]
        public string ContractName
        {
            get
            {
                return materialResponsibility.Contract.ContractName;
            }
            set
            {
                materialResponsibility.Contract.ContractName = value;
            }
        }
        [System.ComponentModel.DisplayName("Дата договора")]
        [System.ComponentModel.Category("Договор")]
        [System.ComponentModel.Description("Дата договора о мат. ответственности")]
        public DateTime DateContract
        {
            get
            {
                return materialResponsibility.Contract.DateContract != null ? materialResponsibility.Contract.DateContract.Value : DateTime.MinValue;
            }
            set
            {
                materialResponsibility.Contract.DateContract = value;
            }
        }

        internal MaterialResponsibility GetMaterial()
        {
            return materialResponsibility;
        }
    }
}
