using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class FinancingSourceConvertor : SimpleToStringConvertor<FinancingSource>// TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            IList res = Kadr.Controllers.KadrController.Instance.Model.FinancingSources.Where(fs => fs.id < 3).OrderBy(finSource => finSource.FinancingSourceName).ToList();
            res.Add(NullFinancingSource.Instance);
            return res; 
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetCollection(context));
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {

                FinancingSource itemSelected = null;
                var c = GetCollection(context);
                foreach (FinancingSource Item in c)
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


