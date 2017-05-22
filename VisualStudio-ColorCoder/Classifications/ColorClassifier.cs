using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using VisualStudio_ColorCoder.ColorCoderCore;
using VisualStudio_ColorCoder.State;

namespace VisualStudio_ColorCoder.Classifications
{
    class ColorClassifier : IClassifier
    {
        private int _initialized;
        private bool _settingsLoaded;
        private IClassificationTypeRegistryService _classificationTypeRegistry;
        private IClassificationFormatMapService _formatMapService;

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            try
            {
                var spans = new List<ClassificationSpan>();
                var snapshot = span.Snapshot;
                if (snapshot == null || snapshot.Length == 0) return spans;

                var start = span.Start.GetContainingLine().LineNumber;
                var end = (span.End - 1).GetContainingLine().LineNumber;
                for (var i = start; i <= end; i++)
                {
                    var line = snapshot.GetLineFromLineNumber(i);
                    if (line == null) continue;
                    var snapshotSpan = new SnapshotSpan(line.Start, line.Length);
                    var text = line.Snapshot.GetText(snapshotSpan);
                    if (string.IsNullOrEmpty(text)) continue;

                    var classificationNames = ColorCoderClassificationName.Namespace;

                    var type = _classificationTypeRegistry.GetClassificationType(classificationNames);

                    if (type != null) spans.Add(new ClassificationSpan(line.Extent, type));
                }
                return spans;
            }
            catch (RegexMatchTimeoutException)
            {
                // eat it.
                return new List<ClassificationSpan>();
            }
            catch (NullReferenceException)
            {
                // eat it.    
                return new List<ClassificationSpan>();
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw;
            }
        }

        public void Initialize(IClassificationTypeRegistryService classificationRegistry, IClassificationFormatMapService formatMapService)
        {
            if (Interlocked.CompareExchange(ref _initialized, 1, 0) == 1) return;

            try
            {
                _classificationTypeRegistry = classificationRegistry;
                _formatMapService = formatMapService;

                State.Settings.SettingsUpdated += (sender, args) =>
                {
                    _settingsLoaded = false;
                    UpdateFormatMap();
                };
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
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
                    var classificationType = _classificationTypeRegistry.GetClassificationType(names);
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

        private void LoadSettings()
        {
            if (_settingsLoaded) return;
            var settings = State.Settings.Load();
            //HighlightFindResults = settings.HighlightFindResults;
            _settingsLoaded = true;
        }

        public event EventHandler<ClassificationChangedEventArgs> ClassificationChanged;
    }
}