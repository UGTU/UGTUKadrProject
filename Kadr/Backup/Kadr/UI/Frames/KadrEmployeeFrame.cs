using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.KadrTreeView;
using Kadr.Controllers;
using Kadr.Data;
using UIX.Commands;

namespace Kadr.UI.Frames
{
    public partial class KadrEmployeeFrame : Kadr.UI.Frames.KadrBaseFrame
    {
        #region Properties

        /// <summary>
        /// Текущая должность (фактическое штатное) сотрудника
        /// </summary>
        public FactStaff FactStaff
        {
            get
            {
                if (this.FrameNodeObject != null)
                    return (this.FrameNodeObject as KadrEmployeeObject).FactStaff;
                else
                    return null;
            }
        }


        /// <summary>
        /// Отображаемый сотрудник
        /// </summary>
        public Kadr.Data.Employee Employee
        {
            get
            {
                if (this.FrameNodeObject != null)
                    return (this.FrameNodeObject as KadrEmployeeObject).Employee;
                else
                    return null;
            }
        }

        private UIX.Commands.ICommandManager commandManager;



        #endregion

        #region LoadData

        private void LoadPostList()
        {
            //factStaffBindingSource.DataSource = KadrController.Instance.EmployeeFactStaffs(Employee);
 
            factStaffBindingSource.DataSource = KadrController.Instance.Model.FactStaffs.Where(factSt => factSt.Employee == Employee);//.OfType<UIX.Views.IDecorable>().ToArray();
        }

        private void LoadBonus()
        {
            bonusBindingSource.DataSource = KadrController.Instance.Model.Bonus.Where(bonus => bonus.FactStaff.Employee == Employee);
        }

        private void LoadEmployee()
        {
            cpgEmployee.SelectedObjects = new object[] { Employee.GetDecorator() };
            commandManager = new UIX.Commands.CommandManager();
            cpgEmployee.CommandRegister = commandManager.GetCommandRegister();
            commandManager.BeginBatchCommand();
        }

        #endregion

        public KadrEmployeeFrame()
        {
            InitializeComponent();
        }

        public KadrEmployeeFrame(object AObject)
        {
            InitializeComponent();
            FrameObject = AObject;
        }

        protected override void DoRefreshFrame()
        {
            LoadEmployee();
            LoadPostList();
            LoadBonus();
        }


        private void DelBonusBtn_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить надбавку?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                    == DialogResult.OK)
            {
                LinqActionsController<Bonus>.Instance.DeleteObject(bonusBindingSource.Current as Bonus, KadrController.Instance.Model.Bonus, bonusBindingSource);
            }

        }



        private void EditBonusBtn_Click(object sender, EventArgs e)
        {
            LinqActionsController<Bonus>.Instance.EditObject(bonusBindingSource.Current as Kadr.Data.Bonus, true);

        }

        private void AddBonusBtn_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<Bonus> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<Bonus>())
            {
                dlg.ObjectList = KadrController.Instance.Model.Bonus;
                dlg.BindingSource = bonusBindingSource;
                dlg.UseInternalCommandManager = true;
                dlg.PrikazButtonVisible = true;
                dlg.InitializeNewObject = (x) =>
                {
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Bonus, FactStaff>(x, "FactStaff", FactStaff, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Bonus, BonusType>(x, "BonusType", NullBonusType.Instance, null), this);
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Bonus, System.Nullable<System.DateTime>>(x, "DateBegin", DateTime.Today, null), this);
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        Bonus prev = dlg.SelectedObjects[0] as Bonus;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Bonus, Prikaz>(x, "Prikaz", prev.Prikaz, null), this);

                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Bonus, Prikaz>(x, "Prikaz", NullPrikaz.Instance, null), this);
                    }
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.Bonus;
                };

                dlg.ShowDialog();
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if (commandManager.IsInBatchMode)
            {
                commandManager.EndBatchCommand();
            }
            KadrController.Instance.SubmitChanges();
            commandManager.BeginBatchCommand();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (commandManager != null)
            {
                if (commandManager.IsInBatchMode)
                {
                    commandManager.TerminateBatchCommand();
                }
            }
            commandManager.BeginBatchCommand();
            cpgEmployee.SelectedObjects = new object[] { Employee.GetDecorator() };
        }

        private void dataGridView1_DoubleClick(object sender, EventArgs e)
        {
            EditBonusBtn_Click(sender, e);

        }




    }

}
