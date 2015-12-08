using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Data;
using Kadr.UI.Common;

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
            if (Employee != null)
            {
                //выбираем только договоры (без доп соглашений)
                var res = Employee.FactStaffs.SelectMany(x => x.FactStaffHistories).SelectMany(y => y.Events).Where(x => x.EventKind != null).Where(x
                        => x.EventKind.ForFactStaff).Where(x => x.Contract != null).Select(z => z.Contract).Where(m => m.idMainContract == null).Where(x => x.id > 0);

                if (res != null)
                    ObjectListBindingSource.DataSource = res.ToList();
            }
            else
            {
                ObjectListBindingSource.DataSource = Kadr.Controllers.KadrController.Instance.Model.Contracts/*.Where(x => x.idMainContract == null)*/.ToArray();
            }
            dialogObject = cbObjectList.SelectedItem;
        }

        public ContractSelectionDialog(): base()
        {

            InitializeComponent();
            lObjectTypeName.Text = "Договор";
        }


        
    }
}
