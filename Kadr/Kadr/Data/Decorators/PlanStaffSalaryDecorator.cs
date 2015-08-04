using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class PlanStaffSalaryDecorator
    {
        private PlanStaffSalary PlanStaffSalary;
        public PlanStaffSalaryDecorator(PlanStaffSalary PlanStaffSalary)
        {
            this.PlanStaffSalary = PlanStaffSalary;
        }

        override public string ToString()
        {
            return "Оклад " + PlanStaffSalary.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код оклада")]
        [System.ComponentModel.ReadOnly(true)]
        //[System.ComponentModel.(true)]
        public int ID
        {
            get
            {
                return PlanStaffSalary.id;
            }
            set
            {
                PlanStaffSalary.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Запись штатного расписания")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Запись штатного расписания")]
        public PlanStaff PlanStaff
        {
            get
            {
                return PlanStaffSalary.PlanStaff;
            }
            set
            {
                PlanStaffSalary.PlanStaff = value;
            }
        }

        [System.ComponentModel.DisplayName("Размер оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Размер индивидуального оклада")]
        //[System.ComponentModel.]
        public decimal SalarySize
        {
            get
            {
                return PlanStaffSalary.SalarySize;
            }
            set
            {
                PlanStaffSalary.SalarySize = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата назначения оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата назначения индивидуального оклада")]
        public DateTime DateBegin
        {
            get
            {
                return Convert.ToDateTime(PlanStaffSalary.DateBegin);
            }
            set
            {
                PlanStaffSalary.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата отмены оклада")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата отмены индивидуального оклада")]
        public DateTime DateEnd
        {
            get
            {
                return Convert.ToDateTime(PlanStaffSalary.DateEnd);
            }
            set
            {
                PlanStaffSalary.DateEnd = value;
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
                return PlanStaffSalary.Prikaz;
            }
            set
            {
                PlanStaffSalary.Prikaz = value;
            }
        }
    }
}
