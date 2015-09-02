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
        [System.ComponentModel.ReadOnly(false)]
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
        [System.ComponentModel.ReadOnly(false)]
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

        [System.ComponentModel.DisplayName("Дата рождения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дата рождения")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime BirthDate
        {
            get
            {
                if (famMember.BirthDate == null)
                    return DateTime.Today;
                else
                    return famMember.BirthDate.Value;
            }
            set
            {
                famMember.BirthDate = value;
                if (value != null)
                    famMember.BirthYear = value.Year;
            }
        }

        [System.ComponentModel.DisplayName("Год рождения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Год рождения")]
        [System.ComponentModel.ReadOnly(false)]
        public int? BirthYear
        {
            get
            {
                return famMember.BirthYear;
            }
            set
            {
                famMember.BirthYear = value;
            }
        }

        /*[System.ComponentModel.DisplayName("Год рождения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Год рождения ")]
        [System.ComponentModel.ReadOnly(false)]
        public int? BirthYear
        {
            get
            {
                return famMember.BirthYear;
            }
            set
            {
                famMember.BirthYear = value;
            }
        }*/

    }

}
