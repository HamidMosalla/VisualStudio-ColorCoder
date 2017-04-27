using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Classification;
using CSharp = Microsoft.CodeAnalysis.CSharp;
using VB = Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using VisualStudio_ColorCoder.Classifications;

namespace VisualStudio_ColorCoder.ColorCoderCore
{
    class ColorCoderProviderServices
    {
        internal IEnumerable<ClassifiedSpan> GetIdentifiersInSpans(Workspace workspace, SemanticModel model, NormalizedSnapshotSpanCollection spans)
        {
            var comparer = StringComparer.InvariantCultureIgnoreCase;

            var classifiedSpans = spans.SelectMany(span =>
            {
                var textSpan = TextSpan.FromBounds(span.Start, span.End);
                return Classifier.GetClassifiedSpans(model, textSpan, workspace);
            });

            return classifiedSpans.Where(c => comparer.Compare(c.ClassificationType, "identifier") == 0);
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

            if (node.IsVbSimpleArgumentSyntaxKind())
            {
                return ((VB.Syntax.SimpleArgumentSyntax)node).Expression;
            }

            return node;
        }

        private bool IsSpecialType(ISymbol symbol)
        {
            var type = (INamedTypeSymbol)symbol;
            return type.SpecialType != SpecialType.None;
        }

        private bool IsExtensionMethod(ISymbol symbol)
        {
            var method = (IMethodSymbol)symbol;
            return method.IsExtensionMethod;
        }

        internal IEnumerable<ITagSpan<IClassificationTag>> GetClassificationTags(ProviderCache cache, NormalizedSnapshotSpanCollection spans, Dictionary<string, IClassificationType> classificationTypeDictionary)
        {
            var snapshot = spans[0].Snapshot;
            IEnumerable<ClassifiedSpan> classifiedSpans = GetIdentifiersInSpans(cache.Workspace, cache.SemanticModel, spans);

            foreach (var classifiedSpan in classifiedSpans)
            {
                var node = GetExpression(cache.SyntaxRoot.FindNode(classifiedSpan.TextSpan));
                var symbol = cache.SemanticModel.GetSymbolInfo(node).Symbol ?? cache.SemanticModel.GetDeclaredSymbol(node);

                if (symbol?.Kind == SymbolKind.Namespace)
                {
                    IClassificationType classificationValue;
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Namespace, out classificationValue);

                    if (classificationValue == null) continue;

                    yield return classifiedSpan.TextSpan.ToTagSpan(snapshot, classificationValue);
                }
            }
        }

        public CacheState ManageCache(ref ProviderCache cache, NormalizedSnapshotSpanCollection spans, ITextBuffer buffer)
        {
            if (cache == null || cache.Snapshot != spans[0].Snapshot)
            {
                var task = ProviderCache.Resolve(buffer, spans[0].Snapshot);
                try
                {
                    task.Wait();
                }
                catch (Exception)
                {
                    return CacheState.NotResolved;
                }

                cache = task.Result;

                if (cache == null)
                {
                    return CacheState.NotResolved;
                }

                return CacheState.Resolved;
            }
            return CacheState.Resolved;
        }

        public enum CacheState
        {
            Resolved,
            NotResolved
        }
    }
}
