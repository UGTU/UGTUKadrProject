using Kadr.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class TripRegionsEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            if (value is BusinessTrip)
                using (Kadr.UI.Dialogs.TripRegionsDialog dlg = new Kadr.UI.Dialogs.TripRegionsDialog((BusinessTrip)value))
                {
                    //dlg.Text = "График работы";
                    //dlg.QueryText = "Выберите график работы";
                    //dlg.DataSource =
                    //    Kadr.Controllers.KadrController.Instance.Model.WorkShedules.OrderBy(wShed => wShed.NameShedule);
                    //dlg.SelectedValue = (Kadr.Data.WorkShedule)value;

                    if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                        if (dlg.Result() == null)
                            return dlg.Result();
                    return value;
                }
            else return null;

        }

        public override UITypeEditorEditStyle GetEditStyle(ITypeDescriptorContext context)
        {
            return UITypeEditorEditStyle.Modal;
        }
    }

}