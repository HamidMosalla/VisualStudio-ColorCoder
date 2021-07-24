using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using ColorCoder.Classifications;
using ColorCoder.Types;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;

namespace ColorCoder.ColorCoderCore
{
    public class ColorCoderTagger : ITagger<IClassificationTag>
    {
        private readonly ITextBuffer _buffer;
        private readonly ColorCoderTaggerServices _colorCoderTaggerServices;
        private readonly Dictionary<string, IClassificationType> _classificationTypeDictionary;
        private ProviderCache _cache;

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

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