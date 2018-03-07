using System.Collections.Generic;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntitySpecialCaseDerivatives
    {
        public static IEnumerable<EntityConstructorProperty> PropertyDerivatives(IEnumerable<EntityProperty> properties)
        {
            foreach (var property in properties) yield return Map(property);
        }

        private static EntityConstructorProperty Map(EntityProperty property)
            => new EntityConstructorProperty(property, MapDerivative(property))
                .WithArgument();

        private static EntityProperty MapDerivative(EntityProperty property)
        {
            var type = property.SpecialType;
            if (type.HasValue)
                switch (type.Value)
                {
                    case SpecialType.AsciiStringReference:
                    case SpecialType.AsciiMaxStringReference:
                    case SpecialType.UnicodeStringReference:
                    case SpecialType.UnicodeMaxStringReference:
                    case SpecialType.StringReference:
                        return property.WithType("string");

                    case SpecialType.List:
                        return property.AsListDerivative();

                    case SpecialType.BinaryShortReference:
                    case SpecialType.BinaryMaxReference:
                    case SpecialType.BinaryReference:
                        return property.WithType("byte[]");
                }
            return null;
        }

        private static EntityConstructorProperty WithArgument(this EntityConstructorProperty map)
        {
            if (map.PropertyDerivative == null) return map;
            var property = map.Property;
            return map.WithNewTypeArgument(property.Type, property.Name.WithLoweredFirstChar());
        }
    }
}
