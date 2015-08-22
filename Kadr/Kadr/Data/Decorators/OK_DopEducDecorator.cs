using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class OK_DopEducDecorator
    {
        private OK_DopEduc _educationDopEduc;

        public OK_DopEducDecorator(OK_DopEduc educationDopEduc)
        {
            this._educationDopEduc = educationDopEduc;
        }

        public override string ToString()
        {
            return _educationDopEduc.DopEducName + " (" + _educationDopEduc.Duration + " часов)";
        }

        [System.ComponentModel.DisplayName("idOK_DopEduc")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код типа повышения квалификации")]
        [System.ComponentModel.ReadOnly(true)]
     //   [System.ComponentModel.Browsable(false)]
        public int idOK_DopEduc
        {
            get
            {
                return _educationDopEduc.id;
            }
        }

        [System.ComponentModel.DisplayName("Тип повышения квалификации")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Наименование типа повышения квалификации")]
        public string DopEducName
        {
            get
            {
                return _educationDopEduc.DopEducName;
            }
            set
            {
                    _educationDopEduc.DopEducName = value;
            }
        }

        [System.ComponentModel.DisplayName("Продолжительность")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Продолжительность в аудиторных часах")]
        public string Duration
        {
            get
            {
                return _educationDopEduc.Duration;
            }
            set
            {
                _educationDopEduc.Duration = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид документа")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Вид документа, подтверждающего обучение")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<EducDocumentType>))]
        public EducDocumentType EducDocumentType
        {
            get
            {
                return _educationDopEduc.EducDocumentType;
            }
            set
            {
                _educationDopEduc.EducDocumentType = value;
            }
        }

        [System.ComponentModel.DisplayName("Название документа")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Вид документа, подтверждающего обучение")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<EducDocumentType>))]
        public string DocTypeName
        {
            get
            {
                return _educationDopEduc.EducDocumentType == null ? "" : _educationDopEduc.EducDocumentType.DocTypeName;
            }
            set
            {
                if (value != "")
                    _educationDopEduc.EducDocumentType = KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(x=>x.DocTypeName == value);
            }
        }

    }
}
