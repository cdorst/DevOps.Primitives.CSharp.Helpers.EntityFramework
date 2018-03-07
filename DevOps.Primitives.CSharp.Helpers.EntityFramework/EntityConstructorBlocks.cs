using DevOps.Primitives.CSharp.Helpers.Common;
using System.Collections.Generic;
using System.Linq;

namespace DevOps.Primitives.CSharp.Helpers.EntityFramework
{
    public static class EntityConstructorBlocks
    {
        public static Block AssignmentStatements(IEnumerable<EntityProperty> arguments)
            => Blocks.Create(Statements(arguments).ToArray());

        private static IEnumerable<Statement> Statements(IEnumerable<EntityProperty> arguments)
        {
            foreach (var argument in arguments) yield return EntityConstructorAssignmentStatements.Assignment(argument);
        }
    }
}
