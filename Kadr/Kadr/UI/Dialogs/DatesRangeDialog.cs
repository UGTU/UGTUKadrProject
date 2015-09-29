using Kadr.UI.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Kadr.UI.Dialogs
{
    public partial class DatesRangeDialog : CustomBaseDialog
    {
        public DatesRangeDialog(DateTime dBegin, DateTime dEnd)
        {
            InitializeComponent();
            ApplyButtonVisible = false;

            this.dBegin.Value = dBegin;
            this.dEnd.Value = dEnd;
        }
    }
}
