using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Media;
using ColorCoder.Classifications;
using ColorCoder.Extensions;
using ColorCoder.Types;
using Microsoft.VisualStudio;
using Microsoft.VisualStudio.Shell.Interop;
using Color = System.Drawing.Color;

namespace ColorCoder.ColorCoderCore
{
    public class ColorManager
    {
        private readonly ColorStorage _colorStorage;
        private readonly IDictionary<String, ColorableItemInfo[]> _classifications;

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

        public IDictionary<String, ColorableItemInfo[]> GetColorableItemInfoDictionary()
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
                {ColorCoderClassificationName.Interface, Color.DarkSlateBlue.ToColorableItemInfo()},
                {ColorCoderClassificationName.Module, Color.Black.ToColorableItemInfo()},
                {ColorCoderClassificationName.Struct, Color.Orchid.ToColorableItemInfo()},
                {ColorCoderClassificationName.Enum, Color.SeaGreen.ToColorableItemInfo()},
                {ColorCoderClassificationName.Delegate, Color.DarkKhaki.ToColorableItemInfo()},
                {ColorCoderClassificationName.GenericTypeParameter, Color.DeepSkyBlue.ToColorableItemInfo()}
            };

            return classifications;
        }

        public void RestoreColorCoderToDefault()
        {
            var colorableItemInfoDictionary = GetColorableItemInfoDictionary();

            foreach (var item in colorableItemInfoDictionary)
            {
                item.Value[0].crForeground = (uint)ColorTranslator.ToWin32(Color.Black);
            }

            Save(colorableItemInfoDictionary);
        }
    }
}