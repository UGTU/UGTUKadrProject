using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.Interfaces;

namespace Kadr.UI.Editors
{
    //приказ на удаление
    class FiredPrikazEditor : PrikazEditor
    {
        protected override PrikazType PrikazType(ITypeDescriptorContext context)
        {
            return MagicNumberController.FiredPrikazType;
        }
    }
}
