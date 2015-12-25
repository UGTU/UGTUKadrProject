using Kadr.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Kadr.UI.Common
{
    internal class SettingsDecorator
    {
        private Settings _settings;

        public SettingsDecorator(Settings settings)
        {
            _settings = settings;
        }

        [DisplayName("Папка для отчётов")]
        [Editor(typeof(Kadr.UI.Editors.BrowseFolderEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ReportOutput
        {
            get
            {
                return _settings.ReportsOutputFolder;
            }
            set
            {
                _settings.ReportsOutputFolder = value;
            }
        }

        public void Save()
        {

        }

    }
}
