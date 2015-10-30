using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class OK_ReasonConvertor : SimpleToStringConvertor<OK_Reason>
    {

        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            var res = Kadr.Controllers.KadrController.Instance.Model.OK_Reasons.Where(x => !x.is_old.Value).OrderBy(y=>y.reasonname);
            if (res == null)
                return null;
            List<OK_Reason> resList = res.ToList();
            resList.Add(NullOK_Reason.Instance);
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
                return NullOK_Reason.Instance;

            if (value.GetType() == typeof(string))
            {

                OK_Reason itemSelected = null;
                var c = GetCollection(context);
                foreach (OK_Reason Item in c)
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

