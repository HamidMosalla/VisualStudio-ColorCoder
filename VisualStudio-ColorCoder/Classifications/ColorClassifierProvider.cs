using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.VisualStudio.Text;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using VisualStudio_ColorCoder.ColorCoderCore;
using VisualStudio_ColorCoder.State;

namespace VisualStudio_ColorCoder.Classifications
{
    [ContentType(ContentTypes.CSharp)]
    [ContentType(ContentTypes.VB)]
    [Export(typeof(IClassifierProvider))]
    class ColorClassifierProvider : IClassifierProvider
    {
        [Import] internal IClassificationTypeRegistryService ClassificationRegistry;
        [Import] internal IClassificationFormatMapService ClassificationFormatMapService;

        private static ColorClassifier _colorsClassifierClassifier;

        public IClassifier GetClassifier(ITextBuffer textBuffer)
        {
            
            try
            {
                if (_colorsClassifierClassifier == null)
                {
                    Interlocked.CompareExchange(ref _colorsClassifierClassifier, new ColorClassifier(), null);

                    _colorsClassifierClassifier.Initialize(ClassificationRegistry, ClassificationFormatMapService);
                }
            }
            catch (Exception ex)
            {
                Log.LogError(ex.ToString());
                throw;
            }
            return _colorsClassifierClassifier;
        }

    }
}