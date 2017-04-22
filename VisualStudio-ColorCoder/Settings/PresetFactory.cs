using System.Drawing;

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
                    Field = Color.Orange,
                    AbstractClass = Color.Red,
                    Attribute = Color.PeachPuff,
                    AutomaticProperty = Color.PaleGoldenrod,
                    Class = Color.BurlyWood,
                    Constructor = Color.Orange,
                    Enum = Color.Orchid,
                    EnumConstant = Color.OldLace,
                    ExtensionMethod = Color.Magenta,
                    Interface = Color.LightBlue,
                    Method = Color.Purple,
                    Namespace = Color.Black,
                    Parameter = Color.Azure,
                    Preset = Preset.Minimalist,
                    StaticClass = Color.LightGoldenrodYellow,
                    StaticMethod = Color.Pink,
                    Struct = Color.Plum
                };
            }

            return new PresetColors();
        }
    }
}