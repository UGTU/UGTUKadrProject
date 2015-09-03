using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class SocialFareTransitConverter : SimpleToStringConvertor<SocialFareTransit>
    {

        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            if (context.Instance is OK_OtpuskDecorator)
            {
                var res = Kadr.Controllers.KadrController.Instance.Model.SocialFareTransits.Where(x => x.Employee == (context.Instance as OK_OtpuskDecorator).Employee);
                if (res == null)
                    return null;
                List<SocialFareTransit> resList = res.ToList().Where(x => !x.IsUsed).ToList();
                resList.Add(Kadr.Data.NullSocialFareTransit.Instance);
                return resList;
            }
            else
            {
                return Kadr.Controllers.KadrController.Instance.Model.SocialFareTransits.ToArray();
            }
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetCollection(context));
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value)
        {
            if (value == null)
                return NullSocialFareTransit.Instance;
            if (value.GetType() == typeof(string))
            {

                SocialFareTransit itemSelected = null;
                var c = GetCollection(context);
                foreach (SocialFareTransit Item in c)
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


