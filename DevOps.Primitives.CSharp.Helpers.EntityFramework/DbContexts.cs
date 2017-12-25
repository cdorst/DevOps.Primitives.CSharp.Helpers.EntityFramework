using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContexts
    {
        private const string DbContext = nameof(DbContext);
        private const string UniqueStringsDbContext = nameof(UniqueStringsDbContext);
        private const string UniqueStringsDbContextNamespace = "DevOps.Primitives.Strings.EntityFramework";

        public static ClassDeclaration Create(string typeName, string @namespace, IEnumerable<DbContextProperty> properties, string baseType = DbContext, IEnumerable<UniqueIndex> uniqueIndexes = null, IEnumerable<string> additionalUsings = null)
            => new ClassDeclaration(
                typeName,
                @namespace,
                ModifierLists.Public,
                usingDirectiveList: DbContextUsings.Create(properties, @namespace, additionalUsings),
                baseList: GetBaseList(baseType),
                constructorList: GetConstructorList(typeName),
                propertyList: DbContextPropertyLists.Create(properties),
                methodList: GetMethodList(uniqueIndexes));

        public static ClassDeclaration CreateUniqueStringsDbContext(string typeName, string @namespace, IEnumerable<DbContextProperty> properties, IEnumerable<UniqueIndex> uniqueIndexes = null, IEnumerable<string> additionalUsings = null)
            => Create(typeName, @namespace, properties, UniqueStringsDbContext, uniqueIndexes, (additionalUsings ?? new string[] { })?.Union(new string[] { UniqueStringsDbContextNamespace }));

        private static BaseList GetBaseList(string baseType)
            => BaseLists.Create(new BaseType(baseType));

        private static ConstructorList GetConstructorList(string typeName)
            => ConstructorLists.Create(
                DbContextConstructors.Create(typeName));

        private static MethodList GetMethodList(IEnumerable<UniqueIndex> uniqueIndexes)
            => uniqueIndexes == null ? null : MethodLists.Create(DbContextOnModelCreating.Create(uniqueIndexes));
    }
}
