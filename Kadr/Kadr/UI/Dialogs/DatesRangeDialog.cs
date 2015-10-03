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

        private void dBegin_ValueChanged(object sender, EventArgs e)
        {
            if (dBegin.Value > dEnd.Value)
            {
                MessageBox.Show("Дата начала не может быть позже даты окончания!");
                dBegin.Value = dEnd.Value;
            }
        }

        private void dEnd_ValueChanged(object sender, EventArgs e)
        {
            if (dBegin.Value > dEnd.Value)
            {
                MessageBox.Show("Дата окончания не может быть раньше даты начала!");
                dEnd.Value = dBegin.Value;
            }
        }
    }
}
