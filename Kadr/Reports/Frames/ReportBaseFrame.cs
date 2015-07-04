using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Reports.Frames
{
    public partial class ReportBaseFrame : UserControl
    {
        /// <summary>
        /// Тип отчета - то есть тип возвращаемых данных (хранимая функция БД)
        /// </summary>
        public System.Type ReportType
        {
            get;
            set;
        }

        /// <summary>
        /// Номер отчета (уникален для каждой функции)
        /// </summary>
        public int ReportNumber
        {
            get;
            set;
        }
        
        private int reportParam = -1;
        public int ReportParam
        {
            get
            {
                return reportParam;
            }
            set
            {
                if ((reportParam != value) && (value>0))
                {
                    reportParam = value;
                    //DoRefreshReport();
                }
            }
        }

        /// <summary>
        /// Сторить отчет с подотделами
        /// </summary>
        private bool withSubReports = true;
        public bool WithSubReports
        {
            get
            {
                return withSubReports;
            }
            set
            {
                if (withSubReports != value)
                {
                    withSubReports = value;
                    //RefreshReport();
                }
            }
        }


        /// <summary>
        /// контекст
        /// </summary>
        private KadrDataDataContext model;
        public KadrDataDataContext Model
        {
            get
            {
                if (model == null)
                {
                    model = new KadrDataDataContext();
                    model.CommandTimeout = 100000;
                }
                return model;
            }
        }
        
        /// <summary>
        /// Инициализирут отчет первичными параметрами - типом данных и номером отчета для кадого типа 
        /// </summary>
        /// <param name="ReportType"></param>
        /// <param name="ReportNumber"></param>
        public void InitializeReport(System.Type reportType, int reportNumber)
        {
            ReportType = reportType;
            ReportNumber = reportNumber;
            DoInitializeReport();
        }

        /// <summary>
        /// реальная инициализация реализуется в классе-потомке
        /// </summary>
        protected virtual void DoInitializeReport()
        {
        }
 
        /// <summary>
        /// обовление отчета
        /// </summary>
        public void RefreshReport()
        {
            DoRefreshReport();
        }

        private void DoRefreshReport()
        {
            //model = new KadrDataDataContext();
            if (ReportParam > 0)
            {
                LoadData();

                reportViewer1.RefreshReport();
            }
        }

        protected virtual void LoadData()
        {
            
        }


       public ReportBaseFrame()
        {
            InitializeComponent();
        }
    }
}
