using Kadr.Interfaces;
using Kadr.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class SimpleToStringConvertor<T> : TypeConverter
        where T:class
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            ICollection collection;

            // реализуй IOrderInformer для своего контекста (например, декоратора), чтобы передать названия полей для сортировки — и конвертер отсортирует сам
            if (context.Instance is IOrderInformer)
            {
                List<T> tmp = KadrController.Instance.Model.GetTable<T>().ToList();

                string[] OrderProps = (context.Instance as IOrderInformer).GetOrderProperties(typeof(T));

                if (OrderProps!=null)
                    for (int i=OrderProps.Length-1; i>=0; i--)
                    {
                        string s = OrderProps[i];
                        tmp = tmp.OrderBy(x => x.GetType().GetProperty(s).GetValue(x,null)).ToList();
                    }

                collection = tmp;
            }
            else
            {
                var l = KadrController.Instance.Model.GetTable<T>().ToList();
                if (typeof(IComparable).IsAssignableFrom(typeof(T)))
                    l.Sort();
                collection = l;
            }
            
            return collection;
        }

        public override TypeConverter.StandardValuesCollection GetStandardValues(ITypeDescriptorContext context)
        {
            return new StandardValuesCollection(GetCollection(context));
        }


        public override bool CanConvertTo(ITypeDescriptorContext context, Type destinationType)
        {
            if (destinationType.Equals(typeof(string)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public override object ConvertTo(ITypeDescriptorContext context,
       System.Globalization.CultureInfo culture, object value, Type destinationType)
        {
            if (destinationType == typeof(string) && value is AwardType)
            {
                T item = (T)value;
                return item.ToString();
            }
            return base.ConvertTo(context, culture, value, destinationType);
        }

        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType.Equals(typeof(string)))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public override object ConvertFrom(ITypeDescriptorContext context,
        System.Globalization.CultureInfo culture, object value)
        {
            if (value.GetType() == typeof(string))
            {
                T itemSelected = null;

                foreach (T Item in GetCollection(context))
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

        public override bool GetStandardValuesExclusive(ITypeDescriptorContext context)
        {
            return true;
        }

    }
}
