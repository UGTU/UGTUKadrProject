using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections;

namespace Kadr.UI.Common
{
    class CustomBooleanConverter: System.ComponentModel.BooleanConverter
    {
        /*public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                if ((string)value == "Да")
                    return true;
                if ((string)value == "Нет")
                    return false;
            }
            return base.ConvertFrom(context, culture, value);
        }

        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context, CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(Boolean))
            {
                if ((bool)value)
                    return "Да";
                if (!(bool)value)
                    return "Нет";
            }

            return base.ConvertTo(context, culture, value, destinationType);
        }
        public override StandardValuesCollection GetStandardValues(System.ComponentModel.ITypeDescriptorContext context)
        {

            //ArrayList t = new ArrayList(2);
            //t.Add(true, "Да");
            //t.Add(false, "Нет");
            return base.GetStandardValues(null);


        }*/
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context,
          CultureInfo culture,
          object value,
          Type destType)
        {
            return (bool)value ?
              "Да" : "Нет";
        }

        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context,
          CultureInfo culture,
          object value)
        {
            return (string)value == "Да";
        }

    }
}
