using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class WorkTypeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.WorkType> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.WorkType>())
            {

                dlg.Text = "Вид работы";
                dlg.QueryText = "Выберите вид работы";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.WorkTypes.OrderBy(wt => wt.TypeWorkName);
                dlg.SelectedValue = (Kadr.Data.WorkType)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullWorkType.Instance;
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


