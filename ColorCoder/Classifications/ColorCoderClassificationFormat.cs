using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;

namespace ColorCoder.Classifications
{
    public static class ClassificationTypeDefinitions
    {
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Constructor)]
        [Name(ColorCoderClassificationName.Constructor)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class ConstructorClassificationFormat : ClassificationFormatDefinition
        {
            public ConstructorClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Constructor;
                this.IsBold = true;
            }
        }

        //[Export(typeof(EditorFormatDefinition))]
        //[ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Attribute)]
        //[Name(ColorCoderClassificationName.Attribute)]
        //[UserVisible(true)]
        //[Order(After = Priority.Default)]
        //public sealed class AttributeClassificationFormat : ClassificationFormatDefinition
        //{
        //    public AttributeClassificationFormat()
        //    {
        //        this.DisplayName = ColorCoderClassificationName.Attribute;
        //        this.ForegroundColor = Colors.Black;
        //    }
        //}

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Field)]
        [Name(ColorCoderClassificationName.Field)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class FieldClassificationFormat : ClassificationFormatDefinition
        {
            public FieldClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Field;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.LocalVariable)]
        [Name(ColorCoderClassificationName.LocalVariable)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class LocalClassificationFormat : ClassificationFormatDefinition
        {
            public LocalClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.LocalVariable;
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
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Method)]
        [Name(ColorCoderClassificationName.Method)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class MethodClassificationFormat : ClassificationFormatDefinition
        {
            public MethodClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Method;
                //this.FontTypeface = new Typeface(new FontFamily("Lucida Console"),
                //    FontStyles.Normal,
                //    FontWeights.Bold,
                //    FontStretches.Condensed);
                this.IsBold = true;
                this.FontRenderingSize = 12;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.StaticMethod)]
        [Name(ColorCoderClassificationName.StaticMethod)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class StaticMethodClassificationFormat : ClassificationFormatDefinition
        {
            public StaticMethodClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.StaticMethod;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.ExtensionMethod)]
        [Name(ColorCoderClassificationName.ExtensionMethod)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class ExtensionMethodClassificationFormat : ClassificationFormatDefinition
        {
            public ExtensionMethodClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.ExtensionMethod;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Property)]
        [Name(ColorCoderClassificationName.Property)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class PropertyClassificationFormat : ClassificationFormatDefinition
        {
            public PropertyClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Property;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Parameter)]
        [Name(ColorCoderClassificationName.Parameter)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class ParameterClassificationFormat : ClassificationFormatDefinition
        {
            public ParameterClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Parameter;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Class)]
        [Name(ColorCoderClassificationName.Class)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class ClassClassificationFormat : ClassificationFormatDefinition
        {
            public ClassClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Class;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Interface)]
        [Name(ColorCoderClassificationName.Interface)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class InterfaceClassificationFormat : ClassificationFormatDefinition
        {
            public InterfaceClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Interface;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Module)]
        [Name(ColorCoderClassificationName.Module)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class ModuleClassificationFormat : ClassificationFormatDefinition
        {
            public ModuleClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Module;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Struct)]
        [Name(ColorCoderClassificationName.Struct)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class StructClassificationFormat : ClassificationFormatDefinition
        {
            public StructClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Struct;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Enum)]
        [Name(ColorCoderClassificationName.Enum)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class EnumClassificationFormat : ClassificationFormatDefinition
        {
            public EnumClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Enum;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.EnumMember)]
        [Name(ColorCoderClassificationName.EnumMember)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class EnumMemberClassificationFormat : ClassificationFormatDefinition
        {
            public EnumMemberClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.EnumMember;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Delegate)]
        [Name(ColorCoderClassificationName.Delegate)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class DelegateClassificationFormat : ClassificationFormatDefinition
        {
            public DelegateClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.Delegate;
            }
        }

        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.GenericTypeParameter)]
        [Name(ColorCoderClassificationName.GenericTypeParameter)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class GenericTypeParameterClassificationFormat : ClassificationFormatDefinition
        {
            public GenericTypeParameterClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.GenericTypeParameter;
            }
        }
    }
}