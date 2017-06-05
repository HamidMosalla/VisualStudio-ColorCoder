using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Microsoft.VisualStudio.Text.Classification;

namespace ColorCoder.Classifications
{
    public sealed class ClassificationTypeFactory
    {
        private static ClassificationTypeFactory instance = null;
        private static readonly object Padlock = new object();
        private static IClassificationTypeRegistryService _classificationRegistry;
        private Dictionary<string, IClassificationType> _classificationTypes;

        ClassificationTypeFactory() { }

        public static ClassificationTypeFactory Instance
        {
            get
            {
                lock (Padlock)
                {
                    return instance ?? (instance = new ClassificationTypeFactory
                    {
                        _classificationTypes = GetClassificationTypes()
                    });
                }
            }
        }

        public static IClassificationTypeRegistryService ClassificationRegistry
        {
            set
            {
                if (instance == null)
                {
                    _classificationRegistry = value;
                }
            }
        }

        public Dictionary<string, IClassificationType> ClassificationTypes
        {
            get
            {
                if (instance != null)
                {
                    return _classificationTypes;
                }

                return new Dictionary<string, IClassificationType>();
            }
        }

        private static Dictionary<string, IClassificationType> GetClassificationTypes()
        {
            var classificationTypes = new Dictionary<string, IClassificationType>();

            var classificationNames = new ColorCoderClassificationName().GetType()
                .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                .Where(fi => fi.IsLiteral && !fi.IsInitOnly)
                .Select(fi => fi.GetRawConstantValue()).ToList();

            foreach (var classificationName in classificationNames)
            {
                classificationTypes.Add(classificationName.ToString(), _classificationRegistry.GetClassificationType(classificationName.ToString()));
            }

            return classificationTypes;
        }
    }
}