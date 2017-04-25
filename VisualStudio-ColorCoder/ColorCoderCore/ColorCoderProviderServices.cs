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

namespace VisualStudio_ColorCoder.ColorCoderCore
{
    class ColorCoderProviderServices
    {
        internal IEnumerable<ClassifiedSpan> GetIdentifiersInSpans(Workspace workspace, SemanticModel model, NormalizedSnapshotSpanCollection spans)
        {
            var comparer = StringComparer.InvariantCultureIgnoreCase;
            var classifiedSpans =
              spans.SelectMany(span => {
                  var textSpan = TextSpan.FromBounds(span.Start, span.End);
                  return Classifier.GetClassifiedSpans(model, textSpan, workspace);
              });

            return from cs in classifiedSpans
                   where comparer.Compare(cs.ClassificationType, "identifier") == 0
                   select cs;
        }

        internal SyntaxNode GetExpression(SyntaxNode node) {

            if (node.IsCSharpArgumentSyntaxKind()) {
                return ((CSharp.Syntax.ArgumentSyntax)node).Expression;
            }

            if (node.IsCSharpAttributeArgumentSyntaxKind()) {
                return ((CSharp.Syntax.AttributeArgumentSyntax)node).Expression;
            }

            if (node.IsVbSimpleArgumentSyntaxKind()) {
                return ((VB.Syntax.SimpleArgumentSyntax)node).Expression;
            }

            return node;
        }
    }
}
