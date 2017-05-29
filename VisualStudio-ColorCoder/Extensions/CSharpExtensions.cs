using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace VisualStudio_ColorCoder.Extensions
{
    public static class CSharpExtensions
    {
        public static bool IsCSharpArgumentSyntaxKind(this SyntaxNode node)
        {
            return node.Kind() == SyntaxKind.Argument;
        }

        public static bool IsCSharpAttributeArgumentSyntaxKind(this SyntaxNode node)
        {
            return node.Kind() == SyntaxKind.AttributeArgument;
        }

        public static bool IsCSharpAttributeSyntaxKind(this SyntaxNode node)
        {
            //return node.Kind() == SyntaxKind.Attribute;
            return (node.Parent.Kind() == SyntaxKind.IdentifierName && node.Parent.Kind() == SyntaxKind.Attribute);
        }

        public static bool IsCSharpConstructorSyntaxKind(this SyntaxNode node)
        {
            return node.Kind() == SyntaxKind.ConstructorDeclaration;
        }

        public static bool IsCSharpAbstractSyntaxKind(this SyntaxNode node)
        {
            return node.Kind() == SyntaxKind.Attribute;
        }
    }
}