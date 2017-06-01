﻿using System.ComponentModel.Composition;
using System.Windows.Media;
using Microsoft.VisualStudio.Text.Classification;
using Microsoft.VisualStudio.Utilities;
using VisualStudio_ColorCoder.Classifications;

namespace ColorCoder.Classifications
{
    public static class ClassificationTypeDefinitions
    {
        [Export(typeof(EditorFormatDefinition))]
        [ClassificationType(ClassificationTypeNames = ColorCoderClassificationName.EnumMember)]
        [Name(ColorCoderClassificationName.EnumMember)]
        [UserVisible(true)]
        [Order(After = Priority.Default)]
        public sealed class EnumConstantClassificationFormat : ClassificationFormatDefinition
        {
            public EnumConstantClassificationFormat()
            {
                this.DisplayName = ColorCoderClassificationName.EnumMember;
                this.ForegroundColor = Colors.Olive;
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
                this.ForegroundColor = Colors.OrangeRed;
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
                this.ForegroundColor = Colors.DarkOrange;
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
                this.ForegroundColor = Colors.Black;
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
                this.ForegroundColor = Colors.Black;
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
                this.ForegroundColor = Colors.Purple;
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
                this.ForegroundColor = Colors.LimeGreen;
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
                this.ForegroundColor = Colors.Magenta;
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
                this.ForegroundColor = Colors.Chocolate;
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
                this.ForegroundColor = Colors.Gray;
            }
        }
    }
}