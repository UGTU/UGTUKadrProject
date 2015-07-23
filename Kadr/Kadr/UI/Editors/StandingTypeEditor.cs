using System;
using System.Linq;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class StandingTypeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.StandingType> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.StandingType>())
            {

                dlg.Text = "Тип стажа";
                dlg.QueryText = "Выберите тип стажа";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.StandingTypes.OrderBy(st => st.StandingTypeName);
                dlg.SelectedValue = (Kadr.Data.StandingType)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullStandingType.Instance;
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




