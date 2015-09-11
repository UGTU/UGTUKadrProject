using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.UI.Common;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.UI.Dialogs
{
    public partial class FactStaffLinqPropertyGridDialogAdding : PropertyGridDialog 
    {
        public FactStaffLinqPropertyGridDialogAdding()
        {
            InitializeComponent();
        }

        protected override void DoApply()
        {
            UIX.Views.IValidatable validatable = (SelectedObjects[0] as UIX.Views.IValidatable);

            if (validatable != null)
                validatable.Validate();
        }
    }
}
