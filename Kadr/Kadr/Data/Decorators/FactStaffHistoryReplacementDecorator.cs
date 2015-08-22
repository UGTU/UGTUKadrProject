using Kadr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHistoryReplacementDecorator
    {

        private FactStaffHistory factStaffHistory;
        public FactStaffHistoryReplacementDecorator(FactStaffHistory factStaffHistory)
        {
            this.factStaffHistory = factStaffHistory;
        }

        override public string ToString()
        {
            return factStaffHistory.ToString();
        }


        [System.ComponentModel.DisplayName("Дата изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Дата изменения")]
        public DateTime DateBegin
        {
            get
            {
                return factStaffHistory.DateBegin;
            }
            set
            {
                factStaffHistory.DateBegin = value;

            }
        }

        [System.ComponentModel.DisplayName("Приказ изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Приказ изменения записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz PrikazBegin
        {
            get
            {
                return factStaffHistory.Prikaz;
            }
            set
            {
                factStaffHistory.Prikaz = value;
            }
        }


        [System.ComponentModel.DisplayName("Новый вид работы")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Новый вид работы сотрудника")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<WorkType>))]
        public WorkType WorkType
        {
            get
            {
                return factStaffHistory.WorkType;
            }
            set
            {
                factStaffHistory.WorkType = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество часов")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Количество часов для почасовиков")]
        public decimal? HourCount
        {
            get
            {
                return factStaffHistory.HourCount;
            }
            set
            {
                factStaffHistory.HourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        public int? SalaryKoeff
        {
            get
            {
                if (factStaffHistory.SalaryKoeff != null)
                    return factStaffHistory.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                factStaffHistory.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }

        [System.ComponentModel.DisplayName("Оплата за час")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Оплата за час для почасовиков")]
        public decimal? HourSalary
        {
            get
            {
                return factStaffHistory.HourSalary;
            }
            set
            {
                factStaffHistory.HourSalary = value;
            }
        }

        [System.ComponentModel.DisplayName("ФИО совмещаемого сотрудника")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("ФИО совмещаемого сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Employee ReplacedEmployee
        {
            get
            {
                return factStaffHistory.FactStaff.FactStaffReplacement.ReplacedFactStaff.Employee;
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.ReplacedFactStaff.Employee = value;
            }
        }

        [System.ComponentModel.DisplayName("% совмещения")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("% совмещения сотрудника")]
        public decimal StaffCount
        {
            get
            {
                return factStaffHistory.FactStaff.FactStaffReplacement.ReplacedPercent;
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.ReplacedPercent = value;
            }
        }

        [System.ComponentModel.DisplayName("Причина совмещения")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("Причина замещения сотрудника")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<FactStaffReplacementReason>))]
        public Kadr.Data.FactStaffReplacementReason FactStaffReplacementReason
        {
            get
            {
                return factStaffHistory.FactStaff.FactStaffReplacement.FactStaffReplacementReason;
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.FactStaffReplacementReason = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания совмещения")]
        [System.ComponentModel.Category("Параметры совмещения")]
        [System.ComponentModel.Description("Дата окончания совмещения")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime ReplacementDataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaffHistory.FactStaff.FactStaffReplacement.DateEnd);
            }
            set
            {
                factStaffHistory.FactStaff.FactStaffReplacement.DateEnd = value;
                if (value == DateTime.MinValue)
                    factStaffHistory.FactStaff.FactStaffReplacement.DateEnd = null;
                if (factStaffHistory.FactStaff.FactStaffReplacement.DateEnd == null)
                    factStaffHistory.FactStaff.FactStaffReplacement.FactStaff1.IsReplacement = true;
                else
                    factStaffHistory.FactStaff.FactStaffReplacement.FactStaff1.IsReplacement = false;
            }
        }

    }
}
