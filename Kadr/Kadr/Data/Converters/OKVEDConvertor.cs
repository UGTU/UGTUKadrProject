using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class OKVEDConvertor : SimpleToStringConvertor<OKVED>
    {

        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
                var res = Kadr.Controllers.KadrController.Instance.Model.OKVEDs;
                if (res == null)
                    return null;
                List<OKVED> resList = res.ToList();
                resList.Add(Kadr.Data.NullOKVED.Instance);
                return resList;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetCollection(context));
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value)
        {
            if (value == null)
                return NullOKVED.Instance;
            if (value.GetType() == typeof(string))
            {

                OKVED itemSelected = null;
                var c = GetCollection(context);
                foreach (OKVED Item in c)
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




