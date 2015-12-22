using System;
using System.Data;
using System.Linq;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.UI.Common;
using Kadr.Data.Common;

namespace Kadr.UI.Dialogs
{
    public partial class EmployeeSelectionDialog : BaseSelectionDialog
    {
        public EmployeeSelectionDialog(): base()
        {
            InitializeComponent();
            lObjectTypeName.Text = "Сотрудник";
            
        }

        protected override void DoRefreshList()
        {

            //берем только договоры (без доп соглашений) 
            var res = Kadr.Controllers.KadrController.Instance.Model.Employees;

            if (res != null)
                ObjectListBindingSource.DataSource = res.ToList();
            if (!((dialogObject == null) || ((dialogObject as Employee).IsNull())))
                cbObjectList.SelectedItem = dialogObject;
            else
                dialogObject = cbObjectList.SelectedItem;
        }

        private void bAddingMode_Click(object sender, EventArgs e)
        {
            dialogObject = CRUDEmployee.Create(this, null);
            if (dialogObject != null)
                Close();
        }
    }
}
