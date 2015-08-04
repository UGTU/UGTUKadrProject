using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class DepartmentFundDecorator
    {
        private DepartmentFund departmentFund;

        override public string ToString()
        {
            return "Бюджетный фонд отдела " + departmentFund.Dep.ToString().ToLower();
        }

        public DepartmentFundDecorator(DepartmentFund departmentFund)
        {
            this.departmentFund = departmentFund;
        }



        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Название отдела, к которому относится норма времени")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Dep Department
        {
            get
            {
                return departmentFund.Dep;
            }
            set
            {
                departmentFund.Dep = value;
            }
        }


        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения")]
        public DateTime DataBegin
        {
            get
            {
                return departmentFund.DateBegin;
            }
            set
            {
                departmentFund.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Плановый размер фонда")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Плановый размер фонда отдела")]
        public decimal PlanFundSum
        {
            get
            {
                return departmentFund.PlanFundSum;
            }
            set
            {
                departmentFund.PlanFundSum = value;
            }
        }

        [System.ComponentModel.DisplayName("Фактический размер фонда")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Фактический размер фонда отдела")]
        public decimal FactFundSum
        {
            get
            {
                return departmentFund.FactFundSum;
            }
            set
            {
                departmentFund.FactFundSum = value;
            }
        }

        [System.ComponentModel.DisplayName("Размер внеплановых выплат")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Размер внеплановых выплат, установленный для отдела")]
        public decimal ExtraordSum
        {
            get
            {
                return departmentFund.ExtraordSum;
            }
            set
            {
                departmentFund.ExtraordSum = value;
            }
        }
    }
}
