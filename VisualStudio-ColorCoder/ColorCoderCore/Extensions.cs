using System;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using CSharp = Microsoft.CodeAnalysis.CSharp;
using VB = Microsoft.CodeAnalysis.VisualBasic;
using Microsoft.CodeAnalysis.Text;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;

namespace VisualStudio_ColorCoder.ColorCoderCore
{
    public static class Extensions
    {
        public static ITagSpan<IClassificationTag> ToTagSpan(this TextSpan span, ITextSnapshot snapshot, IClassificationType classificationType)
        {
            return new TagSpan<IClassificationTag>(new SnapshotSpan(snapshot, span.Start, span.Length), new ClassificationTag(classificationType));
        }

        public static String GetText(this ITextSnapshot snapshot, TextSpan span)
        {
            return snapshot.GetText(new Span(span.Start, span.Length));
        }

        


    }
}
