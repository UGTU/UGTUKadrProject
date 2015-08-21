using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.Data.Converters
{
    class FinancingSourceConvertor : SimpleToStringConvertor<FinancingSource>// TypeConverter
    {
        public override bool GetStandardValuesSupported(ITypeDescriptorContext context)
        {
            return true;
        }

        private ICollection GetCollection(System.ComponentModel.ITypeDescriptorContext context)
        {
            return Kadr.Controllers.KadrController.Instance.Model.FinancingSources.Where(fs => fs.id < 3).OrderBy(finSource => finSource.FinancingSourceName).ToArray();
        }
    }
}


