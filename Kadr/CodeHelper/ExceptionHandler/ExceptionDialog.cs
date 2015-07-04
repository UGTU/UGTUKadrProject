using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace APG.CodeHelper.ExceptionHandler
{
    public partial class ExceptionDialog : Form
    {
        private System.Type detailDialogType;

        public System.Type DetailDialogType
        {
            get { return detailDialogType; }
            set { detailDialogType = value; }
        }

        private MessageBoxIcon messageBoxIcon;

        private Exception exception;

        private string logFileName;

        public string LogFileName
        {
            get { return logFileName; }
            set { logFileName = value; }
        }

        public string AboutMessage
        {
            get
            {
                return aboutText.Text;
            }
            set
            {
                aboutText.Text = value;
            }
        }

        public string ExceptionMessage
        {
            get
            {
                return errorText.Text;
            }
            set
            {
                errorText.Text = E.Message; 
                richTextBox1.Text = value;
            }
        }

        public ExceptionDialog(Exception e)
        {
            InitializeComponent();
            exception = e;
        }

        public MessageBoxIcon MessageIcon
        {
            get
            {
                return messageBoxIcon;
            }
            set
            {
                messageBoxIcon = value;
                SetMessageBoxIcon(value);
            }
        }

        private void SetMessageBoxIcon(MessageBoxIcon value)
        {
           /* switch (value)
            {
                case MessageBoxIcon.Warning: pictBox.Image = Res.Warning; break;
                case MessageBoxIcon.Information: pictBox.Image = Res.Information; break;
                case MessageBoxIcon.Error: pictBox.Image = Res.error; break;
 
            }*/
        }
 
        public Exception E
        {
            get
            {
                return exception;
            }
        }

        public Button BtnRaport
        {
            get 
            {
                return Raportbtn;
            }
            set 
            {
                Raportbtn = value;
            }
        }

        public Button BtnMore
        {
            get 
            {
                return Morebtn;
            }
            set 
            {
                Morebtn = value;
            }
        }

        public string NameFormException
        {
            get 
            {
                return Text;
            }
            set 
            {
                Text = value;
            }
        }

        private void OKbtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Morebtn_Click(object sender, EventArgs e)
        {
            // У формы должен быть конструктор с одним параметром типа Exception
            System.Windows.Forms.Form moreExceptionDialog = Activator.CreateInstance(DetailDialogType, E) as System.Windows.Forms.Form;
            moreExceptionDialog.ShowDialog();
        }

        // Отправка отчёта об ошибке через почтового клиента
        private void Raportbtn_Click(object sender, EventArgs e)
        {
            LogException.SendFileToEmail(LogFileName);
        }

        // Сохранение иформации об исключении в файл
        private void ISGBExceptionDialog_Load(object sender, EventArgs e)
        {
#if !DEBUG
            LogFileName = LogException.LogExceptionToFile(exception);
#endif
        }
    }
}