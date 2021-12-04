using System;
using System.Collections.Generic;
using System.Drawing;
using ColorCoder.Classifications;
using ColorCoder.Extensions;
using ColorCoder.Types;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.PlatformUI;
using Microsoft.VisualStudio.Shell.Interop;
using Color = System.Drawing.Color;

namespace ColorCoder.ColorCoderCore
{
    public class ColorManager
    {
        private readonly ColorStorage _colorStorage;
        private readonly IDictionary<String, ColorableItemInfo[]> _classifications;
        private const string BLUETHEMECOLOR = "fff7f9fe";
        private const string DARKTHEMECOLOR = "ff252526";

        public ColorManager(ColorStorage colorStorage)
        {
            _colorStorage = colorStorage;
            _classifications = new Dictionary<String, ColorableItemInfo[]>();
        }

        public void Load(params String[] classificationNames)
        {
            _classifications.Clear();

            Guid category = new Guid(Guids.TextEditorCategory);

            uint flags = (uint)(__FCSTORAGEFLAGS.FCSF_LOADDEFAULTS
                                 | __FCSTORAGEFLAGS.FCSF_NOAUTOCOLORS
                                 | __FCSTORAGEFLAGS.FCSF_READONLY);

            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            var hr = _colorStorage.Storage.OpenCategory(ref category, flags);
            ErrorHandler.ThrowOnFailure(hr);

            try
            {
                foreach (var classification in classificationNames)
                {
                    ColorableItemInfo[] colors = new ColorableItemInfo[1];

                    hr = _colorStorage.Storage.GetItem(classification, colors);
                    ErrorHandler.ThrowOnFailure(hr);

                    _classifications.Add(classification, colors);
                }
            }
            finally
            {
                _colorStorage.Storage.CloseCategory();
            }
        }

        public void Save(IDictionary<String, ColorableItemInfo[]> classifications)
        {
            Guid category = new Guid(Guids.TextEditorCategory);

            uint flags = (uint)(__FCSTORAGEFLAGS.FCSF_LOADDEFAULTS
                              | __FCSTORAGEFLAGS.FCSF_PROPAGATECHANGES);

            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            var hr = _colorStorage.Storage.OpenCategory(ref category, flags);
            ErrorHandler.ThrowOnFailure(hr);

            try
            {
                foreach (var classification in classifications)
                {
                    hr = _colorStorage.Storage.SetItem(classification.Key, classification.Value);
                    ErrorHandler.ThrowOnFailure(hr);
                }
            }
            finally
            {
                _colorStorage.Storage.CloseCategory();
            }
        }

        public Color Get(String classificationName)
        {
            if (_classifications.TryGetValue(classificationName, out var entry))
            {
                return ColorTranslator.FromWin32((int)entry[0].crForeground);
            }
            return default(Color);
        }

        public void Set(String classificationName, Color color)
        {
            Guid category = new Guid(Guids.TextEditorCategory);

            uint flags = (uint)(__FCSTORAGEFLAGS.FCSF_LOADDEFAULTS
                              | __FCSTORAGEFLAGS.FCSF_PROPAGATECHANGES);

            Microsoft.VisualStudio.Shell.ThreadHelper.ThrowIfNotOnUIThread();
            var hr = _colorStorage.Storage.OpenCategory(ref category, flags);
            ErrorHandler.ThrowOnFailure(hr);

            ColorableItemInfo[] colors = new ColorableItemInfo[1];
            colors[0].crForeground = (uint)ColorTranslator.ToWin32(color);
            colors[0].bForegroundValid = 1;

            _classifications[classificationName] = colors;

            try
            {
                hr = _colorStorage.Storage.SetItem(classificationName, colors);
                ErrorHandler.ThrowOnFailure(hr);
            }
            finally
            {
                _colorStorage.Storage.CloseCategory();
            }
        }

        public IDictionary<String, ColorableItemInfo[]> GetBlueThemeColorCoderDefaultColors()
        {
            var classifications = new Dictionary<String, ColorableItemInfo[]>
            {
                {ColorCoderClassificationName.Constructor, Color.OrangeRed.ToColorableItemInfo()},
                {ColorCoderClassificationName.EnumMember, Color.Olive.ToColorableItemInfo()},
                {ColorCoderClassificationName.ExtensionMethod, Color.Magenta.ToColorableItemInfo()},
                {ColorCoderClassificationName.Field, Color.DarkOrange.ToColorableItemInfo()},
                {ColorCoderClassificationName.LocalVariable, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Method, Color.Purple.ToColorableItemInfo()},
                {ColorCoderClassificationName.Namespace, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Property, Color.Chocolate.ToColorableItemInfo()},
                {ColorCoderClassificationName.StaticMethod, Color.LimeGreen.ToColorableItemInfo()},
                {ColorCoderClassificationName.Parameter, Color.Gray.ToColorableItemInfo()},
                {ColorCoderClassificationName.Class, Color.FromArgb(43, 145, 175).ToColorableItemInfo()},
                {ColorCoderClassificationName.Attribute,Color.Gray.ToColorableItemInfo()},
                {ColorCoderClassificationName.Interface, Color.DarkSlateBlue.ToColorableItemInfo()},
                {ColorCoderClassificationName.Module, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Struct, Color.Orchid.ToColorableItemInfo()},
                {ColorCoderClassificationName.Enum, Color.SeaGreen.ToColorableItemInfo()},
                {ColorCoderClassificationName.Delegate, Color.DarkKhaki.ToColorableItemInfo()},
                {ColorCoderClassificationName.GenericTypeParameter, Color.DeepSkyBlue.ToColorableItemInfo()}
            };

            return classifications;
        }

