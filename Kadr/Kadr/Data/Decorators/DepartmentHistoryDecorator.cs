using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class DepartmentHistoryDecorator
    {
        private DepartmentHistory departmentHistory;
        public DepartmentHistoryDecorator(DepartmentHistory departmentHistory)
        {
            this.departmentHistory = departmentHistory;
        }

        override public string ToString()
        {
            return departmentHistory.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код отдела")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return departmentHistory.id;
            }
            set
            {
                departmentHistory.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Название отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Уникальное название отдела в организации")]
        public string DepartmentName
        {
            get
            {
                return departmentHistory.DepartmentName;
            }
            set
            {
                departmentHistory.DepartmentName = value;
            }
        }

        [System.ComponentModel.DisplayName("Краткое название отдела")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Краткое название отдела в организации")]
        public string DepartmentSmallName
        {
            get
            {
                return departmentHistory.DepartmentSmallName;
            }
            set
            {
                departmentHistory.DepartmentSmallName = value;
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
                if (departmentHistory.Dep1 != null)
                    return departmentHistory.Dep1.Department;
                else
                    return null;
            }
            set
            {
                if (value != null)
                    departmentHistory.Dep1 = value.Dep;
            }
        }

        [System.ComponentModel.DisplayName("Дата изменения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата изменения отдела")]
        public DateTime dateCreate
        {
            get
            {
                return Convert.ToDateTime(departmentHistory.DateBegin);
            }
            set
            {
                departmentHistory.DateBegin = value;
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
                return departmentHistory.Prikaz;
            }
            set
            {
                departmentHistory.Prikaz = value;
            }
        }



    }
}
