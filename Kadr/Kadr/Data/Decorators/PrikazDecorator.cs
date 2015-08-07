using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class PrikazDecorator
    {

        private Prikaz prikaz;
        public PrikazDecorator(Prikaz prikaz)
        {
            this.prikaz = prikaz;
        }

        override public string ToString()
        {
            return "Приказ " + prikaz.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код приказа в системе")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return prikaz.id;
            }
            set
            {
                prikaz.id = value;
            }
        }


        [System.ComponentModel.DisplayName("Название приказа")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Название приказа")]
        public string PrikazName
        {
            get
            {
                return prikaz.PrikazName;
            }
            set
            {
                prikaz.PrikazName = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата вступления в силу")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата вступления приказа в силу")]
        public DateTime DatePrikaz
        {
            get
            {
                return Convert.ToDateTime(prikaz.DatePrikaz);
            }
            set
            {
                prikaz.DatePrikaz = value;
            }
        }

        [System.ComponentModel.DisplayName("Вид приказа")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Вид приказа")]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazTypeEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.PrikazType PrikazType
        {
            get
            {
                return prikaz.PrikazType;
            }
            set
            {
                prikaz.PrikazType = value;
            }
        }


    }
}
