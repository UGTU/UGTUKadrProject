using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace Kadr.Data.Decorators
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

        [System.ComponentModel.DisplayName("Наименование награды")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Наименование награды сотрудника")]

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

        [System.ComponentModel.DisplayName("Дата вручения")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Дата вручения награды")]
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

        [System.ComponentModel.DisplayName("Серия")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Серия документа, подтверждающего факт награждения")]
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

        [System.ComponentModel.DisplayName("Номер")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Номер документа, подтверждающего факт награждения")]

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
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Организация, вручившая награду")]

        public Organisation Organization
        {
            get
            {
                if (Award.EducDocument != null)
                    return Award.EducDocument.Organisation;
                else
                    return null;
            }
            set
            {
                if (Award.EducDocument != null)
                    Award.EducDocument.Organisation = value;
            }
        }
       

        internal Award GetAward()
        {
            return Award;
        }
    }
    }

