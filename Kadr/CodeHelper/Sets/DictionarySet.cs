using System;
using System.Collections.Generic;
using System.Text;

namespace APG.CodeHelper.Sets
{
    /// <summary>
    /// Множество на базе словаря
    /// </summary>
    /// <typeparam name="TKey"></typeparam>
    /// <typeparam name="TValue"></typeparam>
    public class DictionarySet<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /// <summary>
        /// Находит перессечение двух можеств
        /// </summary>
        /// <param name="dictionarySet1">Первое множество</param>
        /// <param name="dictionarySet2">Второе множество</param>
        /// <returns>Пересечение множеств</returns>
        public static DictionarySet<TKey, TValue> operator *
            (DictionarySet<TKey, TValue> dictionarySet1,
            DictionarySet<TKey, TValue> dictionarySet2)
        {
            DictionarySet<TKey, TValue> result = new DictionarySet<TKey, TValue>();
            foreach (KeyValuePair<TKey, TValue> keyPair in dictionarySet2)
            {
                if (dictionarySet1.ContainsKey(keyPair.Key))
                    result.Add(keyPair.Key, keyPair.Value);
            }
            return result;
        }
        /// <summary>
        /// Находит объеденение двух множеств
        /// </summary>
        /// <param name="dictionarySet1">Первое множество</param>
        /// <param name="dictionarySet2">Второе множество</param>
        /// <returns>Объеденение множеств</returns>
        public static DictionarySet<TKey, TValue> operator +
            (DictionarySet<TKey, TValue> dictionarySet1,
            DictionarySet<TKey, TValue> dictionarySet2)
        {
            DictionarySet<TKey, TValue> result = new DictionarySet<TKey, TValue>();
            
            foreach (KeyValuePair<TKey, TValue> keyPair in dictionarySet2)
            {
                result.Add(keyPair.Key, keyPair.Value);
            }
            foreach (KeyValuePair<TKey, TValue> keyPair in dictionarySet1)
            {
                result.Add(keyPair.Key, keyPair.Value);
            }

            return result;
        }
    }
}
