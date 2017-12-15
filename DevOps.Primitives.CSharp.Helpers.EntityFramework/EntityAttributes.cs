using DevOps.Primitives.CSharp.Helpers.Common;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityAttributes
    {
        public static AttributeListCollection Create(string name, string tableSchema = null, string tableName = null)
            => AttributeLists.Create(
                Attributes.ProtoContract(),
                GetTableAttribute(name, tableSchema, tableSchema));

        private static Attribute GetTableAttribute(string name, string tableSchema = null, string tableName = null)
            => Attributes.Table(
                NameHelper.GetNamePlural(name, tableName),
                tableSchema);
    }
}
