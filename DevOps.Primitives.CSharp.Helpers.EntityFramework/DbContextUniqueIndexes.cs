using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContextUniqueIndexes
    {
        public static IEnumerable<Statement> Create(IEnumerable<UniqueIndex> uniqueIndexes)
        {
            foreach (var index in uniqueIndexes) yield return GetStatement(index);
        }

        private static Statement GetStatement(UniqueIndex index)
            => new Statement(
                GetStatementString(index));

        private static string GetStatementString(UniqueIndex index)
            => $"modelBuilder.Entity<{index.Entity}>().HasIndex(e => new {{ {GetStatementStringFields(index.Fields)} }}).IsUnique();";

        private static string GetStatementStringFields(IEnumerable<string> fields)
            => string.Join(", ",
                fields.OrderBy(fieldName => fieldName).Select(fieldName => $"e.{fieldName}"));
    }
}
