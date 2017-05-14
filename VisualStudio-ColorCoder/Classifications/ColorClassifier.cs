using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using VisualStudio_ColorCoder.ColorCoderCore;

namespace VisualStudio_ColorCoder.Classifications
{
    class ColorClassifier : IClassifier
    {
        private int _initialized;
        private bool _settingsLoaded;
        private IClassificationTypeRegistryService _classificationRegistry;
        private IClassificationFormatMapService _formatMapService;

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            throw new NotImplementedException();
        }

        public void Initialize(IClassificationTypeRegistryService classificationRegistry, IClassificationFormatMapService formatMapService)
        {
            if (Interlocked.CompareExchange(ref _initialized, 1, 0) == 1) return;

            try
            {
                _classificationRegistry = classificationRegistry;
                _formatMapService = formatMapService;

                //Settings.SettingsUpdated += (sender, args) =>
                //{
                //    _settingsLoaded = false;
                UpdateFormatMap();
                //};
            }
            catch (Exception ex)
            {
                //Log.LogError(ex.ToString());
                throw;
            }
        }

        private void UpdateFormatMap()
        {
            var colorMap = ColorMap.GetMap();
            var formatMap = _formatMapService.GetClassificationFormatMap("colors");
            try
            {
                var classificationNames = new[]
                {
                    ColorCoderClassificationName.Namespace,
                    ColorCoderClassificationName.Method
                };

                formatMap.BeginBatchUpdate();
                foreach (var names in classificationNames)
                {
                    var classificationType = _classificationRegistry.GetClassificationType(names);
                    var textProperties = formatMap.GetTextProperties(classificationType);
                    var color = colorMap[names];
                    formatMap.SetTextProperties(classificationType, textProperties.SetForeground(color));
                }
            }
            finally
            {
                formatMap.EndBatchUpdate();
            }
        }

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
    }
}
