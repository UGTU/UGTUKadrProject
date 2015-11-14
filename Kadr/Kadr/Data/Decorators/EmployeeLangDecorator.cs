using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class EmployeeLangDecorator
    {
        private OK_EmployeeLang _employeeLang;

        public EmployeeLangDecorator(OK_EmployeeLang employeeLang)
        {
            this._employeeLang = employeeLang;
        }

        public override string ToString()
        {
            return _employeeLang.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код языка сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]

        public int Id
        {
            get
            {
                return _employeeLang.idEmployeeLang;
            }
        }

        [System.ComponentModel.DisplayName("Название языка")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Название языка, которым владеет сотрудник")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<OK_Language>))]
        public OK_Language Language
        {
            get
            {
                return _employeeLang.OK_Language;
            }
            set
            {

                    _employeeLang.OK_Language = value;

            }
        }

        [System.ComponentModel.DisplayName("Степень владения языком")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Степень владения указанным языком")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<LanguageLevel>))]
        public LanguageLevel LanguageLevel
        {
            get
            {
                return _employeeLang.LanguageLevel;
            }
            set
            {
                    _employeeLang.LanguageLevel = value;

            }
        }

        [System.ComponentModel.DisplayName("Хорошее владение")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Показатель хорошего владения языком")]
        [System.ComponentModel.ReadOnly(true)]

        public string Level
        {
            get
            {
                return (_employeeLang.Level);
            }
        }

        [System.ComponentModel.DisplayName("Дата вручения")]
        [System.ComponentModel.Category("Подтверждающий документ (если таковой имеется)")]
        [System.ComponentModel.Description("Дата вручения сертификата")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        public DateTime? Date
        {
            get
            {
                if (_employeeLang.EducDocument != null)
                  return _employeeLang.EducDocument.DocDate;
                return null;
            }
            set
            {
                _employeeLang.EducDocument.DocDate = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\tСерия")]
        [System.ComponentModel.Category("Подтверждающий документ (если таковой имеется)")]
        [System.ComponentModel.Description("Серия документа, подтверждающего владение языком")]
        [System.ComponentModel.ReadOnly(false)]
        public string Serie
        {
            get
            {
                if (_employeeLang.EducDocument != null)
                    return _employeeLang.EducDocument.DocSeries;
                else
                    return "";
            }
            set
            {
                if (_employeeLang.EducDocument != null)
                    _employeeLang.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("\tНомер")]
        [System.ComponentModel.Category("Подтверждающий документ (если таковой имеется)")]
        [System.ComponentModel.Description("Номер документа, подтверждающего владение языком")]
        [System.ComponentModel.ReadOnly(false)]
        public string Number
        {
            get
            {
                if (_employeeLang.EducDocument != null)
                    return _employeeLang.EducDocument.DocNumber;
                else
                    return "";
            }
            set
            {
                if (_employeeLang.EducDocument != null)
                    _employeeLang.EducDocument.DocNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Организация")]
        [System.ComponentModel.Category("Подтверждающий документ (если таковой имеется)")]
        [System.ComponentModel.Description("Организация, вручившая документ (сертификат)")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<Organisation>))]
        public Organisation Organization
        {
            get
            {
                if (_employeeLang.EducDocument != null)
                    return _employeeLang.EducDocument.Organisation;
                else
                    return null;
            }
            set
            {
                if (_employeeLang.EducDocument != null)
                    _employeeLang.EducDocument.Organisation = value;
            }
        }

        internal OK_EmployeeLang GetEmployeeLang()
        {
            return _employeeLang;
        }
    }
}
