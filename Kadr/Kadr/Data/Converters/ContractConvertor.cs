using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class ContractConvertor : SimpleToStringConvertor<Contract>
    {

        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            if (context.Instance is FactStaffDecorator)
            {
                //выбираем только договоры (без доп соглашений)
                var res = Kadr.Controllers.KadrController.Instance.Model.Contracts.Where(x => x.idMainContract == null).Where(x => x.FactStaffHistories.Count > 0).Where(x =>
                    x.FactStaffHistories.FirstOrDefault().FactStaff.Employee == (context.Instance as FactStaffDecorator).Employee);
                if (res == null)
                    return null;
                List<Contract> resList = res.ToList();
                //resList.Add(Kadr.Data.NullSocialFareTransit.Instance);
                return resList;
            }
            else
            {
                return Kadr.Controllers.KadrController.Instance.Model.Contracts.ToArray();
            }
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetCollection(context));
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value)
        {
            /*if (value == null)
                return NullSocialFareTransit.Instance;*/
            if (value.GetType() == typeof(string))
            {

                Contract itemSelected = null;
                var c = GetCollection(context);
                foreach (Contract Item in c)
                {
                    string ItemName = Item.ToString();

                    if (ItemName.Equals((string)value))
                    {
                        itemSelected = Item;
                    }
                }
                return itemSelected;
            }
            else
                return base.ConvertFrom(context, culture, value);
        }

 
    }
}


