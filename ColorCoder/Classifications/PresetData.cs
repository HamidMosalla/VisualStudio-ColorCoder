using System.Runtime.Serialization;

namespace ColorCoder.Classifications
{
    public class PresetData
    {
        [DataMember(Order = 0)]
        public Preset Preset { get; set; } = Preset.NoPreset;
    }
}