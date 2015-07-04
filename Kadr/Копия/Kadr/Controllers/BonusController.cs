using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Kadr.Data;
using System.Windows.Forms;

namespace Kadr.Controllers
{
    class BonusController
    {
        /// <summary>
        /// Добавление надбавки
        /// </summary>
        /// <param name="bonusObject">объект, которому добавляем</param>
        /// <param name="bonusBindingSource">BindingSource</param>
        public void AddBonus(object bonusObject, BindingSource bonusBindingSource)
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
                    //создаем историю надбавки
                    BonusHistory bonusHistory = new BonusHistory();
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusHistory, Bonus>(bonusHistory, "Bonus", x, null), this);
                    
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        Bonus prev = dlg.SelectedObjects[0] as Bonus;
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusHistory, Prikaz>(bonusHistory, "Prikaz", prev.PrikazBegin, null), this);
                    }
                    else
                    {
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusHistory, Prikaz>(bonusHistory, "Prikaz", NullPrikaz.Instance, null), this);
                    }
                    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<Bonus, BonusType>(x, "BonusType", NullBonusType.Instance, null), this);

                    if (bonusObject is FactStaff)
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusHistory, System.DateTime>(bonusHistory, "DateBegin", DateTime.Today.AddDays(1 - DateTime.Today.Day), null), this);
                    else
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusHistory, System.DateTime>(bonusHistory, "DateBegin", DateTime.Today, null), this);
                    
                };


                dlg.CreateRelatedObject = (x) =>
                {
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        Bonus prev = dlg.SelectedObjects[0] as Bonus;
                        if (bonusObject is FactStaff)
                        {
                            BonusFactStaff bonusFactStaff = new BonusFactStaff();
                            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusFactStaff, Bonus>(bonusFactStaff, "Bonus", prev, null), this);
                            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusFactStaff, FactStaff>(bonusFactStaff, "FactStaff", bonusObject as FactStaff, null), this);
                        }

                        if (bonusObject is PlanStaff)
                        {
                            BonusPlanStaff bonusPlanStaff = new BonusPlanStaff();
                            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusPlanStaff, Bonus>(bonusPlanStaff, "Bonus", prev, null), this);
                            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusPlanStaff, PlanStaff>(bonusPlanStaff, "PlanStaff", bonusObject as PlanStaff, null), this);
                        }

                        if (bonusObject is Post)
                        {
                            BonusPost bonusPost = new BonusPost();
                            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusPost, Bonus>(bonusPost, "Bonus", prev, null), this);
                            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusPost, Post>(bonusPost, "Post", bonusObject as Post, null), this);
                        }

                        if (bonusObject is Employee)
                        {
                            BonusEmployee bonusEmployee = new BonusEmployee();
                            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusEmployee, Bonus>(bonusEmployee, "Bonus", prev, null), this);
                            dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<BonusEmployee, Employee>(bonusEmployee, "Employee", bonusObject as Employee, null), this);
                        }
                    }

                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.Bonus;
                };

                dlg.ShowDialog();
            }
           
        }



        /// <summary>
        /// Возвращает список надбавок для объекта
        /// </summary>
        /// <param name="bonusObject">объект</param>
        /// <returns></returns>
        public IEnumerable<Bonus> GetBonus(object bonusObject)
        {
            IEnumerable<Bonus> bonus = null;
            if (bonusObject is FactStaff)
            {
                bonus = KadrController.Instance.Model.Bonus.Where(bon =>
                    bon.BonusFactStaff != null).Where(bon => bon.BonusFactStaff.FactStaff == (bonusObject as FactStaff));
            }

            if (bonusObject is PlanStaff)
            {
                bonus = KadrController.Instance.Model.Bonus.Where(bon =>
                    bon.BonusPlanStaff != null).Where(bon => bon.BonusPlanStaff.PlanStaff == (bonusObject as PlanStaff));
            }

            if (bonusObject is Post)
            {
                bonus = KadrController.Instance.Model.Bonus.Where(bon =>
                    bon.BonusPost != null).Where(bon => bon.BonusPost.Post == (bonusObject as Post));
            }

            if (bonusObject is Employee)
            {
                bonus = KadrController.Instance.Model.Bonus.Where(bon =>
                    bon.BonusEmployee != null).Where(bon => bon.BonusEmployee.Employee == (bonusObject as Employee));
            }

            return bonus.OrderBy(bon => bon.BonusType.BonusTypeName).ThenBy(bon => bon.DateEnd).ThenBy(bon => bon.LastDateBegin);
        }

        public IEnumerable<Bonus> GetAllEmployeeBonus(Employee employee)
        {
            IEnumerable<Bonus> bonus = null;

            bonus = (KadrController.Instance.Model.Bonus.Where(bon => bon.BonusFactStaff != null).Where(bon
                => ((bon.BonusFactStaff.FactStaff.Employee == employee))) as IEnumerable<Bonus>).Concat(KadrController.Instance.Model.FactStaffs.Where(factStf
                    => (factStf.Employee == employee) ).SelectMany(factStf
                        => factStf.PlanStaff.BonusPlanStaffs).Where(bonPlSt => bonPlSt.ForEmployee).Select(bonPlSt => bonPlSt.Bonus) as IEnumerable<Bonus>).Concat(KadrController.Instance.Model.FactStaffs.Where(factStf
                    => (factStf.Employee == employee) ).SelectMany(factStf
                        => factStf.PlanStaff.Post.BonusPosts).Select(bonPost => bonPost.Bonus) as IEnumerable<Bonus>).Distinct();

            return bonus.OrderBy(bon => bon.BonusType.BonusTypeName).ThenBy(bon => bon.DateEnd).ThenBy(bon => bon.DateBegin);
        }


        public void EditBonus(Bonus bonus)
        {
            LinqActionsController<Bonus>.Instance.EditObject(bonus, true);
        }


        public void DeleteBonus(BindingSource bonusBindingSource, Bonus CurrentBonus = null)
        {
            if (CurrentBonus == null)
                CurrentBonus = bonusBindingSource.Current as Bonus;

            if (CurrentBonus == null)
            {
                MessageBox.Show("Не выбрана удаляемая надбавка.", "АИС \"Штатное расписание\"");
                return;
            }

            //если уже задана история (более одной записи), то нельзя удалить надбавку
            if (CurrentBonus.BonusHistories.Count > 1)
            {
                MessageBox.Show("У заданной надбавки есть история изменений. Сначала необходимо удалить историю.", "АИС \"Штатное расписание\"");
                return;
            }

            if (MessageBox.Show("Удалить надбавку?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                != DialogResult.OK)
            {
                return;
            }

            KadrController.Instance.Model.BonusHistories.DeleteAllOnSubmit(KadrController.Instance.Model.BonusHistories.Where(bonHist => bonHist.Bonus == CurrentBonus));

            if (CurrentBonus.BonusFactStaff != null)
                KadrController.Instance.Model.BonusFactStaffs.DeleteOnSubmit(CurrentBonus.BonusFactStaff);

            if (CurrentBonus.BonusPlanStaff != null)
                KadrController.Instance.Model.BonusPlanStaffs.DeleteOnSubmit(CurrentBonus.BonusPlanStaff);

            if (CurrentBonus.BonusPost != null)
                KadrController.Instance.Model.BonusPosts.DeleteOnSubmit(CurrentBonus.BonusPost);

            if (CurrentBonus.BonusEmployee != null)
                KadrController.Instance.Model.BonusEmployees.DeleteOnSubmit(CurrentBonus.BonusEmployee);

            LinqActionsController<Bonus>.Instance.DeleteObject(CurrentBonus, KadrController.Instance.Model.Bonus, bonusBindingSource);

        }
 

        private static BonusController instance;


        private BonusController() 
        {
        }


        /// <summary>
        /// Получает единственный экземпляр контроллера
        /// </summary>
        public static BonusController Instance
        {
            get
            {
                if (instance == null)
                    instance = new BonusController();
                return instance;
            }
        }

        

    }
}
