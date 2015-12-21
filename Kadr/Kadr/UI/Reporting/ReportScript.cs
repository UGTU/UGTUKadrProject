using System;
using System.Diagnostics;
using Kadr.Reporting;

namespace Kadr.UI.Reporting
{
    /// <summary>
    /// Определяет типы с поддержкой действия 
    /// </summary>
    public interface IScriptAction
    {
        /// <summary>
        /// Выполнение действия
        /// </summary>
        void Run();
    }

    /// <summary>
    /// Базовый класс для скрипта подготовки отчёта. Реализует шаги по 
    /// отображению диалога изменения параметров отчёта и
    /// запуска средства просмотра готового отчёта
    /// </summary>
    /// <typeparam name="T">Тип параметра отчёта, производный от ReportGenericParams</typeparam>
    public abstract class ReportScript<T> : IScriptAction where T : ReportGenericParams
    {
        /// <summary>
        /// Получает объект параметров отчёта
        /// </summary>
        public T ReportParams { get; private set; }

        /// <summary>
        /// Создаёт объект ReportScript
        /// </summary>
        /// <param name="reportParams">Объект параметров отчёта</param>
        protected ReportScript(T reportParams)
        {
            if (reportParams == null) throw new ArgumentNullException(nameof(reportParams));
            ReportParams = reportParams;
        }

        /// <summary>
        /// Выполняет специфические действия по созданию отчёта. 
        /// Переопределите а производном классе
        /// </summary>
        protected abstract void CreateReport();

        /// <summary>
        /// Выполняет действие по созданию отчёта
        /// </summary>
        public void Run()
        {
            // Изменение параметров отчёта пользователем
            using (var dlg = new UIX.UI.PropertyGridViewerDialog())
            {
                dlg.SelectedObject = ReportParams;
                dlg.OkButtonText = "Создать";
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            }

            // Выполнение действий по созданию отчёта
            CreateReport();

            // Если необходимо запустить средство просмотра отчётов
            try
            {
                if (ReportParams.RunShellAfterCreate)
                    RunShell();
            }
            catch (Exception exception)
            {
                throw new ApplicationException($"Файл с отчётом успешно построен по адресу {ReportParams.OutputFileName}, однако не удалось запустить средство просмотра. Информация об ошибке содержится во вложенном сообщении.", exception);
            }
        }
        private void RunShell()
        {
            var psi = new ProcessStartInfo(ReportParams.OutputFileName);
            var p = new Process { StartInfo = psi };
            p.Start();
        }
    }
}