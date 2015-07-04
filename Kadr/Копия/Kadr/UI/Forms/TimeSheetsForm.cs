using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Controllers;
using Kadr.Data;

namespace Kadr.UI.Forms
{
    public partial class TimeSheetsForm : Form
    {
        private int currentYear;

        public int CurrentYear
        {
            get
            {
                return currentYear;
            }
            set
            {
                currentYear = value;
            }
        }
        
        public TimeSheetsForm()
        {
            InitializeComponent();
        }

        private void tsbTimeSheets_Click(object sender, EventArgs e)
        {

        }

        private void TimeSheetsForm_Load(object sender, EventArgs e)
        {
            cbTimeSheetYear.Items.Clear();
            for (int year = DateTime.Today.Year+1; year>=DateTime.Today.Year; year--)
            {
                //if (!cbTimeSheetYear.Items.Contains(year))
                cbTimeSheetYear.Items.Add(year);
            }
            cbTimeSheetYear.Items.AddRange(KadrController.Instance.Model.TimeSheets.Select(ts => (ts.TimeSheetYear as Object)).Where(tsy => Convert.ToInt32(tsy) < DateTime.Today.Year).Distinct().OrderByDescending(tsy => Convert.ToInt32(tsy)).ToArray());
            if (CurrentYear > 0 )
                cbTimeSheetYear.SelectedItem = CurrentYear;
            else
                cbTimeSheetYear.SelectedItem = DateTime.Today.Year;
  
        }

 
        private void cbTimeSheetYear_SelectedValueChanged(object sender, EventArgs e)
        {
            timeSheetBindingSource.DataSource = KadrController.Instance.Model.TimeSheets.Where(ts => ts.TimeSheetYear == Convert.ToInt32(cbTimeSheetYear.SelectedItem)).OrderByDescending(ts => ts.TimeSheetMonth);
        }

        private void dgvTimeSheets_DoubleClick(object sender, EventArgs e)
        {
            if (timeSheetBindingSource.Current == null)
            {
                MessageBox.Show("Выберите табель для редактирования!");
                return;
            }
            LinqActionsController<TimeSheet>.Instance.EditObject(timeSheetBindingSource.Current as TimeSheet, true);
        }

        private void AddTimeSheetBtn_Click(object sender, EventArgs e)
        {
            using (Kadr.UI.Common.PropertyGridDialogAdding<TimeSheet> dlg =
                new Kadr.UI.Common.PropertyGridDialogAdding<TimeSheet>())
            {
                dlg.UseInternalCommandManager = true;
                dlg.ObjectList = KadrController.Instance.Model.TimeSheets;
                dlg.BindingSource = timeSheetBindingSource;
                //dlg.PrikazButtonVisible = false;
                dlg.InitializeNewObject = (x) =>
                {
                    if ((dlg.SelectedObjects != null) && (dlg.SelectedObjects.Length == 1))
                    {
                        TimeSheet prev = dlg.SelectedObjects[0] as TimeSheet;
                        int NextMonthsYear = MonthController.Instance.GetNextMonthsYear(prev.TimeSheetMonth, prev.TimeSheetYear);
                        int NextMonth = MonthController.Instance.GetNextMonth(prev.TimeSheetMonth);

                       // dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<TimeSheet, int>(x, "TimeSheetAllDayCount", DateTime.DaysInMonth(NextMonthsYear, NextMonth), null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<TimeSheet, int>(x, "TimeSheetWorkingDayCount", DateTime.DaysInMonth(NextMonthsYear, NextMonth), null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<TimeSheet, int>(x, "TimeSheetYear", NextMonthsYear, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<TimeSheet, int>(x, "TimeSheetMonth", NextMonth, null), this);
                    }
                    else
                    {
                    //    dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<TimeSheet, int>(x, "TimeSheetAllDayCount", DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month), null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<TimeSheet, int>(x, "TimeSheetWorkingDayCount", DateTime.DaysInMonth(DateTime.Today.Year, DateTime.Today.Month), null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<TimeSheet, int>(x, "TimeSheetYear", DateTime.Today.Year, null), this);
                        dlg.CommandManager.Execute(new UIX.Commands.GenericPropertyCommand<TimeSheet, int>(x, "TimeSheetMonth", DateTime.Today.Month, null), this);
                    }
                };

                dlg.UpdateObjectList = () =>
                {
                    dlg.ObjectList = KadrController.Instance.Model.TimeSheets;
                };

                dlg.ShowDialog();
            }
        }

        private void DelTimeSheetBtn_Click(object sender, EventArgs e)
        {
            
            if (MessageBox.Show("Удалить табель?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
            {
                LinqActionsController<TimeSheet>.Instance.DeleteObject(timeSheetBindingSource.Current as TimeSheet,
                     KadrController.Instance.Model.TimeSheets, timeSheetBindingSource);

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnFillingReport_Click(object sender, EventArgs e)
        {
            if (timeSheetBindingSource.Current == null)
            {
                MessageBox.Show("Выберите табель для просмотра информации!");
                return;
            }
            using (TimeSheetReport report = new TimeSheetReport())
            {
                report.CurrentTimeSheet = timeSheetBindingSource.Current as TimeSheet;
                report.ShowDialog();
            }
        }

        private void dgvTimeSheets_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            //зафиксировано - устанавливаем

            if ((dgvTimeSheets.Columns[e.ColumnIndex].DataPropertyName == "IsFilled") && (timeSheetBindingSource.Current != null))
            {
                (timeSheetBindingSource.Current as TimeSheet).IsFilled =
                    !(timeSheetBindingSource.Current as TimeSheet).IsFilled;
                KadrController.Instance.Model.SubmitChanges();
            }

            if ((dgvTimeSheets.Columns[e.ColumnIndex].DataPropertyName == "IsClosed") && (timeSheetBindingSource.Current != null))
            {
                (timeSheetBindingSource.Current as TimeSheet).IsClosed =
                    !(timeSheetBindingSource.Current as TimeSheet).IsClosed;
                KadrController.Instance.Model.SubmitChanges();
            }
        }

      }
}
