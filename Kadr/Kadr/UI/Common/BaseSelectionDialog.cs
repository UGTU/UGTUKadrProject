using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.UI.Common
{
    public partial class BaseSelectionDialog : CustomBaseDialog
    {
        public BaseSelectionDialog()
        {
            InitializeComponent();
            ApplyButtonVisible = false;
        }
    }
}
