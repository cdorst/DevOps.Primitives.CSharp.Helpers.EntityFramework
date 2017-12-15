using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class Entities
    {
        public static ClassDeclaration Create(string name, string @namespace, IEnumerable<EntityProperty> properties, string tableSchema = null, string tableName = null, string primaryKeyType = TypeConstants.Int)
            => new ClassDeclaration(name, @namespace,
                ModifierLists.Public,
                GetUsingDirectiveList(properties),
                attributeListCollection: EntityAttributes.Create(name, tableSchema, tableName),
                propertyList: EntityPropertyLists.Create(name, properties, primaryKeyType));

        private static UsingDirectiveList GetUsingDirectiveList(IEnumerable<EntityProperty> properties)
            => EntityUsings.Create(
                properties.Select(p => p.TypeNamespace).ToArray());
    }
}
