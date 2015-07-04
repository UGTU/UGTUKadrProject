using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class DepartmentEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.Department> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.Department>())
            {
                
                dlg.Text = "Отдел";
                dlg.QueryText = "Выберите отдел";
                dlg.DataSource = 
                    Kadr.Controllers.KadrController.Instance.Model.Departments.OrderBy(dep => dep.DepartmentName);
                dlg.SelectedValue = (Kadr.Data.Department)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullDepartment.Instance;
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


