using Kadr.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kadr.Interfaces
{
    interface IPrikazTypeProvider
    {
        [System.ComponentModel.Browsable(false)]
        [System.ComponentModel.ReadOnly(true)]
        PrikazType PrikazType { get; }
    }
}
