using Kadr.Controllers;
using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class PKCategoryDecorator
    {
        private PKCategory pkCategory;
        public PKCategoryDecorator(PKCategory pkCategory)
        {
            this.pkCategory = pkCategory;
        }

        override public string ToString()
        {
            //return pkCategory.ToString();
            return "Профессионально-квалификационный подуровень " + CategoryFullName;
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код профессионально-квалификационного подуровня")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return pkCategory.id;
            }
            set
            {
                pkCategory.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер уровня")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Номер профессионально-квалификационного уровня")]
        public int PKCategoryNumber
        {
            get
            {
                return pkCategory.PKCategoryNumber;
            }
            set
            {
                pkCategory.PKCategoryNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер подуровня 1")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Номер профессионально-квалификационного подуровня 1")]
        public int PKSubCategoryNumber
        {
            get
            {
                return pkCategory.PKSubCategoryNumber;
            }
            set
            {
                pkCategory.PKSubCategoryNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер подуровня 2")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Номер профессионально-квалификационного подуровня 2")]
        public int? PKSubSubCategoryNumber
        {
            get
            {
                return pkCategory.PKSubSubCategoryNumber;
            }
            set
            {
                pkCategory.PKSubSubCategoryNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        public int? SalaryKoeff
        {
            get
            {
                if (pkCategory.SalaryKoeff != null)
                    return pkCategory.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                pkCategory.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }

        [System.ComponentModel.DisplayName("Профессиональная группа")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Профессионально-квалификационная группа")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<PKGroup>))]
        public PKGroup PKGroup
        {
            get
            {
                return pkCategory.PKGroup;
            }
            set
            {
                pkCategory.PKGroup = value;
            }
        }

        [System.ComponentModel.DisplayName("Полное имя профессионально-квалификационного подуровня")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Полное имя профессионально-квалификационного подуровня")]
        [System.ComponentModel.ReadOnly(true)]
        public string CategoryFullName
        {
            get
            {
                return pkCategory.CategoryFullName;
            }
        }

        [System.ComponentModel.DisplayName("Комментарий")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Комментарий к профессионально-квалификационному подуровню")]
        public string PKComment
        {
            get
            {
                return pkCategory.PKComment;
            }
            set
            {
                pkCategory.PKComment = value;
            }
        }

        //[System.ComponentModel.DisplayName("PKCategorySalary")]
        //[System.ComponentModel.Category("Атрибуты")]
        //[System.ComponentModel.Description("Оклад профессионально-квалификационной категории")]
        //[System.ComponentModel.ReadOnly(true)]
        //public PKCategorySalary PKCategorySalary
        //{
        //    get
        //    {
        //        return pkCategory.PKCategorySalaries.Where(pkCatSal => pkCatSal.DateEnd == null).First() as PKCategorySalary;
        //    }
        //}

    }

    
}
