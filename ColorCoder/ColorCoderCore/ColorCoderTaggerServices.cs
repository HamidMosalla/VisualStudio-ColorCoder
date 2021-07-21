using System;
using System.Collections.Generic;
using System.Linq;
using ColorCoder.Classifications;
using ColorCoder.Extensions;
using ColorCoder.Types;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using CSharp = Microsoft.CodeAnalysis.CSharp;
using VB = Microsoft.CodeAnalysis.VisualBasic;

namespace ColorCoder.ColorCoderCore
{
    partial class ColorCoderTaggerServices
    {
        internal IEnumerable<ClassifiedSpan> GetIdentifiersInSpans(Workspace workspace, SemanticModel model, NormalizedSnapshotSpanCollection spans)
        {
            var classifiedSpans = spans.SelectMany(span =>
            {
                var textSpan = TextSpan.FromBounds(span.Start, span.End);
                return Classifier.GetClassifiedSpans(model, textSpan, workspace);
            });

            return classifiedSpans.Where(span => ColorCoderClassificationTypeNames.SupportedClassificationTypeNames.Contains(span.ClassificationType,
                    StringComparer.InvariantCultureIgnoreCase));
        }

        internal SyntaxNode GetExpression(SyntaxNode node)
        {
            if (node.IsCSharpArgumentSyntaxKind())
            {
                return ((CSharp.Syntax.ArgumentSyntax)node).Expression;
            }

            if (node.IsCSharpAttributeArgumentSyntaxKind())
            {
                return ((CSharp.Syntax.AttributeArgumentSyntax)node).Expression;
            }

            if (node.IsCSharpAttributeSyntaxKind())
            {
                return ((CSharp.Syntax.AttributeSyntax)node).Parent;
            }

            if (node.IsVbSimpleArgumentSyntaxKind())
            {
                return ((VB.Syntax.SimpleArgumentSyntax)node).Expression;
            }

            return node;
        }

        internal IEnumerable<ITagSpan<IClassificationTag>> GetClassificationTags(ProviderCache cache, NormalizedSnapshotSpanCollection spans, Dictionary<string, IClassificationType> classificationTypeDictionary)
        {
            var snapshot = spans[0].Snapshot;
            IEnumerable<ClassifiedSpan> classifiedSpans = GetIdentifiersInSpans(cache.Workspace, cache.SemanticModel, spans);

            foreach (var classifiedSpan in classifiedSpans)
            {
                var node = GetExpression(cache.SyntaxRoot.FindNode(classifiedSpan.TextSpan));
                var symbol = cache.SemanticModel.GetSymbolInfo(node).Symbol ?? cache.SemanticModel.GetDeclaredSymbol(node);
                yield return GetTagSpan(node, classifiedSpan, snapshot, symbol, classificationTypeDictionary);
            }
        }

        public ITagSpan<IClassificationTag> GetTagSpan(SyntaxNode node, ClassifiedSpan span, ITextSnapshot snapshot, ISymbol symbol, Dictionary<string, IClassificationType> classificationTypeDictionary)
        {
            // if (span.ClassificationType == ClassificationTypeNames.Identifier) { }

            if (node.IsCSharpConstructorSyntaxKind())
            {
                classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Constructor, out IClassificationType classificationValue);
                return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
            }

            return null;
        }

        public CacheState ManageCache(ref ProviderCache cache, NormalizedSnapshotSpanCollection spans, ITextBuffer buffer)
        {
            if (cache != null && cache.Snapshot == spans[0].Snapshot) return CacheState.Resolved;

            var task = ProviderCache.ResolveAsync(buffer, spans[0].Snapshot);

            try
            {
                // TODO: can we make this async?
                task.Wait();
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                return CacheState.NotResolved;
            }

            // TODO: can we make this async?
            cache = task.Result;

            return cache == null ? CacheState.NotResolved : CacheState.Resolved;
        }
    }
}