using System.Drawing;

namespace VisualStudio_ColorCoder
{
    public class SettingFactory
    {
        public Settings Create(Preset preset)
        {
            if (preset == Preset.Minimalist)
            {
                return new Settings
                {
                    Field = Color.Orange
                };
            }
            return new Settings();
        }
    }
}