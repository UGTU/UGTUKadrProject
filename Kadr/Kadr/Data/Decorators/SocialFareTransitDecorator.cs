﻿using System;
using System.Collections.Generic;
using System.Drawing.Design;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using Kadr.Interfaces;

namespace Kadr.Data
{

    class SocialFareTransitDecorator : IPrikazTypeProvider
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
        [System.ComponentModel.Browsable(false)]
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
                if ((value != null) && (value != DateTime.MinValue))
                {
                    socialFareTransit.DateEnd = value.AddYears(SocialFareTransit.SocialFareLength).AddDays(-1);
                }
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

        /*
        [System.ComponentModel.DisplayName("Приказ на использование")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Приказ, согласно которому был использован льготный проезд")]
        [System.ComponentModel.Editor(typeof(UI.Editors.PrikazEditor), typeof(UITypeEditor))]
        [System.ComponentModel.ReadOnly(true)]
        public Prikaz PrikazLgot
        {
            get { return socialFareTransit.Prikaz; }
            set { socialFareTransit.Prikaz = value; }
        }
          */

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.ReadOnly(true)]
        public PrikazType PrikazType
        {
            get { return MagicNumberController.SocialFareTransitPrikazType; } 
        }
    }



}
