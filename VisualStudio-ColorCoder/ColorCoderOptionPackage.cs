using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.InteropServices;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using VisualStudio_ColorCoder.Classifications;
using VisualStudio_ColorCoder.ColorCoderCore;


namespace VisualStudio_ColorCoder
{
    [Guid(Guids.ChangeColorOptionGrid)]
    public class ChangeColorOptionGrid : DialogPage
    {
        private ClassificationList _colors;

        private const string ColorSubCategory = "Colors";

        [Category(ColorSubCategory)]
        [DisplayName("Interface")]
        public Color Interface
        {
            get { return _colors.Get(ColorCoderClassificationName.Interface); }
            set { _colors.Set(ColorCoderClassificationName.Interface, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Abstract Class")]
        public Color AbstractClass
        {
            get { return _colors.Get(ColorCoderClassificationName.AbstractClass); }
            set { _colors.Set(ColorCoderClassificationName.AbstractClass, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Static Class")]
        public Color StaticClass
        {
            get { return _colors.Get(ColorCoderClassificationName.StaticClass); }
            set { _colors.Set(ColorCoderClassificationName.StaticClass, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Struct")]
        public Color Struct
        {
            get { return _colors.Get(ColorCoderClassificationName.Struct); }
            set { _colors.Set(ColorCoderClassificationName.Struct, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Enum")]
        public Color Enum
        {
            get { return _colors.Get(ColorCoderClassificationName.Enum); }
            set { _colors.Set(ColorCoderClassificationName.Enum, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Local Variable")]
        public Color Local
        {
            get { return _colors.Get(ColorCoderClassificationName.Local); }
            set { _colors.Set(ColorCoderClassificationName.Local, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Enum Member")]
        public Color EnumConstant
        {
            get { return _colors.Get(ColorCoderClassificationName.EnumConstant); }
            set { _colors.Set(ColorCoderClassificationName.EnumConstant, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Constructor")]
        public Color Constructor
        {
            get { return _colors.Get(ColorCoderClassificationName.Constructor); }
            set { _colors.Set(ColorCoderClassificationName.Constructor, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Attribute")]
        public Color Attribute
        {
            get { return _colors.Get(ColorCoderClassificationName.Attribute); }
            set { _colors.Set(ColorCoderClassificationName.Attribute, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Field")]
        public Color Field
        {
            get { return _colors.Get(ColorCoderClassificationName.Field); }
            set { _colors.Set(ColorCoderClassificationName.Field, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Namespace")]
        public Color Namespace
        {
            get { return _colors.Get(ColorCoderClassificationName.Namespace); }
            set { _colors.Set(ColorCoderClassificationName.Namespace, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Method")]
        public Color Method
        {
            get { return _colors.Get(ColorCoderClassificationName.Method); }
            set { _colors.Set(ColorCoderClassificationName.Method, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Static Method")]
        public Color StaticMethod
        {
            get { return _colors.Get(ColorCoderClassificationName.StaticMethod); }
            set { _colors.Set(ColorCoderClassificationName.StaticMethod, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Extension Method")]
        public Color ExtensionMethod
        {
            get { return _colors.Get(ColorCoderClassificationName.ExtensionMethod); }
            set { _colors.Set(ColorCoderClassificationName.ExtensionMethod, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Property")]
        public Color AutomaticProperty
        {
            get { return _colors.Get(ColorCoderClassificationName.Property); }
            set { _colors.Set(ColorCoderClassificationName.Property, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("TypeParameter")]
        public Color Parameter
        {
            get { return _colors.Get(ColorCoderClassificationName.TypeParameter); }
            set { _colors.Set(ColorCoderClassificationName.TypeParameter, value); }
        }

        public override void LoadSettingsFromStorage()
        {
            this._colors = new ClassificationList(new ColorStorage(this.Site));

            _colors.Load(
                ColorCoderClassificationName.AbstractClass,
                ColorCoderClassificationName.Attribute,
                ColorCoderClassificationName.Constructor,
                ColorCoderClassificationName.Enum,
                ColorCoderClassificationName.EnumConstant,
                ColorCoderClassificationName.ExtensionMethod,
                ColorCoderClassificationName.Field,
                ColorCoderClassificationName.Interface,
                ColorCoderClassificationName.Local,
                ColorCoderClassificationName.Method,
                ColorCoderClassificationName.Namespace,
                ColorCoderClassificationName.Property,
                ColorCoderClassificationName.StaticClass,
                ColorCoderClassificationName.StaticMethod,
                ColorCoderClassificationName.Struct,
                ColorCoderClassificationName.TypeParameter
                );
        }

        public override void SaveSettingsToStorage()
        {
            //_colors.Save();
        }
    }

    [PackageRegistration(UseManagedResourcesOnly = true)]
    [InstalledProductRegistration("#110", "#112", "1.0", IconResourceID = 400)]
    [Guid(Guids.ColorCoderOptionPackage)]
    [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1650:ElementDocumentationMustBeSpelledCorrectly", Justification = "pkgdef, VS and vsixmanifest are valid VS terms")]
    [ProvideOptionPage(typeof(ChangeColorOptionGrid), "ColorCoder", "General", 0, 0, true, Sort = 1)]
    public sealed class ColorCoderOptionPackage : Package
    {
        public ColorCoderOptionPackage() { }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}