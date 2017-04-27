using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VisualStudio_ColorCoder.Classifications
{

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Interface)]
    [Name(ColorCoderClassificationName.Interface)]
    [UserVisible(true)]
    [Order(After = Priority.Default)]
    public sealed class InterfaceClassificationFormat : ClassificationFormatDefinition
    {
        public InterfaceClassificationFormat()
        {
            this.DisplayName = ColorCoderClassificationName.Interface;
            this.ForegroundColor = Colors.Red;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Namespace)]
    [Name(ColorCoderClassificationName.Namespace)]
    [UserVisible(true)]
    [Order(After = Priority.Default)]
    public sealed class NameSpaceClassificationFormat : ClassificationFormatDefinition
    {
        public NameSpaceClassificationFormat()
        {
            this.DisplayName = "Hott and Holler";
            this.ForegroundColor = Colors.DeepPink;
            this.IsBold = true;
            this.FontRenderingSize = 20;
        }
    }

}
