using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Text.Classification;
using VisualStudio_ColorCoder.Classifications;

namespace ColorCoder.Classifications
{
    class ClassificationTypeFactory
    {
        private Dictionary<string, IClassificationType> classificationTypes;

        public ClassificationTypeFactory(IClassificationTypeRegistryService classificationRegistry)
        {
            classificationTypes = new Dictionary<string, IClassificationType>();

            var classificationNames = new ColorCoderClassificationName().GetType()
                                            .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                            .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                                            .Select(fi => fi.GetRawConstantValue()).ToList();

            foreach (var classificationName in classificationNames)
            {
                classificationTypes.Add(classificationName.ToString(), classificationRegistry.GetClassificationType(classificationName.ToString()));
            }
        }

        public Dictionary<string, IClassificationType> CreateClassificationTypes()
        {
            return classificationTypes;
        }
    }
}