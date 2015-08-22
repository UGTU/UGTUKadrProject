using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class BonusHistoryDecorator
    {

        private BonusHistory bonusHistory;
        public BonusHistoryDecorator(BonusHistory bonusHistory)
        {
            this.bonusHistory = bonusHistory;
        }

        override public string ToString()
        {
            return bonusHistory.ToString();
        }


        [System.ComponentModel.DisplayName("Дата назначения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Дата назначения/изменения надбавки")]
        public DateTime DateBegin
        {
            get
            {
                return bonusHistory.DateBegin;
            }
            set
            {
                bonusHistory.DateBegin = value;

            }
        }

        [System.ComponentModel.DisplayName("Приказ назначения")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Приказ назначения/изменения надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return bonusHistory.Prikaz;
            }
            set
            {
                //bonusHistory.Prikaz = value;
                bonusHistory.Prikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Источник финансирования")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Источник финансирования надбавки")]
        //[System.ComponentModel.Editor(typeof(Kadr.UI.Editors.AllFinancingSourceEditor), typeof(System.Drawing.Design.UITypeEditor))]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SimpleToStringConvertor<FinancingSource>))]
        public FinancingSource FinancingSource
        {
            get
            {
                return bonusHistory.FinancingSource;
            }
            set
            {
                bonusHistory.FinancingSource = value;
            }
        }

        [System.ComponentModel.DisplayName("Размер надбавки")]
        [System.ComponentModel.Category("Основные атрибуты изменения")]
        [System.ComponentModel.Description("Новый размер надбавки")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public decimal BonusCount
        {
            get
            {
                return bonusHistory.BonusCount;
            }
            set
            {
                bonusHistory.BonusCount = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид изменяемой надбавки")]
        [System.ComponentModel.Category("Основные атрибуты надбавки")]
        [System.ComponentModel.Description("Вид изменяемой надбавки")]
        [System.ComponentModel.ReadOnly(true)]
        public BonusType BonusType
        {
            get
            {
                return bonusHistory.Bonus.BonusType;
            }
        }

        /* [System.ComponentModel.DisplayName("Дата назначения надбавки")]
         [System.ComponentModel.Category("Основные атрибуты надбавки")]
         [System.ComponentModel.Description("Первоначальная дата назначения надбавки")]
         [System.ComponentModel.ReadOnly(true)]
         public DateTime da
         {
             get
             {
                 return Convert.ToDateTime(bonusHistory.Bonus.DateBegin);
             }
         }*/
    }
}
