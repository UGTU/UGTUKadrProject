using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class WorkSheduleEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.WorkShedule> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.WorkShedule>())
            {
                
                dlg.Text = "График работы";
                dlg.QueryText = "Выберите график работы";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.WorkShedules.OrderBy(wShed => wShed.NameShedule);
                dlg.SelectedValue = (Kadr.Data.WorkShedule)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullFinancingSource.Instance;
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



