using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
        private IClassificationTypeRegistryService _classificationRegistry;
        private IClassificationFormatMapService _formatMapService;

        public IList<ClassificationSpan> GetClassificationSpans(SnapshotSpan span)
        {
            LoadSettings();
            var classifications = new List<ClassificationSpan>();

            //var snapshot = span.Snapshot;
            //if (snapshot == null || snapshot.Length == 0 || !CanSearch(span) || !HighlightFindResults)
            //{
            //    return classifications;
            //}

            //var text = span.GetText();

            //var filenameSpans = GetMatches(text, FilenameRegex, span.Start, FilenameClassificationType).ToList();
            //var searchTermSpans = GetMatches(text, _searchTextRegex, span.Start, SearchTermClassificationType).ToList();

            //var toRemove = (from searchSpan in searchTermSpans
            //                from filenameSpan in filenameSpans
            //                where filenameSpan.Span.Contains(searchSpan.Span)
            //                select searchSpan).ToList();

            //classifications.AddRange(filenameSpans);
            //classifications.AddRange(searchTermSpans.Except(toRemove));
            return classifications;
        }

        public void Initialize(IClassificationTypeRegistryService classificationRegistry, IClassificationFormatMapService formatMapService)
        {
            if (Interlocked.CompareExchange(ref _initialized, 1, 0) == 1) return;

            try
            {
                _classificationRegistry = classificationRegistry;
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
