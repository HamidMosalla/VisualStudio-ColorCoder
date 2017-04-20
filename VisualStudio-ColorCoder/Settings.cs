using System.Drawing;
using System.Runtime.Serialization;
using System;
using System.IO;
using System.Runtime.Serialization.Json;

namespace VisualStudio_ColorCoder
{
    public class Settings
    {
        [DataMember(Order = 0)]
        public Preset Preset { get; set; } = Preset.NoPreset;

        [DataMember(Order = 1)]
        public Color Interface { get; set; } = Color.Orange;

        [DataMember(Order = 2)]
        public Color Class { get; set; } = Color.Orange;

        [DataMember(Order = 3)]
        public Color AbstractClass { get; set; } = Color.Orange;

        [DataMember(Order = 4)]
        public Color StaticClass { get; set; } = Color.Orange;

        [DataMember(Order = 5)]
        public Color Struct { get; set; } = Color.Orange;

        [DataMember(Order = 6)]
        public Color Enum { get; set; } = Color.Orange;

        [DataMember(Order = 7)]
        public Color EnumConstant { get; set; } = Color.Orange;

        [DataMember(Order = 8)]
        public Color Constructor { get; set; } = Color.Orange;

        [DataMember(Order = 9)]
        public Color Attribute { get; set; } = Color.Orange;

        [DataMember(Order = 10)]
        public Color Field { get; set; } = Color.Orange;

        [DataMember(Order = 11)]
        public Color Namespace { get; set; } = Color.Orange;

        [DataMember(Order = 12)]
        public Color Method { get; set; } = Color.Orange;

        [DataMember(Order = 13)]
        public Color StaticMethod { get; set; } = Color.Orange;

        [DataMember(Order = 14)]
        public Color ExtensionMethod { get; set; } = Color.Orange;

        [DataMember(Order = 15)]
        public Color AutomaticProperty { get; set; } = Color.Orange;

        [DataMember(Order = 16)]
        public Color Parameter { get; set; } = Color.Orange;


        private static readonly string ProgramDataFolder;
        private static readonly string SettingsFile;

        public static event EventHandler SettingsUpdated;

        private static void OnSettingsUpdated(object sender, EventArgs ea) => SettingsUpdated?.Invoke(sender, ea);

        static Settings()
        {
            ProgramDataFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "VisualStudioColorCoder");
            SettingsFile = Path.Combine(ProgramDataFolder, "visualstudiocolorcoder.json");
        }

        public static Settings Load()
        {
            //if (Runtime.RunningUnitTests) return new Settings();
            Directory.CreateDirectory(ProgramDataFolder);
            if (!File.Exists(SettingsFile)) new Settings().Save();
            using (var stream = new FileStream(SettingsFile, FileMode.Open))
            {
                var deserialize = new DataContractJsonSerializer(typeof(Settings));
                var settings = (Settings)deserialize.ReadObject(stream);
                //TODO: might need to add missing colors here, but I don't think so, it's added on object creation
                return settings;
            }
        }

        public void Save()
        {
            //if (Runtime.RunningUnitTests) return;
            Directory.CreateDirectory(ProgramDataFolder);
            using (var stream = new FileStream(SettingsFile, FileMode.Create))
            {
                var serializer = new DataContractJsonSerializer(typeof(Settings));
                serializer.WriteObject(stream, this);
            }
            OnSettingsUpdated(this, EventArgs.Empty);
        }
    }
}