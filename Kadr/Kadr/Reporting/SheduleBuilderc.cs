using System;
using System.Collections.Generic;
using System.ComponentModel;
using ClosedXML.Excel;
using Kadr.Data;
using System.Linq;

namespace Kadr.Reporting
{
    public class VacationPlanParams : ReportGenericParams
    {
        [Category("График отпусков")]
        [DisplayName("Год")]
        [Description("Год на который строится график отпусков")]
        public int Year { get; set; }

        [System.ComponentModel.Browsable(false)]
        public Guid Department { get; }

        /// <summary>
        /// Получает или устанавливает наименование листа Excel с отчётом
        /// </summary>
        [Category("График отпусков")]
        [DisplayName("Имя листа")]
        [Description("Наименование листа Microsoft Excel с отчётом")]
        public string PageName { get; set; }
        public VacationPlanParams(Guid departmentId, string template, string outputFile = null)
        {
            if (string.IsNullOrEmpty(template))
                throw new ArgumentException("Argument is null or empty", nameof(template));

            var today = DateTime.Today;
            Year = (today.Month > 8 ? today.Year + 1 : today.Year);
            Department = departmentId;
            Template = template;
            OutputFileName = outputFile ??
                $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\График отпусков {Year}.xlsx";
        }

        #region Overrides of Object

        /// <summary>
        /// Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        /// A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return $"Параметры графика отпусков";
        }

        #endregion
    }
    public static class ScheduleReportBuilder
    {
        /// <summary>
        /// Создаёт файл отчёта с графиком отпусков
        /// </summary>
        /// <param name="vacationParams"></param>
        /// <param name="dataSource"></param>
        ///// <param name="dataSource">Данные для отчёта</param>
        public static void Create(VacationPlanParams vacationParams, IEnumerable<FetchVacationPlansByDepartmentIdResult> dataSource)
        {
            if (vacationParams == null) throw new ArgumentNullException(nameof(vacationParams));

            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));

            var listOfVacationPlan = (dataSource as IList<FetchVacationPlansByDepartmentIdResult>) ?? dataSource.ToList();

            using (var wb = new XLWorkbook(vacationParams.Template))
            {
                var ws = wb.Worksheets.First();
                ws.Cell("E8").Value = DateTime.Today;
                ws.Cell("G8").Value = vacationParams.Year.ToString();
                ws.Name = vacationParams.PageName ?? "График отпусков";
                for (var currentItemIndex = 0; currentItemIndex < listOfVacationPlan.Count; ++currentItemIndex)
                {
                    var currentRow = currentItemIndex + 15;            
                    ws.Cell(currentRow, 1).Value = "Основная";

                    FormatRow(ws, currentRow, 1);
                    ws.Cell(currentRow, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 1).Style.Border.LeftBorderColor = XLColor.Black;

                    ws.Cell(currentRow, 2).Value = listOfVacationPlan[currentItemIndex].DepartmentName.ToString();
                    FormatRow(ws, currentRow,2 );

                    ws.Cell(currentRow,3).Value = listOfVacationPlan[currentItemIndex].PostName.ToString();
                    FormatRow(ws, currentRow,3);

                    ws.Cell(currentRow,4).Value = listOfVacationPlan[currentItemIndex].LastName.ToString()+" "+ listOfVacationPlan[currentItemIndex].FirstName.ToString()+" "+ listOfVacationPlan[currentItemIndex].Otch;
                    FormatRow(ws, currentRow,4);

                    ws.Cell(currentRow,5).Value = listOfVacationPlan[currentItemIndex].CountDay.ToString();
                    FormatRow(ws, currentRow,5);

                    ws.Cell(currentRow,6).Value = listOfVacationPlan[currentItemIndex].DateBegin.ToString();
                    FormatRow(ws, currentRow,6);

                    ws.Cell(currentRow,7).Value = listOfVacationPlan[currentItemIndex].DateEnd.ToString();
                    FormatRow(ws, currentRow,7);

                    FormatRow(ws, currentRow, 8);

                    FormatRow(ws, currentRow, 9);

                    FormatRow(ws, currentRow, 10);

                    FormatRow(ws, currentRow, 11);

                }

                wb.SaveAs(vacationParams.OutputFileName);
            }

            //_template = template;
            //_dataSource = dataSource;
            //_outputFileName = outputFileName;
        }

        private static void FormatRow(IXLWorksheet ws, int rowNum, int colNum)
        {
            ws.Cell(rowNum, colNum).Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            ws.Cell(rowNum, colNum).Style.Border.BottomBorderColor = XLColor.Black;
            ws.Cell(rowNum, colNum).Style.Border.RightBorder = XLBorderStyleValues.Thin;
            ws.Cell(rowNum, colNum).Style.Border.RightBorderColor = XLColor.Black;
        }
    }
}
