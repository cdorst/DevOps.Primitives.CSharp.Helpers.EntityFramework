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
                constructorList: EntityConstructorLists.Create(name, properties),
                propertyList: EntityPropertyLists.Create(name, properties, primaryKeyType));

        public static ClassDeclaration Editable(string name, string @namespace, IEnumerable<EntityProperty> properties, string tableSchema, string tableName, int typeId, string primaryKeyType = TypeConstants.Int)
            => Create(name, @namespace, properties, tableSchema, tableName, primaryKeyType)
                .ImplementIEntity(primaryKeyType, typeId);

        public static ClassDeclaration Editable(EntityDeclaration declaration)
            => Editable(declaration.Name, declaration.Namespace, declaration.Properties, declaration.TableSchema, declaration.TableName, declaration.GetTypeId(), declaration.GetKeyString());

        public static ClassDeclaration Static(string name, string @namespace, IEnumerable<EntityProperty> properties, string tableSchema, string tableName, int typeId, string primaryKeyType = TypeConstants.Int)
            => Create(name, @namespace, properties, tableSchema, tableName, primaryKeyType)
                .ImplementIStaticEntity(primaryKeyType, properties);

        public static ClassDeclaration Static(EntityDeclaration declaration)
            => Static(declaration.Name, declaration.Namespace, declaration.Properties, declaration.TableSchema, declaration.TableName, declaration.GetTypeId(), declaration.GetKeyString());

        private static UsingDirectiveList GetUsingDirectiveList(
            IEnumerable<EntityProperty> properties)
            => EntityUsings.Create(
                properties.Select(p => p.TypeNamespace).ToArray());
    }
}
