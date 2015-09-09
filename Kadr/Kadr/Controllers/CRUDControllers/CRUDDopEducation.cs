using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Data;
using Kadr.UI.Common;
using UIX.Commands;

namespace Kadr.Controllers
{
    public static class CRUDDopEducation
    {
        public static void Create(Employee e, FactStaff fs, BindingSource DopEducationBindingSource, object sender)
        {
            using (var dlg =
               SimpleActionsProvider.NewSimpleObjectAddingDialog<OK_DopEducation>())
            {

                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_DopEducation, Employee>(x, "Employee", e, null), sender);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_DopEducation, FactStaff>(x, "FactStaff", fs, null), sender);   
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<OK_DopEducation, EducDocument>(x, "EducDocument",
                         new EducDocument()), sender);
                    
                };

                dlg.BeforeApplyAction = BeforeApplyAction();

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.OK_DopEducations;
                };

                dlg.ShowDialog();
            }

            Read(e, DopEducationBindingSource);
        }

        private static Action<OK_DopEducation> BeforeApplyAction()
        {
            return (x) =>
            {
                if (x.TempPrikaz != null)
                    x.FactStaffPrikaz = new FactStaffPrikaz()
                    {
                        FactStaff = x.FactStaff,
                        Prikaz = x.TempPrikaz
                    };
                if ((x.FactStaffPrikaz == null) || (x.FactStaffPrikaz.Prikaz != null)) return;
                KadrController.Instance.Model.FactStaffPrikazs.DeleteOnSubmit(x.FactStaffPrikaz);
                x.FactStaffPrikaz = null;
            };
        }

        public static void Read(Employee e, BindingSource DopEducationBindingSource)
        {
            DopEducationBindingSource.DataSource = KadrController.Instance.Model.OK_DopEducations.Where(educ => educ.Employee == e).Select(x => x.GetDecorator()).ToList();
        }

        public static void Update(Employee e,FactStaff fs, BindingSource DopEducationBindingSource)
        {
            if (DopEducationBindingSource.Current != null)
            {
                var ed = (DopEducationBindingSource.Current as DopEducationDecorator).GetDopEduc();
                ed.FactStaff = fs;
                using (var dlg = new Kadr.UI.Common.LinqPropertyGridDialogEditing<OK_DopEducation>())
                {
                    dlg.UseInternalCommandManager = true;
                    dlg.SelectedObjects = new object[] { ed };
                    dlg.BeforeApplyAction = BeforeApplyAction();
                    dlg.UpdateObjectList = () =>
                    {
                        dlg.ObjectList = KadrController.Instance.Model.OK_DopEducations;
                    };
                    dlg.ShowDialog();
                }
            }

            Read(e, DopEducationBindingSource);
        }

        public static void Delete(Employee e, BindingSource DopEducationBindingSource)
        {
            if (DopEducationBindingSource.Current == null)
                MessageBox.Show("Не выбрано удаляемое обучение!");
            else
                if (MessageBox.Show(string.Format("Вы уверены, что хотите удалить '{0}'?", (DopEducationBindingSource.Current as DopEducationDecorator)), "Подтверждение", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    var educ = (DopEducationBindingSource.Current as DopEducationDecorator).GetDopEduc();
                   
                    KadrController.Instance.Model.EducDocuments.DeleteOnSubmit(educ.EducDocument);
                    if (educ.FactStaffPrikaz != null)
                        KadrController.Instance.Model.FactStaffPrikazs.DeleteOnSubmit(educ.FactStaffPrikaz);
                    LinqActionsController<OK_DopEducation>.Instance.DeleteObject(educ, KadrController.Instance.Model.OK_DopEducations, DopEducationBindingSource);
                }
            Read(e, DopEducationBindingSource);
        }
    }
}
