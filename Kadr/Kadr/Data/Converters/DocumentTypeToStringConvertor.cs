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
            return base.GetCollection(context).Cast<EducDocumentType>().Where(x => !x.isOld).ToList();
        }
    }
}
