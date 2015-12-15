using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffTransferDecorator: FactStaffEmployeeReadOnlyDecorator
    {
        public override string ToString()
        {
            return "Прием сотрудника";
        }
        
        public FactStaffTransferDecorator(FactStaff factStaff)
            : base(factStaff)
        {

        }


        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tОсновной договор")]
        [System.ComponentModel.Category("\t\t\tПараметры договора/ доп. соглашения")]
        [System.ComponentModel.Description("Основной договор")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.Browsable(true)]
        //[System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.ContractConvertor))]
        [System.ComponentModel.Editor(typeof(Kadr.UI.Editors.ContractEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public Contract MainContract
        {
            get
            {
                return factStaff.CurrentMainContract;
            }
            set
            {
                factStaff.CurrentMainContract = value;
            }
        }

    }
}


