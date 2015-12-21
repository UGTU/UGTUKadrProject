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
                const int colWorkType = 1;
                const int colDepartment = colWorkType + 1;
                const int colWorkPost = colDepartment + 1;
                const int colName = colWorkPost + 1;
                const int colDays = colName + 1;
                const int colBeginDate = colDays + 1;
                const int colEndDate = colBeginDate + 1;
                const int colReserved1 = colEndDate + 1;
                const int colReserved2 = colReserved1 + 1;
                const int colReserved3 = colReserved2 + 1;
                const int colReserved4 = colReserved3 + 1;

                var ws = wb.Worksheets.First();
                ws.Cell("E8").Value = DateTime.Today;
                ws.Cell("G8").Value = vacationParams.Year.ToString();
                ws.Name = vacationParams.PageName ?? "График отпусков";
                for (var currentItemIndex = 0; currentItemIndex < listOfVacationPlan.Count; ++currentItemIndex)
                {
                    var currentRow = currentItemIndex + 15;
                    var currItem = listOfVacationPlan[currentItemIndex];

                    ws.Cell(currentRow, colWorkType).Value = currItem?.TypeWorkName;

                    FormatRow(ws, currentRow, colWorkType);
                    ws.Cell(currentRow, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                    ws.Cell(currentRow, 1).Style.Border.LeftBorderColor = XLColor.Black;

                    ws.Cell(currentRow, colDepartment).Value = currItem?.DepartmentName;
                    FormatRow(ws, currentRow, colDepartment);

                    ws.Cell(currentRow, colWorkPost).Value = currItem?.PostName;
                    FormatRow(ws, currentRow, colWorkPost);

                    ws.Cell(currentRow, colName).Value = $"{currItem?.LastName} {currItem?.FirstName} {currItem?.Otch}";
                    FormatRow(ws, currentRow, colName);

                    ws.Cell(currentRow, colDays).Value = currItem?.CountDay.ToString();
                    FormatRow(ws, currentRow, colDays);

                    ws.Cell(currentRow, colBeginDate).Value = currItem?.DateBegin.ToString();
                    FormatRow(ws, currentRow, colBeginDate);

                    ws.Cell(currentRow, colEndDate).Value = currItem?.DateEnd.ToString();
                    FormatRow(ws, currentRow, colEndDate);

                    FormatRow(ws, currentRow, colReserved1);

                    FormatRow(ws, currentRow, colReserved2);

                    FormatRow(ws, currentRow, colReserved3);

                    FormatRow(ws, currentRow, colReserved4);

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
            ws.Cell(rowNum, colNum).Style.Font.FontName = "Times New Roman";
            //ws.Cell(rowNum, colNum).Style.Font.FontSize = 9;

        }
    }
}
