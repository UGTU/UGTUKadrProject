﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Kadr.Properties {
    
    
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Microsoft.VisualStudio.Editors.SettingsDesigner.SettingsSingleFileGenerator", "14.0.0.0")]
    internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase {
        
        private static Settings defaultInstance = ((Settings)(global::System.Configuration.ApplicationSettingsBase.Synchronized(new Settings())));
        
        public static Settings Default {
            get {
                return defaultInstance;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Больничный")]
        public string InkapacityDocTypeName {
            get {
                return ((string)(this["InkapacityDocTypeName"]));
            }
            set {
                this["InkapacityDocTypeName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Награда")]
        public string AwardDocTypeName {
            get {
                return ((string)(this["AwardDocTypeName"]));
            }
            set {
                this["AwardDocTypeName"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Социальный статус")]
        public string SocialDocType {
            get {
                return ((string)(this["SocialDocType"]));
            }
            set {
                this["SocialDocType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("Свидетельство прохождения аттестации")]
        public string ValidationDocType {
            get {
                return ((string)(this["ValidationDocType"]));
            }
            set {
                this["ValidationDocType"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("1")]
        public int SexImagesInterval {
            get {
                return ((int)(this["SexImagesInterval"]));
            }
            set {
                this["SexImagesInterval"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ugtudb;Initial Catalog=Kadr;Integrated Security=True")]
        public string kadrConnectionString {
            get {
                return ((string)(this["kadrConnectionString"]));
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ugtudb.ugtu.net;Initial Catalog=KadrRealTest;Integrated Security=True" +
            "")]
        public string KadrRealTestConnectionString1 {
            get {
                return ((string)(this["KadrRealTestConnectionString1"]));
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("3")]
        public byte DisplayVacationsYears {
            get {
                return ((byte)(this["DisplayVacationsYears"]));
            }
            set {
                this["DisplayVacationsYears"] = value;
            }
        }
        
        [global::System.Configuration.UserScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.DefaultSettingValueAttribute("(Не задано)")]
        public string NullName {
            get {
                return ((string)(this["NullName"]));
            }
            set {
                this["NullName"] = value;
            }
        }
        
        [global::System.Configuration.ApplicationScopedSettingAttribute()]
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.Configuration.SpecialSettingAttribute(global::System.Configuration.SpecialSetting.ConnectionString)]
        [global::System.Configuration.DefaultSettingValueAttribute("Data Source=ugtudb;Initial Catalog=KadrRealTest;Integrated Security=True")]
        public string KadrRealTestConnectionString2 {
            get {
                return ((string)(this["KadrRealTestConnectionString2"]));
            }
        }
    }
}
