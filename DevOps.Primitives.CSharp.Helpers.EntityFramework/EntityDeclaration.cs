using Humanizer;
using System.Collections.Generic;
using static DevOps.Primitives.CSharp.Helpers.Common.TypeConstants;
using Keys = DevOps.Primitives.CSharp.Helpers.EntityFramework.KeyType;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public class EntityDeclaration
    {
        public EntityDeclaration() { }
        public EntityDeclaration(string name, string @namespace, List<EntityProperty> properties, Keys keyType = Keys.Int, EntityKind entityKind = EntityKind.Static, int? typeId = null)
        {
            Name = name;
            Namespace = @namespace;
            Properties = properties;
            KeyType = keyType;
            EntityKind = entityKind;
            TypeId = typeId;
        }

        public KeyType? KeyType { get; set; }
        public string Name { get; set; }
        public EntityKind EntityKind { get; set; }
        public string Namespace { get; set; }
        public List<EntityProperty> Properties { get; set; }
        public int? TypeId { get; set; }

        public ClassDeclaration GetClassDeclaration()
            => EntityKind == EntityKind.Editable
                ? Entities.Editable(this)
                : Entities.Static(this);

        public string TableName => Name.Pluralize();
        public string TableSchema => Namespace.Replace(".", string.Empty);
        public string GetKeyString()
        {
            switch (KeyType ?? Keys.Int)
            {
                case Keys.Byte:
                    return Byte;
                case Keys.Short:
                    return Short;
                case Keys.Int:
                    return Int;
                case Keys.Long:
                    return Long;
                default:
                    return null;
            }
        }
        public int GetTypeId() => TypeId ?? $"{Namespace}.{Name}".GetHashCode();
    }
}
