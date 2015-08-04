using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class DepartmentTimeNormDecorator
    {
        private DepartmentTimeNorm departmentTimeNorm;

        override public string ToString()
        {
            return "Норма времени отдела " + departmentTimeNorm.Dep.ToString().ToLower();
        }

        public DepartmentTimeNormDecorator(DepartmentTimeNorm departmentTimeNorm)
        {
            this.departmentTimeNorm = departmentTimeNorm;
        }


        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код нормы времени")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return departmentTimeNorm.id;
            }
            set
            {
                departmentTimeNorm.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Название отдела, к которому относится норма времени")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Dep Department
        {
            get
            {
                return departmentTimeNorm.Dep;
            }
            set
            {
                departmentTimeNorm.Dep = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Источник финансирования, для которой задана норма времени")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return departmentTimeNorm.FinancingSource;
            }
            set
            {
                departmentTimeNorm.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения")]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(departmentTimeNorm.DateBegin);
            }
            set
            {
                departmentTimeNorm.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество часов по норме")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Количество часов по норме времени на ставку")]
        public decimal NormHoursCount
        {
            get
            {
                return departmentTimeNorm.NormHoursCount;
            }
            set
            {
                departmentTimeNorm.NormHoursCount = value;
            }
        }
    }
}
