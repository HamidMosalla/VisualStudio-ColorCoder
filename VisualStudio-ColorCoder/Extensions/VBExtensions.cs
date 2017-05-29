using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;

namespace VisualStudio_ColorCoder.Extensions
{
   public static class VbExtensions
    {
        public static bool IsVbSimpleArgumentSyntaxKind(this SyntaxNode node)
        {
            return node.Kind() == SyntaxKind.SimpleArgument;
        }
    }
}