using Kadr.Data.Converters;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data
{
    class DocumentTypeToStringConvertor : SimpleToStringConvertor<EducDocumentType>
    {
        protected override ICollection GetCollection(ITypeDescriptorContext context)
        {
            IList res = base.GetCollection(context).Cast<EducDocumentType>().Where(x => x!=null).Where(p => !p.isOld).ToList();
            res.Add(NullEducDocumentType.Instance);
            return res;
        }
    }
}
