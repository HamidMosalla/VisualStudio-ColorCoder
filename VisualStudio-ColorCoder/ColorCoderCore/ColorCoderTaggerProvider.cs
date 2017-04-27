using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Text.Tagging;
using Microsoft.VisualStudio.Utilities;

namespace VisualStudio_ColorCoder.ColorCoderCore
{
    [Export(typeof(ITaggerProvider))]
    [ContentType(ContentTypes.CSharp)]
    [ContentType(ContentTypes.VB)]
    [TagType(typeof(IClassificationTag))]
    class ColorCoderTaggerProvider : ITaggerProvider
    {
        [Import]
        internal IClassificationTypeRegistryService ClassificationRegistry;

        public ITagger<T> CreateTagger<T>(ITextBuffer buffer) where T : ITag
        {
            return (ITagger<T>)new ColorCoderTagger(buffer, ClassificationRegistry);
        }
    }
}
