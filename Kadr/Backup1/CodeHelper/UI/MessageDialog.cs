using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace APG.CodeHelper.UI
{
    public class MessageDialog<T> : IDisposable where T : Control
    {
        public event System.ComponentModel.CancelEventHandler Validating;

        private MessageForm internalForm = new MessageForm();
        
        public MessageDialog(string messageCaption, string messageText, params object[] objects)
        {
            T item;
            if (objects != null)
                foreach (object obj in objects)
                {
                    item = Activator.CreateInstance<T>();
                    item.Text = obj.ToString();
                    item.Tag = obj;
                    internalForm.panel4.Controls.Add(item);
                    item.Dock = DockStyle.Bottom;
                    item.Validating += new System.ComponentModel.CancelEventHandler(item_Validating);
                }

            internalForm.label1.Text = messageText;
            internalForm.Text = messageCaption;

            internalForm.StartPosition = FormStartPosition.Manual;
           
        }

        void item_Validating(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (Validating != null)
            {
                Validating(sender, e);
            }
        }

        public T this[int index]
        {
            get
            {
                return (T)internalForm.panel4.Controls[index];
            }
        }

        public DialogResult ShowDialog()
        {
            internalForm.StartPosition = FormStartPosition.CenterScreen;
            return internalForm.ShowDialog();
        }
        public DialogResult ShowDialog(Control owner)
        {
            internalForm.StartPosition = FormStartPosition.CenterParent;
            return internalForm.ShowDialog(owner);

        }

        #region IDisposable Members

        public void Dispose()
        {
            internalForm.Dispose();
        }

        #endregion
    }
}
