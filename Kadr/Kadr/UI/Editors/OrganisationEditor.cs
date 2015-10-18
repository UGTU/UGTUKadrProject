using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing.Design;
using System.Linq;
using System.Text;

namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class OrganisationEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (var dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.Organisation>())
            {

                dlg.Text = "Организация";
                dlg.QueryText = "Выберите организацию";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.Organisations.OrderBy(gr => gr.Name);
                dlg.SelectedValue = (Kadr.Data.Organisation)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullOrganisation.Instance;
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
