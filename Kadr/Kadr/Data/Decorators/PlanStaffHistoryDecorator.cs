using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class PlanStaffHistoryDecorator
    {

        private PlanStaffHistory planStaffHistory;
        public PlanStaffHistoryDecorator(PlanStaffHistory planStaffHistory)
        {
            this.planStaffHistory = planStaffHistory;
        }

        override public string ToString()
        {
            return planStaffHistory.ToString();
        }


        [System.ComponentModel.DisplayName("Дата изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Дата изменения записи в штатном расписании")]
        public DateTime DateBegin
        {
            get
            {
                return planStaffHistory.DateBegin;
            }
            set
            {
                planStaffHistory.DateBegin = value;

            }
        }

        [System.ComponentModel.DisplayName("Приказ изменения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Приказ изменения записи в штатном расписании")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return planStaffHistory.Prikaz;
            }
            set
            {
                planStaffHistory.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Новый источник финансирования")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Новый источник финансирования записи в штатном расписании")]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<FinancingSource>))]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.AllFinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public FinancingSource FinancingSource
        {
            get
            {
                return planStaffHistory.FinancingSource;
            }
            set
            {
                planStaffHistory.FinancingSource = value;
            }
        }


        [System.ComponentModel.DisplayName("Количество ставок")]
        [System.ComponentModel.Category("Новые значения атрибутов")]
        [System.ComponentModel.Description("Запланированное количество ставок в штатном расписании")]
        public decimal StaffCount
        {
            get
            {
                return planStaffHistory.StaffCount;
            }
            set
            {
                if (value >= 0.1M)
                {
                    planStaffHistory.StaffCount = value;
                }
                else
                    throw new ApplicationException("Количество ставок не может быть меньше 0,1.");
            }
        }

    }
}
