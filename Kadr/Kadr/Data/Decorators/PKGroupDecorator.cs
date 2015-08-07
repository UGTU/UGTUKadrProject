using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class PKGroupDecorator
    {
        private PKGroup pkGroup;
        public PKGroupDecorator(PKGroup pkGroup)
        {
            this.pkGroup = pkGroup;
        }

        override public string ToString()
        {
            return pkGroup.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код профессионально-квалификационной группы")]
        [System.ComponentModel.ReadOnly(true)]
        public int ID
        {
            get
            {
                return pkGroup.id;
            }
            set
            {
                pkGroup.id = value;
            }
        }

        [System.ComponentModel.DisplayName("Полное имя профессионально-квалификационной группы")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Полное имя профессионально-квалификационной группы")]
        [System.ComponentModel.ReadOnly(true)]
        public string GroupFullName
        {
            get
            {
                return pkGroup.GroupNumber + " (" + pkGroup.GroupName + ")";
            }
        }
    }
}
