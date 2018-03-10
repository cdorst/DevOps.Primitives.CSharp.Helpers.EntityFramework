using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;
using static DevOps.Primitives.CSharp.Helpers.Common.Methods;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityMethods
    {
        public static Method GetEntityType(int typeId)
            => PublicStatic(nameof(GetEntityType), TypeConstants.Int, $"{typeId}");

        public static Method GetKey(string type, string name)
            => Public(nameof(GetKey), type, name);

        public static Method GetUniqueIndex(
            string entityType,
            IEnumerable<EntityProperty> properties)
            => PublicStatic(nameof(GetUniqueIndex),
                $"Expression<Func<{entityType}, object>>",
                $"e => new {{ {UniqueIndex(properties)} }}");

        private static string UniqueIndex(IEnumerable<EntityProperty> properties)
            => string.Join(", ", properties.Select(p => UniqueIndexProperty(p)));

        private static string UniqueIndexProperty(EntityProperty property)
            => property.IsReference ? $"{property.Name}Id" : property.Name;
    }
}
