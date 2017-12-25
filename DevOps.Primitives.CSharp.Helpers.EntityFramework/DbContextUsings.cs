using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContextUsings
    {
        private const string EfCoreNamespace = "Microsoft.EntityFrameworkCore";

        public static UsingDirectiveList Create(
            IEnumerable<DbContextProperty> properties,
            string dbContextNamespace,
            IEnumerable<string> additionalUsings = null)
            => UsingDirectiveLists.Create(
                GetUsings(properties)
                    .Where(u => u != dbContextNamespace)
                    .Union(additionalUsings ?? new string[] { })
                    .ToArray());

        private static HashSet<string> GetUsings(IEnumerable<DbContextProperty> properties)
        {
            var usings = new HashSet<string> { EfCoreNamespace };
            if (properties != null) foreach (var @namespace in properties.Select(p => p.TypeNamespace)) usings.Add(@namespace);
            return usings;
        }
    }
}
