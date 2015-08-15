using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class EducationDecorator
    {
        private OK_Educ _education;

        public EducationDecorator(OK_Educ education)
        {
            this._education = education;
        }

        public override string ToString()
        {
            return _education.EducationType.EduTypeName + ", " + _education.EducWhen;
        }

        [System.ComponentModel.DisplayName("idEducDocument")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код образования")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]

        public int idEducDocument
        {
            get
            {
                return _education.idEducDocument;
            }
        }

        [System.ComponentModel.DisplayName("Тип образования")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Наименование образования")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<EducationType>))]
        public EducationType Type
        {
            get
            {
                return _education.EducationType;
            }
            set
            {
                if (value != null)
                {
                    _education.EducationType = value;
                }

            }
        }

        [System.ComponentModel.DisplayName("Образовательное учреждение")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Учреждение, где было получено образование")]
        [System.ComponentModel.ReadOnly(true)]
      
        public string Where
        {
            get
            {
                if ((_education.EducDocument != null) && (_education.EducDocument.Organisation != null))
                    return _education.EducDocument.Organisation.ToString();
                return _education.EducWhere;
            }
        }

        [System.ComponentModel.DisplayName("Год окончания")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Год окончания образования")]
        public int EducWhen
        {
            get
            {
                return _education.EducWhen;
            }
            set
            {
                _education.EducWhen = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид документа")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Вид документа, подтверждающего образование")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<EducDocumentType>))]
        public EducDocumentType EducDocumentType
        {
            get
            {
                return _education.EducDocument.EducDocumentType;
            }
            set
            {
                _education.EducDocument.EducDocumentType = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата вручения")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Дата вручения документа об образовании")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        public DateTime? Date
        {
            get
            {
                return _education.EducDocument.DocDate;
            }
            set
            {
                _education.EducDocument.DocDate = value;
                if (value != null)
                    _education.EducWhen = value.Value.Year;
            }
        }

        [System.ComponentModel.DisplayName("\t\tСерия")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Серия документа, подтверждающего факт образования")]
        public string Seria
        {
            get
            {
                if (_education.EducDocument != null)
                    return _education.EducDocument.DocSeries;
                else
                    return "";
            }
            set
            {
                if (_education.EducDocument != null)
                    _education.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("\tНомер")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Номер документа, подтверждающего факт образования")]

        public string Number
        {
            get
            {
                if (_education.EducDocument != null)
                    return _education.EducDocument.DocNumber;
                else
                    return "";
            }
            set
            {
                if (_education.EducDocument != null)
                    _education.EducDocument.DocNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Организация")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Организация, вручившая документ об образовании")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<Organisation>))]
        public Organisation Organization
        {
            get
            {
                if (_education.EducDocument != null)
                    return _education.EducDocument.Organisation;
                return null;
            }
            set
            {
                if (_education.EducDocument != null)
                    _education.EducDocument.Organisation = value;
            }
        }

        [System.ComponentModel.DisplayName("Квалификация")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Квалификация по документу об образовании")]
        public string Qualification
        {
            get
            {

                return (_education.Kvalif);
            }
            set
            {
                _education.Kvalif = value;
            }
        }

        [System.ComponentModel.DisplayName("Направление/Специальность")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Направление или специальность по документу об образовании")]
        public string Spec
        {
            get
            {

                return (_education.Spec);
            }
            set
            {
                _education.Spec = value;
            }
        }

        


        internal OK_Educ GetEmplEduc()
        {
            return _education;
        }

    }
}
