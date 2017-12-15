using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContextPropertyLists
    {
        public static PropertyList Create(IEnumerable<DbContextProperty> properties)
            => PropertyLists.Create(
                GetProperties(properties).ToArray());

        public static IEnumerable<Property> GetProperties(IEnumerable<DbContextProperty> properties)
        {
            foreach (var property in properties) yield return DbContextProperties.Create(property);
        }
    }
}
