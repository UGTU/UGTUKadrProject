﻿using Kadr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHistoryCommonBaseDecorator
    {
        protected FactStaffHistory factStaffHistory;
        public FactStaffHistoryCommonBaseDecorator(FactStaffHistory factStaffHistory)
        {
            this.factStaffHistory = factStaffHistory;
        }

        override public string ToString()
        {
            return factStaffHistory.ToString();
        }


        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\tДата назначения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Дата назначения на должность")]
        [System.ComponentModel.ReadOnly(false)]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\tПриказ назначения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Приказ изменения записи в штатном расписании")]
        [System.ComponentModel.ReadOnly(false)]
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


        /*[System.ComponentModel.DisplayName("Новый вид работы")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Новый вид работы сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
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
        [System.ComponentModel.ReadOnly(false)]
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
        [System.ComponentModel.ReadOnly(false)]
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
        [System.ComponentModel.ReadOnly(false)]
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
        [System.ComponentModel.ReadOnly(false)]
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
        }*/

    }
}

