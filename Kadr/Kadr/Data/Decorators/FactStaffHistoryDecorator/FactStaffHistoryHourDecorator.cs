   using Kadr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;



namespace Kadr.Data
{
    class FactStaffHistoryHourDecorator: FactStaffHistoryBaseDecorator
    {
        public FactStaffHistoryHourDecorator(FactStaffHistory factStaffHistory)
            : base(factStaffHistory)
        {
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\t\t\t\t\tBид работы")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Bид работы сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<WorkType>))]
        public WorkType WorkType
        {
            get
            {
                return factStaffHistory.WorkType;
            }
        }


        [System.ComponentModel.DisplayName("Количество ставок по нагрузке")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\t\tКоличество часов")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
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

        [System.ComponentModel.DisplayName("\t\t\t\t\tОплата за час")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
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
        [System.ComponentModel.Category("\t\t\t\t\t\t\t\t\t\t\t\tОбщие")]
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
