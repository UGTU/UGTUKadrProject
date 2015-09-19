﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;

namespace Kadr.Controllers
{
    public static class CRUDFactStaffHistory
    {
        public static void Create(FactStaff currentFactStaff)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<FactStaffHistory> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<FactStaffHistory>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.FactStaffHistories;
                //dlg.BindingSource = planStaffBindingSource;
                dlg.PrikazButtonVisible = true;
                dlg.oneObjectCreated = true;
                dlg.InitializeNewObject = (x) =>
                {
                    x.SetProperties(dlg.CommandManager, currentFactStaff, currentFactStaff.WorkType, NullPrikaz.Instance, DateTime.Today.Date);
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.FactStaffHistories;
                };

                dlg.ShowDialog();
            }
        }

    }
}
