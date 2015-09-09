using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Data;
using Kadr.Controllers;
using Kadr.UI.Common;

namespace Kadr.UI.Dialogs
{
    public partial class EmployeeLinqPropertyGridDialogAdding : PropertyGridDialogAdding<Employee>
    {
        public PlanStaff PlanStaff
        {
            get;
            set;
        }
        
        public EmployeeLinqPropertyGridDialogAdding()
        {
            InitializeComponent();
        }

        protected override void DoApply()
        {
            UIX.Views.IValidatable validatable = (SelectedObjects[0] as UIX.Views.IValidatable);
            if (validatable != null)
                validatable.Validate();

            //добавляем связанные объекты, если необходимо
            if (BeforeApplyAction != null)
                BeforeApplyAction(newObject);

            if (CRUDFactStaff.CreateWithEmployee(null, PlanStaff, null, false, true, SelectedObjects[0] as Employee, CommandManager, null, WorkType.MainWorkType) != DialogResult.OK)
            {

            }

            //сохраняем прежний объект
            if (ObjectList != null)
            {
                ObjectList.InsertOnSubmit(newObject);

            }

            try
            {
                KadrController.Instance.SubmitChanges();
            }
            catch (Exception exp)
            {
                if (ObjectList != null)
                {
                    ObjectList.DeleteOnSubmit(newObject);
                }
                
            }


            base.DoApply();
            if (!OKClicked)
            {
                this.CommandManager.BeginBatchCommand();
                //создаем новый объект
                CreateNewObject();
            }
        }
    }
}
