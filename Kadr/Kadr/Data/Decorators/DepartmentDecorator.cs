using Kadr.Controllers;
using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data.Converters;

namespace Kadr.Data
{
    class DepartmentDecorator
    {
        private Dep department;
        public DepartmentDecorator(Dep department)
        {
            this.department = department;
        }

        override public string ToString()
        {
            return "Отдел " + department.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код отдела")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return department.id;
            }
            set
            {
                department.id = value;
            }
        }

        [System.ComponentModel.DisplayName("KadrID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Код отдела в системе отдела кадров")]
        [System.ComponentModel.ReadOnly(true)]
        public int KadrID
        {
            get
            {
                //if (department.KadrID!=null)
                return Convert.ToInt16(department.KadrID);
                //else return 0;
            }
            set
            {
                department.KadrID = value;
            }
        }

        [System.ComponentModel.DisplayName("LastChangeID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("LastChangeID")]
        [System.ComponentModel.ReadOnly(true)]
        public int LastChangeID
        {
            get
            {
                //if (department.KadrID!=null)
                return Convert.ToInt16(department.LastChange.id);
                //else return 0;
            }

        }

        [System.ComponentModel.DisplayName("Название отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Уникальное название отдела в организации")]
        public string DepartmentName
        {
            get
            {
                return department.DepartmentName;
            }
            set
            {
                department.DepartmentName = value;
            }
        }

        [System.ComponentModel.DisplayName("Краткое название отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Краткое название отдела в организации")]
        public string DepartmentSmallName
        {
            get
            {
                return department.DepartmentSmallName;
            }
            set
            {
                department.DepartmentSmallName = value;
            }
        }

        [System.ComponentModel.DisplayName("Руководитель отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Руководитель отдела")]
        [System.ComponentModel.Editor(typeof(PlanStaffEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public PlanStaff ManagmentPlanStaff
        {
            get
            {
                return department.PlanStaff;
            }
            set
            {
                department.PlanStaff = value;
            }
        }

        [System.ComponentModel.DisplayName("ОКВЭД")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Код экономической деятельности")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<OKVED>))]
        public OKVED OKVED
        {
            get
            {
                return department.OKVED;
            }
            set
            {
                department.OKVED = value;
            }
        }

        [System.ComponentModel.DisplayName("Руководящий отдел")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Руководящий отдел")]
        [System.ComponentModel.Editor(typeof(DepartmentEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Department ManagerDepartment
        {
            get
            {
                if (department.ManagerDepartment != null)
                    return department.ManagerDepartment.Department;
                else
                    return null;
            }
            set
            {
                if (value != null)
                    department.ManagerDepartment = value.Dep;
                else
                    department.ManagerDepartment = null;
            }
        }

        [System.ComponentModel.DisplayName("Дата создания")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата создания отдела")]
        public DateTime dateCreate
        {
            get
            {
                return Convert.ToDateTime(department.dateCreate);
            }
            set
            {
                department.dateCreate = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата расформирования")]
        [System.ComponentModel.Category("Расформирование отдела")]
        [System.ComponentModel.Description("Дата расформирования отдела")]
        public DateTime dateExit
        {
            get
            {
                return Convert.ToDateTime(department.dateExit);
            }
            set
            {
                department.dateExit = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ о создании")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ о создании отдела")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz PrikazBegin
        {
            get
            {
                return department.PrikazBegin;
            }
            set
            {
                department.PrikazBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Приказ о расформировании")]
        [System.ComponentModel.Category("Расформирование отдела")]
        [System.ComponentModel.Description("Приказ о расформировании отдела")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz PrikazEnd
        {
            get
            {
                return department.Prikaz;
            }
            set
            {
                department.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Центр затрат отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Центр затрат отдела")]
        [System.ComponentModel.Editor(typeof(FundingCenterEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FundingCenter FundingCenter
        {
            get
            {
                return department.FundingCenter;
            }
            set
            {
                department.FundingCenter = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер телефона отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Основной номер телефона отдела")]
        public string DepPhoneNumber
        {
            get
            {
                return department.DepPhoneNumber;
            }
            set
            {
                department.DepPhoneNumber = value;
            }
        }

        [System.ComponentModel.DisplayName("Код отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Код отдела")]
        public string DepartmentIndex
        {
            get
            {
                return department.DepartmentIndex;
            }
            set
            {
                department.DepartmentIndex = value;
            }
        }

        [System.ComponentModel.DisplayName("Тип отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Код типа отдела")]
        public int? WorkSheduleToIntSing
        {
            get
            {
                if (department.DepartmentType == null)
                    return null;
                return department.DepartmentType.id;
            }
            set
            {
                if (value == null)
                    department.DepartmentType = null;
                else
                    department.DepartmentType = KadrController.Instance.Model.DepartmentTypes.Where(dt => dt.id == value).SingleOrDefault();
            }
        }
    }
}
