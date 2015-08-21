using Kadr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHistoryDecorator
    {
        private FactStaffHistory factStaffHistory;
        public FactStaffHistoryDecorator(FactStaffHistory factStaffHistory)
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


        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Новое количество ставок сотрудника")]
        public decimal StaffCount
        {
            get
            {
                return factStaffHistory.StaffCount;
            }
            set
            {
                if (value >= 0.1M)
                {
                    factStaffHistory.StaffCount = value;
                }
                else
                    throw new ApplicationException("Количество ставок не может быть меньше 0,1.");
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок по нагрузке")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Занимаемое сотрудником по факту количество ставок по нагрузке")]
        [System.ComponentModel.ReadOnly(true)]
        public decimal? HourStaffCount
        {
            get
            {
                return factStaffHistory.HourStaffCount;
            }
            set
            {
                factStaffHistory.HourStaffCount = value;
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


        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название отдела")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Dep Department
        {
            get
            {
                return factStaffHistory.FactStaff.Department;
            }
        }

    }
}
