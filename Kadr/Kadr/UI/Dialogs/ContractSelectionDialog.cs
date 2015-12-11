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

        protected override void DoRefreshList()
        {
            if ((Employee == null) || (Employee.IsNull()))
            {
                throw new ArgumentNullException("Cотрудник.");
            }
                //выбираем только договоры (без доп соглашений)
            var res = Employee.FactStaffs.SelectMany(x => x.FactStaffHistories).SelectMany(y => y.Events).Where(x => x.EventKind != null).Where(x
                        => x.EventKind.ForFactStaff).Where(x => x.Contract != null).Select(z => z.Contract).Where(m => m.idMainContract == null).Where(x => x.id > 0);

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
    }
}
