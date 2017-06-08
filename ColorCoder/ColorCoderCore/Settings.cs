using System;
using System.IO;
using System.Runtime.Serialization.Json;
using ColorCoder.Classifications;

namespace ColorCoder.ColorCoderCore
{
    public class Settings
    {
        private static readonly string _programDataFolder;
        private static readonly string _settingsFile;

        public static event EventHandler SettingsUpdated;

        public static void OnSettingsUpdated(object sender, EventArgs ea) => SettingsUpdated?.Invoke(sender, ea);

        static Settings()
        {
            _programDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VisualStudioColorCoder");
            _settingsFile = Path.Combine(_programDataFolder, "visualstudiocolorcoder.json");
        }

        public static PresetData Load()
        {
            Directory.CreateDirectory(_programDataFolder);

            if (!File.Exists(_settingsFile)) Save(new PresetData());

            using (var stream = new FileStream(_settingsFile, FileMode.Open))
            {
                var deserialize = new DataContractJsonSerializer(typeof(PresetData));
                var settings = (PresetData)deserialize.ReadObject(stream);
                return settings;
            }
        }

        public static void Save(PresetData preset)
        {
            Directory.CreateDirectory(_programDataFolder);

            using (var stream = new FileStream(_settingsFile, FileMode.Create))
            {
                var serializer = new DataContractJsonSerializer(typeof(PresetData));
                serializer.WriteObject(stream, preset);
            }

            OnSettingsUpdated(preset, EventArgs.Empty);
        }
    }
}