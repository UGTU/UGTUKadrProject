using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace APG.CodeHelper
{
    public class DataGridViewHelper
    {
        // GUI для ввода даты начала/окончания события
        private static DateTimePicker dtpEventDatePicker = null;
        // Текущий DataGridView для передачи в обработчик сообщений
        private static DataGridView currentDataGridView = null;

        // Показывает на экране элемент для ввода даты и времени
        public static void EnterDateTimeCell(DataGridView dataGridView, DataGridViewCellEventArgs e, DateTimePickerFormat dateTimePickerFormat)
        {
            if (dataGridView.Columns[e.ColumnIndex].ValueType == typeof(DateTime))
            {
                CreateDateTimePicker();

                currentDataGridView = dataGridView;
                dtpEventDatePicker.Tag = e;

                //dtpEventDatePicker.TextChanged += new EventHandler(dtpEventDatePicker_TextChanged);

                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value is DateTime)
                    dtpEventDatePicker.Value = (DateTime)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                else
                    dtpEventDatePicker.Value = DateTime.Today;

                dtpEventDatePicker.Format = dateTimePickerFormat;
                
                if (dtpEventDatePicker.Format == DateTimePickerFormat.Time)
                    dtpEventDatePicker.ShowUpDown = true;
                else
                    dtpEventDatePicker.ShowUpDown = false;

                
                dtpEventDatePicker.Parent = dataGridView;
                dtpEventDatePicker.Bounds = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);


                dtpEventDatePicker.Visible = !dataGridView.ReadOnly;
                


            }
        }

        static void dtpEventDatePicker_TextChanged(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs args = (sender as DateTimePicker).Tag as DataGridViewCellEventArgs;
            
            if ((args !=null) && (currentDataGridView!=null))
            {
                PutBackDateTimeValue(currentDataGridView, args);
            }
        }
       
        public static void EnterDateTimeCell(DataGridView dataGridView, DataGridViewCellEventArgs e, string customFromat)
        {
            if (dataGridView.Columns[e.ColumnIndex].ValueType == typeof(DateTime))
            {
                CreateDateTimePicker();

                currentDataGridView = dataGridView;
                dtpEventDatePicker.Tag = e;

                
                if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value is DateTime)
                    dtpEventDatePicker.Value = (DateTime)dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value;
                else
                    dtpEventDatePicker.Value = DateTime.Today;

                dtpEventDatePicker.Format = DateTimePickerFormat.Custom;
                dtpEventDatePicker.CustomFormat = customFromat;
                dtpEventDatePicker.Parent = dataGridView;
                dtpEventDatePicker.Bounds = dataGridView.GetCellDisplayRectangle(e.ColumnIndex, e.RowIndex, false);
                dtpEventDatePicker.ShowUpDown = true;
                dtpEventDatePicker.Visible = true;

            }
        }

        private static void CreateDateTimePicker()
        {
            if (dtpEventDatePicker == null)
            {
                DoCreateGridView();
            }
            else
            {
                if (dtpEventDatePicker.IsDisposed)
                {
                    DoCreateGridView();
                }
            }
        }

        private static void DoCreateGridView()
        {
            dtpEventDatePicker = new DateTimePicker();
            dtpEventDatePicker.TextChanged += new EventHandler(dtpEventDatePicker_TextChanged);
            dtpEventDatePicker.LostFocus += new EventHandler(dtpEventDatePicker_LostFocus);
        }

        static void dtpEventDatePicker_LostFocus(object sender, EventArgs e)
        {
            DataGridViewCellEventArgs args = (sender as DateTimePicker).Tag as DataGridViewCellEventArgs;

            if ((args != null) && (currentDataGridView != null))
            {
                DoLeaveDateTimeCell(currentDataGridView, args);
            }
        }

        // Записыват значение даты/времени в указанную ячейку и скрывает элемент ввода даты и времени
        public static void LeaveDateTimeCell(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            DoLeaveDateTimeCell(dataGridView, e);
        }

        private static void DoLeaveDateTimeCell(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            PutBackDateTimeValue(dataGridView, e);
            if (dtpEventDatePicker != null)
            {
                dtpEventDatePicker.Visible = false;
            }
        }

        private static void PutBackDateTimeValue(DataGridView dataGridView, DataGridViewCellEventArgs e)
        {
            if (dtpEventDatePicker != null)
            {
                if ((e.ColumnIndex != -1) && (e.RowIndex != -1))
                {
                    if ((dataGridView.Rows.Count > 0) && (dataGridView.ColumnCount > 0))
                    {
                        if (dataGridView.Columns[e.ColumnIndex].ValueType == typeof(DateTime))
                        {
                            dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = dtpEventDatePicker.Value;

                        }
                    }
                }
            }
        }

        public static void CellDataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.Cancel = true;
            e.ThrowException = false;
            if ((e.RowIndex != -1) && (e.ColumnIndex != -1))
            {
                (sender as DataGridView).Rows[e.RowIndex].Cells[e.ColumnIndex].ErrorText = e.Exception.Message;
            }
            else
                e.ThrowException = true;
        }
    }
}
