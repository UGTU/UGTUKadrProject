using Kadr.Controllers;
using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHourContractDecorator: FactStaffBaseDecorator
    {
        public FactStaffHourContractDecorator(FactStaff factStaff)
            : base(factStaff)
        {
        }



        [System.ComponentModel.DisplayName("Cотрудник договора")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Сотрудник, для которого указывается договор")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FactStaffEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FactStaffCurrentMainData MainFactStaff
        {
            get
            {
                return factStaff.MainFactStaffData;
            }
            set
            {
                if (value != null)
                    factStaff.MainFactStaff = KadrController.Instance.Model.FactStaffs.Where(fcSt => fcSt.id == value.id).SingleOrDefault();
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Занимаемое сотрудником по факту количество ставок")]
        [System.ComponentModel.ReadOnly(false)]
        public decimal StaffCount
        {
            get
            {
                return factStaff.StaffCount;
            }
            set
            {
                factStaff.StaffCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок по нагрузке")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Занимаемое сотрудником количество ставок по нагрузке")]
        [System.ComponentModel.ReadOnly(true)]
        public decimal? HourStaffCount
        {
            get
            {
                return factStaff.HourStaffCount;
            }
        }

        [System.ComponentModel.DisplayName("Количество часов")]
        [System.ComponentModel.Category("Почасовики")]
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

        [System.ComponentModel.DisplayName("Оплата за час")]
        [System.ComponentModel.Category("Почасовики")]
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

        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Общие")]
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

        [System.ComponentModel.DisplayName("Название вида работы")]
        [System.ComponentModel.Category("Основные параметры")]
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

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Источник финансирования (редактировать для почасовиков)")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.FinancingSourceConvertor))]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
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

        [System.ComponentModel.DisplayName("Приказ увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Приказ увольнения сотрудника")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return factStaff.Prikaz;
            }
            set
            {
                factStaff.Prikaz = value;
            }
        }


        [System.ComponentModel.DisplayName("Комментарий")]
        [System.ComponentModel.Category("Почасовики")]
        [System.ComponentModel.Description("Комментарий")]
        [System.ComponentModel.ReadOnly(false)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
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
