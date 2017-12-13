using DevOps.Primitives.CSharp.Helpers.Common;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityPropertyAttributes
    {
        public static AttributeListCollection PrimaryKey()
            => AttributeLists.Create(
                Attributes.Key(),
                Attributes.ProtoMember(1));

        public static AttributeListCollection Member(int protobufTag)
            => AttributeLists.Create(
                Attributes.ProtoMember(protobufTag));
    }
}
