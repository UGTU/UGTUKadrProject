using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;
using Kadr.UI.Dialogs;
using Kadr.Data;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class EmployeeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            Employee currentEmployee = null;

            if (context.Instance is FactStaffMainBaseDecorator)
            {
                currentEmployee = (context.Instance as FactStaffMainBaseDecorator).Employee;
            }

            if (context.Instance is FactStaffHistoryMinDecorator)
            {
                currentEmployee = (context.Instance as FactStaffHistoryMinDecorator).FactStaff.Employee;
            }

            using (EmployeeSelectionDialog dlg = new EmployeeSelectionDialog())
            {
                dlg.Text = "Сотрудник";
                dlg.DialogObject = currentEmployee;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    return dlg.DialogObject;
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


