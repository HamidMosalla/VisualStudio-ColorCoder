using System;
using System.Collections.Generic;
using System.Linq;
using ColorCoder.Classifications;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using CacheState = ColorCoder.ColorCoderCore.ColorCoderTaggerServices.CacheState;

namespace ColorCoder.ColorCoderCore
{
    internal class ColorCoderTagger : ITagger<IClassificationTag>
    {
        private ITextBuffer _buffer;
        private readonly ColorCoderTaggerServices _colorCoderTaggerServices;
        private readonly Dictionary<string, IClassificationType> _classificationTypeDictionary;
        private ProviderCache _cache;

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        //why it is called tree times?
        public ColorCoderTagger(ITextBuffer buffer, IClassificationTypeRegistryService classificationRegistry)
        {
            this._buffer = buffer;
            ClassificationTypeFactory.ClassificationRegistry = classificationRegistry;
            _classificationTypeDictionary = ClassificationTypeFactory.Instance.ClassificationTypes;
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

            return _colorCoderTaggerServices.GetClassificationTags(_cache, spans, _classificationTypeDictionary);
        }
    }
}