using Kadr.Controllers;
using Kadr.Data.Converters;
using Kadr.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class ValidationDecorator : IPrikazTypeProvider
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

        [System.ComponentModel.DisplayName("\tРешение комиссии")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Решение, принятое комиссией в результате аттестации")]
        [System.ComponentModel.ReadOnly(false)]
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
        [System.ComponentModel.ReadOnly(false)]
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

        [System.ComponentModel.DisplayName("\t\t\tВид подтверждающего документа")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Вид документа, подтверждающего прохождение аттестации")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(DocumentTypeToStringConvertor))]
        public EducDocumentType DocType
        {
            get
            {
                if (Validation.EducDocument != null)
                    return Validation.EducDocument.EducDocumentType;
                else
                    return null;
            }
            set
            {
                if (Validation.EducDocument != null)
                    Validation.EducDocument.EducDocumentType = value;
                
            }
        }

        [System.ComponentModel.DisplayName("\t\t\tСерия подтверждающего документа")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Серия документа, подтверждающего прохождение аттестации")]
        [System.ComponentModel.ReadOnly(false)]
        public string Serie
        {
            get
            {
                if (Validation.EducDocument != null)
                    return Validation.EducDocument.DocSeries;
                else
                    return "";
            }
            set
            {
                if (Validation.EducDocument != null)
                    Validation.EducDocument.DocSeries = value;
                else
                    Validation.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\tНомер подтверждающего документа")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Номер документа, подтверждающего прохождение аттестации")]
        [System.ComponentModel.ReadOnly(false)]
        public string Number
        {
            get
            {
                if (Validation.EducDocument != null)
                    return Validation.EducDocument.DocNumber;
                else
                    return "";
            }
            set
            {
                if (Validation.EducDocument != null)
                    Validation.EducDocument.DocNumber = value;
            }
        }


        [System.ComponentModel.DisplayName("\tДата выдачи подтверждающего документа")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Дата выдачи подтверждающего документа")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]

        public DateTime? DocDate
        {
            get
            {
                if (Validation.EducDocument != null)
                    return Validation.EducDocument.DocDate;
                else
                    return null;
            }
            set
            {

                if (Validation.EducDocument != null)
                    Validation.EducDocument.DocDate = value;

            }
        }

        [System.ComponentModel.DisplayName("Приказ")]
        [System.ComponentModel.Category("Приказ")]
        [System.ComponentModel.Description("Приказ, назначающий аттестацию")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return Validation.Event.Prikaz;
            }
            set
            {
                Validation.Event.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата аттестации")]
        [System.ComponentModel.Category("Приказ")]
        [System.ComponentModel.Description("Дата проведения аттестации")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        public DateTime? Date
        {
            get
            {
                return Validation.Event.DateBegin;
            }
            set
            {
                    Validation.Event.DateBegin = value;

            }
        }

        public PrikazType PrikazType
        {
            get
            {
                return MagicNumberController.ValidationPrikazType;
            }
        }


        internal Validation GetValidation()
        {
            return Validation;
        }
    }
}
