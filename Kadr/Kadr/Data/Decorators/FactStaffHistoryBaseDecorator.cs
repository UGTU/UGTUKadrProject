using Kadr.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHistoryBaseDecorator
    {
        protected FactStaffHistory factStaffHistory;
        public FactStaffHistoryBaseDecorator(FactStaffHistory factStaffHistory)
        {
            this.factStaffHistory = factStaffHistory;
        }

        override public string ToString()
        {
            return factStaffHistory.ToString();
        }


        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\tДата назначения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Дата назначения на должность")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateBegin
        {
            get
            {
                return factStaffHistory.DateBegin;
            }
            set
            {
                factStaffHistory.DateBegin = value;

            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\tПриказ назначения")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Приказ назначения на должность")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.PrikazEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Prikaz PrikazBegin
        {
            get
            {
                return factStaffHistory.Prikaz;
            }
            set
            {
                factStaffHistory.Prikaz = value;
            }
        }


 

    }
}

