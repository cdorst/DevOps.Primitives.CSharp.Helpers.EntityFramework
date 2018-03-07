using System.Collections.Generic;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityDeclarations
    {
        public static EntityDeclaration Editable(string name, string @namespace, List<EntityProperty> properties, KeyType keyType = KeyType.Int, int? typeId = null)
            => new EntityDeclaration(name, @namespace, properties, keyType, EntityKind.Editable, typeId);

        public static EntityDeclaration Static(string name, string @namespace, List<EntityProperty> properties, KeyType keyType = KeyType.Int, int? typeId = null)
            => new EntityDeclaration(name, @namespace, properties, keyType, EntityKind.Static, typeId);
    }
}
