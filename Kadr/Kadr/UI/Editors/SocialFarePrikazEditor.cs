using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using Kadr.Controllers;
using Kadr.Data;

namespace Kadr.UI.Editors
{
    class SocialFarePrikazEditor: PrikazEditor
    {
        //приказ на льготный проезд
        protected override PrikazType PrikazType(ITypeDescriptorContext context)
        {
            return MagicNumberController.SocialFareTransitPrikazType;
        }
    }
}
