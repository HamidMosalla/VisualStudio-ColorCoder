using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using VisualStudio_ColorCoder.Classifications;
using VisualStudio_ColorCoder.Settings;

namespace VisualStudio_ColorCoder.ColorCoderCore
{
    public static class ColorMap
    {
        public static Dictionary<string, Color> GetMap()
        {
            var settings =  State.Settings.Load();
            return new Dictionary<string, Color>
            {
                {ColorCoderClassificationName.Interface, settings.Interface},
                {ColorCoderClassificationName.Class, settings.Class},
                {ColorCoderClassificationName.AbstractClass, settings.AbstractClass},
                {ColorCoderClassificationName.StaticClass, settings.StaticClass},
                {ColorCoderClassificationName.Struct, settings.Struct},
                {ColorCoderClassificationName.Enum, settings.Enum},
                {ColorCoderClassificationName.EnumConstant, settings.EnumConstant},
                {ColorCoderClassificationName.Constructor, settings.Constructor},
                {ColorCoderClassificationName.Attribute, settings.Attribute},
                {ColorCoderClassificationName.Field, settings.Field},
                {ColorCoderClassificationName.Local, settings.Local},
                {ColorCoderClassificationName.Namespace, settings.Namespace},
                {ColorCoderClassificationName.Method, settings.Method},
                {ColorCoderClassificationName.StaticMethod, settings.StaticMethod},
                {ColorCoderClassificationName.ExtensionMethod, settings.ExtensionMethod},
                {ColorCoderClassificationName.Property, settings.AutomaticProperty},
                {ColorCoderClassificationName.TypeParameter, settings.TypeParameter},
                {ColorCoderClassificationName.Regions, settings.Regions}
            };

            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
            
        }
    }
}
