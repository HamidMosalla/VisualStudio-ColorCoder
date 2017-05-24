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
using VisualStudio_ColorCoder.ColorCoderCore;
using VisualStudio_ColorCoder.Settings;
using VisualStudio_ColorCoder.State;


namespace VisualStudio_ColorCoder
{
    public class PresetOptionGrid : DialogPage
    {
        private readonly PresetFactory _presetFactory;

        public PresetOptionGrid()
        {
            this._presetFactory = new PresetFactory();

        }

        private const string PresetSubCategory = "Presets";

        [Category(PresetSubCategory)]
        [DisplayName("Preset")]
        [Description("Select from one of the available sets of Presets")]
        public Preset Preset { get; set; }

        public override void LoadSettingsFromStorage()
        {
            //C:\Users\Hamid\AppData\Roaming\VisualStudioColorCoder
            var settings = State.Settings.Load();
            Preset = settings.Preset;
        }

        public override void SaveSettingsToStorage()
        {
            if (Preset == Preset.NoPreset) return;

            var settings = _presetFactory.CreateInstance(Preset);

            State.Settings.Save(settings);
        }
    }

    public class ChangeColorOptionGrid : DialogPage
    {
        private PresetFactory _presetFactory;

        public ChangeColorOptionGrid()
        {
            this._presetFactory = new PresetFactory();
        }

        private const string ColorSubCategory = "Colors";

        //public Preset Preset { get; set; }

        [Category(ColorSubCategory)]
        [DisplayName("Interface")]
        public Color Interface { get; set; }

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
        [DisplayName("Local")]
        public Color Local { get; set; }

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
        [DisplayName("TypeParameter")]
        public Color Parameter { get; set; }


        public override void LoadSettingsFromStorage()
        {
            var settings = State.Settings.Load();

            //Preset = settings.Preset;
            Interface = settings.Interface.ToDrawingColor();
            AbstractClass = settings.AbstractClass.ToDrawingColor();
            StaticClass = settings.StaticClass.ToDrawingColor();
            Struct = settings.Struct.ToDrawingColor();
            Enum = settings.Enum.ToDrawingColor();
            EnumConstant = settings.EnumConstant.ToDrawingColor();
            Constructor = settings.Constructor.ToDrawingColor();
            Attribute = settings.Attribute.ToDrawingColor();
            Field = settings.Field.ToDrawingColor();
            Namespace = settings.Namespace.ToDrawingColor();
            Method = settings.Method.ToDrawingColor();
            StaticMethod = settings.StaticMethod.ToDrawingColor();
            ExtensionMethod = settings.ExtensionMethod.ToDrawingColor();
            AutomaticProperty = settings.AutomaticProperty.ToDrawingColor();
            Parameter = settings.TypeParameter.ToDrawingColor();
            Local = settings.Local.ToDrawingColor();
        }

        public override void SaveSettingsToStorage()
        {
            var settings = new PresetColors
            {
                //TODO: do something here to keep the preset colors and change only the filled colors
                //for this you can create to separate setting file on disk and load them separately, first apply the preset and then apply the custom colors
                //Preset = Preset,
                Interface = Interface.ToMediaColor(),
                AbstractClass = AbstractClass.ToMediaColor(),
                StaticClass = StaticClass.ToMediaColor(),
                Struct = Struct.ToMediaColor(),
                Enum = Enum.ToMediaColor(),
                EnumConstant = EnumConstant.ToMediaColor(),
                Constructor = Constructor.ToMediaColor(),
                Attribute = Attribute.ToMediaColor(),
                Field = Field.ToMediaColor(),
                Namespace = Namespace.ToMediaColor(),
                Method = Method.ToMediaColor(),
                StaticMethod = StaticMethod.ToMediaColor(),
                ExtensionMethod = ExtensionMethod.ToMediaColor(),
                AutomaticProperty = AutomaticProperty.ToMediaColor(),
                TypeParameter = Parameter.ToMediaColor(),
                Local = Local.ToMediaColor()
            };
            State.Settings.Save(settings);
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

        protected override void Initialize()
        {
            base.Initialize();
        }
    }
}