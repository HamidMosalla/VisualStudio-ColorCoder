using System.ComponentModel.Composition;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using VisualStudio_ColorCoder.Settings;

namespace VisualStudio_ColorCoder.Classifications
{
    public static class ColorLoader
    {
        public static PresetColors PresetColors = new SettingIo().Load();
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
            this.ForegroundColor = ColorLoader.PresetColors.Interface;
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
            this.ForegroundColor = ColorLoader.PresetColors.Class;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.AbstractClass)]
    [Name(ColorCoderClassificationName.AbstractClass)]
    [UserVisible(true)]
    [Order(After = Priority.Default)]
    public sealed class AbstractClassClassificationFormat : ClassificationFormatDefinition
    {
        public AbstractClassClassificationFormat()
        {
            this.DisplayName = ColorCoderClassificationName.AbstractClass;
            this.ForegroundColor = ColorLoader.PresetColors.AbstractClass;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.StaticClass)]
    [Name(ColorCoderClassificationName.StaticClass)]
    [UserVisible(true)]
    [Order(After = Priority.Default)]
    public sealed class StaticClassClassificationFormat : ClassificationFormatDefinition
    {
        public StaticClassClassificationFormat()
        {
            this.DisplayName = ColorCoderClassificationName.StaticClass;
            this.ForegroundColor = ColorLoader.PresetColors.StaticClass;
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
            this.ForegroundColor = ColorLoader.PresetColors.Struct;
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
            this.ForegroundColor = ColorLoader.PresetColors.Enum;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.EnumConstant)]
    [Name(ColorCoderClassificationName.EnumConstant)]
    [UserVisible(true)]
    [Order(After = Priority.Default)]
    public sealed class EnumConstantClassificationFormat : ClassificationFormatDefinition
    {
        public EnumConstantClassificationFormat()
        {
            this.DisplayName = ColorCoderClassificationName.EnumConstant;
            this.ForegroundColor = ColorLoader.PresetColors.EnumConstant;
        }
    }

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
            this.ForegroundColor = ColorLoader.PresetColors.Constructor;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Attribute)]
    [Name(ColorCoderClassificationName.Attribute)]
    [UserVisible(true)]
    [Order(After = Priority.Default)]
    public sealed class AttributeClassificationFormat : ClassificationFormatDefinition
    {
        public AttributeClassificationFormat()
        {
            this.DisplayName = ColorCoderClassificationName.Attribute;
            this.ForegroundColor = ColorLoader.PresetColors.Attribute;
        }
    }

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
            this.ForegroundColor = ColorLoader.PresetColors.Field;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Local)]
    [Name(ColorCoderClassificationName.Local)]
    [UserVisible(true)]
    [Order(After = Priority.Default)]
    public sealed class LocalClassificationFormat : ClassificationFormatDefinition
    {
        public LocalClassificationFormat()
        {
            this.DisplayName = ColorCoderClassificationName.Local;
            this.ForegroundColor = ColorLoader.PresetColors.Local;
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
            this.ForegroundColor = ColorLoader.PresetColors.Namespace;
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
            this.ForegroundColor = ColorLoader.PresetColors.Method;
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
            this.ForegroundColor = ColorLoader.PresetColors.StaticMethod;
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
            this.ForegroundColor = ColorLoader.PresetColors.ExtensionMethod;
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
            this.ForegroundColor = ColorLoader.PresetColors.AutomaticProperty;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.TypeParameter)]
    [Name(ColorCoderClassificationName.TypeParameter)]
    [UserVisible(true)]
    [Order(After = Priority.Default)]
    public sealed class TypeParameterClassificationFormat : ClassificationFormatDefinition
    {
        public TypeParameterClassificationFormat()
        {
            this.DisplayName = ColorCoderClassificationName.TypeParameter;
            this.ForegroundColor = ColorLoader.PresetColors.TypeParameter;
        }
    }

    [Export(typeof(EditorFormatDefinition))]
    [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.Regions)]
    [Name(ColorCoderClassificationName.Regions)]
    [UserVisible(true)]
    [Order(After = Priority.Default)]
    public sealed class RegionsClassificationFormat : ClassificationFormatDefinition
    {
        public RegionsClassificationFormat()
        {
            this.DisplayName = ColorCoderClassificationName.Regions;
            this.ForegroundColor = ColorLoader.PresetColors.Regions;
        }
    }
}