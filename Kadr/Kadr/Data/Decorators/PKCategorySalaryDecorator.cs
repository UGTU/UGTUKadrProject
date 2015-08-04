using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class PKCategorySalaryDecorator
    {
        private PKCategorySalary pkCategorySalary;
        public PKCategorySalaryDecorator(PKCategorySalary pkCategorySalary)
        {
            this.pkCategorySalary = pkCategorySalary;
        }

        override public string ToString()
        {
            return "Оклад " + pkCategorySalary.PKCategory.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код оклада")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return pkCategorySalary.id;
            }
            set
            {
                pkCategorySalary.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Профессиональный уровень")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Профессионально-квалификационный уровень")]
        public PKCategory PKCategory
        {
            get
            {
                return pkCategorySalary.PKCategory;
            }
            set
            {
                pkCategorySalary.PKCategory = value;
            }
        }

        [System.ComponentModel.DisplayName("Размер оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Размер оклада профессионально-квалификационной категории")]
        //[System.ComponentModel.]
        public decimal SalarySize
        {
            get
            {
                return pkCategorySalary.SalarySize;
            }
            set
            {
                pkCategorySalary.SalarySize = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения оклада категории")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(pkCategorySalary.DateBegin);
            }
            set
            {
                pkCategorySalary.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата отмены оклада категории")]
        public DateTime DateEnd
        {
            get
            {
                return Convert.ToDateTime(pkCategorySalary.DateEnd);
            }
            set
            {
                pkCategorySalary.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения оклада")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz Prikaz
        {
            get
            {
                return pkCategorySalary.Prikaz;
            }
            set
            {
                pkCategorySalary.Prikaz = value;
            }
        }
    }

}
