using System;
using System.IO;
using System.Runtime.Serialization.Json;
using VisualStudio_ColorCoder.Settings;

namespace VisualStudio_ColorCoder.State
{
    public class Settings
    {
        private static readonly string _programDataFolder;
        private static readonly string _settingsFile;

        public static event EventHandler SettingsUpdated;
        private static readonly  PresetFactory _presetFactory;

        public static void OnSettingsUpdated(object sender, EventArgs ea) => SettingsUpdated?.Invoke(sender, ea);

        static Settings()
        {
            _presetFactory = new PresetFactory();
            _programDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VisualStudioColorCoder");
            _settingsFile = Path.Combine(_programDataFolder, "visualstudiocolorcoder.json");
        }

        public static PresetColors Load()
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

        public static void Save(PresetColors presetColors)
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