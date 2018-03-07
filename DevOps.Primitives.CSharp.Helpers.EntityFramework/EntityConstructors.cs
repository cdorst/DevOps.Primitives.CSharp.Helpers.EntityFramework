using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using Microsoft.CodeAnalysis.CSharp;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityConstructors
    {
        public static Constructor BaseCase(string @class, IEnumerable<EntityProperty> arguments)
            => new Constructor(@class,
                EntityConstructorBlocks.AssignmentStatements(arguments),
                ModifierLists.Public,
                EntityConstructorParameters.Parameters(arguments));

        public static Constructor Linked(string @class,
            IEnumerable<EntityProperty> parameters,
            ArgumentList arguments)
            => new Constructor(@class,
                Blocks.Empty,
                ModifierLists.Public,
                EntityConstructorParameters.Parameters(parameters),
                constructorBaseInitializer: new ConstructorBaseInitializer()
                {
                    ArgumentList = arguments,
                    Kind = SyntaxKind.ThisConstructorInitializer
                });
    }
}
