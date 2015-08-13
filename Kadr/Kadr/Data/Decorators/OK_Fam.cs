using Kadr.Data.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{

    class OK_FamDecorator
    {
        private OK_Fam famMember;
        public OK_FamDecorator(OK_Fam famMember)
        {
            this.famMember = famMember;
        }

        override public string ToString()
        {
            return famMember.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код родственника")]
        [System.ComponentModel.ReadOnly(true)]
        //[System.ComponentModel.Browsable(false)]
        public int idfam
        {
            get
            {
                return famMember.idfam;
            }
            set
            {
                famMember.idfam = value;
            }
        }

        [System.ComponentModel.DisplayName("Степень родства")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Стeпень родства")]
        [System.ComponentModel.TypeConverter(typeof(SimpleToStringConvertor<OK_MembFam>))]
        public OK_MembFam OK_MembFam
        {
            get
            {
                return famMember.OK_MembFam;
            }
            set
            {
                famMember.OK_MembFam = value;
            }
        }

        [System.ComponentModel.DisplayName("ФИО родственника")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("ФИО родственника")]
        public string fiomembfam
        {
            get
            {
                return famMember.fiomembfam;
            }
            set
            {
                famMember.fiomembfam = value;
            }
        }

        [System.ComponentModel.DisplayName("Дата/год рождения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата/год рождения")]
        public string godbirth
        {
            get
            {
                return famMember.godbirth;
            }
            set
            {
                famMember.godbirth = value;
            }
        }


    }

}
