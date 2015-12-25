using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using ClosedXML.Excel;
using Kadr.Data;

namespace Kadr.Reporting
{
    public class VacationPlanParams : ReportGenericParams
    {
        public VacationPlanParams(Guid departmentId, string template, string outputFile = null)
        {
            if (string.IsNullOrEmpty(template))
                throw new ArgumentException("Argument is null or empty", nameof(template));

            var today = DateTime.Today;
            Year = today.Month > 8 ? today.Year + 1 : today.Year;
            Department = departmentId;
            Template = template;
            OutputFileName = outputFile ??
                             $"{Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)}\\График отпусков {Year}.xlsx";
        }

        [Category("График отпусков")]
        [DisplayName("Год")]
        [Description("Год на который строится график отпусков")]
        public int Year { get; set; }

        [Browsable(false)]
        public Guid Department { get; }

        /// <summary>
        ///     Получает или устанавливает наименование листа Excel с отчётом
        /// </summary>
        [Category("График отпусков")]
        [DisplayName("Имя листа")]
        [Description("Наименование листа Microsoft Excel с отчётом")]
        public string PageName { get; set; }

        /// <summary>
        ///     Получает или устанавливает группировку записей отчёта по отделу
        /// </summary>
        [Category("График отпусков")]
        [DisplayName("Группировать по отделу")]
        [Description("Группировать записи графика отпусков по отделам")]
        public bool GroupByDepartment { get; set; }

        #region Overrides of Object

        /// <summary>
        ///     Returns a string that represents the current object.
        /// </summary>
        /// <returns>
        ///     A string that represents the current object.
        /// </returns>
        public override string ToString()
        {
            return $"Параметры графика отпусков";
        }

        #endregion
    }

    public static class ScheduleReportBuilder
    {
        private const int StartCol = 1;
        private const int ColWorkType = StartCol;
        private const int ColDepartment = ColWorkType + 1;
        private const int ColWorkPost = ColDepartment + 1;
        private const int ColName = ColWorkPost + 1;
        private const int ColDays = ColName + 1;
        private const int ColBeginDate = ColDays + 1;
        private const int ColEndDate = ColBeginDate + 1;
        private const int ColReserved1 = ColEndDate + 1;
        private const int ColReserved2 = ColReserved1 + 1;
        private const int ColReserved3 = ColReserved2 + 1;
        private const int ColReserved4 = ColReserved3 + 1;

        /// <summary>
        ///     Создаёт файл отчёта с графиком отпусков
        /// </summary>
        /// <param name="vacationParams"></param>
        /// <param name="dataSource"></param>
        ///// <param name="dataSource">Данные для отчёта</param>
        public static void Create(VacationPlanParams vacationParams,
            IEnumerable<FetchVacationPlansByDepartmentIdResult> dataSource)
        {
            if (vacationParams == null) throw new ArgumentNullException(nameof(vacationParams));
            if (dataSource == null) throw new ArgumentNullException(nameof(dataSource));


            var listOfVacationPlan = dataSource as IList<FetchVacationPlansByDepartmentIdResult> ?? dataSource.ToList();

            using (var wb = new XLWorkbook(vacationParams.Template))
            {
                var ws = wb.Worksheets.First();
                ws.Cell("E8").Value = DateTime.Today;
                ws.Cell("G8").Value = vacationParams.Year.ToString();
                try
                {
                    ws.Name = vacationParams.PageName ?? "График отпусков";
                }
                catch (Exception e)
                {
                    if (e.InnerException != null)
                    {
                        var err = e.InnerException.Message;
                    }
                }
                var currentRow = 15;
                if (vacationParams.GroupByDepartment)
                {
                    var grouped = listOfVacationPlan.GroupBy(x => x.DepartmentName).ToList();
                    foreach (var group in grouped)
                    {
                        if (grouped.Count > 1)
                            BuildGroupHeader(ws, group.Key, ref currentRow);
                        BuildDepartmentVacationPlanTable(group.ToList(), ws, ref currentRow);
                    }
                }
                else
                    BuildDepartmentVacationPlanTable(listOfVacationPlan, ws, ref currentRow);

                wb.SaveAs(vacationParams.OutputFileName);
            }
        }

        private static void BuildGroupHeader(IXLWorksheet ws, string departmentName, ref int currentRow)
        {
            ws.Cell(currentRow, StartCol).Value = departmentName;
            var headerCell = ws.Range(currentRow, StartCol, currentRow, ColReserved4).Merge();
            headerCell.Style.Font.Bold = true;
            headerCell.Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
            FormatRange(headerCell);
            ++currentRow;
        }

        private static void BuildDepartmentVacationPlanTable(
            IList<FetchVacationPlansByDepartmentIdResult> listOfVacationPlan,
            IXLWorksheet ws, ref int currentRow)
        {
            for (var currentItemIndex = 0; currentItemIndex < listOfVacationPlan.Count; ++currentItemIndex)
            {
                var currItem = listOfVacationPlan[currentItemIndex];

                ws.Cell(currentRow, ColWorkType).Value = currItem?.TypeWorkName;

                FormatRow(ws, currentRow, ColWorkType);
                ws.Cell(currentRow, 1).Style.Border.LeftBorder = XLBorderStyleValues.Thin;
                ws.Cell(currentRow, 1).Style.Border.LeftBorderColor = XLColor.Black;

                ws.Cell(currentRow, ColDepartment).Value = currItem?.DepartmentName;
                FormatRow(ws, currentRow, ColDepartment);

                ws.Cell(currentRow, ColWorkPost).Value = currItem?.PostName;
                FormatRow(ws, currentRow, ColWorkPost);

                ws.Cell(currentRow, ColName).Value = $"{currItem?.LastName} {currItem?.FirstName} {currItem?.Otch}";
                FormatRow(ws, currentRow, ColName);

                ws.Cell(currentRow, ColDays).Value = currItem?.CountDay.ToString();
                FormatRow(ws, currentRow, ColDays);

                ws.Cell(currentRow, ColBeginDate).Value = currItem?.DateBegin.ToString();
                FormatRow(ws, currentRow, ColBeginDate);

                ws.Cell(currentRow, ColEndDate).Value = currItem?.DateEnd.ToString();
                FormatRow(ws, currentRow, ColEndDate);

                FormatRow(ws, currentRow, ColReserved1);

                FormatRow(ws, currentRow, ColReserved2);

                FormatRow(ws, currentRow, ColReserved3);

                FormatRow(ws, currentRow, ColReserved4);

                ++currentRow;
            }
        }

        private static void FormatRange(IXLRange range)
        {
            range.Style.Border.BottomBorder = XLBorderStyleValues.Thin;
            range.Style.Border.BottomBorderColor = XLColor.Black;
            range.Style.Border.RightBorder = XLBorderStyleValues.Thin;
            range.Style.Border.RightBorderColor = XLColor.Black;
            range.Style.Font.FontName = "Times New Roman";
        }

        private static void FormatRow(IXLWorksheet ws, int rowNum, int colNum)
        {
            var range = ws.Cell(rowNum, colNum).AsRange();
            FormatRange(range);
        }
    }
}