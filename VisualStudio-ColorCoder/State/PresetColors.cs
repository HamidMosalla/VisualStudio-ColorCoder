using System.Runtime.Serialization;
using System.Windows.Media;
using VisualStudio_ColorCoder.Settings;

namespace VisualStudio_ColorCoder.State
{
    public class PresetColors
    {
        [DataMember(Order = 0)]
        public Preset Preset { get; set; } = Preset.NoPreset;

        [DataMember(Order = 1)]
        public Color Interface { get; set; }

        [DataMember(Order = 3)]
        public Color AbstractClass { get; set; }

        [DataMember(Order = 4)]
        public Color StaticClass { get; set; }

        [DataMember(Order = 5)]
        public Color Struct { get; set; }

        [DataMember(Order = 6)]
        public Color Enum { get; set; }

        [DataMember(Order = 7)]
        public Color EnumConstant { get; set; }

        [DataMember(Order = 8)]
        public Color Constructor { get; set; }

        [DataMember(Order = 9)]
        public Color Attribute { get; set; }

        [DataMember(Order = 10)]
        public Color Field { get; set; }

        [DataMember(Order = 11)]
        public Color Namespace { get; set; }

        [DataMember(Order = 12)]
        public Color Method { get; set; }

        [DataMember(Order = 13)]
        public Color StaticMethod { get; set; }

        [DataMember(Order = 14)]
        public Color ExtensionMethod { get; set; }

        [DataMember(Order = 15)]
        public Color AutomaticProperty { get; set; }

        [DataMember(Order = 16)]
        public Color TypeParameter { get; set; }

        [DataMember(Order = 18)]
        public Color Local { get; set; }
    }
}