using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using VisualStudio_ColorCoder.State;

namespace VisualStudio_ColorCoder.Classifications
{
    public static class ClassificationTypeDefinitions
    {
        public static PresetColors Colors = State.Settings.Load();

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Interface)]
        [Name(ColorCoderClassificationName.Interface)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class InterfaceClassificationFormat : ClassificationFormatDefinition
        {
            public InterfaceClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Interface;
                this.ForegroundColor = Colors.Interface;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.AbstractClass)]
        [Name(ColorCoderClassificationName.AbstractClass)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class AbstractClassClassificationFormat : ClassificationFormatDefinition
        {
            public AbstractClassClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.AbstractClass;
                this.ForegroundColor = Colors.AbstractClass;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.StaticClass)]
        [Name(ColorCoderClassificationName.StaticClass)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class StaticClassClassificationFormat : ClassificationFormatDefinition
        {
            public StaticClassClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.StaticClass;
                this.ForegroundColor = Colors.StaticClass;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Struct)]
        [Name(ColorCoderClassificationName.Struct)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class StructClassificationFormat : ClassificationFormatDefinition
        {
            public StructClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Struct;
                this.ForegroundColor = Colors.Struct;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Enum)]
        [Name(ColorCoderClassificationName.Enum)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class EnumClassificationFormat : ClassificationFormatDefinition
        {
            public EnumClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Enum;
                this.ForegroundColor = Colors.Enum;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.EnumConstant)]
        [Name(ColorCoderClassificationName.EnumConstant)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class EnumConstantClassificationFormat : ClassificationFormatDefinition
        {
            public EnumConstantClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.EnumConstant;
                this.ForegroundColor = Colors.EnumConstant;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Constructor)]
        [Name(ColorCoderClassificationName.Constructor)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class ConstructorClassificationFormat : ClassificationFormatDefinition
        {
            public ConstructorClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Constructor;
                this.ForegroundColor = Colors.Constructor;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Attribute)]
        [Name(ColorCoderClassificationName.Attribute)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class AttributeClassificationFormat : ClassificationFormatDefinition
        {
            public AttributeClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Attribute;
                this.ForegroundColor = Colors.Attribute;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Field)]
        [Name(ColorCoderClassificationName.Field)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class FieldClassificationFormat : ClassificationFormatDefinition
        {
            public FieldClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Field;
                this.ForegroundColor = Colors.Field;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Local)]
        [Name(ColorCoderClassificationName.Local)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class LocalClassificationFormat : ClassificationFormatDefinition
        {
            public LocalClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Local;
                this.ForegroundColor = Colors.Local;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Namespace)]
        [Name(ColorCoderClassificationName.Namespace)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class NamespaceClassificationFormat : ClassificationFormatDefinition
        {
            public NamespaceClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Namespace;
                this.ForegroundColor = Colors.Namespace;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Method)]
        [Name(ColorCoderClassificationName.Method)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class MethodClassificationFormat : ClassificationFormatDefinition
        {
            public MethodClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Method;
                this.ForegroundColor = Colors.Method;
                this.IsBold = true;
                this.FontRenderingSize = 12;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.StaticMethod)]
        [Name(ColorCoderClassificationName.StaticMethod)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class StaticMethodClassificationFormat : ClassificationFormatDefinition
        {
            public StaticMethodClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.StaticMethod;
                this.ForegroundColor = Colors.StaticMethod;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.ExtensionMethod)]
        [Name(ColorCoderClassificationName.ExtensionMethod)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class ExtensionMethodClassificationFormat : ClassificationFormatDefinition
        {
            public ExtensionMethodClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.ExtensionMethod;
                this.ForegroundColor = Colors.ExtensionMethod;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Property)]
        [Name(ColorCoderClassificationName.Property)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class PropertyClassificationFormat : ClassificationFormatDefinition
        {
            public PropertyClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Property;
                this.ForegroundColor = Colors.AutomaticProperty;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.TypeParameter)]
        [Name(ColorCoderClassificationName.TypeParameter)]
        [UserVisible(false)]
        [Order(After = Priority.Default)]
        public sealed class TypeParameterClassificationFormat : ClassificationFormatDefinition
        {
            public TypeParameterClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.TypeParameter;
                this.ForegroundColor = Colors.TypeParameter;
            }
        }
    }
}