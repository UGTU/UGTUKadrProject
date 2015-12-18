using System;
using System.Data;
using System.Linq;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.UI.Common;
using Kadr.Data.Common;

namespace Kadr.UI.Dialogs
{
    public partial class ContractSelectionDialog : BaseSelectionDialog
    {

        public Employee Employee
        {
            get;
            set;
        }

        /// <summary>
        /// загрузка данных из имеющегося объекта
        /// </summary>
        /// <param name="contract"></param>
        private void ReadObjectData(Contract contract)
        {
            tbContractName.Text = contract.ContractName;
            dtpDateBegin.Value = Convert.ToDateTime(contract.DateBegin);
            dtpDateContract.Value = Convert.ToDateTime(contract.DateContract);
            dtpDateEnd.Value = contract.DateEnd?? Convert.ToDateTime(contract.DateContract);
            dtpDateEnd.Checked = contract.DateEnd != null;
        }

        protected override void DoRefreshList()
        {
            //если сотрудник не задан, то сразу переходим на добавление договора
            if ((Employee == null) || (Employee.IsNull()))
            {
                AddingModeOn();

                if (dialogObject != null)
                {
                    ReadObjectData(dialogObject as Contract);
                }
                return;
            }
            
            //берем только договоры (без доп соглашений) 
            var res = Employee.GetAllMainContracts();

            if (res != null)
                    ObjectListBindingSource.DataSource = res.ToList();
            dialogObject = cbObjectList.SelectedItem;
        }

        public ContractSelectionDialog(): base()
        {
            InitializeComponent();
            lObjectTypeName.Text = "Договор";
        }

        private void ContractSelectionDialog_Load(object sender, EventArgs e)
        {
            if (!dtpDateEnd.Checked)
                dtpDateEnd.Text = null;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (pAdding.Visible)
            {
                Contract c = CRUDContract.Create(tbContractName.Text, dtpDateContract.Value, 
                    dtpDateBegin.Value,
                    (dtpDateEnd.Checked) ? dtpDateEnd.Value : (DateTime?)null);

                dialogObject = c;
            }
        }

        private void dtpDateContract_ValueChanged(object sender, EventArgs e)
        {
            dtpDateBegin.Value = dtpDateContract.Value;
            if (!dtpDateEnd.Checked)
            {
                dtpDateEnd.Value = dtpDateContract.Value;
                dtpDateEnd.Checked = false;
            }
        }
    }
}
