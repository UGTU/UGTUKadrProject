using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using System.Data.Linq;

using System.Runtime.InteropServices;
using Microsoft.VisualBasic;
using System.Runtime.InteropServices;
using Microsoft.Office.Interop.Excel;
using Microsoft.Office.Interop;
using System.Threading;
using Kadr.Data;




namespace Kadr.Controllers
{
    /// <summary>
    /// Контроллер для работы с Excel
    /// </summary>
    class ExcelExportController
    {
        public ExcelExportController()
        {
        }

        private static ExcelExportController instance;

        public static ExcelExportController Instance
        {
            get
            {
                if (instance == null)
                    instance = new ExcelExportController();
                return instance;
            }
        }

        /// <summary>
        /// Экспорт в Excel переданного DataGridView
        /// </summary>
        /// <param name="GridView"></param>
        public void ExportToExcel(DataGridView GridView)
        {
            ApplicationClass Excel = new ApplicationClass();
            XlReferenceStyle RefStyle = Excel.ReferenceStyle;
            Workbook wb = null;
            //String TemplatePath = System.Windows.Forms.Application.StartupPath + @"\Экспорт данных.xlt";
            try
            {
                wb = Excel.Workbooks.Add(); // !!! 
            }
            catch  { throw new Exception("Не удалось загрузить документ "); }
            Worksheet ws = wb.Worksheets.get_Item(1) as Worksheet;
            
            //настройка и форматирование
            char ch = new char();
            ch = (char)(GridView.Columns.Count+(int)'A'-1);
            ws.Range["A1", ch + (GridView.Rows.Count + 1).ToString()].Cells.NumberFormat = "@";
            
            //вывод данных
            for (int j = 0; j < GridView.Columns.Count; ++j)
            {
                (ws.Cells[1, j + 1] as Range).Value2 = GridView.Columns[j].HeaderText;
                

                for (int i = 0; i < GridView.Rows.Count; ++i)
                {
                    object Val = GridView.Rows[i].Cells[j].Value;
                    if (Val != null)
                    {
                        //если тип колонки - CheckBox, заносим да и Нет
                        if (GridView.Columns[j].GetType() == typeof(DataGridViewCheckBoxColumn))
                        {
                            if (Convert.ToBoolean(Val))
                                (ws.Cells[i + 2, j + 1] as Range).Value2 = "Да";
                            else
                                (ws.Cells[i + 2, j + 1] as Range).Value2 = "Нет";
                        }
                        else
                            (ws.Cells[i + 2, j + 1] as Range).Value2 = Val.ToString();
                    }

                    
                }
            }
            

            //итоговая настройка
            //(ws.Cells[GridView.Rows.Count, GridView.Columns.Count] as Range).AutoFit();
            //(ws.Cells[GridView.Rows.Count, GridView.Columns.Count] as Range).Borders.ColorIndex = 1000;
            ws.Range["A1", ch + (GridView.Rows.Count + 1).ToString()].Columns.AutoFit();
            ws.Range["A1", ch + (GridView.Rows.Count + 1).ToString()].Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            Excel.Visible = true;
            Excel.ReferenceStyle = RefStyle;
            ReleaseExcel(Excel as Object);
        }

        /// <summary>
        /// выгрузка в Excel подчиненных отделов
        /// </summary>
        /// <param name="dep"></param>
        public void ExportDepartmentsToExcel(int idDepartment)
        {
            if (idDepartment < 1)
                return;

            //KadrController.Instance.Model.CommandTimeout = 100000;

            //загрузка данных
            IEnumerable<GetFullSubDepartmentsResult> subDeps = 
                KadrController.Instance.Model.GetFullSubDepartments(idDepartment, DateTime.Today, DateTime.Today);

            //экспорт данных
            ApplicationClass Excel = new ApplicationClass();
            XlReferenceStyle RefStyle = Excel.ReferenceStyle;
            Workbook wb = null;
            //String TemplatePath = System.Windows.Forms.Application.StartupPath + @"\Экспорт данных.xlt";
            try
            {
                wb = Excel.Workbooks.Add(); // !!! 
            }
            catch { throw new Exception("Не удалось загрузить документ "); }
            Worksheet ws = wb.Worksheets.get_Item(1) as Worksheet;

            //вывод данных
            int RowNumber = 1;
            (ws.Cells[RowNumber, 1] as Range).Value2 = "Проректор";
            (ws.Cells[RowNumber, 2] as Range).Value2 = "Краткое название руководящего отдела";
            (ws.Cells[RowNumber, 3] as Range).Value2 = "Руководящий отдел";
            (ws.Cells[RowNumber, 4] as Range).Value2 = "Краткое название отдела";
            (ws.Cells[RowNumber, 5] as Range).Value2 = "Название отдела";
            foreach (GetFullSubDepartmentsResult subDep in subDeps)
            {
                RowNumber++;
                (ws.Cells[RowNumber, 1] as Range).Value2 = subDep.ManagerName;
                (ws.Cells[RowNumber, 2] as Range).Value2 = subDep.DepartmentManagerSmallName;
                (ws.Cells[RowNumber, 3] as Range).Value2 = subDep.DepartmentManagerName;
                (ws.Cells[RowNumber, 4] as Range).Value2 = subDep.DepartmentSmallName;
                (ws.Cells[RowNumber, 5] as Range).Value2 = subDep.DepartmentName;
            }


            //итоговая настройка
            ws.Range["A1", "D" + RowNumber.ToString()].Columns.AutoFit();
            ws.Range["A1", "D" + RowNumber.ToString()].Borders.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.Black);
            Excel.Visible = true;
            Excel.ReferenceStyle = RefStyle;
            ReleaseExcel(Excel as Object);
        }

        private void ReleaseExcel(object excel)
        {
            // Уничтожение объекта Excel.
            Marshal.ReleaseComObject(excel);
            // Вызываем сборщик мусора для немедленной очистки памяти
            GC.GetTotalMemory(true);
        }
    }
}
