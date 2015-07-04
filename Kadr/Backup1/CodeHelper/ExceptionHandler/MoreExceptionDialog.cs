using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APG.CodeHelper.ExceptionHandler
{
    public partial class MoreExceptionDialog : Form
    {

        private Exception exception;

        public Exception E
        {
            get
            {
                return exception;
            }
        }

        public MoreExceptionDialog(Exception exception)
        {
            this.exception = exception;
            InitializeComponent();
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ISGBMoreExceptionDialog_Load(object sender, EventArgs e)
        {
            propertyGrid1.SelectedObject = E;

            //ShowExceptionData();
 
        }

        private void ShowExceptionData()
        {
            //ListViewItem lvi;
            //object obj = null;
            //exeptionListView.Items.Clear();
            //ListViewItem etypeItem = new ListViewItem("Тип исключения");
            //etypeItem.SubItems.Add(E.GetType().ToString());
            //exeptionListView.Items.Add(etypeItem);
            //System.Reflection.PropertyInfo[] props = E.GetType().GetProperties();            
            //foreach (System.Reflection.PropertyInfo pi in props)
            //{
            //    if (pi.CanRead)
            //    {
            //        obj = pi.GetValue(E, null);
            //        lvi = new ListViewItem(pi.Name);
            //        exeptionListView.Items.Add(lvi);
            //        if (obj != null)
            //            lvi.SubItems.Add(obj.ToString());
 
            //    }
            //}
        }

        private void exeptionListView_SizeChanged(object sender, EventArgs e)
        {
            //this.columnHeader1.Width = (sender as ListView).Width / 4;
            //this.columnHeader2.Width = (sender as ListView).Width - this.columnHeader1.Width - 5;
        }       
    }
}