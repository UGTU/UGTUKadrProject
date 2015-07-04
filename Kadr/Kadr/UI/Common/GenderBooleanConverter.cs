using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Collections;

namespace Kadr.UI.Common
{
    class GenderBooleanConverter : System.ComponentModel.BooleanConverter
    {
        public override object ConvertTo(System.ComponentModel.ITypeDescriptorContext context,
          CultureInfo culture,
          object value,
          Type destType)
        {
            return (bool)value ?
              "Мужской" : "Женский";
        }

        public override object ConvertFrom(System.ComponentModel.ITypeDescriptorContext context,
          CultureInfo culture,
          object value)
        {
            return (string)value == "Мужской";
        }

    }
}
