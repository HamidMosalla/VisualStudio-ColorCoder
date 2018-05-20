using System;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.Classification;

namespace ColorCoder.Classifications
{
    public static class ColorCoderClassificationTypeNames
    {
        public static readonly HashSet<String> SupportedClassificationTypeNames = new HashSet<string>
        {
            FieldName,
            PropertyName,
            EnumMemberName,
            EventName,
            LocalName,
            ParameterName,
            ExtensionMethodName,
            ConstantName,
            MethodName,
            Identifier,
            ClassName,
            StructName,
            InterfaceName,
            ModuleName,
            DelegateName,
            EnumName,
            TypeParameterName
        };

        public const string PropertyName = "property name";
        public const string EventName = "event name";
        public const string ExtensionMethodName = "extension method name";
        public const string MethodName = "method name";
        public const string ParameterName = "parameter name";
        public const string LocalName = "local name";
        public const string FieldName = "field name";
        public const string EnumMemberName = "enum member name";
        public const string ConstantName = "constant name";

        public const string Identifier = ClassificationTypeNames.Identifier;
        public const string ClassName = ClassificationTypeNames.ClassName;
        public const string StructName = ClassificationTypeNames.StructName;
        public const string InterfaceName = ClassificationTypeNames.InterfaceName;
        public const string ModuleName = ClassificationTypeNames.ModuleName;
        public const string DelegateName = ClassificationTypeNames.DelegateName;
        public const string EnumName = ClassificationTypeNames.EnumName;
        public const string TypeParameterName = ClassificationTypeNames.TypeParameterName;
    }
}