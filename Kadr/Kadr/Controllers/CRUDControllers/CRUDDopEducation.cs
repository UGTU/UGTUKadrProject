﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Data;
using Kadr.UI.Common;

namespace Kadr.Controllers
{
    public static class CRUDDopEducation
    {
        public static void Create(Employee e, BindingSource DopEducationBindingSource, object sender)
        {
            using (PropertyGridDialogAdding<OK_DopEducation> dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_DopEducation>())
            {

                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_DopEducation, Employee>(x, "Employee", e, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_DopEducation, EducDocument>(x, "EducDocument",
                         new EducDocument(dlg.CommandManager, KadrController.Instance.Model.EducDocumentTypes.FirstOrDefault(q => q.id == EducDocumentType.DefualtDopEducationDoc))), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_DopEducation, DopEducType>(x, "DopEducType", KadrController.Instance.Model.DopEducTypes.FirstOrDefault(), null), sender);
                };

                dlg.ShowDialog();
            }

            Read(e, DopEducationBindingSource);
        }

        public static void Read(Employee e, BindingSource DopEducationBindingSource)
        {
            DopEducationBindingSource.DataSource = KadrController.Instance.Model.OK_DopEducations.Where(educ => educ.Employee == e).Select(x => x.GetDecorator()).ToList();
        }

        public static void Update(Employee e, BindingSource DopEducationBindingSource)
        {
            if (DopEducationBindingSource.Current != null)
            {
                var ed = (DopEducationBindingSource.Current as DopEducationDecorator).GetDopEduc();
                LinqActionsController<OK_DopEducation>.Instance.EditObject(ed, false);
            }

            Read(e, DopEducationBindingSource);
        }

        public static void Delete(Employee e, BindingSource DopEducationBindingSource)
        {
            if (DopEducationBindingSource.Current == null)
                MessageBox.Show("Не выбрано удаляемое обучение!");
            else
                if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (DopEducationBindingSource.Current as DopEducationDecorator).ToString()), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var educ = (DopEducationBindingSource.Current as DopEducationDecorator).GetDopEduc();
                    LinqActionsController<EducDocument>.Instance.DeleteObject(educ.EducDocument, KadrController.Instance.Model.EducDocuments, null);
                    LinqActionsController<OK_DopEducation>.Instance.DeleteObject(educ, KadrController.Instance.Model.OK_DopEducations, DopEducationBindingSource);
                }
            Read(e, DopEducationBindingSource);
        }
    }
}