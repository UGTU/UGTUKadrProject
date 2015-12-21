using System.ComponentModel;

namespace Kadr.Reporting
{
    public class ReportGenericParams
    {
        public ReportGenericParams()
        {
            RunShellAfterCreate = true;
        }
        /// <summary>
        /// Получает или устанавливает полный путь к файлу отчёта
        /// </summary>
        [Category("Параметры отчёта")]
        [DisplayName("Файл отчёта")]
        [Description("Полный путь к файлу формата Microsoft Excel, который будет содержать график отпусков")]
        public string OutputFileName { get; set; }

        /// <summary>
        /// Получает или устанавливает полный путь к файлу шаблона отчёта
        /// </summary>
        [Category("Параметры отчёта")]
        [DisplayName("Файл шаблона отчёта")]
        [Description("Полный путь к файлу формата Microsoft Excel, который содержит шаблон для отчёта. Как правило менять этот параметр не требуется.")]
        public string Template { get; set; }

        /// <summary>
        /// Получает или устанавливает необходимость запуска средства просмотра отчёта
        /// </summary>
        [Category("Параметры отчёта")]
        [DisplayName("Запустить средство просмотра")]
        [Description("После создания файла с отчётом запустить средство просмотра этого отчёта.")]
        public bool RunShellAfterCreate { get; set; }
    }
}