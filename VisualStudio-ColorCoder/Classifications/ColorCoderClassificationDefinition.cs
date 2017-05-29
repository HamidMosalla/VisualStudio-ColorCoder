using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace VisualStudio_ColorCoder.Classifications
{
    class ColorCoderClassificationDefinition
    {
        [Export, Name(ColorCoderClassificationName.Interface)]
        internal static ClassificationTypeDefinition InterfaceClassificationType;

        [Export, Name(ColorCoderClassificationName.AbstractClass)]
        internal static ClassificationTypeDefinition AbstractClassClassificationType;


        [Export, Name(ColorCoderClassificationName.StaticClass)]
        internal static ClassificationTypeDefinition StaticClassClassificationType;


        [Export, Name(ColorCoderClassificationName.Struct)]
        internal static ClassificationTypeDefinition StructClassificationType;


        [Export, Name(ColorCoderClassificationName.Enum)]
        internal static ClassificationTypeDefinition EnumClassificationType;


        [Export, Name(ColorCoderClassificationName.EnumConstant)]
        internal static ClassificationTypeDefinition EnumConstantClassificationType;


        [Export, Name(ColorCoderClassificationName.Constructor)]
        internal static ClassificationTypeDefinition ConstructorClassificationType;


        [Export, Name(ColorCoderClassificationName.Attribute)]
        internal static ClassificationTypeDefinition AttributeClassificationType;


        [Export, Name(ColorCoderClassificationName.Field)]
        internal static ClassificationTypeDefinition FieldClassificationType;

        [Export, Name(ColorCoderClassificationName.LocalVariable)]
        internal static ClassificationTypeDefinition LocalClassificationType;


        [Export, Name(ColorCoderClassificationName.Namespace)]
        internal static ClassificationTypeDefinition NamespaceClassificationType;


        [Export, Name(ColorCoderClassificationName.Method)]
        internal static ClassificationTypeDefinition MethodClassificationType;


        [Export, Name(ColorCoderClassificationName.StaticMethod)]
        internal static ClassificationTypeDefinition StaticMethodClassificationType;


        [Export, Name(ColorCoderClassificationName.ExtensionMethod)]
        internal static ClassificationTypeDefinition ExtensionMethodClassificationType;


        [Export, Name(ColorCoderClassificationName.Property)]
        internal static ClassificationTypeDefinition AutomaticPropertyClassificationType;


        [Export, Name(ColorCoderClassificationName.TypeParameter)]
        internal static ClassificationTypeDefinition ParameterClassificationType;

    }
}
