using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class FundingCenterEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.FundingCenter> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.FundingCenter>())
            {

                dlg.Text = "Центр финансирования";
                dlg.QueryText = "Выберите центр финансирования";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.FundingCenters.Where(fc => (fc.DateEnd == null) || (fc.DateEnd > DateTime.Today.Date)).OrderBy(fc => fc.FundingCenterName);
                dlg.SelectedValue = (Kadr.Data.FundingCenter)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullFundingCenter.Instance;
                    else
                        return dlg.SelectedValue;
                else
                    return value;
            }

        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }

}





