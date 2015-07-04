using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class SemPolEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.SemPol> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.SemPol>())
            {
                
                dlg.Text = "Семейное положение";
                dlg.QueryText = "Выберите семейное положение";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.SemPols.OrderBy(sp => sp.sempolName);
                dlg.SelectedValue = (Kadr.Data.SemPol)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullSemPol.Instance;
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

