using Kadr.Controllers;
using Kadr.Data;
using Kadr.Data.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Linq;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kadr.UI.Dialogs
{
    public partial class TripRegionsDialog : Kadr.UI.Common.LinqDataGridViewDialog
    {
        private object DataSource;

        private AdvancedBindingList<BusinessTripRegionType> Source = new AdvancedBindingList<BusinessTripRegionType>();

        private BusinessTrip bt;
        private BusinessTripRegionType last;
        private BusinessTripRegionType cur;
        //private IEnumerable<BusinessTripRegionType> DataSource;

        public TripRegionsDialog(BusinessTrip bt)
        {
            InitializeComponent();
            regionTypeBindingSource.DataSource = Kadr.Controllers.KadrController.Instance.Model.RegionTypes;
            businessTripRegionTypeBindingSource.DataSource = bt.BusinessTripRegionTypes.GetNewBindingList();
            this.bt = bt;
        }

        internal object Result()
        {
            return businessTripRegionTypeBindingSource.DataSource;
        }

        private void TripRegionsDialog_Load(object sender, EventArgs e)
        {
            bindingNavigator1.BindingSource = businessTripRegionTypeBindingSource;
            ApplyButtonVisible = false;
        }


        private void dgvRegionType_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            //Do nothing
        }


        override protected void DoApply()
        {
            foreach (object o in businessTripRegionTypeBindingSource)
            {
                UIX.Views.IValidatable validatable = (o as UIX.Views.IValidatable);
                if (validatable != null)
                    validatable.Validate();
            }
            KadrController.Instance.SubmitChanges();
            IsModified = true;
        }


        private void dgvRegionType_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if ((businessTripRegionTypeBindingSource[e.RowIndex] as BusinessTripRegionType).DateBegin == DateTime.MinValue) 
            {
                (businessTripRegionTypeBindingSource[e.RowIndex] as BusinessTripRegionType).DateBegin = (DateTime)bt.Event.DateBegin;
                (businessTripRegionTypeBindingSource[e.RowIndex] as BusinessTripRegionType).DateEnd = (DateTime)bt.Event.DateEnd;
            }
        }



    }
}
