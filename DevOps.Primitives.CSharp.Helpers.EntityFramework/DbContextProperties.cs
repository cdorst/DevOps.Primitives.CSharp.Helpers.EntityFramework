using DevOps.Primitives.CSharp.Helpers.Common;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContextProperties
    {
        public static Property Create(DbContextProperty property)
            => Create(property.SqlSchema, property.SqlTableName, property.TypeName, property.PropertyNameOverride);

        public static Property Create(string schema, string table, string entityType, string propertyName = null)
            => Properties.Public(
                name: $"{schema}_{table}",
                type: $"DbSet<{entityType}>");
    }
}
