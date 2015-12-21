using System;
using System.Diagnostics;
using Kadr.Reporting;

namespace Kadr.UI.Reporting
{
    /// <summary>
    /// ���������� ���� � ���������� �������� 
    /// </summary>
    public interface IScriptAction
    {
        /// <summary>
        /// ���������� ��������
        /// </summary>
        void Run();
    }

    /// <summary>
    /// ������� ����� ��� ������� ���������� ������. ��������� ���� �� 
    /// ����������� ������� ��������� ���������� ������ �
    /// ������� �������� ��������� �������� ������
    /// </summary>
    /// <typeparam name="T">��� ��������� ������, ����������� �� ReportGenericParams</typeparam>
    public abstract class ReportScript<T> : IScriptAction where T : ReportGenericParams
    {
        /// <summary>
        /// �������� ������ ���������� ������
        /// </summary>
        public T ReportParams { get; private set; }

        /// <summary>
        /// ������ ������ ReportScript
        /// </summary>
        /// <param name="reportParams">������ ���������� ������</param>
        protected ReportScript(T reportParams)
        {
            if (reportParams == null) throw new ArgumentNullException(nameof(reportParams));
            ReportParams = reportParams;
        }

        /// <summary>
        /// ��������� ������������� �������� �� �������� ������. 
        /// �������������� � ����������� ������
        /// </summary>
        protected abstract void CreateReport();

        /// <summary>
        /// ��������� �������� �� �������� ������
        /// </summary>
        public void Run()
        {
            // ��������� ���������� ������ �������������
            using (var dlg = new UIX.UI.PropertyGridViewerDialog())
            {
                dlg.SelectedObject = ReportParams;
                dlg.OkButtonText = "�������";
                if (dlg.ShowDialog() != System.Windows.Forms.DialogResult.OK) return;
            }

            // ���������� �������� �� �������� ������
            CreateReport();

            // ���� ���������� ��������� �������� ��������� �������
            try
            {
                if (ReportParams.RunShellAfterCreate)
                    RunShell();
            }
            catch (Exception exception)
            {
                throw new ApplicationException($"���� � ������� ������� �������� �� ������ {ReportParams.OutputFileName}, ������ �� ������� ��������� �������� ���������. ���������� �� ������ ���������� �� ��������� ���������.", exception);
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