using Kadr.Data;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class RegionConverter : SimpleToStringConvertor<RegionType>
    {
        
        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
                var res = Kadr.Controllers.KadrController.Instance.Model.RegionTypes.ToList();
                if (res == null)
                    return null;
                List<RegionType> resList = res.ToList();
                resList.Add(Kadr.Data.NullRegionType.Instance);
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
                return NullRegionType.Instance;
            if (value.GetType() == typeof(string))
            {

                RegionType itemSelected = null;
                var c = GetCollection(context);
                foreach (RegionType Item in c)
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
