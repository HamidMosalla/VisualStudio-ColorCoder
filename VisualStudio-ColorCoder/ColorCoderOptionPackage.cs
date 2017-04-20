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
    public enum Preset
    {
        SuperChargerStyle = 0,
        ScottHanselmansDream = 1,
        MoreGirlsInTechPlease = 2
    }
    public class ColorCoderOptionPageGrid : DialogPage
    {
        private const string PresetSubCategory = "Presets";

        [Category(PresetSubCategory)]
        [DisplayName("Preset")]
        [Description("Select from one of the available sets of Presets")]
        public Preset Preset { get; set; }


        private const string ColorSubCategory = "Colors";

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
    }

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(ColorCoderOptionPackage.PackageGuidString)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideOptionPage(typeof(ColorCoderOptionPageGrid), "ColorCoder", "General", 0, 0, true)]
    public sealed class ColorCoderOptionPackage : Package
    {
        public const string PackageGuidString = "0bf71f6b-990b-49ac-809a-940c37a463f3";
        
        public ColorCoderOptionPackage(){ }
      
        protected override void Initialize(){ base.Initialize(); }
    }
}