using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace VisualStudio_ColorCoder
{
    public class SettingIo
    {
        private readonly string _programDataFolder;
        private readonly string _settingsFile;

        public event EventHandler SettingsUpdated;
        private SettingFactory _settingFactory;

        private void OnSettingsUpdated(object sender, EventArgs ea) => SettingsUpdated?.Invoke(sender, ea);

        public SettingIo()
        {
            this._settingFactory = new SettingFactory();
            _programDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VisualStudioColorCoder");
            _settingsFile = Path.Combine(_programDataFolder, "visualstudiocolorcoder.json");
        }

        public Settings Load()
        {
            Directory.CreateDirectory(_programDataFolder);

            if (!File.Exists(_settingsFile)) Save(_settingFactory.Create(Preset.Minimalist));

            using (var stream = new FileStream(_settingsFile, FileMode.Open))
            {
                var deserialize = new DataContractJsonSerializer(typeof(Settings));
                var settings = (Settings)deserialize.ReadObject(stream);
                return settings;
            }
        }

        public void Save(Settings settings)
        {
            Directory.CreateDirectory(_programDataFolder);

            using (var stream = new FileStream(_settingsFile, FileMode.Create))
            {
                var serializer = new DataContractJsonSerializer(typeof(Settings));
                serializer.WriteObject(stream, settings);
            }

            OnSettingsUpdated(settings, EventArgs.Empty);
        }
    }
}