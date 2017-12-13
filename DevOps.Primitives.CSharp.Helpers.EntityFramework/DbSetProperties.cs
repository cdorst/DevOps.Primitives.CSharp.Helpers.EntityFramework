using DevOps.Primitives.CSharp.Helpers.Common;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbSetProperties
    {
        public static Property Create(string entityType, string propertyName = null)
            => Properties.Public(
                NameHelper.GetNamePlural(entityType, propertyName),
                GetType(entityType));

        private static string GetType(string entityType)
            => $"DbSet<{entityType}>";
    }
}
