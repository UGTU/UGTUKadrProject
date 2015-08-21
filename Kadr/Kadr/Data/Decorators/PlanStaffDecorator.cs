using System;
//using System.
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.UI.Editors;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.Data.Common;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    #region PlanStaff Decorator
    class PlanStaffDecorator
    {
        private PlanStaff planStaff;

        override public string ToString()
        {
            return "Штатное расписание отдела " + planStaff.Dep.ToString().ToLower();
        }

        public PlanStaffDecorator(PlanStaff planStaff)
        {
            this.planStaff = planStaff;
        }

        private dckadrDataContext model
        {
            get
            {
                return KadrController.Instance.Model;
            }
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код записи в штатном расписании")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return planStaff.id;
            }
            set
            {
                planStaff.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Отдел")]
        [System.ComponentModel.Category("Общие")]
        [System.ComponentModel.Description("Название отдела, к которому относится запись в штатном расписании")]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.DepartmentEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [System.ComponentModel.ReadOnly(true)]
        public Kadr.Data.Dep Department
        {
            get
            {
                //return model.Departments.First(dep => dep.id == planStaff.idDepartment);
                return planStaff.Dep;
            }
            set
            {
                planStaff.Dep = value;
            }
        }

        [System.ComponentModel.DisplayName("Должность")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название должности в штатном расписании")]
        //[System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<Post>))]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PostEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Post Post
        {
            get
            {
                return planStaff.Post;
            }
            set
            {
                planStaff.Post = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Запланированное количество ставок в штатном расписании")]
        public decimal StaffCount
        {
            get
            {
                return planStaff.StaffCount;
            }
            set
            {
                if (value >= 0.1M)
                    planStaff.StaffCount = value;
                else
                    throw new ApplicationException("Количество ставок не может быть меньше 0,1.");
            }
        }

        [System.ComponentModel.DisplayName("Приказ утверждения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ утверждения записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazBegin
        {
            get
            {
                return planStaff.PrikazBegin;
            }
            set
            {
                planStaff.PrikazBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ отмены")]
        [System.ComponentModel.Category("Отмена штатного расписания")]
        [System.ComponentModel.Description("Приказ отмены записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.Prikaz PrikazEnd
        {
            get
            {
                return planStaff.Prikaz;
            }
            set
            {
                planStaff.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения")]
        public DateTime DataBegin
        {
            get
            {
                return Convert.ToDateTime(planStaff.DateBegin);
            }
            set
            {
                planStaff.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены")]
        [System.ComponentModel.Category("Отмена штатного расписания")]
        [System.ComponentModel.Description("Дата отмены")]
        public DateTime DataEnd
        {
            get
            {
                return Convert.ToDateTime(planStaff.DateEnd);
            }
            set
            {
                planStaff.DateEnd = value;
            }
        }
        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Источник финансирования записи в штатном расписании")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<FinancingSource>))]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.AllFinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FinancingSource FinancingSource
        {
            get
            {
                return planStaff.FinancingSource;
            }
            set
            {
                planStaff.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("График работы")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("График работы сотрудников на данной должности")]
        public int? WorkSheduleToIntSing
        {
            get
            {
                if (planStaff.WorkShedule == null)
                    return null;
                return planStaff.WorkShedule.ToIntSign;
            }
            set
            {
                planStaff.WorkShedule = WorkShedule.IntSignToShedule(value);
            }
        }

    }
    #endregion

}
