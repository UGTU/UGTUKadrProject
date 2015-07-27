﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.UI.Forms
{
    public partial class SocialFareTransitForm : Form
    {
        public Employee Employee
        {
            get;
            set;
        }
        
        public SocialFareTransitForm()
        {
            InitializeComponent();
        }

        private void SocialFareTransitForm_Load(object sender, EventArgs e)
        {
            Text = "ЛЬготный проезд " + Employee;
        }
    }
}
