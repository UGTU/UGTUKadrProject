using Kadr.Data.Converters;
using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class InkapacityDecorator
    {
        private OK_Inkapacity Inkapacity;

        public InkapacityDecorator(OK_Inkapacity Inkapacity)
        {
            this.Inkapacity = Inkapacity;
        }

        public override string ToString()
        {
            return Inkapacity.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код больничного")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]

        public int Id
        {
            get
            {
                return Inkapacity.idInkapacity;
            }
        }

        [System.ComponentModel.DisplayName("Дата начала")]
        [System.ComponentModel.Category("Даты")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Description("Дата начала больничного")]

        public DateTime DateBegin
        {
            get
            {
                return Inkapacity.DateBegin;
            }
            set
            {
                if (value != null)
                {
                    Inkapacity.DateBegin = value;
                }

            }
        }

        [System.ComponentModel.DisplayName("Дата окончания")]
        [System.ComponentModel.Category("Даты")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Description("Дата окончания больничного")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]

        public DateTime? DateEnd
        {
            get
            {
                return Inkapacity.DateEnd;
            }
            set
            {

                if (value != null)
                {
                    Inkapacity.DateEnd = value;
                }

            }
        }

        [System.ComponentModel.DisplayName("Серия")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Серия документа, подтверждающего период нетрудоспособности")]
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.ReadOnly(false)]
        public string Serie
        {
            get
            {
                if (Inkapacity.EducDocument != null)
                    return Inkapacity.EducDocument.DocSeries;
                else
                    return "";
            }
            set
            {
                if (Inkapacity.EducDocument != null)
                    Inkapacity.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Номер документа, подтверждающего период нетрудоспособности")]
        [System.ComponentModel.ReadOnly(false)]
        public string Number
        {
            get
            {
                if (Inkapacity.EducDocument != null)
                    return Inkapacity.EducDocument.DocNumber;
                else
                    return Inkapacity.NInkapacity;
            }
            set
            {
                if (Inkapacity.EducDocument != null)
                    Inkapacity.EducDocument.DocNumber = value;
                else
                    Inkapacity.NInkapacity = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата выдачи документа")]
        [System.ComponentModel.Category("Подтверждающий документ")]
        [System.ComponentModel.Description("Дата выдачи документа, подтверждающего период нетрудоспособности")]
        [System.ComponentModel.EditorAttribute(typeof(DateTimeEditor), typeof(UITypeEditor))]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime? DocDate
        {
            get
            {
                if (Inkapacity.EducDocument != null)
                    return Inkapacity.EducDocument.DocDate;
                else
                    return null;
            }
            set
            {
                if (Inkapacity.EducDocument != null)
                    Inkapacity.EducDocument.DocDate = value;
            }
        }

        [System.ComponentModel.DisplayName("Приступил к работе")]
        [System.ComponentModel.Category("Результат")]
        [System.ComponentModel.Description("Приступил ли сотрудник к работе после окончания данного периода нетрудоспособности")]
        [System.ComponentModel.TypeConverter(typeof(CustomBooleanConverter))]
        [System.ComponentModel.ReadOnly(false)]
        public bool IsFinished
        {
            get
            {
                 return Inkapacity.IsFinished;
            }
            set
            {
                Inkapacity.IsFinished = value;
            }
        }

        internal OK_Inkapacity GetInkapacity()
        {
            return Inkapacity;
        }
    }
}
