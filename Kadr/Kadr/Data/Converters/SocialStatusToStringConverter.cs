using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
class SocialStatusToStringConverter : SimpleToStringConvertor<OK_SocialStatus>
    {
        protected override ICollection GetCollection(ITypeDescriptorContext context)
        {
            return base.GetCollection(context).Cast<OK_SocialStatus>().Where(x => (bool)!x.is_old).ToList();
        }
    }
}
