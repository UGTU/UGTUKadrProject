using Kadr.Data.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class SocialDecorator
    {
        private OK_Social Social;

        public SocialDecorator(OK_Social Social)
        {
            this.Social = Social;
        }

        public override string ToString()
        {
            return Social.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код социальной льготы")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]

        public int Id
        {
            get
            {
                return Social.idSocial;
            }
        }

        [System.ComponentModel.DisplayName("Социальный статус")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Социальный статус льготника")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<OK_SocialStatus>))]

        public OK_SocialStatus Status
        {
            get
            {
                return Social.OK_SocialStatus;
            }
            set
            {
                if (value != null)
                {
                    Social.OK_SocialStatus = value;
                }

            }
        }


        [System.ComponentModel.DisplayName("Дата утверждения")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Дата утверждения социального статуса")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]

        public DateTime? Date
        {
            get
            {
                return Social.EducDocument.DocDate;
            }
            set
            {

                if (value != null)
                {
                    Social.EducDocument.DocDate = value;
                }

            }
        }

        [System.ComponentModel.DisplayName("\t\tСерия документа")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Серия документа, подтверждающего социальный статус")]
        public string Serie
        {
            get
            {
                if (Social.EducDocument != null)
                    return Social.EducDocument.DocSeries;
                else
                    return "";
            }
            set
            {
                if (Social.EducDocument != null)
                    Social.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("\tНомер документа")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Номер документа, подтверждающего социальный статус")]

        public string Number
        {
            get
            {
                if (Social.EducDocument != null)
                    return Social.EducDocument.DocNumber;
                else
                    return "";
            }
            set
            {
                if (Social.EducDocument != null)
                    Social.EducDocument.DocNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Организация")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Организация, утвердившая социальный статус")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<Organisation>))]
        public Organisation Organization
        {
            get
            {
                if (Social.EducDocument != null)
                    return Social.EducDocument.Organisation;
                else
                    return null;
            }
            set
            {
                if (Social.EducDocument != null)
                    Social.EducDocument.Organisation = value;
            }
        }

        internal OK_Social GetSocial()
        {
            return Social;
        }
    }
}
