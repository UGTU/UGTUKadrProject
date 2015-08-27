using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class EmployeeRankDecorator
    {
        private EmployeeRank employeeRank;
        public EmployeeRankDecorator(EmployeeRank employeeRank)
        {
            this.employeeRank = employeeRank;
        }


        public override string ToString()
        {
            return "Ученое звание " + employeeRank.Employee.ToString();
        }


        [System.ComponentModel.DisplayName("Дата выдачи диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Дата выдачи диплома")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DocDate
        {
            get
            {
                return Convert.ToDateTime(employeeRank.EducDocument.DocDate);
            }
            set
            {
                employeeRank.EducDocument.DocDate = value;
            }
        }

        [System.ComponentModel.DisplayName("Серия диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Серия диплома")]
        [System.ComponentModel.ReadOnly(false)]
        public string DocSeries
        {
            get
            {
                return employeeRank.EducDocument.DocSeries;
            }
            set
            {
                employeeRank.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Номер диплома")]
        [System.ComponentModel.ReadOnly(false)]
        public string DocNumber
        {
            get
            {
                return employeeRank.EducDocument.DocNumber;
            }
            set
            {
                employeeRank.EducDocument.DocNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Кем выдан диплом")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Кем выдан диплом")]
        [System.ComponentModel.ReadOnly(false)]
        public string diplWhere
        {
            get
            {
                return employeeRank.rankWhere;
            }
            set
            {
                employeeRank.rankWhere = value;
            }
        }

        [System.ComponentModel.DisplayName("Ученое звание сотрудника")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название ученого звания сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<Rank>))]
        public Kadr.Data.Rank Rank
        {
            get
            {
                return employeeRank.Rank;
            }
            set
            {
                employeeRank.Rank = value;
            }
        }

    }

}
