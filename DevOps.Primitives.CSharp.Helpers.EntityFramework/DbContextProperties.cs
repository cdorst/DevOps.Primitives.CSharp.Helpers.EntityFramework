using DevOps.Primitives.CSharp.Helpers.Common;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContextProperties
    {
        public static Property Create(DbContextProperty property)
            => Create(property.TypeName, property.PropertyNameOverride);

        public static Property Create(string entityType, string propertyName = null)
            => Properties.Public(
                NameHelper.GetNamePlural(entityType, propertyName),
                $"DbSet<{entityType}>");
    }
}
