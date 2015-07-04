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
    public partial class FactStaffHoursForm : Form
    {
        private FactStaff factStaff;

        public FactStaffHoursForm()
        {
            InitializeComponent();
        }

        public FactStaffHoursForm(FactStaff FactStaff)
        {
            InitializeComponent();
            factStaff = FactStaff;
        }

        private void FactStaffHoursForm_Load(object sender, EventArgs e)
        {
            factStaffMonthHourBindingSource.DataSource = KadrController.Instance.Model.FactStaffMonthHours.Where(fcStM =>
                fcStM.FactStaff == factStaff).OrderByDescending(fcStM => fcStM.YearNumber).OrderByDescending(fcStM => fcStM.MonthNumber);
            Text = "Часы для " + factStaff.ToString();
            RestHourStatus.Text = "Оставшееся количество часов: " + factStaff.RestHours.ToString() +
                "; стоимость часа: " + factStaff.LastChange.HourSalary.ToString() + " р.";
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddSalaryBtn_Click(object sender, EventArgs e)
        {
            KadrController.Instance.AddFactStaffMonthHour(factStaff);
            FactStaffHoursForm_Load(null, null);
        }

        private void EditPStChangeBtn_Click(object sender, EventArgs e)
        {

            FactStaffMonthHour CurrentChange = factStaffMonthHourBindingSource.Current as FactStaffMonthHour;
                if (CurrentChange == null)
                {
                    MessageBox.Show("Не выбрана редактируемая строка.", "АИС \"Штатное расписание\"");
                    return;
                }
                LinqActionsController<FactStaffMonthHour>.Instance.EditObject(CurrentChange, true);
         }

        private void DelPStChangeBtn_Click(object sender, EventArgs e)
        {
            FactStaffMonthHour CurrentChange = factStaffMonthHourBindingSource.Current as FactStaffMonthHour;
            if (CurrentChange == null)
            {
                MessageBox.Show("Не выбрана удаляемая строка.", "АИС \"Штатное расписание\"");
                return;
            }

            if (MessageBox.Show("Удалить строку?", "АИС Штатное расписание", MessageBoxButtons.OKCancel)
               == DialogResult.OK)
            {

                LinqActionsController<FactStaffMonthHour>.Instance.DeleteObject(CurrentChange,
                     KadrController.Instance.Model.FactStaffMonthHours, factStaffMonthHourBindingSource);

            }
        }
    }
}
