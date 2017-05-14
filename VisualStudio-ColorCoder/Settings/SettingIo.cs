using System;
using System.IO;
using System.Runtime.Serialization.Json;
using VisualStudio_ColorCoder.ColorCoderCore;

namespace VisualStudio_ColorCoder.Settings
{
    public class SettingIo
    {
        private readonly string _programDataFolder;
        private readonly string _settingsFile;

        public event EventHandler SettingsUpdated;
        private readonly PresetFactory _presetFactory;

        private void OnSettingsUpdated(object sender, EventArgs ea) => SettingsUpdated?.Invoke(sender, ea);

        public SettingIo()
        {
            this._presetFactory = new PresetFactory();
            _programDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VisualStudioColorCoder");
            _settingsFile = Path.Combine(_programDataFolder, "visualstudiocolorcoder.json");
        }

        public PresetColors Load()
        {
            Directory.CreateDirectory(_programDataFolder);

            if (!File.Exists(_settingsFile)) Save(_presetFactory.CreateInstance(Preset.Minimalist));

            using (var stream = new FileStream(_settingsFile, FileMode.Open))
            {
                var deserialize = new DataContractJsonSerializer(typeof(PresetColors));
                var settings = (PresetColors)deserialize.ReadObject(stream);
                return settings;
            }
        }

        public void Save(PresetColors presetColors)
        {
            Directory.CreateDirectory(_programDataFolder);

            using (var stream = new FileStream(_settingsFile, FileMode.Create))
            {
                var serializer = new DataContractJsonSerializer(typeof(PresetColors));
                serializer.WriteObject(stream, presetColors);
            }

            OnSettingsUpdated(presetColors, EventArgs.Empty);
        }
    }
}