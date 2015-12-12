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
            
            //выбираем только договоры (без доп соглашений) 
            var res = Employee.FactStaffs.SelectMany(x => x.FactStaffHistories).SelectMany(y => y.Events).Where(x => x.EventKind != null).Where(x
                        => x.EventKind.ForFactStaff).Where(x => x.Contract != null).Select(z => z.Contract).Where(m => m.idMainContract == null).Where(x => x.id > 0).Concat(
                            Employee.FactStaffs.SelectMany(x => x.FactStaffHistories).SelectMany(y => y.Events).Where(x => x.EventKind != null).Where(x
                              => x.EventKind.ForFactStaff).Where(x => x.Contract != null).Select(z => z.Contract).Where(m => m.idMainContract != null).Select(x => x.MainContract).Where(x => x.id > 0)).Distinct();

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
            dtpDateEnd.Text = null;
        }

        private void OKBtn_Click(object sender, EventArgs e)
        {
            if (pAdding.Visible)
            {

                Contract c = CRUDContract.Create(tbContractName.Text, dtpDateContract.Value, 
                    (dtpDateBegin.Checked) ? dtpDateBegin.Value : (DateTime?)null,
                    (dtpDateEnd.Checked) ? dtpDateEnd.Value : (DateTime?)null);

                dialogObject = c;
            }
        }

        private void dtpDateContract_ValueChanged(object sender, EventArgs e)
        {
            bool Checked = dtpDateEnd.Checked;
            dtpDateBegin.Value = dtpDateContract.Value;
            dtpDateEnd.Value = dtpDateContract.Value;
            dtpDateEnd.Checked = Checked;
        }
    }
}
