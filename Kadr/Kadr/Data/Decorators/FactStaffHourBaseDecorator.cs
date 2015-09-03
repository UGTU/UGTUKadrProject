using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHourBaseDecorator: FactStaffBaseDecorator
    {
        public FactStaffHourBaseDecorator(FactStaff factStaff)
            : base(factStaff)
        {
        }
        
        public override string ToString()
        {
            return "Почасовики (бюджет) отдела " + factStaff.Department.ToString().ToLower();
        }

        [System.ComponentModel.DisplayName("Количество ставок по нагрузке")]
        [System.ComponentModel.Category("\t\t\tПочасовики")]
        [System.ComponentModel.Description("Занимаемое сотрудником количество ставок по нагрузке")]
        [System.ComponentModel.ReadOnly(true)]
        public decimal? HourStaffCount
        {
            get
            {
                return factStaff.HourStaffCount;
            }
        }

        [System.ComponentModel.DisplayName("\t\tОтдел")]
        [System.ComponentModel.Category("\t\t\t\t\tОбщие")]
        [System.ComponentModel.Description("Название отдела")]
        [System.ComponentModel.ReadOnly(true)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Dep Department
        {
            get
            {
                return factStaff.Department;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\tКоличество часов")]
        [System.ComponentModel.Category("\t\t\tПочасовики")]
        [System.ComponentModel.Description("Количество часов для почасовиков")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal? HourCount
        {
            get
            {
                return factStaff.HourCount;
            }
            set
            {
                factStaff.HourCount = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\tОплата за час")]
        [System.ComponentModel.Category("\t\t\tПочасовики")]
        [System.ComponentModel.Description("Оплата за час для почасовиков")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal? HourSalary
        {
            get
            {
                return factStaff.HourSalary;
            }
            set
            {
                factStaff.HourSalary = value;
            }
        }


        [System.ComponentModel.DisplayName("Вид работы")]
        [System.ComponentModel.Category("\t\t\t\t\tОбщие")]
        [System.ComponentModel.Description("Название вида работы")]
        [System.ComponentModel.ReadOnly(false)]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.WorkTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.WorkType WorkType
        {
            get
            {
                return factStaff.WorkType;
            }
            set
            {
                factStaff.WorkType = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\tИсточник финансирования")]
        [System.ComponentModel.Category("\t\t\tПочасовики")]
        [System.ComponentModel.Description("Источник финансирования (редактировать для почасовиков)")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.FinancingSourceConvertor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return factStaff.FinancingSource;
            }
            set
            {
                factStaff.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\tКомментарий")]
        [System.ComponentModel.Category("\t\t\tПочасовики")]
        [System.ComponentModel.Description("Комментарий")]
        [System.ComponentModel.ReadOnly(false)]
        public string Comment
        {
            get
            {
                return factStaff.Comment;
            }
            set
            {
                factStaff.Comment = value;
            }
        }


    }
}
