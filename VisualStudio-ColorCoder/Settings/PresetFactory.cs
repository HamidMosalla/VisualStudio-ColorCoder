using System.Windows.Media;

namespace VisualStudio_ColorCoder.Settings
{
    public class PresetFactory
    {
        public PresetColors CreateInstance(Preset preset)
        {
            if (preset == Preset.Minimalist)
            {
                return new PresetColors
                {
                    Field = Colors.Orange,
                    AbstractClass = Colors.Red,
                    Attribute = Colors.PeachPuff,
                    AutomaticProperty = Colors.PaleGoldenrod,
                    Class = Colors.BurlyWood,
                    Constructor = Colors.Orange,
                    Enum = Colors.Orchid,
                    EnumConstant = Colors.OldLace,
                    ExtensionMethod = Colors.Magenta,
                    Interface = Colors.LightBlue,
                    Method = Colors.Purple,
                    Namespace = Colors.Black,
                    TypeParameter = Colors.Azure,
                    Preset = Preset.Minimalist,
                    StaticClass = Colors.LightGoldenrodYellow,
                    StaticMethod = Colors.Pink,
                    Struct = Colors.Plum,
                    Regions = Colors.DeepPink
                };
            }

            return new PresetColors();
        }
    }
}