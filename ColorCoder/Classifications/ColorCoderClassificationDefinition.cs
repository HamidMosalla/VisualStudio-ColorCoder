using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using VisualStudio_ColorCoder.Classifications;

namespace ColorCoder.Classifications
{
    class ColorCoderClassificationDefinition
    {
        [Export, Name(ColorCoderClassificationName.Interface)]
        internal static ClassificationTypeDefinition InterfaceClassificationType;

        [Export, Name(ColorCoderClassificationName.Struct)]
        internal static ClassificationTypeDefinition StructClassificationType;


        [Export, Name(ColorCoderClassificationName.Enum)]
        internal static ClassificationTypeDefinition EnumClassificationType;


        [Export, Name(ColorCoderClassificationName.EnumMember)]
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
        internal static ClassificationTypeDefinition PropertyClassificationType;


        [Export, Name(ColorCoderClassificationName.Parameter)]
        internal static ClassificationTypeDefinition ParameterClassificationType;

    }
}
