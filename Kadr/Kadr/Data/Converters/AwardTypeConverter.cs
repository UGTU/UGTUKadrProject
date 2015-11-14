using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class AwardTypeConverter : SimpleToStringConvertor<AwardType>
    {
        protected override ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            ICollection<AwardType> col = base.GetCollection(context) as ICollection<AwardType>;
            col.Add(NullAwardType.Instance);
            return (ICollection)col;
        }
    }
}
