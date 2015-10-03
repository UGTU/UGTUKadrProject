using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class SalaryKoeffConvertor : SimpleToStringConvertor<SalaryKoeff>
    {

        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
                var res = Kadr.Controllers.KadrController.Instance.Model.SalaryKoeffs.OrderBy(x => x.PKSubSubCategoryNumber);
                if (res == null)
                    return null;
                List<SalaryKoeff> resList = res.ToList();
                resList.Add(NullSalaryKoeff.Instance);
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
                return NullSalaryKoeff.Instance;
            if (value.GetType() == typeof(string))
            {

                SalaryKoeff itemSelected = null;
                var c = GetCollection(context);
                foreach (SalaryKoeff Item in c)
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

