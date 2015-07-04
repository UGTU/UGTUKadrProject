using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APG.UI
{
    public partial class UserLoginDialog : Form
    {
        public bool UseWindowsAuthentification
        {
            get 
            {
                return checkBox1.Checked;
            }
            set
            {
                SetAuthentificationMode(value);
            }
        }
        public string LoginName
        {
            get
            {
                return loginTextBox.Text;
            }
        }

        public string Password
        {
            get
            {
                return passwordTextBox.Text;
            }
        }
        public string DatabaseName
        {
            get
            {
                return dataBaseNameTextBox.Text;
            }
        }
        public string DataSource
        {
            get
            {
                return dataSourceTextBox.Text;
            }

        }


        private void SetAuthentificationMode(bool value)
        {
            if (value)
                SetWindowsCred();

            SetTextBoxEnabed();
            checkBox1.Checked = value;
        }

        private void SetTextBoxEnabed()
        {
            loginTextBox.Enabled = !UseWindowsAuthentification;
            passwordTextBox.Enabled = !UseWindowsAuthentification;
        }

        public UserLoginDialog()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            UseWindowsAuthentification = ((sender as CheckBox).Checked);
        }
                    
        private void SetWindowsCred()
        {
            loginTextBox.Text = System.Security.Principal.WindowsIdentity.GetCurrent().Name;
        }

        private void UserLoginDialog_Load(object sender, EventArgs e)
        {
            SetAuthentificationMode(checkBox1.Checked);
        }

        private void UserLoginDialog_FormClosed(object sender, FormClosedEventArgs e)
        {
            Properties.Settings.Default.Save();
        }
    }
}
