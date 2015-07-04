using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class ScienceTypeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.ScienceType> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.ScienceType>())
            {

                dlg.Text = "Научное направление";
                dlg.QueryText = "Выберите научное направление";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.ScienceTypes.OrderBy(scType => scType.ScienceTypeName);
                dlg.SelectedValue = (Kadr.Data.ScienceType)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullScienceType.Instance;
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



