using ColorCoder.Classifications;
using ColorCoder.ColorCoderCore;
using ColorCoder.Types;
using Microsoft.VisualStudio.Shell;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Threading;
using Task = System.Threading.Tasks.Task;

namespace ColorCoder
{
    [Guid(Guids.ChangeColorOptionGrid)]
    public class ChangeColorOptionGrid : DialogPage
    {
        private ColorManager _colorManager;

        private const string ColorSubCategory = "Colors";

        [Category(ColorSubCategory)]
        [DisplayName("Class")]
        public Color Class
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Class); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Class, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Delegate")]
        public Color Delegate
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Delegate); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Delegate, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Interface")]
        public Color Interface
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Interface); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Interface, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Struct")]
        public Color Struct
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Struct); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Struct, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Enum")]
        public Color Enum
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Enum); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Enum, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Generic Type Parameter")]
        public Color GenericTypeParameter
        {
            get { return _colorManager.Get(ColorCoderClassificationName.GenericTypeParameter); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.GenericTypeParameter, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Module(VB Only)")]
        public Color Module
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Module); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Module, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Attribute")]
        public Color Attribute
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Attribute); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Attribute, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Local Variable")]
        public Color Local
        {
            get { return _colorManager.Get(ColorCoderClassificationName.LocalVariable); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.LocalVariable, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Enum Member")]
        public Color EnumMember
        {
            get { return _colorManager.Get(ColorCoderClassificationName.EnumMember); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.EnumMember, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Constructor (C# Only)")]
        public Color Constructor
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Constructor); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Constructor, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Field")]
        public Color Field
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Field); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Field, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Namespace")]
        public Color Namespace
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Namespace); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Namespace, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Method")]
        public Color Method
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Method); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Method, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Static Method")]
        public Color StaticMethod
        {
            get { return _colorManager.Get(ColorCoderClassificationName.StaticMethod); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.StaticMethod, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Extension Method")]
        public Color ExtensionMethod
        {
            get { return _colorManager.Get(ColorCoderClassificationName.ExtensionMethod); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.ExtensionMethod, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Property")]
        public Color AutomaticProperty
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Property); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Property, value);
            }
        }

        [Category(ColorSubCategory)]
        [DisplayName("Parameter")]
        public Color Parameter
        {
            get { return _colorManager.Get(ColorCoderClassificationName.Parameter); }
            set
            {
                ThreadHelper.ThrowIfNotOnUIThread();
                _colorManager.Set(ColorCoderClassificationName.Parameter, value);
            }
        }

        public override void LoadSettingsFromStorage()
        {
            ThreadHelper.ThrowIfNotOnUIThread();

            this._colorManager = new ColorManager(new ColorStorage(this.Site));

            _colorManager.Load(
                ColorCoderClassificationName.Attribute,
                ColorCoderClassificationName.Constructor,
                ColorCoderClassificationName.EnumMember,
                ColorCoderClassificationName.ExtensionMethod,
                ColorCoderClassificationName.Field,
                ColorCoderClassificationName.LocalVariable,
                ColorCoderClassificationName.Method,
                ColorCoderClassificationName.Namespace,
                ColorCoderClassificationName.Property,
                ColorCoderClassificationName.StaticMethod,
                ColorCoderClassificationName.Parameter,
                ColorCoderClassificationName.Class,
                ColorCoderClassificationName.Interface,
                ColorCoderClassificationName.Module,
                ColorCoderClassificationName.Struct,
                ColorCoderClassificationName.Enum,
                ColorCoderClassificationName.Delegate,
                ColorCoderClassificationName.GenericTypeParameter
            );
        }

        public override void SaveSettingsToStorage() { }
    }

    [Guid(Guids.PresetOptionGrid)]
    public class PresetOptionGrid : DialogPage
    {
        private ColorManager _colorManager;

        private const string PresetSubCategory = "Presets";

        [Category(PresetSubCategory)]
        [DisplayName("Preset")]
        [Description("Select from one of the available sets of Presets")]
        public Preset Preset { get; set; }

        public override void LoadSettingsFromStorage()
        {
            this._colorManager = new ColorManager(new ColorStorage(this.Site));

            Preset = Settings.Load().Preset;
        }

        public override void SaveSettingsToStorage()
        {
            Settings.Save(new PresetData { Preset = Preset });

            if (Preset == Preset.NoPreset) return;

            ThreadHelper.ThrowIfNotOnUIThread();

            if (Preset == Preset.VisualStudioDefault)
            {
                var defaultColors = _colorManager.GetDefaultColorsBySelectedThemes();

                _colorManager.Save(defaultColors);
            }

            if (Preset == Preset.ColorCoderBlueThemeDefault)
            {
                var colors = _colorManager.GetBlueThemeColorCoderDefaultColors();
                _colorManager.Save(colors);
            }

            if (Preset == Preset.ColorCoderDarkThemeDefault)
            {
                var colors = _colorManager.GetDarkThemeColorCoderDefaultColors();
                _colorManager.Save(colors);
            }
        }
    }

    /// <summary>
    /// This is the class that implements the package exposed by this assembly.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The minimum requirement for a class to be considered a valid package for Visual Studio
    /// is to implement the IVsPackage interface and register itself with the shell.
    /// This package uses the helper classes defined inside the Managed Package Framework (MPF)
    /// to do it: it derives from the Package class that provides the implementation of the
    /// IVsPackage interface and uses the registration attributes defined in the framework to
    /// register itself and its components with the shell. These attributes tell the pkgdef creation
    /// utility what data to put into .pkgdef file.
    /// </para>
    /// <para>
    /// To get loaded into VS, the package must be referred by &lt;Asset Type="Microsoft.VisualStudio.VsPackage" ...&gt; in .vsixmanifest file.
    /// </para>
    /// </remarks>
    [Guid(Guids.ColorCoderOptionPackage)]
    [DefaultRegistryRoot("Software\\Microsoft\\VisualStudio\\14.0")]
    [PackageRegistration(UseManagedResourcesOnly = true, AllowsBackgroundLoading = true)]
    [ProvideOptionPage(typeof(ChangeColorOptionGrid), "ColorCoder", "Colors", 1000, 1001, true)]
    [ProvideOptionPage(typeof(PresetOptionGrid), "ColorCoder", "Presets", 1000, 1001, true)]
    [InstalledProductRegistration("ColorCoder", "Color Coder provides semantic coloring for C# and VB - http://hamidmosalla.com/color-coder/", Vsix.Version, IconResourceID = 400)]
    public sealed class ColorCoderPackage : AsyncPackage
    {
        /// <summary>
        /// ColorCoderPackage GUID string.
        /// </summary>
        public const string PackageGuidString = "b9c81946-7fc5-4544-8f62-881252590edb";

        #region Package Members

        /// <summary>
        /// Initialization of the package; this method is called right after the package is sited, so this is the place
        /// where you can put all the initialization code that rely on services provided by VisualStudio.
        /// </summary>
        /// <param name="cancellationToken">A cancellation token to monitor for initialization cancellation, which can occur when VS is shutting down.</param>
        /// <param name="progress">A provider for progress updates.</param>
        /// <returns>A task representing the async work of package initialization, or an already completed task if there is none. Do not return null from this method.</returns>
        protected override async Task InitializeAsync(CancellationToken cancellationToken, IProgress<ServiceProgressData> progress)
        {
            // When initialized asynchronously, the current thread may be a background thread at this point.
            // Do any initialization that requires the UI thread after switching to the UI thread.
            await this.JoinableTaskFactory.SwitchToMainThreadAsync(cancellationToken);
        }

        #endregion
    }
}
