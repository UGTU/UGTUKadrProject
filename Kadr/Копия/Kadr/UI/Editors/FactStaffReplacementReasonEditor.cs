using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class FactStaffReplacementReasonEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.FactStaffReplacementReason> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.FactStaffReplacementReason>())
            {
                
                dlg.Text = "Причина замещения";
                dlg.QueryText = "Выберите причину замещения";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.FactStaffReplacementReasons.OrderBy(reason => reason.ReplacementReasonName);
                dlg.SelectedValue = (Kadr.Data.FactStaffReplacementReason)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullFactStaffReplacementReason.Instance;
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


