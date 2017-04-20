//------------------------------------------------------------------------------
// <copyright file="ColorCoderOptionPackage.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using System.ComponentModel;
using System.Drawing;

namespace VisualStudio_ColorCoder
{
    public class PresetOptionGrid : DialogPage
    {
        private const string PresetSubCategory = "Presets";

        [Category(PresetSubCategory)]
        [DisplayName("Preset")]
        [Description("Select from one of the available sets of Presets")]
        public Preset Preset { get; set; }

        public override void LoadSettingsFromStorage()
        {
            var settings = Settings.Load();
            Preset = settings.Preset;
        }

        public override void SaveSettingsToStorage()
        {
            if (Preset == Preset.NoPreset) return;

            var settings = SettingFactory.Create(Preset);

            settings.Save();
        }
    }

    public class ChangeColorOptionGrid : DialogPage
    {
        private const string ColorSubCategory = "Colors";

        //public Preset Preset { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Interface")]
        public Color Interface { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Class")]
        public Color Class { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Abstract Class")]
        public Color AbstractClass { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Static Class")]
        public Color StaticClass { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Struct")]
        public Color Struct { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Enum")]
        public Color Enum { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Enum Constant")]
        public Color EnumConstant { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Constructor")]
        public Color Constructor { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Attribute")]
        public Color Attribute { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Field")]
        public Color Field { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Namespace")]
        public Color Namespace { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Method")]
        public Color Method { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Static Method")]
        public Color StaticMethod { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Extension Method")]
        public Color ExtensionMethod { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Automatic Property")]
        public Color AutomaticProperty { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Parameter")]
        public Color Parameter { get; set; }


        public override void LoadSettingsFromStorage()
        {
            var settings = Settings.Load();

            //Preset = settings.Preset;
            Interface = settings.Interface;
            Class = settings.Class;
            AbstractClass = settings.AbstractClass;
            StaticClass = settings.StaticClass;
            Struct = settings.Struct;
            Enum = settings.Enum;
            EnumConstant = settings.EnumConstant;
            Constructor = settings.Constructor;
            Attribute = settings.Attribute;
            Field = settings.Field;
            Namespace = settings.Namespace;
            Method = settings.Method;
            StaticMethod = settings.StaticMethod;
            ExtensionMethod = settings.ExtensionMethod;
            AutomaticProperty = settings.AutomaticProperty;
            Parameter = settings.Parameter;
        }

        public override void SaveSettingsToStorage()
        {
            var settings = new Settings
            {
                //TODO: do something here to keep the preset colors and change only the filled colors
                //Preset = Preset,
                Interface = Interface,
                Class = Class,
                AbstractClass = AbstractClass,
                StaticClass = StaticClass,
                Struct = Struct,
                Enum = Enum,
                EnumConstant = EnumConstant,
                Constructor = Constructor,
                Attribute = Attribute,
                Field = Field,
                Namespace = Namespace,
                Method = Method,
                StaticMethod = StaticMethod,
                ExtensionMethod = ExtensionMethod,
                AutomaticProperty = AutomaticProperty,
                Parameter = Parameter,
            };
            settings.Save();
        }
    }

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(ColorCoderOptionPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    //TODO: fix the option page priority
    [ProvideOptionPage(typeof(PresetOptionGrid), "ColorCoder", "Presets", 0, 0, true, Sort = 0)]
    [ProvideOptionPage(typeof(ChangeColorOptionGrid), "ColorCoder", "General", 0, 0, true, Sort = 1)]
    public sealed class ColorCoderOptionPackage : Package
    {
        public const string PackageGuidString = "0bf71f6b-990b-49ac-809a-940c37a463f3";

        public ColorCoderOptionPackage() { }

        protected override void Initialize() { base.Initialize(); }
    }
}