using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;
using Kadr.Interfaces;
using System.ComponentModel;

namespace Kadr.Data
{
    [TypeConverter(typeof(PropertySorter))]
    class AwardDecorator
    {
        private Award Award;

        public AwardDecorator(Award Award)
        {
            this.Award = Award;
        }

        public override string ToString()
        {
            return Award.ToString();
        }

        [DisplayName("ID")]
        [Category("Атрибуты")]
        [Description("Уникальный код награды")]
        [ReadOnly(true)]
        [Browsable(false)]

        public int Id
        {
            get
            {
                return Award.ID;
            }
        }

        [DisplayName("Вид награды")]
        [Category("1. Основные")]
        [PropertyOrder(2)]
        [Description("Вид награды, полученной сотрудником")]
        [ReadOnly(false)]
        [TypeConverter(typeof(AwardTypeConverter))]

        public AwardType Type
        {
            get
            {
                return Award.AwardType;
            }
            set
            {
                    Award.AwardType = value;

            }
        }


        [DisplayName("Уровень награды")]
        [Category("1. Основные")]
        [PropertyOrder(3)]
        [Description("Уровень награды, полученной сотрудником")]
        [ReadOnly(false)]
        [TypeConverter(typeof(AwardLevelConverter))]

        public AwardLevel Level
        {
            get
            {
                return Award.AwardLevel;
            }
            set
            {
                    Award.AwardLevel = value;

            }
        }

        [DisplayName("Наименование награды")]
        [PropertyOrder(1)]
        [Category("1. Основные")]
        [Description("Наименование награды, полученной сотрудником")]
        [ReadOnly(false)]

        public string Name
        {
            get
            {
                return Award.Name;
            }
            set
            {
                    Award.Name = value;
            }
        }

        [DisplayName("Дата вручения")]
        [Category("2. Подтверждающий документ")]
        [PropertyOrder(3)]
        [Description("Дата вручения награды")]
        [ReadOnly(false)]
        [EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]

        public DateTime? Date
        {
            get
            {
                return Award.EducDocument.DocDate;
            }
            set
            {

                    Award.EducDocument.DocDate = value;

            }
        }

        [DisplayName("Серия")]
        [PropertyOrder(1)]
        [Category("2. Подтверждающий документ")]
        [Description("Серия документа, подтверждающего факт награждения")]
        [ReadOnly(false)]
        public string Serie
        {
            get
            {
                if (Award.EducDocument != null)
                    return Award.EducDocument.DocSeries;
                else
                    return "";
            }
            set
            {
                if (Award.EducDocument != null)
                    Award.EducDocument.DocSeries = value;
            }
        }

        [DisplayName("Номер")]
        [PropertyOrder(2)]
        [Category("2. Подтверждающий документ")]
        [Description("Номер документа, подтверждающего факт награждения")]
        [ReadOnly(false)]
        public string Number
        {
            get
            {
                if (Award.EducDocument != null)
                    return Award.EducDocument.DocNumber;
                else
                    return "";
            }
            set
            {
                if (Award.EducDocument != null)
                    Award.EducDocument.DocNumber = value;
            }
        }

        [DisplayName("Организация")]
        [Category("3. Дополнительно")]
        [Description("Организация, вручившая награду")]
        [ReadOnly(false)]
        public string Organization
        {
            get
            {
                    return Award.Organization;
            }
            set
            {
                    Award.Organization = value;
            }
        }

        [DisplayName("Ведомство")]
        [Category("3. Дополнительно")]
        [Description("Ведомство, вручившее награду сотруднику")]
        [ReadOnly(false)]
        [TypeConverter(typeof(SimpleToStringConvertor<GovDepartment>))]

        public GovDepartment GDepartment
        {
            get
            {
                return Award.GovDepartment;
            }
            set
            {
                    Award.GovDepartment = value;
            }
        }

        internal Award GetAward()
        {
            return Award;
        }

        public string[] GetOrderProperties(Type T)
        {
            if (T == typeof(AwardType)) return new string[2] { "Name", "ID" };

            return null;
        }
    }
    }

