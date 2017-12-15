using DevOps.Primitives.CSharp.Helpers.Common;
using Humanizer;
using System.Collections.Generic;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContextPropertyLists
    {
        public static PropertyList Create(IEnumerable<DbContextProperty> properties)
            => Proper();

        public static IEnumerable<Property> GetProperties(IEnumerable<DbContextProperty> properties)
        {
            foreach (var property in properties) yield return DbContextProperties.Create(property);
        }
    }

    public static class DbContextProperties
    {
        public static Property Create(DbContextProperty property)
            => Create(property.TypeName, property.PropertyNameOverride);

        public static Property Create(string entityType, string propertyName = null)
            => Properties.Public(
                NameHelper.GetNamePlural(entityType, propertyName),
                $"DbSet<{entityType}>");
    }

    public class DbContextProperty
    {
        public string TypeName { get; set; }
        public string TypeNamespace { get; set; }
        public string PropertyNameOverride { get; set; }
    }
}
