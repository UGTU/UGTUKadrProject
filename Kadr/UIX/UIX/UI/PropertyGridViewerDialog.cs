using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UIX.UI
{
    public partial class PropertyGridViewerDialog : Form
    {
        public string OkButtonText
        {
            get { return OKBtn.Text; }
            set { OKBtn.Text = value; }
        }
        public string CancelButtonText
        {
            get { return CancelBtn.Text; }
            set { CancelBtn.Text = value; }
        }

        public object SelectedObject
        {
            get { return commandPropertyGrid1.SelectedObject; }
            set
            {
                if (commandPropertyGrid1.SelectedObject == value) return;
                commandPropertyGrid1.SelectedObject = value;
                Text = commandPropertyGrid1.SelectedObject?.ToString();
            }
        }

        public PropertyGridViewerDialog()
        {
            InitializeComponent();            
        }

        private void PropertyGridViewerDialog_Load(object sender, EventArgs e)
        {
            Visible = true;
            commandPropertyGrid1.LabelColWidth = commandPropertyGrid1.Width/4;
        }
    }
}
