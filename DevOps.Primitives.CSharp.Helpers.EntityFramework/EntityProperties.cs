using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityProperties
    {
        public static EntityProperty Create(string name, string type, string comment, string typeNamespace = null, string referenceKeyType = null)
            => new EntityProperty(name, type, comment, typeNamespace, referenceKeyType);

        public static Property Member(EntityProperty property, int protobufTag)
            => Member(property.Name, property.Type, property.SummaryComment, protobufTag);

        public static Property Member(string name, string type, string comment, int protobufTag)
            => Properties.Public(name, type, comment, EntityPropertyAttributes.Member(protobufTag));

        public static Property PrimaryKey(string entityType, string type = TypeConstants.Int)
            => Properties.Public(
                GetKeyName(entityType),
                type,
                GetKeyComment(entityType),
                EntityPropertyAttributes.PrimaryKey());

        public static IEnumerable<Property> Reference(EntityProperty property, int protobufTag)
            => Reference(property.Type, protobufTag, property.ReferenceInfo.KeyType, property.Name);

        public static IEnumerable<Property> Reference(string type, int protobufTag, string keyType = TypeConstants.IntNullable, string propertyName = null)
        {
            var name = NameHelper.GetName(type, propertyName);
            yield return GetReferenceEntity(name, type, protobufTag);
            yield return GetReferenceKey(name, keyType, type, protobufTag + 1);
        }

        private static string GetKeyComment(string entity) => $"{entity} unique identifier";

        private static string GetKeyName(string entity) => $"{entity}Id";

        private static Property GetReferenceEntity(string name, string type, int protobufTag)
            => Member(name, type, GetReferenceEntityComment(type), protobufTag);

        private static string GetReferenceEntityComment(string type) => $"{type} reference";

        private static Property GetReferenceKey(string name, string keyType, string entityType, int protobufTag)
            => Member(GetKeyName(name), keyType, GetReferenceKeyComment(entityType), protobufTag);

        private static string GetReferenceKeyComment(string type) => $"{type} foreign key";
    }
}
