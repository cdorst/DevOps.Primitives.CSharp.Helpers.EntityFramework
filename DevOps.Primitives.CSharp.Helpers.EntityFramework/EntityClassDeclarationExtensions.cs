using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using static DevOps.Primitives.CSharp.Helpers.EntityFramework.EntityInterfaces;
using static DevOps.Primitives.CSharp.Helpers.EntityFramework.EntityMethods;
using static DevOps.Primitives.CSharp.Helpers.EntityFramework.EntityUsings;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityClassDeclarationExtensions
    {
        public static ClassDeclaration ImplementIEntity(
            this ClassDeclaration @class,
            string keyType,
            int typeId)
            => @class
                .WithBase(IEntity, TypeArgumentLists.Create(keyType))
                .WithMethods(
                    GetEntityType(typeId),
                    GetKey(keyType, $"{@class.Identifier.Name.Value}Id"))
                .WithUsingDirective(DevOpsCodeEntityModelCommonInterfacesEntity);

        public static ClassDeclaration ImplementIStaticEntity(
            this ClassDeclaration @class,
            string keyType,
            IEnumerable<EntityProperty> properties)
            => @class
                .WithSingleBaseType(IStaticEntity, TypeArgumentLists.Create(keyType))
                .WithMethod(GetUniqueIndex(@class.Identifier.Name.Value, properties))
                .WithUsings(
                    EntityUsings.System,
                    SystemLinqExpressions);
    }
}
