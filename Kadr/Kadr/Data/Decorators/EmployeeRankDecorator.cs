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


        [System.ComponentModel.DisplayName("Дата выдачи аттестата")]
        [System.ComponentModel.Category("Данные аттестата")]
        [System.ComponentModel.Description("Дата выдачи аттестата")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Browsable(false)]
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

        [System.ComponentModel.DisplayName("\t\tСерия аттестата")]
        [System.ComponentModel.Category("Данные аттестата")]
        [System.ComponentModel.Description("Серия аттестата")]
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

        [System.ComponentModel.DisplayName("\tНомер аттестата")]
        [System.ComponentModel.Category("Данные аттестата")]
        [System.ComponentModel.Description("Номер аттестата")]
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

        [System.ComponentModel.DisplayName("Кем выдан аттестат")]
        [System.ComponentModel.Category("Данные аттестата")]
        [System.ComponentModel.Description("Кем выдан аттестат")]
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
