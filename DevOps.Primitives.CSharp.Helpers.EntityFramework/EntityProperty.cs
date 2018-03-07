using Humanizer;
using KnownType = DevOps.Primitives.CSharp.Helpers.EntityFramework.SpecialType;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public class EntityProperty
    {
        public string Name { get; set; }
        public EntityPropertyReferenceInfo ReferenceInfo { get; set; }
        public string SummaryComment { get; set; }
        public string Type { get; set; }
        public string TypeNamespace { get; set; }

        public bool IsReference => ReferenceInfo != null;
        public KnownType? SpecialType
        {
            get
            {
                switch (Type)
                {
                    case nameof(KnownType.AsciiStringReference):
                        return KnownType.AsciiStringReference;

                    case nameof(KnownType.AsciiMaxStringReference):
                        return KnownType.AsciiMaxStringReference;

                    case nameof(KnownType.UnicodeStringReference):
                        return KnownType.UnicodeStringReference;

                    case nameof(KnownType.UnicodeMaxStringReference):
                        return KnownType.UnicodeMaxStringReference;

                    case nameof(KnownType.StringReference):
                        return KnownType.StringReference;

                    case nameof(KnownType.BinaryShortReference):
                        return KnownType.BinaryShortReference;

                    case nameof(KnownType.BinaryMaxReference):
                        return KnownType.BinaryMaxReference;

                    case nameof(KnownType.BinaryReference):
                        return KnownType.BinaryReference;

                    case nameof(KnownType.ByteReference):
                        return KnownType.ByteReference;

                    case nameof(KnownType.BytePairReference):
                        return KnownType.BytePairReference;

                    case nameof(KnownType.ByteTreeReference):
                        return KnownType.ByteTreeReference;

                    case string type when type.EndsWith(nameof(KnownType.List)):
                        return KnownType.List;

                    case string type when type.EndsWith(nameof(KnownType.ListAssociation)):
                        return KnownType.ListAssociation;

                    default:
                        return null;
                }
            }
        }

        public EntityProperty AsListDerivative()
            => WithName(Name.TrimList()) // "WidgetList" => "Widget"
                .WithName(Name.Pluralize()) // "Widget" => "Widgets"
                .WithType(Type.TrimList()) // "WidgetList" => "Widget"
                .WithIEnumerableType(); // "Widget" => "IEnumerable<Widget>"

        public EntityProperty WithIEnumerableType()
            => WithType($"IEnumerable<{Type}>");

        public EntityProperty WithName(string name)
        {
            Name = name;
            return this;
        }

        public EntityProperty WithNameSuffix(string suffix)
            => WithName($"{Name}{suffix}");

        public EntityProperty WithType(string type)
        {
            Type = type;
            return this;
        }

        public EntityProperty WithTypePrefix(string prefix)
            => WithType($"{prefix}{Type}");

        public EntityProperty WithTypeSuffix(string suffix)
            => WithType($"{Type}{suffix}");
    }
}
