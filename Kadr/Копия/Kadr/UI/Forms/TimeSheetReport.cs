using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Kadr.Data;
using Kadr.Controllers;

namespace Kadr.UI.Forms
{
    
    public partial class TimeSheetReport : Form
    {
        private TimeSheet currentTimeSheet;
        public TimeSheet CurrentTimeSheet
        {
            get
            {
                return currentTimeSheet;
            }
            set
            {
                currentTimeSheet = value;
            }
        }

        public TimeSheetReport()
        {
            InitializeComponent();
        }

        private void LoadTimeSheets()
        {
            int CurrentTSYear = DateTime.Today.Year;
            if (CurrentTimeSheet != null)
                CurrentTSYear = CurrentTimeSheet.TimeSheetYear;

            TimeSheet SelectedTimeSheet = cbTimeSheet.SelectedItem as TimeSheet;
            cbTimeSheet.Items.Clear();
            foreach (TimeSheet timeSheet in KadrController.Instance.Model.TimeSheets.Where(ts => ts.TimeSheetYear >= CurrentTSYear).OrderByDescending(ts => ts.TimeSheetMonth))
            {
                cbTimeSheet.Items.Add(timeSheet);
            }
                   
            cbTimeSheet.SelectedItem = CurrentTimeSheet;
            if (cbTimeSheet.SelectedItem == null)
                cbTimeSheet.SelectedItem = KadrController.Instance.Model.TimeSheets.Where(ts =>
                    (ts.TimeSheetMonth == DateTime.Today.Month) && (ts.TimeSheetYear == DateTime.Today.Year)).FirstOrDefault();
        }


        private void TimeSheetReport_Load(object sender, EventArgs e)
        {
            LoadTimeSheets();

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvTSRecord_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (timeSheetFSWorkingDaysBindingSource.Current == null)
            {
                return;
            }

            if (dgvTSRecord.Columns[e.ColumnIndex].DataPropertyName == "IsClosed")
            {
                if (!(timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).IsCreated)
                {
                    MessageBox.Show("Выбранная запись еще не добавлена в табель!");
                    return;
                }

                if ((timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).TimeSheetFSRecord.TimeSheet.IsClosed == true)
                {
                    MessageBox.Show("Табель рабочего времени закрыт для редактирования!");
                    return;
                }

                //зафиксировано - устанавливаем
                if ((timeSheetFSWorkingDaysBindingSource.Current != null) &&
                    ((timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).IsCreated))
                {
                    (timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).TimeSheetFSRecord.IsClosed =
                        !(timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).TimeSheetFSRecord.IsClosed;
                    KadrController.Instance.Model.SubmitChanges();
                }
            }
        }

        private void dgvTSRecord_DoubleClick(object sender, EventArgs e)
        {
            if (timeSheetFSWorkingDaysBindingSource.Current == null)
            {
                MessageBox.Show("Выберите запись для редактирования!");
                return;
            }

           if (!(timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).IsCreated)
            {
                MessageBox.Show("Выбранная запись еще не добавлена в табель!");
                return;
            }

             if ((timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).TimeSheetFSRecord.TimeSheet.IsClosed == true)
            {
                MessageBox.Show("Табель рабочего времени закрыт для редактирования!");
                return;
            }


            LinqActionsController<TimeSheetFSWorkingDay>.Instance.EditObject((timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).TimeSheetFSRecord, true);
            (timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).TimeSheetFSRecord =
                (timeSheetFSWorkingDaysBindingSource.Current as TimeSheetRecord).TimeSheetFSRecord;
        }

        private void cbTimeSheet_SelectedIndexChanged(object sender, EventArgs e)
        {
           
            CurrentTimeSheet = cbTimeSheet.SelectedItem as TimeSheet;
            //получаем список сотрyдников отдела за период
            IEnumerable<GetFactStaffForTimeSheetResult> staff = CurrentTimeSheet.GetStaffByPeriod().ToArray();

            IEnumerable<GetFactStaffForTimeSheetResult> NotCreatedFactStaff = CurrentTimeSheet.GetNotInsertedStaff(staff).ToArray();
            timeSheetFSWorkingDaysBindingSource.DataSource = 
                ((from st in NotCreatedFactStaff
                 join fcSt in KadrController.Instance.Model.FactStaffs
                   on (int)st.idFactStaff
                   equals (int)fcSt.id
                 select new
                 {
                     TSRecord = st,
                     FactSt = fcSt
                 }).Select(depSt =>
                        new TimeSheetRecord(depSt.FactSt, CurrentTimeSheet, depSt.TSRecord.StaffCount, Convert.ToInt32(depSt.TSRecord.daysCount))).Union(CurrentTimeSheet.TimeSheetFSWorkingDays.Where(tsRecord =>
                        (tsRecord.IsClosed != true)).Select(tsRecord => new TimeSheetRecord(tsRecord)))).OrderBy(tsRecord => 
                            tsRecord.FactStaff.Employee.LastName).ThenBy(tsRecord => 
                                tsRecord.FactStaff.Employee.FirstName).ThenBy(tsRecord => tsRecord.FactStaff.Employee.Otch);

        }


        private void создатьЗановоToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbTimeSheet.SelectedItem == null)
            {
                MessageBox.Show("Выберите табель!");
                return;
            }

            if ((cbTimeSheet.SelectedItem as TimeSheet).TimeSheetFSWorkingDays.Count() > 0)
            {
                if (MessageBox.Show("При пересоздании табеля все ваши изменения будут потеряны. Вы хотите продолжить?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
                    == DialogResult.Cancel)
                {
                    return;
                }
            }
            (cbTimeSheet.SelectedItem as TimeSheet).CreateTimeSheetRecords(null);
            cbTimeSheet_SelectedIndexChanged(null, null);
        }

        private void добавитьНедостающиеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (cbTimeSheet.SelectedItem == null)
            {
                MessageBox.Show("Выберите табель!");
                return;
            }

            (cbTimeSheet.SelectedItem as TimeSheet).UpdateDepartmentsTimeSheet(NullDepartment.Instance);
            cbTimeSheet_SelectedIndexChanged(null, null);
        }

        private void btnTSheetReportToExcel_Click(object sender, EventArgs e)
        {
            Kadr.Controllers.ExcelExportController.Instance.ExportToExcel(dgvTSRecord);
        }
    }
}
