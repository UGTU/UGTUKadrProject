using System;
using System.Collections.Generic;
using ClosedXML.Excel;
using Kadr.Data;
using System.Linq;

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
        ///// <param name="dataSource">Данные для отчёта</param>
        public static void Create(string template, string outputFileName, IEnumerable<ViewVacationPlan> dataSource, int year)
        {
            if (string.IsNullOrEmpty(template)) throw new ArgumentNullException(nameof(template));
            if (string.IsNullOrEmpty(outputFileName)) throw new ArgumentNullException(nameof(outputFileName));
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));

            var listOfVacationPlan = (dataSource as IList<ViewVacationPlan>) ?? dataSource.ToList();

            using (var wb = new XLWorkbook(template))
            {

                var ws = wb.Worksheets.First();
                ws.Cell("E8").Value = DateTime.Now;

                ws.Cell("G8").Value = year.ToString();

                //var usedDataRange = ws.Range(14, 1, 20, 7);
                for (var currentItemIndex = 0; currentItemIndex < listOfVacationPlan.Count; ++currentItemIndex)
                {
                    var currentRow = currentItemIndex + 15;            
                    ws.Cell(currentRow, 1).Value = "Основная";
                    ws.Cell(currentRow, 1).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 1).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 1).Style.Border.LeftBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 1).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 1).Style.Border.RightBorderColor = XLColor.Black;

                    ws.Cell(currentRow, 2).Value = listOfVacationPlan[currentItemIndex].DepartmentName.ToString();
                    ws.Cell(currentRow, 2).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 2).Style.Border.BottomBorderColor = XLColor.Black;      
                    ws.Cell(currentRow, 2).Style.Border.RightBorder= XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 2).Style.Border.RightBorderColor= XLColor.Black;

                    ws.Cell(currentRow,3).Value = listOfVacationPlan[currentItemIndex].PostName.ToString();
                    ws.Cell(currentRow, 3).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 3).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 3).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 3).Style.Border.RightBorderColor = XLColor.Black;

                    ws.Cell(currentRow,4).Value = listOfVacationPlan[currentItemIndex].LastName.ToString()+" "+ listOfVacationPlan[currentItemIndex].FirstName.ToString()+" "+ listOfVacationPlan[currentItemIndex].Otch;
                    ws.Cell(currentRow, 4).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 4).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 4).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 4).Style.Border.RightBorderColor = XLColor.Black;

                    ws.Cell(currentRow,5).Value = listOfVacationPlan[currentItemIndex].CountDay.ToString();
                    ws.Cell(currentRow, 5).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 5).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 5).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 5).Style.Border.RightBorderColor = XLColor.Black;

                    ws.Cell(currentRow,6).Value = listOfVacationPlan[currentItemIndex].DateBegin.ToString();
                    ws.Cell(currentRow, 6).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 6).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 6).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 6).Style.Border.RightBorderColor = XLColor.Black;

                    ws.Cell(currentRow,7).Value = listOfVacationPlan[currentItemIndex].DateEnd.ToString();
                    ws.Cell(currentRow, 7).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 7).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 7).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 7).Style.Border.RightBorderColor = XLColor.Black;

                    ws.Cell(currentRow, 8).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 8).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 8).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 8).Style.Border.RightBorderColor = XLColor.Black;

                    ws.Cell(currentRow, 9).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 9).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 9).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 9).Style.Border.RightBorderColor = XLColor.Black;

                    ws.Cell(currentRow, 10).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 10).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 10).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 10).Style.Border.RightBorderColor = XLColor.Black;

                    ws.Cell(currentRow, 11).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 11).Style.Border.BottomBorderColor = XLColor.Black;
                    ws.Cell(currentRow, 11).Style.Border.RightBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 11).Style.Border.RightBorderColor = XLColor.Black;

                }

                wb.SaveAs(outputFileName);
            }

            //_template = template;
            //_dataSource = dataSource;
            //_outputFileName = outputFileName;
        }
        
    }
}
