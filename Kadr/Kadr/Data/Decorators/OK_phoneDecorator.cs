using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class OK_phoneDecorator
    {
        private OK_phone phone;
        public OK_phoneDecorator(OK_phone phone)
        {
            this.phone = phone;
        }

        override public string ToString()
        {
            return phone.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код телефона")]
        [System.ComponentModel.ReadOnly(true)]
        public int idphone
        {
            get
            {
                return phone.idphone;
            }
            set
            {
                phone.idphone = value;
            }
        }

        [System.ComponentModel.DisplayName("Номер телефона")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Номер телефона")]
        [System.ComponentModel.ReadOnly(false)]
        public string phoneNumber
        {
            get
            {
                return phone.phone;
            }
            set
            {
                phone.phone = value;
            }
        }
    }

}
