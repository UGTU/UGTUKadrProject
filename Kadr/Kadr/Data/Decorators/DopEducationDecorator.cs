using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using Kadr.Controllers;
using Kadr.Data.Converters;


namespace Kadr.Data
{
    class DopEducationDecorator
    {
        private OK_DopEducation _dop;

        public DopEducationDecorator(OK_DopEducation dopEduc)
        {
            this._dop = dopEduc;
        }

        public override string ToString()
        {
            return (_dop.DopEducType != null) ?_dop.DopEducType.ToString() : "";
        }

        [DisplayName("id")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код доп. образования")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]

        public int id
        {
            get
            {
                return _dop.id;
            }
        }

        [DisplayName("\t\tТип повышения квалификации")]
        [Category("Основные")]
        [Description("Тип повышения квалификации согласно классификатору")]
        [TypeConverter(typeof(SimpleToStringConvertor<DopEducType>))]
    //    [RefreshProperties(RefreshProperties.All)]
        [ReadOnly(false)]
        public DopEducType DopEducType
        {
            get
            {
                return _dop.DopEducType;
            }
            set
            {
               _dop.DopEducType = value;
                if (value == null) return;
                if (value.EducDocumentType != null)
                    _dop.EducDocument.EducDocumentType = value.EducDocumentType;
               // this.SetPropertyReadOnly(() => _dop.EducDocument.EducDocumentType, value.EducDocumentType != null);
            }
        }

        [DisplayName("\tНорма продолжительности")]
        [Category("Основные")]
        [Description("Норма продолжительности обучения в аудиторных часах для указанного типа обучения")]
        [EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        [ReadOnly(true)]
        public string Duration
        {
            get { return ((_dop.DopEducType != null) && (_dop.DopEducType.Duration != "")) ? _dop.DopEducType.Duration : "(не определена)"; }
        }


        [System.ComponentModel.DisplayName("Начало")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Дата начала обучения/стажировки")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        [ReadOnly(false)]
        public DateTime? DateBegin
        {
            get {return _dop.DateBegin;}
            set 
            { 
                _dop.DateBegin = value;
                if (_dop.FactStaffPrikaz != null)
                  _dop.FactStaffPrikaz.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Окончание")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Дата окончания обучения/стажировки")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        [ReadOnly(false)]
        public DateTime? DateEnd
        {
            get { return _dop.DateEnd; }
            set
            {
                _dop.DateEnd = value;
                if (_dop.FactStaffPrikaz != null)
                    _dop.FactStaffPrikaz.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Аудиторных часов")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Общее количество аудиторных часов")]
        [ReadOnly(false)]
        public int? AuditHour
        {
            get { return _dop.AuditHour; }
            set { _dop.AuditHour = value; }
        }

        [System.ComponentModel.DisplayName("Приказ")]
        [System.ComponentModel.Category("Основные")]
        [System.ComponentModel.Description("Приказ, направляющий на обучение/стажировку")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [ReadOnly(false)]
        public Prikaz Prikaz
        {
            get
            {
                return _dop.Prikaz;
            }
            set
            {
                _dop.Prikaz = value;
            }
        }

        [DisplayName("Вид документа")]
        [Category("Подтверждающий документ")]
        [Description("Вид документа, подтверждающего обучение")]
        [TypeConverter(typeof(DocumentTypeToStringConvertor))]
        public EducDocumentType EducDocumentType
        {
            get
            {
                return _dop.EducDocument.EducDocumentType;
            }
            set
            {
                _dop.EducDocument.EducDocumentType = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата вручения")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Дата вручения документа об обучении")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        [ReadOnly(false)]
        public DateTime? Date
        {
            get
            {
                return _dop.EducDocument.DocDate;
            }
            set
            {
                _dop.EducDocument.DocDate = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\tСерия")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Серия документа, подтверждающего факт образования")]
        [ReadOnly(false)]
        public string Seria
        {
            get
            {
                if (_dop.EducDocument != null)
                    return _dop.EducDocument.DocSeries;
                return "";
            }
            set
            {
                if (_dop.EducDocument != null)
                    _dop.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("\tНомер")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Номер документа, подтверждающего факт образования")]
        [ReadOnly(false)]
        public string Number
        {
            get
            {
                if (_dop.EducDocument != null)
                    return _dop.EducDocument.DocNumber;
                return "";
            }
            set
            {
                if (_dop.EducDocument != null)
                    _dop.EducDocument.DocNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Организация")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Организация, вручившая документ об образовании")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<Organisation>))]
        [ReadOnly(false)]
        public Organisation Organization
        {
            get
            {
                if (_dop.EducDocument != null)
                    return _dop.EducDocument.Organisation;
                return null;
            }
            set
            {
                if (_dop.EducDocument != null)
                    _dop.EducDocument.Organisation = value;
            }
        }

        [System.ComponentModel.DisplayName("Квалификация")]
        [System.ComponentModel.Category("Сведения по образованию")]
        [System.ComponentModel.Description("Квалификация по документу об образовании")]
        [ReadOnly(false)]
        public string Qualification
        {
            get
            {

                return (_dop.Kvalif);
            }
            set
            {
                _dop.Kvalif = value;
            }
        }

        [System.ComponentModel.DisplayName("Направление/Специальность")]
        [System.ComponentModel.Category("Сведения по образованию")]
        [System.ComponentModel.Description("Направление или специальность по документу об образовании")]
        [ReadOnly(false)]
        public string Spec
        {
            get
            {

                return (_dop.Spec);
            }
            set
            {
                _dop.Spec = value;
            }
        }

        internal OK_DopEducation GetDopEduc()
        {
            return _dop;
        }
    }
}
