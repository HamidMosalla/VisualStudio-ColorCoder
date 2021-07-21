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
            TypeParameterName,
            ConstructorName,
            AttributeName
        };

        public const string PropertyName = ClassificationTypeNames.PropertyName;
        public const string EventName = ClassificationTypeNames.EventName;
        public const string ExtensionMethodName = ClassificationTypeNames.ExtensionMethodName;
        public const string MethodName = ClassificationTypeNames.MethodName;
        public const string ParameterName = ClassificationTypeNames.ParameterName;
        public const string LocalName = ClassificationTypeNames.LocalName;
        public const string FieldName = ClassificationTypeNames.FieldName;
        public const string EnumMemberName = ClassificationTypeNames.EnumMemberName;
        public const string ConstantName = ClassificationTypeNames.ConstantName;
        public const string Identifier = ClassificationTypeNames.Identifier;
        public const string ClassName = ClassificationTypeNames.ClassName;
        public const string ConstructorName = ColorCoderClassificationName.Constructor;
        public const string AttributeName = ColorCoderClassificationName.Attribute;
        public const string StructName = ClassificationTypeNames.StructName;
        public const string InterfaceName = ClassificationTypeNames.InterfaceName;
        public const string ModuleName = ClassificationTypeNames.ModuleName;
        public const string DelegateName = ClassificationTypeNames.DelegateName;
        public const string EnumName = ClassificationTypeNames.EnumName;
        public const string TypeParameterName = ClassificationTypeNames.TypeParameterName;
    }
}