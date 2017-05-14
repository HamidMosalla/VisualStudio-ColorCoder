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

namespace VisualStudio_ColorCoder.Classifications
{
    [ContentType("Colors")]
    [Export(typeof(IClassifierProvider))]
    class ColorClassifierProvider : IClassifierProvider
    {
        [Import] internal IClassificationTypeRegistryService ClassificationRegistry;
        [Import] internal IClassificationFormatMapService ClassificationFormatMapService;

        private static ColorClassifier _findResultsClassifier;

        public IClassifier GetClassifier(ITextBuffer textBuffer)
        {
            if (_findResultsClassifier == null)
            {
                Interlocked.CompareExchange(
                    ref _findResultsClassifier,
                    new ColorClassifier(),
                    null);

                _findResultsClassifier.Initialize(ClassificationRegistry, ClassificationFormatMapService);
            }
            return _findResultsClassifier;
        }

    }
}
