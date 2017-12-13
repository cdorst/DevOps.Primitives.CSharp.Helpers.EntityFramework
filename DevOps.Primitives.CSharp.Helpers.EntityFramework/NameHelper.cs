using Humanizer;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    internal static class NameHelper
    {
        public static string GetName(string entityType, string propertyName = null)
            => !string.IsNullOrWhiteSpace(propertyName)
                ? propertyName
                : entityType;

        public static string GetNamePlural(string entityType, string propertyName = null)
            => GetName(entityType, propertyName).Pluralize(inputIsKnownToBeSingular: false);
    }
}
