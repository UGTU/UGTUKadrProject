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
            if (!((DialogObject == null) || ((DialogObject as Employee).IsNull())))
                cbObjectList.SelectedItem = DialogObject;
            else
                DialogObject = cbObjectList.SelectedItem;
        }

        private void bAddingMode_Click(object sender, EventArgs e)
        {
            DialogObject = CRUDEmployee.Create(this, null);
            if (DialogObject != null)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                Close();
            }
        }
    }
}
