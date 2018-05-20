using System;
using System.Collections.Generic;
using System.Linq;
using ColorCoder.Classifications;
using ColorCoder.Extensions;
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
    static class ColorCoderClassificationTypeNames
    {
        public const string PropertyName = "property name";
        public const string EventName = "event name";
        public const string ExtensionMethodName = "extension method name";
        public const string MethodName = "method name";
        public const string ParameterName = "parameter name";
        public const string LocalName = "local name";
        public const string FieldName = "field name";
        public const string EnumMemberName = "enum member name";
        public const string ConstantName = "constant name";
    }


    class ColorCoderTaggerServices
    {
        private static readonly HashSet<String> SupportedClassificationTypeNames = new HashSet<string>
        {
            ColorCoderClassificationTypeNames.FieldName,
            ColorCoderClassificationTypeNames.PropertyName,
            ColorCoderClassificationTypeNames.EnumMemberName,
            ColorCoderClassificationTypeNames.EventName,
            ColorCoderClassificationTypeNames.LocalName,
            ColorCoderClassificationTypeNames.ParameterName,
            ColorCoderClassificationTypeNames.ExtensionMethodName,
            ColorCoderClassificationTypeNames.ConstantName,
            ColorCoderClassificationTypeNames.MethodName,

            ClassificationTypeNames.Identifier,
            ClassificationTypeNames.ClassName,
            ClassificationTypeNames.StructName,
            ClassificationTypeNames.InterfaceName,
            ClassificationTypeNames.ModuleName,
            ClassificationTypeNames.DelegateName,
            ClassificationTypeNames.EnumName,
            ClassificationTypeNames.TypeParameterName
        };

        internal IEnumerable<ClassifiedSpan> GetIdentifiersInSpans(Workspace workspace, SemanticModel model, NormalizedSnapshotSpanCollection spans)
        {
            var comparer = StringComparer.InvariantCultureIgnoreCase;

            var classifiedSpans = spans.SelectMany(span =>
            {
                var textSpan = TextSpan.FromBounds(span.Start, span.End);
                return Classifier.GetClassifiedSpans(model, textSpan, workspace);
            });

            return classifiedSpans.Where(span => SupportedClassificationTypeNames.Contains(span.ClassificationType, comparer));
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
            if (symbol?.Kind == SymbolKind.Namespace)
            {
                classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Namespace, out IClassificationType classificationValue);

                return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
            }

            if (symbol?.Kind == SymbolKind.Parameter)
            {
                classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Parameter, out IClassificationType classificationValue);

                return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
            }

            if (symbol?.Kind == SymbolKind.Property)
            {
                classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Property, out IClassificationType classificationValue);

                return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
            }

            if (symbol?.Kind == SymbolKind.Local)
            {
                classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.LocalVariable, out IClassificationType classificationValue);

                return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
            }

            if (node.IsCSharpConstructorSyntaxKind())
            {
                classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Constructor, out IClassificationType classificationValue);
                return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
            }

            if (symbol?.Kind == SymbolKind.Method)
            {
                if (symbol.IsExtensionMethod())
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.ExtensionMethod, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }
                if (symbol.IsStatic)
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.StaticMethod, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }
                else
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Method, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }
            }

            if (symbol?.Kind == SymbolKind.Field)
            {
                if (symbol.ContainingType.TypeKind == TypeKind.Enum)
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.EnumMember, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }
                else
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Field, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }
            }

            if (symbol?.Kind == SymbolKind.NamedType)
            {
                //if (node.IsCSharpAttributeSyntaxKind())
                //{
                //    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Attribute, out IClassificationType classificationValue);

                //    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                //}

                if (span.ClassificationType == ClassificationTypeNames.InterfaceName)
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Interface, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }

                if (span.ClassificationType == ClassificationTypeNames.ClassName)
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Class, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }

                if (span.ClassificationType == ClassificationTypeNames.ModuleName)
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Module, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }

                if (span.ClassificationType == ClassificationTypeNames.StructName)
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Struct, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }

                if (span.ClassificationType == ClassificationTypeNames.EnumName)
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Enum, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }

                if (span.ClassificationType == ClassificationTypeNames.DelegateName)
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.Delegate, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }

                if (span.ClassificationType == ClassificationTypeNames.TypeParameterName)
                {
                    classificationTypeDictionary.TryGetValue(ColorCoderClassificationName.GenericTypeParameter, out IClassificationType classificationValue);
                    return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.TextSpan.Start, span.TextSpan.Length), new ClassificationTag(classificationValue));
                }
            }

            return null;
        }

        public CacheState ManageCache(ref ProviderCache cache, NormalizedSnapshotSpanCollection spans, ITextBuffer buffer)
        {
            if (cache != null && cache.Snapshot == spans[0].Snapshot) return CacheState.Resolved;

            var task = ProviderCache.ResolveAsync(buffer, spans[0].Snapshot);

            try
            {
                task.Wait();
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                return CacheState.NotResolved;
            }

            cache = task.Result;

            return cache == null ? CacheState.NotResolved : CacheState.Resolved;
        }

        public enum CacheState
        {
            Resolved,
            NotResolved
        }
    }
}