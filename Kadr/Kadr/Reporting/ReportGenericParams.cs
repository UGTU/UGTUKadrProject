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
        /// �������� ��� ������������� ������ ���� � ����� ������
        /// </summary>
        [Category("��������� ������")]
        [DisplayName("���� ������")]
        [Description("������ ���� � ����� ������� Microsoft Excel, ������� ����� ��������� ������ ��������")]
        public string OutputFileName { get; set; }

        /// <summary>
        /// �������� ��� ������������� ������ ���� � ����� ������� ������
        /// </summary>
        [Category("��������� ������")]
        [DisplayName("���� ������� ������")]
        [Description("������ ���� � ����� ������� Microsoft Excel, ������� �������� ������ ��� ������. ��� ������� ������ ���� �������� �� ���������.")]
        public string Template { get; set; }

        /// <summary>
        /// �������� ��� ������������� ������������� ������� �������� ��������� ������
        /// </summary>
        [Category("��������� ������")]
        [DisplayName("��������� �������� ���������")]
        [Description("����� �������� ����� � ������� ��������� �������� ��������� ����� ������.")]
        public bool RunShellAfterCreate { get; set; }
    }
}