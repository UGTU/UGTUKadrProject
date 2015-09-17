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
    public partial class LinqPropertyGridDialogEditing<T> where T : class 

{
    //создание связанных объектов
    public Action<T> BeforeApplyAction;

     T editObject;

    public LinqPropertyGridDialogEditing()
    {
        InitializeComponent();

    }

    protected override void DoApply()
    {
        UIX.Views.IValidatable validatable = (SelectedObjects[0] as UIX.Views.IValidatable);
        if (validatable != null)
            validatable.Validate();

        if (SelectedObjects[0] is Kadr.Data.TimeSheetFSWorkingDay)
        {
            (SelectedObjects[0] as Kadr.Data.TimeSheetFSWorkingDay).IsClosed = true;
        }

        editObject = (T)SelectedObjects[0];

        //добавляем связанные объекты, если необходимо
        if (BeforeApplyAction != null)
            BeforeApplyAction(editObject);

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

    //список объектов (записей), в которые производится добавление объектов
    private System.Data.Linq.Table<T> objectList;

    public System.Data.Linq.Table<T> ObjectList
    {
        get
        {
            return objectList;
        }
        set
        {
            objectList = value;
        }
    }

    private void btnPrikaz_Click(object sender, EventArgs e)
    {
        if (UpdateObjectList == null)
        {
            MessageBox.Show("Не заданы все необходимые условия для вызова диалога \"Приказы\".",
                "ИС \"Управление кадрами\"");
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

    protected override void DoCancel()
    {
        base.DoCancel();
        /*if (SelectedObjects[0] is Kadr.Data.FactStaff)
            {
                
                KadrController.Instance.DeleteModel();
            }*/
    }


}
}
