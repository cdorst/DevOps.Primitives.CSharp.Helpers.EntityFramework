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
                .AddIEntityMethods(keyType, typeId)
                .WithUsingDirective(DevOpsCodeEntityModelCommonInterfacesEntity);

        public static ClassDeclaration ImplementIStaticEntity(
            this ClassDeclaration @class,
            string keyType,
            int typeId,
            IEnumerable<EntityProperty> properties)
            => @class
                .WithSingleBaseType(IStaticEntity, TypeArgumentLists.Create(keyType))
                .AddIEntityMethods(keyType, typeId)
                .WithMethods(GetUniqueIndex(@class.Identifier.Name.Value, properties))
                .WithUsings(
                    EntityUsings.System,
                    SystemLinqExpressions);

        private static ClassDeclaration AddIEntityMethods(
            this ClassDeclaration @class,
            string keyType,
            int typeId)
            => @class
                .WithMethods(
                    GetEntityType(typeId),
                    GetKey(keyType, $"{@class.Identifier.Name.Value}Id"));
    }
}
