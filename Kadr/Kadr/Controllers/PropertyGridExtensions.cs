using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;

namespace Kadr.Controllers
{
    public static class PropertyGridExtensions
    {
        public static void SetPropertyReadOnly<T, TU>(this T obj, Expression<Func<TU>> propertySelector, bool value) where T : class
        {
            var body = propertySelector.Body as MemberExpression;
            Debug.Assert(body != null, "body != null");
            var descriptor = TypeDescriptor.GetProperties(obj.GetType())[body.Member.Name];
            var attribute = (ReadOnlyAttribute)descriptor.Attributes[typeof(ReadOnlyAttribute)];
            var fieldToChange = attribute.GetType().GetField("isReadOnly",
                                             BindingFlags.NonPublic |
                                             BindingFlags.Instance);
            Debug.Assert(fieldToChange != null, "fieldToChange != null");
            fieldToChange.SetValue(attribute, value);
        }
    }
}
