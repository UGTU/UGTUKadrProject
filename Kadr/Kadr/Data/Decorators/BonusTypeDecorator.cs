using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class BonusTypeDecorator
    {
        private BonusType bonusType;
        public BonusTypeDecorator(BonusType bonusType)
        {
            this.bonusType = bonusType;
        }

        override public string ToString()
        {
            //return pkCategory.ToString();
            return "Bид надбавки " + BonusTypeName;
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код вида надбавки")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return bonusType.id;
            }
            set
            {
                bonusType.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Единица измерения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Единица измерения надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.BonusMeasureEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public BonusMeasure BonusMeasure
        {
            get
            {
                return bonusType.BonusMeasure;
            }
            set
            {
                bonusType.BonusMeasure = value;
            }
        }

        [System.ComponentModel.DisplayName("Тип надбавки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Тип надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.BonusSuperTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public BonusSuperType BonusSuperType
        {
            get
            {
                return bonusType.BonusSuperType;
            }
            set
            {
                bonusType.BonusSuperType = value;
            }
        }

        [System.ComponentModel.DisplayName("Название вида надбавки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Полное название вида надбавки")]
        public string BonusTypeName
        {
            get
            {
                return bonusType.BonusTypeName;
            }
            set
            {
                bonusType.BonusTypeName = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Источник финансирования, используемый по умолчанию для данного вида надбавки")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<FinancingSource>))]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.AllFinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FinancingSource FinancingSource
        {
            get
            {
                return bonusType.FinancingSource;
            }
            set
            {
                bonusType.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Краткое название")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Краткое название вида надбавки")]
        public string BonusTypeShortName
        {
            get
            {
                return bonusType.BonusTypeShortName;
            }
            set
            {
                bonusType.BonusTypeShortName = value;
            }
        }

        [System.ComponentModel.DisplayName("Начисляются северные")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак, указывающий начисляются ли северный и районный коэффициент для надбавки")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool HasEnvironmentBonus
        {
            get
            {
                return bonusType.HasEnvironmentBonus;
            }
            set
            {
                bonusType.HasEnvironmentBonus = value;
            }
        }

        [System.ComponentModel.DisplayName("Зависит от размера ставки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Признак, указывающий зависит ли размер надбавки от размера ставки")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool IsStaffRateable
        {
            get
            {
                return bonusType.IsStaffRateable;
            }
            set
            {
                bonusType.IsStaffRateable = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены")]
        [System.ComponentModel.Category("Параметры отмены")]
        [System.ComponentModel.Description("Дата отмены вида надбавки")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(bonusType.DateEnd);
            }
            set
            {
                bonusType.DateEnd = value;
            }
        }
    }
}
