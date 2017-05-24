using System.Windows.Media;
using VisualStudio_ColorCoder.State;

namespace VisualStudio_ColorCoder.Settings
{
    public class PresetFactory
    {
        public PresetColors CreateInstance(Preset preset)
        {
            if (preset == Preset.SuperChargerStyle)
            {
                return new PresetColors
                {
                    Field = Colors.Black,
                    AbstractClass = Colors.Beige,
                    Attribute = Colors.DimGray,
                    AutomaticProperty = Colors.Chartreuse,
                    Constructor = Colors.DarkOrange,
                    Enum = Colors.Teal,
                    EnumConstant = Colors.Olive,
                    ExtensionMethod = Colors.Magenta,
                    Interface = Colors.Beige,
                    Method = Colors.Purple,
                    Namespace = Colors.Black,
                    TypeParameter = Colors.Gray,
                    Preset = Preset.SuperChargerStyle,
                    StaticClass = Colors.Orchid,
                    StaticMethod = Colors.MediumSeaGreen,
                    Struct = Colors.PaleVioletRed
                };
            }

            if (preset == Preset.Minimalist)
            {
                return new PresetColors
                {
                    Field = Colors.Black,
                    AbstractClass = Colors.Beige,
                    Attribute = Colors.DimGray,
                    AutomaticProperty = Colors.Chartreuse,
                    Constructor = Colors.DarkOrange,
                    Enum = Colors.Teal,
                    EnumConstant = Colors.Olive,
                    ExtensionMethod = Colors.Magenta,
                    Interface = Colors.Beige,
                    Method = Colors.Purple,
                    Namespace = Colors.Black,
                    TypeParameter = Colors.Gray,
                    Preset = Preset.Minimalist,
                    StaticClass = Colors.Orchid,
                    StaticMethod = Colors.MediumSeaGreen,
                    Struct = Colors.PaleVioletRed
                };
            }

            if (preset == Preset.ScottHanselmansDream)
            {
                return new PresetColors
                {
                    Field = Colors.Black,
                    AbstractClass = Colors.Beige,
                    Attribute = Colors.DimGray,
                    AutomaticProperty = Colors.Chartreuse,
                    Constructor = Colors.DarkOrange,
                    Enum = Colors.Teal,
                    EnumConstant = Colors.Olive,
                    ExtensionMethod = Colors.Magenta,
                    Interface = Colors.Beige,
                    Method = Colors.Purple,
                    Namespace = Colors.Black,
                    TypeParameter = Colors.Gray,
                    Preset = Preset.ScottHanselmansDream,
                    StaticClass = Colors.Orchid,
                    StaticMethod = Colors.MediumSeaGreen,
                    Struct = Colors.PaleVioletRed
                };
            }

            if (preset == Preset.MoreGirlsInTechPlease)
            {
                return new PresetColors
                {
                    Field = Colors.Pink,
                    AbstractClass = Colors.Pink,
                    Attribute = Colors.Pink,
                    AutomaticProperty = Colors.Pink,
                    Constructor = Colors.Pink,
                    Enum = Colors.Pink,
                    EnumConstant = Colors.Pink,
                    ExtensionMethod = Colors.Pink,
                    Interface = Colors.Pink,
                    Method = Colors.Pink,
                    Namespace = Colors.Pink,
                    TypeParameter = Colors.Pink,
                    Preset = Preset.MoreGirlsInTechPlease,
                    StaticClass = Colors.Pink,
                    StaticMethod = Colors.Pink,
                    Struct = Colors.Pink,
                };
            }

            return new PresetColors();
        }
    }
}