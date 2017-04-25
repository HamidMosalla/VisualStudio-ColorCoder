using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using VisualStudio_ColorCoder.Classifications;
using Microsoft.CodeAnalysis;

namespace VisualStudio_ColorCoder.ColorCoderCore
{
    internal class ColorCoderProvider : ITagger<IClassificationTag>
    {
        private ITextBuffer _buffer;
        //private IClassificationTypeRegistryService _classificationRegistry;
        //private IEnumerable<IClassificationType> _classificationTypes;
        private readonly IClassificationType _nameSpaceType;
        private ColorCoderProviderServices colorCoderProviderServices;

        public event EventHandler<SnapshotSpanEventArgs> TagsChanged;


        public ColorCoderProvider(ITextBuffer buffer, IClassificationTypeRegistryService classificationRegistry)
        {
            this._buffer = buffer;
            _nameSpaceType = classificationRegistry.GetClassificationType(ColorCoderClassificationName.Namespace);
            colorCoderProviderServices = new ColorCoderProviderServices();
        }


        public IEnumerable<ITagSpan<IClassificationTag>> GetTags(NormalizedSnapshotSpanCollection spans)
        {
           
            var snapshot = spans[0].Snapshot;
            var cache = new ProviderCache();
            IEnumerable<ClassifiedSpan> identifiers = colorCoderProviderServices.GetIdentifiersInSpans(cache.Workspace, cache.SemanticModel, spans);
            var node = colorCoderProviderServices.GetExpression(cache.SyntaxRoot.FindNode(identifiers.First().TextSpan));
            var symbol = cache.SemanticModel.GetSymbolInfo(node).Symbol ?? cache.SemanticModel.GetDeclaredSymbol(node);

            yield return identifiers.First().TextSpan.ToTagSpan(snapshot, _nameSpaceType);
        }

    }
}