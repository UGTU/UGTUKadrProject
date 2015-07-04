using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class FactStaffEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.FactStaffCurrentMainData> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.FactStaffCurrentMainData>())
            {
                
                dlg.Text = "Сотрудник, занимающий должность";
                dlg.QueryText = "Выберите сотрудника, занимающего должность";
                dlg.DataSource = Kadr.Controllers.KadrController.Instance.Model.FactStaffCurrentMainDatas.OrderBy(fcSt => fcSt.FactStaffFullName);
                dlg.SelectedValue = (Kadr.Data.FactStaffCurrentMainData)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullFactStaff.Instance;
                    else
                        return dlg.SelectedValue;
                }
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


