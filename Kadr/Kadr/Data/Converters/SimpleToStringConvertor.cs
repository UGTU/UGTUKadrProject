using Kadr.Interfaces;
using Kadr.Controllers;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Kadr.Data.Common;
using Kadr.Properties;

namespace Kadr.Data.Converters
{
    class SimpleToStringConvertor<T> : TypeConverter
        where T:class
    {
        protected ICollection col = null;

        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            col = null;
            return true;

        }

        protected virtual ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            if (col != null) return col;

            var table = KadrController.Instance.Model.GetTable<T>() as IQueryable<T>;            
            
            // реализуй IOrderInformer для своего контекста (например, декоратора), чтобы передать названия полей для сортировки — и конвертер отсортирует сам
            if (context.Instance is IOrderInformer)
            {             

                var orderProps = (context.Instance as IOrderInformer).GetOrderProperties(typeof(T));

                if (orderProps!=null)
                    for (var i=orderProps.Length-1; i>=0; i--)
                    {
                        var s = orderProps[i];
                        table = table.OrderBy(x => x.GetType().GetProperty(s).GetValue(x, null));
                    }
                col = table.ToList<T>();
            }
            else
            {
                col = table.ToList();
                if (typeof(IComparable).IsAssignableFrom(typeof(T)))    
                (col as List<T>).Sort();
            }

            //Для пункта "(Не задано)"

            if (col.Count>0)
            if (typeof(INullable).IsAssignableFrom(typeof(T)))
                (col as List<T>).Add((T)((col as List<T>)[0] as INullable).GetNullInstance());

                return col;


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
            if (destinationType == typeof(string) && value is T)
            {
                T item = (T)value;
                return item.ToString();
            }

            if (destinationType == typeof(string) && value == null)
               return Settings.Default.NullName; 

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
                if ((string)value == Settings.Default.NullName) return itemSelected;

                foreach (T Item in GetCollection(context))
                {
                    if (Item != null)
                    {
                        string ItemName = Item.ToString();

                        if (ItemName.Equals((string)value))
                        {
                            itemSelected = Item;
                        }
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
