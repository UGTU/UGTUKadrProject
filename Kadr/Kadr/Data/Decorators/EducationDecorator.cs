using System;
using System.Collections.Generic;
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

        public int Id
        {
            get
            {
                return _education.idEducDocument;
            }
        }

        [System.ComponentModel.DisplayName("Тип образования")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Наименование типа образования")]
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

    }
}
