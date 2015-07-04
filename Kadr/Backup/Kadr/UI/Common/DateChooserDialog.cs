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
    public partial class DateChooserDialog : Form
    {
        public DateChooserDialog()
        {
            InitializeComponent();
        }
        public DateTime Value
        {
            get
            {
                return monthCalendar1.SelectionRange.Start;
            }
            set
            {
                monthCalendar1.SelectionRange.Start = value;
                monthCalendar1.SelectionRange.End = value;
            }
        }
    }
}
