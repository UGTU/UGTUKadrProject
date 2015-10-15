using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{

    class AwardLevelConverter : SimpleToStringConvertor<AwardLevel>
    {
        protected override ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            ICollection<AwardLevel> col = base.GetCollection(context) as ICollection<AwardLevel>;
            col.Add(NullAwardLevel.Instance);
            return (ICollection)col;
        }
    }
}
