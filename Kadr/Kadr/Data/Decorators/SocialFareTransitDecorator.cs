using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{

    class SocialFareTransitDecorator
    {

        private SocialFareTransit socialFareTransit;
        public SocialFareTransitDecorator(SocialFareTransit socialFareTransit)
        {
            this.socialFareTransit = socialFareTransit;
        }

        override public string ToString()
        {
            return socialFareTransit.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код приказа в системе")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return socialFareTransit.id;
            }
            set
            {
                socialFareTransit.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата начала периода")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата начала периода")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateBegin
        {
            get
            {
                return socialFareTransit.DateBegin;
            }
            set
            {
                socialFareTransit.DateBegin = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания периода")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата окончания периода")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateEnd
        {
            get
            {
                return socialFareTransit.DateEnd;
            }
            set
            {
                socialFareTransit.DateEnd = value;
            }
        }



    }



}
