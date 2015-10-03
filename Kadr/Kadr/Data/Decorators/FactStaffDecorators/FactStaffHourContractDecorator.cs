using Kadr.Controllers;
using Kadr.UI.Editors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffHourContractDecorator : FactStaffHourBaseDecorator
    {
        public FactStaffHourContractDecorator(FactStaff factStaff)
            : base(factStaff)
        {
        }



        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\t\t\t\tCотрудник договора")]
        [System.ComponentModel.Category("\t\t\t\t\t\tОсновные параметры")]
        [System.ComponentModel.Description("Сотрудник, для которого указывается договор")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.FactStaffEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Kadr.Data.FactStaffCurrentMainData MainFactStaff
        {
            get
            {
                return factStaff.MainFactStaffData;
            }
            set
            {
                if (value != null)
                    factStaff.MainFactStaff = KadrController.Instance.Model.FactStaffs.Where(fcSt => fcSt.id == value.id).SingleOrDefault();
            }
        }
    }
}
