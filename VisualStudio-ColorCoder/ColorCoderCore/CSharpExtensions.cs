using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

namespace VisualStudio_ColorCoder.ColorCoderCore
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
            return node.Kind() == SyntaxKind.Attribute;
        }

        public static bool IsCSharpConstructorSyntaxKind(this SyntaxNode node)
        {
            return node.Kind() == SyntaxKind.ConstructorDeclaration;
        }
    }
}
