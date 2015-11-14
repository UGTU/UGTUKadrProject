using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class OK_AdressDecorator
    {
        private OK_Adress address;
        public OK_AdressDecorator(OK_Adress address)
        {
            this.address = address;
        }

        override public string ToString()
        {
            return address.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код адреса")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
        public int idAdress
        {
            get
            {
                return address.idAdress;
            }
            set
            {
                address.idAdress = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\tАдрес")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Адрес")]
        [System.ComponentModel.ReadOnly(false)]
        public string Adress
        {
            get
            {
                return address.Adress;
            }
            set
            {
                address.Adress = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\tДата регистрации")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата регистрации")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateReg
        {
            get
            {
                return Convert.ToDateTime(address.DateReg); 
            }
            set
            {
                address.DateReg = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\tДата завершения регистрации")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата завершения регистрации")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateEnd
        {
            get
            {
                return Convert.ToDateTime(address.DateEnd); 
            }
            set
            {
                address.DateEnd = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\tПрописка")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Является ли адрес пропиской")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.UI.Common.CustomBooleanConverter))]
        public bool RegBit
        {
            get
            {
                return address.RegBit;
            }
            set
            {
                address.RegBit = value;
            }
        }
    }
}
