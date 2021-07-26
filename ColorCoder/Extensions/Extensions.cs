using System.Drawing;
using Microsoft.CodeAnalysis;
using Microsoft.VisualStudio.Shell.Interop;
using DrawingColor = System.Drawing.Color;
using MediaColor = System.Windows.Media.Color;

namespace ColorCoder.Extensions
{
    public static class Extensions
    {
        public static DrawingColor ToDrawingColor(this MediaColor mediaColor)
        {
            return DrawingColor.FromArgb(mediaColor.A, mediaColor.R, mediaColor.G, mediaColor.B);
        }

        public static ColorableItemInfo[] ToColorableItemInfo(this DrawingColor drawingColor)
        {
            ColorableItemInfo[] colorableItemInfo = new ColorableItemInfo[1];
            colorableItemInfo[0].crForeground = (uint)ColorTranslator.ToWin32(drawingColor);
            colorableItemInfo[0].bForegroundValid = 1;

            return colorableItemInfo;
        }

        public static bool IsSpecialType(this ISymbol symbol)
        {
            var type = (INamedTypeSymbol)symbol;

            return type.SpecialType != SpecialType.None;
        }

        public static bool IsExtensionMethod(this ISymbol symbol)
        {
            var method = (IMethodSymbol)symbol;

            return method.IsExtensionMethod;
        }
    }
}