        public IDictionary<String, ColorableItemInfo[]> GetDarkThemeColorCoderDefaultColors()
        {
            var classifications = new Dictionary<String, ColorableItemInfo[]>
            {
                {ColorCoderClassificationName.Constructor, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.EnumMember, Color.DarkOliveGreen.ToColorableItemInfo()},
                {ColorCoderClassificationName.ExtensionMethod, Color.Violet.ToColorableItemInfo()},
                {ColorCoderClassificationName.Field, Color.CornflowerBlue.ToColorableItemInfo()},
                {ColorCoderClassificationName.LocalVariable, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.Method, Color.DeepPink.ToColorableItemInfo()},
                {ColorCoderClassificationName.Namespace, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.Property, Color.Salmon.ToColorableItemInfo()},
                {ColorCoderClassificationName.StaticMethod, Color.LawnGreen.ToColorableItemInfo()},
                {ColorCoderClassificationName.Parameter, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.Class, Color.FromArgb(78, 201, 176).ToColorableItemInfo()},
                {ColorCoderClassificationName.Attribute,Color.Gray.ToColorableItemInfo()},
                {ColorCoderClassificationName.Interface, Color.PaleTurquoise.ToColorableItemInfo()},
                {ColorCoderClassificationName.Module, Color.FromArgb(78, 201, 176).ToColorableItemInfo()},
                {ColorCoderClassificationName.Struct, Color.Yellow.ToColorableItemInfo()},
                {ColorCoderClassificationName.Enum, Color.FromArgb(184, 215, 163).ToColorableItemInfo()},
                {ColorCoderClassificationName.Delegate, Color.FromArgb(78, 201, 176).ToColorableItemInfo()},
                {ColorCoderClassificationName.GenericTypeParameter, Color.FromArgb(184, 215, 163).ToColorableItemInfo()}
            };

            return classifications;
        }

        private IDictionary<String, ColorableItemInfo[]> GetBlueThemeDefaultColors()
        {
            return new Dictionary<String, ColorableItemInfo[]>
            {
                {ColorCoderClassificationName.Constructor, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.EnumMember, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.ExtensionMethod, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Field, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.LocalVariable, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Method, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Namespace, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Property, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.StaticMethod, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Parameter, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Class, Color.FromArgb(43, 145, 175).ToColorableItemInfo()},
                {ColorCoderClassificationName.Attribute,Color.FromArgb(43, 145, 175).ToColorableItemInfo()},
                {ColorCoderClassificationName.Interface, Color.FromArgb(43, 145, 175).ToColorableItemInfo()},
                {ColorCoderClassificationName.Module, Color.FromArgb(43, 145, 175).ToColorableItemInfo()},
                {ColorCoderClassificationName.Struct, Color.FromArgb(43, 145, 175).ToColorableItemInfo()},
                {ColorCoderClassificationName.Enum, Color.FromArgb(43, 145, 175).ToColorableItemInfo()},
                {ColorCoderClassificationName.Delegate, Color.FromArgb(43, 145, 175).ToColorableItemInfo()},
                {ColorCoderClassificationName.GenericTypeParameter, Color.FromArgb(43, 145, 175).ToColorableItemInfo()}
            };
        }

        private IDictionary<String, ColorableItemInfo[]> GetDarkThemeDefaultColors()
        {
            return new Dictionary<String, ColorableItemInfo[]>
            {
                {ColorCoderClassificationName.Constructor, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.EnumMember, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.ExtensionMethod, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.Field, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.LocalVariable, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.Method, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.Namespace, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.Property, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.StaticMethod, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.Parameter, Color.Gainsboro.ToColorableItemInfo()},
                {ColorCoderClassificationName.Class, Color.FromArgb(78, 201, 176).ToColorableItemInfo()},
                {ColorCoderClassificationName.Attribute,Color.FromArgb(78, 201, 176).ToColorableItemInfo()},
                {ColorCoderClassificationName.Interface, Color.FromArgb(184, 215, 163).ToColorableItemInfo()},
                {ColorCoderClassificationName.Module,  Color.FromArgb(78, 201, 176).ToColorableItemInfo()},
                {ColorCoderClassificationName.Struct,  Color.FromArgb(78, 201, 176).ToColorableItemInfo()},
                {ColorCoderClassificationName.Enum, Color.FromArgb(184, 215, 163).ToColorableItemInfo()},
                {ColorCoderClassificationName.Delegate,  Color.FromArgb(78, 201, 176).ToColorableItemInfo()},
                {ColorCoderClassificationName.GenericTypeParameter, Color.FromArgb(184, 215, 163).ToColorableItemInfo()}
            };
        }

        public IDictionary<String, ColorableItemInfo[]> GetDefaultColorsBySelectedThemes()
        {
            var defaultBackground = VSColorTheme.GetThemedColor(EnvironmentColors.ToolWindowBackgroundColorKey);

            if (defaultBackground.Name == BLUETHEMECOLOR) return GetBlueThemeDefaultColors();

            if (defaultBackground.Name == DARKTHEMECOLOR) return GetDarkThemeDefaultColors();

            return GetBlueThemeDefaultColors();
        }
    }
}