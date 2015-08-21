using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.UI.Editors;

namespace Kadr.Data
{
    #region Bonus Decorator
    class BonusPlanStaffDecorator
    {
        private Bonus bonus;
        private BonusPlanStaff bonusPlanStaff;

        public BonusPlanStaffDecorator(BonusPlanStaff bonusPlanStaff)
        {
            this.bonusPlanStaff = bonusPlanStaff;
            bonus = bonusPlanStaff.Bonus;
        }

        override public string ToString()
        {
            return "Надбавка";
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код надбавки в системе")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return bonus.id;
            }
            set
            {
                bonus.id = value;
            }
        }


        [System.ComponentModel.DisplayName("Размер надбавки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Последний размер, назначенной сотруднику надбавки")]
        public decimal BonusCount
        {
            get
            {
                return bonus.LastBonusCount;
            }
            set
            {
                bonus.LastBonusCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Последний назначенный источник финансирования надбавки")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<FinancingSource>))]
        public FinancingSource FinancingSource
        {
            get
            {
                return bonus.LastFinancingSource;
            }
            set
            {
                bonus.LastFinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Примечание")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Примечание к надбавке")]
        public string Comment
        {
            get
            {
                return bonus.Comment;
            }
            set
            {
                bonus.Comment = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата начала начисления")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата начала начисления (последнего изменения) надбавки")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(bonus.LastDateBegin);
            }
            set
            {
                bonus.LastDateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата прекращения начисления")]
        [System.ComponentModel.Category("Прекращение начисления")]
        [System.ComponentModel.Description("Дата прекращения начисления надбавки")]
        public DateTime DateEnd
        {
            get
            {
                return Convert.ToDateTime(bonus.DateEnd);
            }
            set
            {
                bonus.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид надбавки")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Вид назначаемой надбавки")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<BonusType>))]
        public BonusType BonusType
        {
            get
            {
                return bonus.BonusType;
            }
            set
            {
                bonus.BonusType = value;
                if (value != null)
                    bonus.LastFinancingSource = value.FinancingSource;
            }
        }

        [System.ComponentModel.DisplayName("Приказ назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения (последнего изменения) надбавки")]
        [System.ComponentModel.Editor(typeof(PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return bonus.LastPrikazBegin;
            }
            set
            {
                bonus.LastPrikazBegin = value;
            }
        }


        [System.ComponentModel.DisplayName("Промежуточный приказ отмены")]
        [System.ComponentModel.Category("Прекращение начисления")]
        [System.ComponentModel.Description("Промежуточный приказ отмены надбавки")]
        [System.ComponentModel.Editor(typeof(PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz IntermediateEndPrikaz
        {
            get
            {
                return bonus.IntermediateEndPrikaz;
            }
            set
            {
                bonus.IntermediateEndPrikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ отмены")]
        [System.ComponentModel.Category("Прекращение начисления")]
        [System.ComponentModel.Description("Приказ отмены надбавки")]
        [System.ComponentModel.Editor(typeof(PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz EndPrikaz
        {
            get
            {
                return bonus.EndPrikaz;
            }
            set
            {
                bonus.EndPrikaz = value;
            }
        }


        [System.ComponentModel.DisplayName("Применяется к вакансиям")]
        [System.ComponentModel.Category("Атрибуты надбавки штатной должности")]
        [System.ComponentModel.Description("Надбавка применяется к вакансиям")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool? ForVacancy
        {
            get
            {
                if (bonus.BonusPlanStaff != null)
                    return bonus.BonusPlanStaff.ForVacancy;
                else
                    return true;
            }
            set
            {
                if (bonus.BonusPlanStaff != null)
                    bonus.BonusPlanStaff.ForVacancy = value.Value;
            }
        }

        [System.ComponentModel.DisplayName("Применяется также к сотрудникам")]
        [System.ComponentModel.Category("Атрибуты надбавки штатной должности")]
        [System.ComponentModel.Description("Надбавка применяется также к сотрудникам")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool? ForEmployee
        {
            get
            {
                if (bonus.BonusPlanStaff != null)
                    return bonus.BonusPlanStaff.ForEmployee;
                else
                    return false;
            }
            set
            {
                if (bonus.BonusPlanStaff != null)
                    bonus.BonusPlanStaff.ForEmployee = value.Value;
            }
        }
    }
    #endregion
}
