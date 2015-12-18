using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using Kadr.Data;

namespace Kadr.Reporting
{
    public static class ScheduleReportBuilder
    {
        //private IEnumerable<ViewVacationPlan> _dataSource;
        //private string _outputFileName;
        //private string _template;
        //private readonly XLWorkbook _workbook;


        /// <summary>
        /// Создаёт файл отчёта с графиком отпусков
        /// </summary>
        /// <param name="template">Полное имя файла шаблона отчёта</param>
        /// <param name="outputFileName">Полное имя выходного файла</param>
        /// <param name="dataSource">Данные для отчёта</param>
        public static void Create(string template, string outputFileName, IEnumerable<ViewVacationPlan> dataSource)
        {
            if (string.IsNullOrEmpty(template)) throw new ArgumentNullException(nameof(template));
            if (string.IsNullOrEmpty(outputFileName)) throw new ArgumentNullException(nameof(outputFileName));
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));
            using (var wb = new XLWorkbook(template))
            {

                var ws = wb.Worksheet(0);
                ws.Cell("E8").Value= DateTime.Now;

                //var usedDataRange = ws.Range(14,1,20,7);
                //foreach (var n in dataSource)
                ////foreach (var ROW in usedDataRange.Rows())
                //{
                //        ws.Cell("A15").Value = "Основная";
                //        ws.Cell("B15").Value = n.DepartmentName.ToString();
                //        ws.Cell("C15").Value = n.PostName.ToString();
                //        ws.Cell("D15").Value = n.LastName.ToString();
                //        ws.Cell("E15").Value = n.CountDay.ToString();
                //        ws.Cell("F15").Value = n.DateBegin.ToString();
                //        ws.Cell("G15").Value = n.DateEnd.ToString();               
                //}

                wb.SaveAs(outputFileName);
            }
            //_template = template;
            //_dataSource = dataSource;
            //_outputFileName = outputFileName;
        }




    }
}
