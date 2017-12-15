using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContextOnModelCreating
    {
        private const string ArgumentName = "modelBuilder";
        private const string ArgumentType = "ModelBuilder";
        private const string MethodName = "OnModelCreating";

        public static Method Create(IEnumerable<UniqueIndex> uniqueIndexes)
            => new Method(
                MethodName,
                TypeConstants.Void,
                new ParameterList(ArgumentName, ArgumentType),
                Blocks.Create(GetStatements(uniqueIndexes)),
                ModifierLists.ProtectedOverride);

        private static Statement[] GetStatements(IEnumerable<UniqueIndex> uniqueIndexes)
        {
            var statements = new List<Statement> { GetBaseMethodInvocationStatement() };
            statements.AddRange(DbContextUniqueIndexes.Create(uniqueIndexes));
            return statements.ToArray();
        }

        public static Statement GetBaseMethodInvocationStatement()
            => new Statement($"base.{MethodName}({ArgumentName});");
    }
}
