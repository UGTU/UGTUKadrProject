using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kadr.UI.Common
{
    /// <summary>
    /// 
    /// </summary>
    public partial class CustomBaseDialog : Form
    {
        private const int ApplyButtonLeft = 492;
        private const int CancelButtonLeft = 399;
        private const int OKButtonLeft = 305;

        private bool isModified = false;

        public bool IsModified
        {
            get { return isModified; }
            set { isModified = value; }
        }

        private bool OKclicked = false;

        public bool OKClicked
        {
            get { return OKclicked; }
            set { OKclicked = value; }
        }


        private object dialogObject;

        public object DialogObject
        {
            get { return GetDialogObject(); }
            set { SetDialogObject(value); }
        }

        protected virtual void SetDialogObject(object value)
        {
            dialogObject = value;
        }

        protected virtual object GetDialogObject()
        {
            return dialogObject;
        }


        public CustomBaseDialog()
        {
            InitializeComponent();
        }

        public CustomBaseDialog(object AObject)
        {
            InitializeComponent();
            dialogObject = AObject;
        }

        public void Cancel()
        {
            DoCancel();
        }

        virtual protected void DoCancel()
        {
            
        }
        public void Apply()
        {
            DoApply();
            IsModified = false;
        }

        virtual protected void DoApply()
        {
       
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            OKclicked = true;
            try
            {
                Apply();
                if (OKclicked)
                    this.Close();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "АИС \"Штатное расписание\"");

                return;
            }
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            Cancel();
            this.Close();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Apply();
            }
            catch (Exception exp)
            {
                MessageBox.Show(exp.Message, "АИС \"Штатное расписание\"");

                return;
            }
        }

        private void HelpBtn_Click(object sender, EventArgs e)
        {
            try
            {
                Help.ShowHelp(this, helpProvider1.HelpNamespace, this.helpProvider1.GetHelpKeyword(this));
            }
            catch(ArgumentException)
            {
                MessageBox.Show("Справка приложения недоступна.", "Спрaвка", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
        }

        public int DialogObjectID
        {
            get
            {
                int result = -1;

                if (DialogObject is DataRow)
                {
                    DataRow row = DialogObject as DataRow;
                    result = (int)row["ID"];
                }
                return result;
            }
        }

        public Guid DialogObjectGUID
        {
            get
            {
                Guid result = Guid.Empty;

                if (DialogObject is DataRow)
                {
                    DataRow row = DialogObject as DataRow;
                    result = (Guid)row["ID"];
                }

                return result;
            }
        }

        private void ISGBBaseDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            //если был выбран OK, но изменения не сохранены (т.е. произошла ошибка), не закрываем диалог
            if ((isModified) && (OKclicked))
            {
                OKclicked = false;
                e.Cancel = true;
                return;
            }


            if (IsModified)
            {
                DialogResult result = MessageBox.Show("Данные в окне были изменены. Сохранить сделанные изменения в базе данных?", 
                    "Сохранение изменений", MessageBoxButtons.YesNoCancel, 
                    MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);

                switch (result)
                {
                    case DialogResult.Yes:
                        Apply();
                        e.Cancel = false;
                        break;
                    case DialogResult.No:
                        Cancel();
                        e.Cancel = false;
                        break;
                    default:
                        e.Cancel = true;
                        break;
                } 
            }
        }

        protected void SetupButtonsVisible()
        {
            if (OKBtn.Visible)
            {
                if (ApplyBtn.Visible)
                {
                    ApplyBtn.Left = panel2.Width - ApplyBtn.Width - 3;
                    CancelBtn.Left = ApplyBtn.Left - CancelBtn.Width - 3;
                }
                else
                    CancelBtn.Left = panel2.Width - CancelBtn.Width - 3;

                OKBtn.Left = CancelBtn.Left - OKBtn.Width - 3;
            }
            else
            {
                CancelBtn.Left = panel2.Width - CancelBtn.Width - 3;
                ApplyBtn.Left = CancelBtn.Left - ApplyBtn.Width - 3;
            }
            

        }

        /// <summary>
        /// Видимость кнопки "Добавить" ("Применить")
        /// </summary>
        public bool ApplyButtonVisible
        {
            get
            {
                return ApplyBtn.Visible;
            }
            set
            {
                ApplyBtn.Visible = value;

                SetupButtonsVisible();
            }
        }




       

    
    }
}