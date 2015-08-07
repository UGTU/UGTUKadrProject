using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{

    class OK_DopInfDecorator
    {
        private OK_DopInf dopInf;
        public OK_DopInfDecorator(OK_DopInf dopInf)
        {
            this.dopInf = dopInf;
        }

        override public string ToString()
        {
            return dopInf.ToString();
        }

        [System.ComponentModel.DisplayName("ID")]
        [System.ComponentModel.Category("Атрибуты")]
        [System.ComponentModel.Description("Уникальный код записи дополнительных сведений")]
        [System.ComponentModel.ReadOnly(true)]
        [System.ComponentModel.Browsable(false)]
        public int idDopInf
        {
            get
            {
                return dopInf.idDopInf;
            }
            set
            {
                dopInf.idDopInf = value;
            }
        }

        [System.ComponentModel.DisplayName("Дополнительные сведения")]
        [System.ComponentModel.Category("Основные параметры")]
        [System.ComponentModel.Description("Дополнительные сведения")]
        public string DopInf
        {
            get
            {
                return dopInf.DopInf;
            }
            set
            {
                dopInf.DopInf = value;
            }
        }


    }


}
