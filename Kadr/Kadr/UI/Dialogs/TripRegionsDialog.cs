using Kadr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Kadr.UI.Dialogs
{
    public partial class TripRegionsDialog : Kadr.UI.Common.LinqDataGridViewDialog
    {
        private object DataSource;
        //private IEnumerable<BusinessTripRegionType> DataSource;

        public TripRegionsDialog(object source)
        {
            InitializeComponent();
            DataSource = source;
            
        }

        internal object Result()
        {
            return businessTripRegionTypeBindingSource.DataSource;
        }

        private void TripRegionsDialog_Load(object sender, EventArgs e)
        {
            regionTypeBindingSource.DataSource = Kadr.Controllers.KadrController.Instance.Model.RegionTypes;
            businessTripRegionTypeBindingSource.DataSource = DataSource;
            bindingNavigator1.BindingSource = businessTripRegionTypeBindingSource;
        }
    }
}
