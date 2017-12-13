using DevOps.Primitives.CSharp.Helpers.Common;
using Humanizer;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContexts
    {
        public static Property GetDbSetProperty(string entityType, string propertyName = null)
            => Properties.Public(
                GetDbSetPropertyName(entityType, propertyName),
                GetDbSetPropertyType(entityType));

        public static Statement GetUniqueIndexStatement(string type, params string[] fields)
            => new Statement($"modelBuilder.Entity<{type}>().HasIndex(e => new {{ {GetUniqueIndexFields(fields)} }}).IsUnique();");

        private static string GetDbSetPropertyName(string entityType, string propertyName)
            => string.IsNullOrWhiteSpace(propertyName) ? entityType.Pluralize(false) : propertyName;

        private static string GetDbSetPropertyType(string entityType)
            => $"DbSet<{entityType}>";

        private static string GetUniqueIndexFields(params string[] fields)
            => string.Join(", ",
                fields.OrderBy(f => f).Select(f => $"e.{f}"));
    }
}
