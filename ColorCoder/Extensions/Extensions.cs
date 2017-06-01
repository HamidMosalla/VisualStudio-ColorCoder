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

        public static MediaColor ToMediaColor(this DrawingColor drawingColor)
        {
            return MediaColor.FromArgb(drawingColor.A, drawingColor.R, drawingColor.G, drawingColor.B);
        }
    }
}