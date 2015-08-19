using Kadr.Data.Converters;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class ValidationDecorator
    {
         private Validation Validation;

        

         public ValidationDecorator(Validation Validation)
        {
            this.Validation = Validation;
        }

        public override string ToString()
        {
            return Validation.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код аттестации")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]

        public int Id
        {
            get
            {
                return Validation.ID;
            }
        }

        [System.ComponentModel.DisplayName("Решение комиссии")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Решение, принятое комиссией в результате аттестации")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<ValidationDecision>))]

        public ValidationDecision Decision
        {
            get
            {
                 return Validation.ValidationDecision;
            }
            set
            {

                    Validation.ValidationDecision = value;
            }
        }

        [System.ComponentModel.DisplayName("Дополнительная информация")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Дополнительная информация, предоставленная комиссией (комментарии, замечания и др.)")]

        public string Commentary
        {
            get
            {
                return Validation.Commentary;
            }
            set
            {

                Validation.Commentary = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\tСерия подтверждающего документа")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Серия документа, подтверждающего факт награждения")]
        public string Serie
        {
            get
            {
                if (Validation.EducDocument != null)
                    return Validation.EducDocument.DocSeries;
                else
                    return Validation.TSerie;
            }
            set
            {
                if (Validation.EducDocument != null)
                    Validation.EducDocument.DocSeries = value;
                else
                    Validation.TSerie = value;
            }
        }

        [System.ComponentModel.DisplayName("\tНомер подтверждающего документа")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Номер документа, подтверждающего факт награждения")]

        public string Number
        {
            get
            {
                if (Validation.EducDocument != null)
                    return Validation.EducDocument.DocNumber;
                else
                    return Validation.TNumber;
            }
            set
            {
                if (Validation.EducDocument != null)
                    Validation.EducDocument.DocNumber = value;
                else
                    Validation.TNumber = value;
            }
        }


        [System.ComponentModel.DisplayName("Дата выдачи подтверждающего документа")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Дата выдачи подтверждающего документа")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]

        public DateTime? DocDate
        {
            get
            {
                if (Validation.EducDocument != null)
                return Validation.EducDocument.DocDate;
                else
                    return Validation.TDocDate;
            }
            set
            {

                if (Validation.EducDocument != null)
                    Validation.EducDocument.DocDate = value;
                else
                    Validation.TDocDate = value;

            }
        }

        [System.ComponentModel.DisplayName("Приказ")]
        [System.ComponentModel.Category("Приказ")]
        [System.ComponentModel.Description("Приказ, назначающий аттестацию")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return Validation.FactStaffPrikaz.Prikaz;
            }
            set
            {
                Validation.FactStaffPrikaz.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата аттестации")]
        [System.ComponentModel.Category("Приказ")]
        [System.ComponentModel.Description("Дата проведения аттестации")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        public DateTime? Date
        {
            get
            {
                return Validation.FactStaffPrikaz.DateBegin;
            }
            set
            {
                    Validation.FactStaffPrikaz.DateBegin = value;

            }
        }

        internal Data.Validation GetValidation()
        {
            return Validation;
        }
    }
}
