//------------------------------------------------------------------------------
// <copyright file="ColorCoderOptionPackage.cs" company="Company">
//     Copyright (c) Company.  All rights reserved.
// </copyright>
//------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Drawing;
using System.Globalization;
using System.Runtime.InteropServices;
using ColorCoder.Classifications;
using ColorCoder.ColorCoderCore;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.OLE.Interop;
using Microsoft.VisualStudio.Shell;
using Microsoft.VisualStudio.Shell.Interop;
using Microsoft.Win32;
using VisualStudio_ColorCoder.Classifications;
using VisualStudio_ColorCoder.ColorCoderCore;

namespace ColorCoder
{
    [Guid(Guids.ChangeColorOptionGrid)]
    public class ChangeColorOptionGrid : DialogPage
    {
        private ColorManager _colorManager;
        private bool defaultColorLoaded;

        private const string ColorSubCategory = "Colors";

        [Category(ColorSubCategory)]
        [DisplayName("Class")]
        public Color Class
        {
            get { return _colorManager.GetBuiltIn(ColorCoderClassificationName.Class); }
            set { _colorManager.SetBuiltIn(ColorCoderClassificationName.Class, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Delegate")]
        public Color Delegate
        {
            get { return _colorManager.GetBuiltIn(ColorCoderClassificationName.Delegate); }
            set { _colorManager.SetBuiltIn(ColorCoderClassificationName.Delegate, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Interface")]
        public Color Interface
        {
            get { return _colorManager.GetBuiltIn(ColorCoderClassificationName.Interface); }
            set { _colorManager.SetBuiltIn(ColorCoderClassificationName.Interface, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Struct")]
        public Color Struct
        {
            get { return _colorManager.GetBuiltIn(ColorCoderClassificationName.Struct); }
            set { _colorManager.SetBuiltIn(ColorCoderClassificationName.Struct, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Enum")]
        public Color Enum
        {
            get { return _colorManager.GetBuiltIn(ColorCoderClassificationName.Enum); }
            set { _colorManager.SetBuiltIn(ColorCoderClassificationName.Enum, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Generic Type Parameter")]
        public Color GenericTypeParameter
        {
            get { return _colorManager.GetBuiltIn(ColorCoderClassificationName.GenericTypeParameter); }
            set { _colorManager.SetBuiltIn(ColorCoderClassificationName.GenericTypeParameter, value); }
        }

        //[Category(ColorSubCategory)]
        //[DisplayName("Attribute")]
        //public Color Attribute
        //{
        //    get { return _colorManager.Get(ColorCoderClassificationName.Attribute); }
        //    set { _colorManager.Set(ColorCoderClassificationName.Attribute, value); }
        //}

        [Category(ColorSubCategory)]
        [DisplayName("Local Variable")]
        public Color Local
        {
            get { return _colorManager.Get(ColorCoderClassificationName.LocalVariable); }
            set { _colorManager.Set(ColorCoderClassificationName.LocalVariable, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Enum Member")]
        public Color EnumMember
        {
            get { return _colorManager.Get(ColorCoderClassificationName.EnumMember); }
            set { _colorManager.Set(ColorCoderClassificationName.EnumMember, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Constructor")]
        public Color Constructor
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Constructor); }
            set { _colorManager.Set(ColorCoderClassificationName.Constructor, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Field")]
        public Color Field
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Field); }
            set { _colorManager.Set(ColorCoderClassificationName.Field, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Namespace")]
        public Color Namespace
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Namespace); }
            set { _colorManager.Set(ColorCoderClassificationName.Namespace, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Method")]
        public Color Method
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Method); }
            set { _colorManager.Set(ColorCoderClassificationName.Method, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Static Method")]
        public Color StaticMethod
        {
            get { return _colorManager.Get(ColorCoderClassificationName.StaticMethod); }
            set { _colorManager.Set(ColorCoderClassificationName.StaticMethod, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Extension Method")]
        public Color ExtensionMethod
        {
            get { return _colorManager.Get(ColorCoderClassificationName.ExtensionMethod); }
            set { _colorManager.Set(ColorCoderClassificationName.ExtensionMethod, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Property")]
        public Color AutomaticProperty
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Property); }
            set { _colorManager.Set(ColorCoderClassificationName.Property, value); }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Parameter")]
        public Color Parameter
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Parameter); }
            set { _colorManager.Set(ColorCoderClassificationName.Parameter, value); }
        }

        public override void LoadSettingsFromStorage()
        {
            var dte = (EnvDTE80.DTE2)ColorCoderOptionPackage.GetGlobalService(typeof(SDTE));

            this._colorManager = new ColorManager(new ColorStorage(this.Site), dte);

            if (!defaultColorLoaded)
            {
                defaultColorLoaded = true;
                _colorManager.SetDefaultBuiltInColors();
            }

            _colorManager.Load(
                //ColorCoderClassificationName.Attribute,
                ColorCoderClassificationName.Constructor,
                ColorCoderClassificationName.EnumMember,
                ColorCoderClassificationName.ExtensionMethod,
                ColorCoderClassificationName.Field,
                ColorCoderClassificationName.LocalVariable,
                ColorCoderClassificationName.Method,
                ColorCoderClassificationName.Namespace,
                ColorCoderClassificationName.Property,
                ColorCoderClassificationName.StaticMethod,
                ColorCoderClassificationName.Parameter
            );
        }

        public override void SaveSettingsToStorage()
        {
            //_colorManager.Save();
        }
    }

    [Guid(Guids.ColorCoderOptionPackage)]
    [DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\14.0")]
    [PackageRegistration(UseManagedResourcesOnly = true)]
    [ProvideOptionPage(typeof(ChangeColorOptionGrid), "ColorCoder", "General", 1000, 1001, true)]
    [InstalledProductRegistration("ColorCoder", "Color Coder provides semantic coloring for C# and VB - http://hamidmosalla.com/colorcoder", "1.0")]

    public sealed class ColorCoderOptionPackage : Package
    {
        public ColorCoderOptionPackage() { }

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}