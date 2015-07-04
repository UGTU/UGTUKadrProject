using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using System.Data.Linq;
using Kadr.UI.Dialogs;


namespace Kadr.UI.Common
{
    public partial class LinqPropertyGridDialogEditing : PropertyGridDialog
    {
        public LinqPropertyGridDialogEditing()
        {
            InitializeComponent();

        }


        protected override void DoApply()
        {
            UIX.Views.IValidatable validatable = (SelectedObjects[0] as UIX.Views.IValidatable);
            if (validatable != null)
                    validatable.Validate();

            KadrController.Instance.SubmitChanges();
            base.DoApply();
        }

        private void ApplyBtn_Click(object sender, EventArgs e)
        {

        }

        private void LinqPropertyGridDialogEditing_Load(object sender, EventArgs e)
        {
            ApplyButtonVisible = false;

        }

        private void btnPrikaz_Click(object sender, EventArgs e)
        {
            if (UpdateObjectList == null)
            {
                MessageBox.Show("Не заданы все необходимые условия для вызова диалога \"Приказы\".", "АИС \"Штатное расписание\"");
                return;
            }

            using (PrikazDialog dlg = new PrikazDialog())
            {
                //сворачиваем все операции с объектом
                if (CommandManager.IsInBatchMode)
                    CommandManager.EndBatchCommand();

                try
                {
                    CommandManager.Unexecute(sender);
                    if (dlg.ShowDialog() == DialogResult.OK)
                    {
                        //заново все операции проводим
                        CommandManager.Redo(sender);
                    }
                    else
                    {
                        //обновляем модель (на случай отмены изменений и уничтожения модели)
                        UpdateObjectList();
                    }
                }
                finally
                {
                    if (!CommandManager.IsInBatchMode)
                        CommandManager.BeginBatchCommand();
                }

            }
        }


   }
}
