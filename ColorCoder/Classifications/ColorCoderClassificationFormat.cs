using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace ColorCoder.Classifications
{
    public static class ClassificationTypeDefinitions
    {
        // Note: EditorFormatDefinition is not necessary for built in types listed in ClassificationTypeNames class

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Constructor)]
        [Name(ColorCoderClassificationName.Constructor)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class ConstructorClassificationFormat : ClassificationFormatDefinition
        {
            public ConstructorClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Constructor;
                this.IsBold = true;
            }
        }
    }
}