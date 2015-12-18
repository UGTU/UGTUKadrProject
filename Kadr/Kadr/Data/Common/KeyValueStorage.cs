using Kadr.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Common
{
    public class KeyValueStorage : IKeyValueStorage
    {
        //4git
        private Hashtable records = new Hashtable();

        public object GetValue(object key)
        {
            return records[key];
        }

        public void Store(object key, object value)
        {
            if (records.ContainsKey(key))
                records[key] = value;
            else records.Add(key, value);

        }
    }
}
