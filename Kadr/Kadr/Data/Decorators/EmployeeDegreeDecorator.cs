using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class EmployeeDegreeDecorator
    {
        private EmployeeDegree employeeDegree;
        public EmployeeDegreeDecorator(EmployeeDegree employeeDegree)
        {
            this.employeeDegree = employeeDegree;
        }


        public override string ToString()
        {
            if (employeeDegree.Employee == null)
                return "Научная степень ";
            else
                return "Научная степень " + employeeDegree.Employee.ToString();
        }



        [System.ComponentModel.DisplayName("Диссертационный совет")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Диссертационный совет, в котором была защищена степень")]
        public string DissertCouncil
        {
            get
            {
                return employeeDegree.DissertCouncil;
            }
            set
            {
                employeeDegree.DissertCouncil = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата присвоения степени")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата присвоения научной степени")]
        public DateTime degreeDate
        {
            get
            {
                return Convert.ToDateTime(employeeDegree.degreeDate);
            }
            set
            {
                employeeDegree.degreeDate = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата выдачи диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Дата выдачи диплома")]
        public DateTime DocDate
        {
            get
            {
                return Convert.ToDateTime(employeeDegree.EducDocument.DocDate);
            }
            set
            {
                employeeDegree.EducDocument.DocDate = value;
            }
        }

        [System.ComponentModel.DisplayName("Серия диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Серия диплома")]
        public string DocSeries
        {
            get
            {
                return employeeDegree.EducDocument.DocSeries;
            }
            set
            {
                employeeDegree.EducDocument.DocSeries = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер диплома")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Номер диплома")]
        public string DocNumber
        {
            get
            {
                return employeeDegree.EducDocument.DocNumber;
            }
            set
            {
                employeeDegree.EducDocument.DocNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Кем выдан диплом")]
        [System.ComponentModel.Category("Данные диплома")]
        [System.ComponentModel.Description("Кем выдан диплом")]
        public string diplWhere
        {
            get
            {
                return employeeDegree.diplWhere;
            }
            set
            {
                employeeDegree.diplWhere = value;
            }
        }

        [System.ComponentModel.DisplayName("Научная степень сотрудника")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название научной степени сотрудника")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<Degree>))]
        public Kadr.Data.Degree Degree
        {
            get
            {
                return employeeDegree.Degree;
            }
            set
            {
                employeeDegree.Degree = value;
            }
        }

        [System.ComponentModel.DisplayName("Научное направление")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Научное направление, в котором присвоена степень")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<ScienceType>))]
        public Kadr.Data.ScienceType ScienceType
        {
            get
            {
                return employeeDegree.ScienceType;
            }
            set
            {
                employeeDegree.ScienceType = value;
            }
        }
    }
}
