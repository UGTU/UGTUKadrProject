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

        [System.ComponentModel.DisplayName("Адрес")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Адрес")]
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

        [System.ComponentModel.DisplayName("Дата регистрации")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата регистрации")]
        public DateTime DateReg
        {
            get
            {
                return address.DateReg.Value;
            }
            set
            {
                address.DateReg = value;
            }
        }

        [System.ComponentModel.DisplayName("Показатель регистрации")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Показатель регистрации")]
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
