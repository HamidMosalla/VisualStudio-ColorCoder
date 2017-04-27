using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using VisualStudio_ColorCoder.Classifications;
using Microsoft.CodeAnalysis;
using CacheState = VisualStudio_ColorCoder.ColorCoderCore.ColorCoderProviderServices.CacheState;

namespace VisualStudio_ColorCoder.ColorCoderCore
{
    internal class ColorCoderProvider : ITagger<IClassificationTag>
    {
        private ITextBuffer _buffer;
        private readonly ColorCoderProviderServices _colorCoderProviderServices;
        private readonly ClassificationTypeFactory _classificationTypeFactory;
        private readonly Dictionary<string, IClassificationType> classificationTypeDictionary;
        private ProviderCache _cache;

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;

        public ColorCoderProvider(ITextBuffer buffer, IClassificationTypeRegistryService classificationRegistry)
        {
            this._buffer = buffer;
            _classificationTypeFactory = new ClassificationTypeFactory(classificationRegistry);
            classificationTypeDictionary = _classificationTypeFactory.CreateClassificationTypes();
            _colorCoderProviderServices = new ColorCoderProviderServices();
        }

        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
            if (spans.Count == 0)
            {
                return Enumerable.Empty<ITagSpan<IClassificationTag>>();
            }

            var cacheStatus = _colorCoderProviderServices.ManageCache(ref _cache, spans, _buffer);

            if (cacheStatus == CacheState.NotResolved)
            {
                return Enumerable.Empty<ITagSpan<IClassificationTag>>();
            }

            return _colorCoderProviderServices.GetClassificationTags(_cache, spans, classificationTypeDictionary);
        }
    }
}