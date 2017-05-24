using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.VisualBasic;

namespace VisualStudio_ColorCoder.ColorCoderCore
{
   public static class VbExtensions
    {
        public static bool IsVbSimpleArgumentSyntaxKind(this SyntaxNode node)
        {
            return node.Kind() == SyntaxKind.SimpleArgument;
        }
    }
}