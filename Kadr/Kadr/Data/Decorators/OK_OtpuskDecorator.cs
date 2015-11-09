using System.Drawing.Design;
using System.Web.Services.Description;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Interfaces;
using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class OK_OtpuskDecorator :  IPrikazTypeProvider
    {
        private OK_Otpusk ok_Otpusk;
        public OK_OtpuskDecorator(OK_Otpusk ok_Otpusk)
        {
            this.ok_Otpusk = ok_Otpusk;
        }

        override public string ToString()
        {
            //return pkCategory.ToString();
            return ok_Otpusk.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код отпуска")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
        public int ID
        {
            get
            {
                return ok_Otpusk.idOtpusk;
            }
            set
            {
                ok_Otpusk.idOtpusk = value;
            }
        }

        [System.ComponentModel.DisplayName("Количество дней")]
        [System.ComponentModel.Category("\tОсновные параметры")]
        [System.ComponentModel.Description("Количество дней отпуска")]
        [System.ComponentModel.ReadOnly(false)]
        public int? CountDay
        {
            get
            {
                return ok_Otpusk.CountDay;
            }
            set
            {
                ok_Otpusk.CountDay = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата начала")]
        [System.ComponentModel.Category("\tОсновные параметры")]
        [System.ComponentModel.Description("Дата начала отпуска")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateBegin
        {
            get
            {
                return ok_Otpusk.RealDateBegin.Value;
            }
            set
            {
                ok_Otpusk.RealDateBegin = value;
                CountDay = (DateEnd - DateBegin).Days + 1;
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания")]
        [System.ComponentModel.Category("\tОсновные параметры")]
        [System.ComponentModel.Description("Дата завершения отпуска")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateEnd
        {
            get
            {
                return ok_Otpusk.RealDateEnd.Value;
            }
            set
            {
                ok_Otpusk.RealDateEnd = value;
                CountDay = (DateEnd - DateBegin).Days + 1;
            }
        }

        [System.ComponentModel.DisplayName("Вид отпуска")]
        [System.ComponentModel.Category("\tОсновные параметры")]
        [System.ComponentModel.Description("Вид отпуска")]
        [System.ComponentModel.ReadOnly(false)]
        //[System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.OK_OtpuskvidConverter))]
        [System.ComponentModel.TypeConverter(typeof(Converters.SimpleToStringConvertor<OK_Otpuskvid>))]
        public OK_Otpuskvid OK_Otpuskvid
        {
            get
            {
                return ok_Otpusk.OK_Otpuskvid;
            }
            set
            {
                ok_Otpusk.OK_Otpuskvid = value;
            }
        }

        [System.ComponentModel.DisplayName("Льготный проезд")]
        [System.ComponentModel.Category("Льготный проезд")]
        [System.ComponentModel.Description("Используемый льготный проезд")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.SocialFareTransitConverter))]
        public SocialFareTransit SocialFareTransit
        {
            get
            {
                return ok_Otpusk.SocialFareTransit;
            }
            set
            {
                if (((value == null) || (value.id == 0)) && (ok_Otpusk.SocialFareTransit != null)) ok_Otpusk.SocialFareTransit.Prikaz = null; 
                ok_Otpusk.SocialFareTransit = value;
                if (value == null) return;
                if ((value.id != 0) && (PrikazLgot == null)) PrikazLgot = ok_Otpusk.Prikaz;
            }
        }

        [System.ComponentModel.DisplayName("Приказ льготного проезда")]
        [System.ComponentModel.Category("Льготный проезд")]
        [System.ComponentModel.Description("Льготный проезд")]
        [System.ComponentModel.ReadOnly(false)]
        //[System.ComponentModel.Editor(typeof(UI.Editors.SocialFarePrikazEditor), typeof(UITypeEditor))]
        public Prikaz PrikazLgot
        {
            get { return (ok_Otpusk.SocialFareTransit != null)?ok_Otpusk.SocialFareTransit.Prikaz:null; }
            set
            {
                if (value == null) return;
                if ((ok_Otpusk.SocialFareTransit != null) && (ok_Otpusk.SocialFareTransit.id != 0)) ok_Otpusk.SocialFareTransit.Prikaz = value;
                else MessageBox.Show("Сначала укажите льготный проезд.");
            }
        }


        [System.ComponentModel.DisplayName("Приказ")]
        [System.ComponentModel.Category("\tОсновные параметры")]
        [System.ComponentModel.Description("Приказ")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz Prikaz
        {
            get
            {
                return ok_Otpusk.RealPrikaz;
            }
            set
            {
                ok_Otpusk.RealPrikaz = value;
                ok_Otpusk.Prikaz = value;
            }
        }


        [System.ComponentModel.DisplayName("Сотрудник")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Сотрудник")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
        public Employee Employee
        {
            get
            {
                return ok_Otpusk.RealFactStaff.Employee;
            }
            set
            {
                ok_Otpusk.RealFactStaff.Employee = value;
            }
        }

        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.ReadOnly(true)]
        public PrikazType PrikazType
        {
            get { return MagicNumberController.OtpuskPrikazType;  }
        }
    }

}
