using Microsoft.CodeAnalysis.Classification;
using System;

namespace ColorCoder.Classifications
{
    class ColorCoderClassificationName
    {
        public const String Constructor = "ColorCoder Constructor";
        public const String Attribute = "ColorCoder Attribute";


        public const String Property = ClassificationTypeNames.PropertyName;
        public const String Parameter = ClassificationTypeNames.ParameterName;
        public const String Namespace = ClassificationTypeNames.NamespaceName;
        public const String Module = ClassificationTypeNames.ModuleName;
        public const String Interface = ClassificationTypeNames.InterfaceName;
        public const String Class = ClassificationTypeNames.ClassName;
        public const String Struct = ClassificationTypeNames.StructName;
        public const String Enum = ClassificationTypeNames.EnumName;
        public const String Delegate = ClassificationTypeNames.DelegateName;
        public const String GenericTypeParameter = ClassificationTypeNames.TypeParameterName;
        public const String Method = ClassificationTypeNames.MethodName;
        public const String StaticMethod = ClassificationTypeNames.StaticSymbol;
        public const String ExtensionMethod = ClassificationTypeNames.ExtensionMethodName;
        public const String LocalVariable = ClassificationTypeNames.LocalName;
        public const String Field = ClassificationTypeNames.FieldName;
        public const String EnumMember = ClassificationTypeNames.EnumMemberName;
    }
}