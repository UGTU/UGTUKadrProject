using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;

namespace APG.Data
{
    public static class BindingSourceHelper
    {
        public static int FindPosition(BindingSource bindingSource, string key, object value)
        {
            CheckBindingSource(bindingSource); 
            
            if (value == null)
                throw new ArgumentNullException("value", "Параметр value не может быть null.");
            if ((key == null) || (key == string.Empty))
                throw new ArgumentNullException("key", "Параметр key не может быть null или пустой строкой.");
            if (!bindingSource.SupportsSearching)
                throw new ArgumentException("Указанный источник не поддерживает операцию поиска.");

            PropertyDescriptorCollection pdc = bindingSource.CurrencyManager.GetItemProperties();
            return  bindingSource.Find(pdc[key], value);                       
        }

        private static void CheckBindingSource(BindingSource bindingSource)
        {
            if (bindingSource == null)
                throw new ArgumentNullException("bindingSource", "Параметр bindingSource не может быть null.");

        }

        public static void GotoPosition(BindingSource bindingSource, string key, object value)
        {
            int pos = FindPosition(bindingSource, key, value);
            if (pos == -1) throw new ArgumentException("Заданная позиция не найдена в источнике.");
            bindingSource.Position = pos;
        }

        public static T GetCurrentDataRowViewValue<T>(BindingSource bindingSource, string key)
        {
            CheckBindingSource(bindingSource);
            if (!(CurrentDataRowView(bindingSource)))
                throw new ArgumentException("Метод поддерживает операции только с типом элемента DataRowView.");
            System.Data.DataRowView drv = bindingSource.Current as System.Data.DataRowView;
            return (T)drv[key];         
        }

        public static bool CurrentDataRowView(BindingSource bindingSource)
        {
            return bindingSource.Current is System.Data.DataRowView;
        }

        public static void GotoSameDataRowViewPosition(BindingSource source, BindingSource target, string sourceKey, string targetKey)
        {            
            GotoPosition(target, targetKey, GetCurrentDataRowViewValue<object>(source, sourceKey));
        }
    }
}
