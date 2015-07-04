using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Reflection;

namespace APG.CodeHelper.UI
{
    /// <summary>
    /// 
    /// </summary>
    public partial class ApplicationAboutDialog : Form
    {
        public static void ShowAbout()
        {
            using (ApplicationAboutDialog dlg = new ApplicationAboutDialog())
            {
                dlg.ShowDialog();
            }
        }
        public ApplicationAboutDialog()
        {
            InitializeComponent();
             
                                   
            foreach (Assembly assembly in System.AppDomain.CurrentDomain.GetAssemblies())
            {
                if (!assembly.GlobalAssemblyCache)
                {
                    if (assembly.EntryPoint != null)
                        BuildTitle(assembly);
                    ListViewItem item = new ListViewItem();
                    item.Text = AssemblyTitle(assembly);
                    item.SubItems.Add(AssemblyVersion(assembly));
                    item.SubItems.Add(AssemblyProduct(assembly));
                   
                    item.SubItems.Add(AssemblyDescription(assembly));
                    listView1.Items.Add(item);
                }
            }
            
        }

        private void BuildTitle(Assembly entry)
        {
            if (entry != null)
            {
                Text = AssemblyTitle(entry);
                this.labelTitle.Text = AssemblyTitle(entry);
                this.labelCopyright.Text = AssemblyCopyright(entry);
                this.labelCompanyName.Text = AssemblyCompany(entry);
                this.labelAssemblyVersion.Text = string.Format("Сборка {0} (Версия файла {1})", AssemblyVersion(entry), AssemblyFileVersion(entry));
                this.labelProduct.Text = AssemblyProduct(entry);
            }
        }

        #region Assembly Attribute Accessors

        public static string AssemblyTitle(Assembly assembly)
        {
                // Get all Title attributes on this assembly
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyTitleAttribute), false);
                // If there is at least one Title attribute
                if (attributes.Length > 0)
                {
                    // Select the first one
                    AssemblyTitleAttribute titleAttribute = (AssemblyTitleAttribute)attributes[0];
                    // If it is not an empty string, return it
                    if (titleAttribute.Title != "")
                        return titleAttribute.Title;
                }
                // If there was no Title attribute, or if the Title attribute was the empty string, return the .exe name
                try
                {
                    return System.IO.Path.GetFileNameWithoutExtension(assembly.CodeBase);
                }
                catch (NotSupportedException)
                {
                    return "Нет данных";
                }
            
        }

        public static string AssemblyVersion(Assembly assembly)
        {
                return assembly.GetName().Version.ToString();           
        }

        public static string AssemblyFileVersion(Assembly assembly)
        {
            // Get all Description attributes on this assembly
            object[] attributes = assembly.GetCustomAttributes(typeof(System.Reflection.AssemblyFileVersionAttribute), false);
            // If there aren't any Description attributes, return an empty string
            if (attributes.Length == 0)
                return "";
            // If there is a Description attribute, return its value
            return ((AssemblyFileVersionAttribute)attributes[0]).Version;
            
        }

        public static string AssemblyDescription(Assembly assembly)
        {
                // Get all Description attributes on this assembly
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyDescriptionAttribute), false);
                // If there aren't any Description attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Description attribute, return its value
                return ((AssemblyDescriptionAttribute)attributes[0]).Description;
        
        }

        public static string AssemblyProduct(Assembly assembly)
        {
                // Get all Product attributes on this assembly
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyProductAttribute), false);
                // If there aren't any Product attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Product attribute, return its value
                return ((AssemblyProductAttribute)attributes[0]).Product;
            
        }

        public static string AssemblyCopyright(Assembly assembly)
        {
            
            
                // Get all Copyright attributes on this assembly
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCopyrightAttribute), false);
                // If there aren't any Copyright attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Copyright attribute, return its value
                return ((AssemblyCopyrightAttribute)attributes[0]).Copyright;
            
        }

        public static string AssemblyCompany(Assembly assembly)
        {
                // Get all Company attributes on this assembly
                object[] attributes = assembly.GetCustomAttributes(typeof(AssemblyCompanyAttribute), false);
                // If there aren't any Company attributes, return an empty string
                if (attributes.Length == 0)
                    return "";
                // If there is a Company attribute, return its value
                return ((AssemblyCompanyAttribute)attributes[0]).Company;
            
        }
        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            SaveAssembliesReportDialog();
        }

        private void SaveAssembliesReportDialog()
        {
            using (SaveFileDialog dlg = new SaveFileDialog())
            {
                dlg.DefaultExt = "txt";
                dlg.Filter = "Текстовые файлы|*.txt|Все файлы|*.*";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    SaveReport(dlg.FileName);
                }
            }
        }

        private void SaveReport(string fileName)
        {
            using(System.IO.StreamWriter writer = new System.IO.StreamWriter(fileName))
            {
                foreach (Assembly assembly in System.AppDomain.CurrentDomain.GetAssemblies())
                {
                    writer.WriteLine(string.Format("{0}\tВерсия {1}\tФайл {2}\tОписание {3}", AssemblyTitle(assembly), AssemblyVersion(assembly), AssemblyFileVersion(assembly), AssemblyDescription(assembly)));
                }
            }
            
        }
    }
}
