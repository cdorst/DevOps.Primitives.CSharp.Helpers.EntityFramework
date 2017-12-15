using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class DbContexts
    {
        private const string DbContext = nameof(DbContext);

        public static ClassDeclaration Create(string typeName, string @namespace, IEnumerable<DbContextProperty> properties, string baseType = DbContext, IEnumerable<UniqueIndex> uniqueIndexes = null)
            => new ClassDeclaration(
                typeName,
                @namespace,
                ModifierLists.Public,
                usingDirectiveList: DbContextUsings.Create(properties, @namespace),
                baseList: GetBaseList(baseType),
                constructorList: GetConstructorList(typeName),
                propertyList: DbContextPropertyLists.Create(properties),
                methodList: GetMethodList(uniqueIndexes));

        private static BaseList GetBaseList(string baseType)
            => BaseLists.Create(new BaseType(baseType));

        private static ConstructorList GetConstructorList(string typeName)
            => ConstructorLists.Create(
                DbContextConstructors.Create(typeName));

        private static MethodList GetMethodList(IEnumerable<UniqueIndex> uniqueIndexes)
            => uniqueIndexes == null ? null : MethodLists.Create(DbContextOnModelCreating.Create(uniqueIndexes));
    }
}
