using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using Kadr.Interfaces;

namespace Kadr.Data
{

    internal class MaterialResponsibilityDecorator : IPrikazTypeProvider
    {
        private MaterialResponsibility _material;

        public MaterialResponsibilityDecorator(MaterialResponsibility materialResponsibility)
        {
            _material = materialResponsibility;
        }

        public override string ToString()
        {
            return _material.ToString();
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
                return _material.id;
            }
        }

        [System.ComponentModel.DisplayName("\tПриказ")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ, назначающий мат. ответственность")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(UI.Editors.PrikazEditor), typeof(UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
        {
            get
            {
                return _material.PrikazBegin;
            }
            set
            {
                _material.PrikazBegin = value;
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
                return _material.DateBegin;
            }
            set
            {
                _material.DateBegin = value;
            }
        }



        [System.ComponentModel.DisplayName("Дата окончания")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата окончания мат. ответственности, значащаяся в приказе")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime? DateEnd
        {
            get { return _material.DateEnd; }
            set
            {
                _material.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Сумма выплаты")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Сумма выплаты за мат. ответственность по приказу")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal Sum
        {
            get{
                return _material.SumMoney;
                }
            set
            {
                _material.SumMoney = value;
            }
        }

        [System.ComponentModel.DisplayName("Процент (%) выплаты")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Процент выплаты от оклада за мат. ответственность")]
        [RefreshProperties(RefreshProperties.All)]
        [System.ComponentModel.ReadOnly(false)]
        public decimal? Percent
        {
            get
            {
                return _material.Perc;
            }
            set
            {
                _material.Perc = value;
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
                return _material.ContractName;
            }
            set
            {
                _material.ContractName = value;
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
                return _material.DateContract;
            }
            set
            {
                _material.DateContract = value;
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
                return _material.PrikazEnd;
            }
            set
            {
               _material.PrikazEnd = value;
            }
        }

        internal MaterialResponsibility GetMaterial()
        {
            return _material;
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.ReadOnly(true)]
        public PrikazType PrikazType
        {
            get { return MagicNumberController.MaterialPrikazType; }
        }
    }
}
