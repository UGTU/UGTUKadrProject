using Kadr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffReplacementDecorator
    {
        private FactStaffReplacement factStaffReplacement;
        public FactStaffReplacementDecorator(FactStaffReplacement factStaffReplacement)
        {
            this.factStaffReplacement = factStaffReplacement;
        }


        public override string ToString()
        {
            string res = "Cовмещение сотрудника ";

            if (factStaffReplacement.ReplacedFactStaff!=null)
                res = res + factStaffReplacement.ReplacedFactStaff.ToString();
            return res;
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код сотрудника (совмещающего) в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return factStaffReplacement.MainFactStaff.id;
            }
        }

        [System.ComponentModel.DisplayName("ФИО совмещающего сотрудника")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("ФИО совмещающего сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.EmployeeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Employee Employee
        {
            get
            {
                return factStaffReplacement.MainFactStaff.Employee;
            }
            set
            {
                factStaffReplacement.MainFactStaff.Employee = value;
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
                return factStaffReplacement.ReplacedFactStaff.PlanStaff.Dep;
            }
            set
            {
                factStaffReplacement.ReplacedFactStaff.PlanStaff.Dep = value;
            }
        }

        [System.ComponentModel.DisplayName("Должность")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название должности в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Post Post
        {
            get
            {
                return factStaffReplacement.ReplacedFactStaff.PlanStaff.Post;
            }
            set
            {
                factStaffReplacement.ReplacedFactStaff.PlanStaff.Post = value;
            }
        }


        [System.ComponentModel.DisplayName("Название вида работы")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название вида работы")]
        //[System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<WorkType>))]
        public Kadr.Data.WorkType WorkType
        {
            get
            {
                return factStaffReplacement.MainFactStaff.WorkType;
            }
            set
            {
                factStaffReplacement.MainFactStaff.WorkType = value;
            }
        }

        [System.ComponentModel.DisplayName("ФИО совмещаемого сотрудника")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("ФИО совмещаемого сотрудника")]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Employee ReplacedEmployee
        {
            get
            {
                return factStaffReplacement.ReplacedFactStaff.Employee;
            }
            set
            {
                factStaffReplacement.ReplacedFactStaff.Employee = value;
            }
        }

        [System.ComponentModel.DisplayName("% замещения")]
        [System.ComponentModel.Category("Параметры замещения")]
        [System.ComponentModel.Description("% замещения сотрудника")]
        public decimal StaffCount
        {
            get
            {
                return factStaffReplacement.ReplacedPercent;
            }
            set
            {
                factStaffReplacement.ReplacedPercent = value;
            }
        }

        [System.ComponentModel.DisplayName("Причина замещения")]
        [System.ComponentModel.Category("Параметры замещения")]
        [System.ComponentModel.Description("Причина замещения сотрудника")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<NullFactStaffReplacementReason>))]
        public Kadr.Data.FactStaffReplacementReason FactStaffReplacementReason
        {
            get
            {
                return factStaffReplacement.FactStaffReplacementReason;
            }
            set
            {
                factStaffReplacement.FactStaffReplacementReason = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания замещения")]
        [System.ComponentModel.Category("Параметры замещения")]
        [System.ComponentModel.Description("Дата окончания замещения")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime ReplacementDataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaffReplacement.DateEnd);
            }
            set
            {
                factStaffReplacement.DateEnd = value;
                if (value == DateTime.MinValue)
                    factStaffReplacement.DateEnd = null;
                if (factStaffReplacement.DateEnd == null)
                    factStaffReplacement.FactStaff1.IsReplacement = true;
                else
                    factStaffReplacement.FactStaff1.IsReplacement = false;
            }
        }

        [System.ComponentModel.DisplayName("Приказ утверждения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ назначения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
        {
            get
            {
                return factStaffReplacement.MainFactStaff.PrikazBegin;
            }
            set
            {
                factStaffReplacement.MainFactStaff.PrikazBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Приказ увольнения сотрудника")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return factStaffReplacement.MainFactStaff.Prikaz;
            }
            set
            {
                factStaffReplacement.MainFactStaff.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения на должность")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(factStaffReplacement.MainFactStaff.DateBegin);
            }
            set
            {
                factStaffReplacement.MainFactStaff.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата увольнения")]
        [System.ComponentModel.Category("Параметры увольнения")]
        [System.ComponentModel.Description("Дата снятия с должности")]
        // [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public DateTime DataEnd
        {
            get
            {
                return Convert.ToDateTime(factStaffReplacement.MainFactStaff.DateEnd);
            }
            set
            {
                if ((value != null) && ((factStaffReplacement.DateEnd == null)
                        || (factStaffReplacement.DateEnd == factStaffReplacement.MainFactStaff.DateEnd)))
                    factStaffReplacement.DateEnd = value;
                factStaffReplacement.MainFactStaff.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("Подподкатегория")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Подподкатегория (определяет коэффициент к окладу сотрудника)")]
        public int? SalaryKoeff
        {
            get
            {
                if (factStaffReplacement.MainFactStaff.SalaryKoeff != null)
                    return factStaffReplacement.MainFactStaff.SalaryKoeff.PKSubSubCategoryNumber;
                return null;
            }
            set
            {
                factStaffReplacement.MainFactStaff.SalaryKoeff = KadrController.Instance.Model.SalaryKoeffs.Where(koef => koef.PKSubSubCategoryNumber == value).FirstOrDefault();
            }
        }
    }
}
