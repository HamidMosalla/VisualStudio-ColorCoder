namespace VisualStudio_ColorCoder
{
    public class SettingFactory
    {
        public static Settings Create(Preset preset)
        {
            //TODO: it's just a thought now, finish the factory
            return new Settings
            {
                Preset = preset
            };
        }
    }
}