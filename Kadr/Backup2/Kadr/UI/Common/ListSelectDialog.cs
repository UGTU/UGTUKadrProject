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
    public partial class ListSelectDialog<T> : Form
    {
        public string DisplayMember
        {
            get
            {
                return comboBox1.DisplayMember;
            }
            set
            {
                comboBox1.DisplayMember = value;
            }
        }
        public object DataSource
        {
            get
            {
                return comboBox1.DataSource;
            }
            set
            {
                comboBox1.DataSource = value;
            }
        }
        
        public string QueryText
        {
            get
            {
                return label1.Text;
            }
            set
            {
                label1.Text = value;
            }
        }

        public T SelectedValue
        {
            get
            {
                return (T)comboBox1.SelectedItem;
            }
            set
            {
                comboBox1.SelectedItem = value;
            }
        }

        public ListSelectDialog()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            comboBox1.SelectedItem = null;
        }
    }
}
