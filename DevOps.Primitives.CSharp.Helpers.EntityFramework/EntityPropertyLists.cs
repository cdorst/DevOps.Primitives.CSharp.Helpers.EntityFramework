using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityPropertyLists
    {
        public static PropertyList Create(string typeName, IEnumerable<EntityProperty> properties, string primaryKeyType = TypeConstants.Int)
        {
            var props = new List<Property> { EntityProperties.PrimaryKey(typeName, primaryKeyType) };
            var protobufTag = 2;
            foreach (var property in properties)
            {
                if (property.IsReference)
                {
                    props.AddRange(EntityProperties.Reference(property, protobufTag));
                    protobufTag = protobufTag + 2;
                    continue;
                }

                props.Add(EntityProperties.Member(property, protobufTag));
                protobufTag++;
            }
            return PropertyLists.Create(props.ToArray());
        }
    }
}
