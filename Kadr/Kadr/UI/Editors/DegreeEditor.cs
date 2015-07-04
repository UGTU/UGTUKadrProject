﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing.Design;
using System.ComponentModel;


namespace Kadr.UI.Editors
{
    [System.Security.Permissions.PermissionSet(System.Security.Permissions.SecurityAction.Demand, Name = "FullTrust")]
    public class DegreeEditor : System.Drawing.Design.UITypeEditor
    {
        public override object EditValue(ITypeDescriptorContext context, IServiceProvider provider, object value)
        {
            using (Common.ListSelectDialog<Kadr.Data.Degree> dlg = new Kadr.UI.Common.ListSelectDialog<Kadr.Data.Degree>())
            {

                dlg.Text = "Научная степень сторудника";
                dlg.QueryText = "Выберите научную степень";
                dlg.DataSource =
                    Kadr.Controllers.KadrController.Instance.Model.Degrees.OrderBy(degr => degr.DegreeName);
                dlg.SelectedValue = (Kadr.Data.Degree)value;

                if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    if (dlg.SelectedValue == null)
                        return Kadr.Data.NullDegree.Instance;
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



