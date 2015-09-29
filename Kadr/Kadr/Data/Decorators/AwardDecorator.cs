using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;
using Kadr.Interfaces;

namespace Kadr.Data
{
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

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код награды")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]

        public int Id
        {
            get
            {
                return Award.ID;
            }
        }

        [System.ComponentModel.DisplayName("Вид награды")]
        [System.ComponentModel.Category("\tОсновные")]
        [System.ComponentModel.Description("Вид награды, полученной сотрудником")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<AwardType>))]

        public AwardType Type
        {
            get
            {
                return Award.AwardType;
            }
            set
            {
                if (value != null)
                {
                    Award.AwardType = value;
                }

            }
        }


        [System.ComponentModel.DisplayName("Уровень награды")]
        [System.ComponentModel.Category("\tОсновные")]
        [System.ComponentModel.Description("Уровень награды, полученной сотрудником")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<AwardLevel>))]

        public AwardLevel Level
        {
            get
            {
                return Award.AwardLevel;
            }
            set
            {
                if (value != null)
                {
                    Award.AwardLevel = value;
                }

            }
        }

        [System.ComponentModel.DisplayName("\tНаименование награды")]
        [System.ComponentModel.Category("\tОсновные")]
        [System.ComponentModel.Description("Наименование награды, полученной сотрудником")]
        [System.ComponentModel.ReadOnly(false)]

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

        [System.ComponentModel.DisplayName("Дата вручения")]
        [System.ComponentModel.Category("\tПодтверждающий документ")]
        [System.ComponentModel.Description("Дата вручения награды")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]

        public DateTime? Date
        {
            get
            {
                return Award.EducDocument.DocDate;
            }
            set
            {

                if (value != null)
                {
                    Award.EducDocument.DocDate = value;
                }

            }
        }

        [System.ComponentModel.DisplayName("\t\tСерия")]
        [System.ComponentModel.Category("\tПодтверждающий документ")]
        [System.ComponentModel.Description("Серия документа, подтверждающего факт награждения")]
        [System.ComponentModel.ReadOnly(false)]
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

        [System.ComponentModel.DisplayName("\tНомер")]
        [System.ComponentModel.Category("\tПодтверждающий документ")]
        [System.ComponentModel.Description("Номер документа, подтверждающего факт награждения")]
        [System.ComponentModel.ReadOnly(false)]
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

        [System.ComponentModel.DisplayName("Организация")]
        [System.ComponentModel.Category("Дополнительно")]
        [System.ComponentModel.Description("Организация, вручившая награду")]
        [System.ComponentModel.ReadOnly(false)]
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

        [System.ComponentModel.DisplayName("Ведомство")]
        [System.ComponentModel.Category("Дополнительно")]
        [System.ComponentModel.Description("Ведомство, вручившее награду сотруднику")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<GovDepartment>))]

        public GovDepartment GDepartment
        {
            get
            {
                return Award.GovDepartment;
            }
            set
            {
                if (value != null)
                {
                    Award.GovDepartment = value;
                }
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

