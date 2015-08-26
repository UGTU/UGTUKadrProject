using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class DopEducTypeDecorator
    {
        private DopEducType _DopEducType;

        public DopEducTypeDecorator(DopEducType dopEducType)
        {
            this._DopEducType = dopEducType;
        }

        public override string ToString()
        {
            return _DopEducType.DopEducName + " (" + _DopEducType.Duration + " часов)";
        }

        [System.ComponentModel.DisplayName("idOK_DopEduc")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код типа повышения квалификации")]
        [System.ComponentModel.ReadOnly(true)]
     //   [System.ComponentModel.Browsable(false)]
        public int IdDopEducType
        {
            get
            {
                return _DopEducType.id;
            }
        }

        [System.ComponentModel.DisplayName("Тип повышения квалификации")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Наименование типа повышения квалификации")]
        public string DopEducName
        {
            get
            {
                return _DopEducType.DopEducName;
            }
            set
            {
                    _DopEducType.DopEducName = value;
            }
        }

        [System.ComponentModel.DisplayName("Продолжительность")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Продолжительность в аудиторных часах")]
        public string Duration
        {
            get
            {
                return _DopEducType.Duration;
            }
            set
            {
                _DopEducType.Duration = value;
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
                return _DopEducType.EducDocumentType;
            }
            set
            {
                _DopEducType.EducDocumentType = value;
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
                return _DopEducType.EducDocumentType == null ? "" : _DopEducType.EducDocumentType.DocTypeName;
            }
            set
            {
                if (value != "")
                    _DopEducType.EducDocumentType = KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(x=>x.DocTypeName == value);
            }
        }

    }
}
