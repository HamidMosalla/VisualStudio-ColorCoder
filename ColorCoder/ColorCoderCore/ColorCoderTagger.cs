using System;
using System.Collections.Generic;
using System.Linq;
using ColorCoder.Classifications;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using VisualStudio_ColorCoder.ColorCoderCore;
using CacheState = VisualStudio_ColorCoder.ColorCoderCore.ColorCoderTaggerServices.CacheState;

namespace ColorCoder.ColorCoderCore
{
    internal class ColorCoderTagger : ITagger<IClassificationTag>
    {
        private ITextBuffer _buffer;
        private readonly ColorCoderTaggerServices _colorCoderTaggerServices;
        private readonly ClassificationTypeFactory _classificationTypeFactory;
        private readonly Dictionary<string, IClassificationType> classificationTypeDictionary;
        private ProviderCache _cache;

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        public ColorCoderTagger(ITextBuffer buffer, IClassificationTypeRegistryService classificationRegistry)
        {
            this._buffer = buffer;
            _classificationTypeFactory = new ClassificationTypeFactory(classificationRegistry);
            classificationTypeDictionary = _classificationTypeFactory.CreateClassificationTypes();
            _colorCoderTaggerServices = new ColorCoderTaggerServices();
        }

        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (spans.Count == 0)
            {
                return Enumerable.Empty<ITagSpan<IClassificationTag>>();
            }

            var cacheStatus = _colorCoderTaggerServices.ManageCache(ref _cache, spans, _buffer);

            if (cacheStatus == CacheState.NotResolved)
            {
                return Enumerable.Empty<ITagSpan<IClassificationTag>>();
            }

            return _colorCoderTaggerServices.GetClassificationTags(_cache, spans, classificationTypeDictionary);
        }
    }
}