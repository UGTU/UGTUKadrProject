using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class FactStaffMainBaseDecorator: FactStaffBaseDecorator
    {
        public FactStaffMainBaseDecorator(FactStaff factStaff)
            : base(factStaff)
        {

        }

        #region ContractData
        [System.ComponentModel.DisplayName("\t\t\t\t\t\t\t\tОсновной договор")]
        [System.ComponentModel.Category("\t\t\tПараметры договора")]
        [System.ComponentModel.Description("Основной договор")]
        [System.ComponentModel.ReadOnly(false)]
        [System.ComponentModel.TypeConverter(typeof(Kadr.Data.Converters.ContractConvertor))]
        public Contract MainContract
        {
            get
            {
                return factStaff.MainContract;
            }
            set
            {
                factStaff.MainContract = value;
            }
        }

        [System.ComponentModel.DisplayName("\t\t\t\tНомер договора")]
        [System.ComponentModel.Category("\t\t\tПараметры договора")]
        [System.ComponentModel.Description("Номер договора")]
        [System.ComponentModel.ReadOnly(false)]
        public string CurrentContractName
        {
            get
            {
                if (factStaff.CurrentContract != null)
                    return factStaff.CurrentContract.ContractName;
                else
                    return null;
            }
            set
            {
                if (value != null)
                {
                    if (factStaff.CurrentContract != null)
                        factStaff.CurrentContract.ContractName = value;
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата договора")]
        [System.ComponentModel.Category("\t\t\tПараметры договора")]
        [System.ComponentModel.Description("Дата составления договора")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateContract
        {
            get
            {
                if (factStaff.CurrentContract != null)
                    return Convert.ToDateTime(factStaff.CurrentContract.DateContract);
                else
                    return DateTime.MinValue;
            }
            set
            {
                if ((value != null) && (value != DateTime.MinValue))
                {
                    if (factStaff.CurrentContract != null)
                        factStaff.CurrentContract.DateContract = value;
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата начала договора")]
        [System.ComponentModel.Category("\t\t\tПараметры договора")]
        [System.ComponentModel.Description("Дата начала действия договора")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateBegin
        {
            get
            {
                if (factStaff.CurrentContract != null)
                    return Convert.ToDateTime(factStaff.CurrentContract.DateBegin);
                else
                    return DateTime.MinValue;
            }
            set
            {
                if ((value != null) && (value != DateTime.MinValue))
                {
                    if (factStaff.CurrentContract != null)
                        factStaff.CurrentContract.DateBegin = value;
                }
            }
        }

        [System.ComponentModel.DisplayName("Дата окончания договора")]
        [System.ComponentModel.Category("\t\t\tПараметры договора")]
        [System.ComponentModel.Description("Дата окончания действия договора")]
        [System.ComponentModel.ReadOnly(false)]
        public DateTime DateEnd
        {
            get
            {
                if (factStaff.CurrentContract != null)
                    return Convert.ToDateTime(factStaff.CurrentContract.DateEnd);
                else
                    return DateTime.MinValue;
            }
            set
            {
                if ((value != null) && (value != DateTime.MinValue))
                {
                    if (factStaff.CurrentContract != null)
                        factStaff.CurrentContract.DateEnd = value;
                }
            }
        }
        #endregion


        
    }
}
