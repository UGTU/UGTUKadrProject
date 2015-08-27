using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    internal class EmployeeStandingDecorator
    {
        private EmployeeStanding employeeStanding;

        public EmployeeStandingDecorator(EmployeeStanding employeeStanding)
        {
            this.employeeStanding = employeeStanding;
        }


        public override string ToString()
        {
            return employeeStanding.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код записи трудовой книжки")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return employeeStanding.id;
            }
            set
            {
                employeeStanding.id = value;
            }
        }

        [System.ComponentModel.DisplayName("ФИО сотрудника")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("ФИО сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public Employee Employee
        {
            get
            {
                return employeeStanding.Employee;
            }
            set
            {
                employeeStanding.Employee = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата приема на работу")]
        [System.ComponentModel.Category("Данные трудовой книжки")]
        [System.ComponentModel.Description("Дата приема на работу")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(employeeStanding.DateBegin);
            }
            set
            {
                employeeStanding.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата увольнения")]
        [System.ComponentModel.Category("Данные трудовой книжки")]
        [System.ComponentModel.Description("Дата увольнения")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateEnd
        {
            get
            {
                return Convert.ToDateTime(employeeStanding.DateEnd);
            }
            set
            {
                employeeStanding.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Должность")]
        [System.ComponentModel.Category("Данные трудовой книжки")]
        [System.ComponentModel.Description("Должность")]
        [System.ComponentModel.ReadOnly(false)]
        public string Post
        {
            get
            {
                return employeeStanding.Post;
            }
            set
            {
                employeeStanding.Post = value;
            }
        }

        [System.ComponentModel.DisplayName("Место работы")]
        [System.ComponentModel.Category("Данные трудовой книжки")]
        [System.ComponentModel.Description("Место работы")]
        [System.ComponentModel.ReadOnly(false)]
        public string WorkPlace
        {
            get
            {
                return employeeStanding.WorkPlace;
            }
            set
            {
                employeeStanding.WorkPlace = value;
            }
        }

        [System.ComponentModel.DisplayName("Тип региона")]
        [System.ComponentModel.Category("Данные трудовой книжки")]
        [System.ComponentModel.Description("Тип региона")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.RegionConverter))]
        //[System.ComponentModel.Editor(typeof(RegionTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]//RegionType
        public RegionType RegionType
        {
            get
            {
                return employeeStanding.RegionType;
            }
            set
            {
                employeeStanding.RegionType = value;
            }
        }

        [System.ComponentModel.DisplayName("Тип стажа")]
        [System.ComponentModel.Category("Данные трудовой книжки")]
        [System.ComponentModel.Description("Тип стажа")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<StandingType>))]
        //[System.ComponentModel.Editor(typeof(StandingTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public StandingType StandingType
        {
            get
            {
                return employeeStanding.StandingType;
            }
            set
            {
                employeeStanding.StandingType = value;
            }
        }
    }

}
