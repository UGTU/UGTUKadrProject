using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kadr.UI.Common
{
    public partial class DataGridViewDialog : CustomBaseDialog
    {
        public DataGridViewDialog()
        {
            InitializeComponent();
        }

        public string AddItemCaption
        {
            get
            {
                return bindingNavigator1.AddNewItem.Text;
            }

            set
            {
                bindingNavigator1.AddNewItem.Text = value;
            }
        }

        public string DeleteItemCaption
        {
            get
            {
                return bindingNavigator1.DeleteItem.Text;
            }

            set
            {
                bindingNavigator1.DeleteItem.Text = value;
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            IsModified = true;
        }
        
    }
}

